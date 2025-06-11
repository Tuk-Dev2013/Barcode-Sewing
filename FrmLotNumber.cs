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
namespace PicklistBOM
{
    public partial class txtPOSearch1 : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public txtPOSearch1()
        {
            InitializeComponent();
        }

 

        private void bntsearch_Click(object sender, EventArgs e)
        {
            if (this.cboDocRefNo.Text == "")
            {
                MessageBox.Show("กรุณาป้อน PO# ก่อนค่ะ");
                return;

            }
            this.gridshow.DataSource = null;
            CallGridViewPO();
            CallGridViewPODetail();
        }

        #region "head PO#"
        private void CallGridViewPO()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT   dbo.DatDocType.DocTypeName, dbo.DatStatus.StatName, dbo.DocOrder.DocNo, dbo.DocOrder.DocBrn, dbo.DocOrder.DocDate, "
              + " dbo.DocOrder.DocRefNo, dbo.DocOrder.DocCust, dbo.DocOrder.CustName, dbo.DocOrder.DocProj, dbo.DocOrder.DocStock, dbo.DocOrder.DocExpDt,   dbo.DocOrder.DocNote, dbo.DocOrder.DocRevise,dbo.DocOrder.DocStatus,  dbo.DocOrder.DocType, dbo.DocOrder.DocRefNo,"
              + "  dbo.DocOrder.DocShipment, dbo.DocOrder.DocContact, dbo.DocOrder.BomNo,  dbo.DocOrder.CloseBy, dbo.DocOrder.CloseDate, dbo.DocOrder.QtyTotal, dbo.DocOrder.DocPONo , dbo.DocOrder.DocBrn, dbo.DocOrder.DocUser, dbo.DocOrder.CloseBy, dbo.DocOrder.CloseDate"
              + " FROM   dbo.DocOrder INNER JOIN    dbo.DatDocType ON dbo.DocOrder.DocType = dbo.DatDocType.DocTypeCode INNER JOIN "
              + " dbo.DatStatus ON dbo.DocOrder.DocStatus = dbo.DatStatus.StatCode "
              + " Where dbo.DocOrder.DocRefNo ='" + this.cboDocRefNo.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtorderNO.Text = rs["DocNo"].ToString();
                    txtOrderDate.Text = rs["DocDate"].ToString();
                    txtStatus.Text = rs["StatName"].ToString();
                    txtPO.Text = rs["DocRefNo"].ToString();
                    txtEdate.Text = rs["DocExpDt"].ToString();
                    txtordertype.Text = rs["DocTypeName"].ToString();
                    txtCusID.Text = rs["DocCust"].ToString();
                    txtCus.Text = rs["CustName"].ToString();
                    txtContact.Text = rs["DocContact"].ToString();
                    txtdes.Text = rs["DocShipment"].ToString();
                    txtLocation.Text = rs["DocStock"].ToString();
                    txtProject.Text = rs["DocProj"].ToString();
                    txtremark.Text = rs["DocNote"].ToString();
                    txtrevise.Text = rs["DocRevise"].ToString();
                    txtPomaster.Text = rs["DocRefNo"].ToString();
                    txtBomno.Text = rs["BomNo"].ToString();
                    txtRef.Text = rs["DocRefNo"].ToString();
                    CGlobal.Status = "0"; ;
                    CGlobal.OrderType = rs["DocType"].ToString();
                    CGlobal.DocBrn = rs["DocBrn"].ToString();
                    CGlobal.DocUser = rs["DocUser"].ToString();
                    CGlobal.CloseBy = rs["CloseBy"].ToString();
                    CGlobal.CloseDate = rs["CloseDate"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();

        }
        #endregion

