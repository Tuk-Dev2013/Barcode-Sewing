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
using System.Collections;

namespace PicklistBOM.MonitorCell
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string day = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", new System.Globalization.CultureInfo("en-US"));
            //this.lbldate11.Text = day;
            CallWeek();


            CallTargetAll(); // Cell Target
            CallTargettotal(); //Cell 0
            CallTargettotal1(); //Cell1
            CallTargettotal2(); //cell2
            CallTargettotal3(); //Cell3
            CallTargettotal4();
            CallTargettotal5();
            CallTargettotal6();
            CallTargettotal7();
            CallTargettotal8();
            CallTargettotal9();
            CallTargettotal10();
            CallTargettotal11();
            CallTargettotal12();
            CallTargettotal13();
            CallTargettotal14();
            CallTargettotal15();
            CallTargettotalS1();
            CallTargettotalT2();
            Callsumsofa();
            Callsumchari();

            //string time
            //Callstdtime("CELL");
            //Callstdtime("CELL T2");
            //Callstdtime("CELL 1");
            //Callstdtime("CELL 2");
            //Callstdtime("CELL 3");
            //Callstdtime("CELL 4");
            //Callstdtime("CELL 5");
            //Callstdtime("CELL 6");
            //Callstdtime("CELL 7");
            //Callstdtime("CELL 8");
            //Callstdtime("CELL 9");
            //Callstdtime("CELL 10");
            //Callstdtime("CELL 11");
            //Callstdtime("CELL 12");
            //Callstdtime("CELL 13");
            //Callstdtime("CELL 14");
            //Callstdtime("CELL 15");
            //Callstdtime("CELL S1");

            CellOutput();
            CallSearchWeek1();
        }

        #region "   CellOutput();"
        private void CellOutput()
        {
            double num = Convert.ToDouble(label57M.Text) + Convert.ToDouble(lblsumM.Text);
         lbltotalPM.Text = num.ToString("#,##0"); ;
        }

        #endregion

        #region " CallTargetAll()"
        private void CallTargetAll()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = " SELECT  TargetID, TargetOutput, Sdate ,Status  from dbo.DocMODtlTarget  "
                + " where  Sdate  ='"+resultdate +"' ";

                if (Isfind== true)
                {
                    ds.Tables["Showdata1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata1");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind = true;

                    for (int i = 0; i < ds.Tables["Showdata1"].Rows.Count; i++)
                    {
                        string Status = ds.Tables["Showdata1"].Rows[i]["Status"].ToString();
                        string TargetOutput = ds.Tables["Showdata1"].Rows[i]["TargetOutput"].ToString();
                        if (Status == "CELL")
                        { this.lbltotaltargetM.Text = TargetOutput; }
                        else if (Status == "CELL 1")
                        { lbltotaltarget1M.Text = TargetOutput; }
                        else if (Status == "CELL 2")
                        { lbltotaltarget2M.Text = TargetOutput; }
                        else if (Status == "CELL 3")
                        { lbltotaltarget3M.Text = TargetOutput; }
                        else if (Status == "CELL 4")
                        { lbltotaltarget4M.Text = TargetOutput; }
                        else if (Status == "CELL 5")
                        { lbltotaltarget5M.Text = TargetOutput; }
                        else if (Status == "CELL 6")
                        { lbltotaltarget6M.Text = TargetOutput; }
                        else if (Status == "CELL 7")
                        { lbltotaltarget7M.Text = TargetOutput; }
                        else if (Status == "CELL 8")
                        { lbltotaltarget8M.Text = TargetOutput; }
                        else if (Status == "CELL 9")
                        { lbltotaltarget9M.Text = TargetOutput; }
                        else if (Status == "CELL 10")
                        { lbltotaltarget10M.Text = TargetOutput; }
                        else if (Status == "CELL 11")
                        { lbltotaltarget11M.Text = TargetOutput; }
                        else if (Status == "CELL 12")
                        { lbltotaltarget12M.Text = TargetOutput; }
                        else if (Status == "CELL 13")
                        { lbltotaltarget13M.Text = TargetOutput; }
                        else if (Status == "CELL 14")
                        { lbltotaltarget14M.Text = TargetOutput; }
                        else if (Status == "CELL 15")
                        { lbltotaltarget15M.Text = TargetOutput; }
                        else if (Status == "CELL S1")
                        { lbltotaltargetS1M.Text = TargetOutput; }
                        else if (Status == "CELL T2")
                        { lbltotaltargetTM.Text = TargetOutput; }
                    }



                }
                else
                {
                    Isfind= false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();

        
        }
        #endregion

        private void CallSearchWeek1()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
           string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  * from Line_MonitorWeek "
              + " Where TagetDate='" + tmpdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    //CGlobal.DayweekTotal = rs["TotalOutput"].ToString();
                    lbltargetPM.Text = rs["TotalTarget"].ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

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
                   // lbltargetPM.Text = rs["TotalTarget"].ToString();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("No Data");
            }
            conn.Close();

        }

        #endregion

        #region "   CallWeek();"
        private void CallWeek()
        {
            lblSatM.BackColor = Color.DodgerBlue;
            lblMonM.BackColor = Color.DodgerBlue;
            lblTueM.BackColor = Color.DodgerBlue;
            lblWebM.BackColor = Color.DodgerBlue;
            lblThdM.BackColor = Color.DodgerBlue;
            lblFriM.BackColor = Color.DodgerBlue;

            DateTime dt = DateTime.Now; // "Sun, 09 Mar 2008 16:05:07 GMT"   RFC1123
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            string day = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
                this.lblSatM.BackColor = Color.Red;
                this.lblSatM.ForeColor = Color.GhostWhite;
                //วันเสาร์
                CallSearchWeek(day);
           // lblSat.Text = CGlobal.DayweekTotal;
                lblSatM.Text = CGlobal.DayweekTotal;
                //วันศุกร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotal;
                //วันพฤหสบดี
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
               // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
               // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันอังคาร
                string tmpD4 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD5 = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD5);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

            }
            else if (temday == "Mon")
            {
                this.lblMonM.BackColor = Color.Red;
                this.lblMonM.ForeColor = Color.GhostWhite;
                //วันจันทร์
                CallSearchWeek(day);
                //lblMon.Text = CGlobal.DayweekTotal;
                //lblTue.Text = "-";
                //lblWeb.Text = "-";
                //lblThd.Text = "-";
                //lblFri.Text = "-";
                //lblSat.Text = "-";

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
                //this.lblTueM.BackColor = Color.Red;
                //this.lblTue.ForeColor = Color.GhostWhite;

                this.lblTueM.BackColor = Color.Red;
                this.lblTueM.ForeColor = Color.GhostWhite;
                //วันอังคาร
                CallSearchWeek(day);
              //  lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //lblWeb.Text = "-";
                //lblThd.Text = "-";
                //lblFri.Text = "-";
                //lblSat.Text = "-";

                lblWebM.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }

            else if (temday == "Wed")
            {
                //this.lblWeb.BackColor = Color.Red;
                //this.lblWeb.ForeColor = Color.GhostWhite;
                this.lblWebM.BackColor = Color.Red;
                this.lblWebM.ForeColor = Color.GhostWhite;
                //วันพุธ
                CallSearchWeek(day);
               // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //lblThd.Text = "-";
                //lblFri.Text = "-";
                //lblSat.Text = "-";
                lblThdM.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";


            }
            else if (temday == "Thu")
            {
               // this.lblThd.BackColor = Color.Red;
               // this.lblThd.ForeColor = Color.GhostWhite;
                this.lblThdM.BackColor = Color.Red;
                this.lblThdM.ForeColor = Color.GhostWhite;
                //วันพฤ
                CallSearchWeek(day);
               // lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;
                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
              //  lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
              //  lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
               // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

               // lblFri.Text = "-";
               // lblSat.Text = "-";
                lblFriM.Text = "-";
                lblSatM.Text = "-";

            }
            else if (temday == "Fri")
            {
               // this.lblFri.BackColor = Color.Red;
               // this.lblFri.ForeColor = Color.GhostWhite;
                this.lblFriM.BackColor = Color.Red;
                this.lblFriM.ForeColor = Color.GhostWhite;
                //วันศุก
                CallSearchWeek(day);
             //   lblFri.Text = CGlobal.DayweekTotal;
                lblFriM.Text = CGlobal.DayweekTotal;

                //วันจันทร์
                string tmpD1 = DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD1);
               // lblMon.Text = CGlobal.DayweekTotal;
                lblMonM.Text = CGlobal.DayweekTotal;

                //วันอังคาร
                string tmpD2 = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD2);
               // lblTue.Text = CGlobal.DayweekTotal;
                lblTueM.Text = CGlobal.DayweekTotal;

                //วันพุธ
                string tmpD3 = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD3);
               // lblWeb.Text = CGlobal.DayweekTotal;
                lblWebM.Text = CGlobal.DayweekTotal;

                //วันพฤ
                string tmpD4 = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                CallSearchWeek(tmpD4);
              //  lblThd.Text = CGlobal.DayweekTotal;
                lblThdM.Text = CGlobal.DayweekTotal;

                lblSatM.Text = "-";

            }


        }

        #endregion
    
        //Cell0
        #region "CallTargettotal();"
        private void CallTargettotal()
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
        #region "CallTargettotal1();"
        private void CallTargettotal1()
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
        //cell2
        #region "CallTargettotal2();"
        private void CallTargettotal2()
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
        //cell3
        #region "CallTargettotal3();"
        private void CallTargettotal3()
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
       //cell4
        #region "CallTargettotal4();"
        private void CallTargettotal4()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 4' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

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
       //cell5
        #region "CallTargettotal5();"
        private void CallTargettotal5()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 5' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
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
      //cell6
        #region "CallTargettotal6();"
        private void CallTargettotal6()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 6' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
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
      //cell7
        #region "CallTargettotal7();"
        private void CallTargettotal7()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
       
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 7' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
        
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
      //cell8
        #region "CallTargettotal8();"
        private void CallTargettotal8()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 8' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {

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
        //cell9
        #region "CallTargettotal9();"
        private void CallTargettotal9()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
       
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 9' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
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
        //cell10
        #region "CallTargettotal10();"
        private void CallTargettotal10()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
            
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 10' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
           
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
        //cell11
        #region "CallTargettotal11();"
        private void CallTargettotal11()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
            
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 11' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
        
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
        //cell12
        #region "CallTargettotal12();"
        private void CallTargettotal12()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
            
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 12' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
   
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
        //cell13
        #region "CallTargettotal13();"
        private void CallTargettotal13()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 13' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
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
        //cell14
        #region "CallTargettotal14();"
        private void CallTargettotal14()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
  
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 14' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
  
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
        //cell15
        #region "CallTargettotal15();"
        private void CallTargettotal15()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
      
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL 15' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {

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
        //cellS1
        #region "CallTargettotalS1();"
        private void CallTargettotalS1()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
        
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL S1' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {

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
        //cellT2
        #region "CallTargettotalT2();"
        private void CallTargettotalT2()
        {

            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
   
                Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(Qty) As Total from dbo.DocMODtlBarcode Where Sdate='" + resultdate + "' and TypeCell='CELL T2' group by Sdate", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
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
                       // string tmpCk = Left(tmpmodel, 3);
                        if ((TotalTime == null) || (TotalTime == ""))
                        {
                            if (i == 0)
                            { n = 1; }
                            else
                            { n = n + i; }
                           
                            tmpstring = ds.Tables["showstdtime"].Rows[i]["tmpmodel"].ToString();

                        }
                        else
                        {
                                num = 1 * Convert.ToDouble(TotalTime);
                                sum = sum + num;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbldate11.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.lbltime1.Text = DateTime.Now.ToString("hh:mm:ss");
            CallWeek();


            CallTargetAll(); // Cell Target
            CallTargettotal(); //Cell 0
            CallTargettotal1(); //Cell1
            CallTargettotal2(); //cell2
            CallTargettotal3(); //Cell3
            CallTargettotal4();
            CallTargettotal5();
            CallTargettotal6();
            CallTargettotal7();
            CallTargettotal8();
            CallTargettotal9();
            CallTargettotal10();
            CallTargettotal11();
            CallTargettotal12();
            CallTargettotal13();
            CallTargettotal14();
            CallTargettotal15();
            CallTargettotalS1();
            CallTargettotalT2();
            Callsumsofa();
            Callsumchari();

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

            CellOutput();

            // sum total time
            double mon = 0;
            double tue = 0;
            double web = 0;
            double tud = 0;
            double fri = 0;
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

           Callday();
           CallSearchWeek1();

        }
        #region "Callday"
        private void Callday()
        {
            string temday = DateTime.Now.ToString("ddd", new System.Globalization.CultureInfo("en-US"));
            if (temday == "Sat")
            {
                lblSatM.Text = lbltotalPM.Text;
            }
            else if (temday == "Mon")
            {
                lblMonM.Text = lbltotalPM.Text;
            }
            else if (temday == "Tue")
            {
                lblTueM.Text = lbltotalPM.Text;
            }
            else if (temday == "Wed")
            {
                lblWebM.Text = lbltotalPM.Text;
            }
            else if (temday == "Thu")
            {
                lblThdM.Text = lbltotalPM.Text;
            }
            else if (temday == "Fri")
            {
                lblFriM.Text = lbltotalPM.Text;
            }

        }

        #endregion

    }
}
