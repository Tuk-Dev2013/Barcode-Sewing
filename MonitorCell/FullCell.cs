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

namespace PicklistBOM.MonitorCell
{
    public partial class FullCell : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        Boolean Isfind4 = false;
        public FullCell()
        {
            InitializeComponent();
        }




        private void FullCell_Load(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.lbldate11.Text = day;
            //Cell0
            CallPO();
            CallLoad();
            CallTargettotal();
            CallLoadToday();
            //Cell1
            CallPO1();
            CallLoad1();
            CallTargettotal1();
            CallLoadToday1();
            //Cell2
            CallPO2();
            CallLoad2();
            CallTargettotal2();
            CallLoadToday2();

            //Cell3
            CallPO3();
            CallLoad3();
            CallTargettotal3();
            CallLoadToday3();


            //Cell4
            CallPO4();
            CallTargettotal4();
            CallLoadToday4();


            //Cell5
            CallPO5();
            CallTargettotal5();
            CallLoadToday5();


            //Cell6
            CallPO6();
            CallLoad6();
            CallTargettotal6();
            CallLoadToday6();

            //Cell7
            CallPO7();
            CallLoad7();
            CallTargettotal7();
            CallLoadToday7();

            //Cell8
            CallPO8();
            CallLoad8();
            CallTargettotal8();
            CallLoadToday8();

            //Cell9
            CallPO9();
            CallLoad9();
            CallTargettotal9();
            CallLoadToday9();

            //Cell10
            CallPO10();
            CallLoad10();
            CallTargettotal10();
            CallLoadToday10();


            //Cell11
            CallPO11();
            CallLoad11();
            CallTargettotal11();
            CallLoadToday11();

            //CellT2
            CallPOT2();
            CallLoadT2();
            CallTargettotalT2();
            CallLoadTodayT2();

            //Cell12
            CallPO12();
            CallLoad12();
            CallTargettotal12();
            CallLoadToday12();

            //Cell13
            CallPO13();
            CallLoad13();
            CallTargettotal13();
            CallLoadToday13();

            //Cell14
            CallPO14();
            CallLoad14();
            CallTargettotal14();
            CallLoadToday14();

            //Cell15
            CallPO15();
            CallLoad15();
            CallTargettotal15();
            CallLoadToday15();

            //CellS1
            CallPOS1();
            CallLoadS1();
            CallTargettotalS1();
            CallLoadTodayS1();



            //line Product
            CallSearchDate();

            CallWeek();

            Callsumsofa(); //sum sofa
            Callsumchari(); // sum chari

            CallCalulateSumTotal();

            //string time
            Callstdtime("CELL");
            Callstdtime("CELL T2");
            Callstdtime("CELL 1");
            Callstdtime("CELL 2");
            Callstdtime("CELL 3");
            Callstdtime("CELL 4");
            Callstdtime("CELL 5");
            Callstdtime("CELL 6");
            Callstdtime("CELL 7");
            Callstdtime("CELL 8");
            Callstdtime("CELL 9");
            Callstdtime("CELL 10");
            Callstdtime("CELL 11");
            Callstdtime("CELL 12");
            Callstdtime("CELL 13");
            Callstdtime("CELL 14");
            Callstdtime("CELL 15");
            Callstdtime("CELL S1");

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
                string temdqate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_Monitor "
              + " Where TagetDate='" + temdqate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltargetP.Text = rs["TodayTraget"].ToString();
                    lbltargetPM.Text = rs["TodayTraget"].ToString();

                  //  lblsofa4.Text = rs["totalcell4"].ToString();
                  //  lblsofa5.Text = rs["totalcell5"].ToString();

                    //วิ่งหาเวลา
                    string txt8 = rs["total8"].ToString();

                    //if (txt8 != "0")
                    //{
                    //    lbltimeI.Text = "08:00-09:00";
                    //    lblsum.Text = txt8;
                    //}

                    //string txt9 = rs["total9"].ToString();

                    //if (txt9 != "0")
                    //{
                    //    lbltimeI.Text = "09.00-10:00";
                    //    lblsum.Text = txt9;
                    //}

                    //string txt10 = rs["total10"].ToString();
                    //if (txt10 != "0")
                    //{
                    //    lbltimeI.Text = "10.00-11:00";
                    //    lblsum.Text = txt10;
                    //}
                    //string txt11 = rs["total11"].ToString();
                    //if (txt11 != "0")
                    //{
                    //    lbltimeI.Text = "11.00-12:00";
                    //    lblsum.Text = txt11;
                    //}
                    //string txt13 = rs["total13"].ToString();
                    //if (txt13 != "0")
                    //{
                    //    lbltimeI.Text = "13.00-14:00";
                    //    lblsum.Text = txt13;
                    //}
                    //string txt14 = rs["total14"].ToString();
                    //if (txt14 != "0")
                    //{
                    //    lbltimeI.Text = "14.00-15:00";
                    //    lblsum.Text = txt14;
                    //}
                    //string txt15 = rs["total15"].ToString();
                    //if (txt15 != "0")
                    //{
                    //    lbltimeI.Text = "15.00-16:00";
                    //    lblsum.Text = txt15;
                    //}
                    //string txt16 = rs["total16"].ToString();
                    //if (txt16 != "0")
                    //{
                    //    lbltimeI.Text = "16.00-17:00";
                    //    lblsum.Text = txt16;
                    //}
                    //string txt17 = rs["total17"].ToString();
                    //if (txt17 != "0")
                    //{
                    //    lbltimeI.Text = "17.30-18:30";
                    //    lblsum.Text = txt17;
                    //}
                    //string txt18 = rs["total18"].ToString();
                    //if (txt18 != "0")
                    //{
                    //    lbltimeI.Text = "18.30-19:30";
                    //    lblsum.Text = txt18;
                    //}
                    //string txt19 = rs["total19"].ToString();
                    //if (txt19 != "0")
                    //{
                    //    lbltimeI.Text = "19.30-20:30";
                    //    lblsum.Text = txt19;
                    //}
                  //  lbltotalP.Text = rs["TotalOutput"].ToString();
                    CGlobal.TotalOutput30 = rs["TotalOutput"].ToString();
                  //  lblMessage.Text = rs["Status"].ToString(); ;

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
                lblSatM.Text = CGlobal.DayweekTotal;
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotal;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
                lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

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

                this.lblMonM.BackColor = Color.Red;
                this.lblMonM.ForeColor = Color.GhostWhite;
                lblMonM.Text = CGlobal.DayweekTotal;
                lblTueM.Text = "-";
                lblWebM.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";

            }
            else if (temday == "Tue")
            {
                this.lblTue.BackColor = Color.Red;
                this.lblTue.ForeColor = Color.GhostWhite;

                this.lblTueM.BackColor = Color.Red;
                this.lblTueM.ForeColor = Color.GhostWhite;
                //วันอังคาร
                CallSearchWeek(day);
                lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;


                lblWeb.Text = "-";
                lblThd.Text = "-";
                lblFri.Text = "-";
                lblSat.Text = "-";

                lblWebM.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }

