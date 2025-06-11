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

namespace PicklistBOM.JinnyBOM
{
    public partial class FrmJinnyCode : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmJinnyCode()
        {
            InitializeComponent();
        }

        private void bntsearch_Click(object sender, EventArgs e)
        {
            if (this.txtcode.Text == "")
            {
                MessageBox.Show("Please input...");
                return;
            }
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select distinct(SUBSTRING(bomGrp,3,6))as model,(select itemname from DatItem Where ItemCode='" + this.txtcode.Text.Trim() + "') as itemname,BomItem,BomNo  from dbo.DocMoBom where BomItem ='" + this.txtcode.Text.Trim() + "' and BomNo in('CELL','STD','CELL-GB','GB') group by SUBSTRING(bomGrp,3,6),BomItem,BomNo";

                if (Isfind == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata2"];
                    gridshow.DataSource = dt;
                   // txtcode.Text = "";
                }
                else
                {
                    MessageBox.Show("No ItemCode");
                    txtcode.Text = "";
                    Isfind = false;
                    this.gridshow.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data1");
            }
            conn.Close();


        }

        private void FrmJinnyCode_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void bntreport_Click(object sender, EventArgs e)
        {
            CGlobal.BinBOI = this.txtcode.Text.Trim();
            JinnyBOM.Frmjinnyreport page = new JinnyBOM.Frmjinnyreport();  // ยิงรับ barcode จ่าย Poly Batch
            page.Show();
        }
    }
}
