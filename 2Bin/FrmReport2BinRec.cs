using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatabaseHelper;
using DatabaseHelper1;
using DevExpress.XtraGrid.Columns;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace PicklistBOM._2Bin
{
    public partial class FrmReport2BinRec : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmReport2BinRec()
        {
            InitializeComponent();
        }

        private void รายงานใบเบก2BinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinAll page = new PicklistBOM._2Bin.FrmReport2BinAll();
            page.Show();
            this.Hide();
        }

        private void รายงานสรปยอดจายรบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinRec page = new PicklistBOM._2Bin.FrmReport2BinRec();
            page.Show();
            this.Hide();
        }

        private void FrmReport2BinRec_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet3.View_DocOrder' table. You can move, or remove it, as needed.
            this.view_DocOrderTableAdapter.Fill(this.dBBARCODEDataSet3.View_DocOrder);
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            //หา cell ที่เบิก
            string resultdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
            CallDetail(resultdate);

            GenAotokey();

            //search
            string resultdate1 = DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            CallShow(resultdate1);
        }

        #region "CallShow"
        private void CallShow(string tmpdate)
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT  N.Cnumber, N.Type ,  N.PONumber,  N.BOI,  N.Sdate,  N.Type, N.Date2bin ,N.DocUser, N.DocApprove, N.DocRunApporve "
                + ", N.ReceiveDate, N.ReceveUser, N.ReceiveDateA,  N.ReceiveUserA, N.ReceiveRunNum,'Print' as Print1,"
                + " (select EmpName From dbo.DatEmp E Where E.EmpCode =N.docuser) As DocUser1,(select EmpName From dbo.DatEmp E Where E.EmpCode =N.DocApprove) As DocApprove1,"
                + " (select EmpName From dbo.DatEmp E Where E.EmpCode =N.ReceveUser) As ReceveUser1,(select EmpName From dbo.DatEmp E Where E.EmpCode =N.ReceiveUserA) As ReceiveUserA1 "
                + " FROM  Lean_Doc2BinNuber N where N.Sdate ='" + tmpdate + "' order by N.Cnumber";


                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables["Showdata"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                   // MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data");
            }
            conn.Close();
        }
        #endregion

        #region "AutoKey"
        private void GenAotokey()
        {
            int iJobid = 0;
            string tmpOrder;
            int OrderID = 0;
            //string resultdate1 = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string resultdate = this.startdate.Value.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string y = Right(resultdate, 2);
            string d = Left(resultdate, 2);
            string M = Mid(resultdate, 3, 2); //C1403
            string dmy = "C" + y + M +"/";

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = " select MAX(Cnumber) As Number from dbo.Lean_Doc2BinNuber where Cnumber like '" + dmy + "%'  ";
                tmpOrder = (String)sqlCmd.ExecuteScalar();

                OrderID = Convert.ToInt32(Right(tmpOrder, 4));
                OrderID = OrderID + 1;

                txtno.Text = dmy + OrderID.ToString("0000");
                //strnewid = strnewid.PadLeft(4, '0');    
            }

            catch (Exception ex)
            {
                txtno.Text = dmy + OrderID.ToString("0001");
            }
            conn.Close();



        }
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }
        #endregion




