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

namespace PicklistBOM.Sewing
{
    public partial class FrmSewnShowTarget : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmSewnShowTarget()
        {
            InitializeComponent();
        }
        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            //double num = Convert.ToDouble(lbltotal.Text) / Convert.ToDouble(lbltotaltarget.Text);
            //double sumper = num * 100;
            //lblper.Text = sumper.ToString("#,###0") + "%";

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }



        private void FrmSewnShowTarget_Load(object sender, EventArgs e)
        {
            CallSearch();
            CallPO();
            //week
            CallWeek();
            CallsumTotal();

            //กรณียิง PO นี้มา
           // CallsearchPO(CGlobal.Sew_DocNo);

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));

            label31.Text = ConfigurationManager.AppSettings["SHOW_CELL"]; 
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

        }

        #region "sumtotal"
        private void CallsumTotal()
        {
            // sum total time
            double mon = 0;
            double tue = 0;
            double web = 0;
            double tud = 0;
            double fri = 0;
            double sat = 0;
            double totalwk = 0;
            if (lblMonM.Text != "-")
            {
                if (lblMonM.Text == "")
                {
                    lblMonM.Text = "0";
                }
                mon = Convert.ToDouble(lblMonM.Text);
            }
            if (lblTueM.Text != "-")
            {
                if (lblTueM.Text == "")
                {
                    lblTueM.Text = "0";
                }
                tue = Convert.ToDouble(lblTueM.Text);
            }
            if (lblWebM.Text != "-")
            {
                //string tmp = lblWebM.Text;
                if (lblWebM.Text == "")
                {
                    lblWebM.Text = "0";
                }
                web = Convert.ToDouble(lblWebM.Text);
            }
            if (lblThdM.Text != "-")
            {
                if (lblThdM.Text == "")
                {
                    lblThdM.Text = "0";
                }
                tud = Convert.ToDouble(lblThdM.Text);
            }
            if (lblFriM.Text != "-")
            {
                if (lblFriM.Text == "")
                {
                    lblFriM.Text = "0";
                }
                fri = Convert.ToDouble(lblFriM.Text);
            }
            if (lblSatM.Text != "-")
            {
                if (lblSatM.Text == "")
                {
                    lblSatM.Text = "0";
                }
                sat = Convert.ToDouble(lblSatM.Text);
            }
            totalwk = mon + tue + web + tud + fri + sat;
            lblwktotal.Text = totalwk.ToString("#,###0.00");

        }

        #endregion

        #region "   CallWeek();"
        private void CallWeek()
        {
            CGlobal.DayweekTotalSew = "0";
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
          //  CGlobal.DayweekTotalSew = "0";
            if (temday == "Sat")
            {
                // this.lblSatM.BackColor = Color.Red;
                this.lblSatM.ForeColor = Color.Red;
                //วันเสาร์
                CallSearchWeek(day);
                // lblSat.Text = CGlobal.DayweekTotal;
                lblSatM.Text = CGlobal.DayweekTotalSew;

                CGlobal.DayweekTotalSew = "0";
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                // lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotalSew;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotalSew;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                //  lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotalSew;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
                //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

            }
            else if (temday == "Mon")
            {
                //this.lblMon.BackColor = Color.Red;
                // this.lblMon.ForeColor = Color.GhostWhite;
                //วันจันทร์
                CallSearchWeek(day);
                //lblMon.Text = CGlobal.DayweekTotal;
                //lblTue.Text = "-";
                //lblWeb.Text = "-";
                //lblThd.Text = "-";
                //lblFri.Text = "-";
                //lblSat.Text = "-";

                //  this.lblMonM.BackColor = Color.Red;
                this.lblMonM.ForeColor = Color.Red;
                CGlobal.DayweekTotalSew = "0";
                lblMonM.Text = CGlobal.DayweekTotalSew;
              //  CGlobal.DayweekTotalSew = "0";
                lblTueM.Text = "-";
                lblWebM.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";

            }
            else if (temday == "Tue")
            {
                //this.lblTue.BackColor = Color.Red;
                //this.lblTue.ForeColor = Color.GhostWhite;

                //   this.lblTueM.BackColor = Color.Red;
                this.lblTueM.ForeColor = Color.Red;
                //วันอังคาร
                CallSearchWeek(day);
                //    lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

                // lblWeb.Text = "-";
                // lblThd.Text = "-";
                // lblFri.Text = "-";
                // lblSat.Text = "-";

                lblWebM.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }

            else if (temday == "Wed")
            {
                //  this.lblWeb.BackColor = Color.Red;
                //  this.lblWeb.ForeColor = Color.GhostWhite;
                //  this.lblWebM.BackColor = Color.Red;
                this.lblWebM.ForeColor = Color.Red;
                //วันพุธ
                CallSearchWeek(day);
                // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                //  lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;

                //lblThd.Text = "-";
                // lblFri.Text = "-";
                //lblSat.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }
            else if (temday == "Thu")
            {
                // this.lblThd.BackColor = Color.Red;
                //this.lblThd.ForeColor = Color.GhostWhite;
                //   this.lblThdM.BackColor = Color.Red;
                this.lblThdM.ForeColor = Color.Red;
                //วันพฤ
                CallSearchWeek(day);
                // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                //  lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotalSew;

                //lblFri.Text = "-";
                // lblSat.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";

            }
            else if (temday == "Fri")
            {
                // this.lblFri.BackColor = Color.Red;
                // this.lblFri.ForeColor = Color.GhostWhite;
                //  this.lblFriM.BackColor = Color.Red;
                this.lblFriM.ForeColor = Color.Red;
                //วันศุก
                CallSearchWeek(day);
                //lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotalSew;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotalSew;

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotalSew;

                lblSatM.Text = "-";

            }


        }

        #endregion

        #region"  CallSearchWeek()"
        private void CallSearchWeek(string temdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {

                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL"];
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Sewing_TargetDay "
              + " Where sdate='" + temdate + "' and Cellname='" + tmpcell  + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.DayweekTotalSew = rs["Output"].ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion


        #region " CallPO()"
        private void CallPO()
        {

            String cellPO = ConfigurationManager.AppSettings["SHOW_CELL"];
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select top(4)Docno,Cellname,Qtyin,Qtyout,qtyback,qtyseat,qtybody FROM  dbo.Sewing_Schedule where cellname ='" + cellPO + "' and qtyin<>Qtyout order by sequence";
                if (Isfind == true)
                {
                    ds.Tables["ShowdataCELL"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataCELL");

                if (ds.Tables["ShowdataCELL"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["ShowdataCELL"];
                    int num = ds.Tables["ShowdataCELL"].Rows.Count;
                        for (int i = 0; i < ds.Tables["ShowdataCELL"].Rows.Count; i++)
                        {
                            string Docno = ds.Tables["ShowdataCELL"].Rows[i]["Docno"].ToString();
                            string QtyIn = ds.Tables["ShowdataCELL"].Rows[i]["QtyIn"].ToString();
                            string qtyback = ds.Tables["ShowdataCELL"].Rows[i]["qtyback"].ToString();
                            string qtyseat = ds.Tables["ShowdataCELL"].Rows[i]["qtyseat"].ToString();
                            string qtybody = ds.Tables["ShowdataCELL"].Rows[i]["qtybody"].ToString();

                            if (i == 0)
                            {
                                lblPO1.Text = Docno;
                                lblbom.Text = QtyIn;
                                lblbody.Text = qtybody;
                                lblseat.Text = qtyseat;
                                lblback.Text = qtyback;
                        
                            }
                            else if (i == 1)
                            {

                                lblPO2.Text = Docno;

                            }
                            else if (i == 2) 
                            {
                                lblPO3.Text = Docno;
                            }

                            else if (i == 3) 
                            {
                                lblPO4.Text = Docno;
                            }
                        }
                    
         

                }
                else
                {
                    Isfind = false;
    
                    return;
                }
         
            }
            catch (Exception ex)
            {

            }
            conn.Close();

        
        }

        #endregion

        #region "CallSearch()"
        private void CallSearch()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            lbltotaltarget.Text = "0";
          //  lbltotal.Text = "0";
            try
            {
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL"];
                string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT SewID, Mantotal, Unitperhead, target,Output, Issuedate, UserID FROM  Sewing_TargetDay  where CONVERT(VARCHAR(10),Issuedate,110)='" + tmpdate.Trim() + "' and CellName='" + tmpcell  + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltotaltarget.Text = rs["target"].ToString();
                  //  lbltotal.Text = rs["Output"].ToString();
                    CGlobal.DayweekOutputD = rs["Output"].ToString();
                }

            }
            catch (Exception ex)
            {
               // CGlobal.IssueNumber2 = "1";
            }
            conn.Close();

        }
        #endregion

        #region "CallsearchPO"
        private void CallsearchPO(string docno)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select Sequence,Startday,Docno,Qtyin,QtyOut,remark,QtyBack, QtySeat, QtyBody from dbo.Sewing_Schedule where Docno='" + docno.Trim() + "'  and QtyIn<>QtyOut order by Sequence ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblbom.Text = rs["Qtyin"].ToString();
                   // lbltotal.Text = rs["QtyOut"].ToString();
                    lblback.Text = rs["QtyBack"].ToString();
                    lblbody.Text = rs["QtyBody"].ToString();
                    lblseat.Text = rs["QtySeat"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_Schedule");
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


        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            this.lbltime.Text = resulttime;

       

            string hh = Left(resulttime, 2);
            if (hh == "08")
            {
                lblperhrs.Text = "08:00-09:00";
            }
            else if (hh == "09")
            {
                lblperhrs.Text = "09:00-10:00";
            }
            else if (hh == "10")
            {
                lblperhrs.Text = "10:00-11:00";
            }
            else if (hh == "11")
            {
                lblperhrs.Text = "11:00-12:00";
            }
            else if (hh == "12")
            {
                lblperhrs.Text = "12:00-13:00";
            }

            else if (hh == "13")
            {
                lblperhrs.Text = "13:00-14:00";
            }
            else if (hh == "14")
            {
                lblperhrs.Text = "14:00-15:00";
            }

            else if (hh == "15")
            {
                lblperhrs.Text = "15:00-16:00";
            }
            else if (hh == "16")
            {
                lblperhrs.Text = "16:00-17:00";
            }
            else if (hh == "17")
            {
                lblperhrs.Text = "16:00-18:00";
            }

            else if (hh == "18")
            {
                lblperhrs.Text = "18:00-19:00";
            }
            else if (hh == "19")
            {
                lblperhrs.Text = "19:00-20:30";
            }
            double seat = Convert.ToDouble(lbltotaltarget.Text) / 8;
            lbltotal.Text = seat.ToString("#,###0");

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void lblback_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            CallSearch();
            CallPO();
            //if (CGlobal.DayweekOutputD != this.lbltotal.Text.Trim())
            //{
        
            CallWeek();
            CallsumTotal();

            Calltime();

            double num = Convert.ToDouble(lbloutput.Text) / Convert.ToDouble(lbltotal.Text);
            double sumper = num * 100;
            lblper.Text = sumper.ToString("#,###0.00") + "%";
            //   lblper.Text = "";

        }

        #region "celltime)
        private void Calltime()
        {
            string resultdate = DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            string tmp = "";
            string hh = Left(resulttime, 2);
            if (hh == "08")
            {
                tmp = "between '" + resultdate + " 08:00:00.567' and '" + resultdate + " 08:59:59.999'";
            }
            else if (hh == "09")
            {
                tmp = "between '" + resultdate + " 09:00:00.567' and '" + resultdate + " 09:59:59.999'";
            }
            else if (hh == "10")
            {
                tmp = "between '" + resultdate + " 10:00:00.567' and '" + resultdate + " 10:59:59.999'";
            }
            else if (hh == "11")
            {
                tmp = "between '" + resultdate + " 11:00:00.567' and '" + resultdate + " 11:59:59.999'";
            }
            else if (hh == "12")
            {
                tmp = "between '" + resultdate + " 12:00:00.567' and '" + resultdate + " 12:59:59.999'";
            }
            else if (hh == "13")
            {
                tmp = "between '" + resultdate + " 13:00:00.567' and '" + resultdate + " 13:59:59.999'";
            }
            else if (hh == "14")
            {
                tmp = "between '" + resultdate + " 14:00:00.567' and '" + resultdate + " 14:59:59.999'";
            }
            else if (hh == "15")
            {
                tmp = "between '" + resultdate + " 15:00:00.567' and '" + resultdate + " 15:59:59.999'";
            }
            else if (hh == "16")
            {
                tmp = "between '" + resultdate + " 16:00:00.567' and '" + resultdate + " 16:59:59.999'";
            }
            else if (hh == "17")
            {
                tmp = "between '" + resultdate + " 17:00:00.567' and '" + resultdate + " 17:59:59.999'";
            }

            else if (hh == "18")
            {
                tmp = "between '" + resultdate + " 18:00:00.567' and '" + resultdate + " 18:59:59.999'";
            }
            else if (hh == "19")
            {
                tmp = "between '" + resultdate + " 19:00:00.567' and '" + resultdate + " 20:59:59.999'";
            }

            else if (hh == "20")
            {
                tmp = "between '" + resultdate + " 20:00:00.567' and '" + resultdate + " 21:59:59.999'";
            }
            else if (hh == "21")
            {
                tmp = "between '" + resultdate + " 21:00:00.567' and '" + resultdate + " 22:59:59.999'";
            }

            string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL"];
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                lbloutput.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand("select top 1 sum(qty) as umqty,remark from dbo.Sewing_DtlBarcode where barcodedate " + tmp + "  and TypeCell ='" + tmpcell + "' group by remark order by sum(qty)", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                   string outnum = rs["umqty"].ToString();

                   lbloutput.Text = Convert.ToDouble(outnum).ToString("#,###0");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No per hrs.");
                lbloutput.Text = "0";
            }
            conn.Close();

        
        }

         #endregion
    }
}
