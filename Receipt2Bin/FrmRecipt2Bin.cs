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
namespace PicklistBOM.Receipt2Bin
{
    public partial class FrmRecipt2Bin : Form
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
        public FrmRecipt2Bin()
        {
            InitializeComponent();
        }

        private void FrmRecipt2Bin_Load(object sender, EventArgs e)
        {
            this.lblme.Text = ConfigurationManager.AppSettings["Wip"];
           // DateTime sdate1 = DateTime.Now;
          //  this.lbltime.Text = " Time : " + sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            //ToolStripStatusLabelConnect.Text = CGlobal.BandName;
          //  Call2Bin();
            txtbarcode.Focus();
            Lean_Doc2Bin();
        }



        #region "Lean_Doc2Bin"
        private void Lean_Doc2Bin()
        {
            this.gridshow.DataSource = null;

        
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

                string strSQL1 = "";
                strSQL1 = " SELECT DocID, Barcode, ItemCode, TypeName, ItemName, DocQty,ItemUnit,  DocUserDate,'Receipt' as Status"
                + " FROM   Lean_Doc2Bin where Status='Out' and TypeName='" + this.lblme.Text.Trim()+ "' order by DocUserDate desc ";

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
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
    
        }
        #endregion



        #region "ยิงbarcode"
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtbarcode.Text == "")
                {
                    MessageBox.Show("กรุณายิง Barcode ก่อนค่ะ ");
                    return;
                }

                CallBarcode();
               //   CallSumBarcode();

                if (CGlobal.CheckBarcode2Bin == "YES")
                {

                    var query = new StringBuilder();
                    query.Append("UPDATE dbo.Lean_Doc2Bin SET");
                    query.Append(" DocUserRec  = @DocUserRec,");
                    query.Append(" DocUserRecDate = @DocUserRecDate,");
                    query.Append(" Status = @Status");
                    query.Append(" WHERE TypeName = @TypeName");
                   // query.Append("  and TypeName = @TypeName");
                    query.Append("  and Status ='Out'");
                    query.Append("  and Remark =@Remark");



                    using (var db = new DbHelper1())
                    {
                        try
                        {

                            db.AddParameter("@DocUserRec", CGlobal.UserID);
                            db.AddParameter("@DocUserRecDate", DateTime.Now);
                            db.AddParameter("@Status", "Success");
                           // db.AddParameter("@Barcode", this.txtbarcode.Text.Trim());
                            db.AddParameter("@TypeName", this.lblme.Text.Trim());
                            db.AddParameter("@Remark", CGlobal.CkBk2One);
                            db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }
                    }



                    Lean_Doc2Bin();
                    CGlobal.CheckBarcode = "";
                    txtbarcode.Text = "";
                    CGlobal.CkBk2One = "";
                }
                else
                {
                   // MessageBox.Show("No Barcode");
                    CGlobal.CheckBarcode = "";
                    txtbarcode.Text = "";
                    return;
                   // this.gridshow.DataSource = null;
                }



            }
        }
        #endregion

        #region " CallBarcode();"
        private void CallBarcode()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.Lean_Doc2Bin  where Barcode ='" + this.txtbarcode.Text.Trim() + "' and  TypeName='" + this.lblme.Text.Trim() + "' and Status ='Out'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.CheckBarcode2Bin = "YES";
                    CGlobal.CkBk2One = rs["Remark"].ToString();

           
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

        private void button1_Click(object sender, EventArgs e)
        {

            if ((MessageBox.Show("คุณต้องรับ 2Bin ทั้งหมด " + this.txtbarcode.Text + "  นี่ใช่หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("UPDATE dbo.Lean_Doc2Bin SET");
                query.Append(" DocUserRec  = @DocUserRec,");
                query.Append(" DocUserRecDate = @DocUserRecDate,");
                query.Append(" Status = @Status");
                query.Append(" WHERE Barcode =  @Barcode");
                query.Append("  and TypeName = @TypeName");
                query.Append("  and Status ='Out'");


                using (var db = new DbHelper1())
                {
                    try
                    {
 
                        db.AddParameter("@DocUserRec", CGlobal.UserID);
                        db.AddParameter("@DocUserRecDate", DateTime.Now);
                        db.AddParameter("@Status", "Success");
                        db.AddParameter("@Barcode", this.txtbarcode.Text.Trim());
                        db.AddParameter("@TypeName", this.txtbarcode.Text.Trim());
                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                        return;
                    }

                    MessageBox.Show("Receipt Complete");
               
                    Lean_Doc2Bin();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           try
            {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Lean_Doc2Bin();
            }
           catch (Exception ex)
             {
              return;
             }
            

          
        }

    }
}
