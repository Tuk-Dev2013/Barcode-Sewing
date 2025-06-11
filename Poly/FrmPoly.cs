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
using System.Configuration;

namespace PicklistBOM.Poly
{
    public partial class FrmPoly : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmPoly()
        {
            InitializeComponent();
        }

        private void FrmPoly_Load(object sender, EventArgs e)
        {
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            this.lblme.Text = ConfigurationManager.AppSettings["WipBatch"];
            CallDetail();
            CallBatch();
        }

        #region " CallDetail();"
        private void CallDetail()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";
                //  strSQL1 = " select style,style from dbo.tb_DatSpecW1  Where model='" + this.cbomodel.SelectedValue + "'";
                strSQL1 = "  select POnumber,Cellname from dbo.A_ScheduleCell where QtyIn <> QtyOut ";

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
                    this.CboLine.DisplayMember = "POnumber";
                    this.CboLine.ValueMember = "POnumber";
                    this.CboLine.DataSource = ds.Tables["style"];

                    this.CboLine.SelectedValue = "12";

                }
                else
                {
                    Isfind2 = false;
                    this.CboLine.DataSource = null;
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

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        #region " CallBarcode();"
        private void CallBarcode(string barcode)
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.Lean_BatchPoly  where Barcode ='" + barcode + "' and  Dep='" + this.lblme.Text.Trim() + "' and  LineCell='" + CGlobal.tmpploy + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.CheckBarcode2Bin = "YES";
                   // CGlobal.CkBk2One = rs["Remark"].ToString();


                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();


        }

        #endregion

        static string MinifyA(string p)
        {
            p = p.Replace("  ", string.Empty);
            p = p.Replace(Environment.NewLine, string.Empty);
            //p = p.Replace("\\t", string.Empty);
            //p = p.Replace(" {", "{");
            //p = p.Replace(" :", ":");
            p = p.Replace("%", "(");
            p = p.Replace("-00", ")");
            p = p.Replace("+", "#");
           // p = p.Replace(";}", "}");
            return p;
        }



#region "   (CallCheckPO();"
        private void    CallCheckPO(string barcode)
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

      

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select POnumber,Cellname from dbo.A_ScheduleCell  where POnumber ='" + barcode  + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.tmpploy = "";
                  CGlobal.tmpployCheck = "YES";
                  string temp = rs["Cellname"].ToString();
                  if (temp == "CELL TRAINING")
                  {
                      CGlobal.tmpploy = "CELL";
                  }
                  else if (temp == "CELL 1")
                  {
                      CGlobal.tmpploy = "CELL1";
                  }
                  else if (temp == "CELL 2")
                  {
                      CGlobal.tmpploy = "CELL2";
                  }
                  else if (temp == "CELL 3")
                  {
                      CGlobal.tmpploy = "CELL3";
                  }
                  else if (temp == "CELL 4")
                  {
                      CGlobal.tmpploy = "CELL4";
                  }
                  else if (temp == "CELL 5")
                  {
                      CGlobal.tmpploy = "CELL5";
                  }
                  else if (temp == "CELL 6")
                  {
                      CGlobal.tmpploy = "CELL6";
                  }
                  else if (temp == "CELL 7")
                  {
                      CGlobal.tmpploy = "CELL7";
                  }
                  else if (temp == "CELL 8")
                  {
                      CGlobal.tmpploy = "CELL8";
                  }
                  else if (temp == "CELL 9")
                  {
                      CGlobal.tmpploy = "CELL9";
                  }
                  else if (temp == "CELL 10")
                  {
                      CGlobal.tmpploy = "CELL10";
                  }
                  else if (temp == "CELL 11")
                  {
                      CGlobal.tmpploy = "CELL11";
                  }
                  else if (temp == "CELL 12")
                  {
                      CGlobal.tmpploy = "CELL12";
                  }
                  else if (temp == "CELL 13")
                  {
                      CGlobal.tmpploy = "CELL13";
                  }
                  else if (temp == "CELL 14")
                  {
                      CGlobal.tmpploy = "CELL14";
                  }
                  else if (temp == "CELL 15")
                  {
                      CGlobal.tmpploy = "CELL15";
                  }
                  else if (temp == "CELL T2")
                  {
                      CGlobal.tmpploy = "CELLT2";
                  }
                  else if (temp == "CELL S1")
                  {
                      CGlobal.tmpploy = "CELLS1";
                  }
                }
                // Callgridview();
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();
        
        
        }
