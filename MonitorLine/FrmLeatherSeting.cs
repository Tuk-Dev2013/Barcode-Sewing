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


namespace PicklistBOM.MonitorLine
{
    public partial class FrmLeatherSeting : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmLeatherSeting()
        {
            InitializeComponent();
        }

        private void FrmLeatherSeting_Load(object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
           CallSearchDate();
        }

        #region"  CallSearchDate()"
        private void CallSearchDate()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Leather_Moniter "
              + " Where TagetDate='" + this.lbldate.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txttragetbody.Text = rs["TodayTragetBody"].ToString();
                    txttragetback.Text = rs["TodayTragetBack"].ToString();
                    txttragetSeat.Text = rs["TodayTragetSeat"].ToString();
                    txt8.Text = rs["total8Body"].ToString();
                    txt8_back.Text = rs["total8Back"].ToString();
                    txt8_Seat.Text = rs["total8Seat"].ToString();
                    txt9.Text = rs["total9Body"].ToString();
                    txt9_back.Text = rs["total9Back"].ToString();
                    txt9_Seat.Text = rs["total9Seat"].ToString();
                    txt10.Text = rs["total10Body"].ToString();
                    txt10_back.Text = rs["total10Back"].ToString();
                    txt10_Seat.Text = rs["total10Seat"].ToString();
                    txt11.Text = rs["total11Body"].ToString();
                    txt11_back.Text = rs["total11Back"].ToString();
                    txt11_Seat.Text = rs["total11Seat"].ToString();
                    txt13.Text = rs["total13Body"].ToString();
                    txt13_back.Text = rs["total13Back"].ToString();
                    txt13_Seat.Text = rs["total13Seat"].ToString();
                    txt14.Text = rs["total14Body"].ToString();
                    txt14_back.Text = rs["total14Back"].ToString();
                    txt14_Seat.Text = rs["total14Seat"].ToString();
                    txt15.Text = rs["total15Body"].ToString();
                    txt15_back.Text = rs["total15Back"].ToString();
                    txt15_Seat.Text = rs["total15Seat"].ToString();
                    txt16.Text = rs["total16Body"].ToString();
                    txt16_back.Text = rs["total16Back"].ToString();
                    txt16_Seat.Text = rs["total16Seat"].ToString();
                    txt17.Text = rs["total17Body"].ToString();
                    txt17_back.Text = rs["total17Back"].ToString();
                    txt17_Seat.Text = rs["total17Seat"].ToString();
                    txt18.Text = rs["total18Body"].ToString();
                    txt18_back.Text = rs["total18Back"].ToString();
                    txt18_Seat.Text = rs["total18Seat"].ToString();
                    txt19.Text = rs["total19Body"].ToString();
                    txt19_back.Text = rs["total19Back"].ToString();
                    txt19_Seat.Text = rs["total19Seat"].ToString();
                    txtoutputbody.Text = rs["TotalOutputBody"].ToString();
                    txtoutputback.Text = rs["TotalOutputBack"].ToString();
                    txtoutputseat.Text = rs["TotalOutputSeat"].ToString();
                    CGlobal.IDMonitor = rs["ID"].ToString();
                    txtmsg.Text = rs["Status"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("คุณใส่ข้อมูลไม่ถูกต้อง กรุณาใส่ตัวเลขเท่านั้นค่ะ");
                return;
            }
            conn.Close();

        }

        #endregion



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึกรายการ  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                //ค้นหาข้อมูล    this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchDate1();

                if ((CGlobal.IDMonitor == "") || (CGlobal.IDMonitor == null))
                {
                    //Insert

                    CallInsert();
                }
                else
                {
                    //Update
                 CallUpdate();

                }



            }
        }


        #region"  CallSearchDate()"
        private void CallSearchDate1()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Leather_Moniter "
              + " Where TagetDate='" + this.lbldate.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
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

        #region " CallInsert()"
        private void CallInsert()
        {
            //save
            var query = new StringBuilder();
            query.Append("INSERT INTO Leather_Moniter (TagetDate, TodayTragetBody, TodayTragetBack, TodayTragetSeat, total8Body, total8Back, total8Seat, total9Body, total9Back, total9Seat, "
               + " total10Body, total10Back, total10Seat, total11Body, total11Back, total11Seat, total13Body, total13Back, total13Seat, total14Body, total14Back,"
               + " total14Seat, total15Body, total15Back, total15Seat, total16Body, total16Back, total16Seat, total17Body, total17Back, total17Seat, total18Body,"
               + " total18Back, total18Seat, total19Body, total19Back, total19Seat, TotalOutputBody, TotalOutputBack, TotalOutputSeat, UserID, Sdate, Status )");
            query.Append(" VALUES (@TagetDate, @TodayTragetBody, @TodayTragetBack, @TodayTragetSeat, @total8Body, @total8Back, @total8Seat, @total9Body, @total9Back, @total9Seat,"
                + " @total10Body, @total10Back, @total10Seat, @total11Body, @total11Back, @total11Seat, @total13Body, @total13Back, @total13Seat, @total14Body, @total14Back,"
                + " @total14Seat, @total15Body, @total15Back, @total15Seat, @total16Body, @total16Back, @total16Seat, @total17Body, @total17Back, @total17Seat, @total18Body,"
                + " @total18Back, @total18Seat, @total19Body, @total19Back, @total19Seat, @TotalOutputBody, @TotalOutputBack, @TotalOutputSeat, @UserID, @Sdate, @Status )");

            using (var db = new DbHelper())
            {
                try
                {
                    double body = Convert.ToDouble(txt8.Text) + Convert.ToDouble(txt9.Text) + Convert.ToDouble(txt10.Text) + Convert.ToDouble(txt11.Text) + Convert.ToDouble(txt13.Text) + Convert.ToDouble(txt14.Text)
                       + Convert.ToDouble(txt15.Text) + Convert.ToDouble(txt16.Text) + Convert.ToDouble(txt17.Text) + Convert.ToDouble(txt18.Text) + Convert.ToDouble(txt19.Text);
                    this.txtoutputbody.Text = Convert.ToString(body);
                    double back = Convert.ToDouble(txt8_back.Text) + Convert.ToDouble(txt9_back.Text) + Convert.ToDouble(txt10_back.Text) + Convert.ToDouble(txt11_back.Text) + Convert.ToDouble(txt13_back.Text) + Convert.ToDouble(txt14_back.Text)
                        + Convert.ToDouble(txt15_back.Text) + Convert.ToDouble(txt16_back.Text) + Convert.ToDouble(txt17_back.Text) + Convert.ToDouble(txt18_back.Text) + Convert.ToDouble(txt19_back.Text);
                    this.txtoutputback.Text = Convert.ToString(back);
                    double Seat = Convert.ToDouble(txt8_Seat.Text) + Convert.ToDouble(txt9_Seat.Text) + Convert.ToDouble(txt10_Seat.Text) + Convert.ToDouble(txt11_Seat.Text) + Convert.ToDouble(txt13_Seat.Text) + Convert.ToDouble(txt14_Seat.Text)
                   + Convert.ToDouble(txt15_Seat.Text) + Convert.ToDouble(txt16_Seat.Text) + Convert.ToDouble(txt17_Seat.Text) + Convert.ToDouble(txt18_Seat.Text) + Convert.ToDouble(txt19_Seat.Text);
                    this.txtoutputseat.Text = Convert.ToString(Seat);

                    db.AddParameter("@TagetDate", this.lbldate.Text.Trim());
                    db.AddParameter("@TodayTragetBody", this.txttragetbody.Text.Trim());
                    db.AddParameter("@TodayTragetBack", this.txttragetback.Text.Trim());
                    db.AddParameter("@TodayTragetSeat", this.txttragetSeat.Text.Trim());
                    db.AddParameter("@total8Body", this.txt8.Text.Trim());
                    db.AddParameter("@total8Back", this.txt8_back.Text.Trim());
                    db.AddParameter("@total8Seat", this.txt8_Seat.Text.Trim());
                    db.AddParameter("@total9Body", this.txt9.Text.Trim());
                    db.AddParameter("@total9Back", this.txt9_back.Text.Trim());
                    db.AddParameter("@total9Seat", this.txt9_Seat.Text.Trim());
                    db.AddParameter("@total10Body", this.txt10.Text.Trim());
                    db.AddParameter("@total10Back", this.txt10_back.Text.Trim());
                    db.AddParameter("@total10Seat", this.txt10_Seat.Text.Trim());
                    db.AddParameter("@total11Body", this.txt11.Text.Trim());
                    db.AddParameter("@total11Back", this.txt11_back.Text.Trim());
                    db.AddParameter("@total11Seat", this.txt11_Seat.Text.Trim());
                    db.AddParameter("@total13Body", this.txt13.Text.Trim());
                    db.AddParameter("@total13Back", this.txt13_back.Text.Trim());
                    db.AddParameter("@total13Seat", this.txt13_Seat.Text.Trim());
                    db.AddParameter("@total14Body", this.txt14.Text.Trim());
                    db.AddParameter("@total14Back", this.txt14_back.Text.Trim());
                    db.AddParameter("@total14Seat", this.txt14_Seat.Text.Trim());
                    db.AddParameter("@total15Body", this.txt15.Text.Trim());
                    db.AddParameter("@total15Back", this.txt15_back.Text.Trim());
                    db.AddParameter("@total15Seat", this.txt15_Seat.Text.Trim());
                    db.AddParameter("@total16Body", this.txt16.Text.Trim());
                    db.AddParameter("@total16Back", this.txt16_back.Text.Trim());
                    db.AddParameter("@total16Seat", this.txt16_Seat.Text.Trim());
                    db.AddParameter("@total17Body", this.txt17.Text.Trim());
                    db.AddParameter("@total17Back", this.txt17_back.Text.Trim());
                    db.AddParameter("@total17Seat", this.txt17_Seat.Text.Trim());
                    db.AddParameter("@total18Body", this.txt18.Text.Trim());
                    db.AddParameter("@total18Back", this.txt18_back.Text.Trim());
                    db.AddParameter("@total18Seat", this.txt18_Seat.Text.Trim());
                    db.AddParameter("@total19Body", this.txt19.Text.Trim());
                    db.AddParameter("@total19Back", this.txt19_back.Text.Trim());
                    db.AddParameter("@total19Seat", this.txt19_Seat.Text.Trim());
                    db.AddParameter("@TotalOutputBody", this.txtoutputbody.Text.Trim());
                    db.AddParameter("@TotalOutputBack", this.txtoutputback.Text.Trim());
                    db.AddParameter("@TotalOutputSeat", this.txtoutputseat.Text.Trim());
                    db.AddParameter("@UserID", "Cut-Sewn");
                    db.AddParameter("@Sdate", DateTime.Now);
                    db.AddParameter("@Status", this.txtmsg.Text.Trim());
                    db.ExecuteNonQuery(query.ToString());
                    // MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("คุณใส่ข้อมูลไม่ถูกต้อง กรุณาใส่ตัวเลขเท่านั้นค่ะ");
                    return;

                }
            }
        
        
        }
        #endregion

        #region "CallInsert();"
        private void CallUpdate()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Leather_Moniter SET");
            query.Append(" TodayTragetBody  = @TodayTragetBody,");
            query.Append(" TodayTragetBack  = @TodayTragetBack,");
            query.Append(" TodayTragetSeat  = @TodayTragetSeat,");
            query.Append(" total8Body  = @total8Body,");
            query.Append(" total8Back  = @total8Back,");
            query.Append(" total8Seat  = @total8Seat,");
            query.Append(" total9Body  = @total9Body,");
            query.Append(" total9Back  = @total9Back,");
            query.Append(" total9Seat  = @total9Seat,");
            query.Append(" total10Body  = @total10Body,");
            query.Append(" total10Back  = @total10Back,");
            query.Append(" total10Seat  = @total10Seat,");
            query.Append(" total11Body  = @total11Body,");
            query.Append(" total11Back  = @total11Back,");
            query.Append(" total11Seat  = @total11Seat,");
            query.Append(" total13Body  = @total13Body,");
            query.Append(" total13Back  = @total13Back,");
            query.Append(" total13Seat  = @total13Seat,");
            query.Append(" total14Body  = @total14Body,");
            query.Append(" total14Back  = @total14Back,");
            query.Append(" total14Seat  = @total14Seat,");
            query.Append(" total15Body  = @total15Body,");
            query.Append(" total15Back  = @total15Back,");
            query.Append(" total15Seat  = @total15Seat,");
            query.Append(" total16Body  = @total16Body,");
            query.Append(" total16Back  = @total16Back,");
            query.Append(" total16Seat  = @total16Seat,");
            query.Append(" total17Body  = @total17Body,");
            query.Append(" total17Back  = @total17Back,");
            query.Append(" total17Seat  = @total17Seat,");
            query.Append(" total18Body  = @total18Body,");
            query.Append(" total18Back  = @total18Back,");
            query.Append(" total18Seat  = @total18Seat,");
            query.Append(" total19Body  = @total19Body,");
            query.Append(" total19Back  = @total19Back,");
            query.Append(" total19Seat  = @total19Seat,");
            query.Append(" Status  = @Status,");
            query.Append(" TotalOutputBody  = @TotalOutputBody,");
            query.Append(" TotalOutputBack  = @TotalOutputBack,");
            query.Append(" TotalOutputSeat  = @TotalOutputSeat");
            query.Append(" WHERE ID =  @ID");
            query.Append(" And TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {

                    double body = Convert.ToDouble(txt8.Text) + Convert.ToDouble(txt9.Text) + Convert.ToDouble(txt10.Text) + Convert.ToDouble(txt11.Text) + Convert.ToDouble(txt13.Text) + Convert.ToDouble(txt14.Text)
                        + Convert.ToDouble(txt15.Text) + Convert.ToDouble(txt16.Text) + Convert.ToDouble(txt17.Text) + Convert.ToDouble(txt18.Text) + Convert.ToDouble(txt19.Text);
                    this.txtoutputbody.Text = Convert.ToString(body);
                    double back = Convert.ToDouble(txt8_back.Text) + Convert.ToDouble(txt9_back.Text) + Convert.ToDouble(txt10_back.Text) + Convert.ToDouble(txt11_back.Text) + Convert.ToDouble(txt13_back.Text) + Convert.ToDouble(txt14_back.Text)
                        + Convert.ToDouble(txt15_back.Text) + Convert.ToDouble(txt16_back.Text) + Convert.ToDouble(txt17_back.Text) + Convert.ToDouble(txt18_back.Text) + Convert.ToDouble(txt19_back.Text);
                    this.txtoutputback.Text = Convert.ToString(back);
                    double Seat = Convert.ToDouble(txt8_Seat.Text) + Convert.ToDouble(txt9_Seat.Text) + Convert.ToDouble(txt10_Seat.Text) + Convert.ToDouble(txt11_Seat.Text) + Convert.ToDouble(txt13_Seat.Text) + Convert.ToDouble(txt14_Seat.Text)
                   + Convert.ToDouble(txt15_Seat.Text) + Convert.ToDouble(txt16_Seat.Text) + Convert.ToDouble(txt17_Seat.Text) + Convert.ToDouble(txt18_Seat.Text) + Convert.ToDouble(txt19_Seat.Text);
                    this.txtoutputseat.Text = Convert.ToString(Seat);



                    db.AddParameter("@TodayTragetBody", this.txttragetbody.Text.Trim());
                    db.AddParameter("@TodayTragetBack", this.txttragetback.Text.Trim());
                    db.AddParameter("@TodayTragetSeat", this.txttragetSeat.Text.Trim());
                    db.AddParameter("@total8Body", this.txt8.Text.Trim());
                    db.AddParameter("@total8Back", this.txt8_back.Text.Trim());
                    db.AddParameter("@total8Seat", this.txt8_Seat.Text.Trim());
                    db.AddParameter("@total9Body", this.txt9.Text.Trim());
                    db.AddParameter("@total9Back", this.txt9_back.Text.Trim());
                    db.AddParameter("@total9Seat", this.txt9_Seat.Text.Trim());
                    db.AddParameter("@total10Body", this.txt10.Text.Trim());
                    db.AddParameter("@total10Back", this.txt10_back.Text.Trim());
                    db.AddParameter("@total10Seat", this.txt10_Seat.Text.Trim());
                    db.AddParameter("@total11Body", this.txt11.Text.Trim());
                    db.AddParameter("@total11Back", this.txt11_back.Text.Trim());
                    db.AddParameter("@total11Seat", this.txt11_Seat.Text.Trim());
                    db.AddParameter("@total13Body", this.txt13.Text.Trim());
                    db.AddParameter("@total13Back", this.txt13_back.Text.Trim());
                    db.AddParameter("@total13Seat", this.txt13_Seat.Text.Trim());
                    db.AddParameter("@total14Body", this.txt14.Text.Trim());
                    db.AddParameter("@total14Back", this.txt14_back.Text.Trim());
                    db.AddParameter("@total14Seat", this.txt14_Seat.Text.Trim());
                    db.AddParameter("@total15Body", this.txt15.Text.Trim());
                    db.AddParameter("@total15Back", this.txt15_back.Text.Trim());
                    db.AddParameter("@total15Seat", this.txt15_Seat.Text.Trim());
                    db.AddParameter("@total16Body", this.txt16.Text.Trim());
                    db.AddParameter("@total16Back", this.txt16_back.Text.Trim());
                    db.AddParameter("@total16Seat", this.txt16_Seat.Text.Trim());
                    db.AddParameter("@total17Body", this.txt17.Text.Trim());
                    db.AddParameter("@total17Back", this.txt17_back.Text.Trim());
                    db.AddParameter("@total17Seat", this.txt17_Seat.Text.Trim());
                    db.AddParameter("@total18Body", this.txt18.Text.Trim());
                    db.AddParameter("@total18Back", this.txt18_back.Text.Trim());
                    db.AddParameter("@total18Seat", this.txt18_Seat.Text.Trim());
                    db.AddParameter("@total19Body", this.txt19.Text.Trim());
                    db.AddParameter("@total19Back", this.txt19_back.Text.Trim());
                    db.AddParameter("@total19Seat", this.txt19_Seat.Text.Trim());
                    db.AddParameter("@Status", this.txtmsg.Text.Trim());
                    db.AddParameter("@TotalOutputBody", this.txtoutputbody.Text);
                    db.AddParameter("@TotalOutputBack", this.txtoutputback.Text);
                    db.AddParameter("@TotalOutputSeat", this.txtoutputseat.Text);
                    db.AddParameter("@ID", CGlobal.IDMonitor);
                    db.AddParameter("@TagetDate", this.lbldate.Text.Trim());
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        
        
        
        }

        #endregion

    }
}
