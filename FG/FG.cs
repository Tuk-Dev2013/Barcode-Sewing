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


namespace PicklistBOM.FG
{
    public partial class FG : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FG()
        {
            InitializeComponent();
        }

        private void FG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet1.DocMO' table. You can move, or remove it, as needed.
            this.docMOTableAdapter.Fill(this.dBBARCODEDataSet1.DocMO);

        }

        private void bntsearch_Click(object sender, EventArgs e)
        {
            Callsearch();
        }

        #region "CallSearch"
        private void Callsearch()
        {
            if (cboDocRefNo.Text == "")
            {
                MessageBox.Show("กรุณาเลือก PO No. ก่อน ");
                return;
            }

            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select DocNo,DeptCode,itemcode,BomNo,QtyBom,QtyOut,ItemCost from dbo.DocMODtl"
                + " where DocNo='" + cboDocRefNo.Text  + "' and DeptCode='F'";

                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    po.Text = cboDocRefNo.Text;
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
                MessageBox.Show("No Data");
            }
            conn.Close();
        
        }
        #endregion

        private void cboDocRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
            //    MessageBox.Show("0k");
                Callsearch();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("คุณต้องการทำรายการ : " + po.Text.Trim() + "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {


                    string itemcode = Convert.ToString(gridView1.GetDataRow(i)["itemcode"]);
                    string DeptCode = Convert.ToString(gridView1.GetDataRow(i)["DeptCode"]);
                    string BomNo = Convert.ToString(gridView1.GetDataRow(i)["BomNo"]);
                    string QtyBom = Convert.ToString(gridView1.GetDataRow(i)["QtyBom"]);
                    string QtyOut = Convert.ToString(gridView1.GetDataRow(i)["QtyOut"]);

                    //string
                    //if (Convert.ToDouble(QtyOut) > 0)
                    //{
                    
                    //}

                    CallUpdate(po.Text.Trim(), itemcode, DeptCode, BomNo, QtyBom, QtyOut);




                }
                MessageBox.Show("ทำรายการเรียบร้อยแล้ว");
            }
        }


        #region  "update"
        private void CallUpdate(String Po, String itemcode, String DeptCode, String BomNo, String QtyBom, String QtyOut)
        {

            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtl SET");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(" WHERE DocNo =  @DocNo");
            query.Append(" AND itemcode =  @itemcode");
            query.Append(" AND DeptCode =  @DeptCode");
            query.Append(" AND BomNo =  @BomNo");
            query.Append(" AND QtyBom =  @QtyBom");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@QtyOut", Convert.ToDouble(QtyOut).ToString("#,###0.00"));
                    db.AddParameter("@DocNo", po.Text.Trim());
                    db.AddParameter("@itemcode", itemcode);
                    db.AddParameter("@DeptCode", DeptCode);
                    db.AddParameter("@BomNo", BomNo);
                    db.AddParameter("@QtyBom", Convert.ToDouble(QtyBom).ToString("#,###0.00"));
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        }

        #endregion

    }
}
