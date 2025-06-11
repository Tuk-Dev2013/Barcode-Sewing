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

namespace PicklistBOM._2Bin
{
    public partial class FrmReceive2Bin : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        public FrmReceive2Bin()
        {
            InitializeComponent();
        }

        private void FrmReceive2Bin_Load(object sender, EventArgs e)
        {
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            month();
            this.cboyear.Text = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
            this.cbomonth.SelectedValue = DateTime.Now.ToString("MM", new System.Globalization.CultureInfo("en-US"));

            if ((CGlobal.EmpPost == "1") || (CGlobal.EmpPost == "6") || (CGlobal.EmpPost == "7"))
            {
                this.lblme.Text = "คุณมีสิทธิ์ในการอนุมัติ 2Bin";
            }
            else
            
            {
                this.lblme.Text = "คุณมีสิทธิ์ในการรับ 2Bin";
            }
        }
        #region " month()"
        private void month()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string strSQL1 = "";
                strSQL1 = "  SELECT  Month, MonthName FROM DocIssueMonth ORDER BY Month";

                if (Isfind == true)
                {
                    ds.Tables["style"].Clear();
                }
                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind = true;
                    this.cbomonth.DisplayMember = "MonthName";
                    this.cbomonth.ValueMember = "Month";
                    this.cbomonth.DataSource = ds.Tables["style"];
                }
                else
                {
                    Isfind = false;
                    this.cbomonth.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;
            }
            catch (Exception ex)
            {


            }
        }

        #endregion



        #region " AutoKey();"
        private void AutoKey(string Appdate)
        {
            string tmpOrder;
            int OrderID = 0;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = " Select Max(ReceiveRunNum)  from Lean_Doc2BinNuber  Where ReceiveRunNum like'" + Appdate + "%'";
                tmpOrder = (String)sqlCmd.ExecuteScalar();
                OrderID = Convert.ToInt32(Right(tmpOrder, 4));
                OrderID = OrderID + 1;
                //  txtAuto.Text = lblmessage.Text.Trim() +'-'+ d + M + y + OrderID.ToString("00");
                CGlobal.IssueLotnumber2Bin = Appdate + OrderID.ToString("0000");
            }

            catch (Exception ex)
            {
                // txtAuto.Text = lblmessage.Text.Trim() + '-' + d + M + y +  OrderID.ToString("01");
                CGlobal.IssueLotnumber2Bin = Appdate + OrderID.ToString("0001");

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

        private void bntApprove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("คุณต้องการ Production Receipt CNC นี่ใช่หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string ckh = Convert.ToString(gridView1.GetDataRow(i)["ckh"]);

                    if (ckh == "True")
                    {
                        string Cnumber = Convert.ToString(gridView1.GetDataRow(i)["Cnumber"]);
                        string ReceveUser = Convert.ToString(gridView1.GetDataRow(i)["ReceveUser"]);
                        string ReceiveUserA = Convert.ToString(gridView1.GetDataRow(i)["ReceiveUserA1"]);
                       

                        //หา lotnumber คนรับ
                        string Appdate = DateTime.Now.ToString("yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        AutoKey(Appdate);

       

                        if ((CGlobal.EmpPost == "1") || (CGlobal.EmpPost == "6") || (CGlobal.EmpPost == "7"))
                        {//เอ็ก 
                            if ((ReceveUser == null) || (ReceveUser == ""))
                            {
                                MessageBox.Show("ต้องรับ 2 Bin ก่อนค่ะ กรุณาติดต่อเจ้าหน้าที่ 2Bin รับวัตถุดิบ!!!");
                               // return;
                            }
                            else
                            {
                                if ((ReceiveUserA == null) || (ReceiveUserA == ""))
                                {
                                    UpdateApport(Cnumber);
                                    CGlobal.IssueLotnumber2Bin = "";
                                }
                            }

                        }
                        else
                        //วุ้น 
                        {
                            UpdateRe2Bin(Cnumber);
                        }


                        //CGlobal.IssueLotnumberCNC1 = "";
                    }
                }
                this.gridshow.DataSource = null;

                string resultdate1 = cboyear.Text + "-" + cbomonth.SelectedValue;
                CallShow(resultdate1);
            }
        }

        #region "UpdateRe2Bin"
        private void UpdateRe2Bin(string Cnumber)
        {

            var query = new StringBuilder();
            query.Append("UPDATE  dbo.Lean_Doc2BinNuber SET");
            query.Append(" ReceveUser  = @ReceveUser");
            query.Append(", ReceiveDate  = @ReceiveDate");
            query.Append(" WHERE Cnumber =  @Cnumber");
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@ReceveUser", CGlobal.UserID);
                    db.AddParameter("@ReceiveDate", DateTime.Now);
                    db.AddParameter("@Cnumber", Cnumber);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }


        }
        #endregion

        #region "UpdateApport"
        private void UpdateApport(string cnumber)
        {
            var query = new StringBuilder();
            query.Append("UPDATE  dbo.Lean_Doc2BinNuber SET");
            query.Append(" ReceiveUserA  = @ReceiveUserA");
            query.Append(", ReceiveDateA  = @ReceiveDateA");
            query.Append(", ReceiveRunNum  = @ReceiveRunNum");
            query.Append(" WHERE Cnumber =  @Cnumber");
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@ReceiveUserA", CGlobal.UserID);
                    db.AddParameter("@ReceiveDateA", DateTime.Now);
                    db.AddParameter("@ReceiveRunNum", CGlobal.IssueLotnumber2Bin);
                    db.AddParameter("@Cnumber", cnumber);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        
        }
        #endregion

        #region "search"
        private void bntsearch_Click(object sender, EventArgs e)
        {
            string resultdate1 = cboyear.Text  + "-" + cbomonth.SelectedValue;
          CallShow(resultdate1);
        }
        #endregion


        #region "CallShow"
        private void CallShow(string tmpdate)
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT  CAST('FALSE' as bit)  as ckh,N.Cnumber, N.Type ,  N.PONumber,  N.BOI,  N.Sdate,  N.Type, N.Date2bin ,N.DocUser, N.DocApprove, N.DocRunApporve "
                + ", N.ReceiveDate, N.ReceveUser, N.ReceiveDateA,  N.ReceiveUserA, N.ReceiveRunNum,'Detail' as Print1,"
                + " (select EmpName From dbo.DatEmp E Where E.EmpCode =N.docuser) As DocUser1,(select EmpName From dbo.DatEmp E Where E.EmpCode =N.DocApprove) As DocApprove1,"
                + " (select EmpName From dbo.DatEmp E Where E.EmpCode =N.ReceveUser) As ReceveUser1,(select EmpName From dbo.DatEmp E Where E.EmpCode =N.ReceiveUserA) As ReceiveUserA1 "
                + " FROM  Lean_Doc2BinNuber N where N.Sdate like '" + tmpdate + "%' and   DocApprove  IS NOT NULL  order by N.Cnumber";


                if (Isfind2 == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables["Showdata"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind2 = false;
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

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            CGlobal.Issuecell = Convert.ToString(gridView1.GetDataRow(index)["Type"]);
            CGlobal.Issuecelldate = Convert.ToString(gridView1.GetDataRow(index)["Sdate"]);

            _2Bin.FrmShowDetail2Bin page = new _2Bin.FrmShowDetail2Bin();
            page.ShowDialog();
        }

    }
}
