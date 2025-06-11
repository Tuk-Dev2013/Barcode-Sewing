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

    public partial class Frm2BIN : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        int _selectedIndex;
        string _text;

        public Frm2BIN()
        {
            InitializeComponent();
        }

        private void splitLotPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPOSearch1 page = new txtPOSearch1();
            page.Show();
            this.Hide();
        }

        private void reportPicklistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            page.Show();
            this.Hide();
        }

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bacthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmBatch page = new PicklistBOM._2Bin.FrmBatch();
            page.Show();
            this.Hide();
        }

        private void Frm2BIN_Load(object sender, EventArgs e)
        {
            DateTime sdate1 = DateTime.Now;
            this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
           // Call2Bin();
            //*** Insert Item ***//

            GenAotokey();
            this.CboLine.Focus();

        }

        #region "AutoKey"
        private void GenAotokey()
        {
            int iJobid = 0;
            string tmpOrder;
            int OrderID = 0;
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string y = Right(resultdate, 4);
            string d = Left(resultdate, 2);
            string M = Mid(resultdate, 3, 2);
            string dmy = y + M +d;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = " Select Max(BinNumber)  from Lean_Doc2Bin";
                tmpOrder = (String)sqlCmd.ExecuteScalar();

                OrderID = Convert.ToInt32(Right(tmpOrder, 4));
                OrderID = OrderID + 1;

                txtNo.Text = dmy + OrderID.ToString("0000");
                //strnewid = strnewid.PadLeft(4, '0');    
            }

            catch (Exception ex)
            {
                txtNo.Text = dmy + OrderID.ToString("0001");
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

        #region "search2bin"
        private void Call2Bin()
         {
             this.gridshow.DataSource = null;

             SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
             conn.Open();
             try
             {

                 string strSQL1 = "";
                 strSQL1 = " select ItemCode,ItemName,Amount,ItemUnit"
                 + " from Lean_Temp2Bin order by ItemCode";

                 if (Isfind == true)
                 {
                     ds.Tables["Showdata"].Clear();
                 }

                 da = new SqlDataAdapter(strSQL1, conn);
                 da.Fill(ds, "Showdata");

                 if (ds.Tables[0].Rows.Count != 0)
                 {
                     Isfind = true;
                     dt = ds.Tables["Showdata"];
                     gridshow.DataSource = dt;
                 }
                 else
                 {
                     Isfind = false;
                     this.gridshow.DataSource = null;
                     MessageBox.Show("No Data");
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

        #region "printbarcode"
        private void bntPrint2bin_Click(object sender, EventArgs e)
         {
             PicklistBOM._2Bin.Report2BinAll page = new PicklistBOM._2Bin.Report2BinAll();
             page.Show();
         }

         private void bnt2bin_Click(object sender, EventArgs e)
         {
             PicklistBOM._2Bin.ReportBarcode page = new PicklistBOM._2Bin.ReportBarcode();
             page.Show();
         }
        #endregion

         #region "      CallDelete();"
         private void CallDelete()
         {
             SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
             conn.Open();
             try
             {
                 string cmdQuery1 = " Delete  from dbo.Lean_Temp2Bin ";
                 SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                 cmd.ExecuteNonQuery();
             }
             catch (Exception ex)
             {

             }
         }

         #endregion


         #region save temp2bin 
         private void bntSearch_Click(object sender, EventArgs e)
         {

             CallDelete();
             SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
             conn.Open();
             try
             {

                 string strSQL1 = "";
                 strSQL1 = " select ItemCode,ItemName,100 as Amount,ItemNote,ItemUnit"
                 + " from dbo.DatItem where  ItemNote = '2Bin' ";

                 if (Isfind1 == true)
                 {
                     ds.Tables["Showdata1"].Clear();
                 }

                 da = new SqlDataAdapter(strSQL1, conn);
                 da.Fill(ds, "Showdata1");

                 if (ds.Tables[0].Rows.Count != 0)
                 {
                     Isfind1 = true;

                     for (int i = 0; i < ds.Tables["Showdata1"].Rows.Count; i++)
                     {
                         string ItemCode = ds.Tables["Showdata1"].Rows[i]["ItemCode"].ToString();
                         string ItemName = ds.Tables["Showdata1"].Rows[i]["ItemName"].ToString();
                         string Amount = ds.Tables["Showdata1"].Rows[i]["ItemNote"].ToString();
                         string ItemUnit = ds.Tables["Showdata1"].Rows[i]["ItemUnit"].ToString();
                        //insert

                         var query = new StringBuilder();
                         query.Append("INSERT INTO Lean_Temp2Bin(ItemCode, ItemName, Amount, ItemUnit, Status)");
                         query.Append(" VALUES (@ItemCode, @ItemName, @Amount, @ItemUnit, @Status)");

                         SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                         conn1.Open();
                         using (var db = new DbHelper1())
                         {
                             try
                             {
                                 db.AddParameter("@ItemCode", ItemCode);
                                 db.AddParameter("@ItemName", ItemName);
                                 db.AddParameter("@Amount", "100");
                                 db.AddParameter("@ItemUnit", ItemUnit);
                                 db.AddParameter("@Status", "0");
                                 db.ExecuteNonQuery(query.ToString());
                             }

                             catch (Exception ex)
                             {
                                 // db.RollbackTransaction();
                                 MessageBox.Show("No Transfer");

                             }
                         }
                         conn1.Close();

                     }



                 }
                 else
                 {
                     Isfind1 = false;
                     this.gridshow.DataSource = null;
                     MessageBox.Show("No Data");
                 }
                 //  dataGridView1.DataBindings();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("No Data");
             }
             conn.Close();
             Call2Bin();
             bntPrint2bin.Enabled = true;
         }
#endregion

         #region "double click gridshw"
         private void gridshow_DoubleClick(object sender, EventArgs e)
         {
             try
             {
                 int index = gridView1.FocusedRowHandle;
                 DataRow row = gridView1.GetDataRow(index);
                 String tempID = Convert.ToString(gridView1.GetDataRow(index)["ItemCode"]);
                 // MessageBox.Show(tempID);
                 CallDelete(tempID);
             }
             catch (Exception ex)
             {
             }
         }
#endregion
         #region "      CallDelete temp 2bin"
         private void CallDelete(string tempID)
         {
             SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
             conn.Open();
             try
             {
                 string cmdQuery1 = " Delete  from dbo.Lean_Temp2Bin where ItemCode='" + tempID +"'";
                 SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                 cmd.ExecuteNonQuery();
             }
             catch (Exception ex)
             {

             }
             conn.Close();
             Call2Bin();
         }

         #endregion


         private void button1_Click(object sender, EventArgs e)
         {
             if (gridshow.DataSource == null)
            {
                MessageBox.Show("No Data");
                return;
            }

             if (this.CboLine.SelectedItem == null)
             {
                 MessageBox.Show("Select Line Cell");
                 return;
             }

               if ((MessageBox.Show("คุณต้องการเบิก 2 Bin ไป line Cell นี่ใช่หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
               {
                   SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                   conn.Open();
                   try
                   {

                       string strSQL1 = "";
                       strSQL1 = " select ItemCode,ItemName, Amount,ItemUnit"
                       + " from dbo.Lean_Temp2Bin Order by ItemCode";

                       if (Isfind2 == true)
                       {
                           ds.Tables["Showdata2"].Clear();
                       }

                       da = new SqlDataAdapter(strSQL1, conn);
                       da.Fill(ds, "Showdata2");

                       if (ds.Tables[0].Rows.Count != 0)
                       {
                           Isfind2 = true;

                           for (int i = 0; i < ds.Tables["Showdata2"].Rows.Count; i++)
                           {
                               string ItemCode = ds.Tables["Showdata2"].Rows[i]["ItemCode"].ToString();
                               string ItemName = ds.Tables["Showdata2"].Rows[i]["ItemName"].ToString();
                               string Amount = ds.Tables["Showdata2"].Rows[i]["Amount"].ToString();
                               string ItemUnit = ds.Tables["Showdata2"].Rows[i]["ItemUnit"].ToString();
                               //insert

                               var query = new StringBuilder();
                               query.Append("INSERT INTO Lean_Doc2Bin(BinNumber, ItemCode, ItemName, DocQty, DocCost, ItemUnit, Remark, LineCell, DocUser, DocUserDate, DocUserRec, DocUserRecDate, Status)");
                               query.Append(" VALUES (@BinNumber, @ItemCode, @ItemName, @DocQty, @DocCost, @ItemUnit, @Remark, @LineCell, @DocUser, @DocUserDate, @DocUserRec, @DocUserRecDate, @Status)");

                               SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                               conn1.Open();
                               using (var db = new DbHelper1())
                               {
                                   try
                                   {
                                                  // DateTime sdate1 = DateTime.Now;
                                 // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                                       db.AddParameter("@BinNumber", this.txtNo.Text.Trim());
                                       db.AddParameter("@ItemCode", ItemCode);
                                       db.AddParameter("@ItemName", ItemName);
                                       db.AddParameter("@DocQty", Amount);
                                       db.AddParameter("@DocCost", "0.00");
                                       db.AddParameter("@ItemUnit", ItemUnit);
                                       db.AddParameter("@Remark", txtremark.Text.Trim());
                                       db.AddParameter("@LineCell", this.CboLine.SelectedItem);
                                       db.AddParameter("@DocUser", CGlobal.UserID);
                                       db.AddParameter("@DocUserDate", DateTime.Now);
                                       db.AddParameter("@DocUserRec", "");
                                       db.AddParameter("@DocUserRecDate", DateTime.Now);
                                       db.AddParameter("@Status", "NO");  // 0 : ยังไม่รับ 1: รับ
                                       db.ExecuteNonQuery(query.ToString());
                                   }

                                   catch (Exception ex)
                                   {
                                       // db.RollbackTransaction();
                                       MessageBox.Show("No Transfer");

                                   }
                               }
                               conn1.Close();

                           }

                           MessageBox.Show("Data Complete");
                           CallDelete();
                           Call2Bin();
                           GenAotokey();
                       }
                       else
                       {
                           Isfind2 = false;
                           this.gridshow.DataSource = null;
                           MessageBox.Show("No Data");
                       }
                       //  dataGridView1.DataBindings();
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("No Data");
                   }
                   conn.Close();

               }
         }

         private void bntall_Click(object sender, EventArgs e)
         {
             PicklistBOM._2Bin.FrmReport2BinAll page = new PicklistBOM._2Bin.FrmReport2BinAll();
             page.Show();
         }

         private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
         {

         }


    }
}
