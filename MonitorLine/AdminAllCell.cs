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

namespace PicklistBOM.MonitorLine
{
    public partial class AdminAllCell : Form
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
        public AdminAllCell()
        {
            InitializeComponent();
        }

        private void AdminAllCell_Load(object sender, EventArgs e)
        {
            CallDetail();
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
                strSQL1 = " select Distinct(TypeCell) as Cell from dbo.DocMODtlBarcode where TypeCell<>'' order by Cell";

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
                    this.Cbocell.DisplayMember = "Cell";
                    this.Cbocell.ValueMember = "Cell";
                    this.Cbocell.DataSource = ds.Tables["style"];

                }
                else
                {
                    Isfind2 = false;
                    this.Cbocell.DataSource = null;
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
