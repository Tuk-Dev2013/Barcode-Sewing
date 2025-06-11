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

namespace PicklistBOM.DeletePOCell
{
    public partial class frmEditPO1 : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public frmEditPO1()
        {
            InitializeComponent();
        }

        private void frmEditPO1_Load(object sender, EventArgs e)
        {
            CallPO();
        }

        #region " Callpo();"
        private void CallPO()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";

                strSQL1 = " select POnumber,Cellname  from dbo.A_ScheduleCell order by Startday desc";

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
                    this.cbopo.DisplayMember = "POnumber";
                    this.cbopo.ValueMember = "Cellname";
                    this.cbopo.DataSource = ds.Tables["style"];

                }
                else
                {
                    Isfind = false;
                    this.cbopo.DataSource = null;
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

        private void bntsearch_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select QtyBom,QtyOut,QtyBal,ItemCode   from dbo.DocMODtl "
            + " where DocNo ='" + this.cbopo.Text.Trim() + "' and Barcode ='" + bntbarcode.Text.Trim() + "' and DeptCode ='W8'", conn); 
                
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtqty.Text = rs["QtyBom"].ToString();
                    txtout.Text = rs["QtyOut"].ToString();
                    txtbal.Text = rs["QtyBal"].ToString();
                    lblfg.Text = rs["ItemCode"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }



        private void cbopo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";

                strSQL1 = "  select Barcode,ItemCode from dbo.DocMODtl where DocNo='" + this.cbopo.Text.Trim() + "'  and Barcode <>'' and DeptCode ='W8'";

                if (Isfind2 == true)
                {
                    ds.Tables["barcode1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "barcode1");
                //*** DropDownList ***// 
                if (ds.Tables["barcode1"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    this.bntbarcode.DisplayMember = "Barcode";
                    this.bntbarcode.ValueMember = "ItemCode";
                    this.bntbarcode.DataSource = ds.Tables["barcode1"];

                }
                else
                {
                    Isfind2 = false;
                    this.bntbarcode.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;
            }
            catch (Exception ex)
            {


            }
        }

        private void bntupdate_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("คุณต้องลด จำนวน PO# "+ cbopo.Text + " Itemcode : " + lblfg.Text + "  จำนวน ." + txtedit.Text + " นี่ใช่หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                if ((txtout.Text.Trim() == txtqty.Text.Trim()) && (txtbal.Text.Trim() == "0.00"))
                {
                    var query = new StringBuilder();
                    query.Append("UPDATE dbo.DocMODtl  SET");
                    query.Append(" QtyOut  = @QtyOut");
                    query.Append(", QtyBal  = @QtyBal");
                    query.Append(" WHERE DocNo =  @DocNo");
                    query.Append(" and ItemCode =  @ItemCode");
                    query.Append(" and Barcode =  @Barcode");
                    query.Append(" and DeptCode ='W8'");

                    using (var db = new DbHelper1())
                    {
                        try
                        {
                            double nout = Convert.ToDouble(txtqty.Text.Trim()) - Convert.ToDouble(txtedit.Text.Trim());
                            double nbal = -Convert.ToDouble(txtedit.Text.Trim());
                            db.AddParameter("@QtyOut", nout);
                            db.AddParameter("@QtyBal", nbal);
                            db.AddParameter("@DocNo", cbopo.Text.Trim());
                            db.AddParameter("@ItemCode", lblfg.Text.Trim());
                            db.AddParameter("@Barcode", bntbarcode.Text.Trim());
                            db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                            show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("ไม่สามารถแก้ไขได้ คุณยิง barcode ยังไม่จบ ");
                
                }
            

            }
        }

        #region "show"
        private void show()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select QtyBom,QtyOut,QtyBal,ItemCode   from dbo.DocMODtl "
            + " where DocNo ='" + this.cbopo.Text.Trim() + "' and Barcode ='" + bntbarcode.Text.Trim() + "' and DeptCode ='W8'", conn);

                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtqty.Text = rs["QtyBom"].ToString();
                    txtout.Text = rs["QtyOut"].ToString();
                    txtbal.Text = rs["QtyBal"].ToString();
                    lblfg.Text = rs["ItemCode"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion

    }
}
