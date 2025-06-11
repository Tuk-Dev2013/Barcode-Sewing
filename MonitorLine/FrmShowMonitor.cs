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

namespace PicklistBOM.MonitorLine
{
    public partial class FrmShowMonitor : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        private int int_XPos = 0, int_YPos = 656;

        public FrmShowMonitor()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

      
           CallSearchDate();
           CallWeek();
           SumQty();
           CallCalulateSumTotal();
       
            
        }

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
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) as SumTotal from dbo.DocMODtlBarcode where Sdate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String num = Convert.ToDouble(rs["SumTotal"]).ToString("#,###0");
                    this.lbltotal.Text = (Convert.ToDouble(CGlobal.TotalOutput29) + Convert.ToDouble(num)).ToString("#,###0");
                    UpdateMonitorWeek(this.lbltotal.Text);
                    CGlobal.TotalOutput29 ="0";
                    //update target day
                    
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }

        #endregion 

        #region "UpdateMonitorWeek()"
        private void UpdateMonitorWeek(String tmpQty)
        {
            string tempday = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_MonitorWeek SET");
            query.Append(" TotalOutput  = @TotalOutput");
            query.Append(" WHERE TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@TotalOutput", tmpQty);
                    db.AddParameter("@TagetDate", tempday);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }

        }
        #endregion 



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

        private void FrmShowMonitor_Load(object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            CallSearchDate();

           // CallWeek();

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));
            this.lblProduct.Text = ConfigurationManager.AppSettings["SHOW_Line"];



            CallSearchDate();
            CallWeek();
            SumQty();
            CallCalulateSumTotal();
        }

        #region "SumQty()"
        private void SumQty()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
          string tempsql = ConfigurationManager.AppSettings["SHOW_CELL"];
            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Sum(Qty) As total FROM  DocMODtlBarcodeLine where TypeCell ='" + tempsql + "' and Sdate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String num = Convert.ToDouble(rs["total"]).ToString("#,###0");
                    lblLine.Text = num;
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
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
               this.lblSat.BackColor = Color.Red;
               this.lblSat.ForeColor = Color.GhostWhite;
               //วันเสาร์
               CallSearchWeek(day);
               lblSat.Text = CGlobal.DayweekTotal;
               //วันศุกร์
               string tmpD1=DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD1);
               lblFri.Text = CGlobal.DayweekTotal;
               //วันพฤหสบดี
               string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD2);
               lblThd.Text = CGlobal.DayweekTotal;
               //วันพุธ
               string tmpD3= DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD3);
               lblWeb.Text = CGlobal.DayweekTotal;
               //วันอังคาร
               string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD4);
               lblTue.Text = CGlobal.DayweekTotal;
               //วันจันทร์
               string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD5);
               lblMon.Text = CGlobal.DayweekTotal;
           
           }
           else if (temday == "Mon")
           {
               this.lblMon.BackColor = Color.Red;
               this.lblMon.ForeColor = Color.GhostWhite;
               //วันจันทร์
               CallSearchWeek(day);
               lblMon.Text = CGlobal.DayweekTotal;
               lblTue.Text = "-";
               lblWeb.Text = "-";
               lblThd.Text = "-";
               lblFri.Text = "-";
               lblSat.Text = "-";

           }
           else if (temday == "Tue")
           {
               this.lblTue.BackColor = Color.Red;
               this.lblTue.ForeColor = Color.GhostWhite;
               //วันอังคาร
               CallSearchWeek(day);
               lblTue.Text = CGlobal.DayweekTotal;
               //วันจันทร์
               string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD1);
               lblMon.Text = CGlobal.DayweekTotal;
    
               lblWeb.Text = "-";
               lblThd.Text = "-";
               lblFri.Text = "-";
               lblSat.Text = "-";


           }

           else if (temday == "Wed")
           {
               this.lblWeb.BackColor = Color.Red;
               this.lblWeb.ForeColor = Color.GhostWhite;
               //วันพุธ
               CallSearchWeek(day);
               lblWeb.Text = CGlobal.DayweekTotal;
               //วันจันทร์
               string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD1);
               lblMon.Text = CGlobal.DayweekTotal;

               //วันอังคาร
               string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD2);
               lblTue.Text = CGlobal.DayweekTotal;

               lblThd.Text = "-";
               lblFri.Text = "-";
               lblSat.Text = "-";


           }
           else if (temday == "Thu")
           {
               this.lblThd.BackColor = Color.Red;
               this.lblThd.ForeColor = Color.GhostWhite;
               //วันพฤ
               CallSearchWeek(day);
               lblThd.Text = CGlobal.DayweekTotal;
               //วันจันทร์
               string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD1);
               lblMon.Text = CGlobal.DayweekTotal;

               //วันอังคาร
               string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD2);
               lblTue.Text = CGlobal.DayweekTotal;

               //วันพุธ
               string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD3);
               lblWeb.Text = CGlobal.DayweekTotal;

               lblFri.Text = "-";
               lblSat.Text = "-";

           }
           else if (temday == "Fri")
           {
               this.lblFri.BackColor = Color.Red;
               this.lblFri.ForeColor = Color.GhostWhite;
               //วันศุก
               CallSearchWeek(day);
               lblFri.Text = CGlobal.DayweekTotal;

               //วันจันทร์
               string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD1);
               lblMon.Text = CGlobal.DayweekTotal;


               //วันอังคาร
               string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD2);
               lblTue.Text = CGlobal.DayweekTotal;

               //วันพุธ
               string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD3);
               lblWeb.Text = CGlobal.DayweekTotal;

               //วันพฤ
               string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
               CallSearchWeek(tmpD4);
               lblThd.Text = CGlobal.DayweekTotal;

               lblSat.Text = "-";

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

        #region"  CallSearchDate()"
        private void CallSearchDate()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_Monitor "
              + " Where TagetDate='" + this.lbldate.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                   lbltotaltarget.Text = rs["TodayTraget"].ToString();

                    //วิ่งหาเวลา
                   string txt8  = rs["total8"].ToString();

                   if (txt8 != "0")
                   {
                       lbltimeI.Text = "08:00-09:00";
                       lblsum.Text = txt8;
                   }

                   string txt9  = rs["total9"].ToString();

                   if (txt9 != "0")
                   {
                       lbltimeI.Text = "09.00-10:00";
                       lblsum.Text = txt9;
                   }

                   string txt10 = rs["total10"].ToString();
                   if (txt10 != "0")
                   {
                       lbltimeI.Text = "10.00-11:00";
                       lblsum.Text = txt10;
                   }
                   string txt11 = rs["total11"].ToString();
                   if (txt11 != "0")
                   {
                       lbltimeI.Text = "11.00-12:00";
                       lblsum.Text = txt11;
                   }
                   string txt13 = rs["total13"].ToString();
                   if (txt13 != "0")
                   {
                       lbltimeI.Text = "13.00-14:00";
                       lblsum.Text = txt13;
                   }
                   string txt14 = rs["total14"].ToString();
                   if (txt14 != "0")
                   {
                       lbltimeI.Text = "14.00-15:00";
                       lblsum.Text = txt14;
                   }
                   string txt15 = rs["total15"].ToString();
                   if (txt15 != "0")
                   {
                       lbltimeI.Text = "15.00-16:00";
                       lblsum.Text = txt15;
                   }
                   string txt16 = rs["total16"].ToString();
                   if (txt16 != "0")
                   {
                       lbltimeI.Text = "16.00-17:00";
                       lblsum.Text = txt16;
                   }
                   string txt17 = rs["total17"].ToString();
                   if (txt17 != "0")
                   {
                       lbltimeI.Text = "17.30-18:30";
                       lblsum.Text = txt17;
                   }
                   string txt18 = rs["total18"].ToString();
                   if (txt18 != "0")
                   {
                       lbltimeI.Text = "18.30-19:30";
                       lblsum.Text = txt18;
                   }
                   string txt19 = rs["total19"].ToString();
                   if (txt19 != "0")
                   {
                    lbltimeI.Text = "19.30-20:30";
                   lblsum.Text = txt19;
                   }
                  //  lbltotal.Text = rs["TotalOutput"].ToString();

                    CGlobal.TotalOutput29 = rs["TotalOutput"].ToString();
                    lblMessage.Text = rs["Status"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            //    MessageBox.Show("No Data");
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
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

    }
}
