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

namespace PicklistBOM.MonitorCell
{
    public partial class FrmCellShowMonitor : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        public FrmCellShowMonitor()
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

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmCellShowMonitor_Load(object sender, EventArgs e)
        {
           string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
           showOnMonitor(Convert.ToInt16(str));

            string y = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
            lblyear.Text = y;
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss", new System.Globalization.CultureInfo("en-US"));

            CallWeek();
            CallCalulateSumTotal();
            CallsumTotal();
            CallMonth("lbljan","%01/"+y);
            CallMonth("lblfeb", "%02/" + y);
            CallMonth("lblmar", "%03/" + y);
            CallMonth("lblapr", "%04/" + y);
            CallMonth("lblmay", "%05/" + y);
            CallMonth("lbljun", "%06/" + y);
            CallMonth("lbljul", "%07/" + y);
            CallMonth("lblaug", "%08/" + y);
            CallMonth("lblsep", "%09/" + y);
            CallMonth("lbloct", "%10/" + y);
            CallMonth("lblnov", "%11/" + y);
            CallMonth("lbldec", "%12/" + y);
        }

        #region "CallMonth"
        private void CallMonth(string M, string my)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(TotalOutput) as MonthOut from dbo.Line_MonitorWeek where  TagetDate like '" + my + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String num = Convert.ToDouble(rs["MonthOut"]).ToString("#,###0");
                    if (M == "lbljan")
                    {
                        lbljan.Text = num;
                    }
                    else if (M == "lblfeb")
                    {
                        lblfeb.Text = num;
                    }
                    else if (M == "lblmar")
                    {
                        lblmar.Text = num;
                    }

                    else if (M == "lblapr")
                    {
                        lblapr.Text = num;
                    }

                    else if (M == "lblmay")
                    {
                        lblmay.Text = num;
                    }

                    else if (M == "lbljun")
                    {
                        lbljun.Text = num;
                    }

                    else if (M == "lbljul")
                    {
                        lbljul.Text = num;
                    }

                    else if (M == "lblaug")
                    {
                        lblaug.Text = num;
                    }

                    else if (M == "lblsep")
                    {
                        lblsep.Text = num;
                    }

                    else if (M == "lbloct")
                    {
                        lbloct.Text = num;
                    }

                    else if (M == "lblnov")
                    {
                        lblnov.Text = num;
                    }

