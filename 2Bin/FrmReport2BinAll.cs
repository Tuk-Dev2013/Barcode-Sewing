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
    public partial class FrmReport2BinAll : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmReport2BinAll()
        {
            InitializeComponent();
        }

        private void FrmReport2BinAll_Load(object sender, EventArgs e)
        {
            Call2Bin();
        }



        #region "search2bin"
        private void Call2Bin()
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                string edate = this.enddate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                string startDate = sdate + " 08:00:08.310";
                string EndtDate = edate + " 23:01:08.310";

                string strSQL1 = "";
                strSQL1 = " SELECT DocID, Barcode, ItemCode, TypeName, ItemName, DocQty,ItemUnit,  DocUserDate,Status,DocUserRec"
                + " FROM   Lean_Doc2Bin where DocUserDate between '" + startDate + "' and '" + EndtDate + "'  order by DocUserDate desc ";

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

        private void bntreport_Click(object sender, EventArgs e)
        {
            Call2Bin();
        }

        private void รายงานสรปยอดจายรบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinRec page = new PicklistBOM._2Bin.FrmReport2BinRec();
            page.Show();
            this.Hide();
        }

        private void รายงานใบเบก2BinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinAll page = new PicklistBOM._2Bin.FrmReport2BinAll();
            page.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
              try
            {
            Call2Bin();
            }
              catch (Exception ex)
              {
                  return;
              }
        }

        private void bINCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }
    }
}
