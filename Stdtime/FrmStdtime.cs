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

namespace PicklistBOM.Stdtime
{
    public partial class FrmStdtime : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmStdtime()
        {
            InitializeComponent();
        }

        private void FrmStdtime_Load(object sender, EventArgs e)
        {
            CallDetail();
            Callstdtime(CboLine.Text);
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

                strSQL1 = " select distinct(Style) as style1 from dbo.Stdtime order by Style ";

                if (Isfind1 == true)
                {
                    ds.Tables["styledetail"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "styledetail");
                //*** DropDownList ***// 
                if (ds.Tables["styledetail"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    this.CboLine.DisplayMember = "style1";
                    this.CboLine.ValueMember = "style1";
                    this.CboLine.DataSource = ds.Tables["styledetail"];

                }
                else
                {
                    Isfind1 = false;
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


        #region " Callstdtime()"
        private void Callstdtime(string tmpmodel)
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select 'Edit' as Edit,* from dbo.Stdtime  Where Style ='" + tmpmodel +"' order by Style  ";

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
                }
                else
                {
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
        #endregion

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void bntsearch_Click(object sender, EventArgs e)
        {
            Callstdtime(CboLine.Text);
        }

        private void CboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Callstdtime(CboLine.Text);
        }

        private void bntNew_Click(object sender, EventArgs e)
        {
            Stdtime.FrmstdAdd page = new Stdtime.FrmstdAdd(); 
            page.ShowDialog();

            this.CboLine.Text = CGlobal.Issuemodel;
            Callstdtime(CboLine.Text);
        }

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            CGlobal.IssueNo2 = Convert.ToString(gridView1.GetDataRow(index)["StdID"]);
            CGlobal.Issuemodel = Convert.ToString(gridView1.GetDataRow(index)["Style"]);

            Stdtime.FrmEditStdTime page = new Stdtime.FrmEditStdTime();
            page.ShowDialog();

            this.CboLine.Text = CGlobal.Issuemodel;
            Callstdtime(CboLine.Text);
        }

        private void bntot_Click(object sender, EventArgs e)
        {
            Stdtime.FrmOT page = new Stdtime.FrmOT();
            page.ShowDialog();
        }
    }
}