        #region "  CallGridViewPODetail();"
        private void CallGridViewPODetail()
        {
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT   DocBrn, DocLine, DocItem,ItemName, DocQty, DocStock, DocFlag, BomNo, DocRefNo, DocPack"
                + " FROM   DocOrderDtl  WHERE DocNo ='" + this.txtorderNO.Text.Trim() + "'";

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

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
           // MessageBox.Show("select OK");
            try
            {
                int index = gridView1.FocusedRowHandle;
                DataRow row = gridView1.GetDataRow(index);
                String tempID = Convert.ToString(gridView1.GetDataRow(index)["DocItem"]);
               // MessageBox.Show(tempID);

                //ทำการ Update รายการก่อน
                CallUpdateSplitlot();


                CallSelectPart(tempID);
            }
            catch (Exception ex)
            {
            }
        }

        #region "  CallUpdateSplitlot()"
        private void CallUpdateSplitlot()
        {

           // double sum = 0.00;
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {

                string DocItem = Convert.ToString(gridView2.GetDataRow(i)["DocItem"]);
                string ItemName = Convert.ToString(gridView2.GetDataRow(i)["ItemName"]);
                string DocQty = Convert.ToString(gridView2.GetDataRow(i)["DocQty"]);
                string DocPrice = Convert.ToString(gridView2.GetDataRow(i)["DocPrice"]);
                string DocNo = Convert.ToString(gridView2.GetDataRow(i)["DocNo"]);

                var query = new StringBuilder();
                query.Append("UPDATE dbo.Splitlot_DocOrderDtl  SET");
                query.Append(" DocQty  = @DocQty");
                query.Append(", ItemName  = @ItemName");
                query.Append(" WHERE DocItem =  @DocItem");
                query.Append(" and DocNo =  @DocNo");


                using (var db = new DbHelper1())
                {
                    try
                    {
                        db.AddParameter("@DocQty", DocQty);
                        db.AddParameter("@ItemName", ItemName);
                        db.AddParameter("@DocItem", DocItem);
                        db.AddParameter("@DocNo", DocNo);
                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show("Error" + ex);
                    }

                }



            }
        
        }
        #endregion




        #region "insert split number"

        private void CallSelectPart(string tempID)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select * from dbo.DocOrderDtl  where DocRefNo ='" + txtPO.Text.Trim() + "' AND DocItem ='" + tempID + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    String DocNo = rs["DocNo"].ToString();
                    String DocBrn = rs["DocBrn"].ToString();
                    String DocLine = rs["DocLine"].ToString();
                    String DocItem = rs["DocItem"].ToString();
                    String DocQty = rs["DocQty"].ToString();
                    String DocPrice = rs["DocPrice"].ToString();
                    String DocStock = rs["DocStock"].ToString();
                    String DocFlag = rs["DocFlag"].ToString();
                    String BomNo = rs["BomNo"].ToString();
                    String DocRefNo = rs["DocRefNo"].ToString();
                    String DocPack = rs["DocPack"].ToString();
                    String ItemName = rs["ItemName"].ToString();

                    //save
                  var query = new StringBuilder();
                  query.Append("INSERT INTO Splitlot_DocOrderDtl (DocNo, DocBrn, DocLine, DocItem, DocQty, DocPrice, DocStock, DocFlag, BomNo, DocRefNo, DocPack, ItemName ,StrDelete)");
                  query.Append(" VALUES (@DocNo, @DocBrn, @DocLine, @DocItem, @DocQty, @DocPrice, @DocStock, @DocFlag, @BomNo, @DocRefNo, @DocPack, @ItemName, @StrDelete)");