                    else if (M == "lbldec")
                    {
                        lbldec.Text = num;
                    }
         

                }


            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }

        #endregion


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
                mon = Convert.ToDouble(lblMonM.Text);
            }
            if (lblTueM.Text != "-")
            {
                tue = Convert.ToDouble(lblTueM.Text);
            }
            if (lblWebM.Text != "-")
            {
                web = Convert.ToDouble(lblWebM.Text);
            }
            if (lblThdM.Text != "-")
            {
                tud = Convert.ToDouble(lblThdM.Text);
            }
            if (lblFriM.Text != "-")
            {
                fri = Convert.ToDouble(lblFriM.Text);
            }
            if (lblSatM.Text != "-")
            {
                sat = Convert.ToDouble(lblSatM.Text);
            }
            totalwk = mon + tue + web + tud + fri + sat;
            lblwktotal.Text = totalwk.ToString("#,###");

        }

        #endregion

        #region "   CallWeek();"
        private void CallWeek()
        {
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
               // this.lblSatM.BackColor = Color.Red;
                this.lblSatM.ForeColor = Color.Red;
                //วันเสาร์
                CallSearchWeek(day);
               // lblSat.Text = CGlobal.DayweekTotal;
                lblSatM.Text = CGlobal.DayweekTotal;
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotal;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
              //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
              //  lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

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
                lblMonM.Text = CGlobal.DayweekTotal;
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
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

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
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
              //  lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

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
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
              //  lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

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
                lblFriM.Text = CGlobal.DayweekTotal;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
               // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
               // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;

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
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_MonitorWeek "
              + " Where TagetDate='" + temdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.DayweekTotal = rs["TotalOutput"].ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #region "CallCalulateSumTotal()"
        private void CallCalulateSumTotal()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select TotalTarget,TotalOutput  from dbo.Line_MonitorWeek where TagetDate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String num = Convert.ToDouble(rs["TotalOutput"]).ToString("#,###0");
                    lbltotalPM.Text = num;
                    String num1 = Convert.ToDouble(rs["TotalTarget"]).ToString("#,###0");
                    lbltargetPM.Text = num1;

                }


            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }

        #endregion 

        private void timer2_Tick(object sender, EventArgs e)
        {

            //lbljan.Text="0";
            //lblfeb.Text="0";
            //lblmar.Text="0";
            //lblapr.Text="0";
            //lblmay.Text="0";
            //lbljun.Text="0";
            //lbljul.Text="0";
            //lblaug.Text="0";
            //lblsep.Text="0";
            //lbloct.Text="0";
            //lblnov.Text="0";
            //lbldec.Text = "0";



            timer2.Start();

            string y = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
            lblyear.Text = y;
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss", new System.Globalization.CultureInfo("en-US"));
            string ydate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            lbldate.Text = ydate;
            string Ymonth = DateTime.Now.ToString("MM", new System.Globalization.CultureInfo("en-US"));

            CallWeek();
            CallCalulateSumTotal();
            CallsumTotal();
            if (Ymonth == "01")
            { CallMonth("lbljan", "%01/" + y); }
            else if (Ymonth == "02")
            { CallMonth("lblfeb", "%02/" + y); }
            else if (Ymonth == "03")
            { CallMonth("lblmar", "%03/" + y); }
            else if (Ymonth == "04")
            { CallMonth("lblapr", "%04/" + y); }
            else if (Ymonth == "05")
            { CallMonth("lblmay", "%05/" + y); }
            else if (Ymonth == "06")
            { CallMonth("lbljun", "%06/" + y); }
            else if (Ymonth == "07")
            { CallMonth("lbljul", "%07/" + y); }
            else if (Ymonth == "08")
            { CallMonth("lblaug", "%08/" + y); }
            else if (Ymonth == "09")
            { CallMonth("lblsep", "%09/" + y); }
            else if (Ymonth == "10")
            { CallMonth("lbloct", "%10/" + y); }
            else if (Ymonth == "11")
            { CallMonth("lblnov", "%11/" + y); }
            else if (Ymonth == "12")
            { CallMonth("lbldec", "%12/" + y); }
          



            string M = DateTime.Now.ToString("MM", new System.Globalization.CultureInfo("en-US"));

            if (M == "01")
            {
                //lbljan.BackColor = Color.Red;
                lbljan.ForeColor = Color.Red;
            }
            else if (M == "02")
            {
               // lblfeb.BackColor = Color.Red;
                lblfeb.ForeColor = Color.Red;
            }
            else if (M == "03")
            {
               // lblmar.BackColor = Color.Red;
                lblmar.ForeColor = Color.Red;
            }
            else if (M == "04")
            {
              //  lblapr.BackColor = Color.Red;
                lblapr.ForeColor = Color.Red;
            }
            else if (M == "05")
            {
               // lblmay.BackColor = Color.Red;
                lblmay.ForeColor = Color.Red;
            }
            else if (M == "06")
            {
              //  lbljun.BackColor = Color.Red;
                lbljun.ForeColor = Color.Red;
            }
            else if (M == "07")
            {
             //   lbljul.BackColor = Color.Red;
                lbljul.ForeColor = Color.Red;
            }
            else if (M == "08")
            {
              //  lblaug.BackColor = Color.Red;
                lblaug.ForeColor = Color.Red;
            }
            else if (M == "09")
            {
               // lblsep.BackColor = Color.Red;
                lblsep.ForeColor = Color.Red;
            }
            else if (M == "10")
            {
                //lbloct.BackColor = Color.Red;
                lbloct.ForeColor = Color.Red;
            }
            else if (M == "11")
            {
              //  lblnov.BackColor = Color.Red;
                lblnov.ForeColor = Color.Red;
            }
            else if (M == "12")
            {
               // lbldec.BackColor = Color.Red;
                lbldec.ForeColor = Color.Red;
            }

            double numtoal = Convert.ToDouble(lbljan.Text) + Convert.ToDouble(lblfeb.Text) + Convert.ToDouble(lblmar.Text) + Convert.ToDouble(lblapr.Text) + Convert.ToDouble(lblmay.Text) + Convert.ToDouble(lbljun.Text)
                + Convert.ToDouble(lbljul.Text) + Convert.ToDouble(lblaug.Text) + Convert.ToDouble(lblsep.Text) + Convert.ToDouble(lbloct.Text) + Convert.ToDouble(lblnov.Text) + Convert.ToDouble(lbldec.Text);
            lbltotalyear.Text = numtoal.ToString("#,###0");

        }


    }
}