#region " CallDetail();"
        private void CallDetail(string tmpdate)
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";
                //  strSQL1 = " select style,style from dbo.tb_DatSpecW1  Where model='" + this.cbomodel.SelectedValue + "'";
                strSQL1 = " select distinct(LineCell) as cell,DocUser from dbo.Lean_Doc2Bin  where  CONVERT(VARCHAR(10),DocUserDate,110)='" + tmpdate + "' order by LineCell";

                if (Isfind2 == true)
                {
                    ds.Tables["style"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                //*** DropDownList ***// 
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    this.CboLine.DisplayMember = "cell";
                    this.CboLine.ValueMember = "DocUser";
                    this.CboLine.DataSource = ds.Tables["style"];

                }
                else
                {
                    Isfind2 = false;
                    this.CboLine.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;

                CboLine.SelectedValue = "12";
            }
            catch (Exception ex)
            {


            }
        }

        #endregion

        #region "  CallSave();"
        private void CallSave()
        {
            if ((CGlobal.Tmptpe == null)||(CGlobal.Tmptpe == ""))
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO dbo.Lean_Doc2BinNuber (Cnumber, PONumber, BOI, Sdate, Type, Status, Date2bin, DocUser, DocApprove,DocRunApporve)");
                query.Append(" VALUES (@Cnumber, @PONumber, @BOI, @Sdate, @Type, @Status, @Date2bin, @DocUser, @DocApprove, @DocRunApporve)");

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                using (var db = new DbHelper1())
                {
                    try
                    {

                        string Tmpdate = this.startdate.Value.ToString("yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        string tmpAuto = Tmpdate + Right(txtno.Text.Trim(), 4);


                        string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                        Double num = Convert.ToDouble(CGlobal.QtyOut) + 1;
                        // string d1 = DateTime.Now.ToShortDateString();
                        string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                        db.AddParameter("@Cnumber", txtno.Text.Trim());
                        db.AddParameter("@PONumber", this.cboDocRefNo.Text);
                        db.AddParameter("@BOI", txtBOI.Text);
                        db.AddParameter("@Sdate", sdate);
                        db.AddParameter("@Type", this.CboLine.Text);
                        db.AddParameter("@Status", "1");
                        db.AddParameter("@Date2bin", DateTime.Now);
                        db.AddParameter("@DocUser", this.CboLine.SelectedValue);
                        db.AddParameter("@DocApprove", CGlobal.UserID);
                        db.AddParameter("@DocRunApporve", tmpAuto);
                        db.ExecuteNonQuery(query.ToString());
                        //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                    }

                    catch (Exception ex)
                    {
                        // db.RollbackTransaction();
                        //  MessageBox.Show("No Transfer");

                    }
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("คุณทำใบเบิก . " + this.CboLine.Text +" นี้แล้ว ");
                CGlobal.Tmptpe = "";
            }
        
        }
        #endregion
      
        #region "        CallSearch();"
        private void CallSearch()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select PONumber from dbo.Lean_Doc2BinNuber "
              + " Where PONumber ='" + this.cboDocRefNo.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    CGlobal.PO2BIN = rs["PONumber"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();

        
        }

        #endregion

        #region "        CallSearchCell();"
        private void CallSearchCell(string cell)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            CGlobal.Tmptpe = "";

            string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select Type from dbo.Lean_Doc2BinNuber "
              + " Where Type ='" + cell + "' and  Sdate ='" + sdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    CGlobal.Tmptpe = rs["Type"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();


        }

        #endregion



        private void bntreport_Click(object sender, EventArgs e)
        {

            if (txtBOI.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลก่อน");
                return;
            
            }
            if (this.CboLine.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน Cell ก่อน");
                return;

            }
            if ((MessageBox.Show("คุณต้องการบันทึก เลขที่: " + txtno.Text.Trim() + " Type : " + this.CboLine.Text + " นี้หรือไม่ ", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            { 

                CallSearch();
                CallSearchCell(this.CboLine.Text);
                if (CGlobal.BinNo != null)
                {
                    //ReportDocument crReportDocument = new ReportDocument();
                    //crReportDocument.Load(Application.StartupPath + "\\Report2Bin\\2BinType.rpt");

                    //ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

                    //string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                    //// string edate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));

                    //string startDate = sdate + " 08:00:00.310";
                    //string EndtDate = sdate + " 23:00:00.310";


                    //crReportDocument.SetParameterValue(0, EndtDate);
                    //crReportDocument.SetParameterValue(1, startDate);
                    //crReportDocument.SetParameterValue(2, this.CboLine.Text);
                    //crReportDocument.SetParameterValue(3, this.cboDocRefNo.Text);
                    //crReportDocument.SetParameterValue(4, this.txtno.Text);
                    //crReportDocument.SetParameterValue(5, this.txtBOI.Text);


                    //crystalReportViewer1.ReportSource = crReportDocument;
                    //crystalReportViewer1.DisplayGroupTree = false;

                    //CGlobal.BinNo = null;
                    //CGlobal.BinPO = null;
                    //CGlobal.BinBOI = null;
                    //CGlobal.BinDate = null;
                    MessageBox.Show("มีในระบบแล้ว");
                }

                else if (CGlobal.PO2BIN == this.cboDocRefNo.Text)
                {
                    MessageBox.Show("PO# ซ้ำ กรุณาตรวจสอบอีกครั้ง ก่อน");
                    return;

                }
                else
                {
                    CallSave();
                    GenAotokey();
                    string resultdate1 = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                    CallShow(resultdate1);
                  
                }
            }
        }

        private void cboDocRefNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallInsertQty();
        }

        #region "CallInsertQty();"
        private void CallInsertQty()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                string temp = this.cboDocRefNo.Text;

                Cmd = new System.Data.SqlClient.SqlCommand(" select DocNo,DocProj from dbo.DocMO where  DocNo ='" + temp + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.txtBOI.Text = rs["DocProj"].ToString();

                }

                // Callgridview();
            }
            catch (Exception ex)
            {

          
            }
            conn.Close();



        }
        #endregion

        private void txtBOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                CallInsertQty();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            ShowNo page = new PicklistBOM._2Bin.ShowNo();  //admin
            page.ShowDialog();
           // this.Hide();

            txtno.Text = CGlobal.BinNo;
            cboDocRefNo.Text = CGlobal.BinPO;
            txtBOI.Text = CGlobal.BinBOI;
            startdate.Value = Convert.ToDateTime(CGlobal.BinDate);
            CboLine.Text = CGlobal.Bintype;
            }
            catch (Exception ex)
            {


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CGlobal.BinNo = null;
            CGlobal.BinPO = null;
            CGlobal.BinBOI = null;
            CGlobal.BinDate = null;
            GenAotokey();
            txtBOI.Text = "";
            cboDocRefNo.Text = "";
        }

        private void biinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("คุณต้องการลบเลขที่ : " + txtno.Text.Trim() + "  นี้หรือไม่ ", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.Lean_Doc2BinNuber  Where  Cnumber = '" + txtno.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

                CGlobal.BinNo = null;
                CGlobal.BinPO = null;
                CGlobal.BinBOI = null;
                CGlobal.BinDate = null;
                GenAotokey();
                txtBOI.Text = "";
                cboDocRefNo.Text = "";
                string resultdate1 = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                CallShow(resultdate1);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void startdate_ValueChanged(object sender, EventArgs e)
        {
            string sdate = this.startdate.Value.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
            CallDetail(sdate);
            GenAotokey();

            string resultdate1 = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            CallShow(resultdate1);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            CGlobal.IssueNo2 = Convert.ToString(gridView1.GetDataRow(index)["Cnumber"]);
            string DocApprove1 = Convert.ToString(gridView1.GetDataRow(index)["ReceiveUserA1"]);
            string Sdate = Convert.ToString(gridView1.GetDataRow(index)["Sdate"]);
            CGlobal.IssueType = Convert.ToString(gridView1.GetDataRow(index)["Type"]);
            CGlobal.BinPO = Convert.ToString(gridView1.GetDataRow(index)["POnumber"]);
            CGlobal.BinBOI = Convert.ToString(gridView1.GetDataRow(index)["BOI"]);

            if ((DocApprove1 == null) || (DocApprove1 == ""))
            {
                MessageBox.Show("ยังไม่ผ่านการ อนุมัติ ไม่สามารถพิพม์ได้");
            }
            else
            {
                string startDate = Sdate + " 08:00:00.310";
                string EndtDate = Sdate + " 23:00:00.310";

                CGlobal.IssueSdate = startDate;
                CGlobal.IssueEdate = EndtDate;

                _2Bin.View2BinIssue page = new _2Bin.View2BinIssue();
                page.ShowDialog();

                CGlobal.IssueNo2 = "";
                CGlobal.IssueSdate = "";
                CGlobal.IssueEdate = "";
                CGlobal.IssueType = "";
                CGlobal.BinPO = "";
                CGlobal.BinBOI = "";
            }
        }

    }
}
