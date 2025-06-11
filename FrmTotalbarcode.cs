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
namespace PicklistBOM
{
    public partial class FrmTotalbarcode : Form
    {

        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;

        public FrmTotalbarcode()
        {
            InitializeComponent();
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            string edate = this.enddate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));

          string startDate = sdate + " 00:00:00.000";
          string EndtDate = edate + " 00:00:00.000";


            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select DocNo,SUM(Qty)As Qty"
              //  + " (select   SUM(Qty) from dbo.DocMODtlBarcode where Sdate between '" + sdate + "' and '" + edate + "') as Total"
                + " from dbo.DocMODtlBarcode where convert(datetime, Sdate, 103)  between '" + startDate + "' and '" + EndtDate + "' group by DocNO ";

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

                    double sum = 0.00;
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        string num = Convert.ToString(gridView1.GetDataRow(i)["Qty"]);
                        sum = sum + Convert.ToDouble(num);
                    }
                    lbltotal.Text =sum.ToString("#,##0");
                

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

        private void FrmTotalbarcode_Load(object sender, EventArgs e)
        {

        }
    }
}
