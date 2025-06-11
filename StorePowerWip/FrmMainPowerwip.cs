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

namespace PicklistBOM.StorePowerWip
{
    public partial class FrmMainPowerwip : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmMainPowerwip()
        {
            InitializeComponent();
        }

        private void FrmMainPowerwip_Load(object sender, EventArgs e)
        {
            ToolStripStatusForm.Text = "Power-Wip";
            ToolStripStatusVersionName.Text = "V 1.0";
            ToolStripStatusUserName.Text = CGlobal.Username;

            CallMonth();
            CallYear();
            //DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.cboyear.Text = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
            this.cbomonth.Text = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("en-US"));

        }

        #region " CallMonth;"
        private void CallMonth()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string strSQL1 = "";
                strSQL1 = " SELECT   Month, MonthName FROM   DocIssueMonth";
                if (Isfind == true)
                {
                    ds.Tables["style"].Clear();
                }
                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                //*** DropDownList ***// 
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

        #region " CallYear;"
        private void CallYear()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string strSQL1 = "";
                strSQL1 = "  select Distinct(Year(Docdate))as tmpyear from dbo.DocIssue order by Year(Docdate)";
                if (Isfind1 == true)
                {
                    ds.Tables["styleYear"].Clear();
                }
                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "styleYear");
                //*** DropDownList ***// 
                if (ds.Tables["styleYear"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    this.cboyear.DisplayMember = "tmpyear";
                    this.cboyear.ValueMember = "tmpyear";
                    this.cboyear.DataSource = ds.Tables["styleYear"];
                }
                else
                {
                    Isfind1 = false;
                    this.cboyear.DataSource = null;
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

    }
}