#endregion


  private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
    {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;

                string tempsql1 = MinifyA(this.txtbarcode.Text.Trim());
                CallCheckPO(tempsql1);


                if (this.txtbarcode.Text == "")
                {
                    MessageBox.Show("กรุณายิง Barcode ก่อนค่ะ ");
                    txtbarcode.Text = "";
                    return;
                }

                CallBarcode(this.txtbarcode.Text.Trim());

                if (CGlobal.CheckBarcode2Bin == "YES")
                {
                    MessageBox.Show("คุณยิง Barcode PO :'" +  txtbarcode.Text + "' ไปเรียบร้อยแล้วหรือมีการรับเข้า Cell แล้ว ");
                    CGlobal.CheckBarcode2Bin = "";
                    txtbarcode.Text = "";
                    return;
                }
                else 
                
                {
                    if (CGlobal.tmpployCheck == "YES")
                    {
                        var query = new StringBuilder();
                        query.Append("INSERT INTO Lean_BatchPoly(Barcode, TypeName, Dep, LineCell, Remark, DocUser, DocUserDate, DocUserRec,DocUserRecDate, Status)");
                        query.Append(" VALUES (@Barcode, @TypeName, @Dep, @LineCell, @Remark, @DocUser, @DocUserDate, @DocUserRec, @DocUserRecDate, @Status)");

                        SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                        conn1.Open();
                        using (var db = new DbHelper1())
                        {
                            try
                            {

                                string tempsql = MinifyA(this.txtbarcode.Text.Trim());
                                // DateTime sdate1 = DateTime.Now;
                                // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                                db.AddParameter("@Barcode", tempsql);
                                db.AddParameter("@TypeName", CGlobal.tmpploy);
                                db.AddParameter("@Dep", lblme.Text.Trim());
                                db.AddParameter("@LineCell", CGlobal.tmpploy);
                                db.AddParameter("@Remark", "0.00");
                                db.AddParameter("@DocUser", CGlobal.UserID);//CGlobal.UserID   23042014
                                db.AddParameter("@DocUserDate", DateTime.Now);
                                db.AddParameter("@DocUserRec", "");
                                db.AddParameter("@DocUserRecDate", DateTime.Now);
                                db.AddParameter("@Status", "Out");  // 0 : ยังไม่รับ 1: รับ
                                db.ExecuteNonQuery(query.ToString());
                            }

                            catch (Exception ex)
                            {
                                // db.RollbackTransaction();
                                MessageBox.Show("No Transfer");

                            }
                        }
                        conn1.Close();
                        CallBatch();
                        CGlobal.CheckBarcode2Bin = "";
                        CGlobal.tmpployCheck = "";
                        CGlobal.tmpploy = "";
                        txtbarcode.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("PO นี้ยังไม่ได้ถูกจองลง Cell ครับ");
                        CGlobal.tmpployCheck = "";
                        CGlobal.tmpploy = "";
                        txtbarcode.Text = "";
                        return;
                    }

                }

            }
    }

        #region "CallBatch();"
        private void CallBatch()
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT  PolyID,Barcode,Dep, LineCell, Remark, DocUser, DocUserDate, DocUserRec, DocUserRecDate, Status, (select EmpName from  dbo.DatEmp Where DatEmp.EmpCode =Lean_BatchPoly.DocUser) as Fullname FROM  Lean_BatchPoly"
                + " where Status='Out' and Dep ='" + lblme.Text.Trim() +"' order by DocUserDate desc ";

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
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
        
        
        }
        #endregion

        #region "      CallDelete temp 2bin"
        private void CallDelete(string tempID)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.Lean_BatchPoly where PolyID='" + tempID + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            CallBatch();
        }

        #endregion




        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            DataRow row = gridView2.GetDataRow(index);
            CGlobal.TempDeletePO = Convert.ToString(gridView2.GetDataRow(index)["PolyID"]);
            String Name = Convert.ToString(gridView2.GetDataRow(index)["Barcode"]);

            if ((MessageBox.Show(" คุณต้องการลบ PO : " + Name+ "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                try
                {
                  
                    // MessageBox.Show(tempID);
                    CallDelete(CGlobal.TempDeletePO);
                    CGlobal.TempDeletePO = "";
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                CallBatch();

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void bntsave_Click(object sender, EventArgs e)
        {
            if (CboLine.Text == "")
            {
                MessageBox.Show("กรุณา Key Po# (Barcode) ก่อน");
                return;
            }
            if ((MessageBox.Show(" คุณต้องการบันทึกจ่าย PO#: " + CboLine.Text + "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                CallCheckPO(CboLine.Text.Trim());

                CallBarcode(CboLine.Text);

                if (CGlobal.CheckBarcode2Bin == "YES")
                {
                    MessageBox.Show("คุณยิง Barcode PO :'" + CboLine.Text + "' ไปเรียบร้อยแล้วหรือมีการรับเข้า Cell แล้ว ");
                    CGlobal.CheckBarcode2Bin = "";
                    txtbarcode.Text = "";
                    return;
                }
                else
                {
                    if (CGlobal.tmpployCheck == "YES")
                    {
                        var query = new StringBuilder();
                        query.Append("INSERT INTO Lean_BatchPoly(Barcode, TypeName, Dep, LineCell, Remark, DocUser, DocUserDate, DocUserRec, Status)");
                        query.Append(" VALUES (@Barcode, @TypeName, @Dep, @LineCell, @Remark, @DocUser, @DocUserDate, @DocUserRec, @Status)");

                        SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                        conn1.Open();
                        using (var db = new DbHelper1())
                        {
                            try
                            {

                                //string tempsql = MinifyA(this.txtbarcode.Text.Trim());
                                // DateTime sdate1 = DateTime.Now;
                                // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                                db.AddParameter("@Barcode", CboLine.Text);
                                db.AddParameter("@TypeName", CGlobal.tmpploy);
                                db.AddParameter("@Dep", lblme.Text.Trim());
                                db.AddParameter("@LineCell", CGlobal.tmpploy);
                                db.AddParameter("@Remark", "0.00");
                                db.AddParameter("@DocUser", CGlobal.UserID);//CGlobal.UserID   23042014
                                db.AddParameter("@DocUserDate", DateTime.Now);
                                db.AddParameter("@DocUserRec", "");
                               // db.AddParameter("@DocUserRecDate", DateTime.Now);
                                db.AddParameter("@Status", "Out");  // 0 : ยังไม่รับ 1: รับ
                                db.ExecuteNonQuery(query.ToString());
                            }

                            catch (Exception ex)
                            {
                                // db.RollbackTransaction();
                                MessageBox.Show("No Transfer");

                            }
                        }
                        conn1.Close();
                        CallBatch();
                        CGlobal.CheckBarcode2Bin = "";
                        CGlobal.tmpployCheck = "";
                        CGlobal.tmpploy = "";
                        txtbarcode.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("PO นี้ยังไม่ได้ถูกจองลง Cell หรือ ยิงจบ/ผลิตจบ ไปแล้ว ");
                        CGlobal.tmpployCheck = "";
                        CGlobal.tmpploy = "";
                        txtbarcode.Text = "";
                        return;
                    }

                }


            }


        }
    }
}
