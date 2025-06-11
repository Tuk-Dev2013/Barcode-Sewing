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
using System.Timers;

namespace PicklistBOM.SumCell
{
    public partial class frmSum : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public frmSum()
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

        private void frmSum_Load(object sender, EventArgs e)
        {
            CallWeek();
            CallDay();

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));
        }


        #region " CallWeek()"
        private void CallWeek()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select Week from dbo.Leather_Day where Sdate ='" +tempdate +"'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.wk.Text = "W" + rs["Week"].ToString();
                  
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


        }
        #endregion

        #region "CallTagetDayCell0"
        private void CallTagetDayCell0(string day,string cell,String tmpday)
       {
           System.Data.SqlClient.SqlCommand Cmd;
           System.Data.SqlClient.SqlDataReader rs;
           SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
           try
           {
               Cmd = new System.Data.SqlClient.SqlCommand(" select TargetOutput from dbo.DocMODtlTarget  Where Sdate ='" + day + "' and  Status='" +cell +"'", conn);
               conn.Open();
               rs = Cmd.ExecuteReader();
               while (rs.Read())
               {
                   if (tmpday == "Sat")
                   {
                       if (cell == "CELL")
                       {
                           this.SC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.SC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.SC2T.Text = rs["TargetOutput"].ToString();
                       }
                   }
                   else if (tmpday == "Fri")
                   {
                       if (cell == "CELL")
                       {
                           this.FC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.FC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.FC2T.Text = rs["TargetOutput"].ToString();
                       }
                   
                   }

                   else if (tmpday == "Thu")
                   {
                       if (cell == "CELL")
                       {
                           this.THC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.THC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.THC2T.Text = rs["TargetOutput"].ToString();
                       }
                   }
                   else if (tmpday == "Wed")
                   {
                       if (cell == "CELL")
                       {
                           this.WC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.WC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.WC2T.Text = rs["TargetOutput"].ToString();
                       }
                   }
                   else if (tmpday == "Tue")
                   {
                       if (cell == "CELL")
                       {
                           this.TC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.TC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.TC2T.Text = rs["TargetOutput"].ToString();
                       }
                   }
                   else if (tmpday == "Mon")
                   {
                       if (cell == "CELL")
                       {
                           this.MC0T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 1")
                       {
                           this.MC1T.Text = rs["TargetOutput"].ToString();
                       }
                       else if (cell == "CELL 2")
                       {
                           this.MC2T.Text = rs["TargetOutput"].ToString();
                       }
                   }


               }
               conn.Close();
           }
           catch (Exception ex)
           {
             //  MessageBox.Show("Error" + ex);
           }
        
        
        }

        #endregion
   

        //Actual
        private void CallActualDayCell0(String day, String cell, String tmpday)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As SumQty from dbo.DocMODtlBarcode  Where Sdate ='" + day + "' and  TypeCell='" + cell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                   Double sum = Convert.ToDouble(rs["SumQty"].ToString());
                   if (tmpday == "Sat")
                   {
                       if (cell == "CELL")
                       {
                           SC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           SC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           SC2A.Text = sum.ToString("###0");
                       }
                   }
                   else if (tmpday == "Fri")
                   {
                       if (cell == "CELL")
                       {
                           FC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           FC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           FC2A.Text = sum.ToString("###0");
                       }
                   }
                   else if (tmpday == "Thu")
                   {
                       if (cell == "CELL")
                       {
                           THC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           THC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           THC2A.Text = sum.ToString("###0");
                       }
                   }
                   else if (tmpday == "Wed")
                   {
                       if (cell == "CELL")
                       {
                           WC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           WC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           WC2A.Text = sum.ToString("###0");
                       }
                   }
                   else if (tmpday == "Wed")
                   {
                       if (cell == "CELL")
                       {
                           WC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           WC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           WC2A.Text = sum.ToString("###0");
                       }
                   }

                   else if (tmpday == "Tue")
                   {
                       if (cell == "CELL")
                       {
                           TC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           TC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           TC2A.Text = sum.ToString("###0");
                       }
                   }
                   else if (tmpday == "Mon")
                   {
                       if (cell == "CELL")
                       {
                           MC0A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 1")
                       {
                           MC1A.Text = sum.ToString("###0");
                       }
                       else if (cell == "CELL 2")
                       {
                           MC2A.Text = sum.ToString("###0");
                       }
                   }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error" + ex);
            }
        
        }

        #region " CallDay();"
        private void CallDay()
        {
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
                this.SC0A.ForeColor = Color.Red;
                this.SC1A.ForeColor = Color.Red;
                this.SC2A.ForeColor = Color.Red;
                this.lblsat.ForeColor = Color.Red;

                //Target
                CallTagetDayCell0(day, "CELL","Sat");
                CallTagetDayCell0(day, "CELL 1", "Sat");
                CallTagetDayCell0(day, "CELL 2", "Sat");

                //Actual
                CallActualDayCell0(day, "CELL", "Sat");
                CallActualDayCell0(day, "CELL 1", "Sat");
                CallActualDayCell0(day, "CELL 2", "Sat");



                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD1, "CELL", "Fri");
                CallTagetDayCell0(tmpD1, "CELL 1", "Fri");
                CallTagetDayCell0(tmpD1, "CELL 2", "Fri");

                //Actual
                CallActualDayCell0(tmpD1, "CELL", "Fri");
                CallActualDayCell0(tmpD1, "CELL 1", "Fri");
                CallActualDayCell0(tmpD1, "CELL 2", "Fri");


                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD2, "CELL", "Thu");
                CallTagetDayCell0(tmpD2, "CELL 1", "Thu");
                CallTagetDayCell0(tmpD2, "CELL 2", "Thu");

                //Actual
                CallActualDayCell0(tmpD2, "CELL", "Thu");
                CallActualDayCell0(tmpD2, "CELL 1", "Thu");
                CallActualDayCell0(tmpD2, "CELL 2", "Thu");

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD3, "CELL", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 1", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 2", "Wed");

                //Actual
                CallActualDayCell0(tmpD3, "CELL", "Wed");
                CallActualDayCell0(tmpD3, "CELL 1", "Wed");
                CallActualDayCell0(tmpD3, "CELL 2", "Wed");
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD4, "CELL", "Tue");
                CallTagetDayCell0(tmpD4, "CELL 1", "Tue");
                CallTagetDayCell0(tmpD4, "CELL 2", "Tue");

                //Actual
                CallActualDayCell0(tmpD4, "CELL", "Tue");
                CallActualDayCell0(tmpD4, "CELL 1", "Tue");
                CallActualDayCell0(tmpD4, "CELL 2", "Tue");
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD5, "CELL", "Mon");
                CallTagetDayCell0(tmpD5, "CELL 1", "Mon");
                CallTagetDayCell0(tmpD5, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(tmpD5, "CELL", "Mon");
                CallActualDayCell0(tmpD5, "CELL 1", "Mon");
                CallActualDayCell0(tmpD5, "CELL 2", "Mon");

            }
            else if (temday == "Mon")
            {
                this.MC0A.ForeColor = Color.Red;
                this.MC1A.ForeColor = Color.Red;
                this.MC2A.ForeColor = Color.Red;
                 this.lblmon.ForeColor = Color.Red;

                //วันจันทร์
                //Target
                CallTagetDayCell0(day, "CELL", "Mon");
                CallTagetDayCell0(day, "CELL 1", "Mon");
                CallTagetDayCell0(day, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(day, "CELL", "Mon");
                CallActualDayCell0(day, "CELL 1", "Mon");
                CallActualDayCell0(day, "CELL 2", "Mon");

            }
            else if (temday == "Tue")
            {
                this.TC0A.ForeColor = Color.Red;
                this.TC1A.ForeColor = Color.Red;
                this.TC2A.ForeColor = Color.Red;
                this.lbltue.ForeColor = Color.Red;
                //วันอังคาร
                CallTagetDayCell0(day, "CELL", "Tue");
                CallTagetDayCell0(day, "CELL 1", "Tue");
                CallTagetDayCell0(day, "CELL 2", "Tue");

                //Actual
                CallActualDayCell0(day, "CELL", "Tue");
                CallActualDayCell0(day, "CELL 1", "Tue");
                CallActualDayCell0(day, "CELL 2", "Tue");
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD1, "CELL", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 1", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(tmpD1, "CELL", "Mon");
                CallActualDayCell0(tmpD1, "CELL 1", "Mon");
                CallActualDayCell0(tmpD1, "CELL 2", "Mon");
    


            }

            else if (temday == "Wed")
            {
                this.WC0A.ForeColor = Color.Red;
                this.WC1A.ForeColor = Color.Red;
                this.WC2A.ForeColor = Color.Red;
                this.lblwed.ForeColor = Color.Red;
                //วันพุธ
                //Target
                CallTagetDayCell0(day, "CELL", "Wed");
                CallTagetDayCell0(day, "CELL 1", "Wed");
                CallTagetDayCell0(day, "CELL 2", "Wed");

                //Actual
                CallActualDayCell0(day, "CELL", "Wed");
                CallActualDayCell0(day, "CELL 1", "Wed");
                CallActualDayCell0(day, "CELL 2", "Wed");
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD1, "CELL", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 1", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(tmpD1, "CELL", "Mon");
                CallActualDayCell0(tmpD1, "CELL 1", "Mon");
                CallActualDayCell0(tmpD1, "CELL 2", "Mon");

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD2, "CELL", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 1", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 2", "Tue");

                //Actual
                CallActualDayCell0(tmpD2, "CELL", "Tue");
                CallActualDayCell0(tmpD2, "CELL 1", "Tue");
                CallActualDayCell0(tmpD2, "CELL 2", "Tue");

            }
            else if (temday == "Thu")
            {
                this.THC0A.ForeColor = Color.Red;
                this.THC1A.ForeColor = Color.Red;
                this.THC2A.ForeColor = Color.Red;
                this.lblthu.ForeColor = Color.Red;
                //วันพฤ
                //Target
                CallTagetDayCell0(day, "CELL", "Thu");
                CallTagetDayCell0(day, "CELL 1", "Thu");
                CallTagetDayCell0(day, "CELL 2", "Thu");

                //Actual
                CallActualDayCell0(day, "CELL", "Thu");
                CallActualDayCell0(day, "CELL 1", "Thu");
                CallActualDayCell0(day, "CELL 2", "Thu");
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD1, "CELL", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 1", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(tmpD1, "CELL", "Mon");
                CallActualDayCell0(tmpD1, "CELL 1", "Mon");
                CallActualDayCell0(tmpD1, "CELL 2", "Mon");

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD2, "CELL", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 1", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 2", "Tue");

                //Actual
                CallActualDayCell0(tmpD2, "CELL", "Tue");
                CallActualDayCell0(tmpD2, "CELL 1", "Tue");
                CallActualDayCell0(tmpD2, "CELL 2", "Tue");

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD3, "CELL", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 1", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 2", "Wed");

                //Actual
                CallActualDayCell0(tmpD3, "CELL", "Wed");
                CallActualDayCell0(tmpD3, "CELL 1", "Wed");
                CallActualDayCell0(tmpD3, "CELL 2", "Wed");

            }
            else if (temday == "Fri")
            {
                this.FC0A.ForeColor = Color.Red;
                this.FC1A.ForeColor = Color.Red;
                this.FC2A.ForeColor = Color.Red;
                this.lblfri.ForeColor = Color.Red;
                //วันศุก
                //Target
                CallTagetDayCell0(day, "CELL", "Fri");
                CallTagetDayCell0(day, "CELL 1", "Fri");
                CallTagetDayCell0(day, "CELL 2", "Fri");

                //Actual
                CallActualDayCell0(day, "CELL", "Fri");
                CallActualDayCell0(day, "CELL 1", "Fri");
                CallActualDayCell0(day, "CELL 2", "Fri");

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD1, "CELL", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 1", "Mon");
                CallTagetDayCell0(tmpD1, "CELL 2", "Mon");

                //Actual
                CallActualDayCell0(tmpD1, "CELL", "Mon");
                CallActualDayCell0(tmpD1, "CELL 1", "Mon");
                CallActualDayCell0(tmpD1, "CELL 2", "Mon");


                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallTagetDayCell0(tmpD2, "CELL", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 1", "Tue");
                CallTagetDayCell0(tmpD2, "CELL 2", "Tue");

                //Actual
                CallActualDayCell0(tmpD2, "CELL", "Tue");
                CallActualDayCell0(tmpD2, "CELL 1", "Tue");
                CallActualDayCell0(tmpD2, "CELL 2", "Tue");
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD3, "CELL", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 1", "Wed");
                CallTagetDayCell0(tmpD3, "CELL 2", "Wed");

                //Actual
                CallActualDayCell0(tmpD3, "CELL", "Wed");
                CallActualDayCell0(tmpD3, "CELL 1", "Wed");
                CallActualDayCell0(tmpD3, "CELL 2", "Wed");

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                //Target
                CallTagetDayCell0(tmpD4, "CELL", "Thu");
                CallTagetDayCell0(tmpD4, "CELL 1", "Thu");
                CallTagetDayCell0(tmpD4, "CELL 2", "Thu");

                //Actual
                CallActualDayCell0(tmpD4, "CELL", "Thu");
                CallActualDayCell0(tmpD4, "CELL 1", "Thu");
                CallActualDayCell0(tmpD4, "CELL 2", "Thu");

            }

        
        
        
        }

        #endregion

        #region "CallSum();"
        private void CallSum()
        {
           /// sum Actual
            double cell0 = 0;
            if (MC0T.Text == "-")
            {
                totalc0t.Text = "0";
            }
            else
            {
                cell0 = Convert.ToDouble(MC0T.Text);
            }
            if (TC0T.Text == "-")
            {
                totalc0t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(TC0T.Text);
            }
            if (WC0T.Text == "-")
            {
                totalc0t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(WC0T.Text);
            }
            if (THC0T.Text == "-")
            {
                totalc0t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(THC0T.Text);
            }
            if (FC0T.Text == "-")
            {
                totalc0t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(FC0T.Text);
            }
            if (SC0T.Text == "-")
            {
                totalc0t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(SC0T.Text);
            }
            totalc0t.Text = cell0.ToString("####0");



            /// sum Actual
            double cellsum = 0;
            if (MC0A.Text == "-")
            {
                totalc0a.Text = "0";
            }
            else
            {
                cellsum = Convert.ToDouble(MC0A.Text);
            }
            if (TC0A.Text == "-")
            {
                totalc0a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(TC0A.Text);
            }
            if (WC0A.Text == "-")
            {
                totalc0a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(WC0A.Text);
            }
            if (THC0A.Text == "-")
            {
                totalc0a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(THC0A.Text);
            }
            if (FC0A.Text == "-")
            {
                totalc0a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(FC0A.Text);
            }
            if (SC0A.Text == "-")
            {
                totalc0a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(SC0A.Text);
            }
            totalc0a.Text = cellsum.ToString("####0");

        
        }
        #endregion

        #region "CallSumCell1();"
        private void CallSumCell1()
        {
            /// sum Actual
            double cell0 = 0;
            if (MC1T.Text == "-")
            {
                totalc1t.Text = "0";
            }
            else
            {
                cell0 = Convert.ToDouble(MC1T.Text);
            }
            if (TC1T.Text == "-")
            {
                totalc1t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(TC1T.Text);
            }
            if (WC1T.Text == "-")
            {
                totalc1t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(WC1T.Text);
            }
            if (THC1T.Text == "-")
            {
                totalc1t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(THC1T.Text);
            }
            if (FC1T.Text == "-")
            {
                totalc1t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(FC1T.Text);
            }
            if (SC1T.Text == "-")
            {
                totalc1t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(SC1T.Text);
            }
            totalc1t.Text = cell0.ToString("####0");



            /// sum Actual
            double cellsum = 0;
            if (MC1A.Text == "-")
            {
                totalc1a.Text = "0";
            }
            else
            {
                cellsum = Convert.ToDouble(MC1A.Text);
            }
            if (TC1A.Text == "-")
            {
                totalc1a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(TC1A.Text);
            }
            if (WC1A.Text == "-")
            {
                totalc1a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(WC1A.Text);
            }
            if (THC1A.Text == "-")
            {
                totalc1a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(THC1A.Text);
            }
            if (FC1A.Text == "-")
            {
                totalc1a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(FC1A.Text);
            }
            if (SC1A.Text == "-")
            {
                totalc1a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(SC1A.Text);
            }
            totalc1a.Text = cellsum.ToString("####0");


        }
        #endregion

        #region "CallSumCell2();"
        private void CallSumCell2()
        {
            /// sum Actual
            double cell0 = 0;
            if (MC2T.Text == "-")
            {
                totalc2t.Text = "-";
            }
            else
            {
                cell0 = Convert.ToDouble(MC2T.Text);
            }
            if (TC2T.Text == "-")
            {
                totalc2t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(TC2T.Text);
            }
            if (WC2T.Text == "-")
            {
                totalc2t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(WC2T.Text);
            }
            if (THC2T.Text == "-")
            {
                totalc2t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(THC2T.Text);
            }
            if (FC2T.Text == "-")
            {
                totalc2t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(FC2T.Text);
            }
            if (SC2T.Text == "-")
            {
                totalc2t.Text = cell0.ToString("####00");
            }
            else
            {
                cell0 = cell0 + Convert.ToDouble(SC2T.Text);
            }
            totalc2t.Text = cell0.ToString("####");



            /// sum Actual
            double cellsum = 0;
            if (MC2A.Text == "-")
            {
                totalc2a.Text = "-";
            }
            else
            {
                cellsum = Convert.ToDouble(MC2A.Text);
            }
            if (TC2A.Text == "-")
            {
                totalc2a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(TC2A.Text);
            }
            if (WC2A.Text == "-")
            {
                totalc2a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(WC2A.Text);
            }
            if (THC2A.Text == "-")
            {
                totalc2a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(THC2A.Text);
            }
            if (FC2A.Text == "-")
            {
                totalc2a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(FC2A.Text);
            }
            if (SC2A.Text == "-")
            {
                totalc2a.Text = cellsum.ToString("####00");
            }
            else
            {
                cellsum = cellsum + Convert.ToDouble(SC2A.Text);
            }
            totalc2a.Text = cellsum.ToString("####");


        }
        #endregion    
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            wk.BackColor = Color.Orange;
            wk.ForeColor = Color.Blue;
            CallDay();
            CallSum();
            CallSumCell1();
            CallSumCell2();


            //color
             DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
                this.SC0A.ForeColor = Color.Red;
                this.SC1A.ForeColor = Color.Red;
                this.SC2A.ForeColor = Color.Red;
                this.lblsat.ForeColor = Color.Red;
            
            }
            else if (temday == "Mon")
            {
                this.MC0A.ForeColor = Color.Red;
                this.MC1A.ForeColor = Color.Red;
                this.MC2A.ForeColor = Color.Red;
                this.lblmon.ForeColor = Color.Red;
            }
            else if (temday == "Tue")
            {
                this.TC0A.ForeColor = Color.Red;
                this.TC1A.ForeColor = Color.Red;
                this.TC2A.ForeColor = Color.Red;
                this.lbltue.ForeColor = Color.Red;
            }
            else if (temday == "Wed")
            {
                this.WC0A.ForeColor = Color.Red;
                this.WC1A.ForeColor = Color.Red;
                this.WC2A.ForeColor = Color.Red;
                this.lblwed.ForeColor = Color.Red;
            }
            else if (temday == "Thu")
            {
                this.THC0A.ForeColor = Color.Red;
                this.THC1A.ForeColor = Color.Red;
                this.THC2A.ForeColor = Color.Red;
                this.lblthu.ForeColor = Color.Red;
            }
            else if (temday == "Fri")
            {
                this.FC0A.ForeColor = Color.Red;
                this.FC1A.ForeColor = Color.Red;
                this.FC2A.ForeColor = Color.Red;
                this.lblfri.ForeColor = Color.Red;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            wk.BackColor = Color.Black;
            wk.ForeColor = Color.White;

            //color
            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
                this.SC0A.ForeColor = SystemColors.ButtonHighlight;
                this.SC1A.ForeColor = SystemColors.ButtonHighlight;
                this.SC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lblsat.ForeColor = Color.BlueViolet;

            }
            else if (temday == "Mon")
            {
                this.MC0A.ForeColor = SystemColors.ButtonHighlight;
                this.MC1A.ForeColor = SystemColors.ButtonHighlight;
                this.MC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lblmon.ForeColor = Color.BlueViolet;
            }
            else if (temday == "Tue")
            {
                this.TC0A.ForeColor = SystemColors.ButtonHighlight;
                this.TC1A.ForeColor = SystemColors.ButtonHighlight;
                this.TC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lbltue.ForeColor = Color.BlueViolet;
            }
            else if (temday == "Wed")
            {
                this.WC0A.ForeColor = SystemColors.ButtonHighlight;
                this.WC1A.ForeColor = SystemColors.ButtonHighlight;
                this.WC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lblwed.ForeColor = Color.BlueViolet;
            }
            else if (temday == "Thu")
            {
                this.THC0A.ForeColor = SystemColors.ButtonHighlight;
                this.THC1A.ForeColor = SystemColors.ButtonHighlight;
                this.THC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lblthu.ForeColor = Color.BlueViolet;
            }
            else if (temday == "Fri")
            {
                this.FC0A.ForeColor = SystemColors.ButtonHighlight;
                this.FC1A.ForeColor = SystemColors.ButtonHighlight;
                this.FC2A.ForeColor = SystemColors.ButtonHighlight;
                this.lblfri.ForeColor = Color.BlueViolet;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {


        }


    }
}
