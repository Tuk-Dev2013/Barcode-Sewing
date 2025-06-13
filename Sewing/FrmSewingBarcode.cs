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
using System.Configuration;


namespace PicklistBOM.Sewing
{
    public partial class FrmSewingBarcode : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmSewingBarcode()
        {
            InitializeComponent();
        }

        private void scToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSewnAdmin page = new FrmSewnAdmin();
            page.Show();
            this.Hide();
        }

        private void totalTargetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            FrmSewTarget page = new FrmSewTarget();
            page.ShowDialog();
        }

        private void barcodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSewingBarcode page = new FrmSewingBarcode();
            page.Show();
            this.Hide();
        }

        private void FrmSewingBarcode_Load(object sender, EventArgs e)
        {
            CGlobal.Frmcount = "1";
            CGlobal.UserID = "00000";
            CGlobal.Username = "Admin";
            CGlobal.EmpPost = "System";

            //date
               string resultdate;

                DateTime now0027 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                TimeSpan start0027 = new TimeSpan(0, 0, 0); // 00:00
                TimeSpan end0027 = new TimeSpan(7, 59, 0);   // 07:59
                TimeSpan currentTime0027 = now0027.TimeOfDay;
                if (currentTime0027 >= start0027 && currentTime0027 <= end0027)
                {
                    resultdate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
               
                lbldate.Text = "Date : " +resultdate;

    
            ToolStripStatusForm.Text = "Barcode Sewing Cell";
            ToolStripStatusVersionName.Text = "Vession-31/03/2025";
            ToolStripStatusUserName.Text = ConfigurationManager.AppSettings["SHOW_CELL1"]+','+ConfigurationManager.AppSettings["SHOW_CELL2"];

            //cell 1
            lblcell1.Text = ConfigurationManager.AppSettings["SHOW_CELL1"];
            if (lblcell1.Text.Trim() == "Sewing 3")
            {
                lblcell1.Text = "Cell Sewing 9";
            }
            else if (lblcell1.Text.Trim() == "Sewing 1")
            {
                lblcell1.Text = "Cell Sewing 13";
            }
            else if (lblcell1.Text.Trim() == "Cell Sewing 14")
            {
                lblcell1.Text = "Cell Sewing 14";
            }
            else if (lblcell1.Text.Trim() == "Sewing 2")
            {
                lblcell1.Text = "Cell Sewing 15";
            }
            else if (lblcell1.Text.Trim() == "Cell Sewing 16")
            {
                lblcell1.Text = "Cell Sewing 16";
            }
            else if (lblcell1.Text.Trim() == "Cell Sewing 17")
            {
                lblcell1.Text = "Cell Sewing 17";
            }


            CallSearchPO();
            showBarcode(CGlobal.Sew_DocNo);
            //string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            //CallSearch(tmpdate);


            //cell 2
            lblcellnew.Text = ConfigurationManager.AppSettings["SHOW_CELL2"];
            if (lblcellnew.Text.Trim() == "Sewing 3")
            {
                lblcellnew.Text = "Cell Sewing 9";
            }
            else if (lblcellnew.Text.Trim() == "Sewing 1")
            {
                lblcellnew.Text = "CELL(R-SOFA)13";
            }
            else if (lblcellnew.Text.Trim() == "Cell Sewing 14")
            {
                lblcellnew.Text = "CELL(R-SOFA)14";
            }
            else if (lblcellnew.Text.Trim() == "Sewing 2")
            {
                lblcellnew.Text = "CELL(SOFA)15";
            }
            else if (lblcellnew.Text.Trim() == "Cell Sewing 16")
            {
                lblcellnew.Text = "CELL(SOFA)16";
            }
            else if (lblcellnew.Text.Trim() == "Cell Sewing 17")
            {
                lblcellnew.Text = "CELL(SOFA)17";
            }
            CallSearchPO1();
            showBarcode2(CGlobal.Sew_DocNo2);

            txtbarcode.Focus();
        }

        //#region "CallSearch()"
        //private void CallSearch(string tmpdate)
        //{
        //    System.Data.SqlClient.SqlCommand Cmd;
        //    System.Data.SqlClient.SqlDataReader rs;
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //    //conn.Open();
        //    try
        //    {
        //        string tmpname = ConfigurationManager.AppSettings["SHOW_CELL1"];
        //        CGlobal.IssueNumber2 = "1";
        //        Cmd = new System.Data.SqlClient.SqlCommand(" SELECT SewID,Sdate, Mantotal, Unitperhead, target, Issuedate, UserID, Target8hr, Target3hr, Total11hr FROM  Sewing_TargetDay Where Sdate='" + tmpdate + "' and Cellname='" + tmpname + "'", conn);
        //        conn.Open();
        //        rs = Cmd.ExecuteReader();
        //        while (rs.Read())
        //        {
        //            lblperson.Text = rs["Mantotal"].ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        CGlobal.IssueNumber2 = "1";
        //    }
        //    conn.Close();

        //}
        //#endregion

        #region "CallSeart()"
        private void CallSeart(string tmpdata)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand("  select SUM(Qty) as totalsum from dbo.Sewing_DtlBarcode where TypeCell='" + tmpcell + "'and docno='" + CGlobal.DayweekPO + "'and remark='" + tmpdata + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    if (tmpdata == "BODY")
                    {
                        double num = Convert.ToDouble(rs["totalsum"].ToString());
                        lblbody.Text = num.ToString("#,###0");
                    }
                    else if (tmpdata == "BACK")
                    {
                        double num = Convert.ToDouble(rs["totalsum"].ToString());
                        lblback.Text = num.ToString("#,###0");
                    }
                    else if (tmpdata == "SEAT")
                    {
                        double num = Convert.ToDouble(rs["totalsum"].ToString());
                        lblseat.Text = num.ToString("#,###0");
                    }
                }

            }
            catch (Exception ex)
            {

            }
            conn.Close();
        }
        #endregion

        //Cell 1//
        #region "CallSearchPO()"
        private void CallSearchPO()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
               // lblcell1.Text = ConfigurationManager.AppSettings["SHOW_CELL1"];
               

                string strSQL1 = "";
                strSQL1 = " select TOP(2)Sequence,Startday,Docno,Qtyin,QtyOut,remark,QtyBack, QtySeat, QtyBody,tmpCk from dbo.Sewing_Schedule  where  Qtyin<>Qtyout "
                + " and Cellname='" + ConfigurationManager.AppSettings["SHOW_CELL1"] + "'   order by Sequence ";

                if (Isfind1 == true)
                {
                    ds.Tables["ShowPO"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowPO");

                if (ds.Tables["ShowPO"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["ShowPO"];
                    string tmpck = "";
                    for (int i = 0; i < ds.Tables["ShowPO"].Rows.Count; i++)
                    {
                        tmpck = "";
                        tmpck = ds.Tables["ShowPO"].Rows[i]["tmpCk"].ToString();

                        if (i==0)
                        {
                            if (tmpck=="-")
                            {
                                lblPO.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString();
                            }
                            else
                            {
                                lblPO.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")"; 
                            }
                            lblQty.Text = ds.Tables["ShowPO"].Rows[i]["Qtyin"].ToString();
                            CGlobal.Sew_QtyBalbom = ds.Tables["ShowPO"].Rows[i]["Qtyin"].ToString();
                            CGlobal.Sew_DocNoRef = ds.Tables["ShowPO"].Rows[i]["remark"].ToString();
                            CGlobal.DayweekPO = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString();
                            CGlobal.Sew_DocNo = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString();
                            lblout.Text = ds.Tables["ShowPO"].Rows[i]["QtyOut"].ToString();
                            lblback.Text = ds.Tables["ShowPO"].Rows[i]["QtyBack"].ToString();
                            lblbody.Text = ds.Tables["ShowPO"].Rows[i]["QtyBody"].ToString();
                            lblseat.Text = ds.Tables["ShowPO"].Rows[i]["QtySeat"].ToString();
                        }
                        else if (i==1)
                        {
                            if (tmpck == "-")
                            {
                                this.txtq2.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString(); 
                            }
                            else
                            {
                                this.txtq2.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")"; 
                            }
                        }
                        //else if (i == 2)
                        //{
                        //    if (tmpck == "-")
                        //    {
                        //        this.txtq3.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString(); 
                        //    }
                        //    else
                        //    {
                        //        this.txtq3.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")"; 
                        //    }
                           
                        //}
                        //else if (i == 3)
                        //{
                        //    if (tmpck == "-")
                        //    {
                        //        this.txtq4.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString(); 
                        //    }
                        //    else
                        //    {
                        //        this.txtq4.Text = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")"; 
                        //    }
                       
                        //}
                    }

                }
                else
                {
                    Isfind1 = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search DocMODtl");
            }
            conn.Close();

        }
        #endregion

        //Cell 2//
        #region "CallSearchPO1()"
        private void CallSearchPO1()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                //lblcellnew.Text = ConfigurationManager.AppSettings["SHOW_CELL2"];


                string strSQL1 = "";
                strSQL1 = " select TOP(2)Sequence,Startday,Docno,Qtyin,QtyOut,remark,QtyBack, QtySeat, QtyBody,tmpCk from dbo.Sewing_Schedule  where  Qtyin<>Qtyout "
                + " and Cellname='" + ConfigurationManager.AppSettings["SHOW_CELL2"] + "'   order by Sequence ";

                if (Isfind2 == true)
                {
                    ds.Tables["ShowPO2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowPO2");

                if (ds.Tables["ShowPO"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["ShowPO2"];
                    string tmpck = "";
                    for (int i = 0; i < ds.Tables["ShowPO2"].Rows.Count; i++)
                    {
                        tmpck = "";
                        tmpck = ds.Tables["ShowPO2"].Rows[i]["tmpCk"].ToString();

                        if (i == 0)
                        {
                            if (tmpck == "-")
                            {
                                lblPO2.Text = ds.Tables["ShowPO2"].Rows[i]["Docno"].ToString();
                            }
                            else
                            {
                                lblPO2.Text = ds.Tables["ShowPO2"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")";
                            }
                            lblQty2.Text = ds.Tables["ShowPO2"].Rows[i]["Qtyin"].ToString();
                           // CGlobal.Sew_QtyBalbom = ds.Tables["ShowPO2"].Rows[i]["Qtyin"].ToString();
                           // CGlobal.Sew_DocNoRef = ds.Tables["ShowPO2"].Rows[i]["remark"].ToString();
                           // CGlobal.DayweekPO = ds.Tables["ShowPO2"].Rows[i]["Docno"].ToString();
                           CGlobal.Sew_DocNo2 = ds.Tables["ShowPO"].Rows[i]["Docno"].ToString();
                            lblout2.Text = ds.Tables["ShowPO2"].Rows[i]["QtyOut"].ToString();
                            lblback2.Text = ds.Tables["ShowPO2"].Rows[i]["QtyBack"].ToString();
                            lblbody2.Text = ds.Tables["ShowPO2"].Rows[i]["QtyBody"].ToString();
                            lblseat2.Text = ds.Tables["ShowPO2"].Rows[i]["QtySeat"].ToString();
                        }
                        else if (i == 1)
                        {
                            if (tmpck == "-")
                            {
                                this.txtq22.Text = ds.Tables["ShowPO2"].Rows[i]["Docno"].ToString();
                            }
                            else
                            {
                                this.txtq22.Text = ds.Tables["ShowPO2"].Rows[i]["Docno"].ToString() + "(" + tmpck + ")";
                            }
                        }
                      
                    }

                }
                else
                {
                    Isfind2 = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search DocMODtl");
            }
            conn.Close();

        }
        #endregion

        #region "Mid, Right,Left'

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

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }

        #endregion

        #region "CallBarcode()"
        private void CallBarcode()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                CGlobal.Sew_DocNo = "";
                String strbarcod = Mid(txtbarcode.Text.Trim(), 0, 14);
                Cmd = new System.Data.SqlClient.SqlCommand(" Select left(Itemcode,5)+'%'+substring(Itemcode,7,11)+'%' as Rsofa,Left(Itemcode,17) as itemnew,DocPoNo,DocNo,DeptCode,QtyBom,QtyOut,QtyBal,QtyUse,Qtywip,itemflag,Barcode,DocPoNo,SUBSTRING(ItemCode,3,19) as item,right(itemcode,4) as remark,left(ItemCode,16) as model   from dbo.DocMODtl  where  Barcode ='" + strbarcod + "' and deptcode='W2'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.Sew_Barcode = rs["Barcode"].ToString();
                    CGlobal.Sew_DocNo = rs["DocNo"].ToString();
                    CGlobal.Sew_DeptCode = rs["DeptCode"].ToString();
                    CGlobal.Sew_QtyBom = rs["QtyBom"].ToString();
                    CGlobal.Sew_QtyOut = rs["QtyOut"].ToString();
                    CGlobal.Sew_QtyBal = rs["QtyBal"].ToString();
                    CGlobal.Sew_Qtywip = rs["Qtywip"].ToString();
                    CGlobal.Sew_itemModel = rs["item"].ToString();
                    CGlobal.Sew_remark = rs["remark"].ToString();
                    CGlobal.Sew_Qtymodel= rs["model"].ToString();
                    CGlobal.DayDocPoNo = rs["DocNo"].ToString();
                    CGlobal.Sew_itemModelNew = rs["itemnew"].ToString();
                    CGlobal.Sew_itemModelNewSofa = rs["Rsofa"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_DtlBarcode");
            }
            conn.Close();
        
        }
        #endregion

        #region "UpdateSewing_Schedule"
        private void UpdateSewing_Schedule()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtl SET");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(", QtyBal  = @QtyBal");
            query.Append(", QtyWip  = @QtyWip");
            query.Append(", ItemFlag  = @ItemType");
            query.Append(" WHERE Docno =  @Docno"); //DocPoNo =  @Docno
            query.Append(" and Itemcode like  @Itemcode");
            query.Append(" and deptcode='W2'");
            query.Append(" and Barcode=@Barcode");

            using (var db = new DbHelper1())
            {
                try
                {

                    double Qtyout = Convert.ToDouble(CGlobal.Sew_QtyOut) + 1;
                    double QtyBal = Convert.ToDouble(CGlobal.Sew_QtyBal) + 1;
                    double QtyWip = Convert.ToDouble(CGlobal.Sew_Qtywip) + 1;
                  
                    string tmpdocno = Left(CGlobal.Sew_DocNo, 6);
                    if (tmpdocno == "R-SOFA")
                    { //R-sofa
                        db.AddParameter("@QtyOut", Qtyout);
                        db.AddParameter("@QtyBal", QtyBal);
                        db.AddParameter("@QtyWip", QtyWip);
                        db.AddParameter("@ItemType", "3");
                        db.AddParameter("@Docno", CGlobal.Sew_DocNo);
                        db.AddParameter("@Itemcode", CGlobal.Sew_itemModelNewSofa);
                        db.AddParameter("@Barcode", CGlobal.Sew_Barcode.Trim());
                    }
                    else
                    {  //sofa chair
                        db.AddParameter("@QtyOut", Qtyout);
                        db.AddParameter("@QtyBal", QtyBal);
                        db.AddParameter("@QtyWip", QtyWip);
                        db.AddParameter("@ItemType", "3");
                        db.AddParameter("@Docno", CGlobal.Sew_DocNo);
                        db.AddParameter("@Itemcode", CGlobal.Sew_itemModelNew + "%");
                        db.AddParameter("@Barcode", CGlobal.Sew_Barcode.Trim());
                    
                    }

                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }

        }
        #endregion

        #region "InsertSewingBarcode()"
        private void InsertSewingBarcode(string numk ,string tmpNew)
        {
            //insert
            var query = new StringBuilder();
           // query.Append("INSERT INTO Sewing_DtlBarcode(DocNo, DeptCode, Qty, Barcode, DocPONo, Sdate, Linenumber, TypeCell, Itemmodel, Barcodedate, SdateSewing, Remark, UserID, POCell)");
            query.Append("INSERT INTO Sewing_DtlBarcode(DocNo, DeptCode, Qty, Barcode, DocPONo, Linenumber, TypeCell, Itemmodel, Sdate, Barcodedate, SdateSewing, Remark, UserID, POCell)");
            query.Append(" VALUES (@DocNo, @DeptCode, @Qty, @Barcode, @DocPONo, @Linenumber, @TypeCell, @Itemmodel, @Sdate, @Barcodedate, @SdateSewing, @Remark, @UserID, @POCell)");

            SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn1.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    //กะกลางวัน และ กลางคืน

                DateTime now0028 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                TimeSpan start0028 = new TimeSpan(0, 0, 0); // 00:00
                TimeSpan end0028 = new TimeSpan(7, 59, 0);   // 07:59
                TimeSpan currentTime0028 = now0028.TimeOfDay;
             

                    string resultdate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US")) + " 23:59:00.000";
                    string resultdate1 = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                    string resultdate2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                  //  string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                   // string resultdate1 = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    db.AddParameter("@DocNo", CGlobal.Sew_DocNo);
                    db.AddParameter("@DeptCode", CGlobal.Sew_DeptCode);
                    db.AddParameter("@Qty", Convert.ToDouble(numk));
                    db.AddParameter("@Barcode", CGlobal.Sew_Barcode);
                    db.AddParameter("@DocPONo", CGlobal.Sew_DocNoRef);
                   // db.AddParameter("@Sdate", resultdate);
                    db.AddParameter("@Linenumber", CGlobal.FrmcountLine);
                    db.AddParameter("@TypeCell", CGlobal.Sew_CellckName.Trim());
                    db.AddParameter("@Itemmodel", CGlobal.Sew_itemModelNew + tmpNew);

                    if (currentTime0028 >= start0028 && currentTime0028 <= end0028)
                    {
                        db.AddParameter("@Sdate", resultdate2);
                        db.AddParameter("@Barcodedate", resultdate);
                        db.AddParameter("@SdateSewing", DateTime.Now);
                    }
                    else
                    {
                        db.AddParameter("@Sdate", resultdate1);
                        db.AddParameter("@Barcodedate", DateTime.Now);
                        db.AddParameter("@SdateSewing", DateTime.Now);
                    }


                  //  db.AddParameter("@Barcodedate", DateTime.Now);
                    db.AddParameter("@Remark", tmpNew);
                    db.AddParameter("@UserID", CGlobal.UserID);
                    db.AddParameter("@POCell", CGlobal.DayDocPoNo);

                    db.ExecuteNonQuery(query.ToString());
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("No Save Sewing_DtlBarcode" + tmpNew);

                }
               // n = n + 1;
            }
            conn1.Close();
            conn1.Dispose();
        }

        #endregion

        #region " Show Cell 1"
        private void showBarcode(string docno)
        {
            string resultdate;
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                DateTime now0029 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                TimeSpan start0029 = new TimeSpan(0, 0, 0); // 00:00
                TimeSpan end0029 = new TimeSpan(07, 59, 0);   // 07:59
                TimeSpan currentTime0029 = now0029.TimeOfDay;


                if (currentTime0029 >= start0029 && currentTime0029 <= end0029)
                {
                    //กะกลางคืน
                    resultdate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }

                string strSQL1 = "";
                strSQL1 = " SELECT  'Delete' as View1,REPLACE(REPLACE(itemmodel,'BACK',''),'W2','') as model1,*  from dbo.Sewing_DtlBarcode "
                + " WHERE Sdate ='" + resultdate + "'    and TypeCell ='" + ConfigurationManager.AppSettings["SHOW_CELL1"] + "' and Remark='BACK' order by barcodedate desc";

                if (Isfind == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata2"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                    //MessageBox.Show("No Data DocMODtlBarcode");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data1");
            }
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region " Show Cell 2"
        private void showBarcode2(string docno)
        {



            string resultdate;
            DateTime now0030 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start0030 = new TimeSpan(0, 0, 0); // 00:00
            TimeSpan end0030 = new TimeSpan(07, 59, 0);   // 07:59
            TimeSpan currentTime0030 = now0030.TimeOfDay;

            this.gridshow2.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
                if (currentTime0030 >= start0030 && currentTime0030 <= end0030)
                {
                    resultdate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }

                string strSQL1 = "";
                strSQL1 = " SELECT  'Delete' as View1,REPLACE(REPLACE(itemmodel,'BACK',''),'W2','') as model1,*  from dbo.Sewing_DtlBarcode "
                + " WHERE Sdate ='" + resultdate + "'    and TypeCell ='" + ConfigurationManager.AppSettings["SHOW_CELL2"] + "' and Remark='BACK' order by barcodedate desc";

                if (Isfind3 == true)
                {
                    ds.Tables["ShowdataCell2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataCell2");

                if (ds.Tables["ShowdataCell2"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["ShowdataCell2"];
                    gridshow2.DataSource = dt;
                }
                else
                {
                    Isfind3 = false;
                    this.gridshow2.DataSource = null;
                    //MessageBox.Show("No Data DocMODtlBarcode");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No gridshow2");
            }
            conn.Close();

        }
        #endregion

        #region "UpdateSewing_Schedule"
        private void UpdateSewing_Schedule(string docno, string Remark, string model, string numk)
        {

            var query = new StringBuilder();

            if (Left(docno, 6) == "CUTSEW")
            {

            }

            string tmpcell = CGlobal.Sew_CellckName.Trim();
            query.Append(" Update dbo.Sewing_Schedule SET  ");
            query.Append(" QtyOut=(select count(DocNo) from dbo.Sewing_DtlBarcode where  docno='" + docno.Trim() + "' and Typecell='"+CGlobal.Sew_CellckName.Trim()+"' and Remark='BACK') ");
            query.Append(" ,QtyBack=(select count(DocNo) from dbo.Sewing_DtlBarcode where  docno='" + docno.Trim() + "' and Typecell='" + CGlobal.Sew_CellckName.Trim() + "' and Remark='BACK') ");
            query.Append(" ,QtySeat=(select count(DocNo) from dbo.Sewing_DtlBarcode where  docno='" + docno.Trim() + "' and  Typecell='" + CGlobal.Sew_CellckName.Trim() + "' and Remark='SEAT') ");
            query.Append(" ,QtyBody=(select count(DocNo) from dbo.Sewing_DtlBarcode where  docno='" + docno.Trim() + "' and  Typecell='" + CGlobal.Sew_CellckName.Trim() + "' and Remark='BODY')");
            query.Append(" where Docno=@Docno");
            query.Append(" and Cellname=@Cellname");
            using (var db = new DbHelper1())
            {
                try
                {

                    db.AddParameter("@Docno", docno);
                    db.AddParameter("@CellName", CGlobal.Sew_CellckName.Trim());
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
            //double numBack = 0;
            //double numBody = 0;
            //double numSeat = 0;
            //double numqty = 0;
            //string tmp = "";
            //string name = CGlobal.Sew_CellckName.Trim();
            //numBack = Convert.ToDouble(lblback.Text.Trim()) + Convert.ToDouble(numk);
            //numBody = Convert.ToDouble(lblbody.Text.Trim()) + Convert.ToDouble(numk);
            //numSeat = Convert.ToDouble(lblseat.Text.Trim()) + Convert.ToDouble(numk);
            //numqty = Convert.ToDouble(this.lblout.Text.Trim()) + 1;
         
            //var query = new StringBuilder();
            //query.Append("UPDATE dbo.Sewing_Schedule SET  ");
            //query.Append("QtyBACK  = @QtyBACK");
            //query.Append(",QtyBODY  = @QtyBODY");
            //query.Append(",QtySEAT = @QtySEAT");
            //query.Append(",QtyOut = @QtyOut");
            //query.Append(" WHERE Docno =  @Docno");
            //query.Append(" and cellname =  @cellname");
            //using (var db = new DbHelper1())
            //{
            //    try
            //    {
            //        db.AddParameter("@QtyBACK", numBack);
            //        db.AddParameter("@QtyBODY", numBody);
            //        db.AddParameter("@QtySEAT", numSeat);
            //        db.AddParameter("@QtyOut", numqty);
            //        db.AddParameter("@Docno", docno);
            //        db.AddParameter("@cellname", name);
            //        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
            //    }
            //    catch (Exception ex)
            //    {
            //        // MessageBox.Show("Error" + ex);
            //    }

            //}
        
        }
        #endregion

        #region "CallBarcodePO"
        private void CallBarcodePO()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {

                string tmpname1 = ConfigurationManager.AppSettings["SHOW_CELL1"];
                string tmpname2 = ConfigurationManager.AppSettings["SHOW_CELL2"];
                CGlobal.IssueNumber2 = "1";
                Cmd = new System.Data.SqlClient.SqlCommand("select Sequence,Startday,Docno,Qtyin,QtyOut,remark,QtyBack, QtySeat, QtyBody,tmpCk,Cellname  from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and  Docno='" + CGlobal.Sew_DocNo + "' and Cellname in ('" + tmpname1 + "','" + tmpname2 + "')", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string cellnae = rs["Cellname"].ToString();
                    CGlobal.Sew_CellckName = cellnae;
                    if (cellnae.Trim() == tmpname1.Trim())
                    {
                     
                        string tmpck = rs["tmpCk"].ToString();
                        if (tmpck == "-")
                        {
                            lblPO.Text = rs["Docno"].ToString();
                        }
                        else
                        {
                            lblPO.Text = rs["Docno"].ToString() + "(" + rs["tmpCk"].ToString() + ")";
                        }


                        lblQty.Text = rs["Qtyin"].ToString();
                        CGlobal.Sew_QtyBalbom = rs["Qtyin"].ToString();
                        CGlobal.Sew_DocNoRef = rs["remark"].ToString();
                        CGlobal.DayweekPO = rs["Docno"].ToString();
                        CGlobal.Sew_DocNo = rs["Docno"].ToString();
                        lblout.Text = rs["QtyOut"].ToString();
                        lblback.Text = rs["QtyBack"].ToString();
                        lblbody.Text = rs["QtyBody"].ToString();
                        lblseat.Text = rs["QtySeat"].ToString();
                        CGlobal.Sew_CellckName = cellnae.Trim();
                        CGlobal.Sdate_Schedule = rs["Startday"].ToString();
                    }
                    else if  (cellnae.Trim() == tmpname2.Trim())
                    {
                        string tmpck = rs["tmpCk"].ToString();
                        if (tmpck == "-")
                        {
                            lblPO2.Text = rs["Docno"].ToString();
                        }
                        else
                        {
                            lblPO2.Text = rs["Docno"].ToString() + "(" + rs["tmpCk"].ToString() + ")";
                        }
                        lblQty2.Text = rs["Qtyin"].ToString();
                        CGlobal.Sew_QtyBalbom = rs["Qtyin"].ToString();
                        CGlobal.Sew_DocNoRef = rs["remark"].ToString();
                        CGlobal.DayweekPO = rs["Docno"].ToString();
                        CGlobal.Sew_DocNo = rs["Docno"].ToString();
                        lblout2.Text = rs["QtyOut"].ToString();
                        lblback2.Text = rs["QtyBack"].ToString();
                        lblbody2.Text = rs["QtyBody"].ToString();
                        lblseat2.Text = rs["QtySeat"].ToString();
                        CGlobal.Sew_CellckName = cellnae.Trim();
                        CGlobal.Sdate_Schedule = rs["Startday"].ToString();
                    
                    }

                }
                   
                       
         

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_Schedule");
            }
            conn.Close();
            conn.Dispose();
        }
        #endregion

        #region "CallNumberLine()
        private void CallNumberLine1(String Line)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                CGlobal.FrmcountLine = "1";
                Cmd = new System.Data.SqlClient.SqlCommand("select Isnull((Max(Isnull(linenumber,0))+1),1)  as Lnumber from dbo.Sewing_DtlBarcode where barcode='" + Line + "' and remark='BACK'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.FrmcountLine = rs["Lnumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Line Number");
            }
            conn.Close();
            conn.Dispose();
        
        }
        #endregion
        #region "CallMan_OT"

              
        private void CallMan_OT()
        {
            System.Data.SqlClient.SqlCommand Cmd2;
            System.Data.SqlClient.SqlDataReader rs2;
            SqlConnection conn2 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                string sdateFormatted;
                DateTime now0026 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                TimeSpan start0026 = new TimeSpan(0, 0, 0); // 00:00
                TimeSpan end0026 = new TimeSpan(7, 59, 0);   // 07:59
                TimeSpan currentTime0026 = now0026.TimeOfDay;
                if (currentTime0026 >= start0026 && currentTime0026 <= end0026)
                {
                    sdateFormatted = now0026.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    sdateFormatted = now0026.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }

               


                //MessageBox.Show(sdateFormatted + CGlobal.Sew_CellckName);

                Cmd2 = new System.Data.SqlClient.SqlCommand(" Select ISNULL(Man_NT_OT,0) as Man_NT_OT ,ISNULL(Man_Night_OT,0)As Man_Night_OT ,ISNULL(Sdate,0) as Sdate   from dbo.Sewing_TargetDay where  CellName  ='" + CGlobal.Sew_CellckName + "' and Sdate ='" + sdateFormatted + "'", conn2);
                conn2.Open();
                rs2 = Cmd2.ExecuteReader();
                while (rs2.Read())
                {
                    CGlobal.Man_NT_OT = rs2["Man_NT_OT"].ToString();
                    CGlobal.Man_Night_OT = rs2["Man_Night_OT"].ToString();
                    CGlobal.Date_Sdate = rs2["Sdate"].ToString();
                    
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_DtlBarcode"+ex.ToString());
            }
            conn2.Close();

        }
        #endregion
        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtbarcode.Text == "")
                {
                  //  MessageBox.Show("กรุณายิง Barcode ก่อนค่ะ ");
                    return;
                }
                
                  CallBarcode();
                  String strbarcod = Mid(txtbarcode.Text.Trim(), 0, 14);
                  CallBarcodePO();
                  CallMan_OT();

                  DateTime now = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                  TimeSpan start = new TimeSpan(17, 30, 0); // 17:30
                  TimeSpan end = new TimeSpan(20, 30, 0);   // 20:30
                  TimeSpan currentTime = now.TimeOfDay;
                      //เช็ค OT กะเช้า
                      if (currentTime >= start && currentTime <= end)
                      {
                          //MessageBox.Show("กะเช้า " + CGlobal.Man_NT_OT);
                          if (CGlobal.Man_NT_OT == "0")
                          {
                             
                              MassgeBox Massge = new MassgeBox();
                              Massge.ShowDialog();

                              FrmSewTarget page = new FrmSewTarget();
                              page.ShowDialog();
                              txtbarcode.Clear();
                              return;
                          }
                           //return;
                      }

                      DateTime now_02 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                      TimeSpan start_02 = new TimeSpan(5, 30, 0); // 05:30
                      TimeSpan end_02 = new TimeSpan(8, 0, 0);   // 08:00
                      TimeSpan currentTime_02 = now_02.TimeOfDay;
                      //เช็ค OT กะดึก

                      if (currentTime_02 >= start_02 && currentTime_02 <= end_02)
                        {
                            //MessageBox.Show("กะกลางคืน " + CGlobal.Man_Night_OT);
                            if (CGlobal.Man_Night_OT == "0")
                            {
                                MassgeBox Massge = new MassgeBox();
                                Massge.ShowDialog();

                                FrmSewTarget page = new FrmSewTarget();
                                page.ShowDialog();
                                txtbarcode.Clear();
                                return;
                            }
                            //return;
                          }
                  
                ///// Start
                 
                //05092018
                  if (CGlobal.DayweekPO != CGlobal.Sew_DocNo)
                  {
                      MessageBox.Show("คุณยิง barcode ไม่ตรงกับ Schedue ที่จัดไว้แล้ว กรณุา key Schedue PO#");
                      this.txtbarcode.Text = "";
                      CGlobal.Sew_DocNo = "";
                      return;
                  }

                if  ((CGlobal.Sew_remark == "SEAT")||(CGlobal.Sew_remark == "BODY"))
                {
                    MessageBox.Show("คุณยิง barcode ไม่ถูกต้อง ยิงเฉพาะ Barcode Back เท่านั้น กรุณายิงใหม่");
                    this.txtbarcode.Text = "";
                    CGlobal.Sew_DocNo = "";
                    return;
                }

                  if (CGlobal.Sew_Barcode == strbarcod)
                  {
                      if (Convert.ToDouble(CGlobal.Sew_Qtywip) >= Convert.ToDouble(CGlobal.Sew_QtyBom))
                      {
                          MessageBox.Show("คุณยิง barcode Model : "+ CGlobal.Sew_itemModelNew + " จบแล้ว กรุณาตรวจสอบด้วย");
                          txtbarcode.Text = "";
                          return;
                      }
                      else
                      {

                          string tempmodel = Left(CGlobal.Sew_itemModel, 3);
                          string numk = "1";

                          if ((CGlobal.Sew_remark == "BACK") || (CGlobal.Sew_remark == "SEAT")||(CGlobal.Sew_remark == "BODY"))
                          {
                              if ((tempmodel == "63T") || (tempmodel == "64T") || (tempmodel == "82T") || (tempmodel == "T51") || (tempmodel == "T52"))
                              {
                                  numk = "2";
                              }
                              if ((tempmodel == "61T") || (tempmodel == "T32") || (tempmodel == "P32") || (tempmodel == "64P"))
                              {
                                  numk = "2";
                              }
                              if ((tempmodel == "80T") || (tempmodel == "T55") || (tempmodel == "T30") || (tempmodel == "P30") || (tempmodel == "T35") || (tempmodel == "P50") || (tempmodel == "P35") || (tempmodel == "T39") || (tempmodel == "P39") || (tempmodel == "T33") || (tempmodel == "P33"))
                              {
                                  numk = "3";
                              }
                          }
                          else
                          {
                              numk = "1";
                          }


                          CallNumberLine1(strbarcod);
                          InsertSewingBarcode(numk, "BACK"); //เพิ่มเติม
                          InsertSewingBarcode(numk, "BODY"); //เพิ่มเติม
                          InsertSewingBarcode(numk, "SEAT"); //เพิ่มเติม

                          UpdateSewing_Schedule(); //เพิ่มเติม DocMODtl


                          UpdateSewing_Schedule(CGlobal.Sew_DocNo, CGlobal.Sew_remark, CGlobal.Sew_itemModel, numk);//เพิ่มเติม

                          //update target output

                          DateTime now0025 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                          TimeSpan start0025= new TimeSpan(0, 0, 0); // 00:00
                          TimeSpan end0025 = new TimeSpan(7, 59, 0);   // 20:30
                          TimeSpan currentTime0025 = now0025.TimeOfDay;

                          string tmpdate;

                          if (currentTime0025 >= start0025 && currentTime0025 <= end0025)
                          {
                              tmpdate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                          }
                          else 
                          {
                              tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                          }

                          UpdateOutput(tmpdate);


                          // เพิ่มเติม  16022017
                          // showBarcodeview(CGlobal.Sew_DocNo);
                          CGlobal.CheckOn = "Yes";

                          //
                          string tmpname1 = ConfigurationManager.AppSettings["SHOW_CELL1"];
                          string tmpname2 = ConfigurationManager.AppSettings["SHOW_CELL2"];

                          if (CGlobal.Sew_CellckName.Trim() == tmpname1.Trim())
                          {
                              CallSearchPO();
                              showBarcode(CGlobal.Sew_DocNo);
                          }
                          else if (CGlobal.Sew_CellckName.Trim() == tmpname2.Trim())
                          {
                              CallSearchPO1();
                              showBarcode2(CGlobal.Sew_DocNo);
                          }

                          CallBarcode();
                          txtbarcode.Text = "";
                          txtbarcode.Focus();
                          CGlobal.Sew_itemModel = "";
                          CGlobal.Sew_CellckName = "";
                      }
                  
                  }


            }
        }

        #region "UpdateShu"
        private void UpdateShu(string docno, string sumout)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Sewing_Schedule SET  ");
            query.Append(" QtyInSeat  = @QtyInSeat");
            query.Append(" WHERE Docno =  @Docno");
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@QtyInSeat", sumout);
                    db.AddParameter("@Docno", docno);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
        }
        #endregion

        #region "SearchBom"
        private void SearchBom(string docno)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" select sum(QtyOut) as sumOut from dbo.DocMODtl  where DocNo ='" + docno + "' and deptcode='W2' and right(itemcode,4) in('BACK','SEAT','BODY')", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.qtytotalEOut = rs["sumOut"].ToString(); ;
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }
        #endregion

        #region "UpdateOutput"
        private void UpdateOutput(string docdate)
        {
            var query = new StringBuilder();

            string tmpcell = CGlobal.Sew_CellckName.Trim();
            query.Append("Update  dbo.Sewing_TargetDay set Output=(select top(1) sum(qty) as qty  from dbo.Sewing_DtlBarcode");
            query.Append(" where sdate='" + docdate + "'  and TypeCell ='" + tmpcell + "' group by remark order by qty)");
            query.Append(" WHERE sdate =  @sdate");
            query.Append(" and CellName =  @CellName");
            using (var db = new DbHelper1())
            {
                try
                {

                    db.AddParameter("@sdate", docdate);
                    db.AddParameter("@CellName", tmpcell);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
        }
        #endregion


        #region "UpdateQtyOutSewing_Schedule"
        private void UpdateQtyOutSewing_Schedule(string docno, string Qtyout)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Sewing_Schedule SET  ");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(" WHERE Docno =  @Docno");
            using (var db = new DbHelper1())
            {
                try
                {

                    db.AddParameter("@QtyOut", Qtyout);
                    db.AddParameter("@Docno", docno);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        
        }

        #endregion

        #region "showBarcodeview"
        private void showBarcodeview(string docno)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select Sequence,Startday,Docno,Qtyin,QtyOut,remark,QtyBack, QtySeat, QtyBody from dbo.Sewing_Schedule where Docno='" + docno.Trim() + "' order by Sequence ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
 
                    lblPO.Text = "PO Cell : " + rs["Docno"].ToString();
                    lblQty.Text = "Qty : " + rs["Qtyin"].ToString();
                    CGlobal.Sew_QtyBalbom = rs["Qtyin"].ToString();
                    CGlobal.Sew_DocNoRef = rs["remark"].ToString();
                    CGlobal.DayweekPO = rs["Docno"].ToString();
           
                    lblback.Text = rs["QtyBack"].ToString();
                    lblbody.Text = rs["QtyBody"].ToString();
                    lblseat.Text = rs["QtySeat"].ToString();
                    lblout.Text = rs["QtyOut"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_Schedule");
            }
            conn.Close();
        
        }
        #endregion

        private void lblPO_Click(object sender, EventArgs e)
        {

        }

        private void lineShape10_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void showBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CGlobal.Frmcount == "1")
            {
                Showmonitor page = new Showmonitor();  // แสดง cell

                // MonitorLine.FrmShowMonitor page = new MonitorLine.FrmShowMonitor(); // แสดง Line Product
                page.Show();
            }
            else
            {
                MessageBox.Show("Open New Program");

            }
        }

        private void showMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Showmonitor page = new Showmonitor();  // แสดง cell

            // MonitorLine.FrmShowMonitor page = new MonitorLine.FrmShowMonitor(); // แสดง Line Product
            page.Show();
        }

        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            CGlobal.CkSPOCell = Convert.ToString(gridView1.GetDataRow(index)["POCell"]);
            CGlobal.CkSItemmodel = Convert.ToString(gridView1.GetDataRow(index)["Itemmodel"]);
            CGlobal.CkSBarcode = Convert.ToString(gridView1.GetDataRow(index)["Barcode"]);
            CGlobal.CkSQtyseat = Convert.ToString(gridView1.GetDataRow(index)["Qty"]);
            CGlobal.DocID = Convert.ToString(gridView1.GetDataRow(index)["DocID"]);
            CGlobal.FrmcountLine = Convert.ToString(gridView1.GetDataRow(index)["Linenumber"]);

          //  string tmdate = gridView1.GetDataRow(index)["Barcodedate"].ToString("dd/MM/yyyy"); 

            CGlobal.CkSDatetime = Convert.ToString(gridView1.GetDataRow(index)["Barcodedate"]);
            CGlobal.Sew_deletecell = ConfigurationManager.AppSettings["SHOW_CELL1"];

            Sewing.FrmDeleteSewing page = new Sewing.FrmDeleteSewing();
            page.ShowDialog();

            CGlobal.CheckOn = "Yes";

            CallSearchPO();

            showBarcode(CGlobal.Sew_DocNo);

          //  CallBarcode();
        }

        private void keyOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmoperator page = new frmoperator();
            page.ShowDialog();

            //string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            //CallSearch(tmpdate);
        }

        private void ToolStripStatusForm_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridshow2_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            DataRow row = gridView2.GetDataRow(index);

            CGlobal.CkSPOCell = Convert.ToString(gridView2.GetDataRow(index)["POCell"]);
            CGlobal.CkSItemmodel = Convert.ToString(gridView2.GetDataRow(index)["Itemmodel"]);
            CGlobal.CkSBarcode = Convert.ToString(gridView2.GetDataRow(index)["Barcode"]);
            CGlobal.CkSQtyseat = Convert.ToString(gridView2.GetDataRow(index)["Qty"]);
            CGlobal.DocID = Convert.ToString(gridView2.GetDataRow(index)["DocID"]);
            CGlobal.FrmcountLine = Convert.ToString(gridView2.GetDataRow(index)["Linenumber"]);
            //  string tmdate = gridView1.GetDataRow(index)["Barcodedate"].ToString("dd/MM/yyyy"); 

            CGlobal.CkSDatetime = Convert.ToString(gridView2.GetDataRow(index)["Barcodedate"]);
            CGlobal.Sew_deletecell = ConfigurationManager.AppSettings["SHOW_CELL2"];

            Sewing.FrmDeleteSewing page = new Sewing.FrmDeleteSewing();
            page.ShowDialog();

            CGlobal.CheckOn = "Yes";

            CallSearchPO1();
            showBarcode2(CGlobal.Sew_DocNo2);
        }





    }
}
