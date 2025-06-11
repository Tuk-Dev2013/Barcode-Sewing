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

namespace PicklistBOM.ScheduleCell
{
    public partial class FrmShow2Bin : Form
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
        Boolean Isfind5 = false;
        Boolean Isfind6 = false;
        Boolean Isfind7 = false;
        Boolean Isfind8 = false;
        Boolean Isfind9 = false;
        Boolean Isfind10 = false;
        Boolean Isfind11= false;
        Boolean Isfind88 = false;
        Boolean Isfind99 = false;
        Boolean Isfind100 = false;
        Boolean Isfind20 = false;
        Boolean Isfind21 = false;
        Boolean Isfind22 = false;
        Boolean Isfind23 = false;
        Boolean Isfind24 = false;
        Boolean Isfind25 = false;
        Boolean Isfind26 = false;
        Boolean Isfind27= false;


        public FrmShow2Bin()
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

        private void FrmShow2Bin_Load(object sender, EventArgs e)
        {

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));
           // this.lblProduct.Text = ConfigurationManager.AppSettings["SHOW_Line"];
           // set0.Text=cen

            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));


            //   วิ่งหาข้อมูลแสดง
            CallSearchCellT();
            CallSearchCellT2();
            CallSearchCell1();
            CallSearchCell2();
            CallSearchCell3();
            CallSearchCell4();
            CallSearchCell5();
            CallSearchCell6();
            CallSearchCell7();
            //20/01/2015
            CallSearchCell8();
            CallSearchCell9();
            CallSearchCell10();
            CallSearchCell11();
            CallSearchCell12();
            CallSearchCell13();

            CallSearchCell14();
            CallSearchCell15();
            CallSearchCellS1();

            CallSet0("CELL");
            CallSet0("CELLT2");
            CallSet0("CELL1");
            CallSet0("CELL2");
            CallSet0("CELL3");
            CallSet0("CELL4");
            CallSet0("CELL5");
            CallSet0("CELL6");
            CallSet0("CELL7");
            //20/01/2015
            CallSet0("CELL8");
            CallSet0("CELL9");
            CallSet0("CELL10");
            CallSet0("CELL11");
            //05/01/2015
            CallSet0("CELL12");
            CallSet0("CELL13");
            CallSet0("CELL14");
            CallSet0("CELL15");
            CallSet0("CELLS1");

            CallOutput();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
           // this.lblhh.Text = DateTime.Now.ToString("hh"); ;

            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));


            //   วิ่งหาข้อมูลแสดง
            CallSearchCellT();
            CallSearchCellT2();
            CallSearchCell1();
            CallSearchCell2();
            CallSearchCell3();
            CallSearchCell4();
            CallSearchCell5();
            CallSearchCell6();
            CallSearchCell7();
            //20/01/2015
            CallSearchCell8();
            CallSearchCell9();
            CallSearchCell10();
            CallSearchCell11();
            CallSearchCell12();
            CallSearchCell13();

            CallSearchCell14();
            CallSearchCell15();
            CallSearchCellS1();

            CallSet0("CELL");
            CallSet0("CELLT2"); 
            CallSet0("CELL1");
            CallSet0("CELL2");
            CallSet0("CELL3");
            CallSet0("CELL4");
            CallSet0("CELL5");
            CallSet0("CELL6");
            CallSet0("CELL7");
            //20/01/2015
            CallSet0("CELL8");
            CallSet0("CELL9");
            CallSet0("CELL10");
            CallSet0("CELL11");
            //05/01/2015
            CallSet0("CELL12");
            CallSet0("CELL13");
            CallSet0("CELL14");
            CallSet0("CELL15");
            CallSet0("CELLS1");

            CallOutput();

        }

        #region "CallOutput"
        private void CallOutput()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {

                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TotalOutput,  TotalTarget  FROM   Line_MonitorWeek "
              + " Where TagetDate='" + tempdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    this.lbltarget.Text  = rs["TotalTarget"].ToString();
                    this.lbloutput.Text = rs["TotalOutput"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
         
       }
        #endregion

        #region "CallSet0()"
        private void CallSet0(String tmpcell)
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {

                string tempdate= DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select COUNT(itemcode) as counta from  dbo.Lean_Doc2Bin "
              + " Where CONVERT(VARCHAR(24),DocUserDate,103)='" + tempdate + "' and LineCell='" + tmpcell + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    if (tmpcell == "CELL")
                    {
                        Nset0.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELLT2")
                    {
                        Nsett2.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL1")
                    {
                        Nset1.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL2")
                    {
                        Nset2.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL3")
                    {
                        Nset3.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL4")
                    {
                        Nset4.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL5")
                    {
                        Nset5.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL6")
                    {
                        Nset6.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL7")
                    {
                        Nset7.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL8")
                    {
                        Nset8.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL9")
                    {
                        Nset9.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL10")
                    {
                        Nset10.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL11")
                    {
                        Nset11.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL12")
                    {
                        Nset12.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL13")
                    {
                        Nset13.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL14")
                    {
                        Nset14.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELL15")
                    {
                        Nset15.Text = rs["counta"].ToString();
                    }
                    else if (tmpcell == "CELLS1")
                    {
                        NsetS1.Text = rs["counta"].ToString();
                    }
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

        #region "  CallSearchCellT();"
        private void CallSearchCellT()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL TRAINING' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind1 == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showdata2"];
                    //  ShowCellT.DataSource = dt;

                    ct1.Text = "";
                    ct2.Text = "";
                    ct3.Text = "";


                    for (int i = 0; i < ds.Tables["Showdata2"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Showdata2"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Showdata2"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Showdata2"].Rows[0]["QtyOut"].ToString();
                        //  bntctbatch.Text = QtyIn;
                        //  bntctactual.Text = QtyOut;

                        if (i == 0)
                        {
                            ct1.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            ct2.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            ct3.Text = POnumber;
                        }



                    }

                }
                else
                {
                    Isfind1 = false;
                    ct1.Text = "";
                    ct2.Text = "";
                    ct3.Text = "";
                    //   this.ShowCellT.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();


        }
        #endregion

        #region "  CallSearchCellT2();"
        private void CallSearchCellT2()
        {
        
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL T2' and QtyIn<>QtyOut  order by ScheduleID";
                
                if (Isfind20 == true)
                {
                    ds.Tables["ShowdataT2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataT2");

                if (ds.Tables["ShowdataT2"].Rows.Count != 0)
                {
                    Isfind20 = true;
                    dt = ds.Tables["ShowdataT2"];
                    //  ShowCellT.DataSource = dt;

                    ct21.Text = "";
                    ct22.Text = "";
                    ct23.Text = "";
                    c16T4.Text = "";
                    c16T5.Text = "";
                    c16T6.Text = "";

                    for (int i = 0; i < ds.Tables["ShowdataT2"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["ShowdataT2"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["ShowdataT2"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["ShowdataT2"].Rows[0]["QtyOut"].ToString();
                        //  bntctbatch.Text = QtyIn;
                        //  bntctactual.Text = QtyOut;

                        if (i == 0)
                        {
                            ct21.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            ct22.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            ct23.Text = POnumber;
                        }
                        else if (i == 3)
                        {
                            c16T4.Text = POnumber;
                        }

                        else if (i == 4)
                        {
                            c16T5.Text = POnumber;
                        }

                        else if (i == 5)
                        {
                            c16T6.Text = POnumber;
                        }



                    }

                }
                else
                {
                    Isfind20 = false;
                    ct21.Text = "";
                    ct22.Text = "";
                    ct23.Text = "";
                    //   this.ShowCellT.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
          
          


        }
        #endregion


        #region "2    CallSearchCell1();"
        private void CallSearchCell1()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 1' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind2 == true)
                {
                    ds.Tables["Cell1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell1");

                if (ds.Tables["Cell1"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["Cell1"];
                    c11.Text = "";
                    c12.Text = "";
                    c13.Text = "";

                    for (int i = 0; i < ds.Tables["Cell1"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell1"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell1"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell1"].Rows[0]["QtyOut"].ToString();
                        // bntc11batch.Text = QtyIn;
                        // bntc12actual.Text = QtyOut;

                        if (i == 0)
                        {
                            c11.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c12.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c13.Text = POnumber;
                        }



                    }



                }
                else
                {
                    Isfind2 = false;
                    c11.Text = "";
                    c12.Text = "";
                    c13.Text = "";

                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 1");
            }
            conn.Close();


        }
        #endregion

        #region "   CallSearchCell2();"
        private void CallSearchCell2()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 2' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind == true)
                {
                    ds.Tables["Cell2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell2");

                if (ds.Tables["Cell2"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Cell2"];

                    c21.Text = "";
                    c22.Text = "";
                    c23.Text = "";
                    for (int i = 0; i < ds.Tables["Cell2"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell2"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell2"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell2"].Rows[0]["QtyOut"].ToString();
                        //  bntc21batch.Text = QtyIn;
                        //  bntc22actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c21.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c22.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c23.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind = false;

                    c21.Text = "";
                    c22.Text = "";
                    c23.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 2");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell3();"
        private void CallSearchCell3()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 3' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind5 == true)
                {
                    ds.Tables["Cell3"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell3");

                if (ds.Tables["Cell3"].Rows.Count != 0)
                {
                    Isfind5 = true;
                    dt = ds.Tables["Cell3"];

                    c31.Text = "";
                    c32.Text = "";
                    c33.Text = "";
                    for (int i = 0; i < ds.Tables["Cell3"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell3"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell3"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell3"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c31.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c32.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c33.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind5 = false;
                    c31.Text = "";
                    c32.Text = "";
                    c33.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 3");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell4();"
        private void CallSearchCell4()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 4' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind6 == true)
                {
                    ds.Tables["Cell4"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell4");

                if (ds.Tables["Cell4"].Rows.Count != 0)
                {
                    Isfind6 = true;
                    dt = ds.Tables["Cell4"];

                    c41.Text = "";
                    c42.Text = "";
                    c43.Text = "";
                    for (int i = 0; i < ds.Tables["Cell4"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell4"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell4"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell4"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c41.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c42.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c43.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind6 = false;
                    c41.Text = "";
                    c42.Text = "";
                    c43.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 4");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell5();"
        private void CallSearchCell5()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 5' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind7 == true)
                {
                    ds.Tables["Cell5"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell5");

                if (ds.Tables["Cell5"].Rows.Count != 0)
                {
                    Isfind7 = true;
                    dt = ds.Tables["Cell5"];

                    c51.Text = "";
                    c52.Text = "";
                    c53.Text = "";
                    for (int i = 0; i < ds.Tables["Cell5"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell5"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell5"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell5"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c51.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c52.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c53.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind7 = false;
                    c51.Text = "";
                    c52.Text = "";
                    c53.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 5");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell6();"
        private void CallSearchCell6()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 6' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind9 == true)
                {
                    ds.Tables["Cell6"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell6");

                if (ds.Tables["Cell6"].Rows.Count != 0)
                {
                    Isfind9 = true;
                    dt = ds.Tables["Cell6"];

                    c61.Text = "";
                    c62.Text = "";
                    c63.Text = "";
                    for (int i = 0; i < ds.Tables["Cell6"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell6"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell6"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell6"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c61.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c62.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c63.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind9 = false;
                    c61.Text = "";
                    c62.Text = "";
                    c63.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 6");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell7();"
        private void CallSearchCell7()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 7' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind10 == true)
                {
                    ds.Tables["Cell7"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell7");

                if (ds.Tables["Cell7"].Rows.Count != 0)
                {
                    Isfind10 = true;
                    dt = ds.Tables["Cell7"];

                    c71.Text = "";
                    c72.Text = "";
                    c73.Text = "";
                    for (int i = 0; i < ds.Tables["Cell7"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell7"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell7"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell7"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c71.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c72.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c73.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind10 = false;
                    c71.Text = "";
                    c72.Text = "";
                    c73.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 7");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell8();"
        private void CallSearchCell8()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 8' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind88 == true)
                {
                    ds.Tables["Cell8"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell8");

                if (ds.Tables["Cell8"].Rows.Count != 0)
                {
                    Isfind88= true;
                    dt = ds.Tables["Cell8"];

                    c81.Text = "";
                    c82.Text = "";
                    c83.Text = "";
                    for (int i = 0; i < ds.Tables["Cell8"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell8"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell8"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell8"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c81.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c82.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c83.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind88 = false;

                    c81.Text = "";
                    c82.Text = "";
                    c83.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 8");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell9();"
        private void CallSearchCell9()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 9' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind99 == true)
                {
                    ds.Tables["Cell9"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell9");

                if (ds.Tables["Cell9"].Rows.Count != 0)
                {
                    Isfind99 = true;
                    dt = ds.Tables["Cell9"];

                    c91.Text = "";
                    c92.Text = "";
                    c93.Text = "";
                    for (int i = 0; i < ds.Tables["Cell9"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell9"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell9"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell9"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c91.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c92.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c93.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind99 = false;

                    c91.Text = "";
                    c92.Text = "";
                    c93.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 9");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell10();"
        private void CallSearchCell10()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 10' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind100 == true)
                {
                    ds.Tables["Cell10"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell10");

                if (ds.Tables["Cell10"].Rows.Count != 0)
                {
                    Isfind100 = true;
                    dt = ds.Tables["Cell10"];

                    c101.Text = "";
                    c102.Text = "";
                    c103.Text = "";
                    for (int i = 0; i < ds.Tables["Cell10"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell10"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell10"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell10"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c101.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c102.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c103.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind100 = false;
                    c101.Text = "";
                    c102.Text = "";
                    c103.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 10");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell11();"
        private void CallSearchCell11()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 11' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind11 == true)
                {
                    ds.Tables["Cell11"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell11");

                if (ds.Tables["Cell11"].Rows.Count != 0)
                {
                    Isfind11= true;
                    dt = ds.Tables["Cell11"];

                    c111.Text = "";
                    c112.Text = "";
                    c113.Text = "";
                    for (int i = 0; i < ds.Tables["Cell11"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell11"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell11"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell11"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c111.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c112.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c113.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind11 = false;
                    c111.Text = "";
                    c112.Text = "";
                    c113.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 11");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell12();"
        private void CallSearchCell12()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 12' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind21 == true)
                {
                    ds.Tables["Cell12"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell12");

                if (ds.Tables["Cell12"].Rows.Count != 0)
                {
                    Isfind21 = true;
                    dt = ds.Tables["Cell12"];

                    c121.Text = "";
                    c122.Text = "";
                    c123.Text = "";
                    for (int i = 0; i < ds.Tables["Cell12"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell12"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell12"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell12"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c121.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c122.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c123.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind21 = false;
                    c121.Text = "";
                    c122.Text = "";
                    c123.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 12");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell13();"
        private void CallSearchCell13()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 13' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind22 == true)
                {
                    ds.Tables["Cell13"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell13");

                if (ds.Tables["Cell13"].Rows.Count != 0)
                {
                    Isfind22 = true;
                    dt = ds.Tables["Cell13"];

                    c131.Text = "";
                    c132.Text = "";
                    c133.Text = "";
                    for (int i = 0; i < ds.Tables["Cell13"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell13"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell13"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell13"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c131.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c132.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c133.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind22 = false;
                    c131.Text = "";
                    c132.Text = "";
                    c133.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 13");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell14();"
        private void CallSearchCell14()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 14' and QtyIn<>QtyOut  order by ScheduleID";
               
                if (Isfind23 == true)
                {
                    ds.Tables["Cell14"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell14");

                if (ds.Tables["Cell14"].Rows.Count != 0)
                {
                    Isfind23 = true;
                    dt = ds.Tables["Cell14"];

                    c141.Text = "";
                    c142.Text = "";
                    c143.Text = "";
                    for (int i = 0; i < ds.Tables["Cell14"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell14"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell14"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell14"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c141.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c142.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c143.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind23 = false;
                    c141.Text = "";
                    c142.Text = "";
                    c143.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 13");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell15();"
        private void CallSearchCell15()
        {
      
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 15' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind24 == true)
                {
                    ds.Tables["Cell15"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell15");

                if (ds.Tables["Cell15"].Rows.Count != 0)
                {
                    Isfind24 = true;
                    dt = ds.Tables["Cell14"];

                    c151.Text = "";
                    c152.Text = "";
                    c153.Text = "";
                    for (int i = 0; i < ds.Tables["Cell15"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell15"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell15"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell15"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i ==0)
                        {
                            c151.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c152.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c153.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind24 = false;
                    c151.Text = "";
                    c152.Text = "";
                    c153.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 15");
            }
         

        }

        #endregion


        #region "   CallSearchCellS1();"
        private void CallSearchCellS1()
        {

            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL S1' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind25 == true)
                {
                    ds.Tables["Cell1S1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell1S1");

                if (ds.Tables["Cell1S1"].Rows.Count != 0)
                {
                    Isfind25 = true;
                    dt = ds.Tables["Cell1S1"];

                    c1S1.Text = "";
                    c1S2.Text = "";
                    c1S3.Text = "";
                    for (int i = 0; i < ds.Tables["Cell1S1"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["Cell1S1"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["Cell1S1"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["Cell1S1"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c1S1.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c1S2.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c1S3.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind25 = false;
                    c1S1.Text = "";
                    c1S2.Text = "";
                    c1S3.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell S1");
            }


        }

        #endregion
    }
}