                using (var db = new DbHelper())
                    {
                      try
                       {
                           db.AddParameter("@DocNo", DocNo);
                           db.AddParameter("@DocBrn", DocBrn);
                           db.AddParameter("@DocLine", DocLine);
                           db.AddParameter("@DocItem", DocItem);
                           db.AddParameter("@DocQty", DocQty);
                           db.AddParameter("@DocPrice", DocPrice);
                           db.AddParameter("@DocStock", DocStock);
                           db.AddParameter("@DocFlag", DocFlag);
                           db.AddParameter("@BomNo", BomNo);
                           db.AddParameter("@DocRefNo", DocRefNo);
                           db.AddParameter("@DocPack", DocPack);
                           db.AddParameter("@ItemName", ItemName);
                           db.AddParameter("@StrDelete", "Delete");
                           db.ExecuteNonQuery(query.ToString());
                           // MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                    }

                    catch (Exception ex)
                    {
                        // db.RollbackTransaction();
                        MessageBox.Show("Duplicate");
             
                    }
                   }
            
               
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

            //Call Split lot Number
            CallShowSplit();
            sum();

        }

        #endregion

        #region " CallShowSplit()"
        private void CallShowSplit()
        {
            this.GridSplitLot.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select * from dbo.Splitlot_DocOrderDtl ";

                if (Isfind1 == true)
                {
                    ds.Tables["SplitLot"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "SplitLot");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["SplitLot"];
                    GridSplitLot.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                    this.GridSplitLot.DataSource = null;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                //alert("No Data");
            }
            conn.Close();
        
        
        }

        #endregion

        #region "sum total"
        private void sum()
        {

            double sum = 0.00;
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {
                string num = Convert.ToString(gridView2.GetDataRow(i)["DocQty"]);
                sum = sum + Convert.ToDouble(num);
            }
            lblsum.Text = Convert.ToString(sum);
        
        }
        #endregion


        private void GridSplitLot_Click(object sender, EventArgs e)
        {
            //int index = gridView2.FocusedRowHandle;
            //DataRow row = gridView2.GetDataRow(index);

            //lblItemNO.Text = Convert.ToString(gridView2.GetDataRow(index)["DocItem"]);
          //  MessageBox.Show(DocItem);


        }


        #region "delete"
        private void GridSplitLot_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            DataRow row = gridView2.GetDataRow(index);

            string DocItem  = Convert.ToString(gridView2.GetDataRow(index)["DocItem"]);
           // MessageBox.Show(DocItem);

