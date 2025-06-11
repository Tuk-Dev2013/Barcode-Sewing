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
    public partial class FrmMainDelete : Form
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
        public FrmMainDelete()
        {
            InitializeComponent();
        }

        private void FrmMainDelete_Load(object sender, EventArgs e)
        {
          //  CallPO();
            CallCell();
        }
        //#region " Callpo();"
        //private void CallPO()
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //        conn.Open();
        //        SqlDataAdapter dtAdapter;
        //        DataTable dt = new DataTable();



        //        string strSQL1 = "";

        //        strSQL1 = " select POnumber,Cellname  from dbo.A_ScheduleCell order by Startday desc";

        //        if (Isfind == true)
        //        {
        //            ds.Tables["style"].Clear();
        //        }

        //        da = new SqlDataAdapter(strSQL1, conn);
        //        da.Fill(ds, "style");
        //        //*** DropDownList ***// 
        //        if (ds.Tables["style"].Rows.Count != 0)
        //        {
        //            Isfind = true;
        //            this.cbopo.DisplayMember = "POnumber";
        //            this.cbopo.ValueMember = "Cellname";
        //            this.cbopo.DataSource = ds.Tables["style"];

        //        }
        //        else
        //        {
        //            Isfind = false;
        //            this.cbopo.DataSource = null;
        //        }

        //        da = null;
        //        conn.Close();
        //        conn = null;
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}

        //#endregion
     

#region " CallCell;"
        private void CallCell()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";

                strSQL1 = " select cellName from dbo.A_CellType ";

                if (Isfind1 == true)
                {
                    ds.Tables["Cell"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell");
                //*** DropDownList ***// 
                if (ds.Tables["Cell"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    this.cbocell.DisplayMember = "cellName";
                    this.cbocell.ValueMember = "cellName";
                    this.cbocell.DataSource = ds.Tables["Cell"];

                }
                else
                {
                    Isfind1 = false;
                    this.cbocell.DataSource = null;
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
            Callshow();
        }

        #region " callshow()"
        private void Callshow()
        {
            string sdate = this.bntdate.Value.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            this.gridshow.DataSource = null;
            string cell = "";
            if (cbocell.Text == "CELL TRAINING")
            {
                cell = "CELL";
            }
            else
            {
                cell = cbocell.Text.Trim();
            }

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select DocID,DocNo, DeptCode, Qty, Barcode, DocPONo, Sdate, Linenumber, TypeCell, Itemmodel, Barcodedate"
                + " from dbo.DocMODtlBarcode where Sdate ='" + sdate + "' and TypeCell ='" + cell + "' order by Barcodedate ";

                if (Isfind2 == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind2 = false;
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);
            String DocID = Convert.ToString(gridView1.GetDataRow(index)["DocID"]);
            String DocNo = Convert.ToString(gridView1.GetDataRow(index)["DocNo"]);
            String Itemmodel = Convert.ToString(gridView1.GetDataRow(index)["Itemmodel"]);
            String Barcode = Convert.ToString(gridView1.GetDataRow(index)["Barcode"]);
            String Qty = Convert.ToString(gridView1.GetDataRow(index)["Qty"]);

            if ((MessageBox.Show(" คุณต้องการลบ PO#  " + DocNo + " : " + Itemmodel + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                try
                {
                    string Wcell = "W8" + Itemmodel;
                 CallDelete(DocID);
                 searchMODtl(DocNo, Wcell, Barcode);
                 UpdateDocMODtl(DocNo, Wcell, Barcode, Qty);
                 searchScheduleCell(DocNo);
                 UpdateScheduleCell(DocNo);

                }
                catch (Exception ex)
                {
                }
            }

            Callshow();
        }

        #region "      CallDelete DocMODtlBarcode "
        private void CallDelete(string tempID)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.DocMODtlBarcode  where DocID='" + tempID + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
          
        }

        #endregion

        #region "search"
        private void searchMODtl(String DocNo, string Itemmodel, string Barcode)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select QtyBom,QtyOut,QtyBal from dbo.DocMODtl where DocNo='" + DocNo + "' and ItemCode ='" + Itemmodel + "' and Barcode='" +Barcode+ "'"
              + " and DeptCode ='W8'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.QtyBom1 = rs["QtyBom"].ToString();
                    CGlobal.QtyOut1 = rs["QtyOut"].ToString();
                    CGlobal.QtyBal1 = rs["QtyBal"].ToString();

                }


                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion

        #region UpdatedocModtal()
        private void UpdateDocMODtl(string DocNo, string Itemmodel, string Barcode, string Qty)
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
                    double nout = Convert.ToDouble(CGlobal.QtyOut1) - 1;
                    double nbal = Convert.ToDouble(CGlobal.QtyBal1) - 1;
                    db.AddParameter("@QtyOut", nout);
                    db.AddParameter("@QtyBal", nbal);
                    db.AddParameter("@DocNo", DocNo);
                    db.AddParameter("@ItemCode", Itemmodel);
                    db.AddParameter("@Barcode", Barcode);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

            }
    
        
        
        }

#endregion

        #region "searchScheduleCell"
        private void searchScheduleCell(string DocNo)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select Qtyout  from dbo.A_ScheduleCell "
              + " where POnumber ='" + DocNo + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.QtyBalT1 = rs["Qtyout"].ToString();

                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion 

        #region "UpdateScheduleCell"
        private void UpdateScheduleCell(string DocNo)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.A_ScheduleCell  SET");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(" WHERE POnumber =  @POnumber");


            using (var db = new DbHelper1())
            {
                try
                {
                    double nout = Convert.ToDouble(CGlobal.QtyBalT1) - 1;
                    db.AddParameter("@QtyOut", nout);
                    db.AddParameter("@POnumber", DocNo);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

            }
        
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DeletePOCell.frmEditPO1 page = new DeletePOCell.frmEditPO1();  // ยิง barcode จ่าย Poly Batch
            page.ShowDialog();
        }


    }
}
