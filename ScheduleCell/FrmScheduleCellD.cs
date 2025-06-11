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
    public partial class FrmScheduleCellD : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind66 = false;
        Boolean Isfind4 = false;
        Boolean Isfind5 = false;
        Boolean Isfind6 = false;
        Boolean Isfind7 = false;
        Boolean Isfind8 = false;
        Boolean Isfind77 = false;
        Boolean Isfind88 = false;
        Boolean Isfind9 = false;
        Boolean Isfind10 = false;
        Boolean Isfind11 = false;

        public FrmScheduleCellD()
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
        private void FrmScheduleCellD_Load(object sender, EventArgs e)
        {
            CallSearchCellT();
            CallSearchCell1();
            CallSearchCell2();
            CallSearchCell3();
            CallSearchCell4();
            CallSearchCell5();

            //check PO 2 จ่ายวัสดุ ครบ ยัง
            //CallCheckPO(ct2.Text.Trim(),"CELL");

            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));
        }

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

        #region "      CallSearchCell1();"
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
                if (Isfind66 == true)
                {
                    ds.Tables["Cell6"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell6");

                if (ds.Tables["Cell6"].Rows.Count != 0)
                {
                    Isfind66 = true;
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
                    Isfind66 = false;

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
                if (Isfind77 == true)
                {
                    ds.Tables["Cell7"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell7");

                if (ds.Tables["Cell7"].Rows.Count != 0)
                {
                    Isfind77 = true;
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
                    Isfind77= false;

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
                    Isfind88 = true;
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
                if (Isfind9 == true)
                {
                    ds.Tables["Cell9"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell9");

                if (ds.Tables["Cell9"].Rows.Count != 0)
                {
                    Isfind9 = true;
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
                    Isfind9 = false;

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
                if (Isfind10 == true)
                {
                    ds.Tables["Cell10"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell10");

                if (ds.Tables["Cell10"].Rows.Count != 0)
                {
                    Isfind10= true;
                    dt = ds.Tables["Cell10"];

                    c101.Text = "";
                    this.c102.Text = "";
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
                    Isfind10 = false;

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
                    Isfind10 = true;
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

        //check PO 2 จ่ายวัสดุ ครบ ยัง
        #region "CallCheckPO"
        private void CallCheckPO(string tempPO,String cell)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Barcode,Dep,Status from dbo.Lean_BatchPoly  where Barcode='" + tempPO + "' and LineCell='" + cell + "' order by Dep";
                if (Isfind8 == true)
                {
                    ds.Tables["Checkdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Checkdata");

                if (ds.Tables["Checkdata"].Rows.Count != 0)
                {
                    Isfind8 = true;
                    dt = ds.Tables["Checkdata"];

                 
                    for (int i = 0; i < ds.Tables["Checkdata"].Rows.Count; i++)
                    {
                        string Barcode = ds.Tables["Checkdata"].Rows[i]["Barcode"].ToString();
                        string Dep = ds.Tables["Checkdata"].Rows[i]["Dep"].ToString();
                        string Status = ds.Tables["Checkdata"].Rows[i]["Status"].ToString();

                        //cell 0
                        if (cell == "CELL")
                        {
                           
                           if ((Dep == "Poly") && (Status == "Success"))
                          {
                              bntpoly0.BackColor = Color.YellowGreen;
                          }
                           else if ((Dep == "Poly") && (Status == "Out"))
                           {
                               bntpoly0.BackColor = Color.Red;
                           }

                           if ((Dep == "Roding") && (Status == "Success"))
                           {
                               bntRod0.BackColor = Color.YellowGreen;
                           }
                           else if ((Dep == "Roding") && (Status == "Out"))
                           {
                               bntRod0.BackColor = Color.Red;
                           }

                           if ((Dep == "Frame") && (Status == "Success"))
                           {
                               bntFrame0.BackColor = Color.YellowGreen;
                           }
                           else if ((Dep == "Frame") && (Status == "Out"))
                           {
                               bntFrame0.BackColor = Color.Red;
                           }
                        }

                        //cell 1
                        if (cell == "CELL1")
                        {
                            if ((Dep == "Poly") && (Status == "Success"))
                            {
                                bntpoly1.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Poly") && (Status == "Out"))
                            {
                                bntpoly1.BackColor = Color.Red;
                            }

                            if ((Dep == "Roding") && (Status == "Success"))
                            {
                                bntRod1.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Roding") && (Status == "Out"))
                            {
                                bntRod1.BackColor = Color.Red;
                            }

                            if ((Dep == "Frame") && (Status == "Success"))
                            {
                                lblPO.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Frame") && (Status == "Out"))
                            {
                                lblPO.BackColor = Color.Red;
                            }
                        }


                        //cell 2
                        if (cell == "CELL2")
                        {
                            if ((Dep == "Poly") && (Status == "Success"))
                            {
                                bntpoly2.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Poly") && (Status == "Out"))
                            {
                                bntpoly2.BackColor = Color.Red;
                            }

                            if ((Dep == "Roding") && (Status == "Success"))
                            {
                                bntRod2.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Roding") && (Status == "Out"))
                            {
                                bntRod2.BackColor = Color.Red;
                            }

                            if ((Dep == "Frame") && (Status == "Success"))
                            {
                                bntFrame2.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Frame") && (Status == "Out"))
                            {
                                bntFrame2.BackColor = Color.Red;
                            }
                        }


                        //cell 3
                        if (cell == "CELL3")
                        {
                            if ((Dep == "Poly") && (Status == "Success"))
                            {
                                bntpoly3.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Poly") && (Status == "Out"))
                            {
                                bntpoly3.BackColor = Color.Red;
                            }

                            if ((Dep == "Roding") && (Status == "Success"))
                            {
                                bntRod3.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Roding") && (Status == "Out"))
                            {
                                bntRod3.BackColor = Color.Red;
                            }

                            if ((Dep == "Frame") && (Status == "Success"))
                            {
                                bntFrame3.BackColor = Color.YellowGreen;
                            }
                            else if ((Dep == "Frame") && (Status == "Out"))
                            {
                                bntFrame3.BackColor = Color.Red;
                            }

                        }
                            //cell 4
                            if (cell == "CELL4")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly4.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly4.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod4.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod4.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame4.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame4.BackColor = Color.Red;
                                }
                            }


                            //cell 5
                            if (cell == "CELL5")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly5.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly5.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod5.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod5.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame5.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame5.BackColor = Color.Red;
                                }
                            }

                            //cell 6
                            if (cell == "CELL6")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly6.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly6.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod6.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod6.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame5.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame5.BackColor = Color.Red;
                                }
                            }

                            //cell 7
                            if (cell == "CELL7")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly7.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly7.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod7.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod7.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame7.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame7.BackColor = Color.Red;
                                }
                            }

                            //cell 8
                            if (cell == "CELL8")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly8.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly8.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod8.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod8.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame8.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame8.BackColor = Color.Red;
                                }
                            }

                            //cell 9
                            if (cell == "CELL9")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly9.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly9.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod9.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod9.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame9.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame9.BackColor = Color.Red;
                                }
                            }

                            //cell 10
                            if (cell == "CELL10")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly10.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly10.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod10.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod10.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame10.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame10.BackColor = Color.Red;
                                }
                            }
                            //cell 11
                            if (cell == "CELL11")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly11.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly11.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod11.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod11.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame11.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame11.BackColor = Color.Red;
                                }
                            }

                        
                    }
                }
                else
                {
                    Isfind8 = false;

                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data");
                return;
            }
            conn.Close();
        
        
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

        #region "CallUpdateCT"
        private void CallUpdateCT(String POnumber)
        {
            string temp = ConfigurationManager.AppSettings["BomCell"];
            var query = new StringBuilder();
            query.Append("UPDATE A_ScheduleCell  SET");
            query.Append(" QtyOut  = (Select SUM(QtyOut) As QtyOut  from  dbo.DocMODtl  where  DocNo ='" + POnumber + "' and  DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + " ))");
            query.Append(" WHERE POnumber =  @POnumber");


            using (var db = new DbHelper1())
            {
                try
                {
                    String tmpstr = " (Select SUM(QtyOut) As QtyOut  from  dbo.DocMODtl  where  DocNo ='" + POnumber + "' and  DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + "))";
                    //  db.AddParameter("@QtyOut", tmpstr);
                    db.AddParameter("@POnumber", POnumber);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

            }


        }
        #endregion

        #region " CallCellT()"
        private void CallCellT(String tmpCell, String tmpremark)
        {

            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

                string tempdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string d = Left(tempdate, 2);
                string M = Mid(tempdate, 3, 2);
                string y = Right(tempdate, 4);

                string strSQL1 = "";
                strSQL1 = " select itemcode,typename,itemname,Status  from dbo.Lean_Doc2Bin"
                + " where TypeName ='" + tmpCell + "' and Status<>'Success' and Remark ='" + tmpremark + "'";

                if (Isfind4 == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables["Showdata"].Rows.Count != 0)
                {
                    Isfind4 = true;
                    dt = ds.Tables["Showdata"];
                    //วิ่งไล่สี
                    if ((tmpremark == "1") && (tmpCell == "CELL"))
                    {
                        bntcell0.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL"))
                    {
                        bntPressing0.BackColor = Color.YellowGreen;
                    }

                    //Cell 1
                    else if ((tmpremark == "1") && (tmpCell == "CELL1"))
                    {
                        bntAsemble1.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL1"))
                    {
                        bntpressing1.BackColor = Color.YellowGreen;
                    }


                      //Cell 2
                    else if ((tmpremark == "1") && (tmpCell == "CELL2"))
                    {
                        lblcell1.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL2"))
                    {
                        bntpressing2.BackColor = Color.YellowGreen;
                    }

                          //Cell 3
                    else if ((tmpremark == "1") && (tmpCell == "CELL3"))
                    {
                        bntAsemble3.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL3"))
                    {
                        bntpressing3.BackColor = Color.YellowGreen;
                    }

                             //Cell 4
                    else if ((tmpremark == "1") && (tmpCell == "CELL4"))
                    {
                        bntAsemble4.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL4"))
                    {
                        bntpressing4.BackColor = Color.YellowGreen;
                    }
                    //Cell 5
                    else if ((tmpremark == "1") && (tmpCell == "CELL5"))
                    {
                        lblcell3.BackColor = Color.YellowGreen;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL5"))
                    {
                        bntpressing5.BackColor = Color.YellowGreen;
                    }
                }
                else
                {
                    Isfind4 = false;
                    //กรณี 2bin line cell หมด
                    //วิ่งไล่สี
                    if ((tmpremark == "1") && (tmpCell == "CELL"))
                    {
                        bntcell0.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL"))
                    {
                        bntPressing0.BackColor = Color.Red;
                    }


                       //Cell 1
                    else if ((tmpremark == "1") && (tmpCell == "CELL1"))
                    {
                        bntAsemble1.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL1"))
                    {
                        bntpressing1.BackColor = Color.Red;
                    }


                       //Cell 2
                    else if ((tmpremark == "1") && (tmpCell == "CELL2"))
                    {
                        lblcell1.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL2"))
                    {
                        bntpressing2.BackColor = Color.Red;
                    }


                       //Cell 3
                    else if ((tmpremark == "1") && (tmpCell == "CELL3"))
                    {
                        bntAsemble3.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL3"))
                    {
                        bntpressing3.BackColor = Color.Red;
                    }
                    //Cell 4
                    else if ((tmpremark == "1") && (tmpCell == "CELL4"))
                    {
                        bntAsemble4.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL4"))
                    {
                        bntpressing4.BackColor = Color.Red;
                    }
                    //Cell 5
                    else if ((tmpremark == "1") && (tmpCell == "CELL5"))
                    {
                        lblcell3.BackColor = Color.Red;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL5"))
                    {
                        bntpressing5.BackColor = Color.Red;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                return;
                //MessageBox.Show("No Data");
            }



        }

        #endregion

        #region"     CallCheckSche();"
        private void CallCheckSche()
        {
            //cell0
            if ((bntpoly0.BackColor == Color.YellowGreen) && (bntFrame0.BackColor == Color.YellowGreen) && (bntRod0.BackColor == Color.YellowGreen))
            {
                bntpoly0.BackColor = Color.Gray;
                bntFrame0.BackColor = Color.Gray;
                bntRod0.BackColor = Color.Gray;
                ct2.BackColor = Color.Lime;
                ct3.BackColor = Color.Red;
                CallCheckPO(ct3.Text.Trim(), "CELL");
                lblcell0.Text = "PO: "+ct3.Text.Trim();
   
            }
            else
            {
                ct2.BackColor = Color.Red;
            }
            //cell 1
            if ((bntpoly1.BackColor == Color.YellowGreen) && (lblPO.BackColor == Color.YellowGreen) && (bntRod1.BackColor == Color.YellowGreen))
            {
                bntpoly1.BackColor = Color.Gray;
                lblPO.BackColor = Color.Gray;
                bntRod1.BackColor = Color.Gray;
                c12.BackColor = Color.Lime;
                c13.BackColor = Color.Red;
                CallCheckPO(c13.Text.Trim(), "CELL1");
                lblcell11.Text = "PO: " + c13.Text.Trim();
            }
            else
            {
                c12.BackColor = Color.Red;
            }
            //cell 2
            if ((bntpoly2.BackColor == Color.YellowGreen) && (bntFrame2.BackColor == Color.YellowGreen) && (bntRod2.BackColor == Color.YellowGreen))
            {
                bntpoly2.BackColor = Color.Gray;
                bntFrame2.BackColor = Color.Gray;
                bntRod2.BackColor = Color.Gray;
                c22.BackColor = Color.Lime;
                c23.BackColor = Color.Red;
                CallCheckPO(c23.Text.Trim(), "CELL2");
                lblcell2.Text = "PO: " + c23.Text.Trim();
            }
            else
            {
                c22.BackColor = Color.Red;
            }
            //cell 3
            if ((bntpoly3.BackColor == Color.YellowGreen) && (bntFrame3.BackColor == Color.YellowGreen) && (bntRod3.BackColor == Color.YellowGreen))
            {
                bntpoly3.BackColor = Color.Gray;
                bntFrame3.BackColor = Color.Gray;
                bntRod3.BackColor = Color.Gray;
                c32.BackColor = Color.Lime;
                c33.BackColor = Color.Red;
                CallCheckPO(c33.Text.Trim(), "CELL3");
                lblcell33.Text = "PO: " + c33.Text.Trim();
            }
            else
            {
                c32.BackColor = Color.Red;
            }
            //cell 4
            if ((bntpoly4.BackColor == Color.YellowGreen) && (bntFrame4.BackColor == Color.YellowGreen))
            {
                bntpoly4.BackColor = Color.Gray;
                bntFrame4.BackColor = Color.Gray;
                bntRod4.BackColor = Color.Gray;
                c42.BackColor = Color.Lime;
                c43.BackColor = Color.Red;
                CallCheckPO(c43.Text.Trim(), "CELL4");
                lblcell4.Text = "PO: " + c43.Text.Trim();
            }
            else
            {
                c42.BackColor = Color.Red;
            }
            //cell 5
            if ((bntpoly5.BackColor == Color.YellowGreen) && (bntFrame5.BackColor == Color.YellowGreen))
            {
                bntpoly5.BackColor = Color.Gray;
                bntFrame5.BackColor = Color.Gray;
                bntRod5.BackColor = Color.Gray;
                c52.BackColor = Color.Lime;
                c53.BackColor = Color.Red;
                CallCheckPO(c53.Text.Trim(), "CELL5");
                lblcell5.Text = "PO: " + c53.Text.Trim();
            }
            else
            {
                c52.BackColor = Color.Red;
            }

            //cell 6
            if ((bntpoly6.BackColor == Color.YellowGreen) && (bntFrame6.BackColor == Color.YellowGreen))
            {
                bntpoly6.BackColor = Color.Gray;
                bntFrame6.BackColor = Color.Gray;
                bntRod6.BackColor = Color.Gray;
                c62.BackColor = Color.Lime;
                c63.BackColor = Color.Red;
                CallCheckPO(c63.Text.Trim(), "CELL6");
                lblcell6.Text = "PO: " + c63.Text.Trim();
            }
            else
            {
                c62.BackColor = Color.Red;
            }

            //cell 7
            if ((bntpoly7.BackColor == Color.YellowGreen) && (bntFrame7.BackColor == Color.YellowGreen))
            {
                bntpoly7.BackColor = Color.Gray;
                bntFrame7.BackColor = Color.Gray;
                bntRod7.BackColor = Color.Gray;
                c72.BackColor = Color.Lime;
                c73.BackColor = Color.Red;
                CallCheckPO(c73.Text.Trim(), "CELL7");
                lblcell7.Text = "PO: " + c73.Text.Trim();
            }
            else
            {
                c72.BackColor = Color.Red;
            }

            //cell 8
            if ((bntpoly8.BackColor == Color.YellowGreen) && (bntFrame8.BackColor == Color.YellowGreen))
            {
                bntpoly8.BackColor = Color.Gray;
                bntFrame8.BackColor = Color.Gray;
                bntRod8.BackColor = Color.Gray;
                c82.BackColor = Color.Lime;
                c83.BackColor = Color.Red;
                CallCheckPO(c83.Text.Trim(), "CELL8");
                lblcell8.Text = "PO: " + c83.Text.Trim();
            }
            else
            {
                c82.BackColor = Color.Red;
            }

            //cell 9
            if ((bntpoly9.BackColor == Color.YellowGreen) && (bntFrame9.BackColor == Color.YellowGreen))
            {
                bntpoly9.BackColor = Color.Gray;
                bntFrame9.BackColor = Color.Gray;
                bntRod9.BackColor = Color.Gray;
                c92.BackColor = Color.Lime;
                c93.BackColor = Color.Red;
                CallCheckPO(c93.Text.Trim(), "CELL9");
                lblcell9.Text = "PO: " + c93.Text.Trim();
            }
            else
            {
                c92.BackColor = Color.Red;
            }
            //cell 10
            if ((bntpoly10.BackColor == Color.YellowGreen) && (bntFrame10.BackColor == Color.YellowGreen))
            {
                bntpoly10.BackColor = Color.Gray;
                bntFrame10.BackColor = Color.Gray;
                bntRod10.BackColor = Color.Gray;
                c102.BackColor = Color.Lime;
                c103.BackColor = Color.Red;
                CallCheckPO(c103.Text.Trim(), "CELL10");
                lblcell10.Text = "PO: " + c103.Text.Trim();
            }
            else
            {
                c102.BackColor = Color.Red;
            }

            //cell 11
            if ((bntpoly11.BackColor == Color.YellowGreen) && (bntFrame11.BackColor == Color.YellowGreen))
            {
                bntpoly11.BackColor = Color.Gray;
                bntFrame11.BackColor = Color.Gray;
                bntRod11.BackColor = Color.Gray;
                c112.BackColor = Color.Lime;
                c113.BackColor = Color.Red;
                CallCheckPO(c113.Text.Trim(), "CELL11");
                lblcell11.Text = "PO: " + c113.Text.Trim();
            }
            else
            {
                c112.BackColor = Color.Red;
            }


        }
        #endregion

        //#region "CallCheckPic"
        //private void CallCheckPic(string barcode,string cell)
        //{
        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //    conn.Open();
        //    try
        //    {

        //        string strSQL1 = "";
        //        strSQL1 = " select COUNT(Barcode)as Num3 from dbo.Lean_BatchPoly where Barcode ='" +barcode + "' and Dep In ('Poly','Roding','Frame')and Status ='Success'";
        //        if (Isfind9 == true)
        //        {
        //            ds.Tables["Showpic"].Clear();
        //        }

        //        da = new SqlDataAdapter(strSQL1, conn);
        //        da.Fill(ds, "Showpic");

        //        if (ds.Tables["Showpic"].Rows.Count != 0)
        //        {
        //            Isfind9 = true;
        //            string Num1 = ds.Tables["Showpic"].Rows[0]["Num3"].ToString();
        //            //cell0
        //            if (cell == "CELL")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    Cell01.Visible = true;
        //                    cell02.Visible = false;

        //                }
        //                else
        //                {
        //                    Cell01.Visible = false;
        //                    cell02.Visible = true;
        //                }
        //            }
        //            //cell1
        //            if (cell == "CELL1")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    cell11.Visible = true;
        //                    cell12.Visible = false;

        //                }
        //                else
        //                {
        //                    cell11.Visible = false;
        //                    cell12.Visible = true;
        //                }
        //            }

        //            //cell2
        //            if (cell == "CELL2")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    cell21.Visible = true;
        //                    cell22.Visible = false;

        //                }
        //                else
        //                {
        //                    cell21.Visible = false;
        //                    cell22.Visible = true;
        //                }
        //            }

        //            //cell3
        //            if (cell == "CELL3")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    cell31.Visible = true;
        //                    cell32.Visible = false;

        //                }
        //                else
        //                {
        //                    cell31.Visible = false;
        //                    cell32.Visible = true;
        //                }
        //            }
        //            //cell4
        //            if (cell == "CELL4")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    cell41.Visible = true;
        //                    cell42.Visible = false;

        //                }
        //                else
        //                {
        //                    cell41.Visible = false;
        //                    cell42.Visible = true;
        //                }
        //            }

        //            //cell5
        //            if (cell == "CELL5")
        //            {
        //                if (Convert.ToDouble(Num1) >= 3)
        //                {
        //                    cell51.Visible = true;
        //                    cell52.Visible = false;

        //                }
        //                else
        //                {
        //                    cell51.Visible = false;
        //                    cell52.Visible = true;
        //                }
        //            }


        //        }
        //        else
        //        {
        //            Isfind9 = false;
        //            return;
        //        }
   
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No Data  Pic");
        //    }
        //    conn.Close();
        
        //}
        
        //#endregion
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            //set default
            bntpoly0.BackColor = Color.Gray;
            bntFrame0.BackColor = Color.Gray;
            bntRod0.BackColor = Color.Gray;
            bntpoly1.BackColor = Color.Gray;
            lblPO.BackColor = Color.Gray;
            bntRod1.BackColor = Color.Gray;

            bntpoly2.BackColor = Color.Gray;
            bntFrame2.BackColor = Color.Gray;
            bntRod2.BackColor = Color.Gray;

            bntpoly3.BackColor = Color.Gray;
            bntFrame3.BackColor = Color.Gray;
            bntRod3.BackColor = Color.Gray;

            bntpoly4.BackColor = Color.Gray;
            bntFrame4.BackColor = Color.Gray;
            bntRod4.BackColor = Color.Gray;

            bntpoly5.BackColor = Color.Gray;
            bntFrame5.BackColor = Color.Gray;
            bntRod5.BackColor = Color.Gray;

            bntpoly6.BackColor = Color.Gray;
            bntFrame6.BackColor = Color.Gray;
            bntRod6.BackColor = Color.Gray;

            bntpoly7.BackColor = Color.Gray;
            bntFrame7.BackColor = Color.Gray;
            bntRod7.BackColor = Color.Gray;

            bntpoly8.BackColor = Color.Gray;
            bntFrame8.BackColor = Color.Gray;
            bntRod8.BackColor = Color.Gray;

            bntpoly9.BackColor = Color.Gray;
            bntFrame9.BackColor = Color.Gray;
            bntRod9.BackColor = Color.Gray;

            bntpoly10.BackColor = Color.Gray;
            bntFrame10.BackColor = Color.Gray;
            bntRod10.BackColor = Color.Gray;

            bntpoly11.BackColor = Color.Gray;
            bntFrame11.BackColor = Color.Gray;
            bntRod11.BackColor = Color.Gray;
            ///
            ct1.BackColor = Color.Lime;
            ct2.BackColor = Color.Red;
            ct3.BackColor = Color.CadetBlue;
            c11.BackColor = Color.Lime;
            c12.BackColor = Color.Red;
            c13.BackColor = Color.CadetBlue;
            c21.BackColor = Color.Lime;
            c22.BackColor = Color.Red;
            c23.BackColor = Color.CadetBlue;
            c31.BackColor = Color.Lime;
            c32.BackColor = Color.Red;
            c33.BackColor = Color.CadetBlue;
            c41.BackColor = Color.Lime;
            c42.BackColor = Color.Red;
            c43.BackColor = Color.CadetBlue;
            c51.BackColor = Color.Lime;
            c52.BackColor = Color.Red;
            c53.BackColor = Color.CadetBlue;
            c61.BackColor = Color.Lime;
            c62.BackColor = Color.Red;
            c63.BackColor = Color.CadetBlue;
            c71.BackColor = Color.Lime;
            c72.BackColor = Color.Red;
            c73.BackColor = Color.CadetBlue;
            c81.BackColor = Color.Lime;
            c82.BackColor = Color.Red;
            c83.BackColor = Color.CadetBlue;
            c91.BackColor = Color.Lime;
            c92.BackColor = Color.Red;
            c93.BackColor = Color.CadetBlue;
            c101.BackColor = Color.Lime;
            c102.BackColor = Color.Red;
            c103.BackColor = Color.CadetBlue;
            c111.BackColor = Color.Lime;
            c112.BackColor = Color.Red;
            c113.BackColor = Color.CadetBlue;
            //   วิ่ง update ยอดยิ่ง barcode
            //CallUpdateCT(ct1.Text.Trim());
            //CallUpdateCT(c11.Text.Trim());
            //CallUpdateCT(c21.Text.Trim());
            //CallUpdateCT(c31.Text.Trim());
            //CallUpdateCT(c41.Text.Trim());
            //CallUpdateCT(c51.Text.Trim());

            //   วิ่งหาข้อมูลแสดง
            CallSearchCellT();
            CallSearchCell1();
            CallSearchCell2();
            CallSearchCell3();
            CallSearchCell4();
            CallSearchCell5();
            //21/01/2015
            CallSearchCell6();
            CallSearchCell7();
            CallSearchCell8();
            CallSearchCell9();
            CallSearchCell10();
            CallSearchCell11();

            //2bin
            CallCellT("CELL", "1"); //Final  Assemble
            CallCellT("CELL", "2"); //Pressing
            CallCellT("CELL1", "1"); //Final  Assemble
            CallCellT("CELL1", "2"); //Pressing
            CallCellT("CELL2", "1"); //Final  Assemble
            CallCellT("CELL2", "2"); //Pressing
            CallCellT("CELL3", "1"); //Final  Assemble
            CallCellT("CELL3", "2"); //Pressing
            CallCellT("CELL4", "1"); //Final  Assemble
            CallCellT("CELL4", "2"); //Pressing
            CallCellT("CELL5", "1"); //Final  Assemble
            CallCellT("CELL5", "2"); //Pressing

            //21/01/2015
            //CallCellT("CELL6", "1"); //Final  Assemble
            //CallCellT("CELL6", "2"); //Pressing
            //CallCellT("CELL7", "1"); //Final  Assemble
            //CallCellT("CELL7", "2"); //Pressing
            //CallCellT("CELL8", "1"); //Final  Assemble
            //CallCellT("CELL8", "2"); //Pressing
            //CallCellT("CELL9", "1"); //Final  Assemble
            //CallCellT("CELL9", "2"); //Pressing
            //CallCellT("CELL10", "1"); //Final  Assemble
            //CallCellT("CELL10", "2"); //Pressing
            //CallCellT("CELL11", "1"); //Final  Assemble
            //CallCellT("CELL11", "2"); //Pressing


            //batch
           // CallCellCheck("CELL", "Poly", bntpoly0.Text.Trim()); //Poly
            //check PO 2 จ่ายวัสดุ ครบ ยัง
            lblcell0.Text = "PO: " + ct2.Text.Trim();
            lblcell11.Text = "PO: " + c12.Text.Trim();
            lblcell2.Text = "PO: " + c22.Text.Trim();
            lblcell33.Text = "PO: " + c32.Text.Trim();
            lblcell4.Text = "PO: " + c42.Text.Trim();
            lblcell5.Text = "PO: " + c52.Text.Trim();
            lblcell6.Text = "PO: " + c62.Text.Trim();
            lblcell7.Text = "PO: " + c72.Text.Trim();
            lblcell8.Text = "PO: " + c82.Text.Trim();
            lblcell9.Text = "PO: " + c92.Text.Trim();
            lblcell10.Text = "PO: " + c102.Text.Trim();
            lblcell111.Text = "PO: " + c112.Text.Trim();


            CallCheckPO(ct2.Text.Trim(), "CELL");
            CallCheckPO(c12.Text.Trim(), "CELL1");
            CallCheckPO(c22.Text.Trim(), "CELL2");
            CallCheckPO(c32.Text.Trim(), "CELL3");
            CallCheckPO(c42.Text.Trim(), "CELL4");
            CallCheckPO(c52.Text.Trim(), "CELL5");
            CallCheckPO(c62.Text.Trim(), "CELL6");
            CallCheckPO(c72.Text.Trim(), "CELL7");
            CallCheckPO(c82.Text.Trim(), "CELL8");
            CallCheckPO(c92.Text.Trim(), "CELL9");
            CallCheckPO(c102.Text.Trim(), "CELL10");
            CallCheckPO(c112.Text.Trim(), "CELL11");


            //check Schedule PO 2
            CallCheckSche();
            //check Schedule PO 1 ครบ set  Poly,Roding,Frame หรือไม่ แสดงเป็นภาพ
          // CallCheckPic(ct1.Text.Trim(), "CELL");
            //CallCheckPic(c11.Text.Trim(), "CELL1");
            //CallCheckPic(c21.Text.Trim(), "CELL2");
            //CallCheckPic(c31.Text.Trim(), "CELL3");
            //CallCheckPic(c41.Text.Trim(), "CELL4");
            //CallCheckPic(c51.Text.Trim(), "CELL5");


        }
        #region "time 2"
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            //2bin
            //Cell0
            if (bntcell0.BackColor == Color.Red)
            {
                //bntcell0.BackColor = Color.FromArgb(171,0,0);
                bntcell0.BackColor = Color.Orange;
            }
            else
            {
                bntcell0.BackColor = Color.YellowGreen;
            }
            //Pressing
            if (bntPressing0.BackColor == Color.Red)
            {
                bntPressing0.BackColor = Color.Orange;
            }
            else
            {
                bntPressing0.BackColor = Color.YellowGreen;
            }


            //cell1
            if (bntAsemble1.BackColor == Color.Red)
            {
                bntAsemble1.BackColor = Color.Orange;
            }
            else
            {
                bntAsemble1.BackColor = Color.YellowGreen;
            }
            if (bntpressing1.BackColor == Color.Red)
            {
                bntpressing1.BackColor = Color.Orange;
            }
            else
            {
                bntpressing1.BackColor = Color.YellowGreen;
            }


            //cell2
            if (lblcell1.BackColor == Color.Red)
            {
                lblcell1.BackColor = Color.Orange;
            }
            else
            {
                lblcell1.BackColor = Color.YellowGreen;
            }
            if (bntpressing2.BackColor == Color.Red)
            {
                bntpressing2.BackColor = Color.Orange;
            }
            else
            {
                bntpressing2.BackColor = Color.YellowGreen;
            }


            //cell3
            if (bntAsemble3.BackColor == Color.Red)
            {
                bntAsemble3.BackColor = Color.Orange;
            }
            else
            {
                bntAsemble3.BackColor = Color.YellowGreen;
            }
            if (bntpressing3.BackColor == Color.Red)
            {
                bntpressing3.BackColor = Color.Orange;
            }
            else
            {
                bntpressing3.BackColor = Color.YellowGreen;
            }

            //cell4
            if (bntAsemble4.BackColor == Color.Red)
            {
                bntAsemble4.BackColor = Color.Orange;
            }
            else
            {
                bntAsemble4.BackColor = Color.YellowGreen;
            }
            if (bntpressing4.BackColor == Color.Red)
            {
                bntpressing4.BackColor = Color.Orange;
            }
            else
            {
                bntpressing4.BackColor = Color.YellowGreen;
            }

            //cell5
            if (lblcell3.BackColor == Color.Red)
            {
                lblcell3.BackColor = Color.Orange;
            }
            else
            {
                lblcell3.BackColor = Color.YellowGreen;
            }
            if (bntpressing5.BackColor == Color.Red)
            {
                bntpressing5.BackColor = Color.Orange;
            }
            else
            {
                bntpressing5.BackColor = Color.YellowGreen;
            }
          
            // cell 0
            //Poly
            if (bntpoly0.BackColor == Color.Red)
            {
                bntpoly0.BackColor = Color.Orange;
            }
            else if (bntpoly0.BackColor == Color.YellowGreen)
            {
                bntpoly0.BackColor = Color.YellowGreen;
            }
            else 
            {
                bntpoly0.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame0.BackColor == Color.Red)
            {
                bntFrame0.BackColor = Color.Orange;
            }
            else if (bntFrame0.BackColor == Color.YellowGreen)
            {
                bntFrame0.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame0.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod0.BackColor == Color.Red)
            {
                bntRod0.BackColor = Color.Orange;
            }
            else if (bntRod0.BackColor == Color.YellowGreen)
            {
                bntRod0.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod0.BackColor = Color.Gray;
            }
            ////////////////////////cell 1 /////////////////////////////////
            //Poly
            if (bntpoly1.BackColor == Color.Red)
            {
                bntpoly1.BackColor = Color.Orange;
            }
            else if (bntpoly1.BackColor == Color.YellowGreen)
            {
                bntpoly1.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly1.BackColor = Color.Gray;
            }
            //Frame
            if (lblPO.BackColor == Color.Red)
            {
                lblPO.BackColor = Color.Orange;
            }
            else if (lblPO.BackColor == Color.YellowGreen)
            {
                lblPO.BackColor = Color.YellowGreen;
            }
            else
            {
                lblPO.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod1.BackColor == Color.Red)
            {
                bntRod1.BackColor = Color.Orange;
            }
            else if (bntRod1.BackColor == Color.YellowGreen)
            {
                bntRod1.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod1.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 2 /////////////////////////////////
            //Poly
            if (bntpoly2.BackColor == Color.Red)
            {
                bntpoly2.BackColor = Color.Orange;
            }
            else if (bntpoly2.BackColor == Color.YellowGreen)
            {
                bntpoly2.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly2.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame2.BackColor == Color.Red)
            {
                bntFrame2.BackColor = Color.Orange;
            }
            else if (bntFrame2.BackColor == Color.YellowGreen)
            {
                bntFrame2.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame2.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod2.BackColor == Color.Red)
            {
                bntRod2.BackColor = Color.Orange;
            }
            else if (bntRod2.BackColor == Color.YellowGreen)
            {
                bntRod2.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod2.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 3 /////////////////////////////////
            //Poly
            if (bntpoly3.BackColor == Color.Red)
            {
                bntpoly3.BackColor = Color.Orange;
            }
            else if (bntpoly3.BackColor == Color.YellowGreen)
            {
                bntpoly3.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly3.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame3.BackColor == Color.Red)
            {
                bntFrame3.BackColor = Color.Orange;
            }
            else if (bntFrame3.BackColor == Color.YellowGreen)
            {
                bntFrame3.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame3.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod3.BackColor == Color.Red)
            {
                bntRod3.BackColor = Color.Orange;
            }
            else if (bntRod3.BackColor == Color.YellowGreen)
            {
                bntRod3.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod3.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 4 /////////////////////////////////
            //Poly
            if (bntpoly4.BackColor == Color.Red)
            {
                bntpoly4.BackColor = Color.Orange;
            }
            else if (bntpoly4.BackColor == Color.YellowGreen)
            {
                bntpoly4.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly4.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame4.BackColor == Color.Red)
            {
                bntFrame4.BackColor = Color.Orange;
            }
            else if (bntFrame4.BackColor == Color.YellowGreen)
            {
                bntFrame4.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame4.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod4.BackColor == Color.Red)
            {
                bntRod4.BackColor = Color.Orange;
            }
            else if (bntRod4.BackColor == Color.YellowGreen)
            {
                bntRod4.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod4.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 5 /////////////////////////////////
            //Poly
            if (bntpoly5.BackColor == Color.Red)
            {
                bntpoly5.BackColor = Color.Orange;
            }
            else if (bntpoly5.BackColor == Color.YellowGreen)
            {
                bntpoly5.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly5.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame5.BackColor == Color.Red)
            {
                bntFrame5.BackColor = Color.Orange;
            }
            else if (bntFrame5.BackColor == Color.YellowGreen)
            {
                bntFrame5.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame5.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod5.BackColor == Color.Red)
            {
                bntRod5.BackColor = Color.Orange;
            }
            else if (bntRod5.BackColor == Color.YellowGreen)
            {
                bntRod5.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod5.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 6 /////////////////////////////////
            //Poly
            if (bntpoly6.BackColor == Color.Red)
            {
                bntpoly6.BackColor = Color.Orange;
            }
            else if (bntpoly6.BackColor == Color.YellowGreen)
            {
                bntpoly6.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly6.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame6.BackColor == Color.Red)
            {
                bntFrame6.BackColor = Color.Orange;
            }
            else if (bntFrame6.BackColor == Color.YellowGreen)
            {
                bntFrame6.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame6.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod6.BackColor == Color.Red)
            {
                bntRod6.BackColor = Color.Orange;
            }
            else if (bntRod6.BackColor == Color.YellowGreen)
            {
                bntRod6.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod6.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 7 /////////////////////////////////
            //Poly
            if (bntpoly7.BackColor == Color.Red)
            {
                bntpoly7.BackColor = Color.Orange;
            }
            else if (bntpoly7.BackColor == Color.YellowGreen)
            {
                bntpoly7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly7.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame7.BackColor == Color.Red)
            {
                bntFrame7.BackColor = Color.Orange;
            }
            else if (bntFrame7.BackColor == Color.YellowGreen)
            {
                bntFrame7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame7.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod7.BackColor == Color.Red)
            {
                bntRod7.BackColor = Color.Orange;
            }
            else if (bntRod7.BackColor == Color.YellowGreen)
            {
                bntRod7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod7.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 7 /////////////////////////////////
            //Poly
            if (bntpoly7.BackColor == Color.Red)
            {
                bntpoly7.BackColor = Color.Orange;
            }
            else if (bntpoly7.BackColor == Color.YellowGreen)
            {
                bntpoly7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly7.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame7.BackColor == Color.Red)
            {
                bntFrame7.BackColor = Color.Orange;
            }
            else if (bntFrame7.BackColor == Color.YellowGreen)
            {
                bntFrame7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame7.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod7.BackColor == Color.Red)
            {
                bntRod7.BackColor = Color.Orange;
            }
            else if (bntRod7.BackColor == Color.YellowGreen)
            {
                bntRod7.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod7.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 8 /////////////////////////////////
            //Poly
            if (bntpoly8.BackColor == Color.Red)
            {
                bntpoly8.BackColor = Color.Orange;
            }
            else if (bntpoly8.BackColor == Color.YellowGreen)
            {
                bntpoly8.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly8.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame8.BackColor == Color.Red)
            {
                bntFrame8.BackColor = Color.Orange;
            }
            else if (bntFrame8.BackColor == Color.YellowGreen)
            {
                bntFrame8.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame8.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod8.BackColor == Color.Red)
            {
                bntRod8.BackColor = Color.Orange;
            }
            else if (bntRod8.BackColor == Color.YellowGreen)
            {
                bntRod8.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod8.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 9 /////////////////////////////////
            //Poly
            if (bntpoly9.BackColor == Color.Red)
            {
                bntpoly9.BackColor = Color.Orange;
            }
            else if (bntpoly9.BackColor == Color.YellowGreen)
            {
                bntpoly9.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly9.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame9.BackColor == Color.Red)
            {
                bntFrame9.BackColor = Color.Orange;
            }
            else if (bntFrame9.BackColor == Color.YellowGreen)
            {
                bntFrame9.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame9.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod9.BackColor == Color.Red)
            {
                bntRod9.BackColor = Color.Orange;
            }
            else if (bntRod9.BackColor == Color.YellowGreen)
            {
                bntRod9.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod9.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////


            ////////////////////////cell 10 /////////////////////////////////
            //Poly
            if (bntpoly10.BackColor == Color.Red)
            {
                bntpoly10.BackColor = Color.Orange;
            }
            else if (bntpoly10.BackColor == Color.YellowGreen)
            {
                bntpoly10.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly10.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame10.BackColor == Color.Red)
            {
                bntFrame10.BackColor = Color.Orange;
            }
            else if (bntFrame10.BackColor == Color.YellowGreen)
            {
                bntFrame10.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame10.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod10.BackColor == Color.Red)
            {
                bntRod10.BackColor = Color.Orange;
            }
            else if (bntRod10.BackColor == Color.YellowGreen)
            {
                bntRod10.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod10.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 11 /////////////////////////////////
            //Poly
            if (bntpoly11.BackColor == Color.Red)
            {
                bntpoly11.BackColor = Color.Orange;
            }
            else if (bntpoly11.BackColor == Color.YellowGreen)
            {
                bntpoly11.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly11.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame11.BackColor == Color.Red)
            {
                bntFrame11.BackColor = Color.Orange;
            }
            else if (bntFrame11.BackColor == Color.YellowGreen)
            {
                bntFrame11.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame11.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod11.BackColor == Color.Red)
            {
                bntRod11.BackColor = Color.Orange;
            }
            else if (bntRod11.BackColor == Color.YellowGreen)
            {
                bntRod11.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod11.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////


        }
        #endregion


    }
}
