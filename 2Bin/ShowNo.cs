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

    public partial class ShowNo : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public ShowNo()
        {
            InitializeComponent();
        }

        private void ShowNo_Load(object sender, EventArgs e)
        {
            ShowModel();
        }

        private void ShowModel()
        {
            this.Show1.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT     Cnumber, PONumber, BOI, Sdate, Type, Status FROM Lean_Doc2BinNuber order by Cnumber Desc";

                if (Isfind1 == true)
                {
                    ds.Tables["S1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "S1");

                if (ds.Tables["S1"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["S1"];
                    Show1.DataSource = dt;

                    //คำนวน จำนวน วัน เวลา

                    // sum();
                }
                else
                {
                    Isfind1 = false;
                    this.Show1.DataSource = null;
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

        private void Show1_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            CGlobal.BinNo = Convert.ToString(gridView1.GetDataRow(index)["Cnumber"]);
            CGlobal.BinPO = Convert.ToString(gridView1.GetDataRow(index)["PONumber"]);
            CGlobal.BinBOI = Convert.ToString(gridView1.GetDataRow(index)["BOI"]);
            CGlobal.BinDate = Convert.ToString(gridView1.GetDataRow(index)["Sdate"]);
            CGlobal.Bintype = Convert.ToString(gridView1.GetDataRow(index)["Type"]);

            this.Close();
        }

    
    }
}
