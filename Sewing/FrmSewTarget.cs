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
    public partial class FrmSewTarget : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmSewTarget()
        {
            InitializeComponent();
        }

        private void FrmSewTarget_Load(object sender, EventArgs e)
        {
            DateTime now555 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start555 = new TimeSpan(0, 0, 0); // 00:00
            TimeSpan end555 = new TimeSpan(8, 0, 0);   // 07:30
            TimeSpan currentTime555 = now555.TimeOfDay;
            //กะเช้า 7.30 - 20.30
            string tmpdate;
            DateTime now = DateTime.Now;
            if (currentTime555 >= start555 && currentTime555 <= end555)
            {
                tmpdate = now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            }
            else {
               
                tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            }

             
        



            
            lbltime.Text = now.ToString("HH:mm:ss");
            string tmpHH = now.ToString("HH");
            string tmpMM = now.ToString("mm");

            lbldate.Text = tmpdate;
            this.lblcell1.Text = ConfigurationManager.AppSettings["SHOW_CELL1"];
            if (this.lblcell1.Text == "Sewing 1")
            {
                this.lblcell1.Text = "Cell Sewing 13";
            }
            else if (this.lblcell1.Text == "Sewing 2")
            {
                this.lblcell1.Text = "Cell Sewing 15";
            }
            else if (this.lblcell1.Text == "Sewing 3")
            {
                this.lblcell1.Text = "Cell Sewing 9";
            }
            this.lblcell2.Text = ConfigurationManager.AppSettings["SHOW_CELL2"];
            if (this.lblcell2.Text == "Sewing 1")
            {
                this.lblcell2.Text = "Cell Sewing 13";
            }
            else if (this.lblcell2.Text == "Sewing 2")
            {
                this.lblcell2.Text = "Cell Sewing 15";
            }
            else if (this.lblcell2.Text == "Sewing 3")
            {
                this.lblcell2.Text = "Cell Sewing 9";
            }
          


       
            CallSearch(tmpdate);
            CallSearch2(tmpdate);
            if (txtMan_Night_OT2.Text==""){
                txtMan_Night_OT2.Text = "0";
            }
            if (txtMan_NT_OT2.Text == "")
            {
                txtMan_NT_OT2.Text = "0";
            }

            if (txtperheadNight2.Text == "")
            {
                txtperheadNight2.Text = "0";
            }
            if (txttotalNight2.Text == "")
            {
                txttotalNight2.Text = "0";
            }
            if (txtperson.Text == "")
            {
                txtperson.Text = "0";
            }
            if (txtMan_NT_OT.Text == "")
            {
                txtMan_NT_OT.Text = "0";
            }
            if (txtMan_Night.Text == "")
            {
                txtMan_Night.Text = "0";
            }

            if (txtMan_Night_OT.Text == "")
            {
                txtMan_Night_OT.Text = "0";
            }
            DateTime now1 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start = new TimeSpan(10, 00, 0); // 17:30
            TimeSpan end = new TimeSpan(13, 00, 0);   // 20:30
            TimeSpan currentTime = now1.TimeOfDay;

            DateTime now_02 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start_02 = new TimeSpan(10, 00, 0); // 17:30
            TimeSpan end_02 = new TimeSpan(15, 30, 0);   // 20:30
            TimeSpan currentTime_02 = now.TimeOfDay;

    }

   
        

        #region "CallSearch()"
        private void CallSearch(string tmpdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
          //  lbldate.Text = "No Date";
            //conn.Open();
            try
            {
                string tmpname = ConfigurationManager.AppSettings["SHOW_CELL1"];
                CGlobal.IssueNumber2 = "1";
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Man_OT,SewID,Sdate, Mantotal, Unitperhead, target, Issuedate, UserID, Target8hr, Target3hr, Total11hr,isnull(Man_NT,0) as Man_NT,isnull(Man_NT_OT,0) as Man_NT_OT,isnull(Man_Night,0) as Man_Night,isnull(Man_Night_OT,0) as Man_Night_OT,isnull(NightTarget8hr,0) as NightTarget8hr,isnull(NightTarget3hr,0) as NightTarget3hr,isnull(NightTotal11hr,0) as NightTotal11hr   FROM  Sewing_TargetDay Where Sdate='" + tmpdate + "' and Cellname='" + tmpname + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //กะกลางวัน
                    txtperson.Text = rs["Man_NT"].ToString();
                    txtMan_NT_OT.Text = rs["Man_NT_OT"].ToString();

                    txttotal.Text = rs["Target8hr"].ToString();
                    txtperhead.Text = rs["Target3hr"].ToString();
                    txttarget.Text = rs["Total11hr"].ToString();

                    //กะกลางคืน
                    txtMan_Night.Text = rs["Man_Night"].ToString();
                    txtMan_Night_OT.Text = rs["Man_Night_OT"].ToString();

                    txttotalNight.Text = rs["NightTarget8hr"].ToString();
                    txtperheadNight.Text = rs["NightTarget3hr"].ToString();
                    txttxttargetNight.Text = rs["NightTotal11hr"].ToString();
                }

            }
            catch (Exception ex)
            {
                CGlobal.IssueNumber2 = "1";
            }
            conn.Close();
        
        }
        #endregion

        #region "CallSearch2()"
        private void CallSearch2(string tmpdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
           // lbldate.Text = "No Date";
            //conn.Open();
            try
            {
                string tmpname = ConfigurationManager.AppSettings["SHOW_CELL2"];
                CGlobal.IssueNumber2 = "1";
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT * FROM  Sewing_TargetDay Where Sdate='" + tmpdate + "' and Cellname='" + tmpname + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    //กะเช้า

                    txtperson2.Text = rs["Man_NT"].ToString();
                    txtMan_NT_OT2.Text = rs["Man_NT_OT"].ToString();


                    txttotal2.Text = rs["Target8hr"].ToString();
                    txtperhead2.Text = rs["Target3hr"].ToString();
                    txttarget2.Text = rs["Total11hr"].ToString();  
 

                   

                    //กะกลางคืน
                    txtMan_Night2.Text = rs["Man_Night"].ToString();
                    txtMan_Night_OT2.Text = rs["Man_Night_OT"].ToString();

                    txttotalNight2.Text = rs["NightTarget8hr"].ToString();
                    txtperheadNight2.Text = rs["NightTarget3hr"].ToString();
                    txttxttargetNight2.Text = rs["NightTotal11hr"].ToString();
                }

            }
            catch (Exception ex)
            {
                CGlobal.IssueNumber2 = "1";
            }
            conn.Close();

        }
        #endregion
        int Man_total = 0;
        #region "CallUpdate1()"
        private void CallUpdate1()
        {
            if (txtMan_NT_OT.Text == "")
            {
                MessageBox.Show("ช่องกรอกจำนวนพนักงาน OT กะเช้าห้ามเท่ากับค่าว่าง ");
                txtMan_NT_OT.Focus();
                return;
            }
            if (txtMan_Night_OT.Text == "")
            {
                MessageBox.Show("ช่องกรอกจำนวนพนักงาน OT กะดึกห้ามเท่ากับค่าว่าง ");
                txtMan_Night_OT.Focus();
                return;
            }

            DateTime now6 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start6 = new TimeSpan(7, 30, 0); // 7:30
            TimeSpan end6 = new TimeSpan(17, 00, 0);  // 20:30

            TimeSpan start06 = new TimeSpan(17, 30, 0); // 17:30
            TimeSpan end06 = new TimeSpan(20, 30, 0);  //20:30
            TimeSpan currentTime6 = now6.TimeOfDay;
            //กะเช้า 7.30 - 17.00
            if (currentTime6 >= start6 && currentTime6 <= end6)
            {
               
                if (txtMan_NT_OT.Text == "0" || txtMan_NT_OT.Text == "" || txtMan_NT_OT.Text != "")
                {
                   
                    Man_total = Convert.ToInt32(txtperson.Text);
                    txtMan_NT_OT.Text = "0";
                }
                else {
                    Man_total = Convert.ToInt32(txtperson.Text);
                    txtMan_NT_OT.Text = "0";
                }
            }
            //กะเช้าช่วง OT 17.30-20.30
            if (currentTime6 >= start06 && currentTime6 <= end06)
            {
             
                if (txtMan_NT_OT.Text != "0")
                {
                    Man_total = Convert.ToInt32(txtMan_NT_OT.Text);
                }
                else
                {
                    Man_total = Convert.ToInt32(txtperson.Text);
                    txtMan_NT_OT.Text = "0";
                }
            }



            DateTime now_05 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start_05 = new TimeSpan(20, 30, 0); // 20:30
            TimeSpan end_05 = new TimeSpan(23, 59, 0);   // 23:59

            TimeSpan start_005 = new TimeSpan(0, 0, 0); // 0:00
            TimeSpan end_005 = new TimeSpan(5, 0, 0);   // 05:00

            TimeSpan start_0005 = new TimeSpan(5, 0, 0); // 05:00
            TimeSpan end_0005 = new TimeSpan(8, 0, 0);   // 08:00

            TimeSpan currentTime_05 = now_05.TimeOfDay;
            //กะดึก 20.30-0.0.0
       

            if (currentTime_05 >= start_05 && currentTime_05 <= end_05)
            {
              
                if (txtMan_Night_OT.Text == "0" || txtMan_Night_OT.Text == "" || txtMan_Night_OT.Text != "")
                {
                    Man_total = Convert.ToInt32(txtMan_Night.Text);
                    txtMan_Night_OT.Text = "0";
                }
                else {
                    Man_total = Convert.ToInt32(txtMan_Night.Text);
                    txtMan_Night_OT.Text = "0";
                }
            }
            //กะดึก 0:00-05:00
            if (currentTime_05 >= start_005 && currentTime_05 <= end_005)
            {
                
                if (txtMan_Night_OT.Text == "0" || txtMan_Night_OT.Text == "" || txtMan_Night_OT.Text != "")
                {
                    Man_total = Convert.ToInt32(txtMan_Night.Text);
                    txtMan_Night_OT.Text = "0";
                }
                else
                {
                    Man_total = Convert.ToInt32(txtMan_Night.Text);
                    txtMan_Night_OT.Text = "0";
                }
            }
            //OTกะดึก 05:00-08:00
            if (currentTime_05 >= start_0005 && currentTime_05 <= end_0005)
            {
               
                if (txtMan_Night_OT.Text != "0")
                {
                    Man_total = Convert.ToInt32(txtMan_Night_OT.Text);
                }
                else
                {
                    Man_total = Convert.ToInt32(txtMan_Night.Text);
                    txtMan_Night_OT.Text = "0";
                }
            }

         
                        
                        string tmpname = ConfigurationManager.AppSettings["SHOW_CELL1"];
                        var query = new StringBuilder();
                        query.Append("UPDATE dbo.Sewing_TargetDay  SET");


                        ////////กะเช้าช่วงปกติ
                        query.Append(" Man_NT  = @Man_NT");
                        query.Append(" ,Target8hr  = @Target8hr");
                       
                        ////////กะเช้าช่วงOT
                        query.Append(", Target3hr  = @Target3hr");
                        query.Append(", Total11hr  = @Total11hr");


                       // query.Append(", Issuedate  = @Issuedate");
                        query.Append(", UserID  = @UserID");
                        query.Append(", Mantotal  = @Mantotal");
                        query.Append(", Man_NT_OT  = @Man_NT_OT");

                        ////////กะดึก
                        query.Append(", Man_Night  = @Man_Night");
                        query.Append(", Man_Night_OT  = @Man_Night_OT");
                        query.Append(", NightTarget8hr  = @NightTarget8hr");
                        query.Append(", NightTarget3hr  = @NightTarget3hr");
                        query.Append(", NightTotal11hr  = @NightTotal11hr");

                        query.Append(" WHERE Sdate =  @Sdate");
                        query.Append(" and Cellname =  @Cellname");

             
           
   

                        using (var db = new DbHelper1())
                        {
                            try
                            {

                                //Day
                                double qtytotal = 0;
                                if (Convert.ToDouble(txtperson.Text.Trim())==5)
                                {
                                    qtytotal=(3 * 8);
                                    txttotal.Text = qtytotal.ToString("#,##0.00");
                   
                                }
                                else if (Convert.ToDouble(txtperson.Text.Trim()) == 4)
                                {
                                    qtytotal = (2.4 * 8);
                                    txttotal.Text = qtytotal.ToString("#,##0.00");
                        
                                }

                                else
                                {
                                    MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                                    return;
                                }


                                if (Convert.ToDouble(txtMan_NT_OT.Text.Trim()) == 5)
                                {
                                    qtytotal = (3 * 3);
                                    txtperhead.Text = qtytotal.ToString("#,##0.00");
                                }
                                else if (Convert.ToDouble(txtMan_NT_OT.Text.Trim()) == 4)
                                {
                                    qtytotal = (2.4 * 3);
                                    txtperhead.Text = qtytotal.ToString("#,##0.00");
                                }
                                else if (Convert.ToDouble(txtMan_NT_OT.Text.Trim()) == 0)
                                {
                                   
                                    txtperhead.Text ="0";
                                }
                                else
                                {
                                    MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                                    return;
                                }


                                //กะดึก
                                double qtytotal3 = 0;
                                if (Convert.ToDouble(txtMan_Night.Text.Trim()) == 5)
                                {
                                    qtytotal3 = (3 * 8);
                                    txttotalNight.Text = qtytotal3.ToString("#,##0.00");

                                }
                                else if (Convert.ToDouble(txtMan_Night.Text.Trim()) == 4)
                                {
                                    qtytotal3 = (2.4 * 8);
                                    txttotalNight.Text = qtytotal3.ToString("#,##0.00");

                                }
                                else if (Convert.ToDouble(txtMan_Night.Text.Trim()) == 0)
                                {

                                    txttotalNight.Text = "0";

                                }
                                else
                                {
                                    MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                                    return;
                                }

                                //กะดึก OT
                                double qtytotal4 = 0;
                                if (Convert.ToDouble(txtMan_Night_OT.Text.Trim()) == 5)
                                {
                                    qtytotal4 = (3 * 3);
                                    txtperheadNight.Text = qtytotal4.ToString("#,##0.00");
                                }
                                else if (Convert.ToDouble(txtMan_Night_OT.Text.Trim()) == 4)
                                {
                                    qtytotal4 = (2.4 * 3);
                                    txtperheadNight.Text = qtytotal4.ToString("#,##0.00");
                                }
                                else if (Convert.ToDouble(txtMan_Night_OT.Text.Trim()) == 0)
                                {

                                    txtperheadNight.Text = "0";
                                }
                                else
                                {
                                    MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                                    return;
                                }

                                double num = (Convert.ToDouble(txttotal.Text.Trim()) + Convert.ToDouble(txtperhead.Text));
                                double num2 = (Convert.ToDouble(txttotalNight.Text.Trim()) + Convert.ToDouble(txtperheadNight.Text));
                               
                                
                                //กะเช้าช่างปกติ
                                db.AddParameter("@Man_NT", txtperson.Text.Trim());
                                db.AddParameter("@Man_NT_OT", this.txtMan_NT_OT.Text);
                                db.AddParameter("@Target8hr", Convert.ToDouble(txttotal.Text.Trim()));
                                //กะเช้าช่วง OT 
                                db.AddParameter("@Target3hr", Convert.ToDouble(txtperhead.Text));
                                db.AddParameter("@Total11hr", num);

                                //db.AddParameter("@Issuedate", DateTime.Now);
                                db.AddParameter("@UserID", CGlobal.UserID);
                                db.AddParameter("@Mantotal", Man_total);
                                db.AddParameter("@Sdate", this.lbldate.Text.Trim());
                                db.AddParameter("@Cellname", tmpname);

                                //กะดึก
                                db.AddParameter("@Man_Night", this.txtMan_Night.Text); //คนทำงานกะดึก 8 ชั่วโมง
                                db.AddParameter("@Man_Night_OT", this.txtMan_Night_OT.Text); //คนทำงานกะดึก OT 
                                db.AddParameter("@NightTarget3hr", this.txtperheadNight.Text); //เป้าหมายกะกลางคืน 3 ช่วง OT ชม
                                db.AddParameter("@NightTarget8hr", this.txttotalNight.Text); //เป้าหมายกะกลางคืน 8 ชม
                                db.AddParameter("@NightTotal11hr", num2);

                                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error" + ex);
                            }

                           
               
                        }
        }
        #endregion

        #region "CallUpdate2()"
        int Man_total2 = 0;
        private void CallUpdate2()
        {

            if (txtMan_NT_OT2.Text == "")
            {
                MessageBox.Show("ช่องกรอกจำนวนพนักงาน OT กะเช้าห้ามเท่ากับค่าว่าง ");
                txtMan_NT_OT2.Focus();
                return;
            }
            if (txtMan_Night_OT2.Text == "")
            {
                MessageBox.Show("ช่องกรอกจำนวนพนักงาน OT กะดึกห้ามเท่ากับค่าว่าง ");
                txtMan_Night_OT2.Focus();
                return;
            }
            string tmpname = ConfigurationManager.AppSettings["SHOW_CELL2"];
            var query = new StringBuilder();


            DateTime now = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start = new TimeSpan(7, 30, 0); // 07:30
            TimeSpan end = new TimeSpan(17, 30, 0);   // 17:30

            TimeSpan start002 = new TimeSpan(17, 30, 0); // 17:30
            TimeSpan end002 = new TimeSpan(20, 30, 0);   // 20:30
            TimeSpan currentTime = now.TimeOfDay;
            //กะเช้า 7.30 - 17.00
            if (currentTime >= start && currentTime <= end)
            {
                //กะเช้า
                if (txtMan_NT_OT2.Text == "0" || txtMan_NT_OT2.Text == "" || txtMan_NT_OT2.Text != "")
                {
                    Man_total2 = Convert.ToInt32(txtperson2.Text);
                    txtMan_NT_OT2.Text = "0"; 
                }else
                {
                    Man_total2 = Convert.ToInt32(txtMan_NT_OT2.Text);
                    txtMan_NT_OT2.Text = "0"; 
                }
            }
            //กะเช้าช่วง OT 17.30-20.30
            if (currentTime >= start002 && currentTime <= end002)
            {
               // MessageBox.Show("17.30-20.30");
                if (txtMan_NT_OT2.Text != "0")
                {
                    Man_total2 = Convert.ToInt32(txtMan_NT_OT2.Text);
                }
                else
                {
                    Man_total2 = Convert.ToInt32(txtperson2.Text);
                    txtMan_NT_OT2.Text = "0";
                }
            }
         

            DateTime now_02 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
            TimeSpan start_02 = new TimeSpan(20, 30, 0); // 20:30
            TimeSpan end_02 = new TimeSpan(23, 59, 0);   // 23:59

            TimeSpan start_022 = new TimeSpan(0, 0, 0); // 00:00
            TimeSpan end_022 = new TimeSpan(05, 0, 0);   // 05:00

            TimeSpan start_0222 = new TimeSpan(5, 0, 0); // 05:00
            TimeSpan end_0222 = new TimeSpan(8, 0, 0);   // 07:30

            TimeSpan currentTime_02 = now_02.TimeOfDay;

            //เช็ค  กะดึก 20:30 - 23:59
            if (currentTime_02 >= start_02 && currentTime_02 <= end_02)
            {
                //กะดึก 
                if (txtMan_Night_OT2.Text == "0" || txtMan_Night_OT2.Text == "" || txtMan_Night_OT2.Text != "")
                {
                    Man_total2 = Convert.ToInt32(txtMan_Night2.Text);
                    txtMan_Night_OT2.Text = "0"; 
                }else
                {
                    Man_total2 = Convert.ToInt32(txtMan_Night_OT2.Text);
                    txtMan_Night_OT2.Text = "0"; 
                }

            }

            //เช็ค  กะดึก 0:00 - 05:00
            if (currentTime_02 >= start_022 && currentTime_02 <= end_022)
            {
                //กะดึก 
                if (txtMan_Night_OT2.Text == "0" || txtMan_Night_OT2.Text == "" || txtMan_Night_OT2.Text != "")
                {
                    Man_total2 = Convert.ToInt32(txtMan_Night2.Text);
                    txtMan_Night_OT2.Text = "0";
                }
                else
                {
                    Man_total2 = Convert.ToInt32(txtMan_Night_OT2.Text);
                    txtMan_Night_OT2.Text = "0";
                }

            }

            //กะดึกช่วง OT 05.00-08.00
            if (currentTime_02 >= start_0222 && currentTime_02 <= end_0222)
            {
                // MessageBox.Show("17.30-20.30");
                if (txtMan_Night_OT2.Text != "0")
                {
                    Man_total2 = Convert.ToInt32(txtMan_Night_OT2.Text);
                }
                else
                {
                    Man_total2 = Convert.ToInt32(txtperson2.Text);
                    txtMan_Night_OT2.Text = "0";
                }
            }
     
           
           
            query.Append("UPDATE dbo.Sewing_TargetDay  SET");



            query.Append(" Man_NT  = @Man_NT");
            query.Append(" ,Man_NT_OT  = @Man_NT_OT");
            query.Append(" ,Target8hr  = @Target8hr");
            query.Append(", Target3hr  = @Target3hr");
            query.Append(", Total11hr  = @Total11hr");
            //query.Append(", Issuedate  = @Issuedate");

            query.Append(", Mantotal  = @Mantotal");
            ////////กะดึก
            query.Append(", Man_Night  = @Man_Night");
            query.Append(", Man_Night_OT  = @Man_Night_OT");
            query.Append(", NightTarget8hr  = @NightTarget8hr");
            query.Append(", NightTarget3hr  = @NightTarget3hr");
            query.Append(", NightTotal11hr  = @NightTotal11hr");

           
           
 
            query.Append(", UserID  = @UserID");
            query.Append(" WHERE Sdate =  @Sdate");
            query.Append(" and Cellname =  @Cellname");



            using (var db = new DbHelper1())
            {
                try
                {
                    double qtytotal = 0;
                    if (Convert.ToDouble(txtperson2.Text.Trim()) == 5)
                    {
                        qtytotal = (3 * 8);
                        txttotal2.Text = qtytotal.ToString("#,##0.00");
                        qtytotal = (3 * 3);
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }
                    else if (Convert.ToDouble(txtperson2.Text.Trim()) == 4)
                    {
                        qtytotal = (2.4 * 8);
                        txttotal2.Text = qtytotal.ToString("#,##0.00");
                        qtytotal = (2.4 * 3);
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }

                    else
                    {
                        MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                        return;
                    }



                    //กะเช้าOT
                    double qtytotal4 = 0;
                    if (Convert.ToDouble(txtMan_NT_OT2.Text.Trim()) == 5)
                    {
                        qtytotal4 = (3 * 3);
                        txtperhead2.Text = qtytotal4.ToString("#,##0.00");

                    }
                    else if (Convert.ToDouble(txtMan_NT_OT2.Text.Trim()) == 4)
                    {
                        qtytotal4 = (2.4 * 3);
                        txtperhead2.Text = qtytotal4.ToString("#,##0.00");
  
                    }
                    else if (Convert.ToDouble(txtMan_NT_OT2.Text.Trim()) == 0)
                    {
                    
                        txtperhead2.Text = "0";

                    }
                    else
                    {
                        MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                        return;
                    }

                    ///กะดึก
                    double qtytotal2 = 0;
                    if (Convert.ToDouble(txtMan_Night2.Text.Trim()) == 5)
                    {
                        qtytotal2 = (3 * 8);
                        txttotalNight2.Text = qtytotal2.ToString("#,##0.00");
                        //qtytotal2 = (3 * 3);
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }
                    else if (Convert.ToDouble(txtMan_Night2.Text.Trim()) == 4)
                    {
                        qtytotal2 = (2.4 * 8);
                        txttotalNight2.Text = qtytotal2.ToString("#,##0.00");
                        //qtytotal2 = (2.4 * 3);
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }
                    else if (Convert.ToDouble(txtMan_Night2.Text.Trim()) == 0)
                    {
                      
                        txttotalNight2.Text = "0";
             
                    }
                    else
                    {
                        MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                        return;
                    }

                    ///กะดึกOT
                    double qtytotal3 = 0;
                    if (Convert.ToDouble(txtMan_Night_OT2.Text.Trim()) == 5)
                    {
                        qtytotal3 = (3 * 3);
                        txtperheadNight2.Text = qtytotal3.ToString("#,##0.00");
                        
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }
                    else if (Convert.ToDouble(txtMan_Night_OT2.Text.Trim()) == 4)
                    {
                        qtytotal3 = (2.4 * 3);
                        txtperheadNight2.Text = qtytotal3.ToString("#,##0.00");
                       
                        //txtperhead2.Text = qtytotal.ToString("#,##0.00");
                    }
                    else if (Convert.ToDouble(txtMan_Night_OT2.Text.Trim()) == 0)
                    {
                       
                        txtperheadNight2.Text = "0";
                    
                    }
                    else
                    {
                        MessageBox.Show("กรุุณาป้อนข้อมูลจำนวน 5 คน หรือ 4 คน เท่านั้นในการคำนวนยอด Target!!!");
                        return;
                    }

                    double num = (Convert.ToDouble(txttotal2.Text.Trim()) + Convert.ToDouble(txtperhead2.Text));
                    double num2 = (Convert.ToDouble(txttotalNight2.Text.Trim()) + Convert.ToDouble(txtperheadNight2.Text));
                    //double num = Convert.ToDouble(txttotal2.Text.Trim());
              
                 
                   
                   // db.AddParameter("@Issuedate", DateTime.Now);
                    db.AddParameter("@UserID", CGlobal.UserID);
                  

                    //กะเช้า
                    db.AddParameter("@Man_NT", this.txtperson2.Text);
                    db.AddParameter("@Man_NT_OT", this.txtMan_NT_OT2.Text);
                    db.AddParameter("@Target3hr", Convert.ToDouble(txtperhead2.Text));
                    db.AddParameter("@Target8hr", Convert.ToDouble(txttotal2.Text.Trim()));
                    db.AddParameter("@Total11hr", num);

                    //กะดึก
                    db.AddParameter("@Man_Night", this.txtMan_Night2.Text); //คนทำงานกะดึก 8 ชั่วโมง
                    db.AddParameter("@Man_Night_OT", this.txtMan_Night_OT2.Text); //คนทำงานกะดึก OT 
                    db.AddParameter("@NightTarget3hr", this.txtperheadNight2.Text); //เป้าหมายกะกลางคืน 3 ช่วง OT ชม
                    db.AddParameter("@NightTarget8hr", this.txttotalNight2.Text); //เป้าหมายกะกลางคืน 8 ชม
                    db.AddParameter("@NightTotal11hr", num2);
                    
                    db.AddParameter("@Sdate", this.lbldate.Text.Trim());
                    db.AddParameter("@Cellname", tmpname);
                    db.AddParameter("@Mantotal", Man_total2);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

               
              
            }
        }
        #endregion

        #region " CallUpdateTarget()"
        private void  CallUpdateTarget()
        {
            try
            {

                SqlConnection connection = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                string connetionString = null;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                SqlParameter param;
                DataSet ds = new DataSet();

                int i = 0;

                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[AA_GetPower_Target_SewingCell]";
           

                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);


                connection.Close();

            }
            catch (Exception ex)
            {
               
            }
        }
        #endregion

        private void bntadd_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึก Target นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))

                //Cellupdate 1
                CallUpdate1();
                CallUpdate2();


                DateTime now556 = DateTime.Now; // หรือใช้ DateTime.Parse("เวลาเฉพาะ")
                TimeSpan start556 = new TimeSpan(0, 0, 0); // 00:00
                TimeSpan end556 = new TimeSpan(8, 0, 0);   // 07:30
                TimeSpan currentTime556 = now556.TimeOfDay;
               
                string tmpdate;
                DateTime now = DateTime.Now;
                if (currentTime556 >= start556 && currentTime556 <= end556)
                {
                    tmpdate = now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    //กะเช้า 7.30 - 0.00
                    tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                }
           
                CallSearch(tmpdate);
                CallSearch2(tmpdate);

                CallUpdateTarget();
                Man_total = 0;
                Man_total2 = 0;
                CGlobal.CheckOn = "Yes";
                MessageBox.Show("Complete");
             
        }


    }
}
