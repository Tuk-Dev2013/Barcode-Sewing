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
    public partial class FrmPolyCell : Form
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

        public FrmPolyCell()
        {
            InitializeComponent();
        }

        private void FrmPolyCell_Load(object sender, EventArgs e)
        {
            this.lblme.Text = ConfigurationManager.AppSettings["Wip"];
            // DateTime sdate1 = DateTime.Now;
            //  this.lbltime.Text = " Time : " + sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            //ToolStripStatusLabelConnect.Text = CGlobal.BandName;
            CallBatch();
            txtbarcode.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                this.lbltime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                CallBatch();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #region " CallBarcode();"
        private void CallBarcode()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.Lean_BatchPoly  where Barcode ='" + this.txtbarcode.Text.Trim() + "'and  LineCell='" + this.lblme.Text.Trim() + "' and Status ='Out'", conn);
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
                    query.Append("UPDATE dbo.Lean_BatchPoly SET");
                    query.Append(" DocUserRec  = @DocUserRec,");
                    query.Append(" DocUserRecDate = @DocUserRecDate,");
                    query.Append(" Status = @Status");
                    query.Append(" WHERE Barcode = @Barcode");
                    query.Append("  and LineCell = @LineCell");
                    query.Append("  and Status ='Out'");



                    using (var db = new DbHelper1())
                    {
                        try
                        {

                            db.AddParameter("@DocUserRec", CGlobal.UserID);
                            db.AddParameter("@DocUserRecDate", DateTime.Now);
                            db.AddParameter("@Status", "Success");
                            db.AddParameter("@Barcode", this.txtbarcode.Text.Trim());
                            db.AddParameter("@LineCell", this.lblme.Text.Trim());
                            db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }
                    }



                    CallBatch();
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
        #region "CallBatch();"
        private void CallBatch()
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT  PolyID,Barcode,Dep, LineCell, Remark, DocUser, DocUserDate, DocUserRec, DocUserRecDate, Status FROM  Lean_BatchPoly"
                + " where Status='Out' and LineCell ='" + lblme.Text.Trim() + "' order by DocUserDate desc ";

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

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

    }
}
