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
using System.Timers;
using System.Configuration;

namespace PicklistBOM
{

    public partial class FrmShowTarget : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        Boolean Isfind4 = false;
       private int int_XPos = 0, int_YPos = 720;
    
        public FrmShowTarget()
        {
            InitializeComponent();
        }

        //protected override void WndProc(ref Message m)
        //{
        // if (m.Msg == 0x86 && m.WParam == IntPtr.Zero)
        //    {
        //        this.WindowState = FormWindowState.Minimized;
        //        this.WindowState = FormWindowState.Normal;
        //         CallLoad();
        //    }  
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        #region "CallPO"
        private void CallPO()
        {

            String cellPO = ConfigurationManager.AppSettings["CellPO"];
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='" + cellPO +"' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.CheckTargetDoc = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

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
        private void FrmShowTarget_Load(object sender, EventArgs e)
        {
        
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
        //    this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            //Next PO;
            CallSearchCellT();

            CallPO();


            CallLoad();
            CallLoadMessage();
            CallLoadToday();
            CallTargettotal();

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));

            lblCell.Text = ConfigurationManager.AppSettings["SHOW_Name"];
            label31.Text = ConfigurationManager.AppSettings["CellPO"]; 
        }


        #region "  CallSearchCellT();"
        private void CallSearchCellT()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string NextPO = ConfigurationManager.AppSettings["NextPO"];
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='" + NextPO +"' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind3 == true)
                {
                    ds.Tables["ShowdataCELL"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataCELL");

                if (ds.Tables["ShowdataCELL"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["ShowdataCELL"];
                    //  ShowCellT.DataSource = dt;

                    int num = ds.Tables["ShowdataCELL"].Rows.Count;

                    if (num == 3)  //จอง 3
                    {

                        for (int i = 0; i < ds.Tables["ShowdataCELL"].Rows.Count; i++)
                        {
                            string POnumber = ds.Tables["ShowdataCELL"].Rows[i]["POnumber"].ToString();
                            string QtyIn = ds.Tables["ShowdataCELL"].Rows[0]["QtyIn"].ToString();


                            if (i == 0)
                            {
                                lblPO.Text = POnumber;
                                lbltarget.Text = QtyIn;
                                CGlobal.PODAY = POnumber;
                            }
                            else if (i == 1)
                            {

                                lblPO2.Text = POnumber;

                            }
                            else if ((i == 2) && (lblPO2.Text.Trim() == CGlobal.CheckTargetDoc))
                            {
                                lblPO2.Text = POnumber;
                            }

                            else 
                            {
                                lblPO3.Text = POnumber;
                            }
                        }
                    }
                    else  //num จอง 2 PO ให้แสดง 1,2
                    {
                        for (int i = 0; i < ds.Tables["ShowdataCELL"].Rows.Count; i++)
                        {
                            string POnumber = ds.Tables["ShowdataCELL"].Rows[i]["POnumber"].ToString();
                            string QtyIn = ds.Tables["ShowdataCELL"].Rows[0]["QtyIn"].ToString();


                            if (i == 0)
                            {
                                lblPO.Text = POnumber;
                                lbltarget.Text = QtyIn;
                                CGlobal.PODAY = POnumber;
                            }
                            else if (i == 1)
                            {

                                lblPO2.Text = POnumber;

                            }
                            else if (i == 2)
                            {

                                lblPO3.Text = POnumber;

                            }
                        }
                    
                    }

                }
                else
                {
                    Isfind3 = false;
                    //   this.ShowCellT.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  show");
            }
            conn.Close();


        }
        #endregion




            #region "CallTargettotal();"
        private void CallTargettotal()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='" + ConfigurationManager.AppSettings["SHOW_CELL"] + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget.Text = rs["TargetOutput"].ToString();


                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }

        #endregion

        #region " CallLoadMessage();"
        private void CallLoadMessage()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.DocMODtlMessage Where IDMe='" + ConfigurationManager.AppSettings["MessageCell"]  + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string str = Convert.ToString(rs["Message"].ToString());
                   // this.lblMessage.RightToLeft = StrReverse(rs["Message"].ToString());

                    this.lblMessage.Text = str;
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }
        #endregion

        #region "CallLoadToday();"
        private void CallLoadToday()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='" + ConfigurationManager.AppSettings["SHOW_CELL"] + "' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }

        #endregion


        //public static string StrReverse(string expression) 
        //{
        //    if (expression == null || expression.Length == 0)         
        //        return string.Empty;
        //    string reversedString = string.Empty; 
        //    for (int charIndex = expression.Length - 1; charIndex >= 0; charIndex--) 
        //        { reversedString += expression[charIndex]; 
        //    } 
        //    return reversedString;
        //} 

        #region "Callstdtime()"
        private void Callstdtime()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string NextPO = ConfigurationManager.AppSettings["NextPO"];

                if (NextPO == "CELL TRAINING")
                {
                    NextPO = "CELL";
                }
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = " select Qty,Itemmodel,left(Itemmodel,8) as tmpmodel,(select  TotalTime from dbo.Stdtime where Style+Cover = LEFT(Itemmodel,3)+'-'+SUBSTRING(Itemmodel,4,5)) as total1  from dbo.DocMODtlBarcode  where TypeCell ='" + NextPO + "' and Sdate='" + tempdate + "'";
               
                if (Isfind4 == true)
                {
                    ds.Tables["showstdtime"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "showstdtime");

                if (ds.Tables["showstdtime"].Rows.Count != 0)
                {
                    Isfind4 = true;
                    dt = ds.Tables["showstdtime"];
                    double num = 0;
                    double min = 0;
                    double sum = 0;
                    double n = 0;
                    string tmpstring="";
                    for (int i = 0; i < ds.Tables["showstdtime"].Rows.Count; i++)
                    {
                        string Qty = ds.Tables["showstdtime"].Rows[i]["Qty"].ToString();
                        string TotalTime = ds.Tables["showstdtime"].Rows[i]["total1"].ToString();
                        string tmpmodel = ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();
                        string tmpCk = Left(tmpmodel, 3);
                        if ((TotalTime==null)||(TotalTime==""))
                        {
                           // lblstdtime1.BackColor = Color.PaleVioletRed;
                            n = n + i;
                            tmpstring= ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();
                            //MessageBox.Show(Convert.ToString(i));
                        }
                        else
                        {

                            if ((tmpCk == "80T") || (tmpCk == "04T") || (tmpCk == "30T") || (tmpCk == "35T") || (tmpCk == "65T") || (tmpCk == "T51") || (tmpCk == "P51") || (tmpCk == "T33") || (tmpCk == "P33") || (tmpCk == "T35") || (tmpCk == "P35") || (tmpCk == "T39") || (tmpCk == "P39"))
                            {
                                // ไม่คูณ seat คิดตัวต่อตัว
                                num = 1 * Convert.ToDouble(TotalTime);
                                sum = sum + num;
                            }
                            else if ((tmpCk == "61T") || (tmpCk == "63T") || (tmpCk == "82T") || (tmpCk == "32T") || (tmpCk == "6ST") || (tmpCk == "T32") || (tmpCk == "P32"))
                            {
                                // ไม่คูณ seat คิดตัวต่อตัว
                                num = 1 * Convert.ToDouble(TotalTime);
                                sum = sum + num;
                            }
                            else
                            {
                                num = 1 * Convert.ToDouble(TotalTime);
                                sum = sum + num;
                            }
                        }
               
                    }

                    //ใส่สี stdtime

                    if (n > 0)
                    {
                        lblme1.Visible = true;
                        lblstdtime1.BackColor = Color.Red;
                        lblstdtime1.ForeColor = Color.Blue;
                        lblme1.Text = tmpstring;
                        n = 0;
                    }
                    else 
                    {
                        lblme1.Visible = false;
                        lblstdtime1.BackColor = Color.Black;
                        lblstdtime1.ForeColor = Color.Orange ;
                    }

                   // MessageBox.Show(Convert.ToString(sum));
                    min = sum/60;
                    lblstdtime1.Text =min.ToString("#####0");
                }
                else
                {
                    Isfind4 = false;
                    return;
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data  show");
            }
            conn.Close();
        
        }
        #endregion

        #region "CallAvertime"
        private void CallAvertime()
        { 
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            try
            {

                string NextPO = ConfigurationManager.AppSettings["NextPO"];
                if (NextPO == "CELL TRAINING")
                {
                    NextPO = "CELL";
                }

                Cmd = new System.Data.SqlClient.SqlCommand(" select  *  from  StdtimeTimeCell  where  typecell ='" + NextPO + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    string timeck = Left(resulttime, 2);
                    double sum = 0;
                    if (timeck=="08")
                    {
                      sum = 1 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck=="09")
                    {
                        sum = 2 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]); 
                    }
                    else if (timeck == "10")
                    {
                        sum = 3 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck == "11")
                    {
                        sum = 4 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck == "12")
                    {
                        sum = 4 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }

                    else if (timeck == "13")
                    {
                        sum = 5 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck == "14")
                    {
                        sum = 6 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck == "15")
                    {
                        sum = 7 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else if (timeck == "16")
                    {
                        sum = 8 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }

                    else if (timeck == "17")
                    {
                        string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3,2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 9 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                        else
                        {
                            sum = 8 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                    }
                    else if (timeck == "18")
                    {
                        string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3,2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 10 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                        else 
                        {
                            sum = 9 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                    }
                    else if (timeck == "19")
                    {
                         string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3,2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 11 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                        else
                        {
                            sum = 10 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                        }
                  
                    }
                    else if (timeck == "20")
                    {
                        sum = 11 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    else
                    {
                        sum = 8 * Convert.ToDouble(rs["TmpMin"]) * Convert.ToDouble(rs["TmpWorker"]);
                    }
                    // นับจำนวน ชั่วโมง ไปเรือย 1 ชั่วโมง
               

                    lbldaytime.Text = sum.ToString("####0");
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }
        #endregion

        private void CallLoadSum()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblTCell.Text = Convert.ToDouble(rs["Total"]).ToString("#,###0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            if (CGlobal.TmpAutoCell9 == "Yes")
            {
                //Next PO;
                CallSearchCellT();
                //group select Qty.
                CallLoad();
                CallLoadMessage();
                CallLoadToday();
                CallTargettotal();

                // เวลา นับจำนวน 
                CallTime();

                // หา stdtime

            }


            CallLoadSum();
            Callstdtime();
            CGlobal.TmpAutoCell9 = "No";

        }
   
        #region "CallLoad()"
        private void CallLoad()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

              // String strbarcod = Mid(txtbarcode.Text.Trim(), 0, 14);
                //Cmd = new System.Data.SqlClient.SqlCommand(" Select DocNo,DeptCode,QtyBom,QtyOut,QtyBal,QtyUse,Barcode,DocPoNo  from dbo.DocMODtl  where  Barcode ='" + CGlobal.CheckTargetBarcode  + "' and DocNo ='" + CGlobal.CheckTargetDoc + "'", conn);

                string temp = ConfigurationManager.AppSettings["BomCell"];

                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    if (CGlobal.CheckTargetDoc == null)
                    {
                        this.lblPO.Text = CGlobal.PODAY;
                    }
                    else 
                    {
                      //  lblPO.Text = CGlobal.CheckTargetDoc;
                    }

                  //  double num = Convert.ToDouble(CGlobal.sumtarget);
                   // lbltarget.Text = num.ToString("#,##0");
                    lbltarget.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                   // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance.Text = num1.ToString("#,##0");


                    // TOTAL
                    lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                   // lbltotalT.Text = num.ToString("#,##0");
                    lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    lblToablB.Text = num1.ToString("#,##0");
         
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        
        }

        #endregion


        private void timer2_Tick(object sender, EventArgs e)
        {
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            int int_StartXPos = this.lblMessage.Width * (-1);

            //    if (this.Width < int_XPos)

            int int_x = Math.Abs(int_XPos);

            if (this.Width < int_x)
            {
                this.lblMessage.Location = new System.Drawing.Point(int_StartXPos, int_XPos);
                int_XPos = 0;
             
            }
            else
            {
                this.lblMessage.Location = new System.Drawing.Point(int_XPos, int_YPos);
                int_XPos -= 4;

           
            }

            //if (int_XPos == 0)
            //{
            //    //repeat marquee
            //    this.lblMessage.Location = new System.Drawing.Point(this.Width, int_YPos);
            //    int_XPos = this.Width;
            //}
            //else
            //{
            //    this.lblMessage.Location = new System.Drawing.Point(int_XPos, int_YPos);
            // int_XPos -= 6;
            //}
        }

        private void lblCell_Click(object sender, EventArgs e)
        {

        }

        private void lineShape10_Click(object sender, EventArgs e)
        {

        }


        #region "CallTime()"
        private void CallTime()
        {

            CallTime8(" 08:00:00.000", " 08:59:59.999", "8");
            CallTime8(" 09:00:00.000", " 09:59:59.999", "9");
            CallTime8(" 10:00:00.000", " 10:59:59.999", "10");
            CallTime8(" 11:00:00.000", " 12:59:59.999", "11");
            CallTime8(" 13:00:00.000", " 13:59:59.999", "13");
            CallTime8(" 14:00:00.000", " 14:59:59.999", "14");
            CallTime8(" 15:00:00.000", " 15:59:59.999", "15");
            CallTime8(" 16:00:00.000", " 16:59:59.999", "16");
            CallTime8(" 17:30:00.000", " 18:29:59.999", "17");
            CallTime8(" 18:30:00.000", " 19:29:59.999", "18");
            CallTime8(" 19:30:00.000", " 20:59:59.999", "19");

        
        }

        private void  CallTime8(string time1, string time2, string temp)
        {
        
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            try
            {
                string resultdate1 = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string resultdate = DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
                string t1 = resultdate + time1;
                string t2 = resultdate + time2;
                String cellPO = ConfigurationManager.AppSettings["SHOW_CELL"];

                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) as totalsum from dbo.DocMODtlBarcode where Sdate='" + resultdate1 + "' and TypeCell ='" + cellPO + "' and Barcodedate  between '" + t1 + "' and ' " + t2 + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string sumT = "";
                     string sum = rs["totalsum"].ToString();
                     if (sum == "")
                     {
                         sumT = "0";
                     }
                     else
                     {
                         sumT = sum;
                     }

                    if (temp=="8")
                    {
                        label20.Text = Convert.ToDouble(sumT).ToString("#,##0");
                    }
                    else if (temp == "9")
                    {

                        label21.Text = Convert.ToDouble(sumT).ToString("#,##0");
                    
                    }
                    else if (temp == "10")
                    {

                        label22.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "11")
                    {

                        label23.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "13")
                    {

                        label24.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "14")
                    {

                        label25.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "15")
                    {

                        label26.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }

                    else if (temp == "16")
                    {

                        label27.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "17")
                    {

                        label28.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "18")
                    {

                        label29.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    else if (temp == "19")
                    {

                        label30.Text = Convert.ToDouble(sumT).ToString("#,##0");

                    }
                    temp = "";

                }

                conn.Close();
            }
            catch (Exception ex)
            {
            }

           
          
        }

        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbltime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblstdtime = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape10 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblPO = new System.Windows.Forms.Label();
            this.lbltarget = new System.Windows.Forms.Label();
            this.lblactual = new System.Windows.Forms.Label();
            this.lblbalance = new System.Windows.Forms.Label();
            this.lbltotalT = new System.Windows.Forms.Label();
            this.lblTotalA = new System.Windows.Forms.Label();
            this.lblToablB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCell = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbltotaltarget = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPO2 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cachedReportPODate1 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lbldaytime = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblstdtime1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblme1 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.lblPO3 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTCell = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltime
            // 
            this.lbltime.BackColor = System.Drawing.Color.Black;
            this.lbltime.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltime.ForeColor = System.Drawing.Color.Yellow;
            this.lbltime.Location = new System.Drawing.Point(948, 100);
            this.lbltime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(271, 50);
            this.lbltime.TabIndex = 64;
            this.lbltime.Text = "Time";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2590;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(391, 457);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 44);
            this.label1.TabIndex = 65;
            this.label1.Text = "Batch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblstdtime
            // 
            this.lblstdtime.BackColor = System.Drawing.Color.Green;
            this.lblstdtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblstdtime.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstdtime.ForeColor = System.Drawing.Color.Tomato;
            this.lblstdtime.Location = new System.Drawing.Point(945, 456);
            this.lblstdtime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstdtime.Name = "lblstdtime";
            this.lblstdtime.Size = new System.Drawing.Size(302, 45);
            this.lblstdtime.TabIndex = 67;
            this.lblstdtime.Text = "Balance";
            this.lblstdtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1,
            this.lineShape10});
            this.shapeContainer1.Size = new System.Drawing.Size(1274, 772);
            this.shapeContainer1.TabIndex = 69;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineShape2.BorderWidth = 3;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 820;
            this.lineShape2.X2 = 819;
            this.lineShape2.Y1 = 429;
            this.lineShape2.Y2 = 376;
            this.lineShape2.Click += new System.EventHandler(this.lineShape10_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 14;
            this.lineShape1.X2 = 1232;
            this.lineShape1.Y1 = 162;
            this.lineShape1.Y2 = 162;
            // 
            // lineShape10
            // 
            this.lineShape10.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineShape10.BorderWidth = 3;
            this.lineShape10.Name = "lineShape10";
            this.lineShape10.X1 = 56;
            this.lineShape10.X2 = 321;
            this.lineShape10.Y1 = 445;
            this.lineShape10.Y2 = 445;
            this.lineShape10.Click += new System.EventHandler(this.lineShape10_Click);
            // 
            // lblPO
            // 
            this.lblPO.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO.ForeColor = System.Drawing.Color.Purple;
            this.lblPO.Location = new System.Drawing.Point(269, 607);
            this.lblPO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(613, 53);
            this.lblPO.TabIndex = 72;
            this.lblPO.Text = "Product Order";
            // 
            // lbltarget
            // 
            this.lbltarget.BackColor = System.Drawing.Color.Black;
            this.lbltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget.Location = new System.Drawing.Point(391, 502);
            this.lbltarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget.Name = "lbltarget";
            this.lbltarget.Size = new System.Drawing.Size(273, 99);
            this.lbltarget.TabIndex = 73;
            this.lbltarget.Text = "0";
            this.lbltarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual
            // 
            this.lblactual.BackColor = System.Drawing.Color.Black;
            this.lblactual.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual.Location = new System.Drawing.Point(666, 502);
            this.lblactual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual.Name = "lblactual";
            this.lblactual.Size = new System.Drawing.Size(276, 99);
            this.lblactual.TabIndex = 74;
            this.lblactual.Text = "0";
            this.lblactual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblbalance
            // 
            this.lblbalance.BackColor = System.Drawing.Color.Black;
            this.lblbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance.Location = new System.Drawing.Point(945, 502);
            this.lblbalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance.Name = "lblbalance";
            this.lblbalance.Size = new System.Drawing.Size(302, 99);
            this.lblbalance.TabIndex = 75;
            this.lblbalance.Text = "0";
            this.lblbalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotalT
            // 
            this.lbltotalT.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbltotalT.Location = new System.Drawing.Point(697, 715);
            this.lbltotalT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalT.Name = "lbltotalT";
            this.lbltotalT.Size = new System.Drawing.Size(38, 54);
            this.lbltotalT.TabIndex = 76;
            this.lbltotalT.Text = "0";
            this.lbltotalT.Visible = false;
            // 
            // lblTotalA
            // 
            this.lblTotalA.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalA.Location = new System.Drawing.Point(690, 715);
            this.lblTotalA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalA.Name = "lblTotalA";
            this.lblTotalA.Size = new System.Drawing.Size(45, 62);
            this.lblTotalA.TabIndex = 77;
            this.lblTotalA.Text = "0";
            this.lblTotalA.Visible = false;
            // 
            // lblToablB
            // 
            this.lblToablB.Font = new System.Drawing.Font("Microsoft Sans Serif", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblToablB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblToablB.Location = new System.Drawing.Point(743, 739);
            this.lblToablB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToablB.Name = "lblToablB";
            this.lblToablB.Size = new System.Drawing.Size(58, 54);
            this.lblToablB.TabIndex = 78;
            this.lblToablB.Text = "0";
            this.lblToablB.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(666, 457);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 44);
            this.label2.TabIndex = 66;
            this.label2.Text = "Actual";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCell
            // 
            this.lblCell.Font = new System.Drawing.Font("Tahoma", 33F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCell.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCell.Location = new System.Drawing.Point(11, 600);
            this.lblCell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(253, 67);
            this.lblCell.TabIndex = 79;
            this.lblCell.Text = "CELL PO:";
            this.lblCell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCell.Click += new System.EventHandler(this.lblCell_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1130;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(-1, 715);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1298, 80);
            this.label7.TabIndex = 81;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal
            // 
            this.lbltotal.BackColor = System.Drawing.Color.Black;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal.ForeColor = System.Drawing.Color.Yellow;
            this.lbltotal.Location = new System.Drawing.Point(840, 67);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(352, 109);
            this.lbltotal.TabIndex = 83;
            this.lbltotal.Text = "0";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(838, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(348, 57);
            this.label9.TabIndex = 85;
            this.label9.Text = "Today Output";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(444, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(337, 57);
            this.label8.TabIndex = 86;
            this.label8.Text = "Today Target";
            // 
            // lbltotaltarget
            // 
            this.lbltotaltarget.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget.Location = new System.Drawing.Point(434, 68);
            this.lbltotaltarget.Name = "lbltotaltarget";
            this.lbltotaltarget.Size = new System.Drawing.Size(352, 108);
            this.lbltotaltarget.TabIndex = 83;
            this.lbltotaltarget.Text = "0";
            this.lbltotaltarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltotaltarget.Click += new System.EventHandler(this.lbltotaltarget_Click);
            // 
            // lbldate
            // 
            this.lbldate.BackColor = System.Drawing.Color.Black;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbldate.ForeColor = System.Drawing.Color.Yellow;
            this.lbldate.Location = new System.Drawing.Point(56, 448);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(268, 48);
            this.lbldate.TabIndex = 88;
            this.lbldate.Text = "date";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 33F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(4, 659);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 51);
            this.label5.TabIndex = 89;
            this.label5.Text = "NEXT  PO:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(48, 502);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 99);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(21, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 65);
            this.label4.TabIndex = 71;
            this.label4.Text = "TOTAL";
            // 
            // lblPO2
            // 
            this.lblPO2.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPO2.Location = new System.Drawing.Point(272, 662);
            this.lblPO2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO2.Name = "lblPO2";
            this.lblPO2.Size = new System.Drawing.Size(417, 49);
            this.lblPO2.TabIndex = 91;
            this.lblPO2.Text = "xxx";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 46F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMessage.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblMessage.Location = new System.Drawing.Point(-13, 713);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1490, 76);
            this.lblMessage.TabIndex = 82;
            this.lblMessage.Text = "ขอความทดสอบ";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(5, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 33);
            this.label10.TabIndex = 93;
            this.label10.Text = "09:00-10:00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 113);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 33);
            this.label11.TabIndex = 94;
            this.label11.Text = "10:00-11:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(304, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 33);
            this.label12.TabIndex = 95;
            this.label12.Text = "11:00-12:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(303, 64);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(183, 33);
            this.label13.TabIndex = 96;
            this.label13.Text = "13:00-14:00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(303, 112);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 33);
            this.label14.TabIndex = 97;
            this.label14.Text = "14:00-15:00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(631, 18);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 33);
            this.label15.TabIndex = 98;
            this.label15.Text = "15:00-16:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 33);
            this.label6.TabIndex = 99;
            this.label6.Text = "08:00-09:00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(631, 64);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(183, 33);
            this.label16.TabIndex = 100;
            this.label16.Text = "16:00-17:00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(632, 109);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(183, 33);
            this.label17.TabIndex = 101;
            this.label17.Text = "17:30-18:30";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(928, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(183, 33);
            this.label18.TabIndex = 102;
            this.label18.Text = "18:30-19:30";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(930, 62);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(183, 33);
            this.label19.TabIndex = 103;
            this.label19.Text = "19:30-20:30";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.ForeColor = System.Drawing.Color.Yellow;
            this.label20.Location = new System.Drawing.Point(191, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 36);
            this.label20.TabIndex = 104;
            this.label20.Text = "0";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.ForeColor = System.Drawing.Color.Yellow;
            this.label21.Location = new System.Drawing.Point(191, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 36);
            this.label21.TabIndex = 105;
            this.label21.Text = "0";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.ForeColor = System.Drawing.Color.Yellow;
            this.label22.Location = new System.Drawing.Point(191, 110);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 36);
            this.label22.TabIndex = 106;
            this.label22.Text = "0";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.ForeColor = System.Drawing.Color.Yellow;
            this.label23.Location = new System.Drawing.Point(492, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 36);
            this.label23.TabIndex = 107;
            this.label23.Text = "0";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label24.ForeColor = System.Drawing.Color.Yellow;
            this.label24.Location = new System.Drawing.Point(492, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(103, 36);
            this.label24.TabIndex = 108;
            this.label24.Text = "0";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.ForeColor = System.Drawing.Color.Yellow;
            this.label25.Location = new System.Drawing.Point(492, 109);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 36);
            this.label25.TabIndex = 109;
            this.label25.Text = "0";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label26.ForeColor = System.Drawing.Color.Yellow;
            this.label26.Location = new System.Drawing.Point(825, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 36);
            this.label26.TabIndex = 110;
            this.label26.Text = "0";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.ForeColor = System.Drawing.Color.Yellow;
            this.label27.Location = new System.Drawing.Point(825, 61);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(103, 36);
            this.label27.TabIndex = 111;
            this.label27.Text = "0";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.BackColor = System.Drawing.Color.Black;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label28.ForeColor = System.Drawing.Color.Yellow;
            this.label28.Location = new System.Drawing.Point(825, 109);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(103, 36);
            this.label28.TabIndex = 112;
            this.label28.Text = "0";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.BackColor = System.Drawing.Color.Black;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label29.ForeColor = System.Drawing.Color.Yellow;
            this.label29.Location = new System.Drawing.Point(1116, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 36);
            this.label29.TabIndex = 113;
            this.label29.Text = "0";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label30.ForeColor = System.Drawing.Color.Yellow;
            this.label30.Location = new System.Drawing.Point(1116, 60);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(103, 36);
            this.label30.TabIndex = 114;
            this.label30.Text = "0";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.lbltime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(14, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1250, 153);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label31.ForeColor = System.Drawing.Color.Brown;
            this.label31.Location = new System.Drawing.Point(86, 371);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(159, 65);
            this.label31.TabIndex = 116;
            this.label31.Text = "CELL";
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // lbldaytime
            // 
            this.lbldaytime.BackColor = System.Drawing.Color.Black;
            this.lbldaytime.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbldaytime.ForeColor = System.Drawing.Color.Lime;
            this.lbldaytime.Location = new System.Drawing.Point(507, 369);
            this.lbldaytime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldaytime.Name = "lbldaytime";
            this.lbldaytime.Size = new System.Drawing.Size(219, 63);
            this.lbldaytime.TabIndex = 117;
            this.lbldaytime.Text = "0";
            this.lbldaytime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label34.Location = new System.Drawing.Point(829, 378);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(137, 48);
            this.label34.TabIndex = 119;
            this.label34.Text = "Std T.";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label35.Location = new System.Drawing.Point(326, 371);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(174, 57);
            this.label35.TabIndex = 120;
            this.label35.Text = "Day T.";
            // 
            // lblstdtime1
            // 
            this.lblstdtime1.BackColor = System.Drawing.Color.Black;
            this.lblstdtime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstdtime1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblstdtime1.Location = new System.Drawing.Point(965, 369);
            this.lblstdtime1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstdtime1.Name = "lblstdtime1";
            this.lblstdtime1.Size = new System.Drawing.Size(220, 63);
            this.lblstdtime1.TabIndex = 121;
            this.lblstdtime1.Text = "0";
            this.lblstdtime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblstdtime1.Click += new System.EventHandler(this.lblstdtime1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(727, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 41);
            this.label3.TabIndex = 122;
            this.label3.Text = "Min.";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label32.Location = new System.Drawing.Point(1186, 382);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(91, 41);
            this.label32.TabIndex = 123;
            this.label32.Text = "Min.";
            // 
            // lblme1
            // 
            this.lblme1.AutoSize = true;
            this.lblme1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblme1.ForeColor = System.Drawing.Color.Blue;
            this.lblme1.Location = new System.Drawing.Point(1029, 432);
            this.lblme1.Name = "lblme1";
            this.lblme1.Size = new System.Drawing.Size(69, 23);
            this.lblme1.TabIndex = 124;
            this.lblme1.Text = "model";
            this.lblme1.Visible = false;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 600;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // lblPO3
            // 
            this.lblPO3.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPO3.Location = new System.Drawing.Point(855, 660);
            this.lblPO3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO3.Name = "lblPO3";
            this.lblPO3.Size = new System.Drawing.Size(419, 49);
            this.lblPO3.TabIndex = 125;
            this.lblPO3.Text = "xxx";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 33F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label36.Location = new System.Drawing.Point(675, 652);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(180, 51);
            this.label36.TabIndex = 126;
            this.label36.Text = "NEXT :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label37.Location = new System.Drawing.Point(148, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(145, 57);
            this.label37.TabIndex = 128;
            this.label37.Text = "Total";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.lblTCell);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.lbltotaltarget);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lbltotal);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(15, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1249, 187);
            this.groupBox3.TabIndex = 129;
            this.groupBox3.TabStop = false;
            // 
            // lblTCell
            // 
            this.lblTCell.BackColor = System.Drawing.Color.Black;
            this.lblTCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTCell.ForeColor = System.Drawing.Color.Lime;
            this.lblTCell.Location = new System.Drawing.Point(62, 67);
            this.lblTCell.Name = "lblTCell";
            this.lblTCell.Size = new System.Drawing.Size(332, 108);
            this.lblTCell.TabIndex = 130;
            this.lblTCell.Text = "0";
            this.lblTCell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmShowTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1274, 772);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.lblPO3);
            this.Controls.Add(this.lblme1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblstdtime1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.lbldaytime);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblPO2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCell);
            this.Controls.Add(this.lblToablB);
            this.Controls.Add(this.lblTotalA);
            this.Controls.Add(this.lbltotalT);
            this.Controls.Add(this.lblbalance);
            this.Controls.Add(this.lblactual);
            this.Controls.Add(this.lbltarget);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.lblstdtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmShowTarget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cell  Lean";
            this.Load += new System.EventHandler(this.FrmShowTarget_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lbltotaltarget_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void lblstdtime1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            this.lbltime.Text = resulttime;
            // Callstdtime();
            CallAvertime();
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }




    }
}