             if ((MessageBox.Show("คุณต้องการลบข้อมูล " + DocItem + "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
             {
                 SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
                 conn.Open();
                 try
                 {
                     string cmdQuery1 = " Delete  from dbo.Splitlot_DocOrderDtl  Where  DocItem = '" + DocItem.Trim() + "'";
                     SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                     cmd.ExecuteNonQuery();
                 }
                 catch (Exception ex)
                 {

                 }
                 CallShowSplit();
                 sum();
                 conn.Close();
             }
        }
        #endregion

        #region "transfer Leand"
        private void bntTranfer_Click(object sender, EventArgs e)
        {
            if (GridSplitLot.DataSource == null)
            {
                MessageBox.Show("No Data Transfer");
                return;
            }

            if ((MessageBox.Show("คุณต้องการ Transfer PO : " + txtPO.Text.Trim() + "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                //Check ซ้ำ
                CallDup();
                CallDupDocRefNo();

                if (CGlobal.CheckPO == this.txtorderNO.Text.Trim())
                {
                   
                    MessageBox.Show("PO#. ซ้ำไม่สามารถ Transfer ได้");
                }
                else if (CGlobal.CheckPORef == this.txtRef.Text.Trim())
                {
                    MessageBox.Show("PO CheckPORef. ซ้ำไม่สามารถ Transfer ได้");
                }
                else
                {
                  TransferHeadPO();
                    TranferDetailPO();
                }
              
            }
        }

        #endregion

        #region "check ซ้ำ"
        private void CallDup()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
           // conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select DocNo from dbo.DocOrder  "
              + " Where DocNo ='" + this.txtorderNO.Text.Trim() + "'", conn);
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

        #region "check ซ้ำ  DocRefNo"
        private void CallDupDocRefNo()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            // conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select DocRefNo from dbo.DocOrder  "
              + " Where DocRefNo ='" + this.txtRef.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.CheckPORef = rs["DocRefNo"].ToString();

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }


        #endregion


        #region " TransferHeadPO()"
        private void TransferHeadPO()
        {

            //save
            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocOrder (DocNo, DocBrn, DocType, DocDate, DocRefNo, DocStatus, DocCust, CustName, DocProj, DocStock, DocExpDt, DocNote, DocUser, DocRevise,DocShipment, DocContact, BomNo, CloseBy, CloseDate, QtyTotal, DocPONo)");
            query.Append(" VALUES (@DocNo, @DocBrn, @DocType, @DocDate, @DocRefNo, @DocStatus, @DocCust, @CustName, @DocProj, @DocStock, @DocExpDt, @DocNote, @DocUser, @DocRevise,@DocShipment, @DocContact, @BomNo, @CloseBy, @CloseDate, @QtyTotal, @DocPONo)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@DocNo", txtorderNO.Text.Trim());
                    db.AddParameter("@DocBrn", CGlobal.DocBrn.Trim());
                    db.AddParameter("@DocType", CGlobal.OrderType.Trim());
                    db.AddParameter("@DocDate", Convert.ToDateTime(txtOrderDate.Text.Trim()));
                    db.AddParameter("@DocRefNo", txtRef.Text.Trim());
                    db.AddParameter("@DocStatus", CGlobal.Status.Trim());
                    db.AddParameter("@DocCust", txtCusID.Text.Trim());
                    db.AddParameter("@CustName", txtCus.Text.Trim());
                    db.AddParameter("@DocProj", txtProject.Text.Trim());
                    db.AddParameter("@DocStock", txtLocation.Text .Trim());
                    db.AddParameter("@DocExpDt", Convert.ToDateTime(txtEdate.Text.Trim()));
                    db.AddParameter("@DocNote", txtremark.Text.Trim());
                    db.AddParameter("@DocUser", CGlobal.DocUser);
                    db.AddParameter("@DocRevise", txtrevise.Text.Trim());
                    db.AddParameter("@DocShipment", txtdes.Text.Trim());
                    db.AddParameter("@DocContact", txtContact.Text.Trim());
                    db.AddParameter("@BomNo", txtBomno.Text.Trim());
                    db.AddParameter("@CloseBy", CGlobal.CloseBy);
                    db.AddParameter("@CloseDate", "");
                    db.AddParameter("@QtyTotal", lblsum.Text.Trim());
                    db.AddParameter("@DocPONo", txtPO.Text.Trim());
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

        #region " TranferDetailPO()"
        private void TranferDetailPO()
        {
            //save
            Int16 num = 0;
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {

            
                string DocItem = Convert.ToString(gridView2.GetDataRow(i)["DocItem"]);
                string ItemName = Convert.ToString(gridView2.GetDataRow(i)["ItemName"]);
                string DocQty = Convert.ToString(gridView2.GetDataRow(i)["DocQty"]);
                string DocPrice = Convert.ToString(gridView2.GetDataRow(i)["DocPrice"]);
                string DocStock = Convert.ToString(gridView2.GetDataRow(i)["DocStock"]);
                string DocFlag = "0";
                string BomNo = Convert.ToString(gridView2.GetDataRow(i)["BomNo"]);
                string DocPack = Convert.ToString(gridView2.GetDataRow(i)["DocPack"]);
                string DocBrn = Convert.ToString(gridView2.GetDataRow(i)["DocBrn"]);
         
            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocOrderDtl (DocNo, DocBrn, DocLine, DocItem, DocQty, DocPrice, DocStock, DocFlag, BomNo, DocRefNo, DocPack, ItemName)");
            query.Append(" VALUES (@DocNo, @DocBrn, @DocLine, @DocItem, @DocQty, @DocPrice, @DocStock, @DocFlag, @BomNo, @DocRefNo, @DocPack, @ItemName)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@DocNo", txtorderNO.Text.Trim());
                    db.AddParameter("@DocBrn", DocBrn);
                    db.AddParameter("@DocLine", i+1);
                    db.AddParameter("@DocItem", DocItem);
                    db.AddParameter("@DocQty", DocQty);
                    db.AddParameter("@DocPrice", DocPrice);
                    db.AddParameter("@DocStock", DocStock);
                    db.AddParameter("@DocFlag", DocFlag);
                    db.AddParameter("@BomNo", BomNo);
                    db.AddParameter("@DocRefNo", txtRef.Text.Trim());
                    db.AddParameter("@DocPack", DocPack);
                    db.AddParameter("@ItemName", ItemName);
                    db.ExecuteNonQuery(query.ToString());
                
                  
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("No Transfer"); 

                }
            }
            conn.Close();
            }
            MessageBox.Show(" Transfer Complete");
            CallClear();
            CallDelete();
            gridshow.DataSource = null;
            GridSplitLot.DataSource = null;

            
        
        
        }
        #endregion

        #region " CallClear();"
        private void CallClear()
        {
            txtorderNO.Text = "";
            txtOrderDate.Text = "";
           // txtPOSearch.Text = "";
            txtStatus.Text = "";
            txtPO.Text = "";
            txtEdate.Text = "";
            txtordertype.Text = "";
            txtCusID.Text = "";
            txtCus.Text = "";
            txtContact.Text = "";
            txtdes.Text = "";
            txtLocation.Text = "";
            txtProject.Text = "";
            txtremark.Text = "";
            txtrevise.Text = "";
            txtPomaster.Text = "";
            txtBomno.Text = "";
            txtRef.Text = "";
            lblsum.Text = "0.00";
        }
        #endregion

        #region "      CallDelete();"
        private void CallDelete()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.Splitlot_DocOrderDtl ";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region "sum"
        private void GridSplitLot_EditorKeyPress(object sender, KeyPressEventArgs e)
      {
            sum();
           
        }

        private void GridSplitLot_EditorKeyDown(object sender, KeyEventArgs e)
        {
            sum();
        }

        private void GridSplitLot_EditorKeyUp(object sender, KeyEventArgs e)
        {
            sum();
        }

        private void GridSplitLot_MouseClick(object sender, MouseEventArgs e)
        {
            sum();
        }

        private void GridSplitLot_Enter(object sender, EventArgs e)
        {
            sum();
   
        }

        private void GridSplitLot_KeyDown(object sender, KeyEventArgs e)
        {
            sum();
        }

        private void GridSplitLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            sum();
        }

