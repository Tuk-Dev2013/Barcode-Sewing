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
    public partial class FrmInterfaceFG : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        public FrmInterfaceFG()
        {
            InitializeComponent();
        }

        private void FrmInterfaceFG_Load(object sender, EventArgs e)
        {

        }

        #region "Search"
        private void SearchPO()
        {
            if (this.txtPO.Text == "")
            {
                MessageBox.Show("กรุณา Key PO ก่อน");
                this.gridshow.DataSource = null;
                this.txtPO.Focus();
                return;
            }
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select DocNo,DocItem,itemname,DocQty ,BomNo,'W8'+substring(DocItem,2,15) As FG,DocStock,"
                + " (select QtyBom From DocMODtl Where ItemCode='W8'+substring(DocItem,2,15) and DocMODtl.DocNo= dbo.DocOrderDtl.DocNo)As QtyBom,"
                + " (select QtyOut From DocMODtl Where ItemCode='W8'+substring(DocItem,2,15) and DocMODtl.DocNo= dbo.DocOrderDtl.DocNo)as QtyOut,"
                + " (select QtyBal From DocMODtl Where ItemCode='W8'+substring(DocItem,2,15) and DocMODtl.DocNo= dbo.DocOrderDtl.DocNo)as QtyBal"
                + " from dbo.DocOrderDtl where DocOrderDtl.DocNoCell like '" + this.txtPO.Text.Trim() + "%'"
                + " order by  dbo.DocOrderDtl.DocNo";

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
                    MessageBox.Show("No Data");
                    this.txtPO.Focus();
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

        #region "CheckDocMODtl()"
        private void CheckDocMODtl()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {
                this.lblcheck.Text = "No Power-WIP"; 
                Cmd = new System.Data.SqlClient.SqlCommand(" Select Docno from dbo.DocMODtl "
              + " where docno ='" + this.txtPO.Text.Trim() + "' and deptcode='F' ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string tmpstr = rs["Docno"].ToString();
                    if (tmpstr == "")
                    { this.lblcheck.Text = "No Power-WIP"; }
                    else
                    { 
                    this.lblcheck.Text="Yes Power-WIP";
                    }

                }


                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion

        private void bntsearch_Click(object sender, EventArgs e)
        {
            SearchPO();
            CheckDocMODtl();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void txtPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
             
                SearchPO();
                CheckDocMODtl();
            }
        }

        #region "CallDocMO"
        private void CallDocMO(string docno)
        {

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " INSERT INTO dbo.DocMO(DocNo, DocBrn, DocRefNo, DocDate, DocDue, DocStart, DocFinish, DocType, DocUser, DocProj, DocNote, DocStatus, ReviseNo, Line_No, DocPONo)"
                               + "  SELECT  '" + this.txtPO.Text.Trim() + "', DocBrn, DocRefNo, DocDate, DocDue, DocStart, DocFinish, DocType, DocUser, DocProj, DocNote, DocStatus, ReviseNo, Line_No, '" + this.txtPO.Text.Trim() +"'"
                              + " FROM dbo.DocMO Where  docno ='" + docno + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
        
        }
        #endregion

        private void bnttranfer_Click(object sender, EventArgs e)
        {
            if (this.gridshow.DataSource == null)
            {
                MessageBox.Show("No Data");
                this.txtPO.Focus();
                return;
            }
            else
            {
                if (this.txtPO.Text == "")
                {
                    MessageBox.Show("กรุณา Key PO ก่อน");
                    this.gridshow.DataSource = null;
                    this.txtPO.Focus();
                    return;
                }
                //tranfer data
                if (this.lblcheck.Text.Trim() == "No Power-WIP")
                {
                    //Insert DocMODtl
                    double sum = 1.00;
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        string DocNo = Convert.ToString(gridView1.GetDataRow(i)["DocNo"]);
                        if (i == 0)
                        {
                            CallDocMO(DocNo);
                        }
                        string DocItem = Convert.ToString(gridView1.GetDataRow(i)["DocItem"]);
                        string BomNo = Convert.ToString(gridView1.GetDataRow(i)["BomNo"]);
                        string DocStock = Convert.ToString(gridView1.GetDataRow(i)["DocStock"]);
                        string QtyBom = Convert.ToString(gridView1.GetDataRow(i)["QtyBom"]);
                        string QtyOut = Convert.ToString(gridView1.GetDataRow(i)["QtyOut"]);
                        string QtyBal = Convert.ToString(gridView1.GetDataRow(i)["QtyBal"]);
                        sum = sum + i;

                        var query = new StringBuilder();
                        query.Append("INSERT INTO dbo.DocMODtl(DocNo, BrnCode, RefNo, DeptCode, StockCode, ItemCode, BomNo, QtyBom, QtyOut, QtyBal, QtyUse, QtyWip, ItemType, ItemFlag, ItemCost, CheckFlag, Barcode, BarFlag, BarQty, DocPONo)");
                        query.Append(" VALUES (@DocNo, @BrnCode, @RefNo, @DeptCode, @StockCode, @ItemCode, @BomNo, @QtyBom, @QtyOut, @QtyBal, @QtyUse, @QtyWip, @ItemType, @ItemFlag, @ItemCost, @CheckFlag, @Barcode, @BarFlag, @BarQty, @DocPONo)");

                        SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                        conn1.Open();
                        using (var db = new DbHelper1())
                        {
                            try
                            {
                                db.AddParameter("@DocNo", this.txtPO.Text.Trim());
                                db.AddParameter("@BrnCode", "HOF");
                                db.AddParameter("@RefNo", DocNo);
                                db.AddParameter("@DeptCode", "F");
                                db.AddParameter("@StockCode", DocStock);
                                db.AddParameter("@ItemCode", DocItem.Trim());
                                db.AddParameter("@BomNo", BomNo.Trim());
                                db.AddParameter("@QtyBom", Convert.ToDouble(QtyBom));
                                db.AddParameter("@QtyOut", Convert.ToDouble(QtyOut));
                                db.AddParameter("@QtyBal", Convert.ToDouble(QtyBal));
                                db.AddParameter("@QtyUse", 0.00);
                                db.AddParameter("@QtyWip", 0.00);
                                db.AddParameter("@ItemType", "0");
                                db.AddParameter("@ItemFlag", "0");
                                db.AddParameter("@ItemCost", "0.00");
                                db.AddParameter("@CheckFlag", "0");
                                db.AddParameter("@Barcode", "");
                                db.AddParameter("@BarFlag", "");
                                db.AddParameter("@BarQty", 0);
                                db.AddParameter("@DocPONo", this.txtPO.Text.Trim()); 
                                db.ExecuteNonQuery(query.ToString());
                            }

                            catch (Exception ex)
                            {
                                // db.RollbackTransaction();
                                MessageBox.Show("No Transfer");
                            }
                        }
                        conn1.Close();
                    }

                    MessageBox.Show("Transfer Complete");
                    this.lblcheck.Text = "Yes Power-WIP";
                }
                else if (lblcheck.Text.Trim() == "Yes Power-WIP")
                {
                    //Update DocMODtl 
                    CallUPdate();
                
                }
            
            }
        }

        #region "CallUPdate();"
        private void CallUPdate()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                string DocNo = Convert.ToString(gridView1.GetDataRow(i)["DocNo"]);
                string DocItem = Convert.ToString(gridView1.GetDataRow(i)["DocItem"]);
                string BomNo = Convert.ToString(gridView1.GetDataRow(i)["BomNo"]);
                string DocStock = Convert.ToString(gridView1.GetDataRow(i)["DocStock"]);
                string QtyBom = Convert.ToString(gridView1.GetDataRow(i)["QtyBom"]);
                string QtyOut = Convert.ToString(gridView1.GetDataRow(i)["QtyOut"]);
                string QtyBal = Convert.ToString(gridView1.GetDataRow(i)["QtyBal"]);

                if (Convert.ToDouble(QtyBom) >= Convert.ToDouble(QtyOut))
                {
                    var query = new StringBuilder();
                    query.Append("UPDATE dbo.DocMODtl SET");
                    query.Append(" QtyOut  = @QtyOut");
                    query.Append(" WHERE DocNo =  @DocNo");
                    query.Append(" AND ItemCode =  @DocItem");
                    query.Append(" AND QtyBom =  @QtyBom");
                    query.Append(" AND BomNo =  @BomNo");
                    query.Append(" AND DocPOno =  @DocPOno");


                    using (var db = new DbHelper1())
                    {
                        try
                        {
                            db.AddParameter("@QtyOut", QtyOut);
                            db.AddParameter("@DocNo", this.txtPO.Text.Trim());
                            db.AddParameter("@DocItem", DocItem);
                            db.AddParameter("@BomNo", BomNo);
                            db.AddParameter("@QtyBom", QtyBom);
                            db.AddParameter("@DocPOno", this.txtPO.Text.Trim());
                            db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error DocMODtl" + ex);
                            return;
                        }
                    }
        
                }
                else
                {
                    MessageBox.Show("No Data Update : " + DocItem); 
                }


            }


            MessageBox.Show("Update Complete");
        }
        #endregion

    }
}
