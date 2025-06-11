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
using System.Configuration;


namespace PicklistBOM.Sewing
{
    public partial class FrmSewnAdmin : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmSewnAdmin()
        {
            InitializeComponent();
        }

        private void scToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSewnAdmin page = new FrmSewnAdmin();
            page.Show();
            this.Hide();
        }

        private void FrmSewnAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet14.View_PORefQty' table. You can move, or remove it, as needed.
            this.view_PORefQtyTableAdapter.Fill(this.dBBARCODEDataSet14.View_PORefQty);
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            ShowCell();
        }

        #region "   ShowCell()"
        private void ShowCell()
        {
            this.ShowCellT.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL"];
                string strSQL1 = "";
                strSQL1 = " select ScheduleID,Sequence,Startday,Docno,Qtyin,QtyOut,remark FROM Sewing_Schedule where  Qtyin<>Qtyout and Cellname='" + tmpcell + "' order by Sequence ";
                if (Isfind1 == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showdata2"];
                    ShowCellT.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                    this.ShowCellT.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();
        
        }
        #endregion

        #region "check"
        private void CallBarcode(string DocNo)
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select Docno from Sewing_Schedule  where Docno ='" + cboCell.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.tmpcheck10 = "YES";

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }

        #endregion

        #region "AutoKey"
        private void GenAotokey()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                CGlobal.IssueNumber2 = "1";
                Cmd = new System.Data.SqlClient.SqlCommand(" select MAX(Sequence) As Number from dbo.Sewing_Schedule where  QtyInSeat<>QtyInBom", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.IssueNumber2 = rs["Number"].ToString();
                    if (CGlobal.IssueNumber2 == "")
                    {
                        CGlobal.IssueNumber2 = "1";
                    }
                    else
                    {
                        CGlobal.IssueNumber2 = Convert.ToString(Convert.ToInt16(CGlobal.IssueNumber2) + 1);
                    }

                }
  
            }
            catch (Exception ex)
            {
                CGlobal.IssueNumber2 = "1";
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

        #region "CallBarcodeQry"
        private void CallBarcodeQry(string po)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                //   Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(qtyBom) as Qty  from dbo.DocMODtl  where DocNo ='" + po + "' and BomNo In (" + temp + ") and ItemCode like 'W8%' and DeptCode='W8' ", conn);

                Cmd = new System.Data.SqlClient.SqlCommand(" select  SUM(docqty)  as Qty  from dbo.DocOrderDtl  where DocNo ='" + po + "' and BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.qtytotalE = rs["Qty"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }
        #endregion

        #region "CallSum"
        private void CallSum(string docno)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" select  sum(Qtybom) as sumbom from dbo.DocMODtl  where DocNo ='" + docno + "' and deptcode='W2' and right(itemcode,4) in('BACK','SEAT','BODY')", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.qtytotalEBom = rs["sumbom"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }

        #endregion

        private void bntadd_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึก PO#." + txtPo.Text.Trim() + " Schedule นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
           
                        // หา max number
                        GenAotokey();
                        int n = Convert.ToInt16(CGlobal.IssueNumber2);
                        //for (int i = 0; i < ds.Tables["Sewing"].Rows.Count; i++)
                        //{
                            //string DocNo = ds.Tables["Sewing"].Rows[i]["DocNo"].ToString();
                            //string SumDoc = ds.Tables["Sewing"].Rows[i]["SumDoc"].ToString();

                            CallBarcodeQry(cboCell.Text.Trim());

                            CallBarcode(txtPo.Text.Trim());

                            if (CGlobal.tmpcheck10 == "YES")
                            {
                                MessageBox.Show("คุณป้อน PO Cell ซ้ำ หรือ PO ผลิตจบไปแล้ว");
                                CGlobal.tmpcheck10 = "No";
                               // return;
                            }
                            else
                            {

                                //insert
                                var query = new StringBuilder();
                                query.Append("INSERT INTO Sewing_Schedule(Docno, Cellname, QtyIn, QtyOut, Startday, Remark, TempType, Status, Sequence, UserID, QtyBack, QtySeat, QtyBody,QtyInSeat, QtyInBom)");
                                query.Append(" VALUES (@Docno, @Cellname, @QtyIn, @QtyOut, @Startday, @Remark, @TempType, @Status, @Sequence, @UserID, @QtyBack, @QtySeat, @QtyBody, @QtyInSeat, @QtyInBom)");

                                SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                                conn1.Open();
                                using (var db = new DbHelper1())
                                {
                                    try
                                    {
                                        // Rsofa
                                       // double num = Convert.ToDouble(CGlobal.qtytotalE) * 3; //comment ไว้
                                        CallSum(cboCell.Text.Trim());

                                        //sofa
                                        //double nsum = Convert.ToDouble(CGlobal.qtytotalE) * 2;
                                        //double nnum = Convert.ToDouble(CGlobal.qtytotalE) * 3;
                                        //double num = nsum + nnum;

                                        db.AddParameter("@Docno", cboCell.Text.Trim());
                                        db.AddParameter("@Cellname", ConfigurationManager.AppSettings["SHOW_CELL"]); // ค่อยเปลี่ยน cell 1,2 ต่อไป ตรงนี้
                                        db.AddParameter("@QtyIn", CGlobal.qtytotalE);
                                        db.AddParameter("@QtyOut", 0);
                                        db.AddParameter("@Startday", DateTime.Now);
                                        db.AddParameter("@Remark", txtPo.Text.Trim());
                                        db.AddParameter("@TempType", "");
                                        db.AddParameter("@Status", "1");
                                        db.AddParameter("@Sequence", n);
                                        db.AddParameter("@UserID", CGlobal.UserID);
                                        db.AddParameter("@QtyBack", 0);
                                        db.AddParameter("@QtySeat", 0);
                                        db.AddParameter("@QtyBody", 0);
                                        db.AddParameter("@QtyInSeat", 0);
                                        db.AddParameter("@QtyInBom", CGlobal.qtytotalEBom);
                                        db.ExecuteNonQuery(query.ToString());
                                        CGlobal.qtytotalEBom = "0";
                                    }

                                    catch (Exception ex)
                                    {
                                        // db.RollbackTransaction();
                                        MessageBox.Show("No Save Sewing_Schedule");

                                    }
                                    n = n + 1;
                                }
                               // conn1.Close();

                                //UpdateDocMODtl(txtPo.Text.Trim());

                                //SearhUpdatePO(txtPo.Text.Trim());

                            }
                      // }
              
                //    }
                //    else
                //    {
                //        Isfind = false;
             
                //        return;
                //    }
                //    //  dataGridView1.DataBindings();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("No Data Save Sewing");
                //}
                //conn.Close();
             
           

               // string tmpsqlRsofa2 = txtPo.Text.Trim() + "/R-SOFA";
               // CallupdateMOdtl(tmpsqlRsofa2); //เปลี่ยน เพิ่มเติม
                ShowCell();
                txtPo.Text = "";
        
            }
        }

        #region " SearhUpdatePO()"
        private void SearhUpdatePO(string docno)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string tmpchar = txtPo.Text.Trim() + "/SOFA";
                string tmpsqlRsofa = txtPo.Text.Trim() + "/R-SOFA";

                string strSQL1 = "";
                strSQL1 = " select distinct(Docno)as Docno from dbo.DocOrderDtl where  DocNoCell in ('" + tmpchar + "' ,'" + tmpsqlRsofa + "')";//เปลี่ยน เพิ่มเติม
           

                if (Isfind3 == true)
                {
                    ds.Tables["updateS"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "updateS");

                if (ds.Tables["updateS"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["updateS"];
                    ShowCellT.DataSource = dt;
                    for (int i = 0; i < ds.Tables["updateS"].Rows.Count; i++)
                    {
                        string DocNo = ds.Tables["updateS"].Rows[i]["DocNo"].ToString();

                        var query = new StringBuilder();
                        query.Append("UPDATE dbo.DocMODtl SET");
                        query.Append(" DocPono  = @DocPono");
                        query.Append(" WHERE docno =  @Docno");
                        query.Append(" and Deptcode =  'W2'");
                        using (var db = new DbHelper1())
                        {
                            try
                            {

                                db.AddParameter("@DocPono", txtPo.Text.Trim());
                                db.AddParameter("@docno", DocNo);
                                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                            }
                            catch (Exception ex)
                            {
                                // MessageBox.Show("Error" + ex);
                            }

                        }

                    }
                }
                else
                {
                    Isfind3 = false;
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
        
        
        
        }


        #endregion

        #region "CallupdateMOdtl"
        private void CallupdateMOdtl(string docnoR)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select DocNo,'W2'+substring(docitem,2,3)+'%'+substring(docitem,5,11)+'%' as Docitem from dbo.DocOrderDtl  where DocNoCell='" + docnoR + "' ";

                if (Isfind2 == true)
                {
                    ds.Tables["RSofa"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "RSofa");

                if (ds.Tables["RSofa"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["RSofa"];
                    ShowCellT.DataSource = dt;
                    for (int i = 0; i < ds.Tables["RSofa"].Rows.Count; i++)
                    {
                        string DocNo = ds.Tables["RSofa"].Rows[i]["DocNo"].ToString();
                        string DocItem = ds.Tables["RSofa"].Rows[i]["DocItem"].ToString();

                        var query = new StringBuilder();
                        query.Append("UPDATE dbo.DocMODtl SET");
                        query.Append(" DocPono  = @DocPono");
                        query.Append(" WHERE docno =  @Docno");
                        query.Append(" and itemcode like  @DocItem");
                        query.Append(" and deptcode =  @deptcode");
                        using (var db = new DbHelper1())
                        {
                            try
                            {

                                db.AddParameter("@DocPono", txtPo.Text.Trim());
                                db.AddParameter("@docno", DocNo);
                                db.AddParameter("@DocItem", DocItem);
                                db.AddParameter("@deptcode", "W2");
                                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                            }
                            catch (Exception ex)
                            {
                                // MessageBox.Show("Error" + ex);
                            }

                        }

                    }
                }
                else
                {
                    Isfind2 = false;
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
             
            }
            conn.Close();
        
        
        
        }
        #endregion


        #region "UpdateDocMODtl"
        private void UpdateDocMODtl(string docno)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtl SET");
            query.Append(" DocPono  = @DocPono");
            query.Append(" WHERE docno like  @Docno");

            using (var db = new DbHelper1())
            {
                try
                {

                    db.AddParameter("@DocPono", docno);
                    db.AddParameter("@docno", docno+"%");
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
        }
        #endregion


        private void ShowCellT_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            string DocItem = Convert.ToString(gridView1.GetDataRow(index)["ScheduleID"]);
            string Docno = Convert.ToString(gridView1.GetDataRow(index)["Docno"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + Docno + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.Sewing_Schedule where ScheduleID='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการจัด ลำดับ Schedule ใหม่ นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string Sequence = Convert.ToString(gridView1.GetDataRow(i)["Sequence"]);
                    string Docno = Convert.ToString(gridView1.GetDataRow(i)["Docno"]);
                    string remark = Convert.ToString(gridView1.GetDataRow(i)["remark"]);
                    callupdate(Sequence, Docno, remark);
                }
                MessageBox.Show("Complete");
                ShowCell();
            }
        }

        #region "callupdate"
        private void callupdate(string Sequence, string Docno, string remark)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Sewing_Schedule  SET");
            query.Append(" Sequence  = @Sequence");
            query.Append(" WHERE Docno =  @Docno");
            query.Append(" and remark =  @remark");


            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@Sequence", Sequence);
                    db.AddParameter("@Docno", Docno);
                    db.AddParameter("@remark", remark);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
        
        }
        #endregion

        private void totalTargetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSewTarget page = new FrmSewTarget();
            page.ShowDialog();
        }

        private void showBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Showmonitor page = new Showmonitor();  // แสดง cell

            // MonitorLine.FrmShowMonitor page = new MonitorLine.FrmShowMonitor(); // แสดง Line Product
            page.Show();
        }

        private void barcodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSewingBarcode page = new FrmSewingBarcode();
            page.Show();
            this.Hide();
        }

    }
}
