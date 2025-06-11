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
    public partial class FrmSawingWeek : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmSawingWeek()
        {
            InitializeComponent();
        }

        private void FrmSawingWeek_Load(object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
          
            string Month = Mid(this.lbldate.Text, 3, 2);
            callMouth(Month);
            Callcboweek();
            CallWeek();

            Calldaydate();

            // tempday

            CboOT.Text = "ไม่มีโอที";

            Callday(CGlobal.Dayweek);
            CallYear();
           
     
        }


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

        #region " CallYear()"
        private void CallYear()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  *  from Leather_Year ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtT1.Text = rs["JanuaryT"].ToString();
                    txtA1.Text = rs["JanuaryA"].ToString();
                    txtT2.Text = rs["FebruaryT"].ToString();
                    txtA2.Text = rs["FebruaryA"].ToString();
                    txtT3.Text = rs["MarchT"].ToString();
                    txtA3.Text = rs["MarchA"].ToString();
                    txtT4.Text = rs["AprilT"].ToString();
                    txtA4.Text = rs["AprilA"].ToString();
                    txtT5.Text = rs["MayT"].ToString();
                    txtA5.Text = rs["MayA"].ToString();
                    txtT6.Text = rs["JuneT"].ToString();
                    txtA6.Text = rs["JuneA"].ToString();
                    txtT7.Text = rs["JulyT"].ToString();
                    txtA7.Text = rs["JulyA"].ToString();
                    txtT8.Text = rs["AugustT"].ToString();
                    txtA8.Text = rs["AugustA"].ToString();
                    txtT9.Text = rs["SeptemberT"].ToString();
                    txtA9.Text = rs["SeptemberA"].ToString();
                    txtT10.Text = rs["OctoberT"].ToString();
                    txtA10.Text = rs["OctoberA"].ToString();
                    txtT11.Text = rs["NoverberT"].ToString();
                    txtA11.Text = rs["NoverberA"].ToString();
                    txtT12.Text = rs["DecemberT"].ToString();
                    txtA12.Text = rs["DecemberA"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
             {
               MessageBox.Show("Error" + ex);
             }
           
  
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

   

          // int NumWeek = GetWeekNumber(DateTime.Now);
        }

        #region "AutoKey"


        #endregion

        #region "callMouth"
        private void callMouth(string Month)
        {
            if (Month == "01")
            {
                this.Month.Text = "JANUARY";
                cboMonth.Text = "January";
            }
            else if (Month == "02")
            {
                this.Month.Text = "FEBRUARY";
                cboMonth.Text = "February";
            }
            else if (Month == "03")
            {
                this.Month.Text = "MARCH";
                cboMonth.Text = "March";
            }
            else if (Month == "04")
            {
                this.Month.Text = "APRIL";
                cboMonth.Text = "April";
            }
            else if (Month == "05")
            {
                this.Month.Text = "MAY";
                cboMonth.Text = "May";
            }
            else if (Month == "06")
            {
                this.Month.Text = "JUNE";
                cboMonth.Text = "June";
            }
            else if (Month == "07")
            {
                this.Month.Text = "JULY";
                cboMonth.Text = "July";
            }
            else if (Month == "08")
            {
                this.Month.Text = "AUGUST";
                cboMonth.Text = "August";
            }
            else if (Month == "09")
            {
                this.Month.Text = "SEPTEMBER";
                cboMonth.Text = "September";
            }
            else if (Month == "10")
            {
                this.Month.Text = "OCTOBER";
                cboMonth.Text = "October";
            }
            else if (Month == "11")
            {
                this.Month.Text = "NOVEMBER";
                cboMonth.Text = "Noverber";
            }  
            else if (Month == "12")
            {
                this.Month.Text = "DECEMBER";
                cboMonth.Text = "December";
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


        #region "หา สัปดาห์ ของเดือน."
        public static int GetWeekNumber(DateTime dtPassed)
        {
            //Constants
            const int JAN = 1;
            const int DEC = 12;
            const int LASTDAYOFDEC = 31;
            const int FIRSTDAYOFJAN = 1;
            const int THURSDAY = 4;
            bool thursdayFlag = false;

            //Get the day number since the beginning of the year
            int dayOfYear = dtPassed.DayOfYear;

            //Get the first and last weekday of the year
            int startWeekDayOfYear = (int)(new DateTime(dtPassed.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
            int endWeekDayOfYear = (int)(new DateTime(dtPassed.Year, DEC, LASTDAYOFDEC)).DayOfWeek;

            //Compensate for using monday as the first day of the week
            if (startWeekDayOfYear == 0)
                startWeekDayOfYear = 7;
            if (endWeekDayOfYear == 0)
                endWeekDayOfYear = 7;

            //Calculate the number of days in the first week
            int daysInFirstWeek = 8 - (startWeekDayOfYear);

            //Year starting and ending on a thursday will have 53 weeks
            if (startWeekDayOfYear == THURSDAY || endWeekDayOfYear == THURSDAY)
                thursdayFlag = true;

            //We begin by calculating the number of FULL weeks between
            //the year start and our date. The number is rounded up so
            //the smallest possible value is 0.
            int fullWeeks = (int)Math.Ceiling((dayOfYear - (daysInFirstWeek)) / 7.0);
            int resultWeekNumber = fullWeeks;

            //If the first week of the year has at least four days, the
            //actual week number for our date can be incremented by one.
            if (daysInFirstWeek >= THURSDAY)
                resultWeekNumber = resultWeekNumber + 1;

            //If the week number is larger than 52 (and the year doesn't
            //start or end on a thursday), the correct week number is 1.
            if (resultWeekNumber > 52 && !thursdayFlag)
                resultWeekNumber = 1;

            //If the week number is still 0, it means that we are trying
            //to evaluate the week number for a week that belongs to the
            //previous year (since it has 3 days or less in this year).
            //We therefore execute this function recursively, using the
            //last day of the previous year.
            if (resultWeekNumber == 0)
                resultWeekNumber = GetWeekNumber(new DateTime(dtPassed.Year - 1, DEC, LASTDAYOFDEC));
            return resultWeekNumber;
        }

        #endregion


        #region "callupdate"
        private void Callupdate()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Leather_Week SET");
            query.Append(" Month  = @Month,");
            query.Append(" Target  = @Target,");
            query.Append(" Actual  = @Actual");
            query.Append(" WHERE Week =  @Week");


            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@Month", this.cboMonth.Text);
                    db.AddParameter("@Target", this.txtwtarget.Text.Trim());
                    db.AddParameter("@Actual", this.txtwactual.Text.Trim());
                    db.AddParameter("@Week", this.txtW.Text.Trim());
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        
        }

        #endregion

        #region "save week"
        private void bntweek_Click(object sender, EventArgs e)
        {
            if (this.txtW.Text == "")
            {
                MessageBox.Show("กรุณาป้อน Week ก่อน");
                return;
            
            }
            if (bntweek.Text == "Edit")
            {
                Callupdate();
            
            }
            else
            {

                if ((MessageBox.Show(" คุณต้องการบันทึกรายการ Week ที่ " + this.txtW.Text + "  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    //save
                    var query = new StringBuilder();
                    query.Append("INSERT INTO dbo.Leather_Week (Week, Month, Target, Actual, Sdate, Status)");
                    query.Append(" VALUES (@Week, @Month, @Target, @Actual, @Sdate, @Status)");

                    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                    conn.Open();
                    using (var db = new DbHelper1())
                    {
                        try
                        {
                            db.AddParameter("@Week", this.txtW.Text.Trim());
                            db.AddParameter("@Month", cboMonth.Text);
                            db.AddParameter("@Target", this.txtwtarget.Text.Trim());
                            db.AddParameter("@Actual", this.txtwactual.Text.Trim());
                            db.AddParameter("@Sdate", DateTime.Now);
                            db.AddParameter("@Status", "0");
                            db.ExecuteNonQuery(query.ToString());
                            //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                        }

                        catch (Exception ex)
                        {
                            // db.RollbackTransaction();
                            MessageBox.Show("คุณป้อน Week ซ้ำครับ กรุณาป้อนใหม่");

                        }
                    }
                    conn.Close();
                }

            }

            this.txtwtarget.Text = "0";
            this.txtwactual.Text = "0";
            CallWeek();
            Callcboweek();
            bntweek.Text = "Add";
            this.txtW.Enabled = true;
        }

        #endregion

        #region "Callcboweek:"
        private void Callcboweek()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";
                //  strSQL1 = " select style,style from dbo.tb_DatSpecW1  Where model='" + this.cbomodel.SelectedValue + "'";
                strSQL1 = " Select Week as week from Leather_Week  order by Week Desc";

                if (Isfind2 == true)
                {
                    ds.Tables["style"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                //*** DropDownList ***// 
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    this.cboweek.DisplayMember = "Week";
                    this.cboweek.ValueMember = "Week";
                    this.cboweek.DataSource = ds.Tables["style"];

                }
                else
                {
                    Isfind2 = false;
                    this.cboweek.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;
            }
            catch (Exception ex)
            {


            }
        }
        #endregion



        #region " CallWeek();"
        private void CallWeek()
        {
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select * from  Leather_Week  order by Week Desc";
                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                    MessageBox.Show("No Data");
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

        #region "key number"
        private void txtwtarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
   

        private void txtwactual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region "click edit"
        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = gridView1.FocusedRowHandle;
                DataRow row = gridView1.GetDataRow(index);
                this.txtW.Text = Convert.ToString(gridView1.GetDataRow(index)["Week"]);
                this.cboMonth.Text= Convert.ToString(gridView1.GetDataRow(index)["Month"]);
                this.txtwtarget.Text = Convert.ToString(gridView1.GetDataRow(index)["Target"]);
                this.txtwactual.Text= Convert.ToString(gridView1.GetDataRow(index)["Actual"]);
                this.txtW.Enabled = false;
                bntweek.Text = "Edit";
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region "save day"
        private void bntday_Click(object sender, EventArgs e)
        {
            if (bntday.Text == "Edit")
            {
                Updateday();
            }
            else{

                if ((MessageBox.Show(" คุณต้องการบันทึกรายการ Actual Day นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    string sdate = this.daydate.Value.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                    string tmpdate = Left(sdate, 2);
                    //save
                    var query = new StringBuilder();
                    query.Append("INSERT INTO dbo.Leather_Day (Week, DateDay, Sdate, Actual, Status)");
                    query.Append(" VALUES (@Week, @DateDay, @Sdate, @Actual, @Status)");

                    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                    conn.Open();
                    using (var db = new DbHelper1())
                    {
                        try
                        {
                            db.AddParameter("@Week", this.cboweek.Text.Trim());
                            db.AddParameter("@DateDay", tmpdate);
                            db.AddParameter("@Sdate", sdate);
                            db.AddParameter("@Actual", this.txtdactual.Text.Trim());
                            db.AddParameter("@Status", "0");
                            db.ExecuteNonQuery(query.ToString());
                            //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                        }

                        catch (Exception ex)
                        {
                            // db.RollbackTransaction();
                            MessageBox.Show("คุณป้อน Day ซ้ำครับ กรุณาป้อนใหม่");

                        }
                    }
                    conn.Close();
                }
            }
            Callday(cboweek.Text.Trim());
                this.cboweek.Enabled = true;
                bntday.Text = "Add";
                this.txtdactual.Text="0";
                CGlobal.Daycode = "";
            
        }
        #endregion

        #region " Updateday();"
        private void Updateday()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Leather_Day SET");
            query.Append(" Actual  = @Actual");
            query.Append(", Status  = @Status");
            query.Append(" WHERE Daycode =  @Daycode");


            using (var db = new DbHelper1())
            {
                try
                {
                    string tmpOT = "";
                    if (CboOT.Text == "ไม่มีโอที")
                    {
                        tmpOT = "0";
                    }
                    else
                    { tmpOT = "1"; }


                    db.AddParameter("@Actual", this.txtdactual.Text.Trim());
                    db.AddParameter("@Status", tmpOT);
                    db.AddParameter("@Daycode", CGlobal.Daycode);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        
        }

        #endregion



        #region " Callday();"
        private void Callday(string tempweek)
        {
            this.showgrid2.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select * from Leather_Day where Week='" + tempweek + "' order by DateDay";
                if (Isfind1 == true)
                {
                    ds.Tables["Showday"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showday");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showday"];
                    showgrid2.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                    this.showgrid2.DataSource = null;
                  //  MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data");
            }
            conn.Close();
        
        
        }

        #endregion

        private void cboweek_SelectedIndexChanged(object sender, EventArgs e)
        {
            Callday(cboweek.Text.Trim());
        }

        private void showgrid2_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            DataRow row = gridView2.GetDataRow(index);
            cboweek.Text= Convert.ToString(gridView2.GetDataRow(index)["Week"]);
            daydate.Text= Convert.ToString(gridView2.GetDataRow(index)["Sdate"]);
            this.txtdactual.Text = Convert.ToString(gridView2.GetDataRow(index)["Actual"]);
            CGlobal.Daycode = Convert.ToString(gridView2.GetDataRow(index)["Daycode"]);
            this.cboweek.Enabled = false;

           string tmpStaus = Convert.ToString(gridView2.GetDataRow(index)["Status"]);
           if (tmpStaus == "1")
           { this.CboOT.Text = "โอที"; }
           else
           { this.CboOT.Text = "ไม่มีโอที"; }

            bntday.Text = "Edit";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึกรายการ Year นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("UPDATE dbo.Leather_Year SET");
                query.Append(" JanuaryT  = @JanuaryT,");
                query.Append(" JanuaryA  = @JanuaryA,");
                query.Append(" FebruaryT  = @FebruaryT,");
                query.Append(" FebruaryA  = @FebruaryA,");
                query.Append(" MarchT  = @MarchT,");
                query.Append(" MarchA  = @MarchA,");
                query.Append(" AprilT  = @AprilT,");
                query.Append(" AprilA  = @AprilA,");
                query.Append(" MayT  = @MayT,");
                query.Append(" MayA  = @MayA,");
                query.Append(" JuneT  = @JuneT,");
                query.Append(" JuneA  = @JuneA,");
                query.Append(" JulyT  = @JulyT,");
                query.Append(" JulyA  = @JulyA,");
                query.Append(" AugustT  = @AugustT,");
                query.Append(" AugustA  = @AugustA,");
                query.Append(" SeptemberT  = @SeptemberT,");
                query.Append(" SeptemberA  = @SeptemberA,");
                query.Append(" OctoberT  = @OctoberT,");
                query.Append(" OctoberA  = @OctoberA,");
                query.Append(" NoverberT  = @NoverberT,");
                query.Append(" NoverberA  = @NoverberA,");
                query.Append(" DecemberT  = @DecemberT,");
                query.Append(" DecemberA  = @DecemberA");
                query.Append(" WHERE Yearcode =  @Yearcode");


                using (var db = new DbHelper1())
                {
                    try
                    {
                        db.AddParameter("@JanuaryT", this.txtT1.Text.Trim());
                        db.AddParameter("@JanuaryA", this.txtA1.Text.Trim());
                        db.AddParameter("@FebruaryT", this.txtT2.Text.Trim());
                        db.AddParameter("@FebruaryA", this.txtA2.Text.Trim());
                        db.AddParameter("@MarchT", this.txtT3.Text.Trim());
                        db.AddParameter("@MarchA", this.txtA3.Text.Trim());
                        db.AddParameter("@AprilT", this.txtT4.Text.Trim());
                        db.AddParameter("@AprilA", this.txtA4.Text.Trim());
                        db.AddParameter("@MayT", this.txtT5.Text.Trim());
                        db.AddParameter("@MayA", this.txtA5.Text.Trim());
                        db.AddParameter("@JuneT", this.txtT6.Text.Trim());
                        db.AddParameter("@JuneA", this.txtA6.Text.Trim());
                        db.AddParameter("@JulyT", this.txtT7.Text.Trim());
                        db.AddParameter("@JulyA", this.txtA7.Text.Trim());
                        db.AddParameter("@AugustT", this.txtT8.Text.Trim());
                        db.AddParameter("@AugustA", this.txtA8.Text.Trim());
                        db.AddParameter("@SeptemberT", this.txtT9.Text.Trim());
                        db.AddParameter("@SeptemberA", this.txtA9.Text.Trim());
                        db.AddParameter("@OctoberT", this.txtT10.Text.Trim());
                        db.AddParameter("@OctoberA", this.txtA10.Text.Trim());
                        db.AddParameter("@NoverberT", this.txtT11.Text.Trim());
                        db.AddParameter("@NoverberA", this.txtA11.Text.Trim());
                        db.AddParameter("@DecemberT", this.txtT12.Text.Trim());
                        db.AddParameter("@DecemberA", this.txtA12.Text.Trim());
                        db.AddParameter("@Yearcode", "1");
                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }

                CallYear();
            }
        }

    }
}
