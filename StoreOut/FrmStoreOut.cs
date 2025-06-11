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
namespace PicklistBOM.StoreOut
{
    public partial class FrmStoreOut : Form
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
        private char enter;



        public FrmStoreOut()
        {
            InitializeComponent();
        }

        private void FrmStoreOut_Load(object sender, EventArgs e)
        {
            //DateTime sdate1 = DateTime.Now;
            this.lbltime.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
            Call2Bin();
            CallStock();
        }


        #region "CallStock"
        private void CallStock()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  ID, Store1, Store2 FROM  A_Stock ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtS1.Text= rs["Store1"].ToString();
                    txtS2.Text = rs["Store2"].ToString();

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();
        
        }
        #endregion 

        #region "barcode'"
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
         if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtbarcode.Text == "")
                {
                    MessageBox.Show("กรุณายิง Barcode ก่อนค่ะ ");
                    return;
                }

              //  CallBarcode();

                if (CGlobal.CheckBarcode2Bin == "YES")
                {
                    MessageBox.Show("คุณยิงรหัส Barcode นี้แล้ว ไม่สามารถยิงซ้ำได้ จนกว่าจะรับ Barcode นี้ก่อน ");
                    this.txtbarcode.Text = "";
                    CGlobal.CheckBarcode2Bin = "";
                    txtbarcode.Focus();
                    return;
                }
                else
                {
                    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                    conn.Open();
                    try
                    {
                        string strSQL1 = "";
                        strSQL1 = " SELECT  TypeName, Status, Itemcode, Barcode, ItemName, Qty, UOM, DefaultDate FROM  Lean_Default2Bin"
                        + " where Barcode='" + this.txtbarcode.Text.Trim() + "'";

                        if (Isfind2 == true)
                        {
                            ds.Tables["Showdata2"].Clear();
                        }

                        da = new SqlDataAdapter(strSQL1, conn);
                        da.Fill(ds, "Showdata2");

                        if (ds.Tables["Showdata2"].Rows.Count != 0)
                        {
                            Isfind2 = true;
                            string TypeName = ds.Tables["Showdata2"].Rows[0]["TypeName"].ToString();
                            string Itemcode = ds.Tables["Showdata2"].Rows[0]["Itemcode"].ToString();
                            string Barcode = ds.Tables["Showdata2"].Rows[0]["Barcode"].ToString();
                            string ItemName = ds.Tables["Showdata2"].Rows[0]["ItemName"].ToString();
                            string Qty = ds.Tables["Showdata2"].Rows[0]["Qty"].ToString();
                            string UOM = ds.Tables["Showdata2"].Rows[0]["UOM"].ToString();
                            string Status111 = ds.Tables["Showdata2"].Rows[0]["Status"].ToString();
                            //insert

                            //start
                            //ตัด stock สินค้า จากคลัง 01 ถ้าไม่มีก็ 00 ต่อ
                            string temcode = Itemcode;// Mid(this.txtbarcode.Text.Trim(), 4, 9);
                            callstocktotal(temcode, this.txtS1.Text.Trim());
                            
                            if (Convert.ToDouble(CGlobal.BalQtyNet) >= Convert.ToDouble(Qty))
                            {


                              //  MessageBox.Show("o1"); ตัด stock 00
                                double BalQtyOut = Convert.ToDouble(CGlobal.BalQtyOut) - Convert.ToDouble(Qty);
                                double BalQtyNet = Convert.ToDouble(CGlobal.BalQtyNet) - Convert.ToDouble(Qty);
                                CallUPdateStockbal(Itemcode, this.txtS1.Text.Trim(), BalQtyOut, BalQtyNet);
                              //// หา lot ที่จะตัด
                              CallLotNumber(temcode, this.txtS1.Text.Trim(), Qty);
                              // หา mov ที่จะตัด
                              InsertStockMov(temcode, this.txtS1.Text.Trim(), Qty, TypeName);
                                //insert Lean_Doc2Bin 
                              if (CGlobal.TmpDouble != "No")
                              {
                                  insert2Bin(TypeName, Itemcode, Barcode, ItemName, Qty, UOM, Status111, this.txtS1.Text.Trim());
                              }
                            }
                            else
                            {
                                // ถ้าไม่พอตัด ให้ไปตัด ตัว 00 ต่อไป
                                callstocktotal(temcode, this.txtS2.Text.Trim());
                                if (Convert.ToDouble(CGlobal.BalQtyNet) >= Convert.ToDouble(Qty))
                                {
                                    //  MessageBox.Show("o1"); ตัด stock 00
                                    double BalQtyOut = Convert.ToDouble(CGlobal.BalQtyOut) - Convert.ToDouble(Qty);
                                    double BalQtyNet = Convert.ToDouble(CGlobal.BalQtyNet) - Convert.ToDouble(Qty);
                                    CallUPdateStockbal(Itemcode, this.txtS2.Text.Trim(), BalQtyOut, BalQtyNet);
                                    //// หา lot ที่จะตัด
                                    CallLotNumber(temcode, this.txtS2.Text.Trim(), Qty);
                                    // หา mov ที่จะตัด
                                    InsertStockMov(temcode, this.txtS2.Text.Trim(), Qty, TypeName);
                                     //insert Lean_Doc2Bin 
                                    if (CGlobal.TmpDouble != "No")
                                    {
                                        insert2Bin(TypeName, Itemcode, Barcode, ItemName, Qty, UOM, Status111, this.txtS2.Text.Trim());
                                    }
                                  
                                }
                                else
                                {
                                    Calldelete(Itemcode, TypeName, "Success");
                                    MessageBox.Show("สินค้าใน stock ไม่พอตัดได้ กรุณาตรวจสอบข้อมูลกับ Store F1");
                                    txtbarcode.Text = "";
                                    txtbarcode.Focus();
                                    return;
                                }

                            }

                            CGlobal.TmpDouble = "";
                            //end

                            Call2Bin();
                            CGlobal.CheckBarcode2Bin = "";
                            this.txtbarcode.Text = "";

                            CGlobal.BalQtyIn ="0";
                            CGlobal.BalQtyOut ="0";
                            CGlobal.BalQtyNet ="0";
                        }
                        else
                        {
                            Isfind2 = false;
                            MessageBox.Show("คุณยังไม่ได้ตั้งค่า Default 2Bin กรุณาเพิ่มรายการที่ Admin ครับ");
                            txtbarcode.Text = "";
                            txtbarcode.Focus();
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

            }

        }
        #endregion

        #region "insert"
        private void insert2Bin(string TypeName, string Itemcode, string Barcode, string ItemName, string Qty, string UOM, string Status111,String stock)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();

            var query = new StringBuilder();
            query.Append("INSERT INTO Lean_Doc2Bin(Barcode, ItemCode, TypeName, ItemName, DocQty, DocCost, ItemUnit, Remark, LineCell, DocUser, DocUserDate, DocUserRec, DocUserRecDate, Status)");
            query.Append(" VALUES (@Barcode, @ItemCode, @TypeName, @ItemName, @DocQty, @DocCost, @ItemUnit, @Remark, @LineCell, @DocUser, @DocUserDate, @DocUserRec, @DocUserRecDate, @Status)");

            SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn1.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    // DateTime sdate1 = DateTime.Now;
                    // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    db.AddParameter("@Barcode", Barcode);
                    db.AddParameter("@ItemCode", Itemcode);
                    db.AddParameter("@TypeName", TypeName);
                    db.AddParameter("@ItemName", ItemName);
                    db.AddParameter("@DocQty", Qty);
                    db.AddParameter("@DocCost", this.txtS1.Text.Trim());
                    db.AddParameter("@ItemUnit", UOM);
                    db.AddParameter("@Remark", Status111);
                    db.AddParameter("@LineCell", TypeName);
                    db.AddParameter("@DocUser", CGlobal.UserID);//CGlobal.UserID   23042014
                    db.AddParameter("@DocUserDate", DateTime.Now);
                    db.AddParameter("@DocUserRec", stock);
                    db.AddParameter("@DocUserRecDate", DateTime.Now);
                    db.AddParameter("@Status", "Success");  // 0 : ยังไม่รับ=Out 1: รับ=Success
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
        #endregion


        #region "update stock"
        private void UpdateLean_Doc2Bin(String temcode, string stock, string Qty, string TypeName, String barcode)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Lean_Doc2Bin SET");
            query.Append(" DocUserRec  = @Stock");
            query.Append(" WHERE ItemCode =  @ItemCode");
            query.Append(" AND TypeName =  @TypeName");
            query.Append(" AND CONVERT(VARCHAR(24),Lean_Doc2Bin.DocUserDate,103)=CONVERT(VARCHAR(24),GETDATE(),103)");
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@Stock", stock);
                    db.AddParameter("@ItemCode", temcode);
                    db.AddParameter("@TypeName", TypeName);
                 //   db.AddParameter("@BalItem", itemcode);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Error" + ex);
                }
            }

        }

        #endregion

        #region "Calldelete"
        private void Calldelete(string itemcode, string Type, string Sout)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string tempdut = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string cmdQuery1 = " delete dbo.Lean_Doc2Bin  Where  ItemCode = '" + itemcode + "' and LineCell='" + Type + "' and Status='" + Sout + "' and CONVERT(VARCHAR(24),DocUserDate ,103)='" + tempdut + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            this.txtbarcode.Text = "";
        
        }

        #endregion


        #region "InsertStockMov"
        private void InsertStockMov(string itemcode, string stock, string netout, String TypeName)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO StockMov ( MovBrn, MovItem, MovStock, MovLotNo, MovType, MovModule, MovDocNo, MovRefNo, MovDate, MovQty, MovCost, MovPrice)");
            query.Append(" VALUES (@MovBrn, @MovItem, @MovStock, @MovLotNo, @MovType, @MovModule, @MovDocNo, @MovRefNo, @MovDate, @MovQty, @MovCost, @MovPrice)");

            using (var db = new DbHelper())
            {
                try
                {
                    // กำหนด CELL

                    if (CGlobal.Lotno == null) 
                    {
                        CGlobal.Lotno = "0000000000";
                    }
              

                    string tempdut = DateTime.Now.ToString("mmss", new System.Globalization.CultureInfo("en-US"));
                    string tempcost = "-" + netout;
                    db.AddParameter("@MovBrn", "HOF");
                    db.AddParameter("@MovItem", itemcode);
                    db.AddParameter("@MovStock", stock);
                    db.AddParameter("@MovLotNo", CGlobal.Lotno);  //lotnumber
                    db.AddParameter("@MovType", "O");
                    db.AddParameter("@MovModule", tempdut);
                    db.AddParameter("@MovDocNo", "2BIN");
                    db.AddParameter("@MovRefNo", TypeName);
                    db.AddParameter("@MovDate", DateTime.Now);
                    db.AddParameter("@MovQty", tempcost);
                    db.AddParameter("@MovCost", "0.00");
                    db.AddParameter("@MovPrice", "0.00");
                    db.ExecuteNonQuery(query.ToString());
                    // MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                }

                catch (Exception ex)
                {
                    CGlobal.TmpDouble = "No";
                    MessageBox.Show("Duplicate");

                }
            }
        
        
        
        }

        #endregion

        #region "CallUPdateStockbal"
        private void CallUPdateStockbal(string itemcode, string stock, double sumout, double sumnet)
        {

            var query = new StringBuilder();
            query.Append("UPDATE dbo.StockBal SET");
            query.Append(" BalQtyOut  = @BalQtyOut");
            query.Append(", BalQtyNet  = @BalQtyNet");
            query.Append(" WHERE BalItem =  @BalItem");
            query.Append(" AND BalStock =  @BalStock");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@BalQtyOut", Convert.ToDouble(sumout));
                    db.AddParameter("@BalQtyNet", Convert.ToDouble(sumnet));
                    db.AddParameter("@BalItem", itemcode);
                    db.AddParameter("@BalStock", stock);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        }
        #endregion

        #region " CallLotNumber()"
        private void CallLotNumber(string itemcode, string stock,string  Qty)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select Lotno,LotQtyIn,LotQtyOut,LotQtyNet from dbo.StockLot  where LotItem ='" + itemcode + "' and  LotStock='" + stock + "' and LotQtyIn<>abs(LotQtyOut)", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.Lotno = rs["Lotno"].ToString();
                    CGlobal.LotQtyIn = rs["LotQtyIn"].ToString();
                    CGlobal.LotQtyOut = rs["LotQtyOut"].ToString();
                    CGlobal.LotQtyNet = rs["LotQtyNet"].ToString();

                    if (Convert.ToDouble(CGlobal.LotQtyNet) >= Convert.ToDouble(Qty))
                    {
                        double LotQtyOut1 = Convert.ToDouble(CGlobal.LotQtyOut) - Convert.ToDouble(Qty);
                        double LotQtyNet1 = Convert.ToDouble(CGlobal.LotQtyNet) - Convert.ToDouble(Qty);
                        //MessageBox.Show( LotQtyOut1 + "  " + LotQtyNet );

                        CallUPdateStocklot(stock, LotQtyOut1, LotQtyNet1);

                        return;
                    }

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();


        }
        #endregion


        #region "CallUPdateStockbal"
        private void CallUPdateStocklot(string stock, double LotQtyOut1, double LotQtyNet1)
        {

            var query = new StringBuilder();
            query.Append("UPDATE dbo.StockLot SET");
            query.Append(" LotQtyOut  = @LotQtyOut");
            query.Append(", LotQtyNet  = @LotQtyNet");
            query.Append(" WHERE Lotno =  @Lotno");
            query.Append(" AND LotStock =  @LotStock");
     

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@LotQtyOut", LotQtyOut1);
                    db.AddParameter("@LotQtyNet", LotQtyNet1);
                    db.AddParameter("@Lotno", CGlobal.Lotno);
                    db.AddParameter("@LotStock", stock);

                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        }

        #endregion

        #region " callstocktotal()"
        private void callstocktotal(string itemcode, string stock)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select BalQtyIn,BalQtyOut,BalQtyNet from dbo.StockBal  where BalItem ='" + itemcode + "' and  BalStock='" + stock + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.BalQtyIn = rs["BalQtyIn"].ToString();
                    CGlobal.BalQtyOut = rs["BalQtyOut"].ToString();
                    CGlobal.BalQtyNet = rs["BalQtyNet"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                //return;
            }
            conn.Close();

        
        }
        #endregion



        #region "search2bin"
        private void Call2Bin()
        {
            this.gridshow.DataSource = null;
            string tempdut = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {


                string strSQL1 = "";
                strSQL1 = " SELECT  DocUserRec,DocID, Barcode, ItemCode, TypeName, ItemName, DocQty,ItemUnit,  DocUserDate,Status,(select Typename from dbo.Leather_Type1 Where LeatherID =Remark) as Typename11"
                + " FROM   Lean_Doc2Bin where Status='Success'  and CONVERT(VARCHAR(24),DocUserDate ,103)= '" + tempdut + "' order by DocUserDate desc ";

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
        #endregion

        #region "left right,mid"
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
        #endregion

        #region " CallBarcode();"
        private void CallBarcode()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();

            string tmpstr = this.txtbarcode.Text.Trim();
            string tmplert = Left(tmpstr, 2);
            string type = "";


            string tmpstr1 = tmpstr.Length.ToString();
            if (tmpstr1 == "15")
            {
                string tmplert1 = Left(tmpstr, 5);
                type = tmplert1;
            
            }

            else if (tmpstr1 == "14")
            {

                type = "CELL";
            }
            else
            {
                type = tmplert;
            }


            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.Lean_Doc2Bin  where Barcode ='" + this.txtbarcode.Text.Trim() + "' and  TypeName='" + type + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                 CGlobal.CheckBarcode2Bin = "YES";  //ห้ามซ้ำ
                  //  CGlobal.CheckBarcode2Bin = "No";  //ซ้ำ

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
               // return;
            }
            conn.Close();


        }

        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
          try
            {
            timer1.Start();
            Call2Bin();
           // this.lbltime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
          catch (Exception ex)
          {
           //   return;
          }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.FieldName == "")

               // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStoreOut));
            this.StatusMain = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusVersionName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridshow = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView2 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cachedReportPODate1 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.txtS1 = new System.Windows.Forms.TextBox();
            this.txtS2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bntsave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cachedReportPODate2 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.cachedReportPODate3 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.cachedReportPODate4 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.cachedReportPODate5 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cachedReportPODate6 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.lbltime = new System.Windows.Forms.Label();
            this.StatusMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridshow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusMain
            // 
            this.StatusMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.StatusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusForm,
            this.ToolStripStatusLabel2,
            this.ToolStripStatusLabel3,
            this.ToolStripStatusLabel4,
            this.ToolStripStatusUserName,
            this.ToolStripStatusLabel5,
            this.ToolStripStatusLabel6,
            this.ToolStripStatusLabel7,
            this.ToolStripStatusVersionName,
            this.ToolStripStatusLabel8,
            this.ToolStripStatusLabelConnect});
            this.StatusMain.Location = new System.Drawing.Point(0, 706);
            this.StatusMain.Name = "StatusMain";
            this.StatusMain.Padding = new System.Windows.Forms.Padding(2, 0, 11, 0);
            this.StatusMain.Size = new System.Drawing.Size(999, 22);
            this.StatusMain.TabIndex = 64;
            this.StatusMain.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.ToolStripStatusLabel1.Text = "ระบบ :";
            this.ToolStripStatusLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // ToolStripStatusForm
            // 
            this.ToolStripStatusForm.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusForm.Name = "ToolStripStatusForm";
            this.ToolStripStatusForm.Size = new System.Drawing.Size(50, 17);
            this.ToolStripStatusForm.Text = "Pick List";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(79, 17);
            this.ToolStripStatusLabel2.Text = "                        ";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.ToolStripStatusLabel3.Text = "|";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(55, 17);
            this.ToolStripStatusLabel4.Text = "ผู้ใช้ระบบ :";
            // 
            // ToolStripStatusUserName
            // 
            this.ToolStripStatusUserName.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusUserName.Name = "ToolStripStatusUserName";
            this.ToolStripStatusUserName.Size = new System.Drawing.Size(27, 17);
            this.ToolStripStatusUserName.Text = "MIS";
            this.ToolStripStatusUserName.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Size = new System.Drawing.Size(67, 17);
            this.ToolStripStatusLabel5.Text = "                    ";
            // 
            // ToolStripStatusLabel6
            // 
            this.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            this.ToolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.ToolStripStatusLabel6.Text = "|";
            // 
            // ToolStripStatusLabel7
            // 
            this.ToolStripStatusLabel7.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7";
            this.ToolStripStatusLabel7.Size = new System.Drawing.Size(52, 17);
            this.ToolStripStatusLabel7.Text = "Version :";
            // 
            // ToolStripStatusVersionName
            // 
            this.ToolStripStatusVersionName.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusVersionName.Name = "ToolStripStatusVersionName";
            this.ToolStripStatusVersionName.Size = new System.Drawing.Size(22, 17);
            this.ToolStripStatusVersionName.Text = "1.0";
            // 
            // ToolStripStatusLabel8
            // 
            this.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8";
            this.ToolStripStatusLabel8.Size = new System.Drawing.Size(37, 17);
            this.ToolStripStatusLabel8.Text = "          ";
            // 
            // ToolStripStatusLabelConnect
            // 
            this.ToolStripStatusLabelConnect.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusLabelConnect.Name = "ToolStripStatusLabelConnect";
            this.ToolStripStatusLabelConnect.Size = new System.Drawing.Size(124, 17);
            this.ToolStripStatusLabelConnect.Text = "LA-Z-BOY-THAILAND";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(54, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 25);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "Store Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.txtbarcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(54, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 49);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode 2BIN ";
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtbarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtbarcode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtbarcode.Location = new System.Drawing.Point(119, 18);
            this.txtbarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(273, 22);
            this.txtbarcode.TabIndex = 68;
            this.txtbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbarcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(28, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Barcode .  :";
            // 
            // gridshow
            // 
            this.gridshow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridshow.Location = new System.Drawing.Point(0, 97);
            this.gridshow.MainView = this.gridView2;
            this.gridshow.Name = "gridshow";
            this.gridshow.Size = new System.Drawing.Size(999, 606);
            this.gridshow.TabIndex = 69;
            this.gridshow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.cardView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.gridView2.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.gridView2.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(223)))), ((int)(((byte)(220)))));
            this.gridView2.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(195)))), ((int)(((byte)(191)))));
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView2.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(247)))));
            this.gridView2.Appearance.Preview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(247)))));
            this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView2.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.gridView2.Appearance.Preview.Options.UseBackColor = true;
            this.gridView2.Appearance.Preview.Options.UseBorderColor = true;
            this.gridView2.Appearance.Preview.Options.UseFont = true;
            this.gridView2.Appearance.Preview.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseBorderColor = true;
            this.gridView2.Appearance.Row.Options.UseForeColor = true;
            this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(208)))), ((int)(((byte)(205)))));
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn15,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn18});
            this.gridView2.GridControl = this.gridshow;
            this.gridView2.GroupPanelText = "Show Detail 2BIN";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.ViewCaption = "Show Detail 2Bin";
            this.gridView2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView2_CustomColumnDisplayText);
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "No.";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "ItemCode";
            this.gridColumn1.FieldName = "ItemCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 88;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.Caption = "ItemName";
            this.gridColumn15.FieldName = "ItemName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 279;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Stock";
            this.gridColumn8.FieldName = "DocUserRec";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 67;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Type";
            this.gridColumn7.FieldName = "Typename11";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 120;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn16.Caption = "Qty";
            this.gridColumn16.FieldName = "DocQty";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 50;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "UOM";
            this.gridColumn17.FieldName = "ItemUnit";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            this.gridColumn17.Width = 77;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "To Cell";
            this.gridColumn2.FieldName = "TypeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 59;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Date";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "DocUserDate";
            this.gridColumn4.GroupFormat.FormatString = "d";
            this.gridColumn4.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            this.gridColumn4.Width = 91;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn18.Caption = "Status Receipt";
            this.gridColumn18.FieldName = "Status";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 9;
            this.gridColumn18.Width = 100;
            // 
            // cardView2
            // 
            this.cardView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.cardView2.FocusedCardTopFieldIndex = 0;
            this.cardView2.GridControl = this.gridshow;
            this.cardView2.Name = "cardView2";
            this.cardView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView2.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Line";
            this.gridColumn3.FieldName = "DocLine";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 58;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Item NO.";
            this.gridColumn5.FieldName = "DocItem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 141;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "Description";
            this.gridColumn11.FieldName = "ItemName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 140;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn12.Caption = "Quantity";
            this.gridColumn12.FieldName = "DocQty";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 106;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn13.AppearanceHeader.Options.UseFont = true;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "Location";
            this.gridColumn13.FieldName = "DocStock";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 71;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "Status";
            this.gridColumn14.FieldName = "DocFlag";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            this.gridColumn14.Width = 50;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 280000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtS1
            // 
            this.txtS1.BackColor = System.Drawing.Color.White;
            this.txtS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtS1.Enabled = false;
            this.txtS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtS1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtS1.Location = new System.Drawing.Point(535, 55);
            this.txtS1.Margin = new System.Windows.Forms.Padding(4);
            this.txtS1.MaxLength = 2;
            this.txtS1.Name = "txtS1";
            this.txtS1.Size = new System.Drawing.Size(60, 22);
            this.txtS1.TabIndex = 69;
            // 
            // txtS2
            // 
            this.txtS2.BackColor = System.Drawing.Color.White;
            this.txtS2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtS2.Enabled = false;
            this.txtS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtS2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtS2.Location = new System.Drawing.Point(619, 55);
            this.txtS2.Margin = new System.Windows.Forms.Padding(4);
            this.txtS2.MaxLength = 2;
            this.txtS2.Name = "txtS2";
            this.txtS2.Size = new System.Drawing.Size(60, 22);
            this.txtS2.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(462, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "Stock :";
            // 
            // bntsave
            // 
            this.bntsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bntsave.Location = new System.Drawing.Point(766, 52);
            this.bntsave.Name = "bntsave";
            this.bntsave.Size = new System.Drawing.Size(75, 27);
            this.bntsave.TabIndex = 71;
            this.bntsave.Text = "Update";
            this.bntsave.UseVisualStyleBackColor = true;
            this.bntsave.Click += new System.EventHandler(this.bntsave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(514, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 72;
            this.label3.Text = "1.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(597, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "2.";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(685, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 74;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(100, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 75;
            this.label5.Text = "V.26032015";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltime.ForeColor = System.Drawing.Color.Red;
            this.lbltime.Location = new System.Drawing.Point(191, 7);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(60, 24);
            this.lbltime.TabIndex = 67;
            this.lbltime.Text = "label1";
            // 
            // FrmStoreOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 728);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bntsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtS2);
            this.Controls.Add(this.txtS1);
            this.Controls.Add(this.gridshow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.StatusMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStoreOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store  Center";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStoreOut_Load);
            this.StatusMain.ResumeLayout(false);
            this.StatusMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridshow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void bntsave_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้อง Update คลัง นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("UPDATE dbo.A_Stock SET");
                query.Append(" Store1  = @Store1");
                query.Append(", Store2  = @Store2");



                using (var db = new DbHelper1())
                {
                    try
                    {
                        db.AddParameter("@Store1", this.txtS1.Text.Trim());
                        db.AddParameter("@Store2", this.txtS2.Text.Trim());


                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error" + ex);
                    }
                }
                MessageBox.Show("complete");
                txtS1.Enabled = false;
                txtS2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtS1.Enabled = true;
            txtS2.Enabled = true;
        }
    
    
    }
}