            else if (temday == "Wed")
            {
                this.lblWeb.BackColor = Color.Red;
                this.lblWeb.ForeColor = Color.GhostWhite;
                this.lblWebM.BackColor = Color.Red;
                this.lblWebM.ForeColor = Color.GhostWhite;
                //วันพุธ
                CallSearchWeek(day);
                lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                lblThd.Text = "-";
                lblFri.Text = "-";
                lblSat.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }
            else if (temday == "Thu")
            {
                this.lblThd.BackColor = Color.Red;
                this.lblThd.ForeColor = Color.GhostWhite;
                this.lblThdM.BackColor = Color.Red;
                this.lblThdM.ForeColor = Color.GhostWhite;
                //วันพฤ
                CallSearchWeek(day);
                lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

                lblFri.Text = "-";
                lblSat.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";

            }
            else if (temday == "Fri")
            {
                this.lblFri.BackColor = Color.Red;
                this.lblFri.ForeColor = Color.GhostWhite;
                this.lblFriM.BackColor = Color.Red;
                this.lblFriM.ForeColor = Color.GhostWhite;
                //วันศุก
                CallSearchWeek(day);
                lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotal;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
                lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
                lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
                lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
                lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;

                lblSatM.Text = "-";

            }


        }

        #endregion

        //Cell0
        #region "CallPO"
        private void CallPO()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.cellpo00 = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad()"
        private void CallLoad()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + CGlobal.cellpo00 + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO.Text = CGlobal.cellpo00;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        #region "CallTargettotal();"
        private void CallTargettotal()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltargetM.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday();"
        private void CallLoadToday()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotalM.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        //Cell1
        #region "CallPO1"
        private void CallPO1()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 1' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.cellpo0 = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad1()"
        private void CallLoad1()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + CGlobal.cellpo0 + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO1.Text = CGlobal.cellpo0;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget1.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual1.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance1.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        #region "CallTargettotal1();"
        private void CallTargettotal1()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 1'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget1.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget1M.Text = rs["TargetOutput"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday1();"
        private void CallLoadToday1()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 1' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal1.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal1M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

    //Cell2
        #region "CallPO2"
        private void CallPO2()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 2' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.cellpo2 = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad()2"
        private void CallLoad2()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + CGlobal.cellpo2 + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO2.Text = CGlobal.cellpo2;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget2.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual2.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance2.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        #region "CallTargettotal2();"
        private void CallTargettotal2()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 2'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget2.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget2M.Text = rs["TargetOutput"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday2();"
        private void CallLoadToday2()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 2' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal2.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal2M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        //Cell3
        #region "CallPO3"
        private void CallPO3()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 3' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.cellpo3 = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad()3"
        private void CallLoad3()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + CGlobal.cellpo3 + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO3.Text = CGlobal.cellpo3;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget3.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual3.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance3.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        #region "CallTargettotal3();"
        private void CallTargettotal3()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 3'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget3.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget3M.Text = rs["TargetOutput"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday3();"
        private void CallLoadToday3()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 3' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotal3.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal3M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion


          //Cell 4
        #region "CallTargettotal4();"
        private void CallTargettotal4()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 4'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget4.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget4M.Text = rs["TargetOutput"].ToString();


                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad()4"
        private void CallLoad4()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO4.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget4.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual4.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance4.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        #region "CallLoadToday4();"
        private void CallLoadToday4()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa4.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 4' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblsofa4.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal4M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO4"
        private void CallPO4()
        {
            lblPO4.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 4' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO4.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        //Cell 5
        #region "CallTargettotal5();"
        private void CallTargettotal5()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 5'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget5.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget5M.Text = rs["TargetOutput"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday5();"
        private void CallLoadToday5()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa5.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 5' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblsofa5.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal5M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO5"
        private void CallPO5()
        {
            lblPO5.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 5' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                 lblPO5.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad5()5"
        private void CallLoad5()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO5.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget5.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual5.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance5.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion
        
        //Cell 6
        #region "CallTargettotal6();"
        private void CallTargettotal6()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 6'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltotaltarget6.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget6M.Text = rs["TargetOutput"].ToString();

                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday6();"
        private void CallLoadToday6()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa6.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 6' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblsofa6.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal6M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO6"
        private void CallPO6()
        {
            lblPO6.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 6' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO6.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad6()"
        private void CallLoad6()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO6.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget6.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual6.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance6.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //Cell 7
        #region "CallTargettotal7();"
        private void CallTargettotal7()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 7'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget7.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget7M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday7();"
        private void CallLoadToday7()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa7.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 7' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lblsofa7.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal7M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO7"
        private void CallPO7()
        {
            lblPO7.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 7' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO7.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad7()"
        private void CallLoad7()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO7.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget7.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual7.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance7.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //Cell 8
        #region "CallTargettotal8();"
        private void CallTargettotal8()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 8'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget8.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget8M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }
        #endregion
        #region "CallLoadToday8();"
        private void CallLoadToday8()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa8.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 8' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lblsofa8.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal8M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO8"
        private void CallPO8()
        {
            lblPO8.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 8' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO8.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad8()"
        private void CallLoad8()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO8.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget8.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual8.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance8.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //Cell 9
        #region "CallTargettotal9();"
        private void CallTargettotal9()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 9'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget9.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget9M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday9();"
        private void CallLoadToday9()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa9.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 9' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lblsofa9.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal9M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO9"
        private void CallPO9()
        {
            lblPO9.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 9' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO9.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad9()"
        private void CallLoad9()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO9.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget9.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual9.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance9.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell10
        #region "CallTargettotal10();"
        private void CallTargettotal10()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 10'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget10.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget10M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday10();"
        private void CallLoadToday10()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa10.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 10' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lblsofa10.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal10M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO10"
        private void CallPO10()
        {
            lblPO10.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 10' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO10.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad10()"
        private void CallLoad10()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO10.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget10.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual10.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance10.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell11
        #region "CallTargettotal11();"
        private void CallTargettotal11()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 11'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget11.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget11M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday11();"
        private void CallLoadToday11()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lblsofa11.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 11' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lblsofa11.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal11M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO11"
        private void CallPO11()
        {
            lblPO11.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 11' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO11.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad11()"
        private void CallLoad11()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO11.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //lblPO4.Text = CGlobal.cellpo4;
                    //  double num = Convert.ToDouble(CGlobal.sumtarget);
                    // lbltarget.Text = num.ToString("#,##0");
                    lbltarget11.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual11.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");


                    // lblbalance.Text = Convert.ToDouble(rs["QtyBal"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance11.Text = num1.ToString("#,##0");


                    // TOTAL
                    //lbltotalT.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    //// lbltotalT.Text = num.ToString("#,##0");
                    //lblTotalA.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    //lblToablB.Text = num1.ToString("#,##0");

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cellT2
        #region "CallTargettotalT2();"
        private void CallTargettotalT2()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL T2'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltargetT2.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltargetTM.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadTodayT2();"
        private void CallLoadTodayT2()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotalT2.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL T2' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotalT2.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotalTM.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");

                    //lbltotaltargetTM
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPOT2"
        private void CallPOT2()
        {
            lblPOT2.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL T2' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                        lblPOT2.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadT2()"
        private void CallLoadT2()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPOT2.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltargetT2.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactualT2.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalanceT2.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell12
        #region "CallTargettotal12();"
        private void CallTargettotal12()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 12'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget12.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget12M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday12();"
        private void CallLoadToday12()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotal12.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 12' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotal12.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal12M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO12"
        private void CallPO12()
        {
            lblPO12.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 12' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO12.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad12()"
        private void CallLoad12()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO12.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltarget12.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual12.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance12.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell13
        #region "CallTargettotal13();"
        private void CallTargettotal13()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 13'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget13.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget13M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday13();"
        private void CallLoadToday13()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotal13.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 13' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotal13.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal13M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO13"
        private void CallPO13()
        {
            lblPO13.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 13' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO13.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad13()"
        private void CallLoad13()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO13.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltarget13.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual133.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance13.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell14
        #region "CallTargettotal14();"
        private void CallTargettotal14()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 14'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget14.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget14M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday14();"
        private void CallLoadToday14()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotal14.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 14' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotal14.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal14M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO14"
        private void CallPO14()
        {
            lblPO14.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 14' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO14.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad14()"
        private void CallLoad14()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO14.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltarget14.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual14.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance14.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cell15
        #region "CallTargettotal15();"
        private void CallTargettotal15()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL 15'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltarget15.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltarget15M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadToday15();"
        private void CallLoadToday15()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotal15.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 15' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotal15.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotal15M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPO15"
        private void CallPO15()
        {
            lblPO15.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL 15' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPO15.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoad15()"
        private void CallLoad15()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPO15.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltarget15.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactual15.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalance15.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion

        //cellS1
        #region "CallTargettotalS1();"
        private void CallTargettotalS1()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + resultdate + "'  and Status ='CELL S1'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lbltotaltargetS1.Text = rs["TargetOutput"].ToString();
                    this.lbltotaltargetS1M.Text = rs["TargetOutput"].ToString();
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadTodayS1();"
        private void CallLoadTodayS1()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                this.lbltotalS1.Text = "0";
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL S1' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    this.lbltotalS1.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                    this.lbltotalS1M.Text = Convert.ToDouble(rs["Total"]).ToString("#,##0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallPOS1"
        private void CallPOS1()
        {
            lblPOS1.Text = "";
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select Top 1 DocID,DocNo  from dbo.DocMODtlBarcode where TypeCell='CELL S1' and Sdate='" + tempdate + "'   order by DocID desc", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lblPOS1.Text = rs["DocNo"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion
        #region "CallLoadS1()"
        private void CallLoadS1()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
                Cmd = new System.Data.SqlClient.SqlCommand(" Select SUM(QtyBom) As QtyBom, SUM(QtyOut) As QtyOut ,SUM(QtyBal) As QtyBal  from dbo.DocMODtl  where   DocNo ='" + lblPOS1.Text.Trim() + "' and DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + ")", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    lbltargetS1.Text = Convert.ToDouble(rs["QtyBom"]).ToString("#,##0");
                    lblactualS1.Text = Convert.ToDouble(rs["QtyOut"]).ToString("#,##0");
                    double num1 = (Convert.ToDouble(rs["QtyOut"]) - Convert.ToDouble(rs["QtyBom"]));
                    lblbalanceS1.Text = num1.ToString("#,##0");
                }

            }
            catch (Exception ex)
            {
            }
            conn.Close();



        }

        #endregion


// Line Production
        //#region "SumQtyLine2()"
        //private void SumQtyLine2()
        //{
        //    System.Data.SqlClient.SqlCommand Cmd;
        //    System.Data.SqlClient.SqlDataReader rs;
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //   // string tempsql = ConfigurationManager.AppSettings["SHOW_CELL"];
        //    //conn.Open();
        //    try
        //    {
        //        string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
        //        Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Sum(Qty) As total FROM  DocMODtlBarcodeLine  where TypeCell ='Production Line2' and Sdate='" + resultdate + "'", conn);
        //        conn.Open();
        //        rs = Cmd.ExecuteReader();
        //        while (rs.Read())
        //        {
        //            String num = Convert.ToDouble(rs["total"]).ToString("#,###0");
        //            lblLine2.Text = num;
        //            lblLine2M.Text = num;
        //        }

        //        // Callgridview();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    conn.Close();
        //}
        //#endregion
        //#region "SumQtyLine1()"
        //private void SumQtyLine1()
        //{
        //    System.Data.SqlClient.SqlCommand Cmd;
        //    System.Data.SqlClient.SqlDataReader rs;
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //    // string tempsql = ConfigurationManager.AppSettings["SHOW_CELL"];
        //    //conn.Open();
        //    try
        //    {
        //        string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
        //        Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Sum(Qty) As total FROM  DocMODtlBarcodeLine where TypeCell ='Production Line1' and Sdate='" + resultdate + "'", conn);
        //        conn.Open();
        //        rs = Cmd.ExecuteReader();
        //        while (rs.Read())
        //        {
        //            String num = Convert.ToDouble(rs["total"]).ToString("#,###0");
        //            lblLine1.Text = num;
        //            lblLine1M.Text = num;
        //        }

        //        // Callgridview();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    conn.Close();
        //}
        //#endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
           
          
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
                Cmd = new System.Data.SqlClient.SqlCommand(" select TotalOutput  from dbo.Line_MonitorWeek where TagetDate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String num = Convert.ToDouble(rs["TotalOutput"]).ToString("#,###0");
                    this.lbltotalP.Text = num;
                    lbltotalPM.Text = num;
                  // UpdateMonitorWeek(this.lbltotal.Text);
                    CGlobal.TotalOutput30 = "0";
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullCell));
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSat = new System.Windows.Forms.Label();
            this.lblFri = new System.Windows.Forms.Label();
            this.lblThd = new System.Windows.Forms.Label();
            this.lblWeb = new System.Windows.Forms.Label();
            this.lblTue = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbltotalP = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbltargetP = new System.Windows.Forms.Label();
            this.lblsum = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbltimeI = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lbltotaltarget = new System.Windows.Forms.Label();
            this.lblbalance = new System.Windows.Forms.Label();
            this.lblactual = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.lbltarget = new System.Windows.Forms.Label();
            this.lblCell = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblbalance1 = new System.Windows.Forms.Label();
            this.lblactual1 = new System.Windows.Forms.Label();
            this.lbltarget1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPO1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbltotal1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotaltarget1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblbalance2 = new System.Windows.Forms.Label();
            this.lblactual2 = new System.Windows.Forms.Label();
            this.lbltarget2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblPO2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lbltotal2 = new System.Windows.Forms.Label();
            this.lbltotaltarget2 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblbalance3 = new System.Windows.Forms.Label();
            this.lblactual3 = new System.Windows.Forms.Label();
            this.lbltarget3 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblPO3 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lbltotal3 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lbltotaltarget3 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblbalance4 = new System.Windows.Forms.Label();
            this.lblactual4 = new System.Windows.Forms.Label();
            this.lbltarget4 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.lblPO4 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lbltotaltarget4 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblsofa4 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblbalance5 = new System.Windows.Forms.Label();
            this.lblPO5 = new System.Windows.Forms.Label();
            this.lblactual5 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.lbltarget5 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.lbltotaltarget5 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lblsofa5 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblbalance6 = new System.Windows.Forms.Label();
            this.lblPO6 = new System.Windows.Forms.Label();
            this.lblactual6 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lbltarget6 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.lbltotaltarget6 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.lblsofa6 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label91 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.lblwktotal = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label57M = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.lblsumM = new System.Windows.Forms.Label();
            this.lbltime1 = new System.Windows.Forms.Label();
            this.lbltargetPM = new System.Windows.Forms.Label();
            this.lbldate11 = new System.Windows.Forms.Label();
            this.lbltotalPM = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label218 = new System.Windows.Forms.Label();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.label211 = new System.Windows.Forms.Label();
            this.lblstdS1 = new System.Windows.Forms.Label();
            this.lbltotalS1M = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.label216 = new System.Windows.Forms.Label();
            this.lbltotaltargetS1M = new System.Windows.Forms.Label();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.label204 = new System.Windows.Forms.Label();
            this.lblstd13 = new System.Windows.Forms.Label();
            this.lbltotal13M = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.lbltotaltarget13M = new System.Windows.Forms.Label();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.label197 = new System.Windows.Forms.Label();
            this.lblstd122 = new System.Windows.Forms.Label();
            this.lbltotal12M = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.lbltotaltarget12M = new System.Windows.Forms.Label();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.label188 = new System.Windows.Forms.Label();
            this.lblstd15 = new System.Windows.Forms.Label();
            this.lbltotal15M = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.lbltotaltarget15M = new System.Windows.Forms.Label();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.label94 = new System.Windows.Forms.Label();
            this.lblstd14 = new System.Windows.Forms.Label();
            this.lbltotal14M = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.lbltotaltarget14M = new System.Windows.Forms.Label();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.label86 = new System.Windows.Forms.Label();
            this.lblstdT2 = new System.Windows.Forms.Label();
            this.lbltotalTM = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.lbltotaltargetTM = new System.Windows.Forms.Label();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label191 = new System.Windows.Forms.Label();
            this.lblstd12 = new System.Windows.Forms.Label();
            this.lbltotal11M = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.lbltotaltarget11M = new System.Windows.Forms.Label();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label183 = new System.Windows.Forms.Label();
            this.lblstd8 = new System.Windows.Forms.Label();
            this.lbltotal7M = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.lbltotaltarget7M = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.label189 = new System.Windows.Forms.Label();
            this.lblstd11 = new System.Windows.Forms.Label();
            this.lbltotal10M = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.lbltotaltarget10M = new System.Windows.Forms.Label();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label181 = new System.Windows.Forms.Label();
            this.lblstd7 = new System.Windows.Forms.Label();
            this.lbltotal6M = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.lbltotaltarget6M = new System.Windows.Forms.Label();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label187 = new System.Windows.Forms.Label();
            this.lblstd10 = new System.Windows.Forms.Label();
            this.lbltotal9M = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.lbltotaltarget9M = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label179 = new System.Windows.Forms.Label();
            this.lblstd6 = new System.Windows.Forms.Label();
            this.lbltotal5M = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.lbltotaltarget5M = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label168 = new System.Windows.Forms.Label();
            this.lblstd4 = new System.Windows.Forms.Label();
            this.lbltotal3M = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.lbltotaltarget3M = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label158 = new System.Windows.Forms.Label();
            this.lblstd3 = new System.Windows.Forms.Label();
            this.lbltotal2M = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.lbltotaltarget2M = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label147 = new System.Windows.Forms.Label();
            this.lblstd2 = new System.Windows.Forms.Label();
            this.lbltotal1M = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.lbltotaltarget1M = new System.Windows.Forms.Label();
            this.label60M = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label185 = new System.Windows.Forms.Label();
            this.lblstd9 = new System.Windows.Forms.Label();
            this.lbltotal8M = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.lbltotaltarget8M = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label173 = new System.Windows.Forms.Label();
            this.lblstd5 = new System.Windows.Forms.Label();
            this.lbltotal4M = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.lbltotaltarget4M = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.lblstd1 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.lbltotalM = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.lbltotaltargetM = new System.Windows.Forms.Label();
            this.lblLine2M = new System.Windows.Forms.Label();
            this.lblLine1M = new System.Windows.Forms.Label();
            this.lblSatM = new System.Windows.Forms.Label();
            this.lblFriM = new System.Windows.Forms.Label();
            this.lblThdM = new System.Windows.Forms.Label();
            this.lblWebM = new System.Windows.Forms.Label();
            this.lblTueM = new System.Windows.Forms.Label();
            this.lblMonM = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.lblbalanceT2 = new System.Windows.Forms.Label();
            this.lblactualT2 = new System.Windows.Forms.Label();
            this.lbltargetT2 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.lblPOT2 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.lbltotalT2 = new System.Windows.Forms.Label();
            this.label224 = new System.Windows.Forms.Label();
            this.lbltotaltargetT2 = new System.Windows.Forms.Label();
            this.label226 = new System.Windows.Forms.Label();
            this.label227 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lblbalance10 = new System.Windows.Forms.Label();
            this.lblPO10 = new System.Windows.Forms.Label();
            this.lblactual10 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.lbltarget10 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.lbltotaltarget10 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.lblsofa10 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblbalance9 = new System.Windows.Forms.Label();
            this.lblPO9 = new System.Windows.Forms.Label();
            this.lblactual9 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.lbltarget9 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.lbltotaltarget9 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.lblsofa9 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblbalance8 = new System.Windows.Forms.Label();
            this.lblPO8 = new System.Windows.Forms.Label();
            this.lblactual8 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.lbltarget8 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.lbltotaltarget8 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.lblsofa8 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblbalance7 = new System.Windows.Forms.Label();
            this.lblPO7 = new System.Windows.Forms.Label();
            this.lblactual7 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.lbltarget7 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.lbltotaltarget7 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.lblsofa7 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.lblactual13 = new System.Windows.Forms.TabPage();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.lblbalanceS1 = new System.Windows.Forms.Label();
            this.lblactualS1 = new System.Windows.Forms.Label();
            this.lbltargetS1 = new System.Windows.Forms.Label();
            this.label268 = new System.Windows.Forms.Label();
            this.label269 = new System.Windows.Forms.Label();
            this.label270 = new System.Windows.Forms.Label();
            this.label271 = new System.Windows.Forms.Label();
            this.lblPOS1 = new System.Windows.Forms.Label();
            this.label273 = new System.Windows.Forms.Label();
            this.lbltotaltargetS1 = new System.Windows.Forms.Label();
            this.label275 = new System.Windows.Forms.Label();
            this.lbltotalS1 = new System.Windows.Forms.Label();
            this.label277 = new System.Windows.Forms.Label();
            this.label278 = new System.Windows.Forms.Label();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.lblbalance15 = new System.Windows.Forms.Label();
            this.lblactual15 = new System.Windows.Forms.Label();
            this.lbltarget15 = new System.Windows.Forms.Label();
            this.label254 = new System.Windows.Forms.Label();
            this.label255 = new System.Windows.Forms.Label();
            this.label256 = new System.Windows.Forms.Label();
            this.label257 = new System.Windows.Forms.Label();
            this.lblPO15 = new System.Windows.Forms.Label();
            this.label259 = new System.Windows.Forms.Label();
            this.lbltotaltarget15 = new System.Windows.Forms.Label();
            this.label261 = new System.Windows.Forms.Label();
            this.lbltotal15 = new System.Windows.Forms.Label();
            this.label263 = new System.Windows.Forms.Label();
            this.label264 = new System.Windows.Forms.Label();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.lblbalance14 = new System.Windows.Forms.Label();
            this.lblactual14 = new System.Windows.Forms.Label();
            this.lbltarget14 = new System.Windows.Forms.Label();
            this.label228 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.label232 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.lblPO14 = new System.Windows.Forms.Label();
            this.label237 = new System.Windows.Forms.Label();
            this.lbltotaltarget14 = new System.Windows.Forms.Label();
            this.label244 = new System.Windows.Forms.Label();
            this.lbltotal14 = new System.Windows.Forms.Label();
            this.label249 = new System.Windows.Forms.Label();
            this.label250 = new System.Windows.Forms.Label();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.lblbalance13 = new System.Windows.Forms.Label();
            this.lblactual133 = new System.Windows.Forms.Label();
            this.lbltarget13 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.label239 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.label241 = new System.Windows.Forms.Label();
            this.lblPO13 = new System.Windows.Forms.Label();
            this.label243 = new System.Windows.Forms.Label();
            this.lbltotaltarget13 = new System.Windows.Forms.Label();
            this.label245 = new System.Windows.Forms.Label();
            this.lbltotal13 = new System.Windows.Forms.Label();
            this.label247 = new System.Windows.Forms.Label();
            this.label248 = new System.Windows.Forms.Label();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.lblbalance12 = new System.Windows.Forms.Label();
            this.lblactual12 = new System.Windows.Forms.Label();
            this.lbltarget12 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.label225 = new System.Windows.Forms.Label();
            this.lblPO12 = new System.Windows.Forms.Label();
            this.label229 = new System.Windows.Forms.Label();
            this.lbltotaltarget12 = new System.Windows.Forms.Label();
            this.label231 = new System.Windows.Forms.Label();
            this.lbltotal12 = new System.Windows.Forms.Label();
            this.label233 = new System.Windows.Forms.Label();
            this.label234 = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.lblbalance11 = new System.Windows.Forms.Label();
            this.lblactual11 = new System.Windows.Forms.Label();
            this.lbltarget11 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.lblPO11 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.lbltotaltarget11 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.lblsofa11 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.lblactual13.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineShape4
            // 
            this.lineShape4.BorderWidth = 3;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 39;
            this.lineShape4.X2 = 626;
            this.lineShape4.Y1 = 256;
            this.lineShape4.Y2 = 254;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4});
            this.shapeContainer1.Size = new System.Drawing.Size(1335, 743);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 33);
            this.label5.TabIndex = 129;
            this.label5.Text = "CELL T1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.label60);
            this.groupBox1.Controls.Add(this.label57);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.lblLine1);
            this.groupBox1.Controls.Add(this.lblLine2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSat);
            this.groupBox1.Controls.Add(this.lblFri);
            this.groupBox1.Controls.Add(this.lblThd);
            this.groupBox1.Controls.Add(this.lblWeb);
            this.groupBox1.Controls.Add(this.lblTue);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.lblMon);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.lbltotalP);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lbltargetP);
            this.groupBox1.Controls.Add(this.lblsum);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lbltimeI);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(30, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(10, 21);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label60
            // 
            this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label60.BackColor = System.Drawing.Color.Black;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(151, 39);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(0, 47);
            this.label60.TabIndex = 154;
            this.label60.Text = "0";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label57.ForeColor = System.Drawing.Color.Aqua;
            this.label57.Location = new System.Drawing.Point(416, 40);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(0, 47);
            this.label57.TabIndex = 153;
            this.label57.Text = "0";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label54.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label54.Location = new System.Drawing.Point(148, 9);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(134, 29);
            this.label54.TabIndex = 151;
            this.label54.Text = "SUM LINE";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label50.Location = new System.Drawing.Point(409, 10);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(137, 29);
            this.label50.TabIndex = 152;
            this.label50.Text = "SUM SOFA";
            // 
            // lblLine1
            // 
            this.lblLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine1.BackColor = System.Drawing.Color.Black;
            this.lblLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLine1.ForeColor = System.Drawing.Color.Yellow;
            this.lblLine1.Location = new System.Drawing.Point(12, 39);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(0, 47);
            this.lblLine1.TabIndex = 149;
            this.lblLine1.Text = "0";
            this.lblLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine2
            // 
            this.lblLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine2.BackColor = System.Drawing.Color.Black;
            this.lblLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLine2.ForeColor = System.Drawing.Color.Yellow;
            this.lblLine2.Location = new System.Drawing.Point(12, 120);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(0, 47);
            this.lblLine2.TabIndex = 148;
            this.lblLine2.Text = "0";
            this.lblLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 147;
            this.label1.Text = "Pro Line 2.";
            // 
            // lblSat
            // 
            this.lblSat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSat.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSat.ForeColor = System.Drawing.Color.Yellow;
            this.lblSat.Location = new System.Drawing.Point(458, 206);
            this.lblSat.Name = "lblSat";
            this.lblSat.Size = new System.Drawing.Size(0, 35);
            this.lblSat.TabIndex = 146;
            this.lblSat.Text = "0";
            this.lblSat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFri
            // 
            this.lblFri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFri.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblFri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFri.ForeColor = System.Drawing.Color.Yellow;
            this.lblFri.Location = new System.Drawing.Point(370, 206);
            this.lblFri.Name = "lblFri";
            this.lblFri.Size = new System.Drawing.Size(0, 35);
            this.lblFri.TabIndex = 145;
            this.lblFri.Text = "0";
            this.lblFri.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblThd
            // 
            this.lblThd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThd.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblThd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblThd.ForeColor = System.Drawing.Color.Yellow;
            this.lblThd.Location = new System.Drawing.Point(280, 206);
            this.lblThd.Name = "lblThd";
            this.lblThd.Size = new System.Drawing.Size(0, 35);
            this.lblThd.TabIndex = 144;
            this.lblThd.Text = "0";
            this.lblThd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWeb
            // 
            this.lblWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeb.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWeb.ForeColor = System.Drawing.Color.Yellow;
            this.lblWeb.Location = new System.Drawing.Point(191, 206);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(0, 35);
            this.lblWeb.TabIndex = 143;
            this.lblWeb.Text = "0";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTue
            // 
            this.lblTue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTue.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTue.ForeColor = System.Drawing.Color.Yellow;
            this.lblTue.Location = new System.Drawing.Point(101, 206);
            this.lblTue.Name = "lblTue";
            this.lblTue.Size = new System.Drawing.Size(0, 35);
            this.lblTue.TabIndex = 138;
            this.lblTue.Text = "0";
            this.lblTue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label30.Location = new System.Drawing.Point(466, 178);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(57, 26);
            this.label30.TabIndex = 142;
            this.label30.Text = "SAT";
            // 
            // lblMon
            // 
            this.lblMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMon.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMon.ForeColor = System.Drawing.Color.Yellow;
            this.lblMon.Location = new System.Drawing.Point(12, 206);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(0, 35);
            this.lblMon.TabIndex = 137;
            this.lblMon.Text = "0";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label31.Location = new System.Drawing.Point(383, 179);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 26);
            this.label31.TabIndex = 141;
            this.label31.Text = "FRI";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(289, 179);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 26);
            this.label25.TabIndex = 140;
            this.label25.Text = "THD";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label28.Location = new System.Drawing.Point(199, 179);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 26);
            this.label28.TabIndex = 139;
            this.label28.Text = "WED";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(109, 179);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 26);
            this.label19.TabIndex = 138;
            this.label19.Text = "TUE";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label24.Location = new System.Drawing.Point(18, 179);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 26);
            this.label24.TabIndex = 137;
            this.label24.Text = "MON";
            // 
            // lbltotalP
            // 
            this.lbltotalP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalP.BackColor = System.Drawing.Color.Black;
            this.lbltotalP.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalP.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbltotalP.Location = new System.Drawing.Point(354, 118);
            this.lbltotalP.Name = "lbltotalP";
            this.lbltotalP.Size = new System.Drawing.Size(0, 58);
            this.lbltotalP.TabIndex = 138;
            this.lbltotalP.Text = "0";
            this.lbltotalP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.Purple;
            this.label12.Location = new System.Drawing.Point(356, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 29);
            this.label12.TabIndex = 138;
            this.label12.Text = "ACCUMULATE";
            // 
            // lbltargetP
            // 
            this.lbltargetP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltargetP.BackColor = System.Drawing.Color.Black;
            this.lbltargetP.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltargetP.ForeColor = System.Drawing.Color.Red;
            this.lbltargetP.Location = new System.Drawing.Point(159, 118);
            this.lbltargetP.Name = "lbltargetP";
            this.lbltargetP.Size = new System.Drawing.Size(0, 58);
            this.lbltargetP.TabIndex = 137;
            this.lbltargetP.Text = "0";
            this.lbltargetP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblsum
            // 
            this.lblsum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsum.BackColor = System.Drawing.Color.Black;
            this.lblsum.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsum.ForeColor = System.Drawing.Color.Gold;
            this.lblsum.Location = new System.Drawing.Point(283, 40);
            this.lblsum.Name = "lblsum";
            this.lblsum.Size = new System.Drawing.Size(0, 47);
            this.lblsum.TabIndex = 133;
            this.lblsum.Text = "0";
            this.lblsum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.ForeColor = System.Drawing.Color.Purple;
            this.label15.Location = new System.Drawing.Point(188, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 29);
            this.label15.TabIndex = 137;
            this.label15.Text = "TARGET";
            // 
            // lbltimeI
            // 
            this.lbltimeI.AutoSize = true;
            this.lbltimeI.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltimeI.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lbltimeI.Location = new System.Drawing.Point(281, 9);
            this.lbltimeI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltimeI.Name = "lbltimeI";
            this.lbltimeI.Size = new System.Drawing.Size(133, 29);
            this.lbltimeI.TabIndex = 132;
            this.lbltimeI.Text = "SUM CELL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(7, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 29);
            this.label11.TabIndex = 131;
            this.label11.Text = "Pro Line1.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.lbltotal);
            this.groupBox2.Controls.Add(this.lbltotaltarget);
            this.groupBox2.Controls.Add(this.lblbalance);
            this.groupBox2.Controls.Add(this.lblactual);
            this.groupBox2.Controls.Add(this.lblPO);
            this.groupBox2.Controls.Add(this.lbltarget);
            this.groupBox2.Controls.Add(this.lblCell);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(26, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 217);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            // 
            // lbltotal
            // 
            this.lbltotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal.BackColor = System.Drawing.Color.Black;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal.Location = new System.Drawing.Point(361, 47);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(185, 48);
            this.lbltotal.TabIndex = 136;
            this.lbltotal.Text = "0";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotaltarget
            // 
            this.lbltotaltarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget.Location = new System.Drawing.Point(148, 47);
            this.lbltotaltarget.Name = "lbltotaltarget";
            this.lbltotaltarget.Size = new System.Drawing.Size(173, 48);
            this.lbltotaltarget.TabIndex = 135;
            this.lbltotaltarget.Text = "0";
            this.lbltotaltarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblbalance
            // 
            this.lblbalance.BackColor = System.Drawing.Color.Black;
            this.lblbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance.Location = new System.Drawing.Point(405, 164);
            this.lblbalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance.Name = "lblbalance";
            this.lblbalance.Size = new System.Drawing.Size(138, 43);
            this.lblbalance.TabIndex = 141;
            this.lblbalance.Text = "0";
            this.lblbalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual
            // 
            this.lblactual.BackColor = System.Drawing.Color.Black;
            this.lblactual.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual.Location = new System.Drawing.Point(269, 164);
            this.lblactual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual.Name = "lblactual";
            this.lblactual.Size = new System.Drawing.Size(134, 43);
            this.lblactual.TabIndex = 140;
            this.lblactual.Text = "0";
            this.lblactual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO
            // 
            this.lblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO.ForeColor = System.Drawing.Color.Blue;
            this.lblPO.Location = new System.Drawing.Point(159, 98);
            this.lblPO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(355, 33);
            this.lblPO.TabIndex = 140;
            this.lblPO.Text = "56300/C14/8";
            // 
            // lbltarget
            // 
            this.lbltarget.BackColor = System.Drawing.Color.Black;
            this.lbltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget.Location = new System.Drawing.Point(131, 163);
            this.lbltarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget.Name = "lbltarget";
            this.lbltarget.Size = new System.Drawing.Size(137, 44);
            this.lbltarget.TabIndex = 139;
            this.lbltarget.Text = "0";
            this.lbltarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCell
            // 
            this.lblCell.AutoSize = true;
            this.lblCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCell.Location = new System.Drawing.Point(19, 99);
            this.lblCell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(133, 25);
            this.lblCell.TabIndex = 139;
            this.lblCell.Text = "CELL 0 PO#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(16, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 33);
            this.label4.TabIndex = 138;
            this.label4.Text = "TOTAL";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Green;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.Tomato;
            this.label6.Location = new System.Drawing.Point(405, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 31);
            this.label6.TabIndex = 137;
            this.label6.Text = "Balance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Green;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Tomato;
            this.label7.Location = new System.Drawing.Point(269, 131);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 31);
            this.label7.TabIndex = 136;
            this.label7.Text = "Actual";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Green;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.Tomato;
            this.label10.Location = new System.Drawing.Point(132, 131);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 31);
            this.label10.TabIndex = 135;
            this.label10.Text = "Batch";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.Purple;
            this.label9.Location = new System.Drawing.Point(355, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 31);
            this.label9.TabIndex = 136;
            this.label9.Text = "Today Output";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Purple;
            this.label8.Location = new System.Drawing.Point(137, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 31);
            this.label8.TabIndex = 135;
            this.label8.Text = "Today Target";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.lblbalance1);
            this.groupBox3.Controls.Add(this.lblactual1);
            this.groupBox3.Controls.Add(this.lbltarget1);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.lblPO1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lbltotal1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lbltotaltarget1);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(26, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 220);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            // 
            // lblbalance1
            // 
            this.lblbalance1.BackColor = System.Drawing.Color.Black;
            this.lblbalance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance1.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance1.Location = new System.Drawing.Point(406, 165);
            this.lblbalance1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance1.Name = "lblbalance1";
            this.lblbalance1.Size = new System.Drawing.Size(138, 48);
            this.lblbalance1.TabIndex = 154;
            this.lblbalance1.Text = "0";
            this.lblbalance1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual1
            // 
            this.lblactual1.BackColor = System.Drawing.Color.Black;
            this.lblactual1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual1.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual1.Location = new System.Drawing.Point(270, 165);
            this.lblactual1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual1.Name = "lblactual1";
            this.lblactual1.Size = new System.Drawing.Size(134, 48);
            this.lblactual1.TabIndex = 153;
            this.lblactual1.Text = "0";
            this.lblactual1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget1
            // 
            this.lbltarget1.BackColor = System.Drawing.Color.Black;
            this.lbltarget1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget1.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget1.Location = new System.Drawing.Point(132, 164);
            this.lbltarget1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget1.Name = "lbltarget1";
            this.lbltarget1.Size = new System.Drawing.Size(137, 49);
            this.lbltarget1.TabIndex = 152;
            this.lbltarget1.Text = "0";
            this.lbltarget1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label20.Location = new System.Drawing.Point(17, 175);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 33);
            this.label20.TabIndex = 151;
            this.label20.Text = "TOTAL";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Green;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.ForeColor = System.Drawing.Color.Tomato;
            this.label21.Location = new System.Drawing.Point(406, 129);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(138, 34);
            this.label21.TabIndex = 150;
            this.label21.Text = "Balance";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Green;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.ForeColor = System.Drawing.Color.Tomato;
            this.label22.Location = new System.Drawing.Point(270, 129);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(135, 34);
            this.label22.TabIndex = 149;
            this.label22.Text = "Actual";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Green;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.ForeColor = System.Drawing.Color.Tomato;
            this.label23.Location = new System.Drawing.Point(133, 129);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 34);
            this.label23.TabIndex = 148;
            this.label23.Text = "Batch";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO1
            // 
            this.lblPO1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO1.ForeColor = System.Drawing.Color.Blue;
            this.lblPO1.Location = new System.Drawing.Point(160, 95);
            this.lblPO1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO1.Name = "lblPO1";
            this.lblPO1.Size = new System.Drawing.Size(355, 33);
            this.lblPO1.TabIndex = 147;
            this.lblPO1.Text = "56300/C14/8";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label16.Location = new System.Drawing.Point(17, 96);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 25);
            this.label16.TabIndex = 146;
            this.label16.Text = "CELL 1 PO#";
            // 
            // lbltotal1
            // 
            this.lbltotal1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal1.BackColor = System.Drawing.Color.Black;
            this.lbltotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal1.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal1.Location = new System.Drawing.Point(354, 42);
            this.lbltotal1.Name = "lbltotal1";
            this.lbltotal1.Size = new System.Drawing.Size(190, 49);
            this.lbltotal1.TabIndex = 144;
            this.lbltotal1.Text = "0";
            this.lbltotal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 33);
            this.label2.TabIndex = 129;
            this.label2.Text = "CELL 1";
            // 
            // lbltotaltarget1
            // 
            this.lbltotaltarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget1.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget1.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget1.Location = new System.Drawing.Point(153, 42);
            this.lbltotaltarget1.Name = "lbltotaltarget1";
            this.lbltotaltarget1.Size = new System.Drawing.Size(178, 48);
            this.lbltotaltarget1.TabIndex = 142;
            this.lbltotaltarget1.Text = "0";
            this.lbltotaltarget1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.Purple;
            this.label14.Location = new System.Drawing.Point(147, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 31);
            this.label14.TabIndex = 143;
            this.label14.Text = "Today Target";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.Purple;
            this.label13.Location = new System.Drawing.Point(351, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(191, 31);
            this.label13.TabIndex = 145;
            this.label13.Text = "Today Output";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox4.Controls.Add(this.lblbalance2);
            this.groupBox4.Controls.Add(this.lblactual2);
            this.groupBox4.Controls.Add(this.lbltarget2);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.lblPO2);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.lbltotal2);
            this.groupBox4.Controls.Add(this.lbltotaltarget2);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(26, 471);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 241);
            this.groupBox4.TabIndex = 134;
            this.groupBox4.TabStop = false;
            // 
            // lblbalance2
            // 
            this.lblbalance2.BackColor = System.Drawing.Color.Black;
            this.lblbalance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance2.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance2.Location = new System.Drawing.Point(405, 166);
            this.lblbalance2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance2.Name = "lblbalance2";
            this.lblbalance2.Size = new System.Drawing.Size(138, 47);
            this.lblbalance2.TabIndex = 156;
            this.lblbalance2.Text = "0";
            this.lblbalance2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblactual2
            // 
            this.lblactual2.BackColor = System.Drawing.Color.Black;
            this.lblactual2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual2.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual2.Location = new System.Drawing.Point(269, 166);
            this.lblactual2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual2.Name = "lblactual2";
            this.lblactual2.Size = new System.Drawing.Size(135, 47);
            this.lblactual2.TabIndex = 155;
            this.lblactual2.Text = "0";
            this.lblactual2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbltarget2
            // 
            this.lbltarget2.BackColor = System.Drawing.Color.Black;
            this.lbltarget2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget2.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget2.Location = new System.Drawing.Point(132, 166);
            this.lbltarget2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget2.Name = "lbltarget2";
            this.lbltarget2.Size = new System.Drawing.Size(136, 47);
            this.lbltarget2.TabIndex = 154;
            this.lbltarget2.Text = "0";
            this.lbltarget2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label33.Location = new System.Drawing.Point(21, 176);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(103, 33);
            this.label33.TabIndex = 153;
            this.label33.Text = "TOTAL";
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Green;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label34.ForeColor = System.Drawing.Color.Tomato;
            this.label34.Location = new System.Drawing.Point(405, 130);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(138, 36);
            this.label34.TabIndex = 152;
            this.label34.Text = "Balance";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Green;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label35.ForeColor = System.Drawing.Color.Tomato;
            this.label35.Location = new System.Drawing.Point(269, 130);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(135, 36);
            this.label35.TabIndex = 151;
            this.label35.Text = "Actual";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Green;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label36.ForeColor = System.Drawing.Color.Tomato;
            this.label36.Location = new System.Drawing.Point(132, 130);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(136, 36);
            this.label36.TabIndex = 150;
            this.label36.Text = "Batch";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO2
            // 
            this.lblPO2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO2.ForeColor = System.Drawing.Color.Blue;
            this.lblPO2.Location = new System.Drawing.Point(159, 94);
            this.lblPO2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO2.Name = "lblPO2";
            this.lblPO2.Size = new System.Drawing.Size(384, 34);
            this.lblPO2.TabIndex = 143;
            this.lblPO2.Text = "56300/C14/8";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label29.Location = new System.Drawing.Point(16, 97);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(133, 25);
            this.label29.TabIndex = 142;
            this.label29.Text = "CELL 2 PO#";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // lbltotal2
            // 
            this.lbltotal2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal2.BackColor = System.Drawing.Color.Black;
            this.lbltotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal2.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal2.Location = new System.Drawing.Point(358, 46);
            this.lbltotal2.Name = "lbltotal2";
            this.lbltotal2.Size = new System.Drawing.Size(185, 46);
            this.lbltotal2.TabIndex = 148;
            this.lbltotal2.Text = "0";
            this.lbltotal2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotaltarget2
            // 
            this.lbltotaltarget2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget2.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget2.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget2.Location = new System.Drawing.Point(173, 46);
            this.lbltotaltarget2.Name = "lbltotaltarget2";
            this.lbltotaltarget2.Size = new System.Drawing.Size(173, 45);
            this.lbltotaltarget2.TabIndex = 146;
            this.lbltotaltarget2.Text = "0";
            this.lbltotaltarget2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label26.ForeColor = System.Drawing.Color.Purple;
            this.label26.Location = new System.Drawing.Point(158, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(188, 31);
            this.label26.TabIndex = 147;
            this.label26.Text = "Today Target";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.ForeColor = System.Drawing.Color.Purple;
            this.label27.Location = new System.Drawing.Point(352, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(191, 31);
            this.label27.TabIndex = 149;
            this.label27.Text = "Today Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 33);
            this.label3.TabIndex = 129;
            this.label3.Text = "CELL 2";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbldate.Location = new System.Drawing.Point(1, 28);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(18, 25);
            this.lbldate.TabIndex = 135;
            this.lbldate.Text = " ";
            this.lbldate.Visible = false;
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbltime.Location = new System.Drawing.Point(4, 3);
            this.lbltime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(60, 25);
            this.lbltime.TabIndex = 136;
            this.lbltime.Text = "Time";
            this.lbltime.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox5.Controls.Add(this.lblbalance3);
            this.groupBox5.Controls.Add(this.lblactual3);
            this.groupBox5.Controls.Add(this.lbltarget3);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.lblPO3);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.lbltotal3);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.lbltotaltarget3);
            this.groupBox5.Controls.Add(this.label46);
            this.groupBox5.Controls.Add(this.label47);
            this.groupBox5.Location = new System.Drawing.Point(609, 241);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(556, 220);
            this.groupBox5.TabIndex = 155;
            this.groupBox5.TabStop = false;
            // 
            // lblbalance3
            // 
            this.lblbalance3.BackColor = System.Drawing.Color.Black;
            this.lblbalance3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance3.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance3.Location = new System.Drawing.Point(407, 163);
            this.lblbalance3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance3.Name = "lblbalance3";
            this.lblbalance3.Size = new System.Drawing.Size(138, 46);
            this.lblbalance3.TabIndex = 154;
            this.lblbalance3.Text = "0";
            this.lblbalance3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual3
            // 
            this.lblactual3.BackColor = System.Drawing.Color.Black;
            this.lblactual3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual3.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual3.Location = new System.Drawing.Point(271, 163);
            this.lblactual3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual3.Name = "lblactual3";
            this.lblactual3.Size = new System.Drawing.Size(135, 46);
            this.lblactual3.TabIndex = 153;
            this.lblactual3.Text = "0";
            this.lblactual3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget3
            // 
            this.lbltarget3.BackColor = System.Drawing.Color.Black;
            this.lbltarget3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget3.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget3.Location = new System.Drawing.Point(134, 163);
            this.lbltarget3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget3.Name = "lbltarget3";
            this.lbltarget3.Size = new System.Drawing.Size(136, 46);
            this.lbltarget3.TabIndex = 152;
            this.lbltarget3.Text = "0";
            this.lbltarget3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label37.Location = new System.Drawing.Point(23, 176);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(103, 33);
            this.label37.TabIndex = 151;
            this.label37.Text = "TOTAL";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Green;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label38.ForeColor = System.Drawing.Color.Tomato;
            this.label38.Location = new System.Drawing.Point(407, 127);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(138, 36);
            this.label38.TabIndex = 150;
            this.label38.Text = "Balance";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Green;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label39.ForeColor = System.Drawing.Color.Tomato;
            this.label39.Location = new System.Drawing.Point(271, 127);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(135, 36);
            this.label39.TabIndex = 149;
            this.label39.Text = "Actual";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Green;
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label40.ForeColor = System.Drawing.Color.Tomato;
            this.label40.Location = new System.Drawing.Point(134, 127);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(136, 36);
            this.label40.TabIndex = 148;
            this.label40.Text = "Batch";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label40.Click += new System.EventHandler(this.label40_Click);
            // 
            // lblPO3
            // 
            this.lblPO3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO3.ForeColor = System.Drawing.Color.Blue;
            this.lblPO3.Location = new System.Drawing.Point(160, 92);
            this.lblPO3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO3.Name = "lblPO3";
            this.lblPO3.Size = new System.Drawing.Size(355, 35);
            this.lblPO3.TabIndex = 147;
            this.lblPO3.Text = "56300/C14/8";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label42.Location = new System.Drawing.Point(17, 98);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(133, 25);
            this.label42.TabIndex = 146;
            this.label42.Text = "CELL 3 PO#";
            // 
            // lbltotal3
            // 
            this.lbltotal3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal3.BackColor = System.Drawing.Color.Black;
            this.lbltotal3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal3.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal3.Location = new System.Drawing.Point(354, 42);
            this.lbltotal3.Name = "lbltotal3";
            this.lbltotal3.Size = new System.Drawing.Size(190, 49);
            this.lbltotal3.TabIndex = 144;
            this.lbltotal3.Text = "0";
            this.lbltotal3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label44.ForeColor = System.Drawing.Color.Blue;
            this.label44.Location = new System.Drawing.Point(7, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(105, 33);
            this.label44.TabIndex = 129;
            this.label44.Text = "CELL 3";
            // 
            // lbltotaltarget3
            // 
            this.lbltotaltarget3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget3.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget3.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget3.Location = new System.Drawing.Point(153, 42);
            this.lbltotaltarget3.Name = "lbltotaltarget3";
            this.lbltotaltarget3.Size = new System.Drawing.Size(178, 48);
            this.lbltotaltarget3.TabIndex = 142;
            this.lbltotaltarget3.Text = "0";
            this.lbltotaltarget3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label46.ForeColor = System.Drawing.Color.Purple;
            this.label46.Location = new System.Drawing.Point(147, 11);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(188, 31);
            this.label46.TabIndex = 143;
            this.label46.Text = "Today Target";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label47.ForeColor = System.Drawing.Color.Purple;
            this.label47.Location = new System.Drawing.Point(351, 11);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(191, 31);
            this.label47.TabIndex = 145;
            this.label47.Text = "Today Output";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox6.Controls.Add(this.lblbalance4);
            this.groupBox6.Controls.Add(this.lblactual4);
            this.groupBox6.Controls.Add(this.lbltarget4);
            this.groupBox6.Controls.Add(this.label64);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.label66);
            this.groupBox6.Controls.Add(this.label67);
            this.groupBox6.Controls.Add(this.lblPO4);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Controls.Add(this.lbltotaltarget4);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.lblsofa4);
            this.groupBox6.Controls.Add(this.label52);
            this.groupBox6.Controls.Add(this.label55);
            this.groupBox6.Location = new System.Drawing.Point(614, 469);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(556, 220);
            this.groupBox6.TabIndex = 156;
            this.groupBox6.TabStop = false;
            // 
            // lblbalance4
            // 
            this.lblbalance4.BackColor = System.Drawing.Color.Black;
            this.lblbalance4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance4.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance4.Location = new System.Drawing.Point(407, 161);
            this.lblbalance4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance4.Name = "lblbalance4";
            this.lblbalance4.Size = new System.Drawing.Size(138, 50);
            this.lblbalance4.TabIndex = 164;
            this.lblbalance4.Text = "0";
            this.lblbalance4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual4
            // 
            this.lblactual4.BackColor = System.Drawing.Color.Black;
            this.lblactual4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual4.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual4.Location = new System.Drawing.Point(271, 161);
            this.lblactual4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual4.Name = "lblactual4";
            this.lblactual4.Size = new System.Drawing.Size(135, 50);
            this.lblactual4.TabIndex = 163;
            this.lblactual4.Text = "0";
            this.lblactual4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget4
            // 
            this.lbltarget4.BackColor = System.Drawing.Color.Black;
            this.lbltarget4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget4.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget4.Location = new System.Drawing.Point(134, 161);
            this.lbltarget4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget4.Name = "lbltarget4";
            this.lbltarget4.Size = new System.Drawing.Size(136, 50);
            this.lbltarget4.TabIndex = 162;
            this.lbltarget4.Text = "0";
            this.lbltarget4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label64.Location = new System.Drawing.Point(24, 173);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(103, 33);
            this.label64.TabIndex = 161;
            this.label64.Text = "TOTAL";
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Green;
            this.label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label65.ForeColor = System.Drawing.Color.Tomato;
            this.label65.Location = new System.Drawing.Point(407, 125);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(138, 36);
            this.label65.TabIndex = 160;
            this.label65.Text = "Balance";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Green;
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label66.ForeColor = System.Drawing.Color.Tomato;
            this.label66.Location = new System.Drawing.Point(271, 125);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(135, 36);
            this.label66.TabIndex = 159;
            this.label66.Text = "Actual";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Green;
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label67.ForeColor = System.Drawing.Color.Tomato;
            this.label67.Location = new System.Drawing.Point(134, 125);
            this.label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(136, 36);
            this.label67.TabIndex = 158;
            this.label67.Text = "Batch";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO4
            // 
            this.lblPO4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO4.ForeColor = System.Drawing.Color.Blue;
            this.lblPO4.Location = new System.Drawing.Point(175, 88);
            this.lblPO4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO4.Name = "lblPO4";
            this.lblPO4.Size = new System.Drawing.Size(355, 35);
            this.lblPO4.TabIndex = 157;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label45.Location = new System.Drawing.Point(33, 87);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(123, 24);
            this.label45.TabIndex = 157;
            this.label45.Text = "CELL 4 PO#";
            // 
            // lbltotaltarget4
            // 
            this.lbltotaltarget4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget4.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget4.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget4.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget4.Name = "lbltotaltarget4";
            this.lbltotaltarget4.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget4.TabIndex = 155;
            this.lbltotaltarget4.Text = "0";
            this.lbltotaltarget4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label32.ForeColor = System.Drawing.Color.Purple;
            this.label32.Location = new System.Drawing.Point(163, 11);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(188, 31);
            this.label32.TabIndex = 155;
            this.label32.Text = "Today Target";
            // 
            // lblsofa4
            // 
            this.lblsofa4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa4.BackColor = System.Drawing.Color.Black;
            this.lblsofa4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa4.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa4.Location = new System.Drawing.Point(386, 41);
            this.lblsofa4.Name = "lblsofa4";
            this.lblsofa4.Size = new System.Drawing.Size(143, 43);
            this.lblsofa4.TabIndex = 144;
            this.lblsofa4.Text = "0";
            this.lblsofa4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label52.ForeColor = System.Drawing.Color.Blue;
            this.label52.Location = new System.Drawing.Point(7, 12);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(105, 33);
            this.label52.TabIndex = 129;
            this.label52.Text = "CELL 4";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label55.ForeColor = System.Drawing.Color.Purple;
            this.label55.Location = new System.Drawing.Point(351, 10);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(199, 31);
            this.label55.TabIndex = 145;
            this.label55.Text = "Today Output ";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox7.Controls.Add(this.lblbalance5);
            this.groupBox7.Controls.Add(this.lblPO5);
            this.groupBox7.Controls.Add(this.lblactual5);
            this.groupBox7.Controls.Add(this.label48);
            this.groupBox7.Controls.Add(this.lbltarget5);
            this.groupBox7.Controls.Add(this.label49);
            this.groupBox7.Controls.Add(this.label68);
            this.groupBox7.Controls.Add(this.lbltotaltarget5);
            this.groupBox7.Controls.Add(this.label69);
            this.groupBox7.Controls.Add(this.label70);
            this.groupBox7.Controls.Add(this.label71);
            this.groupBox7.Controls.Add(this.lblsofa5);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Location = new System.Drawing.Point(26, 11);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(556, 241);
            this.groupBox7.TabIndex = 157;
            this.groupBox7.TabStop = false;
            // 
            // lblbalance5
            // 
            this.lblbalance5.BackColor = System.Drawing.Color.Black;
            this.lblbalance5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance5.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance5.Location = new System.Drawing.Point(411, 165);
            this.lblbalance5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance5.Name = "lblbalance5";
            this.lblbalance5.Size = new System.Drawing.Size(138, 50);
            this.lblbalance5.TabIndex = 171;
            this.lblbalance5.Text = "0";
            this.lblbalance5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO5
            // 
            this.lblPO5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO5.ForeColor = System.Drawing.Color.Blue;
            this.lblPO5.Location = new System.Drawing.Point(175, 89);
            this.lblPO5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO5.Name = "lblPO5";
            this.lblPO5.Size = new System.Drawing.Size(355, 33);
            this.lblPO5.TabIndex = 158;
            // 
            // lblactual5
            // 
            this.lblactual5.BackColor = System.Drawing.Color.Black;
            this.lblactual5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual5.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual5.Location = new System.Drawing.Point(275, 165);
            this.lblactual5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual5.Name = "lblactual5";
            this.lblactual5.Size = new System.Drawing.Size(135, 50);
            this.lblactual5.TabIndex = 170;
            this.lblactual5.Text = "0";
            this.lblactual5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label48.Location = new System.Drawing.Point(31, 93);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(123, 24);
            this.label48.TabIndex = 158;
            this.label48.Text = "CELL 5 PO#";
            // 
            // lbltarget5
            // 
            this.lbltarget5.BackColor = System.Drawing.Color.Black;
            this.lbltarget5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget5.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget5.Location = new System.Drawing.Point(138, 165);
            this.lbltarget5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget5.Name = "lbltarget5";
            this.lbltarget5.Size = new System.Drawing.Size(136, 50);
            this.lbltarget5.TabIndex = 169;
            this.lbltarget5.Text = "0";
            this.lbltarget5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label49.ForeColor = System.Drawing.Color.Purple;
            this.label49.Location = new System.Drawing.Point(171, 11);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(188, 31);
            this.label49.TabIndex = 156;
            this.label49.Text = "Today Target";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label68.Location = new System.Drawing.Point(23, 178);
            this.label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(103, 33);
            this.label68.TabIndex = 168;
            this.label68.Text = "TOTAL";
            // 
            // lbltotaltarget5
            // 
            this.lbltotaltarget5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget5.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget5.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget5.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget5.Name = "lbltotaltarget5";
            this.lbltotaltarget5.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget5.TabIndex = 156;
            this.lbltotaltarget5.Text = "0";
            this.lbltotaltarget5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Green;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label69.ForeColor = System.Drawing.Color.Tomato;
            this.label69.Location = new System.Drawing.Point(411, 129);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(138, 36);
            this.label69.TabIndex = 167;
            this.label69.Text = "Balance";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Green;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label70.ForeColor = System.Drawing.Color.Tomato;
            this.label70.Location = new System.Drawing.Point(275, 129);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(135, 36);
            this.label70.TabIndex = 166;
            this.label70.Text = "Actual";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Green;
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label71.ForeColor = System.Drawing.Color.Tomato;
            this.label71.Location = new System.Drawing.Point(138, 129);
            this.label71.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(136, 36);
            this.label71.TabIndex = 165;
            this.label71.Text = "Batch";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa5
            // 
            this.lblsofa5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa5.BackColor = System.Drawing.Color.Black;
            this.lblsofa5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa5.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa5.Location = new System.Drawing.Point(391, 42);
            this.lblsofa5.Name = "lblsofa5";
            this.lblsofa5.Size = new System.Drawing.Size(138, 43);
            this.lblsofa5.TabIndex = 144;
            this.lblsofa5.Text = "0";
            this.lblsofa5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label41.ForeColor = System.Drawing.Color.Blue;
            this.label41.Location = new System.Drawing.Point(8, 11);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(105, 33);
            this.label41.TabIndex = 129;
            this.label41.Text = "CELL 5";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label43.ForeColor = System.Drawing.Color.Purple;
            this.label43.Location = new System.Drawing.Point(357, 11);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(191, 31);
            this.label43.TabIndex = 145;
            this.label43.Text = "Today Output";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox8.Controls.Add(this.lblbalance6);
            this.groupBox8.Controls.Add(this.lblPO6);
            this.groupBox8.Controls.Add(this.lblactual6);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.lbltarget6);
            this.groupBox8.Controls.Add(this.label53);
            this.groupBox8.Controls.Add(this.label75);
            this.groupBox8.Controls.Add(this.lbltotaltarget6);
            this.groupBox8.Controls.Add(this.label76);
            this.groupBox8.Controls.Add(this.label77);
            this.groupBox8.Controls.Add(this.label78);
            this.groupBox8.Controls.Add(this.lblsofa6);
            this.groupBox8.Controls.Add(this.label58);
            this.groupBox8.Controls.Add(this.label59);
            this.groupBox8.Location = new System.Drawing.Point(26, 258);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(556, 229);
            this.groupBox8.TabIndex = 158;
            this.groupBox8.TabStop = false;
            // 
            // lblbalance6
            // 
            this.lblbalance6.BackColor = System.Drawing.Color.Black;
            this.lblbalance6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance6.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance6.Location = new System.Drawing.Point(409, 166);
            this.lblbalance6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance6.Name = "lblbalance6";
            this.lblbalance6.Size = new System.Drawing.Size(138, 50);
            this.lblbalance6.TabIndex = 178;
            this.lblbalance6.Text = "0";
            this.lblbalance6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO6
            // 
            this.lblPO6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO6.ForeColor = System.Drawing.Color.Blue;
            this.lblPO6.Location = new System.Drawing.Point(175, 92);
            this.lblPO6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO6.Name = "lblPO6";
            this.lblPO6.Size = new System.Drawing.Size(355, 32);
            this.lblPO6.TabIndex = 158;
            // 
            // lblactual6
            // 
            this.lblactual6.BackColor = System.Drawing.Color.Black;
            this.lblactual6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual6.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual6.Location = new System.Drawing.Point(273, 166);
            this.lblactual6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual6.Name = "lblactual6";
            this.lblactual6.Size = new System.Drawing.Size(135, 50);
            this.lblactual6.TabIndex = 177;
            this.lblactual6.Text = "0";
            this.lblactual6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label51.Location = new System.Drawing.Point(37, 92);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(123, 24);
            this.label51.TabIndex = 158;
            this.label51.Text = "CELL 6 PO#";
            // 
            // lbltarget6
            // 
            this.lbltarget6.BackColor = System.Drawing.Color.Black;
            this.lbltarget6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget6.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget6.Location = new System.Drawing.Point(136, 166);
            this.lbltarget6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget6.Name = "lbltarget6";
            this.lbltarget6.Size = new System.Drawing.Size(136, 50);
            this.lbltarget6.TabIndex = 176;
            this.lbltarget6.Text = "0";
            this.lbltarget6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label53.ForeColor = System.Drawing.Color.Purple;
            this.label53.Location = new System.Drawing.Point(169, 11);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(188, 31);
            this.label53.TabIndex = 156;
            this.label53.Text = "Today Target";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label75.Location = new System.Drawing.Point(25, 175);
            this.label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(103, 33);
            this.label75.TabIndex = 175;
            this.label75.Text = "TOTAL";
            // 
            // lbltotaltarget6
            // 
            this.lbltotaltarget6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget6.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget6.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget6.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget6.Name = "lbltotaltarget6";
            this.lbltotaltarget6.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget6.TabIndex = 156;
            this.lbltotaltarget6.Text = "0";
            this.lbltotaltarget6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Green;
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label76.ForeColor = System.Drawing.Color.Tomato;
            this.label76.Location = new System.Drawing.Point(409, 130);
            this.label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(138, 36);
            this.label76.TabIndex = 174;
            this.label76.Text = "Balance";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Green;
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label77.ForeColor = System.Drawing.Color.Tomato;
            this.label77.Location = new System.Drawing.Point(273, 130);
            this.label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(135, 36);
            this.label77.TabIndex = 173;
            this.label77.Text = "Actual";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Green;
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label78.ForeColor = System.Drawing.Color.Tomato;
            this.label78.Location = new System.Drawing.Point(136, 130);
            this.label78.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(136, 36);
            this.label78.TabIndex = 172;
            this.label78.Text = "Batch";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa6
            // 
            this.lblsofa6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa6.BackColor = System.Drawing.Color.Black;
            this.lblsofa6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa6.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa6.Location = new System.Drawing.Point(391, 42);
            this.lblsofa6.Name = "lblsofa6";
            this.lblsofa6.Size = new System.Drawing.Size(138, 43);
            this.lblsofa6.TabIndex = 144;
            this.lblsofa6.Text = "0";
            this.lblsofa6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label58.ForeColor = System.Drawing.Color.Blue;
            this.label58.Location = new System.Drawing.Point(8, 11);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(105, 33);
            this.label58.TabIndex = 129;
            this.label58.Text = "CELL 6";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label59.ForeColor = System.Drawing.Color.Purple;
            this.label59.Location = new System.Drawing.Point(365, 11);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(191, 31);
            this.label59.TabIndex = 145;
            this.label59.Text = "Today Output";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.lblactual13);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabControl1.Location = new System.Drawing.Point(9, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1295, 758);
            this.tabControl1.TabIndex = 159;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label91);
            this.tabPage3.Controls.Add(this.label89);
            this.tabPage3.Controls.Add(this.lblwktotal);
            this.tabPage3.Controls.Add(this.label112);
            this.tabPage3.Controls.Add(this.label178);
            this.tabPage3.Controls.Add(this.groupBox13);
            this.tabPage3.Controls.Add(this.lblSatM);
            this.tabPage3.Controls.Add(this.lblFriM);
            this.tabPage3.Controls.Add(this.lblThdM);
            this.tabPage3.Controls.Add(this.lblWebM);
            this.tabPage3.Controls.Add(this.lblTueM);
            this.tabPage3.Controls.Add(this.lblMonM);
            this.tabPage3.Controls.Add(this.label56);
            this.tabPage3.Controls.Add(this.label61);
            this.tabPage3.Controls.Add(this.label62);
            this.tabPage3.Controls.Add(this.label63);
            this.tabPage3.Controls.Add(this.label72);
            this.tabPage3.Controls.Add(this.label73);
            this.tabPage3.Controls.Add(this.shapeContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1287, 729);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " Total Cell Taget&Output  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label91.ForeColor = System.Drawing.Color.Gold;
            this.label91.Location = new System.Drawing.Point(684, -15);
            this.label91.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(217, 29);
            this.label91.TabIndex = 133;
            this.label91.Text = "Production Line2.";
            this.label91.Visible = false;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label89.ForeColor = System.Drawing.Color.Gold;
            this.label89.Location = new System.Drawing.Point(704, -15);
            this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(217, 29);
            this.label89.TabIndex = 132;
            this.label89.Text = "Production Line1.";
            this.label89.Visible = false;
            // 
            // lblwktotal
            // 
            this.lblwktotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblwktotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblwktotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwktotal.ForeColor = System.Drawing.Color.Lime;
            this.lblwktotal.Location = new System.Drawing.Point(1043, 25);
            this.lblwktotal.Name = "lblwktotal";
            this.lblwktotal.Size = new System.Drawing.Size(183, 32);
            this.lblwktotal.TabIndex = 175;
            this.lblwktotal.Text = "0";
            this.lblwktotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label112.ForeColor = System.Drawing.Color.Red;
            this.label112.Location = new System.Drawing.Point(1070, 1);
            this.label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(118, 23);
            this.label112.TabIndex = 174;
            this.label112.Text = "WK. TOTAL";
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label178.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label178.Location = new System.Drawing.Point(12, 15);
            this.label178.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(119, 41);
            this.label178.TabIndex = 173;
            this.label178.Text = "WEEK";
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.Gray;
            this.groupBox13.Controls.Add(this.label74);
            this.groupBox13.Controls.Add(this.label79);
            this.groupBox13.Controls.Add(this.label57M);
            this.groupBox13.Controls.Add(this.label80);
            this.groupBox13.Controls.Add(this.lblsumM);
            this.groupBox13.Controls.Add(this.lbltime1);
            this.groupBox13.Controls.Add(this.lbltargetPM);
            this.groupBox13.Controls.Add(this.lbldate11);
            this.groupBox13.Controls.Add(this.lbltotalPM);
            this.groupBox13.Controls.Add(this.label83);
            this.groupBox13.Controls.Add(this.label81);
            this.groupBox13.Controls.Add(this.label218);
            this.groupBox13.Controls.Add(this.groupBox32);
            this.groupBox13.Controls.Add(this.groupBox31);
            this.groupBox13.Controls.Add(this.groupBox30);
            this.groupBox13.Controls.Add(this.groupBox29);
            this.groupBox13.Controls.Add(this.groupBox28);
            this.groupBox13.Controls.Add(this.groupBox27);
            this.groupBox13.Controls.Add(this.groupBox25);
            this.groupBox13.Controls.Add(this.groupBox24);
            this.groupBox13.Controls.Add(this.groupBox23);
            this.groupBox13.Controls.Add(this.groupBox22);
            this.groupBox13.Controls.Add(this.groupBox21);
            this.groupBox13.Controls.Add(this.groupBox20);
            this.groupBox13.Controls.Add(this.groupBox16);
            this.groupBox13.Controls.Add(this.groupBox15);
            this.groupBox13.Controls.Add(this.groupBox14);
            this.groupBox13.Controls.Add(this.label60M);
            this.groupBox13.Controls.Add(this.groupBox19);
            this.groupBox13.Controls.Add(this.groupBox18);
            this.groupBox13.Controls.Add(this.groupBox17);
            this.groupBox13.Controls.Add(this.lblLine2M);
            this.groupBox13.Controls.Add(this.lblLine1M);
            this.groupBox13.Location = new System.Drawing.Point(0, 60);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(1283, 622);
            this.groupBox13.TabIndex = 172;
            this.groupBox13.TabStop = false;
            this.groupBox13.Enter += new System.EventHandler(this.groupBox13_Enter);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label74.ForeColor = System.Drawing.Color.SkyBlue;
            this.label74.Location = new System.Drawing.Point(684, -8);
            this.label74.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(134, 29);
            this.label74.TabIndex = 154;
            this.label74.Text = "SUM LINE";
            this.label74.Visible = false;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label79.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label79.Location = new System.Drawing.Point(54, 0);
            this.label79.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(137, 29);
            this.label79.TabIndex = 185;
            this.label79.Text = "SUM SOFA";
            // 
            // label57M
            // 
            this.label57M.BackColor = System.Drawing.Color.Black;
            this.label57M.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label57M.ForeColor = System.Drawing.Color.Gold;
            this.label57M.Location = new System.Drawing.Point(34, 31);
            this.label57M.Name = "label57M";
            this.label57M.Size = new System.Drawing.Size(168, 41);
            this.label57M.TabIndex = 184;
            this.label57M.Text = "0";
            this.label57M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label80.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label80.ForeColor = System.Drawing.Color.Navy;
            this.label80.Location = new System.Drawing.Point(232, -1);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(133, 29);
            this.label80.TabIndex = 183;
            this.label80.Text = "SUM CELL";
            // 
            // lblsumM
            // 
            this.lblsumM.BackColor = System.Drawing.Color.Black;
            this.lblsumM.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsumM.ForeColor = System.Drawing.Color.Aqua;
            this.lblsumM.Location = new System.Drawing.Point(215, 31);
            this.lblsumM.Name = "lblsumM";
            this.lblsumM.Size = new System.Drawing.Size(168, 41);
            this.lblsumM.TabIndex = 182;
            this.lblsumM.Text = "0";
            this.lblsumM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltime1
            // 
            this.lbltime1.AutoSize = true;
            this.lbltime1.BackColor = System.Drawing.Color.Gray;
            this.lbltime1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltime1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbltime1.Location = new System.Drawing.Point(792, 541);
            this.lbltime1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime1.Name = "lbltime1";
            this.lbltime1.Size = new System.Drawing.Size(119, 48);
            this.lbltime1.TabIndex = 176;
            this.lbltime1.Text = "Time";
            // 
            // lbltargetPM
            // 
            this.lbltargetPM.BackColor = System.Drawing.Color.Black;
            this.lbltargetPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltargetPM.ForeColor = System.Drawing.Color.Red;
            this.lbltargetPM.Location = new System.Drawing.Point(560, 7);
            this.lbltargetPM.Name = "lbltargetPM";
            this.lbltargetPM.Size = new System.Drawing.Size(230, 64);
            this.lbltargetPM.TabIndex = 163;
            this.lbltargetPM.Text = "0";
            this.lbltargetPM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbldate11
            // 
            this.lbldate11.AutoSize = true;
            this.lbldate11.BackColor = System.Drawing.Color.Gray;
            this.lbldate11.Font = new System.Drawing.Font("Tahoma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbldate11.ForeColor = System.Drawing.Color.Yellow;
            this.lbldate11.Location = new System.Drawing.Point(781, 484);
            this.lbldate11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate11.Name = "lbldate11";
            this.lbldate11.Size = new System.Drawing.Size(131, 57);
            this.lbldate11.TabIndex = 159;
            this.lbldate11.Text = "date";
            // 
            // lbltotalPM
            // 
            this.lbltotalPM.BackColor = System.Drawing.Color.Black;
            this.lbltotalPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalPM.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalPM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbltotalPM.Location = new System.Drawing.Point(1003, 5);
            this.lbltotalPM.Name = "lbltotalPM";
            this.lbltotalPM.Size = new System.Drawing.Size(258, 64);
            this.lbltotalPM.TabIndex = 164;
            this.lbltotalPM.Text = "0";
            this.lbltotalPM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label83.Font = new System.Drawing.Font("Tahoma", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label83.Location = new System.Drawing.Point(793, 21);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(208, 34);
            this.label83.TabIndex = 181;
            this.label83.Text = "ACCUMULATE";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label81.Font = new System.Drawing.Font("Tahoma", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label81.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label81.Location = new System.Drawing.Point(429, 20);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(126, 34);
            this.label81.TabIndex = 180;
            this.label81.Text = "TARGET";
            // 
            // label218
            // 
            this.label218.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label218.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label218.Location = new System.Drawing.Point(0, -2);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(1277, 79);
            this.label218.TabIndex = 0;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.label211);
            this.groupBox32.Controls.Add(this.lblstdS1);
            this.groupBox32.Controls.Add(this.lbltotalS1M);
            this.groupBox32.Controls.Add(this.label214);
            this.groupBox32.Controls.Add(this.label215);
            this.groupBox32.Controls.Add(this.label216);
            this.groupBox32.Controls.Add(this.lbltotaltargetS1M);
            this.groupBox32.Location = new System.Drawing.Point(518, 475);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(251, 133);
            this.groupBox32.TabIndex = 178;
            this.groupBox32.TabStop = false;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label211.ForeColor = System.Drawing.Color.GhostWhite;
            this.label211.Location = new System.Drawing.Point(4, 93);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(99, 25);
            this.label211.TabIndex = 163;
            this.label211.Text = "Std.Time";
            // 
            // lblstdS1
            // 
            this.lblstdS1.BackColor = System.Drawing.Color.Purple;
            this.lblstdS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstdS1.ForeColor = System.Drawing.Color.Yellow;
            this.lblstdS1.Location = new System.Drawing.Point(113, 93);
            this.lblstdS1.Name = "lblstdS1";
            this.lblstdS1.Size = new System.Drawing.Size(130, 30);
            this.lblstdS1.TabIndex = 163;
            this.lblstdS1.Text = "0";
            this.lblstdS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotalS1M
            // 
            this.lbltotalS1M.BackColor = System.Drawing.Color.Black;
            this.lbltotalS1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalS1M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalS1M.Location = new System.Drawing.Point(113, 56);
            this.lbltotalS1M.Name = "lbltotalS1M";
            this.lbltotalS1M.Size = new System.Drawing.Size(130, 34);
            this.lbltotalS1M.TabIndex = 155;
            this.lbltotalS1M.Text = "0";
            this.lbltotalS1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label214.ForeColor = System.Drawing.Color.Blue;
            this.label214.Location = new System.Drawing.Point(6, 0);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(101, 27);
            this.label214.TabIndex = 152;
            this.label214.Text = "CELL S1";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label215.ForeColor = System.Drawing.Color.GhostWhite;
            this.label215.Location = new System.Drawing.Point(9, 28);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(90, 29);
            this.label215.TabIndex = 153;
            this.label215.Text = "Target";
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label216.ForeColor = System.Drawing.Color.GhostWhite;
            this.label216.Location = new System.Drawing.Point(9, 59);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(90, 29);
            this.label216.TabIndex = 156;
            this.label216.Text = "Output";
            // 
            // lbltotaltargetS1M
            // 
            this.lbltotaltargetS1M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltargetS1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltargetS1M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltargetS1M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltargetS1M.Name = "lbltotaltargetS1M";
            this.lbltotaltargetS1M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltargetS1M.TabIndex = 154;
            this.lbltotaltargetS1M.Text = "0";
            this.lbltotaltargetS1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.label204);
            this.groupBox31.Controls.Add(this.lblstd13);
            this.groupBox31.Controls.Add(this.lbltotal13M);
            this.groupBox31.Controls.Add(this.label207);
            this.groupBox31.Controls.Add(this.label208);
            this.groupBox31.Controls.Add(this.label209);
            this.groupBox31.Controls.Add(this.lbltotaltarget13M);
            this.groupBox31.Location = new System.Drawing.Point(1024, 341);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(251, 133);
            this.groupBox31.TabIndex = 177;
            this.groupBox31.TabStop = false;
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label204.ForeColor = System.Drawing.Color.GhostWhite;
            this.label204.Location = new System.Drawing.Point(4, 93);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(99, 25);
            this.label204.TabIndex = 163;
            this.label204.Text = "Std.Time";
            // 
            // lblstd13
            // 
            this.lblstd13.BackColor = System.Drawing.Color.Purple;
            this.lblstd13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd13.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd13.Location = new System.Drawing.Point(113, 93);
            this.lblstd13.Name = "lblstd13";
            this.lblstd13.Size = new System.Drawing.Size(130, 30);
            this.lblstd13.TabIndex = 163;
            this.lblstd13.Text = "0";
            this.lblstd13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal13M
            // 
            this.lbltotal13M.BackColor = System.Drawing.Color.Black;
            this.lbltotal13M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal13M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal13M.Location = new System.Drawing.Point(113, 56);
            this.lbltotal13M.Name = "lbltotal13M";
            this.lbltotal13M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal13M.TabIndex = 155;
            this.lbltotal13M.Text = "0";
            this.lbltotal13M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label207.ForeColor = System.Drawing.Color.Blue;
            this.label207.Location = new System.Drawing.Point(6, 0);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(101, 27);
            this.label207.TabIndex = 152;
            this.label207.Text = "CELL 13";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label208.ForeColor = System.Drawing.Color.GhostWhite;
            this.label208.Location = new System.Drawing.Point(9, 28);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(90, 29);
            this.label208.TabIndex = 153;
            this.label208.Text = "Target";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label209.ForeColor = System.Drawing.Color.GhostWhite;
            this.label209.Location = new System.Drawing.Point(9, 59);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(90, 29);
            this.label209.TabIndex = 156;
            this.label209.Text = "Output";
            // 
            // lbltotaltarget13M
            // 
            this.lbltotaltarget13M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget13M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget13M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget13M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltarget13M.Name = "lbltotaltarget13M";
            this.lbltotaltarget13M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget13M.TabIndex = 154;
            this.lbltotaltarget13M.Text = "0";
            this.lbltotaltarget13M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.label197);
            this.groupBox30.Controls.Add(this.lblstd122);
            this.groupBox30.Controls.Add(this.lbltotal12M);
            this.groupBox30.Controls.Add(this.label200);
            this.groupBox30.Controls.Add(this.label201);
            this.groupBox30.Controls.Add(this.label202);
            this.groupBox30.Controls.Add(this.lbltotaltarget12M);
            this.groupBox30.Location = new System.Drawing.Point(769, 342);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(251, 133);
            this.groupBox30.TabIndex = 176;
            this.groupBox30.TabStop = false;
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label197.ForeColor = System.Drawing.Color.GhostWhite;
            this.label197.Location = new System.Drawing.Point(4, 93);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(99, 25);
            this.label197.TabIndex = 163;
            this.label197.Text = "Std.Time";
            // 
            // lblstd122
            // 
            this.lblstd122.BackColor = System.Drawing.Color.Purple;
            this.lblstd122.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd122.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd122.Location = new System.Drawing.Point(113, 93);
            this.lblstd122.Name = "lblstd122";
            this.lblstd122.Size = new System.Drawing.Size(130, 30);
            this.lblstd122.TabIndex = 163;
            this.lblstd122.Text = "0";
            this.lblstd122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal12M
            // 
            this.lbltotal12M.BackColor = System.Drawing.Color.Black;
            this.lbltotal12M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal12M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal12M.Location = new System.Drawing.Point(113, 56);
            this.lbltotal12M.Name = "lbltotal12M";
            this.lbltotal12M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal12M.TabIndex = 155;
            this.lbltotal12M.Text = "0";
            this.lbltotal12M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label200.ForeColor = System.Drawing.Color.Blue;
            this.label200.Location = new System.Drawing.Point(6, 0);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(101, 27);
            this.label200.TabIndex = 152;
            this.label200.Text = "CELL 12";
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label201.ForeColor = System.Drawing.Color.GhostWhite;
            this.label201.Location = new System.Drawing.Point(9, 28);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(90, 29);
            this.label201.TabIndex = 153;
            this.label201.Text = "Target";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label202.ForeColor = System.Drawing.Color.GhostWhite;
            this.label202.Location = new System.Drawing.Point(9, 59);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(90, 29);
            this.label202.TabIndex = 156;
            this.label202.Text = "Output";
            // 
            // lbltotaltarget12M
            // 
            this.lbltotaltarget12M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget12M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget12M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget12M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltarget12M.Name = "lbltotaltarget12M";
            this.lbltotaltarget12M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget12M.TabIndex = 154;
            this.lbltotaltarget12M.Text = "0";
            this.lbltotaltarget12M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.label188);
            this.groupBox29.Controls.Add(this.lblstd15);
            this.groupBox29.Controls.Add(this.lbltotal15M);
            this.groupBox29.Controls.Add(this.label193);
            this.groupBox29.Controls.Add(this.label194);
            this.groupBox29.Controls.Add(this.label195);
            this.groupBox29.Controls.Add(this.lbltotaltarget15M);
            this.groupBox29.Location = new System.Drawing.Point(261, 476);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(251, 133);
            this.groupBox29.TabIndex = 175;
            this.groupBox29.TabStop = false;
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label188.ForeColor = System.Drawing.Color.GhostWhite;
            this.label188.Location = new System.Drawing.Point(4, 93);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(99, 25);
            this.label188.TabIndex = 163;
            this.label188.Text = "Std.Time";
            // 
            // lblstd15
            // 
            this.lblstd15.BackColor = System.Drawing.Color.Purple;
            this.lblstd15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd15.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd15.Location = new System.Drawing.Point(113, 93);
            this.lblstd15.Name = "lblstd15";
            this.lblstd15.Size = new System.Drawing.Size(130, 30);
            this.lblstd15.TabIndex = 163;
            this.lblstd15.Text = "0";
            this.lblstd15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal15M
            // 
            this.lbltotal15M.BackColor = System.Drawing.Color.Black;
            this.lbltotal15M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal15M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal15M.Location = new System.Drawing.Point(113, 56);
            this.lbltotal15M.Name = "lbltotal15M";
            this.lbltotal15M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal15M.TabIndex = 155;
            this.lbltotal15M.Text = "0";
            this.lbltotal15M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label193.ForeColor = System.Drawing.Color.Blue;
            this.label193.Location = new System.Drawing.Point(6, 0);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(101, 27);
            this.label193.TabIndex = 152;
            this.label193.Text = "CELL 15";
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label194.ForeColor = System.Drawing.Color.GhostWhite;
            this.label194.Location = new System.Drawing.Point(9, 28);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(90, 29);
            this.label194.TabIndex = 153;
            this.label194.Text = "Target";
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label195.ForeColor = System.Drawing.Color.GhostWhite;
            this.label195.Location = new System.Drawing.Point(9, 59);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(90, 29);
            this.label195.TabIndex = 156;
            this.label195.Text = "Output";
            // 
            // lbltotaltarget15M
            // 
            this.lbltotaltarget15M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget15M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget15M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget15M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltarget15M.Name = "lbltotaltarget15M";
            this.lbltotaltarget15M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget15M.TabIndex = 154;
            this.lbltotaltarget15M.Text = "0";
            this.lbltotaltarget15M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.label94);
            this.groupBox28.Controls.Add(this.lblstd14);
            this.groupBox28.Controls.Add(this.lbltotal14M);
            this.groupBox28.Controls.Add(this.label180);
            this.groupBox28.Controls.Add(this.label182);
            this.groupBox28.Controls.Add(this.label184);
            this.groupBox28.Controls.Add(this.lbltotaltarget14M);
            this.groupBox28.Location = new System.Drawing.Point(7, 475);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(251, 133);
            this.groupBox28.TabIndex = 174;
            this.groupBox28.TabStop = false;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label94.ForeColor = System.Drawing.Color.GhostWhite;
            this.label94.Location = new System.Drawing.Point(4, 93);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(99, 25);
            this.label94.TabIndex = 163;
            this.label94.Text = "Std.Time";
            // 
            // lblstd14
            // 
            this.lblstd14.BackColor = System.Drawing.Color.Purple;
            this.lblstd14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd14.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd14.Location = new System.Drawing.Point(113, 93);
            this.lblstd14.Name = "lblstd14";
            this.lblstd14.Size = new System.Drawing.Size(130, 30);
            this.lblstd14.TabIndex = 163;
            this.lblstd14.Text = "0";
            this.lblstd14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal14M
            // 
            this.lbltotal14M.BackColor = System.Drawing.Color.Black;
            this.lbltotal14M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal14M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal14M.Location = new System.Drawing.Point(113, 56);
            this.lbltotal14M.Name = "lbltotal14M";
            this.lbltotal14M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal14M.TabIndex = 155;
            this.lbltotal14M.Text = "0";
            this.lbltotal14M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label180.ForeColor = System.Drawing.Color.Blue;
            this.label180.Location = new System.Drawing.Point(6, 0);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(101, 27);
            this.label180.TabIndex = 152;
            this.label180.Text = "CELL 14";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label182.ForeColor = System.Drawing.Color.GhostWhite;
            this.label182.Location = new System.Drawing.Point(9, 28);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(90, 29);
            this.label182.TabIndex = 153;
            this.label182.Text = "Target";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label184.ForeColor = System.Drawing.Color.GhostWhite;
            this.label184.Location = new System.Drawing.Point(9, 59);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(90, 29);
            this.label184.TabIndex = 156;
            this.label184.Text = "Output";
            // 
            // lbltotaltarget14M
            // 
            this.lbltotaltarget14M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget14M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget14M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget14M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltarget14M.Name = "lbltotaltarget14M";
            this.lbltotaltarget14M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget14M.TabIndex = 154;
            this.lbltotaltarget14M.Text = "0";
            this.lbltotaltarget14M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.label86);
            this.groupBox27.Controls.Add(this.lblstdT2);
            this.groupBox27.Controls.Add(this.lbltotalTM);
            this.groupBox27.Controls.Add(this.label152);
            this.groupBox27.Controls.Add(this.label167);
            this.groupBox27.Controls.Add(this.label172);
            this.groupBox27.Controls.Add(this.lbltotaltargetTM);
            this.groupBox27.Location = new System.Drawing.Point(260, 80);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(251, 133);
            this.groupBox27.TabIndex = 166;
            this.groupBox27.TabStop = false;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label86.ForeColor = System.Drawing.Color.GhostWhite;
            this.label86.Location = new System.Drawing.Point(4, 85);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(99, 25);
            this.label86.TabIndex = 159;
            this.label86.Text = "Std.Time";
            // 
            // lblstdT2
            // 
            this.lblstdT2.BackColor = System.Drawing.Color.Purple;
            this.lblstdT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstdT2.ForeColor = System.Drawing.Color.Yellow;
            this.lblstdT2.Location = new System.Drawing.Point(107, 88);
            this.lblstdT2.Name = "lblstdT2";
            this.lblstdT2.Size = new System.Drawing.Size(130, 30);
            this.lblstdT2.TabIndex = 159;
            this.lblstdT2.Text = "0";
            this.lblstdT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotalTM
            // 
            this.lbltotalTM.BackColor = System.Drawing.Color.Black;
            this.lbltotalTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalTM.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalTM.Location = new System.Drawing.Point(107, 52);
            this.lbltotalTM.Name = "lbltotalTM";
            this.lbltotalTM.Size = new System.Drawing.Size(130, 34);
            this.lbltotalTM.TabIndex = 155;
            this.lbltotalTM.Text = "0";
            this.lbltotalTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label152.ForeColor = System.Drawing.Color.Blue;
            this.label152.Location = new System.Drawing.Point(6, -6);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(100, 27);
            this.label152.TabIndex = 152;
            this.label152.Text = "CELL T2";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label167.ForeColor = System.Drawing.Color.GhostWhite;
            this.label167.Location = new System.Drawing.Point(11, 24);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(90, 29);
            this.label167.TabIndex = 153;
            this.label167.Text = "Target";
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label172.ForeColor = System.Drawing.Color.GhostWhite;
            this.label172.Location = new System.Drawing.Point(10, 54);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(90, 29);
            this.label172.TabIndex = 156;
            this.label172.Text = "Output";
            // 
            // lbltotaltargetTM
            // 
            this.lbltotaltargetTM.BackColor = System.Drawing.Color.Black;
            this.lbltotaltargetTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltargetTM.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltargetTM.Location = new System.Drawing.Point(107, 16);
            this.lbltotaltargetTM.Name = "lbltotaltargetTM";
            this.lbltotaltargetTM.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltargetTM.TabIndex = 154;
            this.lbltotaltargetTM.Text = "0";
            this.lbltotaltargetTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label191);
            this.groupBox25.Controls.Add(this.lblstd12);
            this.groupBox25.Controls.Add(this.lbltotal11M);
            this.groupBox25.Controls.Add(this.label174);
            this.groupBox25.Controls.Add(this.label175);
            this.groupBox25.Controls.Add(this.label176);
            this.groupBox25.Controls.Add(this.lbltotaltarget11M);
            this.groupBox25.Location = new System.Drawing.Point(514, 342);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(251, 133);
            this.groupBox25.TabIndex = 173;
            this.groupBox25.TabStop = false;
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label191.ForeColor = System.Drawing.Color.GhostWhite;
            this.label191.Location = new System.Drawing.Point(4, 93);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(99, 25);
            this.label191.TabIndex = 163;
            this.label191.Text = "Std.Time";
            // 
            // lblstd12
            // 
            this.lblstd12.BackColor = System.Drawing.Color.Purple;
            this.lblstd12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd12.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd12.Location = new System.Drawing.Point(113, 93);
            this.lblstd12.Name = "lblstd12";
            this.lblstd12.Size = new System.Drawing.Size(130, 30);
            this.lblstd12.TabIndex = 163;
            this.lblstd12.Text = "0";
            this.lblstd12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal11M
            // 
            this.lbltotal11M.BackColor = System.Drawing.Color.Black;
            this.lbltotal11M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal11M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal11M.Location = new System.Drawing.Point(113, 56);
            this.lbltotal11M.Name = "lbltotal11M";
            this.lbltotal11M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal11M.TabIndex = 155;
            this.lbltotal11M.Text = "0";
            this.lbltotal11M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label174.ForeColor = System.Drawing.Color.Blue;
            this.label174.Location = new System.Drawing.Point(6, 0);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(101, 27);
            this.label174.TabIndex = 152;
            this.label174.Text = "CELL 11";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label175.ForeColor = System.Drawing.Color.GhostWhite;
            this.label175.Location = new System.Drawing.Point(9, 28);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(90, 29);
            this.label175.TabIndex = 153;
            this.label175.Text = "Target";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label176.ForeColor = System.Drawing.Color.GhostWhite;
            this.label176.Location = new System.Drawing.Point(9, 59);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(90, 29);
            this.label176.TabIndex = 156;
            this.label176.Text = "Output";
            // 
            // lbltotaltarget11M
            // 
            this.lbltotaltarget11M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget11M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget11M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget11M.Location = new System.Drawing.Point(113, 19);
            this.lbltotaltarget11M.Name = "lbltotaltarget11M";
            this.lbltotaltarget11M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget11M.TabIndex = 154;
            this.lbltotaltarget11M.Text = "0";
            this.lbltotaltarget11M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.label183);
            this.groupBox24.Controls.Add(this.lblstd8);
            this.groupBox24.Controls.Add(this.lbltotal7M);
            this.groupBox24.Controls.Add(this.label169);
            this.groupBox24.Controls.Add(this.label170);
            this.groupBox24.Controls.Add(this.label171);
            this.groupBox24.Controls.Add(this.lbltotaltarget7M);
            this.groupBox24.Location = new System.Drawing.Point(770, 215);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(251, 125);
            this.groupBox24.TabIndex = 172;
            this.groupBox24.TabStop = false;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label183.ForeColor = System.Drawing.Color.GhostWhite;
            this.label183.Location = new System.Drawing.Point(4, 90);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(99, 25);
            this.label183.TabIndex = 162;
            this.label183.Text = "Std.Time";
            // 
            // lblstd8
            // 
            this.lblstd8.BackColor = System.Drawing.Color.Purple;
            this.lblstd8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd8.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd8.Location = new System.Drawing.Point(103, 88);
            this.lblstd8.Name = "lblstd8";
            this.lblstd8.Size = new System.Drawing.Size(130, 30);
            this.lblstd8.TabIndex = 162;
            this.lblstd8.Text = "0";
            this.lblstd8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal7M
            // 
            this.lbltotal7M.BackColor = System.Drawing.Color.Black;
            this.lbltotal7M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal7M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal7M.Location = new System.Drawing.Point(103, 52);
            this.lbltotal7M.Name = "lbltotal7M";
            this.lbltotal7M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal7M.TabIndex = 155;
            this.lbltotal7M.Text = "0";
            this.lbltotal7M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label169.ForeColor = System.Drawing.Color.Blue;
            this.label169.Location = new System.Drawing.Point(7, -4);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(87, 27);
            this.label169.TabIndex = 152;
            this.label169.Text = "CELL 7";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label170.ForeColor = System.Drawing.Color.GhostWhite;
            this.label170.Location = new System.Drawing.Point(8, 26);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(90, 29);
            this.label170.TabIndex = 153;
            this.label170.Text = "Target";
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label171.ForeColor = System.Drawing.Color.GhostWhite;
            this.label171.Location = new System.Drawing.Point(6, 56);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(90, 29);
            this.label171.TabIndex = 156;
            this.label171.Text = "Output";
            // 
            // lbltotaltarget7M
            // 
            this.lbltotaltarget7M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget7M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget7M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget7M.Location = new System.Drawing.Point(103, 16);
            this.lbltotaltarget7M.Name = "lbltotaltarget7M";
            this.lbltotaltarget7M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget7M.TabIndex = 154;
            this.lbltotaltarget7M.Text = "0";
            this.lbltotaltarget7M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.label189);
            this.groupBox23.Controls.Add(this.lblstd11);
            this.groupBox23.Controls.Add(this.lbltotal10M);
            this.groupBox23.Controls.Add(this.label164);
            this.groupBox23.Controls.Add(this.label165);
            this.groupBox23.Controls.Add(this.label166);
            this.groupBox23.Controls.Add(this.lbltotaltarget10M);
            this.groupBox23.Location = new System.Drawing.Point(260, 343);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(251, 133);
            this.groupBox23.TabIndex = 171;
            this.groupBox23.TabStop = false;
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label189.ForeColor = System.Drawing.Color.GhostWhite;
            this.label189.Location = new System.Drawing.Point(6, 91);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(99, 25);
            this.label189.TabIndex = 162;
            this.label189.Text = "Std.Time";
            // 
            // lblstd11
            // 
            this.lblstd11.BackColor = System.Drawing.Color.Purple;
            this.lblstd11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd11.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd11.Location = new System.Drawing.Point(112, 92);
            this.lblstd11.Name = "lblstd11";
            this.lblstd11.Size = new System.Drawing.Size(130, 30);
            this.lblstd11.TabIndex = 162;
            this.lblstd11.Text = "0";
            this.lblstd11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal10M
            // 
            this.lbltotal10M.BackColor = System.Drawing.Color.Black;
            this.lbltotal10M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal10M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal10M.Location = new System.Drawing.Point(112, 55);
            this.lbltotal10M.Name = "lbltotal10M";
            this.lbltotal10M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal10M.TabIndex = 155;
            this.lbltotal10M.Text = "0";
            this.lbltotal10M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label164.ForeColor = System.Drawing.Color.Blue;
            this.label164.Location = new System.Drawing.Point(5, -1);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(101, 27);
            this.label164.TabIndex = 152;
            this.label164.Text = "CELL 10";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label165.ForeColor = System.Drawing.Color.GhostWhite;
            this.label165.Location = new System.Drawing.Point(6, 27);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(90, 29);
            this.label165.TabIndex = 153;
            this.label165.Text = "Target";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label166.ForeColor = System.Drawing.Color.GhostWhite;
            this.label166.Location = new System.Drawing.Point(7, 57);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(90, 29);
            this.label166.TabIndex = 156;
            this.label166.Text = "Output";
            // 
            // lbltotaltarget10M
            // 
            this.lbltotaltarget10M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget10M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget10M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget10M.Location = new System.Drawing.Point(112, 18);
            this.lbltotaltarget10M.Name = "lbltotaltarget10M";
            this.lbltotaltarget10M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget10M.TabIndex = 154;
            this.lbltotaltarget10M.Text = "0";
            this.lbltotaltarget10M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.label181);
            this.groupBox22.Controls.Add(this.lblstd7);
            this.groupBox22.Controls.Add(this.lbltotal6M);
            this.groupBox22.Controls.Add(this.label159);
            this.groupBox22.Controls.Add(this.label160);
            this.groupBox22.Controls.Add(this.label161);
            this.groupBox22.Controls.Add(this.lbltotaltarget6M);
            this.groupBox22.Location = new System.Drawing.Point(514, 215);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(251, 125);
            this.groupBox22.TabIndex = 170;
            this.groupBox22.TabStop = false;
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label181.ForeColor = System.Drawing.Color.GhostWhite;
            this.label181.Location = new System.Drawing.Point(6, 89);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(99, 25);
            this.label181.TabIndex = 161;
            this.label181.Text = "Std.Time";
            // 
            // lblstd7
            // 
            this.lblstd7.BackColor = System.Drawing.Color.Purple;
            this.lblstd7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd7.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd7.Location = new System.Drawing.Point(105, 89);
            this.lblstd7.Name = "lblstd7";
            this.lblstd7.Size = new System.Drawing.Size(130, 30);
            this.lblstd7.TabIndex = 161;
            this.lblstd7.Text = "0";
            this.lblstd7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal6M
            // 
            this.lbltotal6M.BackColor = System.Drawing.Color.Black;
            this.lbltotal6M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal6M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal6M.Location = new System.Drawing.Point(105, 53);
            this.lbltotal6M.Name = "lbltotal6M";
            this.lbltotal6M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal6M.TabIndex = 155;
            this.lbltotal6M.Text = "0";
            this.lbltotal6M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltotal6M.Click += new System.EventHandler(this.label158_Click);
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label159.ForeColor = System.Drawing.Color.Blue;
            this.label159.Location = new System.Drawing.Point(4, -1);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(87, 27);
            this.label159.TabIndex = 152;
            this.label159.Text = "CELL 6";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label160.ForeColor = System.Drawing.Color.GhostWhite;
            this.label160.Location = new System.Drawing.Point(9, 26);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(90, 29);
            this.label160.TabIndex = 153;
            this.label160.Text = "Target";
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label161.ForeColor = System.Drawing.Color.GhostWhite;
            this.label161.Location = new System.Drawing.Point(6, 56);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(90, 29);
            this.label161.TabIndex = 156;
            this.label161.Text = "Output";
            // 
            // lbltotaltarget6M
            // 
            this.lbltotaltarget6M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget6M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget6M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget6M.Location = new System.Drawing.Point(106, 17);
            this.lbltotaltarget6M.Name = "lbltotaltarget6M";
            this.lbltotaltarget6M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget6M.TabIndex = 154;
            this.lbltotaltarget6M.Text = "0";
            this.lbltotaltarget6M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label187);
            this.groupBox21.Controls.Add(this.lblstd10);
            this.groupBox21.Controls.Add(this.lbltotal9M);
            this.groupBox21.Controls.Add(this.label154);
            this.groupBox21.Controls.Add(this.label155);
            this.groupBox21.Controls.Add(this.label156);
            this.groupBox21.Controls.Add(this.lbltotaltarget9M);
            this.groupBox21.Location = new System.Drawing.Point(9, 342);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(248, 133);
            this.groupBox21.TabIndex = 169;
            this.groupBox21.TabStop = false;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label187.ForeColor = System.Drawing.Color.GhostWhite;
            this.label187.Location = new System.Drawing.Point(6, 92);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(99, 25);
            this.label187.TabIndex = 161;
            this.label187.Text = "Std.Time";
            // 
            // lblstd10
            // 
            this.lblstd10.BackColor = System.Drawing.Color.Purple;
            this.lblstd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd10.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd10.Location = new System.Drawing.Point(106, 94);
            this.lblstd10.Name = "lblstd10";
            this.lblstd10.Size = new System.Drawing.Size(130, 30);
            this.lblstd10.TabIndex = 161;
            this.lblstd10.Text = "0";
            this.lblstd10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal9M
            // 
            this.lbltotal9M.BackColor = System.Drawing.Color.Black;
            this.lbltotal9M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal9M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal9M.Location = new System.Drawing.Point(105, 56);
            this.lbltotal9M.Name = "lbltotal9M";
            this.lbltotal9M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal9M.TabIndex = 155;
            this.lbltotal9M.Text = "0";
            this.lbltotal9M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label154.ForeColor = System.Drawing.Color.Blue;
            this.label154.Location = new System.Drawing.Point(7, 0);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(87, 27);
            this.label154.TabIndex = 152;
            this.label154.Text = "CELL 9";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label155.ForeColor = System.Drawing.Color.GhostWhite;
            this.label155.Location = new System.Drawing.Point(12, 28);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(90, 29);
            this.label155.TabIndex = 153;
            this.label155.Text = "Target";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label156.ForeColor = System.Drawing.Color.GhostWhite;
            this.label156.Location = new System.Drawing.Point(10, 60);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(90, 29);
            this.label156.TabIndex = 156;
            this.label156.Text = "Output";
            // 
            // lbltotaltarget9M
            // 
            this.lbltotaltarget9M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget9M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget9M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget9M.Location = new System.Drawing.Point(104, 19);
            this.lbltotaltarget9M.Name = "lbltotaltarget9M";
            this.lbltotaltarget9M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget9M.TabIndex = 154;
            this.lbltotaltarget9M.Text = "0";
            this.lbltotaltarget9M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label179);
            this.groupBox20.Controls.Add(this.lblstd6);
            this.groupBox20.Controls.Add(this.lbltotal5M);
            this.groupBox20.Controls.Add(this.label149);
            this.groupBox20.Controls.Add(this.label150);
            this.groupBox20.Controls.Add(this.label151);
            this.groupBox20.Controls.Add(this.lbltotaltarget5M);
            this.groupBox20.Location = new System.Drawing.Point(260, 215);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(251, 125);
            this.groupBox20.TabIndex = 168;
            this.groupBox20.TabStop = false;
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label179.ForeColor = System.Drawing.Color.GhostWhite;
            this.label179.Location = new System.Drawing.Point(3, 89);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(99, 25);
            this.label179.TabIndex = 160;
            this.label179.Text = "Std.Time";
            // 
            // lblstd6
            // 
            this.lblstd6.BackColor = System.Drawing.Color.Purple;
            this.lblstd6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd6.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd6.Location = new System.Drawing.Point(106, 90);
            this.lblstd6.Name = "lblstd6";
            this.lblstd6.Size = new System.Drawing.Size(130, 30);
            this.lblstd6.TabIndex = 160;
            this.lblstd6.Text = "0";
            this.lblstd6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal5M
            // 
            this.lbltotal5M.BackColor = System.Drawing.Color.Black;
            this.lbltotal5M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal5M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal5M.Location = new System.Drawing.Point(106, 53);
            this.lbltotal5M.Name = "lbltotal5M";
            this.lbltotal5M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal5M.TabIndex = 155;
            this.lbltotal5M.Text = "0";
            this.lbltotal5M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label149.ForeColor = System.Drawing.Color.Blue;
            this.label149.Location = new System.Drawing.Point(13, -2);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(87, 27);
            this.label149.TabIndex = 152;
            this.label149.Text = "CELL 5";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label150.ForeColor = System.Drawing.Color.GhostWhite;
            this.label150.Location = new System.Drawing.Point(5, 23);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(90, 29);
            this.label150.TabIndex = 153;
            this.label150.Text = "Target";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label151.ForeColor = System.Drawing.Color.GhostWhite;
            this.label151.Location = new System.Drawing.Point(7, 55);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(90, 29);
            this.label151.TabIndex = 156;
            this.label151.Text = "Output";
            // 
            // lbltotaltarget5M
            // 
            this.lbltotaltarget5M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget5M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget5M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget5M.Location = new System.Drawing.Point(105, 17);
            this.lbltotaltarget5M.Name = "lbltotaltarget5M";
            this.lbltotaltarget5M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget5M.TabIndex = 154;
            this.lbltotaltarget5M.Text = "0";
            this.lbltotaltarget5M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.label168);
            this.groupBox16.Controls.Add(this.lblstd4);
            this.groupBox16.Controls.Add(this.lbltotal3M);
            this.groupBox16.Controls.Add(this.label118);
            this.groupBox16.Controls.Add(this.label120);
            this.groupBox16.Controls.Add(this.label123);
            this.groupBox16.Controls.Add(this.lbltotaltarget3M);
            this.groupBox16.Location = new System.Drawing.Point(1024, 80);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(246, 133);
            this.groupBox16.TabIndex = 167;
            this.groupBox16.TabStop = false;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label168.ForeColor = System.Drawing.Color.GhostWhite;
            this.label168.Location = new System.Drawing.Point(7, 89);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(99, 25);
            this.label168.TabIndex = 161;
            this.label168.Text = "Std.Time";
            // 
            // lblstd4
            // 
            this.lblstd4.BackColor = System.Drawing.Color.Purple;
            this.lblstd4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd4.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd4.Location = new System.Drawing.Point(108, 90);
            this.lblstd4.Name = "lblstd4";
            this.lblstd4.Size = new System.Drawing.Size(130, 30);
            this.lblstd4.TabIndex = 161;
            this.lblstd4.Text = "0";
            this.lblstd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal3M
            // 
            this.lbltotal3M.BackColor = System.Drawing.Color.Black;
            this.lbltotal3M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal3M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal3M.Location = new System.Drawing.Point(107, 53);
            this.lbltotal3M.Name = "lbltotal3M";
            this.lbltotal3M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal3M.TabIndex = 155;
            this.lbltotal3M.Text = "0";
            this.lbltotal3M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label118.ForeColor = System.Drawing.Color.Blue;
            this.label118.Location = new System.Drawing.Point(6, -5);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(87, 27);
            this.label118.TabIndex = 152;
            this.label118.Text = "CELL 3";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label120.ForeColor = System.Drawing.Color.GhostWhite;
            this.label120.Location = new System.Drawing.Point(7, 22);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(90, 29);
            this.label120.TabIndex = 153;
            this.label120.Text = "Target";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label123.ForeColor = System.Drawing.Color.GhostWhite;
            this.label123.Location = new System.Drawing.Point(7, 52);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(90, 29);
            this.label123.TabIndex = 156;
            this.label123.Text = "Output";
            // 
            // lbltotaltarget3M
            // 
            this.lbltotaltarget3M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget3M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget3M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget3M.Location = new System.Drawing.Point(107, 15);
            this.lbltotaltarget3M.Name = "lbltotaltarget3M";
            this.lbltotaltarget3M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget3M.TabIndex = 154;
            this.lbltotaltarget3M.Text = "0";
            this.lbltotaltarget3M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label158);
            this.groupBox15.Controls.Add(this.lblstd3);
            this.groupBox15.Controls.Add(this.lbltotal2M);
            this.groupBox15.Controls.Add(this.label108);
            this.groupBox15.Controls.Add(this.label109);
            this.groupBox15.Controls.Add(this.label110);
            this.groupBox15.Controls.Add(this.lbltotaltarget2M);
            this.groupBox15.Location = new System.Drawing.Point(768, 79);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(253, 133);
            this.groupBox15.TabIndex = 166;
            this.groupBox15.TabStop = false;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label158.ForeColor = System.Drawing.Color.GhostWhite;
            this.label158.Location = new System.Drawing.Point(4, 90);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(99, 25);
            this.label158.TabIndex = 160;
            this.label158.Text = "Std.Time";
            // 
            // lblstd3
            // 
            this.lblstd3.BackColor = System.Drawing.Color.Purple;
            this.lblstd3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd3.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd3.Location = new System.Drawing.Point(105, 90);
            this.lblstd3.Name = "lblstd3";
            this.lblstd3.Size = new System.Drawing.Size(130, 30);
            this.lblstd3.TabIndex = 160;
            this.lblstd3.Text = "0";
            this.lblstd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal2M
            // 
            this.lbltotal2M.BackColor = System.Drawing.Color.Black;
            this.lbltotal2M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal2M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal2M.Location = new System.Drawing.Point(104, 54);
            this.lbltotal2M.Name = "lbltotal2M";
            this.lbltotal2M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal2M.TabIndex = 155;
            this.lbltotal2M.Text = "0";
            this.lbltotal2M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label108.ForeColor = System.Drawing.Color.Blue;
            this.label108.Location = new System.Drawing.Point(6, -6);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(87, 27);
            this.label108.TabIndex = 152;
            this.label108.Text = "CELL 2";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label109.ForeColor = System.Drawing.Color.GhostWhite;
            this.label109.Location = new System.Drawing.Point(4, 22);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(90, 29);
            this.label109.TabIndex = 153;
            this.label109.Text = "Target";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label110.ForeColor = System.Drawing.Color.GhostWhite;
            this.label110.Location = new System.Drawing.Point(3, 54);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(90, 29);
            this.label110.TabIndex = 156;
            this.label110.Text = "Output";
            // 
            // lbltotaltarget2M
            // 
            this.lbltotaltarget2M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget2M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget2M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget2M.Location = new System.Drawing.Point(104, 17);
            this.lbltotaltarget2M.Name = "lbltotaltarget2M";
            this.lbltotaltarget2M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget2M.TabIndex = 154;
            this.lbltotaltarget2M.Text = "0";
            this.lbltotaltarget2M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label147);
            this.groupBox14.Controls.Add(this.lblstd2);
            this.groupBox14.Controls.Add(this.lbltotal1M);
            this.groupBox14.Controls.Add(this.label95);
            this.groupBox14.Controls.Add(this.label97);
            this.groupBox14.Controls.Add(this.label100);
            this.groupBox14.Controls.Add(this.lbltotaltarget1M);
            this.groupBox14.Location = new System.Drawing.Point(514, 80);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(251, 133);
            this.groupBox14.TabIndex = 165;
            this.groupBox14.TabStop = false;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label147.ForeColor = System.Drawing.Color.GhostWhite;
            this.label147.Location = new System.Drawing.Point(4, 85);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(99, 25);
            this.label147.TabIndex = 159;
            this.label147.Text = "Std.Time";
            // 
            // lblstd2
            // 
            this.lblstd2.BackColor = System.Drawing.Color.Purple;
            this.lblstd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd2.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd2.Location = new System.Drawing.Point(107, 88);
            this.lblstd2.Name = "lblstd2";
            this.lblstd2.Size = new System.Drawing.Size(130, 30);
            this.lblstd2.TabIndex = 159;
            this.lblstd2.Text = "0";
            this.lblstd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal1M
            // 
            this.lbltotal1M.BackColor = System.Drawing.Color.Black;
            this.lbltotal1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal1M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal1M.Location = new System.Drawing.Point(107, 52);
            this.lbltotal1M.Name = "lbltotal1M";
            this.lbltotal1M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal1M.TabIndex = 155;
            this.lbltotal1M.Text = "0";
            this.lbltotal1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label95.ForeColor = System.Drawing.Color.Blue;
            this.label95.Location = new System.Drawing.Point(6, -6);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(87, 27);
            this.label95.TabIndex = 152;
            this.label95.Text = "CELL 1";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label97.ForeColor = System.Drawing.Color.GhostWhite;
            this.label97.Location = new System.Drawing.Point(11, 24);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(90, 29);
            this.label97.TabIndex = 153;
            this.label97.Text = "Target";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label100.ForeColor = System.Drawing.Color.GhostWhite;
            this.label100.Location = new System.Drawing.Point(10, 54);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(90, 29);
            this.label100.TabIndex = 156;
            this.label100.Text = "Output";
            // 
            // lbltotaltarget1M
            // 
            this.lbltotaltarget1M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget1M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget1M.Location = new System.Drawing.Point(107, 16);
            this.lbltotaltarget1M.Name = "lbltotaltarget1M";
            this.lbltotaltarget1M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget1M.TabIndex = 154;
            this.lbltotaltarget1M.Text = "0";
            this.lbltotaltarget1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label60M
            // 
            this.label60M.BackColor = System.Drawing.Color.Black;
            this.label60M.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label60M.ForeColor = System.Drawing.Color.White;
            this.label60M.Location = new System.Drawing.Point(18, 19);
            this.label60M.Name = "label60M";
            this.label60M.Size = new System.Drawing.Size(10, 40);
            this.label60M.TabIndex = 162;
            this.label60M.Text = "0";
            this.label60M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label60M.Visible = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label185);
            this.groupBox19.Controls.Add(this.lblstd9);
            this.groupBox19.Controls.Add(this.lbltotal8M);
            this.groupBox19.Controls.Add(this.label144);
            this.groupBox19.Controls.Add(this.label145);
            this.groupBox19.Controls.Add(this.label146);
            this.groupBox19.Controls.Add(this.lbltotaltarget8M);
            this.groupBox19.Location = new System.Drawing.Point(1024, 215);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(246, 125);
            this.groupBox19.TabIndex = 164;
            this.groupBox19.TabStop = false;
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label185.ForeColor = System.Drawing.Color.GhostWhite;
            this.label185.Location = new System.Drawing.Point(6, 92);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(99, 25);
            this.label185.TabIndex = 160;
            this.label185.Text = "Std.Time";
            // 
            // lblstd9
            // 
            this.lblstd9.BackColor = System.Drawing.Color.Purple;
            this.lblstd9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd9.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd9.Location = new System.Drawing.Point(107, 90);
            this.lblstd9.Name = "lblstd9";
            this.lblstd9.Size = new System.Drawing.Size(130, 30);
            this.lblstd9.TabIndex = 160;
            this.lblstd9.Text = "0";
            this.lblstd9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal8M
            // 
            this.lbltotal8M.BackColor = System.Drawing.Color.Black;
            this.lbltotal8M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal8M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal8M.Location = new System.Drawing.Point(107, 53);
            this.lbltotal8M.Name = "lbltotal8M";
            this.lbltotal8M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal8M.TabIndex = 155;
            this.lbltotal8M.Text = "0";
            this.lbltotal8M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label144.ForeColor = System.Drawing.Color.Blue;
            this.label144.Location = new System.Drawing.Point(14, 1);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(87, 27);
            this.label144.TabIndex = 152;
            this.label144.Text = "CELL 8";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label145.ForeColor = System.Drawing.Color.GhostWhite;
            this.label145.Location = new System.Drawing.Point(7, 30);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(90, 29);
            this.label145.TabIndex = 153;
            this.label145.Text = "Target";
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label146.ForeColor = System.Drawing.Color.GhostWhite;
            this.label146.Location = new System.Drawing.Point(7, 60);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(90, 29);
            this.label146.TabIndex = 156;
            this.label146.Text = "Output";
            // 
            // lbltotaltarget8M
            // 
            this.lbltotaltarget8M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget8M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget8M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget8M.Location = new System.Drawing.Point(107, 16);
            this.lbltotaltarget8M.Name = "lbltotaltarget8M";
            this.lbltotaltarget8M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget8M.TabIndex = 154;
            this.lbltotaltarget8M.Text = "0";
            this.lbltotaltarget8M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.label173);
            this.groupBox18.Controls.Add(this.lblstd5);
            this.groupBox18.Controls.Add(this.lbltotal4M);
            this.groupBox18.Controls.Add(this.label139);
            this.groupBox18.Controls.Add(this.label140);
            this.groupBox18.Controls.Add(this.label141);
            this.groupBox18.Controls.Add(this.lbltotaltarget4M);
            this.groupBox18.Location = new System.Drawing.Point(10, 216);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(247, 124);
            this.groupBox18.TabIndex = 163;
            this.groupBox18.TabStop = false;
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label173.ForeColor = System.Drawing.Color.GhostWhite;
            this.label173.Location = new System.Drawing.Point(7, 84);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(99, 25);
            this.label173.TabIndex = 159;
            this.label173.Text = "Std.Time";
            // 
            // lblstd5
            // 
            this.lblstd5.BackColor = System.Drawing.Color.Purple;
            this.lblstd5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd5.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd5.Location = new System.Drawing.Point(106, 88);
            this.lblstd5.Name = "lblstd5";
            this.lblstd5.Size = new System.Drawing.Size(130, 30);
            this.lblstd5.TabIndex = 159;
            this.lblstd5.Text = "0";
            this.lblstd5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotal4M
            // 
            this.lbltotal4M.BackColor = System.Drawing.Color.Black;
            this.lbltotal4M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal4M.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal4M.Location = new System.Drawing.Point(107, 52);
            this.lbltotal4M.Name = "lbltotal4M";
            this.lbltotal4M.Size = new System.Drawing.Size(130, 34);
            this.lbltotal4M.TabIndex = 155;
            this.lbltotal4M.Text = "0";
            this.lbltotal4M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label139.ForeColor = System.Drawing.Color.Blue;
            this.label139.Location = new System.Drawing.Point(6, -4);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(87, 27);
            this.label139.TabIndex = 152;
            this.label139.Text = "CELL 4";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label140.ForeColor = System.Drawing.Color.GhostWhite;
            this.label140.Location = new System.Drawing.Point(6, 23);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(90, 29);
            this.label140.TabIndex = 153;
            this.label140.Text = "Target";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label141.ForeColor = System.Drawing.Color.GhostWhite;
            this.label141.Location = new System.Drawing.Point(6, 52);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(90, 29);
            this.label141.TabIndex = 156;
            this.label141.Text = "Output";
            // 
            // lbltotaltarget4M
            // 
            this.lbltotaltarget4M.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget4M.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget4M.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget4M.Location = new System.Drawing.Point(108, 16);
            this.lbltotaltarget4M.Name = "lbltotaltarget4M";
            this.lbltotaltarget4M.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltarget4M.TabIndex = 154;
            this.lbltotaltarget4M.Text = "0";
            this.lbltotaltarget4M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.lblstd1);
            this.groupBox17.Controls.Add(this.label115);
            this.groupBox17.Controls.Add(this.lbltotalM);
            this.groupBox17.Controls.Add(this.label130);
            this.groupBox17.Controls.Add(this.label133);
            this.groupBox17.Controls.Add(this.label135);
            this.groupBox17.Controls.Add(this.lbltotaltargetM);
            this.groupBox17.Location = new System.Drawing.Point(10, 80);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(247, 133);
            this.groupBox17.TabIndex = 160;
            this.groupBox17.TabStop = false;
            // 
            // lblstd1
            // 
            this.lblstd1.BackColor = System.Drawing.Color.Purple;
            this.lblstd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstd1.ForeColor = System.Drawing.Color.Yellow;
            this.lblstd1.Location = new System.Drawing.Point(107, 91);
            this.lblstd1.Name = "lblstd1";
            this.lblstd1.Size = new System.Drawing.Size(130, 30);
            this.lblstd1.TabIndex = 158;
            this.lblstd1.Text = "0";
            this.lblstd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label115.ForeColor = System.Drawing.Color.GhostWhite;
            this.label115.Location = new System.Drawing.Point(5, 91);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(99, 25);
            this.label115.TabIndex = 157;
            this.label115.Text = "Std.Time";
            // 
            // lbltotalM
            // 
            this.lbltotalM.BackColor = System.Drawing.Color.Black;
            this.lbltotalM.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalM.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalM.Location = new System.Drawing.Point(107, 55);
            this.lbltotalM.Name = "lbltotalM";
            this.lbltotalM.Size = new System.Drawing.Size(130, 34);
            this.lbltotalM.TabIndex = 155;
            this.lbltotalM.Text = "0";
            this.lbltotalM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label130.ForeColor = System.Drawing.Color.Blue;
            this.label130.Location = new System.Drawing.Point(7, -3);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(100, 27);
            this.label130.TabIndex = 152;
            this.label130.Text = "CELL T1";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label133.ForeColor = System.Drawing.Color.GhostWhite;
            this.label133.Location = new System.Drawing.Point(8, 21);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(90, 29);
            this.label133.TabIndex = 153;
            this.label133.Text = "Target";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label135.ForeColor = System.Drawing.Color.GhostWhite;
            this.label135.Location = new System.Drawing.Point(9, 55);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(90, 29);
            this.label135.TabIndex = 156;
            this.label135.Text = "Output";
            // 
            // lbltotaltargetM
            // 
            this.lbltotaltargetM.BackColor = System.Drawing.Color.Black;
            this.lbltotaltargetM.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltargetM.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltargetM.Location = new System.Drawing.Point(108, 18);
            this.lbltotaltargetM.Name = "lbltotaltargetM";
            this.lbltotaltargetM.Size = new System.Drawing.Size(130, 34);
            this.lbltotaltargetM.TabIndex = 154;
            this.lbltotaltargetM.Text = "0";
            this.lbltotaltargetM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine2M
            // 
            this.lblLine2M.BackColor = System.Drawing.Color.Black;
            this.lblLine2M.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLine2M.ForeColor = System.Drawing.Color.Lime;
            this.lblLine2M.Location = new System.Drawing.Point(60, 20);
            this.lblLine2M.Name = "lblLine2M";
            this.lblLine2M.Size = new System.Drawing.Size(18, 39);
            this.lblLine2M.TabIndex = 151;
            this.lblLine2M.Text = "0";
            this.lblLine2M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine2M.Visible = false;
            // 
            // lblLine1M
            // 
            this.lblLine1M.BackColor = System.Drawing.Color.Black;
            this.lblLine1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLine1M.ForeColor = System.Drawing.Color.Lime;
            this.lblLine1M.Location = new System.Drawing.Point(6, 32);
            this.lblLine1M.Name = "lblLine1M";
            this.lblLine1M.Size = new System.Drawing.Size(31, 41);
            this.lblLine1M.TabIndex = 150;
            this.lblLine1M.Text = "0";
            this.lblLine1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine1M.Visible = false;
            // 
            // lblSatM
            // 
            this.lblSatM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblSatM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSatM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSatM.ForeColor = System.Drawing.Color.Yellow;
            this.lblSatM.Location = new System.Drawing.Point(897, 26);
            this.lblSatM.Name = "lblSatM";
            this.lblSatM.Size = new System.Drawing.Size(140, 31);
            this.lblSatM.TabIndex = 170;
            this.lblSatM.Text = "0";
            this.lblSatM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSatM.Click += new System.EventHandler(this.lblSatM_Click);
            // 
            // lblFriM
            // 
            this.lblFriM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblFriM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFriM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFriM.ForeColor = System.Drawing.Color.Yellow;
            this.lblFriM.Location = new System.Drawing.Point(742, 26);
            this.lblFriM.Name = "lblFriM";
            this.lblFriM.Size = new System.Drawing.Size(141, 31);
            this.lblFriM.TabIndex = 169;
            this.lblFriM.Text = "0";
            this.lblFriM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblThdM
            // 
            this.lblThdM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblThdM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThdM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblThdM.ForeColor = System.Drawing.Color.Yellow;
            this.lblThdM.Location = new System.Drawing.Point(584, 26);
            this.lblThdM.Name = "lblThdM";
            this.lblThdM.Size = new System.Drawing.Size(144, 31);
            this.lblThdM.TabIndex = 168;
            this.lblThdM.Text = "0";
            this.lblThdM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWebM
            // 
            this.lblWebM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblWebM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWebM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWebM.ForeColor = System.Drawing.Color.Yellow;
            this.lblWebM.Location = new System.Drawing.Point(440, 26);
            this.lblWebM.Name = "lblWebM";
            this.lblWebM.Size = new System.Drawing.Size(129, 31);
            this.lblWebM.TabIndex = 167;
            this.lblWebM.Text = "0";
            this.lblWebM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblWebM.Click += new System.EventHandler(this.label108_Click);
            // 
            // lblTueM
            // 
            this.lblTueM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTueM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTueM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTueM.ForeColor = System.Drawing.Color.Yellow;
            this.lblTueM.Location = new System.Drawing.Point(287, 26);
            this.lblTueM.Name = "lblTueM";
            this.lblTueM.Size = new System.Drawing.Size(136, 31);
            this.lblTueM.TabIndex = 166;
            this.lblTueM.Text = "0";
            this.lblTueM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMonM
            // 
            this.lblMonM.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblMonM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMonM.ForeColor = System.Drawing.Color.Yellow;
            this.lblMonM.Location = new System.Drawing.Point(138, 26);
            this.lblMonM.Name = "lblMonM";
            this.lblMonM.Size = new System.Drawing.Size(137, 31);
            this.lblMonM.TabIndex = 165;
            this.lblMonM.Text = "0";
            this.lblMonM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label56.Location = new System.Drawing.Point(949, 5);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(47, 23);
            this.label56.TabIndex = 148;
            this.label56.Text = "SAT";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label61.Location = new System.Drawing.Point(787, 5);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(44, 23);
            this.label61.TabIndex = 147;
            this.label61.Text = "FRI";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label62.Location = new System.Drawing.Point(634, 5);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(51, 23);
            this.label62.TabIndex = 146;
            this.label62.Text = "THD";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label63.Location = new System.Drawing.Point(483, 5);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(56, 23);
            this.label63.TabIndex = 145;
            this.label63.Text = "WED";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label72.Location = new System.Drawing.Point(337, 5);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(48, 23);
            this.label72.TabIndex = 144;
            this.label72.Text = "TUE";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label73.Location = new System.Drawing.Point(189, 5);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(57, 23);
            this.label73.TabIndex = 143;
            this.label73.Text = "MON";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(1287, 729);
            this.shapeContainer2.TabIndex = 171;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -3;
            this.lineShape2.X2 = 1304;
            this.lineShape2.Y1 = 58;
            this.lineShape2.Y2 = 58;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox33);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1287, 729);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "       CELL T1,T2, CELL 1 - 4    ";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox33
            // 
            this.groupBox33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox33.Controls.Add(this.lblbalanceT2);
            this.groupBox33.Controls.Add(this.lblactualT2);
            this.groupBox33.Controls.Add(this.lbltargetT2);
            this.groupBox33.Controls.Add(this.label125);
            this.groupBox33.Controls.Add(this.label177);
            this.groupBox33.Controls.Add(this.label219);
            this.groupBox33.Controls.Add(this.label220);
            this.groupBox33.Controls.Add(this.lblPOT2);
            this.groupBox33.Controls.Add(this.label222);
            this.groupBox33.Controls.Add(this.lbltotalT2);
            this.groupBox33.Controls.Add(this.label224);
            this.groupBox33.Controls.Add(this.lbltotaltargetT2);
            this.groupBox33.Controls.Add(this.label226);
            this.groupBox33.Controls.Add(this.label227);
            this.groupBox33.Location = new System.Drawing.Point(607, 11);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(556, 220);
            this.groupBox33.TabIndex = 157;
            this.groupBox33.TabStop = false;
            // 
            // lblbalanceT2
            // 
            this.lblbalanceT2.BackColor = System.Drawing.Color.Black;
            this.lblbalanceT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalanceT2.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalanceT2.Location = new System.Drawing.Point(407, 163);
            this.lblbalanceT2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalanceT2.Name = "lblbalanceT2";
            this.lblbalanceT2.Size = new System.Drawing.Size(138, 46);
            this.lblbalanceT2.TabIndex = 154;
            this.lblbalanceT2.Text = "0";
            this.lblbalanceT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactualT2
            // 
            this.lblactualT2.BackColor = System.Drawing.Color.Black;
            this.lblactualT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactualT2.ForeColor = System.Drawing.Color.Yellow;
            this.lblactualT2.Location = new System.Drawing.Point(271, 163);
            this.lblactualT2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactualT2.Name = "lblactualT2";
            this.lblactualT2.Size = new System.Drawing.Size(135, 46);
            this.lblactualT2.TabIndex = 153;
            this.lblactualT2.Text = "0";
            this.lblactualT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltargetT2
            // 
            this.lbltargetT2.BackColor = System.Drawing.Color.Black;
            this.lbltargetT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltargetT2.ForeColor = System.Drawing.Color.Yellow;
            this.lbltargetT2.Location = new System.Drawing.Point(134, 163);
            this.lbltargetT2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltargetT2.Name = "lbltargetT2";
            this.lbltargetT2.Size = new System.Drawing.Size(136, 46);
            this.lbltargetT2.TabIndex = 152;
            this.lbltargetT2.Text = "0";
            this.lbltargetT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label125.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label125.Location = new System.Drawing.Point(23, 176);
            this.label125.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(103, 33);
            this.label125.TabIndex = 151;
            this.label125.Text = "TOTAL";
            // 
            // label177
            // 
            this.label177.BackColor = System.Drawing.Color.Green;
            this.label177.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label177.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label177.ForeColor = System.Drawing.Color.Tomato;
            this.label177.Location = new System.Drawing.Point(407, 127);
            this.label177.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(138, 36);
            this.label177.TabIndex = 150;
            this.label177.Text = "Balance";
            this.label177.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label219
            // 
            this.label219.BackColor = System.Drawing.Color.Green;
            this.label219.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label219.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label219.ForeColor = System.Drawing.Color.Tomato;
            this.label219.Location = new System.Drawing.Point(271, 127);
            this.label219.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(135, 36);
            this.label219.TabIndex = 149;
            this.label219.Text = "Actual";
            this.label219.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label220
            // 
            this.label220.BackColor = System.Drawing.Color.Green;
            this.label220.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label220.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label220.ForeColor = System.Drawing.Color.Tomato;
            this.label220.Location = new System.Drawing.Point(134, 127);
            this.label220.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(136, 36);
            this.label220.TabIndex = 148;
            this.label220.Text = "Batch";
            this.label220.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPOT2
            // 
            this.lblPOT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPOT2.ForeColor = System.Drawing.Color.Blue;
            this.lblPOT2.Location = new System.Drawing.Point(160, 92);
            this.lblPOT2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOT2.Name = "lblPOT2";
            this.lblPOT2.Size = new System.Drawing.Size(355, 35);
            this.lblPOT2.TabIndex = 147;
            this.lblPOT2.Text = "56300/C14/8";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label222.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label222.Location = new System.Drawing.Point(17, 98);
            this.label222.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(147, 25);
            this.label222.TabIndex = 146;
            this.label222.Text = "CELL T2 PO#";
            // 
            // lbltotalT2
            // 
            this.lbltotalT2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalT2.BackColor = System.Drawing.Color.Black;
            this.lbltotalT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalT2.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalT2.Location = new System.Drawing.Point(354, 42);
            this.lbltotalT2.Name = "lbltotalT2";
            this.lbltotalT2.Size = new System.Drawing.Size(190, 49);
            this.lbltotalT2.TabIndex = 144;
            this.lbltotalT2.Text = "0";
            this.lbltotalT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label224.ForeColor = System.Drawing.Color.Blue;
            this.label224.Location = new System.Drawing.Point(7, 16);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(122, 33);
            this.label224.TabIndex = 129;
            this.label224.Text = "CELL T2";
            // 
            // lbltotaltargetT2
            // 
            this.lbltotaltargetT2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltargetT2.BackColor = System.Drawing.Color.Black;
            this.lbltotaltargetT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltargetT2.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltargetT2.Location = new System.Drawing.Point(153, 42);
            this.lbltotaltargetT2.Name = "lbltotaltargetT2";
            this.lbltotaltargetT2.Size = new System.Drawing.Size(178, 48);
            this.lbltotaltargetT2.TabIndex = 142;
            this.lbltotaltargetT2.Text = "0";
            this.lbltotaltargetT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label226.ForeColor = System.Drawing.Color.Purple;
            this.label226.Location = new System.Drawing.Point(147, 11);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(188, 31);
            this.label226.TabIndex = 143;
            this.label226.Text = "Today Target";
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label227.ForeColor = System.Drawing.Color.Purple;
            this.label227.Location = new System.Drawing.Point(351, 11);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(191, 31);
            this.label227.TabIndex = 145;
            this.label227.Text = "Today Output";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox12);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1287, 729);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "        CELL 5 -10        ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox12.Controls.Add(this.lblbalance10);
            this.groupBox12.Controls.Add(this.lblPO10);
            this.groupBox12.Controls.Add(this.lblactual10);
            this.groupBox12.Controls.Add(this.label126);
            this.groupBox12.Controls.Add(this.lbltarget10);
            this.groupBox12.Controls.Add(this.label128);
            this.groupBox12.Controls.Add(this.label129);
            this.groupBox12.Controls.Add(this.lbltotaltarget10);
            this.groupBox12.Controls.Add(this.label131);
            this.groupBox12.Controls.Add(this.label132);
            this.groupBox12.Controls.Add(this.label134);
            this.groupBox12.Controls.Add(this.lblsofa10);
            this.groupBox12.Controls.Add(this.label136);
            this.groupBox12.Controls.Add(this.label137);
            this.groupBox12.Location = new System.Drawing.Point(630, 488);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(556, 229);
            this.groupBox12.TabIndex = 162;
            this.groupBox12.TabStop = false;
            // 
            // lblbalance10
            // 
            this.lblbalance10.BackColor = System.Drawing.Color.Black;
            this.lblbalance10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance10.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance10.Location = new System.Drawing.Point(409, 166);
            this.lblbalance10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance10.Name = "lblbalance10";
            this.lblbalance10.Size = new System.Drawing.Size(138, 50);
            this.lblbalance10.TabIndex = 178;
            this.lblbalance10.Text = "0";
            this.lblbalance10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO10
            // 
            this.lblPO10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO10.ForeColor = System.Drawing.Color.Blue;
            this.lblPO10.Location = new System.Drawing.Point(175, 92);
            this.lblPO10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO10.Name = "lblPO10";
            this.lblPO10.Size = new System.Drawing.Size(355, 32);
            this.lblPO10.TabIndex = 158;
            // 
            // lblactual10
            // 
            this.lblactual10.BackColor = System.Drawing.Color.Black;
            this.lblactual10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual10.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual10.Location = new System.Drawing.Point(273, 166);
            this.lblactual10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual10.Name = "lblactual10";
            this.lblactual10.Size = new System.Drawing.Size(135, 50);
            this.lblactual10.TabIndex = 177;
            this.lblactual10.Text = "0";
            this.lblactual10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label126.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label126.Location = new System.Drawing.Point(37, 92);
            this.label126.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(134, 24);
            this.label126.TabIndex = 158;
            this.label126.Text = "CELL 10 PO#";
            // 
            // lbltarget10
            // 
            this.lbltarget10.BackColor = System.Drawing.Color.Black;
            this.lbltarget10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget10.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget10.Location = new System.Drawing.Point(136, 166);
            this.lbltarget10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget10.Name = "lbltarget10";
            this.lbltarget10.Size = new System.Drawing.Size(136, 50);
            this.lbltarget10.TabIndex = 176;
            this.lbltarget10.Text = "0";
            this.lbltarget10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label128.ForeColor = System.Drawing.Color.Purple;
            this.label128.Location = new System.Drawing.Point(169, 11);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(188, 31);
            this.label128.TabIndex = 156;
            this.label128.Text = "Today Target";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label129.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label129.Location = new System.Drawing.Point(27, 178);
            this.label129.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(103, 33);
            this.label129.TabIndex = 175;
            this.label129.Text = "TOTAL";
            // 
            // lbltotaltarget10
            // 
            this.lbltotaltarget10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget10.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget10.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget10.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget10.Name = "lbltotaltarget10";
            this.lbltotaltarget10.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget10.TabIndex = 156;
            this.lbltotaltarget10.Text = "0";
            this.lbltotaltarget10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.Green;
            this.label131.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label131.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label131.ForeColor = System.Drawing.Color.Tomato;
            this.label131.Location = new System.Drawing.Point(409, 130);
            this.label131.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(138, 36);
            this.label131.TabIndex = 174;
            this.label131.Text = "Balance";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Green;
            this.label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label132.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label132.ForeColor = System.Drawing.Color.Tomato;
            this.label132.Location = new System.Drawing.Point(273, 130);
            this.label132.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(135, 36);
            this.label132.TabIndex = 173;
            this.label132.Text = "Actual";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label134
            // 
            this.label134.BackColor = System.Drawing.Color.Green;
            this.label134.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label134.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label134.ForeColor = System.Drawing.Color.Tomato;
            this.label134.Location = new System.Drawing.Point(136, 130);
            this.label134.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(136, 36);
            this.label134.TabIndex = 172;
            this.label134.Text = "Batch";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa10
            // 
            this.lblsofa10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa10.BackColor = System.Drawing.Color.Black;
            this.lblsofa10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa10.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa10.Location = new System.Drawing.Point(391, 42);
            this.lblsofa10.Name = "lblsofa10";
            this.lblsofa10.Size = new System.Drawing.Size(138, 43);
            this.lblsofa10.TabIndex = 144;
            this.lblsofa10.Text = "0";
            this.lblsofa10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label136.ForeColor = System.Drawing.Color.Blue;
            this.label136.Location = new System.Drawing.Point(8, 11);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(122, 33);
            this.label136.TabIndex = 129;
            this.label136.Text = "CELL 10";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label137.ForeColor = System.Drawing.Color.Purple;
            this.label137.Location = new System.Drawing.Point(365, 11);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(191, 31);
            this.label137.TabIndex = 145;
            this.label137.Text = "Today Output";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox11.Controls.Add(this.lblbalance9);
            this.groupBox11.Controls.Add(this.lblPO9);
            this.groupBox11.Controls.Add(this.lblactual9);
            this.groupBox11.Controls.Add(this.label111);
            this.groupBox11.Controls.Add(this.lbltarget9);
            this.groupBox11.Controls.Add(this.label113);
            this.groupBox11.Controls.Add(this.label114);
            this.groupBox11.Controls.Add(this.lbltotaltarget9);
            this.groupBox11.Controls.Add(this.label116);
            this.groupBox11.Controls.Add(this.label117);
            this.groupBox11.Controls.Add(this.label119);
            this.groupBox11.Controls.Add(this.lblsofa9);
            this.groupBox11.Controls.Add(this.label121);
            this.groupBox11.Controls.Add(this.label122);
            this.groupBox11.Location = new System.Drawing.Point(630, 250);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(556, 229);
            this.groupBox11.TabIndex = 161;
            this.groupBox11.TabStop = false;
            // 
            // lblbalance9
            // 
            this.lblbalance9.BackColor = System.Drawing.Color.Black;
            this.lblbalance9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance9.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance9.Location = new System.Drawing.Point(409, 166);
            this.lblbalance9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance9.Name = "lblbalance9";
            this.lblbalance9.Size = new System.Drawing.Size(138, 50);
            this.lblbalance9.TabIndex = 178;
            this.lblbalance9.Text = "0";
            this.lblbalance9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO9
            // 
            this.lblPO9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO9.ForeColor = System.Drawing.Color.Blue;
            this.lblPO9.Location = new System.Drawing.Point(175, 92);
            this.lblPO9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO9.Name = "lblPO9";
            this.lblPO9.Size = new System.Drawing.Size(355, 32);
            this.lblPO9.TabIndex = 158;
            // 
            // lblactual9
            // 
            this.lblactual9.BackColor = System.Drawing.Color.Black;
            this.lblactual9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual9.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual9.Location = new System.Drawing.Point(273, 166);
            this.lblactual9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual9.Name = "lblactual9";
            this.lblactual9.Size = new System.Drawing.Size(135, 50);
            this.lblactual9.TabIndex = 177;
            this.lblactual9.Text = "0";
            this.lblactual9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label111.Location = new System.Drawing.Point(37, 92);
            this.label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(123, 24);
            this.label111.TabIndex = 158;
            this.label111.Text = "CELL 9 PO#";
            // 
            // lbltarget9
            // 
            this.lbltarget9.BackColor = System.Drawing.Color.Black;
            this.lbltarget9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget9.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget9.Location = new System.Drawing.Point(136, 166);
            this.lbltarget9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget9.Name = "lbltarget9";
            this.lbltarget9.Size = new System.Drawing.Size(136, 50);
            this.lbltarget9.TabIndex = 176;
            this.lbltarget9.Text = "0";
            this.lbltarget9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label113.ForeColor = System.Drawing.Color.Purple;
            this.label113.Location = new System.Drawing.Point(169, 11);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(188, 31);
            this.label113.TabIndex = 156;
            this.label113.Text = "Today Target";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label114.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label114.Location = new System.Drawing.Point(27, 179);
            this.label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(103, 33);
            this.label114.TabIndex = 175;
            this.label114.Text = "TOTAL";
            // 
            // lbltotaltarget9
            // 
            this.lbltotaltarget9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget9.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget9.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget9.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget9.Name = "lbltotaltarget9";
            this.lbltotaltarget9.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget9.TabIndex = 156;
            this.lbltotaltarget9.Text = "0";
            this.lbltotaltarget9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Green;
            this.label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label116.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label116.ForeColor = System.Drawing.Color.Tomato;
            this.label116.Location = new System.Drawing.Point(409, 130);
            this.label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(138, 36);
            this.label116.TabIndex = 174;
            this.label116.Text = "Balance";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.Green;
            this.label117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label117.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label117.ForeColor = System.Drawing.Color.Tomato;
            this.label117.Location = new System.Drawing.Point(273, 130);
            this.label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(135, 36);
            this.label117.TabIndex = 173;
            this.label117.Text = "Actual";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.Green;
            this.label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label119.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label119.ForeColor = System.Drawing.Color.Tomato;
            this.label119.Location = new System.Drawing.Point(136, 130);
            this.label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(136, 36);
            this.label119.TabIndex = 172;
            this.label119.Text = "Batch";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa9
            // 
            this.lblsofa9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa9.BackColor = System.Drawing.Color.Black;
            this.lblsofa9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa9.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa9.Location = new System.Drawing.Point(391, 42);
            this.lblsofa9.Name = "lblsofa9";
            this.lblsofa9.Size = new System.Drawing.Size(138, 43);
            this.lblsofa9.TabIndex = 144;
            this.lblsofa9.Text = "0";
            this.lblsofa9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label121.ForeColor = System.Drawing.Color.Blue;
            this.label121.Location = new System.Drawing.Point(8, 11);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(105, 33);
            this.label121.TabIndex = 129;
            this.label121.Text = "CELL 9";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label122.ForeColor = System.Drawing.Color.Purple;
            this.label122.Location = new System.Drawing.Point(365, 11);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(191, 31);
            this.label122.TabIndex = 145;
            this.label122.Text = "Today Output";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox10.Controls.Add(this.lblbalance8);
            this.groupBox10.Controls.Add(this.lblPO8);
            this.groupBox10.Controls.Add(this.lblactual8);
            this.groupBox10.Controls.Add(this.label96);
            this.groupBox10.Controls.Add(this.lbltarget8);
            this.groupBox10.Controls.Add(this.label98);
            this.groupBox10.Controls.Add(this.label99);
            this.groupBox10.Controls.Add(this.lbltotaltarget8);
            this.groupBox10.Controls.Add(this.label101);
            this.groupBox10.Controls.Add(this.label102);
            this.groupBox10.Controls.Add(this.label104);
            this.groupBox10.Controls.Add(this.lblsofa8);
            this.groupBox10.Controls.Add(this.label106);
            this.groupBox10.Controls.Add(this.label107);
            this.groupBox10.Location = new System.Drawing.Point(630, 11);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(556, 229);
            this.groupBox10.TabIndex = 160;
            this.groupBox10.TabStop = false;
            // 
            // lblbalance8
            // 
            this.lblbalance8.BackColor = System.Drawing.Color.Black;
            this.lblbalance8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance8.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance8.Location = new System.Drawing.Point(409, 166);
            this.lblbalance8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance8.Name = "lblbalance8";
            this.lblbalance8.Size = new System.Drawing.Size(138, 50);
            this.lblbalance8.TabIndex = 178;
            this.lblbalance8.Text = "0";
            this.lblbalance8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO8
            // 
            this.lblPO8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO8.ForeColor = System.Drawing.Color.Blue;
            this.lblPO8.Location = new System.Drawing.Point(175, 92);
            this.lblPO8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO8.Name = "lblPO8";
            this.lblPO8.Size = new System.Drawing.Size(355, 32);
            this.lblPO8.TabIndex = 158;
            // 
            // lblactual8
            // 
            this.lblactual8.BackColor = System.Drawing.Color.Black;
            this.lblactual8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual8.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual8.Location = new System.Drawing.Point(273, 166);
            this.lblactual8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual8.Name = "lblactual8";
            this.lblactual8.Size = new System.Drawing.Size(135, 50);
            this.lblactual8.TabIndex = 177;
            this.lblactual8.Text = "0";
            this.lblactual8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label96.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label96.Location = new System.Drawing.Point(37, 92);
            this.label96.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(123, 24);
            this.label96.TabIndex = 158;
            this.label96.Text = "CELL 8 PO#";
            // 
            // lbltarget8
            // 
            this.lbltarget8.BackColor = System.Drawing.Color.Black;
            this.lbltarget8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget8.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget8.Location = new System.Drawing.Point(136, 166);
            this.lbltarget8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget8.Name = "lbltarget8";
            this.lbltarget8.Size = new System.Drawing.Size(136, 50);
            this.lbltarget8.TabIndex = 176;
            this.lbltarget8.Text = "0";
            this.lbltarget8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label98.ForeColor = System.Drawing.Color.Purple;
            this.label98.Location = new System.Drawing.Point(169, 11);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(188, 31);
            this.label98.TabIndex = 156;
            this.label98.Text = "Today Target";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label99.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label99.Location = new System.Drawing.Point(25, 177);
            this.label99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(103, 33);
            this.label99.TabIndex = 175;
            this.label99.Text = "TOTAL";
            // 
            // lbltotaltarget8
            // 
            this.lbltotaltarget8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget8.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget8.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget8.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget8.Name = "lbltotaltarget8";
            this.lbltotaltarget8.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget8.TabIndex = 156;
            this.lbltotaltarget8.Text = "0";
            this.lbltotaltarget8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Green;
            this.label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label101.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label101.ForeColor = System.Drawing.Color.Tomato;
            this.label101.Location = new System.Drawing.Point(409, 130);
            this.label101.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(138, 36);
            this.label101.TabIndex = 174;
            this.label101.Text = "Balance";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Green;
            this.label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label102.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label102.ForeColor = System.Drawing.Color.Tomato;
            this.label102.Location = new System.Drawing.Point(273, 130);
            this.label102.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(135, 36);
            this.label102.TabIndex = 173;
            this.label102.Text = "Actual";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Green;
            this.label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label104.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label104.ForeColor = System.Drawing.Color.Tomato;
            this.label104.Location = new System.Drawing.Point(136, 130);
            this.label104.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(136, 36);
            this.label104.TabIndex = 172;
            this.label104.Text = "Batch";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa8
            // 
            this.lblsofa8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa8.BackColor = System.Drawing.Color.Black;
            this.lblsofa8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa8.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa8.Location = new System.Drawing.Point(391, 42);
            this.lblsofa8.Name = "lblsofa8";
            this.lblsofa8.Size = new System.Drawing.Size(138, 43);
            this.lblsofa8.TabIndex = 144;
            this.lblsofa8.Text = "0";
            this.lblsofa8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label106.ForeColor = System.Drawing.Color.Blue;
            this.label106.Location = new System.Drawing.Point(8, 11);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(105, 33);
            this.label106.TabIndex = 129;
            this.label106.Text = "CELL 8";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label107.ForeColor = System.Drawing.Color.Purple;
            this.label107.Location = new System.Drawing.Point(365, 11);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(191, 31);
            this.label107.TabIndex = 145;
            this.label107.Text = "Today Output";
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox9.Controls.Add(this.lblbalance7);
            this.groupBox9.Controls.Add(this.lblPO7);
            this.groupBox9.Controls.Add(this.lblactual7);
            this.groupBox9.Controls.Add(this.label82);
            this.groupBox9.Controls.Add(this.lbltarget7);
            this.groupBox9.Controls.Add(this.label84);
            this.groupBox9.Controls.Add(this.label85);
            this.groupBox9.Controls.Add(this.lbltotaltarget7);
            this.groupBox9.Controls.Add(this.label87);
            this.groupBox9.Controls.Add(this.label88);
            this.groupBox9.Controls.Add(this.label90);
            this.groupBox9.Controls.Add(this.lblsofa7);
            this.groupBox9.Controls.Add(this.label92);
            this.groupBox9.Controls.Add(this.label93);
            this.groupBox9.Location = new System.Drawing.Point(26, 492);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(556, 229);
            this.groupBox9.TabIndex = 159;
            this.groupBox9.TabStop = false;
            // 
            // lblbalance7
            // 
            this.lblbalance7.BackColor = System.Drawing.Color.Black;
            this.lblbalance7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance7.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance7.Location = new System.Drawing.Point(409, 166);
            this.lblbalance7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance7.Name = "lblbalance7";
            this.lblbalance7.Size = new System.Drawing.Size(138, 50);
            this.lblbalance7.TabIndex = 178;
            this.lblbalance7.Text = "0";
            this.lblbalance7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO7
            // 
            this.lblPO7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO7.ForeColor = System.Drawing.Color.Blue;
            this.lblPO7.Location = new System.Drawing.Point(175, 92);
            this.lblPO7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO7.Name = "lblPO7";
            this.lblPO7.Size = new System.Drawing.Size(355, 32);
            this.lblPO7.TabIndex = 158;
            // 
            // lblactual7
            // 
            this.lblactual7.BackColor = System.Drawing.Color.Black;
            this.lblactual7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual7.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual7.Location = new System.Drawing.Point(273, 166);
            this.lblactual7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual7.Name = "lblactual7";
            this.lblactual7.Size = new System.Drawing.Size(135, 50);
            this.lblactual7.TabIndex = 177;
            this.lblactual7.Text = "0";
            this.lblactual7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label82.Location = new System.Drawing.Point(37, 92);
            this.label82.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(123, 24);
            this.label82.TabIndex = 158;
            this.label82.Text = "CELL 7 PO#";
            // 
            // lbltarget7
            // 
            this.lbltarget7.BackColor = System.Drawing.Color.Black;
            this.lbltarget7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget7.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget7.Location = new System.Drawing.Point(136, 166);
            this.lbltarget7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget7.Name = "lbltarget7";
            this.lbltarget7.Size = new System.Drawing.Size(136, 50);
            this.lbltarget7.TabIndex = 176;
            this.lbltarget7.Text = "0";
            this.lbltarget7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label84.ForeColor = System.Drawing.Color.Purple;
            this.label84.Location = new System.Drawing.Point(169, 11);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(188, 31);
            this.label84.TabIndex = 156;
            this.label84.Text = "Today Target";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label85.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label85.Location = new System.Drawing.Point(21, 179);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(103, 33);
            this.label85.TabIndex = 175;
            this.label85.Text = "TOTAL";
            // 
            // lbltotaltarget7
            // 
            this.lbltotaltarget7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget7.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget7.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget7.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget7.Name = "lbltotaltarget7";
            this.lbltotaltarget7.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget7.TabIndex = 156;
            this.lbltotaltarget7.Text = "0";
            this.lbltotaltarget7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.Green;
            this.label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label87.ForeColor = System.Drawing.Color.Tomato;
            this.label87.Location = new System.Drawing.Point(409, 130);
            this.label87.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(138, 36);
            this.label87.TabIndex = 174;
            this.label87.Text = "Balance";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Green;
            this.label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label88.ForeColor = System.Drawing.Color.Tomato;
            this.label88.Location = new System.Drawing.Point(273, 130);
            this.label88.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(135, 36);
            this.label88.TabIndex = 173;
            this.label88.Text = "Actual";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Green;
            this.label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label90.ForeColor = System.Drawing.Color.Tomato;
            this.label90.Location = new System.Drawing.Point(136, 130);
            this.label90.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(136, 36);
            this.label90.TabIndex = 172;
            this.label90.Text = "Batch";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsofa7
            // 
            this.lblsofa7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa7.BackColor = System.Drawing.Color.Black;
            this.lblsofa7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa7.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa7.Location = new System.Drawing.Point(391, 42);
            this.lblsofa7.Name = "lblsofa7";
            this.lblsofa7.Size = new System.Drawing.Size(138, 43);
            this.lblsofa7.TabIndex = 144;
            this.lblsofa7.Text = "0";
            this.lblsofa7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label92.ForeColor = System.Drawing.Color.Blue;
            this.label92.Location = new System.Drawing.Point(8, 11);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(105, 33);
            this.label92.TabIndex = 129;
            this.label92.Text = "CELL 7";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label93.ForeColor = System.Drawing.Color.Purple;
            this.label93.Location = new System.Drawing.Point(365, 11);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(191, 31);
            this.label93.TabIndex = 145;
            this.label93.Text = "Today Output";
            // 
            // lblactual13
            // 
            this.lblactual13.Controls.Add(this.groupBox38);
            this.lblactual13.Controls.Add(this.groupBox37);
            this.lblactual13.Controls.Add(this.groupBox36);
            this.lblactual13.Controls.Add(this.groupBox35);
            this.lblactual13.Controls.Add(this.groupBox34);
            this.lblactual13.Controls.Add(this.groupBox26);
            this.lblactual13.Location = new System.Drawing.Point(4, 25);
            this.lblactual13.Name = "lblactual13";
            this.lblactual13.Size = new System.Drawing.Size(1287, 729);
            this.lblactual13.TabIndex = 3;
            this.lblactual13.Text = " CELL 11-15 ,CELL S1";
            this.lblactual13.UseVisualStyleBackColor = true;
            // 
            // groupBox38
            // 
            this.groupBox38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox38.Controls.Add(this.lblbalanceS1);
            this.groupBox38.Controls.Add(this.lblactualS1);
            this.groupBox38.Controls.Add(this.lbltargetS1);
            this.groupBox38.Controls.Add(this.label268);
            this.groupBox38.Controls.Add(this.label269);
            this.groupBox38.Controls.Add(this.label270);
            this.groupBox38.Controls.Add(this.label271);
            this.groupBox38.Controls.Add(this.lblPOS1);
            this.groupBox38.Controls.Add(this.label273);
            this.groupBox38.Controls.Add(this.lbltotaltargetS1);
            this.groupBox38.Controls.Add(this.label275);
            this.groupBox38.Controls.Add(this.lbltotalS1);
            this.groupBox38.Controls.Add(this.label277);
            this.groupBox38.Controls.Add(this.label278);
            this.groupBox38.Location = new System.Drawing.Point(636, 478);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(556, 220);
            this.groupBox38.TabIndex = 168;
            this.groupBox38.TabStop = false;
            // 
            // lblbalanceS1
            // 
            this.lblbalanceS1.BackColor = System.Drawing.Color.Black;
            this.lblbalanceS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalanceS1.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalanceS1.Location = new System.Drawing.Point(407, 161);
            this.lblbalanceS1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalanceS1.Name = "lblbalanceS1";
            this.lblbalanceS1.Size = new System.Drawing.Size(138, 50);
            this.lblbalanceS1.TabIndex = 164;
            this.lblbalanceS1.Text = "0";
            this.lblbalanceS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactualS1
            // 
            this.lblactualS1.BackColor = System.Drawing.Color.Black;
            this.lblactualS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactualS1.ForeColor = System.Drawing.Color.Yellow;
            this.lblactualS1.Location = new System.Drawing.Point(271, 161);
            this.lblactualS1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactualS1.Name = "lblactualS1";
            this.lblactualS1.Size = new System.Drawing.Size(135, 50);
            this.lblactualS1.TabIndex = 163;
            this.lblactualS1.Text = "0";
            this.lblactualS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltargetS1
            // 
            this.lbltargetS1.BackColor = System.Drawing.Color.Black;
            this.lbltargetS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltargetS1.ForeColor = System.Drawing.Color.Yellow;
            this.lbltargetS1.Location = new System.Drawing.Point(134, 161);
            this.lbltargetS1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltargetS1.Name = "lbltargetS1";
            this.lbltargetS1.Size = new System.Drawing.Size(136, 50);
            this.lbltargetS1.TabIndex = 162;
            this.lbltargetS1.Text = "0";
            this.lbltargetS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label268
            // 
            this.label268.AutoSize = true;
            this.label268.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label268.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label268.Location = new System.Drawing.Point(24, 173);
            this.label268.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label268.Name = "label268";
            this.label268.Size = new System.Drawing.Size(103, 33);
            this.label268.TabIndex = 161;
            this.label268.Text = "TOTAL";
            // 
            // label269
            // 
            this.label269.BackColor = System.Drawing.Color.Green;
            this.label269.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label269.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label269.ForeColor = System.Drawing.Color.Tomato;
            this.label269.Location = new System.Drawing.Point(407, 125);
            this.label269.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label269.Name = "label269";
            this.label269.Size = new System.Drawing.Size(138, 36);
            this.label269.TabIndex = 160;
            this.label269.Text = "Balance";
            this.label269.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label270
            // 
            this.label270.BackColor = System.Drawing.Color.Green;
            this.label270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label270.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label270.ForeColor = System.Drawing.Color.Tomato;
            this.label270.Location = new System.Drawing.Point(271, 125);
            this.label270.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(135, 36);
            this.label270.TabIndex = 159;
            this.label270.Text = "Actual";
            this.label270.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label271
            // 
            this.label271.BackColor = System.Drawing.Color.Green;
            this.label271.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label271.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label271.ForeColor = System.Drawing.Color.Tomato;
            this.label271.Location = new System.Drawing.Point(134, 125);
            this.label271.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label271.Name = "label271";
            this.label271.Size = new System.Drawing.Size(136, 36);
            this.label271.TabIndex = 158;
            this.label271.Text = "Batch";
            this.label271.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPOS1
            // 
            this.lblPOS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPOS1.ForeColor = System.Drawing.Color.Blue;
            this.lblPOS1.Location = new System.Drawing.Point(175, 88);
            this.lblPOS1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOS1.Name = "lblPOS1";
            this.lblPOS1.Size = new System.Drawing.Size(355, 35);
            this.lblPOS1.TabIndex = 157;
            // 
            // label273
            // 
            this.label273.AutoSize = true;
            this.label273.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label273.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label273.Location = new System.Drawing.Point(33, 87);
            this.label273.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label273.Name = "label273";
            this.label273.Size = new System.Drawing.Size(136, 24);
            this.label273.TabIndex = 157;
            this.label273.Text = "CELL S1 PO#";
            // 
            // lbltotaltargetS1
            // 
            this.lbltotaltargetS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltargetS1.BackColor = System.Drawing.Color.Black;
            this.lbltotaltargetS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltargetS1.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltargetS1.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltargetS1.Name = "lbltotaltargetS1";
            this.lbltotaltargetS1.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltargetS1.TabIndex = 155;
            this.lbltotaltargetS1.Text = "0";
            this.lbltotaltargetS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label275
            // 
            this.label275.AutoSize = true;
            this.label275.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label275.ForeColor = System.Drawing.Color.Purple;
            this.label275.Location = new System.Drawing.Point(163, 11);
            this.label275.Name = "label275";
            this.label275.Size = new System.Drawing.Size(188, 31);
            this.label275.TabIndex = 155;
            this.label275.Text = "Today Target";
            // 
            // lbltotalS1
            // 
            this.lbltotalS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalS1.BackColor = System.Drawing.Color.Black;
            this.lbltotalS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotalS1.ForeColor = System.Drawing.Color.Lime;
            this.lbltotalS1.Location = new System.Drawing.Point(386, 41);
            this.lbltotalS1.Name = "lbltotalS1";
            this.lbltotalS1.Size = new System.Drawing.Size(143, 43);
            this.lbltotalS1.TabIndex = 144;
            this.lbltotalS1.Text = "0";
            this.lbltotalS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label277
            // 
            this.label277.AutoSize = true;
            this.label277.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label277.ForeColor = System.Drawing.Color.Blue;
            this.label277.Location = new System.Drawing.Point(7, 11);
            this.label277.Name = "label277";
            this.label277.Size = new System.Drawing.Size(122, 33);
            this.label277.TabIndex = 129;
            this.label277.Text = "CELL S1";
            // 
            // label278
            // 
            this.label278.AutoSize = true;
            this.label278.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label278.ForeColor = System.Drawing.Color.Purple;
            this.label278.Location = new System.Drawing.Point(351, 10);
            this.label278.Name = "label278";
            this.label278.Size = new System.Drawing.Size(199, 31);
            this.label278.TabIndex = 145;
            this.label278.Text = "Today Output ";
            // 
            // groupBox37
            // 
            this.groupBox37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox37.Controls.Add(this.lblbalance15);
            this.groupBox37.Controls.Add(this.lblactual15);
            this.groupBox37.Controls.Add(this.lbltarget15);
            this.groupBox37.Controls.Add(this.label254);
            this.groupBox37.Controls.Add(this.label255);
            this.groupBox37.Controls.Add(this.label256);
            this.groupBox37.Controls.Add(this.label257);
            this.groupBox37.Controls.Add(this.lblPO15);
            this.groupBox37.Controls.Add(this.label259);
            this.groupBox37.Controls.Add(this.lbltotaltarget15);
            this.groupBox37.Controls.Add(this.label261);
            this.groupBox37.Controls.Add(this.lbltotal15);
            this.groupBox37.Controls.Add(this.label263);
            this.groupBox37.Controls.Add(this.label264);
            this.groupBox37.Location = new System.Drawing.Point(634, 245);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(556, 220);
            this.groupBox37.TabIndex = 167;
            this.groupBox37.TabStop = false;
            // 
            // lblbalance15
            // 
            this.lblbalance15.BackColor = System.Drawing.Color.Black;
            this.lblbalance15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance15.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance15.Location = new System.Drawing.Point(407, 161);
            this.lblbalance15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance15.Name = "lblbalance15";
            this.lblbalance15.Size = new System.Drawing.Size(138, 50);
            this.lblbalance15.TabIndex = 164;
            this.lblbalance15.Text = "0";
            this.lblbalance15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual15
            // 
            this.lblactual15.BackColor = System.Drawing.Color.Black;
            this.lblactual15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual15.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual15.Location = new System.Drawing.Point(271, 161);
            this.lblactual15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual15.Name = "lblactual15";
            this.lblactual15.Size = new System.Drawing.Size(135, 50);
            this.lblactual15.TabIndex = 163;
            this.lblactual15.Text = "0";
            this.lblactual15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget15
            // 
            this.lbltarget15.BackColor = System.Drawing.Color.Black;
            this.lbltarget15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget15.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget15.Location = new System.Drawing.Point(134, 161);
            this.lbltarget15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget15.Name = "lbltarget15";
            this.lbltarget15.Size = new System.Drawing.Size(136, 50);
            this.lbltarget15.TabIndex = 162;
            this.lbltarget15.Text = "0";
            this.lbltarget15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label254.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label254.Location = new System.Drawing.Point(24, 173);
            this.label254.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(103, 33);
            this.label254.TabIndex = 161;
            this.label254.Text = "TOTAL";
            // 
            // label255
            // 
            this.label255.BackColor = System.Drawing.Color.Green;
            this.label255.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label255.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label255.ForeColor = System.Drawing.Color.Tomato;
            this.label255.Location = new System.Drawing.Point(407, 125);
            this.label255.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(138, 36);
            this.label255.TabIndex = 160;
            this.label255.Text = "Balance";
            this.label255.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label256
            // 
            this.label256.BackColor = System.Drawing.Color.Green;
            this.label256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label256.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label256.ForeColor = System.Drawing.Color.Tomato;
            this.label256.Location = new System.Drawing.Point(271, 125);
            this.label256.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(135, 36);
            this.label256.TabIndex = 159;
            this.label256.Text = "Actual";
            this.label256.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label257
            // 
            this.label257.BackColor = System.Drawing.Color.Green;
            this.label257.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label257.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label257.ForeColor = System.Drawing.Color.Tomato;
            this.label257.Location = new System.Drawing.Point(134, 125);
            this.label257.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label257.Name = "label257";
            this.label257.Size = new System.Drawing.Size(136, 36);
            this.label257.TabIndex = 158;
            this.label257.Text = "Batch";
            this.label257.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO15
            // 
            this.lblPO15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO15.ForeColor = System.Drawing.Color.Blue;
            this.lblPO15.Location = new System.Drawing.Point(175, 88);
            this.lblPO15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO15.Name = "lblPO15";
            this.lblPO15.Size = new System.Drawing.Size(355, 35);
            this.lblPO15.TabIndex = 157;
            // 
            // label259
            // 
            this.label259.AutoSize = true;
            this.label259.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label259.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label259.Location = new System.Drawing.Point(33, 87);
            this.label259.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(134, 24);
            this.label259.TabIndex = 157;
            this.label259.Text = "CELL 15 PO#";
            // 
            // lbltotaltarget15
            // 
            this.lbltotaltarget15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget15.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget15.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget15.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget15.Name = "lbltotaltarget15";
            this.lbltotaltarget15.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget15.TabIndex = 155;
            this.lbltotaltarget15.Text = "0";
            this.lbltotaltarget15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label261
            // 
            this.label261.AutoSize = true;
            this.label261.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label261.ForeColor = System.Drawing.Color.Purple;
            this.label261.Location = new System.Drawing.Point(163, 11);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(188, 31);
            this.label261.TabIndex = 155;
            this.label261.Text = "Today Target";
            // 
            // lbltotal15
            // 
            this.lbltotal15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal15.BackColor = System.Drawing.Color.Black;
            this.lbltotal15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal15.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal15.Location = new System.Drawing.Point(386, 41);
            this.lbltotal15.Name = "lbltotal15";
            this.lbltotal15.Size = new System.Drawing.Size(143, 43);
            this.lbltotal15.TabIndex = 144;
            this.lbltotal15.Text = "0";
            this.lbltotal15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label263
            // 
            this.label263.AutoSize = true;
            this.label263.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label263.ForeColor = System.Drawing.Color.Blue;
            this.label263.Location = new System.Drawing.Point(7, 11);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(122, 33);
            this.label263.TabIndex = 129;
            this.label263.Text = "CELL 15";
            // 
            // label264
            // 
            this.label264.AutoSize = true;
            this.label264.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label264.ForeColor = System.Drawing.Color.Purple;
            this.label264.Location = new System.Drawing.Point(351, 10);
            this.label264.Name = "label264";
            this.label264.Size = new System.Drawing.Size(199, 31);
            this.label264.TabIndex = 145;
            this.label264.Text = "Today Output ";
            // 
            // groupBox36
            // 
            this.groupBox36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox36.Controls.Add(this.lblbalance14);
            this.groupBox36.Controls.Add(this.lblactual14);
            this.groupBox36.Controls.Add(this.lbltarget14);
            this.groupBox36.Controls.Add(this.label228);
            this.groupBox36.Controls.Add(this.label230);
            this.groupBox36.Controls.Add(this.label232);
            this.groupBox36.Controls.Add(this.label235);
            this.groupBox36.Controls.Add(this.lblPO14);
            this.groupBox36.Controls.Add(this.label237);
            this.groupBox36.Controls.Add(this.lbltotaltarget14);
            this.groupBox36.Controls.Add(this.label244);
            this.groupBox36.Controls.Add(this.lbltotal14);
            this.groupBox36.Controls.Add(this.label249);
            this.groupBox36.Controls.Add(this.label250);
            this.groupBox36.Location = new System.Drawing.Point(634, 13);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(556, 220);
            this.groupBox36.TabIndex = 166;
            this.groupBox36.TabStop = false;
            // 
            // lblbalance14
            // 
            this.lblbalance14.BackColor = System.Drawing.Color.Black;
            this.lblbalance14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance14.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance14.Location = new System.Drawing.Point(407, 161);
            this.lblbalance14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance14.Name = "lblbalance14";
            this.lblbalance14.Size = new System.Drawing.Size(138, 50);
            this.lblbalance14.TabIndex = 164;
            this.lblbalance14.Text = "0";
            this.lblbalance14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual14
            // 
            this.lblactual14.BackColor = System.Drawing.Color.Black;
            this.lblactual14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual14.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual14.Location = new System.Drawing.Point(271, 161);
            this.lblactual14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual14.Name = "lblactual14";
            this.lblactual14.Size = new System.Drawing.Size(135, 50);
            this.lblactual14.TabIndex = 163;
            this.lblactual14.Text = "0";
            this.lblactual14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget14
            // 
            this.lbltarget14.BackColor = System.Drawing.Color.Black;
            this.lbltarget14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget14.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget14.Location = new System.Drawing.Point(134, 161);
            this.lbltarget14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget14.Name = "lbltarget14";
            this.lbltarget14.Size = new System.Drawing.Size(136, 50);
            this.lbltarget14.TabIndex = 162;
            this.lbltarget14.Text = "0";
            this.lbltarget14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label228.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label228.Location = new System.Drawing.Point(24, 173);
            this.label228.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(103, 33);
            this.label228.TabIndex = 161;
            this.label228.Text = "TOTAL";
            // 
            // label230
            // 
            this.label230.BackColor = System.Drawing.Color.Green;
            this.label230.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label230.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label230.ForeColor = System.Drawing.Color.Tomato;
            this.label230.Location = new System.Drawing.Point(407, 125);
            this.label230.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(138, 36);
            this.label230.TabIndex = 160;
            this.label230.Text = "Balance";
            this.label230.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label232
            // 
            this.label232.BackColor = System.Drawing.Color.Green;
            this.label232.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label232.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label232.ForeColor = System.Drawing.Color.Tomato;
            this.label232.Location = new System.Drawing.Point(271, 125);
            this.label232.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(135, 36);
            this.label232.TabIndex = 159;
            this.label232.Text = "Actual";
            this.label232.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label235
            // 
            this.label235.BackColor = System.Drawing.Color.Green;
            this.label235.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label235.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label235.ForeColor = System.Drawing.Color.Tomato;
            this.label235.Location = new System.Drawing.Point(134, 125);
            this.label235.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(136, 36);
            this.label235.TabIndex = 158;
            this.label235.Text = "Batch";
            this.label235.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO14
            // 
            this.lblPO14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO14.ForeColor = System.Drawing.Color.Blue;
            this.lblPO14.Location = new System.Drawing.Point(175, 88);
            this.lblPO14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO14.Name = "lblPO14";
            this.lblPO14.Size = new System.Drawing.Size(355, 35);
            this.lblPO14.TabIndex = 157;
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label237.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label237.Location = new System.Drawing.Point(33, 87);
            this.label237.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(134, 24);
            this.label237.TabIndex = 157;
            this.label237.Text = "CELL 14 PO#";
            // 
            // lbltotaltarget14
            // 
            this.lbltotaltarget14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget14.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget14.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget14.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget14.Name = "lbltotaltarget14";
            this.lbltotaltarget14.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget14.TabIndex = 155;
            this.lbltotaltarget14.Text = "0";
            this.lbltotaltarget14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label244.ForeColor = System.Drawing.Color.Purple;
            this.label244.Location = new System.Drawing.Point(163, 11);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(188, 31);
            this.label244.TabIndex = 155;
            this.label244.Text = "Today Target";
            // 
            // lbltotal14
            // 
            this.lbltotal14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal14.BackColor = System.Drawing.Color.Black;
            this.lbltotal14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal14.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal14.Location = new System.Drawing.Point(386, 41);
            this.lbltotal14.Name = "lbltotal14";
            this.lbltotal14.Size = new System.Drawing.Size(143, 43);
            this.lbltotal14.TabIndex = 144;
            this.lbltotal14.Text = "0";
            this.lbltotal14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label249.ForeColor = System.Drawing.Color.Blue;
            this.label249.Location = new System.Drawing.Point(7, 11);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(122, 33);
            this.label249.TabIndex = 129;
            this.label249.Text = "CELL 14";
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label250.ForeColor = System.Drawing.Color.Purple;
            this.label250.Location = new System.Drawing.Point(351, 10);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(199, 31);
            this.label250.TabIndex = 145;
            this.label250.Text = "Today Output ";
            // 
            // groupBox35
            // 
            this.groupBox35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox35.Controls.Add(this.lblbalance13);
            this.groupBox35.Controls.Add(this.lblactual133);
            this.groupBox35.Controls.Add(this.lbltarget13);
            this.groupBox35.Controls.Add(this.label238);
            this.groupBox35.Controls.Add(this.label239);
            this.groupBox35.Controls.Add(this.label240);
            this.groupBox35.Controls.Add(this.label241);
            this.groupBox35.Controls.Add(this.lblPO13);
            this.groupBox35.Controls.Add(this.label243);
            this.groupBox35.Controls.Add(this.lbltotaltarget13);
            this.groupBox35.Controls.Add(this.label245);
            this.groupBox35.Controls.Add(this.lbltotal13);
            this.groupBox35.Controls.Add(this.label247);
            this.groupBox35.Controls.Add(this.label248);
            this.groupBox35.Location = new System.Drawing.Point(13, 476);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(556, 220);
            this.groupBox35.TabIndex = 165;
            this.groupBox35.TabStop = false;
            // 
            // lblbalance13
            // 
            this.lblbalance13.BackColor = System.Drawing.Color.Black;
            this.lblbalance13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance13.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance13.Location = new System.Drawing.Point(407, 161);
            this.lblbalance13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance13.Name = "lblbalance13";
            this.lblbalance13.Size = new System.Drawing.Size(138, 50);
            this.lblbalance13.TabIndex = 164;
            this.lblbalance13.Text = "0";
            this.lblbalance13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual133
            // 
            this.lblactual133.BackColor = System.Drawing.Color.Black;
            this.lblactual133.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual133.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual133.Location = new System.Drawing.Point(271, 161);
            this.lblactual133.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual133.Name = "lblactual133";
            this.lblactual133.Size = new System.Drawing.Size(135, 50);
            this.lblactual133.TabIndex = 163;
            this.lblactual133.Text = "0";
            this.lblactual133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblactual133.Click += new System.EventHandler(this.label236_Click);
            // 
            // lbltarget13
            // 
            this.lbltarget13.BackColor = System.Drawing.Color.Black;
            this.lbltarget13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget13.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget13.Location = new System.Drawing.Point(134, 161);
            this.lbltarget13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget13.Name = "lbltarget13";
            this.lbltarget13.Size = new System.Drawing.Size(136, 50);
            this.lbltarget13.TabIndex = 162;
            this.lbltarget13.Text = "0";
            this.lbltarget13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label238.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label238.Location = new System.Drawing.Point(24, 173);
            this.label238.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(103, 33);
            this.label238.TabIndex = 161;
            this.label238.Text = "TOTAL";
            // 
            // label239
            // 
            this.label239.BackColor = System.Drawing.Color.Green;
            this.label239.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label239.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label239.ForeColor = System.Drawing.Color.Tomato;
            this.label239.Location = new System.Drawing.Point(407, 125);
            this.label239.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(138, 36);
            this.label239.TabIndex = 160;
            this.label239.Text = "Balance";
            this.label239.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label240
            // 
            this.label240.BackColor = System.Drawing.Color.Green;
            this.label240.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label240.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label240.ForeColor = System.Drawing.Color.Tomato;
            this.label240.Location = new System.Drawing.Point(271, 125);
            this.label240.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(135, 36);
            this.label240.TabIndex = 159;
            this.label240.Text = "Actual";
            this.label240.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label241
            // 
            this.label241.BackColor = System.Drawing.Color.Green;
            this.label241.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label241.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label241.ForeColor = System.Drawing.Color.Tomato;
            this.label241.Location = new System.Drawing.Point(134, 125);
            this.label241.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(136, 36);
            this.label241.TabIndex = 158;
            this.label241.Text = "Batch";
            this.label241.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO13
            // 
            this.lblPO13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO13.ForeColor = System.Drawing.Color.Blue;
            this.lblPO13.Location = new System.Drawing.Point(175, 88);
            this.lblPO13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO13.Name = "lblPO13";
            this.lblPO13.Size = new System.Drawing.Size(355, 35);
            this.lblPO13.TabIndex = 157;
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label243.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label243.Location = new System.Drawing.Point(33, 87);
            this.label243.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(134, 24);
            this.label243.TabIndex = 157;
            this.label243.Text = "CELL 13 PO#";
            // 
            // lbltotaltarget13
            // 
            this.lbltotaltarget13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget13.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget13.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget13.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget13.Name = "lbltotaltarget13";
            this.lbltotaltarget13.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget13.TabIndex = 155;
            this.lbltotaltarget13.Text = "0";
            this.lbltotaltarget13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label245.ForeColor = System.Drawing.Color.Purple;
            this.label245.Location = new System.Drawing.Point(163, 11);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(188, 31);
            this.label245.TabIndex = 155;
            this.label245.Text = "Today Target";
            // 
            // lbltotal13
            // 
            this.lbltotal13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal13.BackColor = System.Drawing.Color.Black;
            this.lbltotal13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal13.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal13.Location = new System.Drawing.Point(386, 41);
            this.lbltotal13.Name = "lbltotal13";
            this.lbltotal13.Size = new System.Drawing.Size(143, 43);
            this.lbltotal13.TabIndex = 144;
            this.lbltotal13.Text = "0";
            this.lbltotal13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label247.ForeColor = System.Drawing.Color.Blue;
            this.label247.Location = new System.Drawing.Point(7, 11);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(122, 33);
            this.label247.TabIndex = 129;
            this.label247.Text = "CELL 13";
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label248.ForeColor = System.Drawing.Color.Purple;
            this.label248.Location = new System.Drawing.Point(351, 10);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(199, 31);
            this.label248.TabIndex = 145;
            this.label248.Text = "Today Output ";
            // 
            // groupBox34
            // 
            this.groupBox34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox34.Controls.Add(this.lblbalance12);
            this.groupBox34.Controls.Add(this.lblactual12);
            this.groupBox34.Controls.Add(this.lbltarget12);
            this.groupBox34.Controls.Add(this.label157);
            this.groupBox34.Controls.Add(this.label221);
            this.groupBox34.Controls.Add(this.label223);
            this.groupBox34.Controls.Add(this.label225);
            this.groupBox34.Controls.Add(this.lblPO12);
            this.groupBox34.Controls.Add(this.label229);
            this.groupBox34.Controls.Add(this.lbltotaltarget12);
            this.groupBox34.Controls.Add(this.label231);
            this.groupBox34.Controls.Add(this.lbltotal12);
            this.groupBox34.Controls.Add(this.label233);
            this.groupBox34.Controls.Add(this.label234);
            this.groupBox34.Location = new System.Drawing.Point(13, 245);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(556, 220);
            this.groupBox34.TabIndex = 164;
            this.groupBox34.TabStop = false;
            // 
            // lblbalance12
            // 
            this.lblbalance12.BackColor = System.Drawing.Color.Black;
            this.lblbalance12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance12.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance12.Location = new System.Drawing.Point(407, 161);
            this.lblbalance12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance12.Name = "lblbalance12";
            this.lblbalance12.Size = new System.Drawing.Size(138, 50);
            this.lblbalance12.TabIndex = 164;
            this.lblbalance12.Text = "0";
            this.lblbalance12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual12
            // 
            this.lblactual12.BackColor = System.Drawing.Color.Black;
            this.lblactual12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual12.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual12.Location = new System.Drawing.Point(271, 161);
            this.lblactual12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual12.Name = "lblactual12";
            this.lblactual12.Size = new System.Drawing.Size(135, 50);
            this.lblactual12.TabIndex = 163;
            this.lblactual12.Text = "0";
            this.lblactual12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget12
            // 
            this.lbltarget12.BackColor = System.Drawing.Color.Black;
            this.lbltarget12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget12.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget12.Location = new System.Drawing.Point(134, 161);
            this.lbltarget12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget12.Name = "lbltarget12";
            this.lbltarget12.Size = new System.Drawing.Size(136, 50);
            this.lbltarget12.TabIndex = 162;
            this.lbltarget12.Text = "0";
            this.lbltarget12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label157.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label157.Location = new System.Drawing.Point(24, 173);
            this.label157.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(103, 33);
            this.label157.TabIndex = 161;
            this.label157.Text = "TOTAL";
            // 
            // label221
            // 
            this.label221.BackColor = System.Drawing.Color.Green;
            this.label221.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label221.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label221.ForeColor = System.Drawing.Color.Tomato;
            this.label221.Location = new System.Drawing.Point(407, 125);
            this.label221.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(138, 36);
            this.label221.TabIndex = 160;
            this.label221.Text = "Balance";
            this.label221.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label223
            // 
            this.label223.BackColor = System.Drawing.Color.Green;
            this.label223.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label223.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label223.ForeColor = System.Drawing.Color.Tomato;
            this.label223.Location = new System.Drawing.Point(271, 125);
            this.label223.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(135, 36);
            this.label223.TabIndex = 159;
            this.label223.Text = "Actual";
            this.label223.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label225
            // 
            this.label225.BackColor = System.Drawing.Color.Green;
            this.label225.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label225.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label225.ForeColor = System.Drawing.Color.Tomato;
            this.label225.Location = new System.Drawing.Point(134, 125);
            this.label225.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(136, 36);
            this.label225.TabIndex = 158;
            this.label225.Text = "Batch";
            this.label225.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO12
            // 
            this.lblPO12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO12.ForeColor = System.Drawing.Color.Blue;
            this.lblPO12.Location = new System.Drawing.Point(175, 88);
            this.lblPO12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO12.Name = "lblPO12";
            this.lblPO12.Size = new System.Drawing.Size(355, 35);
            this.lblPO12.TabIndex = 157;
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label229.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label229.Location = new System.Drawing.Point(33, 87);
            this.label229.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(134, 24);
            this.label229.TabIndex = 157;
            this.label229.Text = "CELL 12 PO#";
            // 
            // lbltotaltarget12
            // 
            this.lbltotaltarget12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget12.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget12.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget12.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget12.Name = "lbltotaltarget12";
            this.lbltotaltarget12.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget12.TabIndex = 155;
            this.lbltotaltarget12.Text = "0";
            this.lbltotaltarget12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label231.ForeColor = System.Drawing.Color.Purple;
            this.label231.Location = new System.Drawing.Point(163, 11);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(188, 31);
            this.label231.TabIndex = 155;
            this.label231.Text = "Today Target";
            // 
            // lbltotal12
            // 
            this.lbltotal12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotal12.BackColor = System.Drawing.Color.Black;
            this.lbltotal12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal12.ForeColor = System.Drawing.Color.Lime;
            this.lbltotal12.Location = new System.Drawing.Point(386, 41);
            this.lbltotal12.Name = "lbltotal12";
            this.lbltotal12.Size = new System.Drawing.Size(143, 43);
            this.lbltotal12.TabIndex = 144;
            this.lbltotal12.Text = "0";
            this.lbltotal12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label233.ForeColor = System.Drawing.Color.Blue;
            this.label233.Location = new System.Drawing.Point(7, 11);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(122, 33);
            this.label233.TabIndex = 129;
            this.label233.Text = "CELL 12";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label234.ForeColor = System.Drawing.Color.Purple;
            this.label234.Location = new System.Drawing.Point(351, 10);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(199, 31);
            this.label234.TabIndex = 145;
            this.label234.Text = "Today Output ";
            // 
            // groupBox26
            // 
            this.groupBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox26.Controls.Add(this.lblbalance11);
            this.groupBox26.Controls.Add(this.lblactual11);
            this.groupBox26.Controls.Add(this.lbltarget11);
            this.groupBox26.Controls.Add(this.label127);
            this.groupBox26.Controls.Add(this.label138);
            this.groupBox26.Controls.Add(this.label142);
            this.groupBox26.Controls.Add(this.label143);
            this.groupBox26.Controls.Add(this.lblPO11);
            this.groupBox26.Controls.Add(this.label148);
            this.groupBox26.Controls.Add(this.lbltotaltarget11);
            this.groupBox26.Controls.Add(this.label153);
            this.groupBox26.Controls.Add(this.lblsofa11);
            this.groupBox26.Controls.Add(this.label162);
            this.groupBox26.Controls.Add(this.label163);
            this.groupBox26.Location = new System.Drawing.Point(13, 13);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(556, 220);
            this.groupBox26.TabIndex = 163;
            this.groupBox26.TabStop = false;
            // 
            // lblbalance11
            // 
            this.lblbalance11.BackColor = System.Drawing.Color.Black;
            this.lblbalance11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblbalance11.ForeColor = System.Drawing.Color.Yellow;
            this.lblbalance11.Location = new System.Drawing.Point(407, 161);
            this.lblbalance11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbalance11.Name = "lblbalance11";
            this.lblbalance11.Size = new System.Drawing.Size(138, 50);
            this.lblbalance11.TabIndex = 164;
            this.lblbalance11.Text = "0";
            this.lblbalance11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblactual11
            // 
            this.lblactual11.BackColor = System.Drawing.Color.Black;
            this.lblactual11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblactual11.ForeColor = System.Drawing.Color.Yellow;
            this.lblactual11.Location = new System.Drawing.Point(271, 161);
            this.lblactual11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactual11.Name = "lblactual11";
            this.lblactual11.Size = new System.Drawing.Size(135, 50);
            this.lblactual11.TabIndex = 163;
            this.lblactual11.Text = "0";
            this.lblactual11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltarget11
            // 
            this.lbltarget11.BackColor = System.Drawing.Color.Black;
            this.lbltarget11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltarget11.ForeColor = System.Drawing.Color.Yellow;
            this.lbltarget11.Location = new System.Drawing.Point(134, 161);
            this.lbltarget11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltarget11.Name = "lbltarget11";
            this.lbltarget11.Size = new System.Drawing.Size(136, 50);
            this.lbltarget11.TabIndex = 162;
            this.lbltarget11.Text = "0";
            this.lbltarget11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label127.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label127.Location = new System.Drawing.Point(24, 173);
            this.label127.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(103, 33);
            this.label127.TabIndex = 161;
            this.label127.Text = "TOTAL";
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.Green;
            this.label138.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label138.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label138.ForeColor = System.Drawing.Color.Tomato;
            this.label138.Location = new System.Drawing.Point(407, 125);
            this.label138.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(138, 36);
            this.label138.TabIndex = 160;
            this.label138.Text = "Balance";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.Green;
            this.label142.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label142.ForeColor = System.Drawing.Color.Tomato;
            this.label142.Location = new System.Drawing.Point(271, 125);
            this.label142.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(135, 36);
            this.label142.TabIndex = 159;
            this.label142.Text = "Actual";
            this.label142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Green;
            this.label143.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label143.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label143.ForeColor = System.Drawing.Color.Tomato;
            this.label143.Location = new System.Drawing.Point(134, 125);
            this.label143.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(136, 36);
            this.label143.TabIndex = 158;
            this.label143.Text = "Batch";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPO11
            // 
            this.lblPO11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPO11.ForeColor = System.Drawing.Color.Blue;
            this.lblPO11.Location = new System.Drawing.Point(175, 88);
            this.lblPO11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO11.Name = "lblPO11";
            this.lblPO11.Size = new System.Drawing.Size(355, 35);
            this.lblPO11.TabIndex = 157;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label148.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label148.Location = new System.Drawing.Point(33, 87);
            this.label148.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(134, 24);
            this.label148.TabIndex = 157;
            this.label148.Text = "CELL 11 PO#";
            // 
            // lbltotaltarget11
            // 
            this.lbltotaltarget11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotaltarget11.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget11.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget11.Location = new System.Drawing.Point(191, 42);
            this.lbltotaltarget11.Name = "lbltotaltarget11";
            this.lbltotaltarget11.Size = new System.Drawing.Size(148, 43);
            this.lbltotaltarget11.TabIndex = 155;
            this.lbltotaltarget11.Text = "0";
            this.lbltotaltarget11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label153.ForeColor = System.Drawing.Color.Purple;
            this.label153.Location = new System.Drawing.Point(163, 11);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(188, 31);
            this.label153.TabIndex = 155;
            this.label153.Text = "Today Target";
            // 
            // lblsofa11
            // 
            this.lblsofa11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsofa11.BackColor = System.Drawing.Color.Black;
            this.lblsofa11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblsofa11.ForeColor = System.Drawing.Color.Lime;
            this.lblsofa11.Location = new System.Drawing.Point(386, 41);
            this.lblsofa11.Name = "lblsofa11";
            this.lblsofa11.Size = new System.Drawing.Size(143, 43);
            this.lblsofa11.TabIndex = 144;
            this.lblsofa11.Text = "0";
            this.lblsofa11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Font = new System.Drawing.Font("Tahoma", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label162.ForeColor = System.Drawing.Color.Blue;
            this.label162.Location = new System.Drawing.Point(7, 11);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(122, 33);
            this.label162.TabIndex = 129;
            this.label162.Text = "CELL 11";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label163.ForeColor = System.Drawing.Color.Purple;
            this.label163.Location = new System.Drawing.Point(351, 10);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(199, 31);
            this.label163.TabIndex = 145;
            this.label163.Text = "Today Output ";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // FullCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1335, 743);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullCell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FullCell";
            this.Load += new System.EventHandler(this.FullCell_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.lblactual13.ResumeLayout(false);
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region "time"
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
           // this.lbltime1.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

            //Cell0
            CallPO();
            CallLoad();
            CallTargettotal();
            CallLoadToday();
            //Cell1
            CallPO1();
            CallLoad1();
            CallTargettotal1();
            CallLoadToday1();
            //Cell2
            CallPO2();
            CallLoad2();
            CallTargettotal2();
            CallLoadToday2();

            //Cell3
            CallPO3();
            CallLoad3();
            CallTargettotal3();
            CallLoadToday3();



            //Cell4
            CallPO4();
            CallLoad4();
            CallTargettotal4();
            CallLoadToday4();

            //Cell5
            CallPO5();
            CallLoad5();
            CallTargettotal5();
            CallLoadToday5();

            //Cell6
            CallPO6();
            CallLoad6();
            CallTargettotal6();
            CallLoadToday6();

            //Cell7
            CallPO7();
            CallLoad7();
            CallTargettotal7();
            CallLoadToday7();

            //Cell8
            CallPO8();
            CallLoad8();
            CallTargettotal8();
            CallLoadToday8();

            //Cell9
            CallPO9();
            CallLoad9();
            CallTargettotal9();
            CallLoadToday9();

            //Cell10
            CallPO10();
            CallLoad10();
            CallTargettotal10();
            CallLoadToday10();


            //Cell11
            CallPO11();
            CallLoad11();
            CallTargettotal11();
            CallLoadToday11();

            //CellT2
            CallPOT2();
            CallLoadT2();
            CallTargettotalT2();
            CallLoadTodayT2();

            //Cell12
            CallPO12();
            CallLoad12();
            CallTargettotal12();
            CallLoadToday12();

            //Cell13
            CallPO13();
            CallLoad13();
            CallTargettotal13();
            CallLoadToday13();

            //Cell14
            CallPO14();
            CallLoad14();
            CallTargettotal14();
            CallLoadToday14();

            //Cell15
            CallPO15();
            CallLoad15();
            CallTargettotal15();
            CallLoadToday15();

            //CellS1
            CallPOS1();
            CallLoadS1();
            CallTargettotalS1();
            CallLoadTodayS1();




            CallWeek();

            // line Production
            lblLine1.Text = "0";
            lblLine1M.Text = "0";
            lblLine2.Text = "0";
            lblLine2M.Text = "0";
            //SumQtyLine1();
            //SumQtyLine2();
     


            //line Product
            CallSearchDate();
            Callsum11(); //sum line
            Callsumsofa(); //sum sofa
            Callsumchari(); // sum chari

            CallCalulateSumTotal();

            // sum total time
            double mon = 0;
            double tue = 0;
            double web = 0;
            double tud = 0;
            double fri = 0 ;
            double sat = 0;
            double totalwk = 0;
         
            if (lblMonM.Text != "-")
            {
                mon = Convert.ToDouble(lblMonM.Text);
            }
            if (lblTueM.Text != "-")
            {
                tue = Convert.ToDouble(lblTueM.Text);
            }
            if (lblWebM.Text != "-")
            {
                web = Convert.ToDouble(lblWebM.Text);
            }
            if (lblThdM.Text != "-")
            {
                tud = Convert.ToDouble(lblThdM.Text);
            }
            if (lblFriM.Text != "-")
            {
                fri = Convert.ToDouble(lblFriM.Text);
            }
            if (lblSatM.Text != "-")
            {
                sat = Convert.ToDouble(lblSatM.Text);
            }
             totalwk = mon + tue + web + tud + fri + sat;
             lblwktotal.Text = totalwk.ToString("#,###");


          //string time
             Callstdtime("CELL");
             Callstdtime("CELL T2");
             Callstdtime("CELL 1");
             Callstdtime("CELL 2");
             Callstdtime("CELL 3");
             Callstdtime("CELL 4");
             Callstdtime("CELL 5");
             Callstdtime("CELL 6");
             Callstdtime("CELL 7");
             Callstdtime("CELL 8");
             Callstdtime("CELL 9");
             Callstdtime("CELL 10");
             Callstdtime("CELL 11");
             Callstdtime("CELL 12");
             Callstdtime("CELL 13");
             Callstdtime("CELL 14");
             Callstdtime("CELL 15");
             Callstdtime("CELL S1");

        }
        #endregion

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
        private void Callstdtime(string cell)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = " select Qty,Itemmodel,left(Itemmodel,8) as tmpmodel,(select  TotalTime from dbo.Stdtime where Style+Cover = LEFT(Itemmodel,3)+'-'+SUBSTRING(Itemmodel,4,5)) as total1  from dbo.DocMODtlBarcode  where TypeCell ='" + cell + "' and Sdate='" + tempdate + "'";

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
                 
                            n = n + i;
                            tmpstring = ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();
                  
                        }
                        else
                        {

                            if ((tmpCk == "80T") || (tmpCk == "04T") || (tmpCk == "30T") || (tmpCk == "35T") || (tmpCk == "65T") || (tmpCk == "T51") || (tmpCk == "P51") || (tmpCk == "T33") || (tmpCk == "P33") || (tmpCk == "T35") || (tmpCk == "P35") || (tmpCk == "T39") || (tmpCk == "P39"))
                            {
                                // ไม่คูณ seat คิดตัวต่อตัว
                                num = 1 * Convert.ToDouble(TotalTime);
                                sum = sum + num;
                            }
                            else if ((tmpCk == "61T") || (tmpCk == "63T") || (tmpCk == "82T") || (tmpCk == "32T") || (tmpCk == "6ST") || (tmpCk == "T32") || (tmpCk == "P32"))
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
                    min = sum / 60;
                    if (cell == "CELL")
                    { 
                        lblstd1.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd1.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd1.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 1")
                    { 
                        lblstd2.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd2.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd2.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 2")
                    {
                        lblstd3.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd3.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd3.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 3")
                    { 
                        lblstd4.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd4.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd4.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 4")
                    { 
                        lblstd5.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd5.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd5.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 5")
                    { 
                        lblstd6.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd6.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd6.BackColor = Color.Purple;
                        }
                    
                    }
                    else if (cell == "CELL 6")
                    {
                        lblstd7.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd7.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd7.BackColor = Color.Purple;
                        }
                    
                    }
                    else if (cell == "CELL 7")
                    {
                        lblstd8.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd8.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd8.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 8")
                    {
                        lblstd9.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd9.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd9.BackColor = Color.Purple;
                        }
                    
                    }
                    else if (cell == "CELL 9")
                    { 
                        lblstd10.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd10.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd10.BackColor = Color.Purple;
                        }
                    
                    }
                    else if (cell == "CELL 10")
                    {
                        lblstd11.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd11.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd11.BackColor = Color.Purple;
                        }
                    
                    }
                    else if (cell == "CELL 11")
                    {
                        lblstd12.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd12.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd12.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL T2")
                    {
                        lblstdT2.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstdT2.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstdT2.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 12")
                    {
                        lblstd122.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd122.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd122.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 13")
                    {
                        lblstd13.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd13.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd13.BackColor = Color.Purple;
                        }
                    }

                    else if (cell == "CELL 14")
                    {
                        lblstd14.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd14.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd14.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL 15")
                    {
                        lblstd15.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstd15.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstd15.BackColor = Color.Purple;
                        }
                    }
                    else if (cell == "CELL S1")
                    {
                        lblstdS1.Text = min.ToString("#####0");
                        if (n > 0)
                        {
                            lblstdS1.BackColor = Color.OrangeRed;
                            n = 0;
                        }
                        else
                        {
                            lblstdS1.BackColor = Color.Purple;
                        }
                    }

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

        #region "sumfofa"
        private void Callsumsofa()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select ISNULL(SUM(Qty), 0 ) as sumsofa from  dbo.DocMODtlBarcode where  Sdate='" + tempdate + "'   and Qty >1 ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    double sumsofa = Convert.ToDouble(rs["sumsofa"]);
                    label57.Text = sumsofa.ToString("#,###0");
                    label57M.Text = sumsofa.ToString("#,###0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }

        #endregion

        #region "sumchari"
        private void Callsumchari()
        {
            string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("select ISNULL(SUM(Qty), 0 )as sumChair  from  dbo.DocMODtlBarcode  where Sdate='" + tempdate + "'   and Qty = 1 ", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    double sumcell = Convert.ToDouble(rs["sumChair"]);
                    lblsum.Text = sumcell.ToString("#,###0");
                    lblsumM.Text = sumcell.ToString("#,###0");
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }

        #endregion

        #region :Callsum11()
        private void Callsum11()
        {
            //sum line
            double sumline = Convert.ToDouble(lblLine1.Text.Trim()) + Convert.ToDouble(lblLine2.Text.Trim());
            label60.Text = sumline.ToString("#,###0");
            //label60M.Text = sumline.ToString("#,###0");


            ////sum Sofa
            //double sumsofa = Convert.ToDouble(lblsofa4.Text) + Convert.ToDouble(lblsofa5.Text) + Convert.ToDouble(lblsofa11.Text);
            //label57.Text = sumsofa.ToString("#,###0");
            //label57M.Text = sumsofa.ToString("#,###0");

            //////sum Cell chair
            //double sumcell = Convert.ToDouble(lbltotal.Text) + Convert.ToDouble(lbltotal1.Text) + Convert.ToDouble(lbltotal2.Text) + Convert.ToDouble(lbltotal3.Text) + Convert.ToDouble(lblsofa6.Text) + Convert.ToDouble(lblsofa7.Text) + Convert.ToDouble(lblsofa8.Text) + Convert.ToDouble(lblsofa9.Text) + Convert.ToDouble(lblsofa10.Text);
            //lblsum.Text = sumcell.ToString("#,###0");
            //lblsumM.Text = sumcell.ToString("#,###0");
        
        }
        #endregion

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label108_Click(object sender, EventArgs e)
        {

        }

        private void label158_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            this.lbltime1.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void label236_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void lblSatM_Click(object sender, EventArgs e)
        {

        }

 

    }
}
