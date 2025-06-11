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
    public partial class Showmonitor : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind4 = false;
        public Showmonitor()
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

        #region"  CallSearchWeek()"
        private void CallSearchWeek(string temdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                CGlobal.DayweekTotalSew = "0";
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Sewing_TargetDay "
              + " Where sdate='" + temdate + "' and Cellname='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.DayweekTotalSew = Convert.ToDouble(rs["Output"].ToString()).ToString("#####0");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #region"  CallSearchWeek2()"
        private void CallSearchWeek2(string temdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                CGlobal.DayweekTotalSew = "0";
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL2"];
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Sewing_TargetDay "
              + " Where sdate='" + temdate + "' and Cellname='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.DayweekTotalSew = Convert.ToDouble(rs["Output"].ToString()).ToString("#####0");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #region "   CallWeek();"
        private void CallWeek()
        {
            CGlobal.DayweekTotalSew = "0";
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
          //  string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
            if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
            {
                //กะกลางคืน
              //  temday = DateTime.Now.AddDays(-1).ToString("ddd", new System.Globalization.CultureInfo("en-US"));
                day = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            }

           // CGlobal.DayweekTotalSew = "0";
            if (temday == "Sun")
            {
                // this.lblSatM.BackColor = Color.Red;
                this.lblSatM.ForeColor = Color.Black;
                this.lblSatM.BackColor = Color.Fuchsia;
                //วันเสาร์
                CallSearchWeek(day);
                // lblSat.Text = CGlobal.DayweekTotal;
                lblSatM.Text = CGlobal.DayweekTotalSew;

                // CGlobal.DayweekTotalSew = "0";
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                // lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotalSew;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotalSew;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                //  lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotalSew;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-6).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
                //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotalSew;

            }

            else  if (temday == "Sat")
            {
                // this.lblSatM.BackColor = Color.Red;
                this.lblSatM.ForeColor = Color.Black;
                this.lblSatM.BackColor = Color.Fuchsia;
                //วันเสาร์
                CallSearchWeek(day);
                // lblSat.Text = CGlobal.DayweekTotal;
                lblSatM.Text = CGlobal.DayweekTotalSew;

               // CGlobal.DayweekTotalSew = "0";
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
               // CGlobal.DayweekTotalSew = "0";
                //วันจันทร์
                CallSearchWeek(day);
                //lblMon.Text = CGlobal.DayweekTotal;
                //lblTue.Text = "-";
                //lblWeb.Text = "-";
                //lblThd.Text = "-";
                //lblFri.Text = "-";
                //lblSat.Text = "-";

                //  this.lblMonM.BackColor = Color.Red;
                this.lblMonM.ForeColor = Color.Black;
                this.lblMonM.BackColor = Color.Fuchsia;
              //  CGlobal.DayweekTotalSew = "0";
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
                this.lblTueM.ForeColor = Color.Black;
                this.lblTueM.BackColor = Color.Fuchsia;
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
                CGlobal.DayweekTotalSew = "0";
                this.lblWebM.ForeColor = Color.Black;
                this.lblWebM.BackColor = Color.Fuchsia;
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
                this.lblThdM.ForeColor = Color.Black;
                this.lblThdM.BackColor = Color.Fuchsia;
 
                //วันพฤ
                CallSearchWeek(day);
                // lblThd.Text = CGlobal.DayweekTotal;

               
                lblThdM.Text = CGlobal.DayweekTotalSew;
               // CGlobal.DayweekTotalSew = "0";
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
                this.lblFriM.ForeColor = Color.Black;
                this.lblFriM.BackColor = Color.Fuchsia;
   
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

        #region "   CallWeek2();"
        private void CallWeek2()
        {
            CGlobal.DayweekTotalSew = "0";
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
           // string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
            if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
            {
                //กะกลางคืน
               // temday = DateTime.Now.AddDays(-1).ToString("ddd", new System.Globalization.CultureInfo("en-US"));
                day = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            }

            // CGlobal.DayweekTotalSew = "0";

            if (temday == "Sun")
            {
                // this.lblSatM.BackColor = Color.Red;
                this.lblSatM2.ForeColor = Color.Black;
                this.lblSatM2.BackColor = Color.Fuchsia;
                //วันเสาร์
                CallSearchWeek2(day);
                lblSatM2.Text = CGlobal.DayweekTotalSew;

                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                lblFriM2.Text = CGlobal.DayweekTotalSew;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD2);
                //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM2.Text = CGlobal.DayweekTotalSew;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD3);
                lblWebM2.Text = CGlobal.DayweekTotalSew;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD4);
                lblTueM2.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-6).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD5);
                lblMonM2.Text = CGlobal.DayweekTotalSew;

            }

            else
            if (temday == "Sat")
            {
                this.lblSatM2.ForeColor = Color.Black;
                this.lblSatM2.BackColor = Color.Fuchsia;
                //วันเสาร์
                CallSearchWeek2(day);
                lblSatM2.Text = CGlobal.DayweekTotalSew;

                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                lblFriM2.Text = CGlobal.DayweekTotalSew;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD2);
                //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM2.Text = CGlobal.DayweekTotalSew;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD3);
                lblWebM2.Text = CGlobal.DayweekTotalSew;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD4);
                lblTueM2.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD5);
                lblMonM2.Text = CGlobal.DayweekTotalSew;

            }
            else if (temday == "Mon")
            {
                //วันจันทร์
                CallSearchWeek2(day);
                this.lblMonM2.ForeColor = Color.Black;
                this.lblMonM2.BackColor = Color.Fuchsia;

                //  CGlobal.DayweekTotalSew = "0";
                lblMonM2.Text = CGlobal.DayweekTotalSew;
                //  CGlobal.DayweekTotalSew = "0";
                lblTueM2.Text = "-";
                lblWebM2.Text = "-";
                lblThdM2.Text = "-";
                lblFriM2.Text = "-";
                lblSatM2.Text = "-";

            }
            else if (temday == "Tue")
            {
                this.lblTueM2.ForeColor = Color.Black;
                this.lblTueM2.BackColor = Color.Fuchsia;

                //วันอังคาร
                CallSearchWeek2(day);
                lblTueM2.Text = CGlobal.DayweekTotalSew;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                lblMonM2.Text = CGlobal.DayweekTotalSew;


                lblWebM2.Text = "-";
                lblThdM2.Text = "-";
                lblFriM2.Text = "-";
                lblSatM2.Text = "-";


            }

            else if (temday == "Wed")
            {
                CGlobal.DayweekTotalSew = "0";
                this.lblWebM2.ForeColor = Color.Black;
                this.lblWebM2.BackColor = Color.Fuchsia;

                //วันพุธ
                CallSearchWeek2(day);
                lblWebM2.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                lblMonM2.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD2);

                lblTueM2.Text = CGlobal.DayweekTotalSew;
                lblThdM2.Text = "-";
                lblFriM2.Text = "-";
                lblSatM2.Text = "-";


            }
            else if (temday == "Thu")
            {

                this.lblThdM2.ForeColor = Color.Black;
                this.lblThdM2.BackColor = Color.Fuchsia;
                //วันพฤ
                CallSearchWeek2(day);


                lblThdM2.Text = CGlobal.DayweekTotalSew;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                lblMonM2.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD2);
                lblTueM2.Text = CGlobal.DayweekTotalSew;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD3);

                lblWebM2.Text = CGlobal.DayweekTotalSew;

                lblFriM2.Text = "-";
                lblSatM2.Text = "-";

            }
            else if (temday == "Fri")
            {
                this.lblFriM2.ForeColor = Color.Black;
                this.lblFriM2.BackColor = Color.Fuchsia;

                //วันศุก
                CallSearchWeek2(day);
                //lblFri.Text = CGlobal.DayweekTotal;
                lblFriM2.Text = CGlobal.DayweekTotalSew;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD1);
                //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM2.Text = CGlobal.DayweekTotalSew;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD2);
                // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM2.Text = CGlobal.DayweekTotalSew;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD3);
                // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM2.Text = CGlobal.DayweekTotalSew;

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek2(tmpD4);
                // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM2.Text = CGlobal.DayweekTotalSew;

                lblSatM2.Text = "-";

            }


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
            lblwktotal.Text = totalwk.ToString("#,###0");

        }

        #endregion

        #region "sumtotal2"
        private void CallsumTotal2()
        {
            // sum total time
            double mon = 0;
            double tue = 0;
            double web = 0;
            double tud = 0;
            double fri = 0;
            double sat = 0;
            double totalwk = 0;
            if (lblMonM2.Text != "-")
            {
                if (lblMonM2.Text == "")
                {
                    lblMonM2.Text = "0";
                }
                mon = Convert.ToDouble(lblMonM2.Text);
            }
            if (lblTueM2.Text != "-")
            {
                if (lblTueM2.Text == "")
                {
                    lblTueM2.Text = "0";
                }
                tue = Convert.ToDouble(lblTueM2.Text);
            }
            if (lblWebM2.Text != "-")
            {
                //string tmp = lblWebM.Text;
                if (lblWebM2.Text == "")
                {
                    lblWebM2.Text = "0";
                }
                web = Convert.ToDouble(lblWebM2.Text);
            }
            if (lblThdM2.Text != "-")
            {
                if (lblThdM2.Text == "")
                {
                    lblThdM2.Text = "0";
                }
                tud = Convert.ToDouble(lblThdM2.Text);
            }
            if (lblFriM2.Text != "-")
            {
                if (lblFriM2.Text == "")
                {
                    lblFriM2.Text = "0";
                }
                fri = Convert.ToDouble(lblFriM2.Text);
            }
            if (lblSatM2.Text != "-")
            {
                if (lblSatM2.Text == "")
                {
                    lblSatM2.Text = "0";
                }
                sat = Convert.ToDouble(lblSatM2.Text);
            }
            totalwk = mon + tue + web + tud + fri + sat;
            lblwktotal2.Text = totalwk.ToString("#,###0");

        }

        #endregion

        private void Showmonitor_Load(object sender, EventArgs e)
        {
            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));

            CGlobal.Frmcount = "0";
            //cell 1
            lblcellname1.Text = ConfigurationManager.AppSettings["SHOW_CELL1"];
            if (lblcellname1.Text.Trim() == "Sewing 3")
            {
                lblcellname1.Text = "Cell Sewing 9";
            }
            else if (lblcellname1.Text.Trim() == "Sewing 1")
            {
                lblcellname1.Text = "CELL Sewing 13";
            }
            else if (lblcellname1.Text.Trim() == "Cell Sewing 14")
            {
                lblcellname1.Text = "CELL Sewing 14";
            }
            else if (lblcellname1.Text.Trim() == "Sewing 2")
            {
                lblcellname1.Text = "CELL Sewing 15";
            }
            else if (lblcellname1.Text.Trim() == "Cell Sewing 16")
            {
                lblcellname1.Text = "Cell Sewing 16";
            }
            else if (lblcellname1.Text.Trim() == "Cell Sewing 17")
            {
                lblcellname1.Text = "Cell Sewing 17";
            }

            CallWeek();
            CallsumTotal();
            CallSearch();
            CallSearchWeek();
            CallPO();

            //CallAvertime();
            //Callstdtime();

            lblcellname2.Text = ConfigurationManager.AppSettings["SHOW_CELL2"];
            if (lblcellname2.Text.Trim() == "Sewing 3")
            {
                lblcellname2.Text = "Cell Sewing 9";
            }
            else if (lblcellname2.Text.Trim() == "Sewing 1")
            {
                lblcellname2.Text = "CELL(R-SOFA)13";
            }
            else if (lblcellname2.Text.Trim() == "Cell Sewing 14")
            {
                lblcellname2.Text = "CELL(R-SOFA)14";
            }
            else if (lblcellname2.Text.Trim() == "Sewing 2")
            {
                lblcellname2.Text = "CELL(SOFA)15";
            }
            else if (lblcellname2.Text.Trim() == "Cell Sewing 16")
            {
                lblcellname2.Text = "CELL(SOFA)16";
            }
            else if (lblcellname2.Text.Trim() == "Cell Sewing 17")
            {
                lblcellname2.Text = "CELL(SOFA)17";
            }
             CallWeek2();
             CallsumTotal2();
             CallSearch2();
             CallSearchWeek2();
             CallPO2();
            //lblcell.Text = ConfigurationManager.AppSettings["SHOW_CELL"];
            //lblmonitor.Text = ConfigurationManager.AppSettings["SHOW_Monitor"]; 

            //eff
             CallEffCell();


        }

        #region " CallEffCell()"
        private void  CallEffCell()
        {
            try
            {
                EffDay1.Text = "0";
                EffDay2.Text = "0"; 
                SqlConnection connection = new SqlConnection(WebConfig.GetconnectionBarcode());
                string connetionString = null;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();

                int i = 0;
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AA_GetPower_Eff_SewingCell";
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                string tmpcell2 = ConfigurationManager.AppSettings["SHOW_CELL2"];

                    if (tmpcell=="Sewing 1")
                    {
                    tmpcell="Cell Sewing 13";
                    }
                    else  if (tmpcell=="Sewing 2")
                     {
                    tmpcell="Cell Sewing 15";
                     }
                    else if (tmpcell=="Sewing 3")
                    {
                        tmpcell = "Cell Sewing 9";
                    }
                //
                    if (tmpcell2 == "Sewing 1")
                    {
                        tmpcell2 = "Cell Sewing 13";
                    }
                    else if (tmpcell2 == "Sewing 2")
                    {
                        tmpcell2 = "Cell Sewing 15";
                    }
                    else if (tmpcell == "Sewing 3")
                    {
                        tmpcell2 = "Cell Sewing 9";
                    }


                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                
                    string Cell = ds.Tables[0].Rows[i][0].ToString();
                    string Qty = ds.Tables[0].Rows[i][1].ToString();
                    string Eff = ds.Tables[0].Rows[i][2].ToString();

                    if (Cell == tmpcell)
                    {
                        EffDay1.Text = Eff;
                    }
                    else if (Cell == tmpcell2) 
                    {
                        EffDay2.Text = Eff;
                    }
                  

                }

                connection.Close();


             if (Convert.ToDouble(EffDay1.Text) < 100)
            {
                EffDay1.ForeColor = Color.OrangeRed;
            }
            else
            {
                EffDay1.ForeColor = Color.Lime;
            }
             if (Convert.ToDouble(EffDay2.Text) < 100)
             {
                 EffDay2.ForeColor = Color.OrangeRed;
             }
             else
             {
                 EffDay2.ForeColor = Color.Lime;
             }






            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.lbltime.Text = resulttime;

            //test CGlobal.CheckOn = "Yes";
          //  label33.Text = CGlobal.CheckOn;
            if (CGlobal.CheckOn == "Yes")
            {
                //cell 1
                CallWeek();
                CallsumTotal();
                CallSearch();
                CallSearchWeek();
                CallPO();

               //cell2
                CallWeek2();
                CallsumTotal2();
                CallSearch2();
                CallSearchWeek2();
                CallPO2();

                CallEffCell();
                CGlobal.CheckOn = "No";
            }
          
            
        }

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

        #region "Callstdtime()"
        private void Callstdtime()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
              //  string NextPO = ConfigurationManager.AppSettings["NextPO"];

                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
               // string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

     
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = "  select Qty,Itemmodel,SUBSTRING(Itemmodel,3,8) as tmpmodel,(select  SewingTotal from dbo.StdtimeMarkCutSewing where Style+Cover = SUBSTRING(Itemmodel,3,3)+'-'+SUBSTRING(Itemmodel,6,5)) as total1  from dbo.Sewing_DtlBarcode where TypeCell ='" + tmpcell + "' and Sdate='" + tempdate + "' and remark='BACK'";

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
                    string tmpstring = "";
                    for (int i = 0; i < ds.Tables["showstdtime"].Rows.Count; i++)
                    {
                        string Qty = ds.Tables["showstdtime"].Rows[i]["Qty"].ToString();
                        string TotalTime = ds.Tables["showstdtime"].Rows[i]["total1"].ToString();
                        string tmpmodel = ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();
                        string tmpCk = Left(tmpmodel, 3);
                        if ((TotalTime == null) || (TotalTime == ""))
                        {
                            // lblstdtime1.BackColor = Color.PaleVioletRed;
                            n = n + i;
                            tmpstring = ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();
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
                            else if ((tmpCk == "61T") || (tmpCk == "63T") || (tmpCk == "64T") || (tmpCk == "82T") || (tmpCk == "T51") || (tmpCk == "T52") || (tmpCk == "61T"))
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
                        lblstdtime1.ForeColor = Color.Orange;
                    }

                    // MessageBox.Show(Convert.ToString(sum));
                    min = sum / 60;
                    lblstdtime1.Text = min.ToString("#####0");
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
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select  *  from  dbo.Sewing_TargetDay  where  CellName ='" + tmpcell + "'and Sdate='" + tmpdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    string timeck = Left(resulttime, 2);
                    double sum = 0;
                    if (timeck == "08")
                    {
                        sum = 1 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "09")
                    {
                        sum = 2 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "10")
                    {
                        sum = 3 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "11")
                    {
                        sum = 4 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "12")
                    {
                        sum = 4 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }

                    else if (timeck == "13")
                    {
                        sum = 5 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "14")
                    {
                        sum = 6 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "15")
                    {
                        sum = 7 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else if (timeck == "16")
                    {
                        sum = 8 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }

                    else if (timeck == "17")
                    {
                        string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3, 2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 9 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }
                        else
                        {
                            sum = 8 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }
                    }
                    else if (timeck == "18")
                    {
                        string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3, 2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 10 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }
                        else
                        {
                            sum = 9 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }
                    }
                    else if (timeck == "19")
                    {
                        string resulttime1 = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                        string timeck1 = Mid(resulttime, 3, 2);
                        if (Convert.ToInt16(timeck1) > 29)
                        {
                            sum = 11 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }
                        else
                        {
                            sum = 10 * 60 * Convert.ToDouble(rs["Mantotal"]);
                        }

                    }
                    else if (timeck == "20")
                    {
                        sum = 11 * 60 * Convert.ToDouble(rs["Mantotal"]);
                    }
                    else
                    {
                        sum = 8 * 60 * Convert.ToDouble(rs["Mantotal"]);
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

        private void lineShape10_Click(object sender, EventArgs e)
        {

        }

        //#region "CallSeart()"
        //private void CallSeart(string tmpdata)
        //{
        //    System.Data.SqlClient.SqlCommand Cmd;
        //    System.Data.SqlClient.SqlDataReader rs;
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

        //    //TotalTarget11hr.Text = "0";
        //    //  lbltotal.Text = "0";
        //    try
        //    {
        //        string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL"];
        //        string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
        //        Cmd = new System.Data.SqlClient.SqlCommand("  select SUM(Qty) as totalsum from dbo.Sewing_DtlBarcode where TypeCell='" + tmpcell + "'and docno='" + lblPOCell.Text.Trim() + "'and remark='" + tmpdata + "'", conn);
        //        conn.Open();
        //        rs = Cmd.ExecuteReader();
        //        while (rs.Read())
        //        {
        //            if (tmpdata == "BODY")
        //            {
        //                double num = Convert.ToDouble(rs["totalsum"].ToString());
        //                lblbody.Text = num.ToString("#,###0");
        //            }
        //            else if (tmpdata == "BACK")
        //            {
        //                double num = Convert.ToDouble(rs["totalsum"].ToString());
        //                lblback.Text = num.ToString("#,###0");
        //            }
        //            else if (tmpdata == "SEAT")
        //            {
        //                double num = Convert.ToDouble(rs["totalsum"].ToString());
        //                lblseat.Text = num.ToString("#,###0");
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
       
        //    }
        //    conn.Close();
        //}
        //#endregion

        #region "CallSearch()"
        private void CallSearch()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            TotalTarget11hr.Text = "0";
            //  lbltotal.Text = "0";
            try
            {
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));

                string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
                if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
                {
                    //กะกลางคืน
                    tmpdate = DateTime.Now.AddDays(-1).ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                }


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT NightTarget8hr,NightTarget3hr,SewID, Mantotal, Unitperhead, target,Output, Issuedate, UserID, Target8hr, Target3hr, Total11hr,isnull(TargetAutoRun,0) as TargetAutoRun FROM  Sewing_TargetDay  where CONVERT(VARCHAR(10),Issuedate,110)='" + tmpdate.Trim() + "' and CellName='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                DateTime currentTime = DateTime.Now;
                while (rs.Read())
                {
                       

                    if ((currentTime.Hour >= 20 && currentTime.Minute >= 31) && (currentTime.Hour <= 23 && currentTime.Minute <= 59))
                    {
                    
                        TotalTarget11hr.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr.Text = Convert.ToDouble(rs["NightTarget8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr.Text = Convert.ToDouble(rs["NightTarget3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    } 
                    else if ((currentTime.Hour >= 0 && currentTime.Minute >= 0) && (currentTime.Hour <= 7 && currentTime.Minute <= 30))
                    {

                        TotalTarget11hr.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr.Text = Convert.ToDouble(rs["NightTarget8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr.Text = Convert.ToDouble(rs["NightTarget3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    }
                    else
                    {
                        TotalTarget11hr.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr.Text = Convert.ToDouble(rs["Target8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr.Text = Convert.ToDouble(rs["Target3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                // CGlobal.IssueNumber2 = "1";
            }
            conn.Close();

        }
        #endregion

        #region "CallSearch2()"
        private void CallSearch2()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            TotalTarget11hr2.Text = "0";
            //  lbltotal.Text = "0";
            try
            {
                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL2"];
                string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
                if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
                {
                    //กะกลางคืน
                    tmpdate = DateTime.Now.AddDays(-1).ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                }


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT NightTarget8hr,NightTarget3hr,SewID, Mantotal, Unitperhead, target,Output, Issuedate, UserID, Target8hr, Target3hr, Total11hr,isnull(TargetAutoRun,0) as TargetAutoRun FROM  Sewing_TargetDay  where CONVERT(VARCHAR(10),Issuedate,110)='" + tmpdate.Trim() + "' and CellName='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                DateTime currentTime = DateTime.Now;
                while (rs.Read())
                {

                    if ((currentTime.Hour >= 20 && currentTime.Minute >= 31) && (currentTime.Hour <= 23 && currentTime.Minute <= 59))
                    {
                        TotalTarget11hr2.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr2.Text = Convert.ToDouble(rs["NightTarget8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr2.Text = Convert.ToDouble(rs["NightTarget3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    }
                    else if ((currentTime.Hour >= 0 && currentTime.Minute >= 0) && (currentTime.Hour <= 7 && currentTime.Minute <= 30))
                    {
                        TotalTarget11hr2.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr2.Text = Convert.ToDouble(rs["NightTarget8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr2.Text = Convert.ToDouble(rs["NightTarget3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    }
                    else
                    {
                        TotalTarget11hr2.Text = Convert.ToDouble(rs["TargetAutoRun"].ToString()).ToString("#,###0");
                        TotalTarget8hr2.Text = Convert.ToDouble(rs["Target8hr"].ToString()).ToString("#,###0");
                        TotalTarget3hr2.Text = Convert.ToDouble(rs["Target3hr"].ToString()).ToString("#,###0");
                        CGlobal.DayweekOutputD = rs["Output"].ToString();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                // CGlobal.IssueNumber2 = "1";
            }
            conn.Close();

        }
        #endregion

        #region"  CallSearchWeek()"
        private void CallSearchWeek()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
               string temdte= DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
               if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
               {
                   //กะกลางคืน
                   temdte = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               }


                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL1"];
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Sewing_TargetDay "
              + " Where sdate='" + temdte + "' and Cellname='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbloutput.Text = Convert.ToDouble(rs["Output"].ToString()).ToString("#,###0");
                }
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();

        }

        #endregion

        #region"  CallSearchWeek2()"
        private void CallSearchWeek2()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                string temdte = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string resultMM = DateTime.Now.ToString("HH", new System.Globalization.CultureInfo("en-US"));
                if ((Convert.ToDouble(resultMM) >= 0) && (Convert.ToDouble(resultMM) <= 6))
                {
                    //กะกลางคืน
                    temdte = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }


                string tmpcell = ConfigurationManager.AppSettings["SHOW_CELL2"];
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Sewing_TargetDay "
              + " Where sdate='" + temdte + "' and Cellname='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbloutput2.Text = Convert.ToDouble(rs["Output"].ToString()).ToString("#,###0");
                }
            }
            catch (Exception ex)
            {
                return;
            }
            conn.Close();

        }

        #endregion
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

        private void CallTime8(string time1, string time2, string temp)
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
                String cellPO = ConfigurationManager.AppSettings["SHOW_CELL1"];

                Cmd = new System.Data.SqlClient.SqlCommand(" select  top 1 SUM(Qty) as totalsum from dbo.Sewing_DtlBarcode where Sdate='" + resultdate1 + "' and TypeCell ='" + cellPO + "' and Barcodedate  between '" + t1 + "' and ' " + t2 + "'  group by remark ", conn);
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

                    if (temp == "8")
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

        #region " CallPO()"
        private void CallPO()
        {
            lblPO2.Text = "-";
            lblPO3.Text = "-";
            lblPO4.Text = "-";
            lblPO5.Text = "-";
            String cellPO = ConfigurationManager.AppSettings["SHOW_CELL1"];
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select top(4)Docno,Cellname,Qtyin,Qtyout,qtyback,qtyseat,qtybody,tmpCk FROM  dbo.Sewing_Schedule where cellname ='" + cellPO + "' and Qtyin<>Qtyout order by sequence";
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
                         string QtyOut = ds.Tables["ShowdataCELL"].Rows[i]["QtyOut"].ToString();

                         string tmpCk = ds.Tables["ShowdataCELL"].Rows[i]["tmpCk"].ToString();
                        //string qtyseat = ds.Tables["ShowdataCELL"].Rows[i]["qtyseat"].ToString();
                        //string qtybody = ds.Tables["ShowdataCELL"].Rows[i]["qtybody"].ToString();

                        if (i == 0)
                        {
                            if (tmpCk == "-")
                            {
                                lblPOCell.Text = "Q1:" + Docno;
                            }
                            else
                            {
                                lblPOCell.Text = "Q1:" + Docno + "(" + tmpCk + ")";
                            }
                        
                            lblbatch.Text = QtyIn;
                            lblactual.Text = QtyOut;
                            double n = Convert.ToDouble(QtyIn) - Convert.ToDouble(QtyOut);
                            lblbalance.Text = "-" + n.ToString();
                            //lblseat.Text = qtyseat;
                            //lblback.Text = qtyback;

                        }
                        else if (i == 1)
                        {
                            if (tmpCk=="-")
                            {
                                lblPO2.Text = Docno; 
                            }
                            else
                            {
                                lblPO2.Text = Docno + "(" + tmpCk + ")"; 
                            }
                            
                        }
                        else if (i == 2)
                        {
                            if (tmpCk == "-")
                            {
                                lblPO3.Text = Docno; 
                            }
                            else
                            {
                                lblPO3.Text = Docno + "(" + tmpCk + ")"; 
                            }
                       
                        }

                        else if (i == 3)
                        {
                            if (tmpCk == "-")
                            {
                                lblPO4.Text = Docno; 
                            }
                            else
                            {
                                lblPO4.Text = Docno + "(" + tmpCk + ")"; 
                            }
                            
                        }
                        else if (i == 4)
                        {
                            lblPO5.Text = Docno;
                        }
                        else if (i == 5)
                        {
                            lblPO6.Text = Docno;
                        }
                        else if (i == 6)
                        {
                          lblPO7.Text = Docno;
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


        #region " CallPO2()"
        private void CallPO2()
        {
            lblPO22.Text = "-";
            lblPO33.Text = "-";
            lblPO44.Text = "-";

            String cellPO = ConfigurationManager.AppSettings["SHOW_CELL2"];
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select top(4)Docno,Cellname,Qtyin,Qtyout,qtyback,qtyseat,qtybody,tmpCk FROM  dbo.Sewing_Schedule where cellname ='" + cellPO + "' and Qtyin<>Qtyout order by sequence";
                if (Isfind2 == true)
                {
                    ds.Tables["ShowdataCELL2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataCELL2");

                if (ds.Tables["ShowdataCELL2"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["ShowdataCELL2"];
                    int num = ds.Tables["ShowdataCELL2"].Rows.Count;
                    for (int i = 0; i < ds.Tables["ShowdataCELL2"].Rows.Count; i++)
                    {
                        string Docno = ds.Tables["ShowdataCELL2"].Rows[i]["Docno"].ToString();
                        string QtyIn = ds.Tables["ShowdataCELL2"].Rows[i]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["ShowdataCELL2"].Rows[i]["QtyOut"].ToString();

                        string tmpCk = ds.Tables["ShowdataCELL2"].Rows[i]["tmpCk"].ToString();
                       

                        if (i == 0)
                        {
                            if (tmpCk == "-")
                            {
                                lblPOCell2.Text = "Q1:" + Docno;
                            }
                            else
                            {
                                lblPOCell2.Text = "Q1:" + Docno + "(" + tmpCk + ")";
                            }

                            lblbatch2.Text = QtyIn;
                            lblactual2.Text = QtyOut;
                            double n = Convert.ToDouble(QtyIn) - Convert.ToDouble(QtyOut);
                            lblbalance2.Text = "-" + n.ToString();
                           // lblseat.Text = qtyseat;
                            //lblback.Text = qtyback;

                        }
                        else if (i == 1)
                        {
                            if (tmpCk == "-")
                            {
                                lblPO22.Text = Docno;
                            }
                            else
                            {
                                lblPO22.Text = Docno + "(" + tmpCk + ")";
                            }

                        }
                        else if (i == 2)
                        {
                            if (tmpCk == "-")
                            {
                                lblPO33.Text = Docno;
                            }
                            else
                            {
                                lblPO33.Text = Docno + "(" + tmpCk + ")";
                            }

                        }

                        else if (i == 3)
                        {
                            if (tmpCk == "-")
                            {
                                lblPO44.Text = Docno;
                            }
                            else
                            {
                                lblPO44.Text = Docno + "(" + tmpCk + ")";
                            }

                        }
                     
                    }



                }
                else
                {
                    Isfind2 = false;

                    return;
                }

            }
            catch (Exception ex)
            {

            }
            conn.Close();


        }

        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            //cell 1
            CallWeek();
            CallsumTotal();
            CallSearch();
            CallSearchWeek();
            CallPO();

            //cell2
            CallWeek2();
            CallsumTotal2();
            CallSearch2();
            CallSearchWeek2();
            CallPO2();

            CallEffCell();
         
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }
    }
}