        private void GridSplitLot_KeyUp(object sender, KeyEventArgs e)
        {
            sum();
        }
        #endregion

        private void txtPOSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.cboDocRefNo.Text == "")
                {
                    MessageBox.Show("กรุณาป้อน PO# ก่อนค่ะ");
                    return;

                }
                this.gridshow.DataSource = null;
                CallGridViewPO();
                CallGridViewPODetail();
            }

        }

        private void splitLotPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPOSearch1 page = new txtPOSearch1();
            page.Show();
            this.Hide();

        }

        private void reportPicklistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            page.Show();
            this.Hide();
        }

        private void txtPOSearch1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet4.View_DocOrder' table. You can move, or remove it, as needed.
            this.view_DocOrderTableAdapter.Fill(this.dBBARCODEDataSet4.View_DocOrder);
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text =  CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            //ToolStripStatusLabelConnect.Text = CGlobal.BandName;

            CallDeleteAll();
        }

        #region "CalldeleteAll"
        private void CallDeleteAll()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.Splitlot_DocOrderDtl";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        
        }
        #endregion

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmBatch page = new PicklistBOM._2Bin.FrmBatch();
            page.Show();
            this.Hide();
        }

        private void cboDocRefNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridshow.DataSource = null;
            CallGridViewPO();
            CallGridViewPODetail();
        }

        private void cboDocRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                this.gridshow.DataSource = null;
                CallGridViewPO();
                CallGridViewPODetail();
            }
        }

    }
}
