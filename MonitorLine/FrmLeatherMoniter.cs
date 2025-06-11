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
    public partial class FrmLeatherMoniter : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        private int int_XPos = 0, int_YPos = 646;
        public FrmLeatherMoniter()
        {
            InitializeComponent();
        }

        private void FrmLeatherMoniter_Load(object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
          CallSearchDate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
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
                    lbltargetbody.Text = rs["TodayTragetBody"].ToString();
                    lbltargetback.Text = rs["TodayTragetBack"].ToString();
                    lbltargetseat.Text = rs["TodayTragetSeat"].ToString();

                    //วิ่งหาเวลา
                    string txt8body = rs["total8Body"].ToString();
                    string txt8back = rs["total8Back"].ToString();
                    string txt8seat = rs["total8Seat"].ToString();

                    if (txt8body != "0")
                    {
                        lbltimeI.Text = "08:00-09:00";
                        lblsumbody.Text = txt8body;
                        lblsumback.Text = txt8back;
                        lblsumseat.Text = txt8seat;
                    }

                    string txt9body = rs["total9Body"].ToString();
                    string txt9back = rs["total9Back"].ToString();
                    string txt9seat = rs["total9Seat"].ToString();

                    if (txt9body != "0")
                    {
                        lbltimeI.Text = "09.00-10:00";
                        lblsumbody.Text = txt9body;
                        lblsumback.Text = txt9back;
                        lblsumseat.Text = txt9seat;
                    }

                    string txt10body = rs["total10Body"].ToString();
                    string txt10back = rs["total10Back"].ToString();
                    string txt10seat = rs["total10Seat"].ToString();
                    if (txt10body != "0")
                    {
                        lbltimeI.Text = "10.00-11:00";
                        lblsumbody.Text = txt10body;
                        lblsumback.Text = txt10back;
                        lblsumseat.Text = txt10seat;
                    }
                    string txt11body = rs["total11Body"].ToString();
                    string txt11back = rs["total11Back"].ToString();
                    string txt11seat = rs["total11Seat"].ToString();
                    if (txt11body != "0")
                    {
                        lbltimeI.Text = "11.00-12:00";
                        lblsumbody.Text = txt11body;
                        lblsumback.Text = txt11back;
                        lblsumseat.Text = txt11seat;
                    }
                    string txt13body = rs["total13Body"].ToString();
                    string txt13back = rs["total13Back"].ToString();
                    string txt13seat = rs["total13Seat"].ToString();

                    if (txt13body != "0")
                    {
                        lbltimeI.Text = "13.00-14:00";
                        lblsumbody.Text = txt13body;
                        lblsumback.Text = txt13back;
                        lblsumseat.Text = txt13seat;
                    }
                    string txt14body = rs["total14Body"].ToString();
                    string txt14back = rs["total14Back"].ToString();
                    string txt14seat = rs["total14Seat"].ToString();
                    if (txt14body != "0")
                    {
                        lbltimeI.Text = "14.00-15:00";
                        lblsumbody.Text = txt14body;
                        lblsumback.Text = txt14back;
                        lblsumseat.Text = txt14seat;
                    }

                    string txt15body = rs["total15Body"].ToString();
                    string txt15back = rs["total15Back"].ToString();
                    string txt15seat = rs["total15Seat"].ToString();
                    if (txt15body != "0")
                    {
                        lbltimeI.Text = "15.00-16:00";
                        lblsumbody.Text = txt15body;
                        lblsumback.Text = txt15back;
                        lblsumseat.Text = txt15seat;
                    }
                    string txt16body = rs["total16Body"].ToString();
                    string txt16back = rs["total16Back"].ToString();
                    string txt16seat = rs["total16Seat"].ToString();
                    if (txt16body != "0")
                    {
                        lbltimeI.Text = "16.00-17:00";
                        lblsumbody.Text = txt16body;
                        lblsumback.Text = txt16back;
                        lblsumseat.Text = txt16seat;
                    }
                    string txt17body = rs["total17Body"].ToString();
                    string txt17back = rs["total17Back"].ToString();
                    string txt17seat = rs["total17Seat"].ToString();
                    if (txt17body != "0")
                    {
                        lbltimeI.Text = "17.30-18:30";
                        lblsumbody.Text = txt17body;
                        lblsumback.Text = txt17back;
                        lblsumseat.Text = txt17seat;
                    }
                    string txt18body = rs["total18Body"].ToString();
                    string txt18back = rs["total18Back"].ToString();
                    string txt18seat = rs["total18Seat"].ToString();
                    if (txt18body != "0")
                    {
                        lbltimeI.Text = "18.30-19:30";
                        lblsumbody.Text = txt18body;
                        lblsumback.Text = txt18back;
                        lblsumseat.Text = txt18seat;
                    }
                    string txt19body = rs["total19Body"].ToString();
                    string txt19back = rs["total19Back"].ToString();
                    string txt19seat = rs["total19Seat"].ToString();
                    if (txt19body != "0")
                    {
                        lbltimeI.Text = "19.30-20:30";
                        lblsumbody.Text = txt19body;
                        lblsumback.Text = txt19back;
                        lblsumseat.Text = txt19seat;
                    }
                    lbltotalboby.Text = rs["TotalOutputBody"].ToString();
                    lbltotalback.Text = rs["TotalOutputBack"].ToString();
                    lbltotalseat.Text = rs["TotalOutputSeat"].ToString();

                    string hrs = rs["Status"].ToString();

                    double sumseat1 = Convert.ToDouble(lbltotalback.Text) + Convert.ToDouble(lbltotalseat.Text);
                    double sum = (sumseat1 / 2); // seat unit
                    if (sum == 0.0)
                    {
                        this.lbltotalhr.Text = "0.00";
                    
                    }
                    else 
                    {
                        double sumhr = sum / Convert.ToDouble(hrs);  //หา arg per her
                        this.lbltotalhr.Text = sumhr.ToString("#,##0.00");
                    }
                 
                    this.lblunit.Text = sum.ToString("#,##0.00");

                    if (lbltargetback.Text == "0")
                    {
                        lbltargetseat.Text = "0";
                    }
                    else
                    {
                        double sumare = Convert.ToDouble(lbltotalhr.Text) / Convert.ToDouble(lbltargetback.Text);
                        double sumper = sumare * 100;
                        lbltargetseat.Text = sumper.ToString("#,###0.00")+"%";

                    }

                    // CGlobal.IDMonitor = rs["ID"].ToString();
                   // lblMessage.Text = rs["Status"].ToString(); ;

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

        private void lblsumbody_Click(object sender, EventArgs e)
        {

        }
    }
}
