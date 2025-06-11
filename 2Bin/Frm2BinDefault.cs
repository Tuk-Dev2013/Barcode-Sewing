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
namespace PicklistBOM._2Bin
{
    public partial class Frm2BinDefault : Form
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
        public Frm2BinDefault()
        {
            InitializeComponent();
        }

        private void Frm2BinDefault_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet5.Leather_Type1' table. You can move, or remove it, as needed.
            this.leather_Type1TableAdapter.Fill(this.dBBARCODEDataSet5.Leather_Type1);
            DateTime sdate1 = DateTime.Now;
            this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            // Call2Bin();
            //*** Insert Item ***//

            CallDetail();
            this.CboLine.Focus();
            Call2Bin();
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
                strSQL1 = " SELECT  TypeID, TypeName, Status FROM  Lean_Type2Bin  Order by Status";

                if (Isfind2 == true)
                {
                    ds.Tables["style"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                //*** DropDownList ***// 
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    this.CboLine.DisplayMember = "TypeName";
                    this.CboLine.ValueMember = "TypeID";
                    this.CboLine.DataSource = ds.Tables["style"];

                }
                else
                {
                    Isfind2 = false;
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

        private void splitLotPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void reportPicklistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinAll page = new PicklistBOM._2Bin.FrmReport2BinAll();
            page.Show();
            this.Hide();
        }

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinRec page = new PicklistBOM._2Bin.FrmReport2BinRec();
            page.Show();
            this.Hide();
        }

 

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtcode.Text == "")
                {
                    MessageBox.Show("No Item code");
                    return;
                }
                System.Data.SqlClient.SqlCommand Cmd;
                System.Data.SqlClient.SqlDataReader rs;
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                // conn.Open();
                try
                {
                    Cmd = new System.Data.SqlClient.SqlCommand(" select ItemCode,ItemName,100 as Amount,ItemNote,ItemUnit from dbo.DatItem "
                  + " Where ItemCode ='" + this.txtcode.Text.Trim() + "'", conn);
                    conn.Open();
                    rs = Cmd.ExecuteReader();
                    while (rs.Read())
                    {
                        this.txtname.Text = rs["ItemName"].ToString();
                        this.txtqty.Text = rs["Amount"].ToString();
                        this.txtuom.Text = rs["ItemUnit"].ToString();

                    }


                    // Callgridview();
                }
                catch (Exception ex)
                {
                }
                conn.Close();
            }
        }

        #region "add:"
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtcode.Text == "")
            {
                MessageBox.Show("No Item code");
                return;
            }
            if (this.txtname.Text == "")
            {
                MessageBox.Show("No ItemName");
                return;
            }
                
                  var query = new StringBuilder();
                  query.Append("INSERT INTO Lean_Default2Bin(TypeName, Itemcode, Barcode, ItemName, Qty, UOM, DefaultDate, DocUser, Status)");
                  query.Append(" VALUES (@TypeName, @Itemcode, @Barcode, @ItemName, @Qty, @UOM, @DefaultDate, @DocUser, @Status)");

                  SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                  conn1.Open();
                  using (var db = new DbHelper1())
                          {
                           try
                                  {
                                     // barcode

                                      if (Cbogroup.Text == "Final  Assemble")
                                      {
                                          CGlobal.strG = "A";
                                      }
                                      else if (Cbogroup.Text == "Pressing")
                                      {
                                          CGlobal.strG = "P";
                                      }
                                      else if (Cbogroup.Text == "Stuffing")
                                      {
                                          CGlobal.strG = "S";
                                      }
                                      else if (Cbogroup.Text == "Back UPH")
                                      {
                                          CGlobal.strG = "B";
                                      }
                                      else if (Cbogroup.Text == "Seat UPH")
                                      {
                                          CGlobal.strG = "E";
                                      }
                                      else if (Cbogroup.Text == "Body UPH")
                                      {
                                          CGlobal.strG = "O";
                                      }
                                      else if (Cbogroup.Text == "Packing")
                                      {
                                          CGlobal.strG = "C";
                                      }

                                      string bracode = this.CboLine.Text + this.txtcode.Text.Trim() + CGlobal.strG; ;// + CGlobal.strG;
                                     // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                                       db.AddParameter("@TypeName", this.CboLine.Text);
                                       db.AddParameter("@ItemCode", this.txtcode.Text.Trim());
                                       db.AddParameter("@Barcode", bracode);
                                       db.AddParameter("@ItemName", this.txtname.Text.Trim());
                                       db.AddParameter("@Qty", Convert.ToDouble(this.txtqty.Text.Trim()));
                                       db.AddParameter("@UOM", this.txtuom.Text.Trim());
                                       db.AddParameter("@DefaultDate", DateTime.Now);
                                       db.AddParameter("@DocUser", CGlobal.UserID);//CGlobal.UserID
                                       db.AddParameter("@Status", Cbogroup.SelectedValue);  // 0 : ยังไม่รับ 1: รับ
                                       db.ExecuteNonQuery(query.ToString());
                                  }

                              catch (Exception ex)
                              {
                                       // db.RollbackTransaction();
                                   MessageBox.Show("No Save Data");
                                   this.txtqty.Text = "0";
                                   this.txtqty.Focus();
                                   CGlobal.strG = "";

                             }
                        }
                    conn1.Close();
                    Call2Bin();
                    this.txtcode.Text = "";
                    this.txtname.Text = "";
                    this.txtqty.Text = "0";
                    this.txtuom.Text = "";
        }
        #endregion

        #region "search2bin"
        private void Call2Bin()
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT   DefaultID, TypeName, Itemcode, Barcode, ItemName, Qty, UOM ,(select  TypeName From Leather_Type1 where LeatherID =Status)as Typename11"
                + " FROM   Lean_Default2Bin  Where TypeName ='" + this.CboLine.Text + "' order by Typename11";

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
                MessageBox.Show("No Data");
            }
            conn.Close();
        }
        #endregion

        private void CboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Call2Bin();
        }

        #region "double gridview"
        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการลบรายการ  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                try
                {
                    int index = gridView1.FocusedRowHandle;
                    DataRow row = gridView1.GetDataRow(index);
                    String tempID = Convert.ToString(gridView1.GetDataRow(index)["DefaultID"]);
                    // MessageBox.Show(tempID);
                    CallDelete(tempID);
                }
                catch (Exception ex)
                {
                }
            }


        }
        #endregion

        #region "      CallDelete temp 2bin"
        private void CallDelete(string tempID)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.Lean_Default2Bin where DefaultID='" + tempID + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            Call2Bin();
        }

        #endregion

        private void bnt2bin_Click(object sender, EventArgs e)
        {
            CGlobal.TempWipR = this.CboLine.Text;
            PicklistBOM._2Bin.ReportBarcode page = new PicklistBOM._2Bin.ReportBarcode();
            page.Show();
        }

        private void bntall_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmReport2BinAll page = new PicklistBOM._2Bin.FrmReport2BinAll();
            page.Show();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }
    }
}
