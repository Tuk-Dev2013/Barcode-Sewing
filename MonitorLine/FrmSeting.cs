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
using System.Xml;


namespace PicklistBOM.MonitorLine
{
    public partial class FrmSeting : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmSeting()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSeting_Load(object sender, EventArgs e)
        {
           // this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            CallSearchDate();

            CallshowWeek();

        //    CallshowWeekTarget();
        }

        //#region "CallshowWeekTarget"
        //private void CallshowWeekTarget()
        //{
        //    System.Data.SqlClient.SqlCommand Cmd;
        //    System.Data.SqlClient.SqlDataReader rs;
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
        //    string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
        //    try
        //    {
        //        Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_MonitorWeek "
        //      + " Where TagetDate='" + day + "'", conn);
        //        conn.Open();
        //        rs = Cmd.ExecuteReader();
        //        while (rs.Read())
        //        {
        //           lblwk.Text = rs["Week"].ToString();
        //            txttargetweek.Text = rs["TargetWeek"].ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //    MessageBox.Show("No Data");
        //    }
        //    conn.Close();
        
        //}

        //#endregion "CallshowWeekTarget"


        #region " CallshowWeek();"
        private void CallshowWeek()
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
                lbldsat.Text = CGlobal.DayweekTotaldate;   
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblFri.Text = CGlobal.DayweekTotal;
                lbldfri.Text = CGlobal.DayweekTotaldate;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblThd.Text = CGlobal.DayweekTotal;
                lbldthu.Text = CGlobal.DayweekTotaldate;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lbldwed.Text = CGlobal.DayweekTotaldate;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                lblTue.Text = CGlobal.DayweekTotal;
                lbldtue.Text = CGlobal.DayweekTotaldate;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;

            }
            else if (temday == "Mon")
            {
                this.lblMon.BackColor = Color.Red;
                this.lblMon.ForeColor = Color.GhostWhite;
                //วันจันทร์
                CallSearchWeek(day);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;
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
                lbldtue.Text = CGlobal.DayweekTotaldate;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;

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
                lbldwed.Text = CGlobal.DayweekTotaldate;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;


                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lbldtue.Text = CGlobal.DayweekTotaldate;


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
                lbldthu.Text = CGlobal.DayweekTotaldate;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lbldtue.Text = CGlobal.DayweekTotaldate;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lbldwed.Text = CGlobal.DayweekTotaldate;

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
                lbldfri.Text = CGlobal.DayweekTotaldate;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lbldmon.Text = CGlobal.DayweekTotaldate;


                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lbldtue.Text = CGlobal.DayweekTotaldate;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lbldwed.Text = CGlobal.DayweekTotaldate;
                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                lblThd.Text = CGlobal.DayweekTotal;
                lbldthu.Text = CGlobal.DayweekTotaldate;

                lblSat.Text = "-";


            }

        
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
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_MonitorWeek "
              + " Where TagetDate='" + temdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.DayweekTotal = rs["TotalOutput"].ToString();
                    CGlobal.DayweekTotaldate = rs["TagetDate"].ToString();
                }

            }
            catch (Exception ex)
            {
                //    MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #region"  CallSearchDate1()"
        private void CallSearchDate1()
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
                    txttraget.Text = rs["TodayTraget"].ToString();
                    txt8.Text = rs["total8"].ToString();
                    txt9.Text = rs["total9"].ToString();
                    txt10.Text = rs["total10"].ToString();
                    txt11.Text = rs["total11"].ToString();
                    txt13.Text = rs["total13"].ToString();
                    txt14.Text = rs["total14"].ToString();
                    txt15.Text = rs["total15"].ToString();
                    txt16.Text = rs["total16"].ToString();
                    txt17.Text = rs["total17"].ToString();
                    txt18.Text = rs["total18"].ToString();
                    txt19.Text = rs["total19"].ToString();
                    //txtcell4.Text = rs["totalcell4"].ToString();
                    //txtcell5.Text = rs["totalcell5"].ToString();
                    txtoutput.Text = rs["TotalOutput"].ToString();
                    CGlobal.IDMonitor = rs["ID"].ToString();
                    txtmsg.Text = rs["Status"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #endregion



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            CallSearchDate111();

            CallshowWeek();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region "key number"

        private void txttraget_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt13_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt14_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt16_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt19_KeyPress(object sender, KeyPressEventArgs e)
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
        
        private void button1_Click(object sender, EventArgs e)
        {

            string temp = this.txttraget.Text;
            if ((MessageBox.Show(" คุณต้องการบันทึกรายการ  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                //ค้นหาข้อมูล    this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
              //  CallSearchDate1();

                if ((CGlobal.IDMonitor == "")||(CGlobal.IDMonitor==null))
                { 
                //Insert

                    CallInsert();
                }
                else 
                {
                //Update
               
                    CallUpdate();

                    CallUpdate1();

                }

                CallSearchDate();


            }
        }

        #region "CallUpdate1"
        private void CallUpdate1()
        {
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_MonitorWeek SET");
            query.Append(" TotalTarget  = @TotalTarget");
            query.Append(" WHERE TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@TotalTarget", txttraget.Text.Trim());
                    db.AddParameter("@TagetDate", day);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        
        }
        #endregion

        #region "CallSearchDatesum"
        private void CallSearchDatesum()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) as Qty from dbo.DocMODtlBarcodeLine "
              + " Where Sdate='" + tempdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.Barcode1 = rs["Qty"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
        
        }
        #endregion


        #region " CallUpdate()"
        private void CallUpdate()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_Monitor SET");
            query.Append(" TodayTraget  = @TodayTraget,");
            query.Append(" total8  = @total8,");
            query.Append(" total9  = @total9,");
            query.Append(" total10  = @total10,");
            query.Append(" total11  = @total11,");
            query.Append(" total13  = @total13,");
            query.Append(" total14  = @total14,");
            query.Append(" total15  = @total15,");
            query.Append(" total16  = @total16,");
            query.Append(" total17  = @total17,");
            query.Append(" total18  = @total18,");
            query.Append(" total19  = @total19,");
            query.Append(" Status  = @Status,");
            query.Append(" totalcell4  = @totalcell4,");
            query.Append(" totalcell5  = @totalcell5");
          //  query.Append(" TotalOutput  = @TotalOutput");
            query.Append(" WHERE ID =  @ID");
            query.Append(" And TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {

                   // string sum = this.txttraget.Text;
                    //Double num = Convert.ToDouble(txt8.Text) + Convert.ToDouble(txt9.Text) + Convert.ToDouble(txt10.Text) + Convert.ToDouble(txt11.Text) + Convert.ToDouble(txt13.Text) + Convert.ToDouble(txt14.Text)
                    //    + Convert.ToDouble(txt15.Text) + Convert.ToDouble(txt16.Text) + Convert.ToDouble(txt17.Text) + Convert.ToDouble(txt18.Text) + Convert.ToDouble(txt19.Text) + Convert.ToDouble(txtcell4.Text) + Convert.ToDouble(txtcell5.Text);
                    CallSearchDatesum();

                  //  double num = Convert.ToDouble(CGlobal.Barcode1) + Convert.ToDouble(txtcell4.Text) + Convert.ToDouble(txtcell5.Text);
                    
                    db.AddParameter("@TodayTraget", this.txttraget.Text.Trim());
                    db.AddParameter("@total8", this.txt8.Text.Trim());
                    db.AddParameter("@total9", this.txt9.Text.Trim());
                    db.AddParameter("@total10", this.txt10.Text.Trim());
                    db.AddParameter("@total11", this.txt11.Text.Trim());
                    db.AddParameter("@total13", this.txt13.Text.Trim());
                    db.AddParameter("@total14", this.txt14.Text.Trim());
                    db.AddParameter("@total15", this.txt15.Text.Trim());
                    db.AddParameter("@total16", this.txt16.Text.Trim());
                    db.AddParameter("@total17", this.txt17.Text.Trim());
                    db.AddParameter("@total18", this.txt18.Text.Trim());
                    db.AddParameter("@total19", this.txt19.Text.Trim());
                    db.AddParameter("@Status", this.txtmsg.Text.Trim());
                    db.AddParameter("@totalcell4", this.txtcell4.Text.Trim());
                    db.AddParameter("@totalcell5", this.txtcell5.Text.Trim());
                    //db.AddParameter("@TotalOutput", num);
                    db.AddParameter("@ID", CGlobal.IDMonitor);
                    db.AddParameter("@TagetDate",  this.lbldate.Text.Trim());
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        
        
        }
        #endregion

        #region "CallInsert()"
        private void CallInsert()
        {
            //save
            var query = new StringBuilder();
            query.Append("INSERT INTO Line_Monitor (TagetDate, TodayTraget, total8, total9, total10, total11, total13, total14, total15, total16, total17, total18, total19, TotalOutput, UserID, Sdate,  Status, totalcell4, totalcell5)");
            query.Append(" VALUES (@TagetDate, @TodayTraget, @total8, @total9, @total10, @total11, @total13, @total14, @total15, @total16, @total17, @total18, @total19, @TotalOutput, @UserID, @Sdate,  @Status, @totalcell4, @totalcell5)");

            using (var db = new DbHelper())
            {
                try
                {
                    //string tempdate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    db.AddParameter("@TagetDate", this.lbldate.Text.Trim());
                    db.AddParameter("@TodayTraget", this.txttraget.Text.Trim());
                    db.AddParameter("@total8", this.txt8.Text.Trim());
                    db.AddParameter("@total9", this.txt9.Text.Trim());
                    db.AddParameter("@total10", this.txt10.Text.Trim());
                    db.AddParameter("@total11", this.txt11.Text.Trim());
                    db.AddParameter("@total13", this.txt13.Text.Trim());
                    db.AddParameter("@total14", this.txt14.Text.Trim());
                    db.AddParameter("@total15", this.txt15.Text.Trim());
                    db.AddParameter("@total16", this.txt16.Text.Trim());
                    db.AddParameter("@total17", this.txt17.Text.Trim());
                    db.AddParameter("@total18", this.txt18.Text.Trim());
                    db.AddParameter("@total19", this.txt19.Text.Trim());
                    db.AddParameter("@TotalOutput", this.txtoutput.Text.Trim());
                    db.AddParameter("@UserID", "Production");
                    db.AddParameter("@Sdate", DateTime.Now);
                    db.AddParameter("@Status", this.txtmsg.Text.Trim());
                    db.AddParameter("@totalcell4", this.txtcell4.Text.Trim());
                    db.AddParameter("@totalcell5", this.txtcell5.Text.Trim());
                    db.ExecuteNonQuery(query.ToString());
                    // MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("Duplicate");

                }
            }
        
        
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
                    txttraget.Text = rs["TodayTraget"].ToString();
                    txt8.Text = rs["total8"].ToString();
                    txt9.Text = rs["total9"].ToString();
                    txt10.Text = rs["total10"].ToString();
                    txt11.Text = rs["total11"].ToString();
                    txt13.Text = rs["total13"].ToString();
                    txt14.Text = rs["total14"].ToString();
                    txt15.Text = rs["total15"].ToString();
                    txt16.Text = rs["total16"].ToString();
                    txt17.Text = rs["total17"].ToString();
                    txt18.Text = rs["total18"].ToString();
                    txt19.Text = rs["total19"].ToString();
                    txtcell4.Text = rs["totalcell4"].ToString();
                    txtcell5.Text = rs["totalcell5"].ToString();
                    txtoutput.Text = rs["TotalOutput"].ToString();
                    CGlobal.IDMonitor = rs["ID"].ToString();
                    txtmsg.Text = rs["Status"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
        
        }

        #endregion


        #region"  CallSearchDate11()"
        private void CallSearchDate111()
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
                 //   txttraget.Text = rs["TodayTraget"].ToString();
                    txt8.Text = rs["total8"].ToString();
                    txt9.Text = rs["total9"].ToString();
                    txt10.Text = rs["total10"].ToString();
                    txt11.Text = rs["total11"].ToString();
                    txt13.Text = rs["total13"].ToString();
                    txt14.Text = rs["total14"].ToString();
                    txt15.Text = rs["total15"].ToString();
                    txt16.Text = rs["total16"].ToString();
                    txt17.Text = rs["total17"].ToString();
                    txt18.Text = rs["total18"].ToString();
                    txt19.Text = rs["total19"].ToString();
                  //  txtcell4.Text = rs["totalcell4"].ToString();
                   // txtcell5.Text = rs["totalcell5"].ToString();
                    txtoutput.Text = rs["TotalOutput"].ToString();
                    CGlobal.IDMonitor = rs["ID"].ToString();
                    txtmsg.Text = rs["Status"].ToString(); ;
                    CGlobal.IDMonitor = rs["ID"].ToString();


                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        private void bntupdate_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึกรายการข้อมูล Target Day  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                //

                Update(lblMon.Text.Trim(), lbldmon.Text.Trim());
                Update(lblTue.Text.Trim(), lbldtue.Text.Trim());
                Update(lblWeb.Text.Trim(), lbldwed.Text.Trim());
                Update(lblThd.Text.Trim(), lbldthu.Text.Trim());
                Update(lblFri.Text.Trim(), lbldfri.Text.Trim());
                Update(lblSat.Text.Trim(), lbldsat.Text.Trim());

                CallshowWeek();

            }
        }

        #region "update"
        private void Update(string tmp1,string tempdate)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_MonitorWeek SET");
            query.Append(" TotalOutput  = @TotalOutput");
            query.Append(" WHERE TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@TotalOutput", tmp1);
                    db.AddParameter("@TagetDate", tempdate);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        }
        #endregion

        //private void bntsaveweek_Click(object sender, EventArgs e)
        //{
        //       if ((MessageBox.Show(" คุณต้องการบันทึกรายการข้อมูล Target Week  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
        //    {
        //        var query = new StringBuilder();
        //        query.Append("UPDATE dbo.Line_MonitorWeek SET");
        //        query.Append(" TargetWeek  = @TargetWeek");
        //        query.Append(" WHERE Week =  @Week");
        //        //query.Append(" and Week =  @Week");

        //        using (var db = new DbHelper1())
        //        {
        //            try
        //            {
        //                string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
        //                db.AddParameter("@TargetWeek", this.txttargetweek.Text.Trim());
        //               // db.AddParameter("@TagetDate", day);
        //                db.AddParameter("@Week", this.lblwk.Text.Trim());
        //                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error" + ex);
        //            }
        //        }
        //     }
        //}

        //private void txttargetweek_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar))
        //    {
        //        e.Handled = false;
        //    }
        //    else if (e.KeyChar == Convert.ToChar(Keys.Back))
        //    {
        //        e.Handled = false;
        //    }
        //    else if (e.KeyChar == Convert.ToChar(Keys.Delete))
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
