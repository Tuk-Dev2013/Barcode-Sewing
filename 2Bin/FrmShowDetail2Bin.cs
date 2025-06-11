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

namespace PicklistBOM._2Bin
{
    public partial class FrmShowDetail2Bin : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmShowDetail2Bin()
        {
            InitializeComponent();
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
        private void FrmShowDetail2Bin_Load(object sender, EventArgs e)
        {
            this.lblissue.Text = CGlobal.Issuecell;
            CallGridViewPODetail();
        }

        #region "  CallGridViewPODetail();"
        private void CallGridViewPODetail()
        {
            this.gridshow.DataSource = null;
            var conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string y = Left(CGlobal.Issuecelldate, 4);
                string d = Right(CGlobal.Issuecelldate, 2);
                string M= Mid(CGlobal.Issuecelldate, 5,2);
                string tmpsql = M + "-" + d + "-" + y;


                string strSQL1 = "";
                strSQL1 = " select ItemCode ,ItemName ,DocQty ,ItemUnit  from dbo.Lean_Doc2Bin " +
                          " where CONVERT(VARCHAR(10),DocUserDate,110) = '" + tmpsql + "' " +
                          " and TypeName = '" + CGlobal.Issuecell + "' order by  ItemCode ";

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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
            conn.Dispose();
            // sumleft();


        }


        #endregion

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

    }
}
