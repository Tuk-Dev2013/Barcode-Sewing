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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
namespace PicklistBOM._2Bin
{

    public partial class Frm2BinToAccpac : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public Frm2BinToAccpac()
        {
            InitializeComponent();
        }

        private void Frm2BinToAccpac_Load(object sender, EventArgs e)
        {
            CallNo();
            CallNo1();
  
        }

        #region " CallNo(); "
        private void CallNo()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string strSQL1 = "";
                //  strSQL1 = " select style,style from dbo.tb_DatSpecW1  Where model='" + this.cbomodel.SelectedValue + "'";
                strSQL1 = " SELECT Cnumber from dbo.Lean_Doc2BinNuber ORDER BY Cnumber DESC";

                if (Isfind == true)
                {
                    ds.Tables["Cell"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell");
                //*** DropDownList ***// 
                if (ds.Tables["Cell"].Rows.Count != 0)
                {
                    Isfind = true;
                    this.cbono.DisplayMember = "Cnumber";
                    this.cbono.ValueMember = "Cnumber";
                    this.cbono.DataSource = ds.Tables["Cell"];


                    //this.cbono1.DisplayMember = "Cnumber";
                    //this.cbono1.ValueMember = "Cnumber";
                    //this.cbono1.DataSource = ds.Tables["Cell"];

                }
                else
                {
                    Isfind = false;
                    this.cbono.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;

              //  cbono.SelectedValue = "12";
            }
            catch (Exception ex)
            {


            }
        
        }

        #endregion

        #region " CallNo(); "
        private void CallNo1()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string strSQL1 = "";
                //  strSQL1 = " select style,style from dbo.tb_DatSpecW1  Where model='" + this.cbomodel.SelectedValue + "'";
                strSQL1 = " SELECT Cnumber from dbo.Lean_Doc2BinNuber ORDER BY Cnumber DESC";

                if (Isfind2 == true)
                {
                    ds.Tables["Cell2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell2");
                //*** DropDownList ***// 
                if (ds.Tables["Cell2"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    //this.cbono.DisplayMember = "Cnumber";
                    //this.cbono.ValueMember = "Cnumber";
                    //this.cbono.DataSource = ds.Tables["Cell"];


                    this.cbono1.DisplayMember = "Cnumber";
                    this.cbono1.ValueMember = "Cnumber";
                    this.cbono1.DataSource = ds.Tables["Cell2"];

                }
                else
                {
                    Isfind2 = false;
                    this.cbono.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;

                //  cbono.SelectedValue = "12";
            }
            catch (Exception ex)
            {


            }

        }

        #endregion


        #region " CallDetail();"
        private void CallDetail()
        {
  
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Cnumber, PONumber, BOI, Sdate, Type, Status from Lean_Doc2BinNuber "
              + " Where Cnumber='" + cbono.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //txtPo1.Text = rs["PONumber"].ToString();
                    //txtcell.Text = rs["Type"].ToString();
                    //txtdate.Text = rs["Sdate"].ToString();
                    //txtpro.Text = rs["BOI"].ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //txtPo1.Text = "";
            //txtcell.Text = "";
            //txtdate.Text = "";
           // CallDetail();

            //string startDate = txtdate.Text.Trim() + " 08:00:00.310";
            //string EndtDate = txtdate.Text.Trim() + " 23:00:00.310";

            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
            
                string strSQL1 = "";

                strSQL1 = " SELECT Cnumber, PONumber, BOI, Sdate, Type, Status FROM   Lean_Doc2BinNuber "
                + " where  Cnumber between '" + this.cbono.Text.Trim() + "' and  '" + this.cbono1.Text.Trim() + "'";


                //strSQL1 = " SELECT  ItemCode, TypeName, ItemName, Sum(DocQty) DocQty,ItemUnit  FROM   Lean_Doc2Bin  "
                //+ " where DocUserDate between '" + startDate + "' and  '" + EndtDate + "'"
                //+"  and TypeName= '" + txtcell.Text.Trim() +"'"
                //+ " and Status='Success' group by  ItemCode, TypeName, ItemName ,ItemUnit ";

                if (Isfind1 == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        #region "check ซ้ำ"
        private void CallDup()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select DocNo from dbo.DocIssue  "
              + " Where DocNo ='" + this.cbono.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.CheckPO = rs["DocNo"].ToString();

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }


        #endregion

        #region "CallInsertHead()"
        private void CallInsertHead(String Cnumber, String PONumber,String BOI, String Sdate, String Type)
        {
            //save
            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocIssue (DocNo, DocBrn, DocType, DocDate, DocRefNo, DocStatus, DocEmp, DocPoNo, DocDept, DocStock, DocNote, DocUser, DocRecBy, DocStockIn, PostBy, PostDate, DocProj, DocRecDate)");
            query.Append(" VALUES (@DocNo, @DocBrn, @DocType, @DocDate, @DocRefNo, @DocStatus, @DocEmp, @DocPoNo, @DocDept, @DocStock, @DocNote, @DocUser, @DocRecBy, @DocStockIn, @PostBy, @PostDate, @DocProj, @DocRecDate)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    string startDate = Sdate  + " 08:00:00.310";
                    db.AddParameter("@DocNo", Cnumber);
                    db.AddParameter("@DocBrn", "HOF");
                    db.AddParameter("@DocType", "SI1");
                    db.AddParameter("@DocDate", startDate);
                    db.AddParameter("@DocRefNo", PONumber);
                    db.AddParameter("@DocStatus","8");
                    db.AddParameter("@DocEmp", "5608002");
                    db.AddParameter("@DocPoNo", Type);
                    db.AddParameter("@DocDept", Type);
                    db.AddParameter("@DocStock", "8");
                    db.AddParameter("@DocNote","");
                    db.AddParameter("@DocUser", "");
                    db.AddParameter("@DocRecBy", "5608002");
                    db.AddParameter("@DocStockIn", "");
                    db.AddParameter("@PostBy", "");
                    db.AddParameter("@PostDate", "");
                    db.AddParameter("@DocProj", BOI);
                    db.AddParameter("@DocRecDate", startDate);
                    db.ExecuteNonQuery(query.ToString());
                    //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("No Transfer");

                }
            }
            conn.Close();
            
        
        
        
        }
        #endregion

        #region "CallInsertDetail();"
        private void CallInsertDetail(String Cnumber, String PONumber, String BOI, String Sdate, String Type)
        {


            string startDate = Sdate + " 08:00:00.310";
            string EndtDate = Sdate + " 23:00:00.310";


            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";

                strSQL1 = " SELECT  ItemCode, TypeName, ItemName, Sum(DocQty) DocQty,ItemUnit,DocUserRec  FROM   Lean_Doc2Bin  "
                + " where DocUserDate between '" + startDate + "' and  '" + EndtDate + "'"
                + "  and TypeName= '" + Type + "'"
                + " and Status='Success' group by  ItemCode, TypeName, ItemName ,ItemUnit,DocUserRec ";

                if (Isfind3 == true)
                {
                    ds.Tables["Show"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Show");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["Show"];
                   //insert Detail
                    for (int i = 0; i < ds.Tables["Show"].Rows.Count; i++)
                    {
                        string ItemCode = ds.Tables["Show"].Rows[i]["ItemCode"].ToString();
                        string stock = ds.Tables["Show"].Rows[i]["DocUserRec"].ToString();
                        string TypeName = ds.Tables["Show"].Rows[i]["TypeName"].ToString();
                        string ItemName = ds.Tables["Show"].Rows[i]["ItemName"].ToString();
                        string DocQty = ds.Tables["Show"].Rows[i]["DocQty"].ToString();
                        string ItemUnit = ds.Tables["Show"].Rows[i]["ItemUnit"].ToString();
                        var query = new StringBuilder();
                        query.Append("INSERT INTO dbo.DocIssueDtl (DocNo, DocBrn, DocLine, DocItem, DocQty, DocStock, DocLotNo, DocRec, DocBal, DocCost, DocDept)");
                        query.Append(" VALUES (@DocNo, @DocBrn, @DocLine, @DocItem, @DocQty, @DocStock, @DocLotNo, @DocRec, @DocBal, @DocCost, @DocDept)");

                        SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                        conn1.Open();
                        using (var db = new DbHelper1())
                        {
                            try
                            {
                                db.AddParameter("@DocNo", Cnumber);
                                db.AddParameter("@DocBrn", "HOF");
                                db.AddParameter("@DocLine", i + 1);
                                db.AddParameter("@DocItem", ItemCode);
                                db.AddParameter("@DocQty", DocQty);
                                db.AddParameter("@DocStock", stock);
                                db.AddParameter("@DocLotNo", "-");
                                db.AddParameter("@DocRec", "0");
                                db.AddParameter("@DocBal", "0");
                                db.AddParameter("@DocCost", "0");
                                db.AddParameter("@DocDept", Type);
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

                }
                else
                {
                    Isfind3 = false;
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


        private void button2_Click(object sender, EventArgs e)
        {
            if (gridshow.DataSource == null)
            {
                MessageBox.Show("No Data Transfer");
                return;
            }
            if ((MessageBox.Show("คุณต้องการ Transfer 2Bin นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                //Check ซ้ำ
                CallDup();

                if (CGlobal.CheckPO == this.cbono.Text.Trim())
                {

                    MessageBox.Show("PO#. ซ้ำไม่สามารถ Transfer ได้");
                }
                else 
                {
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        string Cnumber = Convert.ToString(gridView1.GetDataRow(i)["Cnumber"]);
                        string PONumber = Convert.ToString(gridView1.GetDataRow(i)["PONumber"]);
                        string BOI = Convert.ToString(gridView1.GetDataRow(i)["BOI"]);
                        string Sdate = Convert.ToString(gridView1.GetDataRow(i)["Sdate"]);
                        string Type = Convert.ToString(gridView1.GetDataRow(i)["Type"]);
                        CallInsertHead(Cnumber, PONumber, BOI, Sdate, Type);
                        CallInsertDetail(Cnumber, PONumber, BOI, Sdate, Type);

                    }

                    MessageBox.Show(" Transfer Complete");
                }

            }
        }

        #region " DeletensertHead();"
        private void DeletensertHead()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " delete  FROM  DocIssue where DocNo like 'C%' ";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
        
        }

        #endregion

        #region "DeleteInsertDetail()"
        private void DeleteInsertDetail()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " delete  FROM  DocIssueDtl where DocNo like 'C%'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
        }
        #endregion


        private void button3_Click(object sender, EventArgs e)
        {
            //   if (gridshow.DataSource == null)
            //{
            //    MessageBox.Show("No Data Transfer");
            //    return;
            //}
            if ((MessageBox.Show("คุณต้องการลบ ข้อมูล 2Bin ที่ Transfer ทั้งหมดหรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
               {
                   DeletensertHead();
                   DeleteInsertDetail();
                   MessageBox.Show(" Delete Complete");

               }
        }
    }
}
