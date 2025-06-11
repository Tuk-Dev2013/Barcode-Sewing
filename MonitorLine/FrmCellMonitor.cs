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

namespace PicklistBOM.MonitorLine
{
    public partial class FrmCellMonitor : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;




        public FrmCellMonitor()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
           // this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string Month = Mid(this.lbldate.Text, 3, 2);
            CallMonthWeek(Month);
            Calldaydate();
            Callday(CGlobal.Dayweek, Month);

            CallYear("01");
            CallYear("02");
            CallYear("03");
            CallYear("04");
            CallYear("05");
            CallYear("06");
            CallYear("07");
            CallYear("08");
            CallYear("09");
            CallYear("10");
            CallYear("11");
            CallYear("12");

        }

        private void FrmCellMonitor_Load(object sender, EventArgs e)
        {
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string Month = Mid(this.lbldate.Text, 3, 2);

            label7.Text = "Y:" + DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US")); ;
            Calldaydate();

            callMouth(Month);

            CallMonthWeek(Month);
     

            Callday(CGlobal.Dayweek, Month);

            //Calldaydate();

            CallYear("01");
            CallYear("02");
            CallYear("03");
            CallYear("04");
            CallYear("05");
            CallYear("06");
            CallYear("07");
            CallYear("08");
            CallYear("09");
            CallYear("10");
            CallYear("11");
            CallYear("12");

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));
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

        #region " Callday();"
        private void Callday(string tempweek,string month)
        {
            //this.showgrid2.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string tempdate1 = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
                string my = month + '/' + tempdate1;

                string strSQL1 = "";
                strSQL1 = " select * from Line_MonitorWeek  where Week='" + tempweek + "' and SUBSTRING(tagetdate,4,7) ='" + my + "'  order by ID";
                if (Isfind1 == true)
                {
                    ds.Tables["Showday3"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showday3");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showday3"];
                    double sumtotal = 0;
                    for (int i = 0; i < ds.Tables["Showday3"].Rows.Count; i++)
                    {
                        string Week = ds.Tables["Showday3"].Rows[i]["TagetDate"].ToString();
                        string Actual = Convert.ToDouble(ds.Tables["Showday3"].Rows[i]["TotalOutput"].ToString()).ToString("#####0");
                        string target = Convert.ToDouble(ds.Tables["Showday3"].Rows[i]["Totaltarget"].ToString()).ToString("#####0");
                        if (Actual == "0.00")
                        { 
                            Actual = "0"; 
                        }
                        if (target == "0.00")
                        {
                            target = "0";
                        }

                        sumtotal = sumtotal + Convert.ToDouble(Actual);
                        if (i == 0)
                        {
                            d1.Text = Week;
                            ac1.Text = Actual;
                            ta1.Text = target;
                            if (Actual == "0")
                            {
                                sum1.Text = "0";
                            }
                            else
                            {
                                sum1.Text = sumtotal.ToString("#,###0");
                            }
      
                          
                              //ใส่สี
                            if (Week == tempdate)
                            {
                                d1.BackColor = Color.Red;
                                ac1.BackColor = Color.Red;
                                sum1.BackColor = Color.Red;
                                ta1.BackColor = Color.Red;
                            }

                
                        }
                        else if (i == 1)
                        {
                            d2.Text = Week;
                            ac2.Text = Actual;
                            ta2.Text = target;
                            if (Actual == "0")
                            {
                                sum2.Text = "0";
                            }
                            else
                            {
                                sum2.Text = sumtotal.ToString("#,###0");
                            }
                            //ใส่สี
                            if (Week == tempdate)
                            {
                                d2.BackColor = Color.Red;
                                ac2.BackColor = Color.Red;
                                sum2.BackColor = Color.Red;
                                ta2.BackColor = Color.Red;
                            }
                        }
                        else if (i == 2)
                        {
                            d3.Text = Week;
                            ac3.Text = Actual;
                            ta3.Text = target;
                            if (Actual == "0")
                            {
                                sum3.Text = "0";
                            }
                            else
                            {
                                sum3.Text = sumtotal.ToString("#,###0");
                            }
                            //ใส่สี
                            if (Week == tempdate)
                            {
                                d3.BackColor = Color.Red;
                                ac3.BackColor = Color.Red;
                                sum3.BackColor = Color.Red;
                                ta3.BackColor = Color.Red;
                            }
                           

                        }
                        else if (i == 3)
                        {
                            d4.Text = Week;
                            ac4.Text = Actual;
                            ta4.Text = target;
                            if (Actual == "0")
                            {
                                sum4.Text = "0";
                            }
                            else
                            {
                                sum4.Text = sumtotal.ToString("#,###0");
                            }
                            //ใส่สี
                            if (Week == tempdate)
                            {
                                d4.BackColor = Color.Red;
                                ac4.BackColor = Color.Red;
                                sum4.BackColor = Color.Red;
                                ta4.BackColor = Color.Red;
                            }
                          
                        }
                        else if (i == 4)
                        {
                            d5.Text = Week;
                            ac5.Text = Actual;
                            ta5.Text = target;
                            if (Actual == "0")
                            {
                                sum5.Text = "0";
                            }
                            else
                            {
                                sum5.Text = sumtotal.ToString("#,###0");

                            }
                            //ใส่สี
                            if (Week == tempdate)
                            {
                                d5.BackColor = Color.Red;
                                ac5.BackColor = Color.Red;
                                sum5.BackColor = Color.Red;
                                ta5.BackColor = Color.Red;
                            }

                        }
                        else if (i == 5)
                        {
                            d6.Text = Week;
                            ac6.Text = Actual;
                            ta6.Text = target;
                            if (Actual == "0")
                            {
                                sum6.Text = "0";
                            }
                            else
                            {
                                sum6.Text = sumtotal.ToString("#,###0");
                            }
                            //ใส่สี
                            if (Week == tempdate)
                            {
                                d6.BackColor = Color.Red ;
                                ac6.BackColor = Color.Red;
                                sum6.BackColor = Color.Red;
                                ta6.BackColor = Color.Red;
                            }
                        }
                    }
                   // showgrid2.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                   //  this.showgrid2.DataSource = null;
                   //  MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data");
            }
            conn.Close();
            lbldayweek.Text = "DATE (WK" + tempweek + ")";
 
        }

        #endregion


        #region " Callday();"
        private void Calldaydate()
        {

            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string strSQL1 = "";
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  *  from  Line_MonitorWeek  Where TagetDate='" + tempdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.Dayweek = rs["Week"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


        }

        #endregion

        #region "CallWeek"
        private void CallWeek(String week)
        {
            string strSQL1 = "";
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {

                string tempdate = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT sum(Totaltarget)as target,SUM(TotalOutput) as output  from Line_MonitorWeek  where Week ='" + week + "' and  Right(tagetdate,4)='" + tempdate + "' and week IS NOT NULL  group by week ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string num = rs["target"].ToString();
                  //  CGlobal.WeekTarget = Convert.ToDouble(rs["TargetWeek"].ToString()).ToString("#,####");
                    if ((num == "") || (num == null))
                    {
                        CGlobal.WeekTarget = "-";

                    }
                    else 
                    {
                        CGlobal.WeekTarget = Convert.ToDouble(num).ToString("#,####");
                    }
                    CGlobal.WeekActual = Convert.ToDouble(rs["output"].ToString()).ToString("#,####");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        
        }
        #endregion

        #region " CallMonthWeek()"
        private void CallMonthWeek(string month)
        {
    
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string tempdate = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
                string my = month + '/' + tempdate;
                string strSQL1 = "";
                strSQL1 = "  select week from Line_MonitorWeek  where SUBSTRING(tagetdate,4,7) ='" + my + "' and week IS NOT NULL  group by week ";

                if (Isfind2 == true)
                {
                    ds.Tables["showweek"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "showweek");

                if (ds.Tables["showweek"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["showweek"];

                    double sumT = 0;
                    double sumA = 0;

                    for (int i = 0; i < ds.Tables["showweek"].Rows.Count; i++)
                    {
                        string Week = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["week"].ToString()).ToString("#,###");
                    //  string Target = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["target"].ToString()).ToString("#,###0");
                      //  string Actual = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["output"].ToString()).ToString("#,###0");
                     
                        if (i == 0)
                        {
                            w1.Text = Week;

                            CallWeek(Week);

                            t1.Text = CGlobal.WeekTarget;
                            a1.Text = CGlobal.WeekActual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w1.BackColor = Color.Red;
                                t1.BackColor = Color.Red;
                                a1.BackColor = Color.Red;
                            }
                        }
                      else  if  (i==1)
                        {
                            w2.Text = Week;
                            CallWeek(Week);
                            t2.Text = CGlobal.WeekTarget;
                            a2.Text = CGlobal.WeekActual;

                          //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w2.BackColor = Color.Red;
                                t2.BackColor = Color.Red;
                                a2.BackColor = Color.Red;
                            }



                        }
                        else if (i == 2)
                        {
                            w3.Text = Week;
                            CallWeek(Week);
                            t3.Text = CGlobal.WeekTarget;
                            a3.Text = CGlobal.WeekActual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w3.BackColor = Color.Red;
                                t3.BackColor = Color.Red;
                                a3.BackColor = Color.Red;
                            }
                        }
                        else if (i == 3)
                        {
                            w4.Text = Week;
                            CallWeek(Week);
                            t4.Text = CGlobal.WeekTarget;
                            a4.Text = CGlobal.WeekActual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w4.BackColor = Color.Red;
                                t4.BackColor = Color.Red;
                                a4.BackColor = Color.Red;
                            }
                        }
                        else if (i == 4)
                        {
                            w5.Text = Week;
                            CallWeek(Week);
                            t5.Text = CGlobal.WeekTarget;
                            a5.Text = CGlobal.WeekActual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w5.BackColor = Color.Red;
                                t5.BackColor = Color.Red;
                                a5.BackColor = Color.Red;
                            }
                        }
                        if ((CGlobal.WeekTarget == "")|| (CGlobal.WeekTarget == "-"))
                        {
                            sumT = sumT + 0;
                        }
                        else 
                        {
                            sumT = sumT + Convert.ToDouble(CGlobal.WeekTarget);
                        }
                       // sumT = sumT + Convert.ToDouble(Target);
                        if ((CGlobal.WeekActual == "")||(CGlobal.WeekActual == "-"))
                        {
                            sumT = sumT + 0;
                        }
                        else
                        {
                            sumA = sumA + Convert.ToDouble(CGlobal.WeekActual);
                        }

                       // sumA = sumA + Convert.ToDouble(Actual);
                    }
                    this.sumT.Text = sumT.ToString("#,###0");
                    this.sumA.Text = sumA.ToString("#,###0");

                }
                else
                {
                    Isfind2 = false;
                   // this.GridSplitLot.DataSource = null;
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

        #region " CallYear()"
        private void CallYear(String month)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());

            string tempdate = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));
            label7.Text = "Y:" + tempdate;
            string my = month + '/' + tempdate;
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select  SUM(Totaltarget) As target,SUM(TotalOutput) As Actual from dbo.Line_MonitorWeek where SUBSTRING(tagetdate,4,7) ='" + my + "' ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    if (month == "01")
                    {
                        //this.JanT.Text = Convert.ToDouble(rs["target"].ToString()).ToString("####");
                        //this.JanA.Text = Convert.ToDouble(rs["Actual"].ToString()).ToString("####");
                        this.JanT.Text = rs["target"].ToString();
                        this.JanA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "02")
                    {
                        //this.FebT.Text = Convert.ToDouble(rs["target"].ToString()).ToString("####");
                        //this.FebA.Text = Convert.ToDouble(rs["Actual"].ToString()).ToString("####");
                        this.FebT.Text = rs["target"].ToString();
                        this.FebA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "03")
                    {
                      this.MarT.Text = rs["target"].ToString();
                      this.MarA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "04")
                    {
                        this.AprT.Text = rs["target"].ToString();
                        this.AprA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "05")
                    {
                        this.MayT.Text = rs["target"].ToString();
                        this.MayA.Text =rs["Actual"].ToString();
                    }
                    else if (month == "06")
                    {
                        this.JunT.Text = rs["target"].ToString();
                        this.JunA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "07")
                    {
                        this.JulT.Text = rs["target"].ToString();
                        this.JulA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "08")
                    {
                        this.AugT.Text = rs["target"].ToString();
                        this.AugA.Text = rs["Actual"].ToString();
                     }
                    else if (month == "09")
                    {
                        this.SepT.Text = rs["target"].ToString();
                        this.SepA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "10")
                    {
                        this.OctT.Text = rs["target"].ToString();
                        this.OctA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "11")
                    {
                        this.NovT.Text = rs["target"].ToString();
                        this.NovA.Text = rs["Actual"].ToString();
                    }
                    else if (month == "12")
                    {
                        this.DecT.Text = rs["target"].ToString();
                        this.DecA.Text = rs["Actual"].ToString();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  Year  " + ex);
            }


        }
        #endregion


        #region "mid"
        public static string Mid1(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable       
            string result = param.Substring(startIndex, length);
            //return the result of the operation52.         
            return result;
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
        #endregion

        #region "callMouth"
        private void callMouth(string Month)
        {
            if (Month == "01")
            {
                this.Month.Text = "JANUARY";
                this.label32.BackColor = Color.Red;
                this.JanT.BackColor = Color.Red;
                this.JanA.BackColor = Color.Red;
        
            }
            else if (Month == "02")
            {
                this.Month.Text = "FEBRUARY";
                this.label31.BackColor = Color.Red;
                this.FebT.BackColor = Color.Red;
                this.FebA.BackColor = Color.Red;
        
        
            }
            else if (Month == "03")
            {
                this.Month.Text = "MARCH";
                this.label30.BackColor = Color.Red;
                this.MarT.BackColor = Color.Red;
                this.MarA.BackColor = Color.Red;
      
            }
            else if (Month == "04")
            {
                this.Month.Text = "APRIL";
                this.label29.BackColor = Color.Red;
                this.AprT.BackColor = Color.Red;
                this.AprA.BackColor = Color.Red;
          
            }
            else if (Month == "05")
            {
                this.Month.Text = "MAY";
                this.label28.BackColor = Color.Red;
                this.MayT.BackColor = Color.Red;
                this.MayA.BackColor = Color.Red;
        
            }
            else if (Month == "06")
            {
                this.Month.Text = "JUNE";
                this.label27.BackColor = Color.Red;
                this.JunT.BackColor = Color.Red;
                this.JunA.BackColor = Color.Red;
            }
            else if (Month == "07")
            {
                this.Month.Text = "JULY";
                this.label26.BackColor = Color.Red;
                this.JulT.BackColor = Color.Red;
                this.JulA.BackColor = Color.Red;
     
            }
            else if (Month == "08")
            {
                this.Month.Text = "AUGUST";
                this.label25.BackColor = Color.Red;
                this.AugT.BackColor = Color.Red;
                this.AugA.BackColor = Color.Red;
          
            }
            else if (Month == "09")
            {
                this.Month.Text = "SEPTEMBER";
                this.label24.BackColor = Color.Red;
                this.SepT.BackColor = Color.Red;
                this.SepA.BackColor = Color.Red;
          
    
            }
            else if (Month == "10")
            {
                this.Month.Text = "OCTOBER";
                this.label23.BackColor = Color.Red;
                this.OctT.BackColor = Color.Red;
                this.OctA.BackColor = Color.Red;
        
            }
            else if (Month == "11")
            {
                this.Month.Text = "NOVEMBER";
                this.label22.BackColor = Color.Red;
                this.NovT.BackColor = Color.Red;
                this.NovA.BackColor = Color.Red;
           
            }
            else if (Month == "12")
            {
                this.Month.Text = "DECEMBER";
                this.label21.BackColor = Color.Red;
                this.DecT.BackColor = Color.Red;
                this.DecA.BackColor = Color.Red;
           
            }


        }
        #endregion

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void lineShape9_Click(object sender, EventArgs e)
        {

        }

        private void sum4_Click(object sender, EventArgs e)
        {

        }

        private void t5_Click(object sender, EventArgs e)
        {

        }

        private void lineShape29_Click(object sender, EventArgs e)
        {


        }

        private void lineShape14_Click(object sender, EventArgs e)
        {

        }

        private void lineShape17_Click(object sender, EventArgs e)
        {

        }

        private void NovA_Click(object sender, EventArgs e)
        {

        }

        private void OctA_Click(object sender, EventArgs e)
        {

        }

        private void SepA_Click(object sender, EventArgs e)
        {

        }

        private void AugA_Click(object sender, EventArgs e)
        {

        }

        private void JulA_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void MarT_Click(object sender, EventArgs e)
        {

        }

        private void FebT_Click(object sender, EventArgs e)
        {

        }

        private void MayT_Click(object sender, EventArgs e)
        {

        }

        private void JunT_Click(object sender, EventArgs e)
        {

        }

        private void AugT_Click(object sender, EventArgs e)
        {

        }

        private void FebA_Click(object sender, EventArgs e)
        {

        }

        private void DecA_Click(object sender, EventArgs e)
        {

        }

        private void MayA_Click(object sender, EventArgs e)
        {

        }

        private void JunA_Click(object sender, EventArgs e)
        {

        }

        private void AprA_Click(object sender, EventArgs e)
        {

        }

        private void JanT_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
