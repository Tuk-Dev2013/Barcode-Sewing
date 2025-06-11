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

namespace PicklistBOM.MonitorLine
{
    public partial class FrmSawingMonitor : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;




        public FrmSawingMonitor()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            CallYear();
            CallMonthWeek();
            Calldaydate();
            Callday(CGlobal.Dayweek);
        }

        private void FrmSawingMonitor_Load(object sender, EventArgs e)
        {
            //monitor
            //PicklistBOM.MonitorLine.FrmSawingWeek frmMain = new PicklistBOM.MonitorLine.FrmSawingWeek();

            //frmMain.StartPosition = FormStartPosition.Manual;
            //frmMain.FormBorderStyle = FormBorderStyle.None;
            //frmMain.WindowState = FormWindowState.Maximized;
            //string show_scr = System.Configuration.ConfigurationManager.AppSettings["SHOW_SCREEN"];

            //if (string.IsNullOrEmpty(show_scr) || show_scr == "0")
            //{
            //    Application.Run(frmMain);
            //}
            //else
            //{
            //    int scr = 0;
            //    int.TryParse(show_scr, out scr);

            //    if (Screen.AllScreens.Length > 1 && Screen.AllScreens.Length >= scr)
            //    {
            //        frmMain.Location = Screen.AllScreens[scr].WorkingArea.Location;
            //        Application.Run(frmMain);
            //    }
            //    else
            //    {
            //        Application.Run(frmMain);
            //    }
            //}

            //end monitor




            string y = DateTime.Now.ToString("yyyy", new System.Globalization.CultureInfo("en-US"));

            //if ((y =="2016") ||(y =="2017"))
            //{
                this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                label7.Text="Y:" + y;
                string Month = Mid(this.lbldate.Text, 3, 2);
                callMouth(Month);
                CallYear();
                CallMonthWeek();
                Calldaydate();
                Callday(CGlobal.Dayweek);
          //  }

          
        }



        #region " Callday();"
        private void Callday(string tempweek)
        {
            //this.showgrid2.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = " select * from Leather_Day where Week='" + tempweek + "' order by DateDay";
                if (Isfind1 == true)
                {
                    ds.Tables["Showday3"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showday3");

                if (ds.Tables["Showday3"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showday3"];
                    double sumtotal = 0;
                    for (int i = 0; i < ds.Tables["Showday3"].Rows.Count; i++)
                    {
                        string Week = ds.Tables["Showday3"].Rows[i]["Sdate"].ToString();
                        string Actual = Convert.ToDouble(ds.Tables["Showday3"].Rows[i]["Actual"].ToString()).ToString("#####0.00");

                        string Status = Convert.ToDouble(ds.Tables["Showday3"].Rows[i]["Status"].ToString()).ToString("#####0.00");

                        if (Actual == "0.00")
                        { 
                            Actual = "0"; 
                        }

                        sumtotal = sumtotal + Convert.ToDouble(Actual);
                        if (i == 0)
                        {
                            d1.Text = Week;
                            ac1.Text = Actual;
                            if (Actual == "0")
                            {
                                sum1.Text = "0";
                            }
                            else
                            {
                                sum1.Text = sumtotal.ToString("#,###0.00");
                            }
  
                              //ใส่สี
                            //if (Week == tempdate)
                            //{
                            //    d1.BackColor = Color.Yellow;
                            //    ac1.BackColor = Color.Yellow;
                            //    sum1.BackColor = Color.Yellow;
                            //}

                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d1.BackColor = Color.Red;
                                ac1.BackColor = Color.Red;
                                sum1.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d1.BackColor = Color.Yellow;
                                ac1.BackColor = Color.Yellow;
                                sum1.BackColor = Color.Yellow;
                            }
                            else
                            {
                                d1.BackColor = Color.NavajoWhite;
                                ac1.BackColor = Color.NavajoWhite;
                                sum1.BackColor = Color.NavajoWhite;
                            }
                
                        }
                        else if (i == 1)
                        {
                            d2.Text = Week;
                            ac2.Text = Actual;
                            if (Actual == "0")
                            {
                                sum2.Text = "0";
                            }
                            else
                            {
                                sum2.Text = sumtotal.ToString("#,###0.00");
                            }
                            //ใส่สี
                            //if (Week == tempdate)
                            //{
                            //    d2.BackColor = Color.Yellow;
                            //    ac2.BackColor = Color.Yellow;
                            //    sum2.BackColor = Color.Yellow;
                            //}


                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d2.BackColor = Color.Red;
                                ac2.BackColor = Color.Red;
                                sum2.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d2.BackColor = Color.Yellow;
                                ac2.BackColor = Color.Yellow;
                                sum2.BackColor = Color.Yellow;
                            }
                            else
                            {
                                d2.BackColor = Color.NavajoWhite;
                                ac2.BackColor = Color.NavajoWhite;
                                sum2.BackColor = Color.NavajoWhite;
                            }
                
                        }
                        else if (i == 2)
                        {
                            d3.Text = Week;
                            ac3.Text = Actual;
                            if (Actual == "0")
                            {
                                sum3.Text = "0";
                            }
                            else
                            {
                                sum3.Text = sumtotal.ToString("#,###0.00");
                            }
                            //ใส่สี
                            //if (Week == tempdate)
                            //{
                            //    d3.BackColor = Color.Yellow;
                            //    ac3.BackColor = Color.Yellow;
                            //    sum3.BackColor = Color.Yellow;
                            //}

                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d3.BackColor = Color.Red;
                                ac3.BackColor = Color.Red;
                                sum3.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d3.BackColor = Color.Yellow;
                                ac3.BackColor = Color.Yellow;
                                sum3.BackColor = Color.Yellow;
                            }
                            else
                            {
                                d3.BackColor = Color.NavajoWhite;
                                ac3.BackColor = Color.NavajoWhite;
                                sum3.BackColor = Color.NavajoWhite;
                            }
                
                           

                        }
                        else if (i == 3)
                        {
                            d4.Text = Week;
                            ac4.Text = Actual;
                            if (Actual == "0")
                            {
                                sum4.Text = "0";
                            }
                            else
                            {
                                sum4.Text = sumtotal.ToString("#,###0.00");
                            }
                            //ใส่สี
                            //if (Week == tempdate)
                            //{
                            //    d4.BackColor = Color.Yellow;
                            //    ac4.BackColor = Color.Yellow;
                            //    sum4.BackColor = Color.Yellow;
                            //}


                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d4.BackColor = Color.Red;
                                ac4.BackColor = Color.Red;
                                sum4.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d4.BackColor = Color.Yellow;
                                ac4.BackColor = Color.Yellow;
                                sum4.BackColor = Color.Yellow;
                            }
                            else
                            {
                                d4.BackColor = Color.NavajoWhite;
                                ac4.BackColor = Color.NavajoWhite;
                                sum4.BackColor = Color.NavajoWhite;
                            }
                
                          
                        }
                        else if (i == 4)
                        {
                            d5.Text = Week;
                            ac5.Text = Actual;
                            if (Actual == "0")
                            {
                                sum5.Text = "0";
                            }
                            else
                            {
                                sum5.Text = sumtotal.ToString("#,###0.00");

                            }
                            ////ใส่สี
                            //if (Week == tempdate)
                            //{
                            //    d5.BackColor = Color.Yellow;
                            //    ac5.BackColor = Color.Yellow;
                            //    sum5.BackColor = Color.Yellow;
                            //}


                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d5.BackColor = Color.Red;
                                ac5.BackColor = Color.Red;
                                sum5.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d5.BackColor = Color.Yellow;
                                ac5.BackColor = Color.Yellow;
                                sum5.BackColor = Color.Yellow;
                            }
                            else
                            {
                                d5.BackColor = Color.NavajoWhite;
                                ac5.BackColor = Color.NavajoWhite;
                                sum5.BackColor = Color.NavajoWhite;
                            }
                

                        }
                        else if (i == 5)
                        {
                            d6.Text = Week;
                            ac6.Text = Actual;
                            if (Actual == "0")
                            {
                                sum6.Text = "0";
                            }
                            else
                            {
                                sum6.Text = sumtotal.ToString("#,###0.00");
                            }
                            //ใส่สี
                        

                            //ใส่สี OT
                            if (Status == "1.00")
                            {
                                d6.BackColor = Color.Red;
                                ac6.BackColor = Color.Red;
                                sum6.BackColor = Color.Red;
                            }
                            else if (Week == tempdate)
                            {
                                d6.BackColor = Color.Yellow;
                                ac6.BackColor = Color.Yellow;
                                sum6.BackColor = Color.Yellow;
                            }

                            else 
                            {
                                d6.BackColor = Color.NavajoWhite;
                                ac6.BackColor = Color.NavajoWhite;
                                sum6.BackColor = Color.NavajoWhite;
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
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  *  from  Leather_Day  Where Sdate='" + tempdate + "'", conn);
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

        #region " CallMonthWeek()"
        private void CallMonthWeek()
        {
    
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select * from dbo.Leather_Week  where Month ='"+Month.Text.Trim() +"' order by Week ";

                if (Isfind2 == true)
                {
                    ds.Tables["showweek"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "showweek");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["showweek"];

                    double sumT = 0;
                    double sumA = 0;

                    for (int i = 0; i < ds.Tables["showweek"].Rows.Count; i++)
                    {
                        string Week = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["Week"].ToString()).ToString("#,###");
                        string Target = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["Target"].ToString()).ToString("#,###0.00");
                        string Actual = Convert.ToDouble(ds.Tables["showweek"].Rows[i]["Actual"].ToString()).ToString("#,###0.00");
                     
                        if (i == 0)
                        {
                            w1.Text = Week;
                            t1.Text = Target;
                            a1.Text = Actual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w1.BackColor = Color.Yellow;
                                t1.BackColor = Color.Yellow;
                                a1.BackColor = Color.Yellow;
                            }
                        }
                      else  if  (i==1)
                        {
                            w2.Text = Week;
                            t2.Text = Target;
                            a2.Text = Actual;

                          //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w2.BackColor = Color.Yellow;
                                t2.BackColor = Color.Yellow;
                                a2.BackColor = Color.Yellow;
                            }



                        }
                        else if (i == 2)
                        {
                            w3.Text = Week;
                            t3.Text = Target;
                            a3.Text = Actual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w3.BackColor = Color.Yellow;
                                t3.BackColor = Color.Yellow;
                                a3.BackColor = Color.Yellow;
                            }
                        }
                        else if (i == 3)
                        {
                            w4.Text = Week;
                            t4.Text = Target;
                            a4.Text = Actual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w4.BackColor = Color.Yellow;
                                t4.BackColor = Color.Yellow;
                                a4.BackColor = Color.Yellow;
                            }
                        }
                        else if (i == 4)
                        {
                            w5.Text = Week;
                            t5.Text = Target;
                            a5.Text = Actual;

                            //backup color
                            if (Week == CGlobal.Dayweek)
                            {
                                w5.BackColor = Color.Yellow;
                                t5.BackColor = Color.Yellow;
                                a5.BackColor = Color.Yellow;
                            }
                        }
                        if (Target == "")
                        {
                            sumT = sumT + 0;
                        }
                        else 
                        {
                            sumT = sumT + Convert.ToDouble(Target);
                        }
                       // sumT = sumT + Convert.ToDouble(Target);
                        if (Actual == "")
                        {
                            sumT = sumT + 0;
                        }
                        else
                        {
                            sumA = sumA + Convert.ToDouble(Actual);
                        }

                       // sumA = sumA + Convert.ToDouble(Actual);
                    }
                    this.sumT.Text = sumT.ToString("#,###0.00");
                    this.sumA.Text = sumA.ToString("#,###0.00");

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
        private void CallYear()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  *  from Leather_Year", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.JanT.Text = Convert.ToDouble(rs["JanuaryT"].ToString()).ToString("####");
                    this.JanA.Text = Convert.ToDouble(rs["JanuaryA"].ToString()).ToString("####");
                    this.FebT.Text = Convert.ToDouble(rs["FebruaryT"].ToString()).ToString("####");
                    this.FebA.Text = Convert.ToDouble(rs["FebruaryA"].ToString()).ToString("####");
                    this.MarT.Text = Convert.ToDouble(rs["MarchT"].ToString()).ToString("#####");
                    this.MarA.Text = Convert.ToDouble(rs["MarchA"].ToString()).ToString("#####");
                    this.AprT.Text = Convert.ToDouble(rs["AprilT"].ToString()).ToString("#####");
                    this.AprA.Text = Convert.ToDouble(rs["AprilA"].ToString()).ToString("#####");
                    this.MayT.Text = Convert.ToDouble(rs["MayT"].ToString()).ToString("#####");
                    this.MayA.Text = Convert.ToDouble(rs["MayA"].ToString()).ToString("#####");
                    this.JunT.Text = Convert.ToDouble(rs["JuneT"].ToString()).ToString("#####");
                    this.JunA.Text = Convert.ToDouble(rs["JuneA"].ToString()).ToString("#####");
                    this.JulT.Text = Convert.ToDouble(rs["JulyT"].ToString()).ToString("#####");
                    this.JulA.Text = Convert.ToDouble(rs["JulyA"].ToString()).ToString("#####");
                    this.AugT.Text = Convert.ToDouble(rs["AugustT"].ToString()).ToString("#####");
                    this.AugA.Text = Convert.ToDouble(rs["AugustA"].ToString()).ToString("#####");
                    this.SepT.Text = Convert.ToDouble(rs["SeptemberT"].ToString()).ToString("#####");
                    this.SepA.Text = Convert.ToDouble(rs["SeptemberA"].ToString()).ToString("#####");
                    this.OctT.Text = Convert.ToDouble(rs["OctoberT"].ToString()).ToString("#####");
                    this.OctA.Text = Convert.ToDouble(rs["OctoberA"].ToString()).ToString("#####");
                    this.NovT.Text = Convert.ToDouble(rs["NoverberT"].ToString()).ToString("#####");
                    this.NovA.Text = Convert.ToDouble(rs["NoverberA"].ToString()).ToString("#####");
                    this.DecT.Text = Convert.ToDouble(rs["DecemberT"].ToString()).ToString("#####");
                    this.DecA.Text = Convert.ToDouble(rs["DecemberA"].ToString()).ToString("#####");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
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
                this.label32.BackColor = Color.Yellow;
                this.JanT.BackColor = Color.Yellow;
                this.JanA.BackColor = Color.Yellow;
        
            }
            else if (Month == "02")
            {
                this.Month.Text = "FEBRUARY";
                this.label31.BackColor = Color.Yellow;
                this.FebT.BackColor = Color.Yellow;
                this.FebA.BackColor = Color.Yellow;
        
        
            }
            else if (Month == "03")
            {
                this.Month.Text = "MARCH";
                this.label30.BackColor = Color.Yellow;
                this.MarT.BackColor = Color.Yellow;
                this.MarA.BackColor = Color.Yellow;
      
            }
            else if (Month == "04")
            {
                this.Month.Text = "APRIL";
                this.label29.BackColor = Color.Yellow;
                this.AprT.BackColor = Color.Yellow;
                this.AprA.BackColor = Color.Yellow;
          
            }
            else if (Month == "05")
            {
                this.Month.Text = "MAY";
                this.label28.BackColor = Color.Yellow;
                this.MayT.BackColor = Color.Yellow;
                this.MayA.BackColor = Color.Yellow;
        
            }
            else if (Month == "06")
            {
                this.Month.Text = "JUNE";
                this.label27.BackColor = Color.Yellow;
                this.JunT.BackColor = Color.Yellow;
                this.JunA.BackColor = Color.Yellow;
            }
            else if (Month == "07")
            {
                this.Month.Text = "JULY";
                this.label26.BackColor = Color.Yellow;
                this.JulT.BackColor = Color.Yellow;
                this.JulA.BackColor = Color.Yellow;
     
            }
            else if (Month == "08")
            {
                this.Month.Text = "AUGUST";
                this.label25.BackColor = Color.Yellow;
                this.AugT.BackColor = Color.Yellow;
                this.AugA.BackColor = Color.Yellow;
          
            }
            else if (Month == "09")
            {
                this.Month.Text = "SEPTEMBER";
                this.label24.BackColor = Color.Yellow;
                this.SepT.BackColor = Color.Yellow;
                this.SepA.BackColor = Color.Yellow;
          
    
            }
            else if (Month == "10")
            {
                this.Month.Text = "OCTOBER";
                this.label23.BackColor = Color.Yellow;
                this.OctT.BackColor = Color.Yellow;
                this.OctA.BackColor = Color.Yellow;
        
            }
            else if (Month == "11")
            {
                this.Month.Text = "NOVEMBER";
                this.label22.BackColor = Color.Yellow;
                this.NovT.BackColor = Color.Yellow;
                this.NovA.BackColor = Color.Yellow;
           
            }
            else if (Month == "12")
            {
                this.Month.Text = "DECEMBER";
                this.label21.BackColor = Color.Yellow;
                this.DecT.BackColor = Color.Yellow;
                this.DecA.BackColor = Color.Yellow;
           
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
    }
}
