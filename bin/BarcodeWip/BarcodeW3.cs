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

namespace PicklistBOM.BarcodeWip
{
    public partial class BarcodeW3 : Form
    {

        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public BarcodeW3()
        {
            InitializeComponent();
        }

        private void BarcodeW3_Load(object sender, EventArgs e)
        {

        }

        private void bntsearch_Click(object sender, EventArgs e)
        {
           

            ShowBarcode();
        }


        #region " ShowBarcode()"
        private void ShowBarcode()
        {

            if (this.txtsearch.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูลก่อน");
                return;
            }

            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
               
                string strSQL1 = "";
                strSQL1 = "select DocNo,DeptCode,Stockcode,itemCode,BomNo,QtyBom,QtyOut,BomNo from dbo.DocMODtl"
                + " where DeptCode ='F'  and BomNo='STD' and QtyBom <> QtyOut and DocNo ='" + this.txtsearch.Text.Trim() + "' ";

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
                MessageBox.Show("ไม่มี PO NO. หรือ อาจถูกยิง ไปแล้ว ");
            }
            conn.Close();

        }
        #endregion

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ShowBarcode();
        }

        private void gridshow_Click(object sender, EventArgs e)
        {

        }


    }
}
