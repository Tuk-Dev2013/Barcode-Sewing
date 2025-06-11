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
    public partial class FrmScheduleCell : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind4 = false;
        Boolean Isfind5 = false;
        Boolean Isfind6 = false;
        Boolean Isfind7 = false;
        Boolean Isfind8 = false;
        Boolean Isfind9 = false;
        Boolean Isfind10 = false;
        Boolean Isfind11 = false;
        Boolean Isfind12 = false;
        Boolean Isfind13 = false;
        Boolean Isfind14= false;

        Boolean Isfind15 = false;
        Boolean Isfind16 = false;
        Boolean Isfind17 = false;
        Boolean Isfind18 = false;
        Boolean Isfind19 = false;
        Boolean Isfind20 = false;
        public FrmScheduleCell()
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

        private void FrmScheduleCell_Load(object sender, EventArgs e)
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
           
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
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
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  show");
            }
       


        }
        #endregion

        #region "      CallSearchCell1();"
        private void CallSearchCell1()
        {
           
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data  Cell 1");
            }
      


        }
        #endregion

        #region "   CallSearchCell2();"
        private void CallSearchCell2()
        {
          
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data  Cell 2");
            }
       

        }

        #endregion

        #region "   CallSearchCell3();"
        private void CallSearchCell3()
        {
        
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data  Cell 3");
            }
     

        }

        #endregion

        #region "   CallSearchCell4();"
        private void CallSearchCell4()
        {
         
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data  Cell 4");
            }
         

        }

        #endregion

        #region "   CallSearchCell5();"
        private void CallSearchCell5()
        {
         
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  Cell 5");
            }
      

        }

        #endregion

        #region "   CallSearchCell6();"
        private void CallSearchCell6()
        {
          
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

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
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  Cell 6");
            }
     

        }

        #endregion

        #region "   CallSearchCell7();"
        private void CallSearchCell7()
        {
            try
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
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
                conn.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data  Cell 7");
            }
       

        }

        #endregion

        #region "   CallSearchCell8();"
        private void CallSearchCell8()
        {
     
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 8' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind11 == true)
                {
                    ds.Tables["Cell8"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell8");

                if (ds.Tables["Cell8"].Rows.Count != 0)
                {
                    Isfind11 = true;
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
                    Isfind11 = false;
                    c81.Text = "";
                    c82.Text = "";
                    c83.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
             //   MessageBox.Show("No Data  Cell 8");
            }
   

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
                if (Isfind12 == true)
                {
                    ds.Tables["Cell9"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell9");

                if (ds.Tables["Cell9"].Rows.Count != 0)
                {
                    Isfind12 = true;
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
                    Isfind12 = false;
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
                //MessageBox.Show("No Data  Cell 9");
            }
            conn.Close();

        }

        #endregion

        #region "   CallSearchCell10();"
        private void CallSearchCell10()
        {
           
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 10' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind13 == true)
                {
                    ds.Tables["Cell10"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell10");

                if (ds.Tables["Cell10"].Rows.Count != 0)
                {
                    Isfind13 = true;
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
                    Isfind13 = false;
                    c101.Text = "";
                    c102.Text = "";
                    c103.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  Cell 10");
            }
        

        }

        #endregion

        #region "   CallSearchCell11();"
        private void CallSearchCell11()
        {
        
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 11' and QtyIn<>QtyOut  order by ScheduleID";
               
                if (Isfind14 == true)
                {
                    ds.Tables["Cell11"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell11");

                if (ds.Tables["Cell11"].Rows.Count != 0)
                {
                    Isfind14 = true;
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
                    Isfind14 = false;
                    c111.Text = "";
                    c112.Text = "";
                    c113.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data  Cell 11");
            }
     

        }

        #endregion

        #region "   CallSearchCell12();"
        private void CallSearchCell12()
        {
           
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 12' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind15 == true)
                {
                    ds.Tables["Cell12"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell12");

                if (ds.Tables["Cell12"].Rows.Count != 0)
                {
                    Isfind15 = true;
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
                    Isfind15 = false;
                    c121.Text = "";
                    c122.Text = "";
                    c123.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  Cell 12");
            }
      

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

                if (Isfind16 == true)
                {
                    ds.Tables["Cell13"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell13");

                if (ds.Tables["Cell13"].Rows.Count != 0)
                {
                    Isfind16 = true;
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
                    Isfind16 = false;

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
           
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL 14' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind17 == true)
                {
                    ds.Tables["Cell14"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell14");

                if (ds.Tables["Cell14"].Rows.Count != 0)
                {
                    Isfind17 = true;
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
                    Isfind17 = false;
                    c141.Text = "";
                    c142.Text = "";
                    c143.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();

            }
            catch (Exception ex)
            {
             //   MessageBox.Show("No Data  Cell 14");
            }
   
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

                if (Isfind18 == true)
                {
                    ds.Tables["Cell15"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell15");

                if (ds.Tables["Cell15"].Rows.Count != 0)
                {
                    Isfind18 = true;
                    dt = ds.Tables["Cell15"];

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


                        if (i == 0)
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
                    Isfind18 = false;
                    c151.Text = "";
                    c152.Text = "";
                    c153.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data  Cell 15");
            }
       

        }

        #endregion

        #region "   CallSearchCell16T();"
        private void CallSearchCell16T()
        {

            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL T2' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind19 == true)
                {
                    ds.Tables["CellT2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellT2");

                if (ds.Tables["CellT2"].Rows.Count != 0)
                {
                    Isfind19 = true;
                    dt = ds.Tables["CellT2"];

                    c16T1.Text = "";
                    c16T2.Text = "";
                    c16T3.Text = "";
                    c16T4.Text = "";
                    c16T5.Text = "";
                    c16T6.Text = "";
                    for (int i = 0; i < ds.Tables["CellT2"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["CellT2"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["CellT2"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["CellT2"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c16T1.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c16T2.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c16T3.Text = POnumber;
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
                    Isfind19 = false;
                    c16T1.Text = "";
                    c16T2.Text = "";
                    c16T3.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("No Data  Cell 19");
            }


        }

        #endregion

        #region "   CallSearchCell16S();"
        private void CallSearchCell16S()
        {

            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname,QtyOut  FROM A_ScheduleCell where Cellname ='CELL S1' and QtyIn<>QtyOut  order by ScheduleID";

                if (Isfind20 == true)
                {
                    ds.Tables["CellS1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellS1");

                if (ds.Tables["CellS1"].Rows.Count != 0)
                {
                    Isfind20 = true;
                    dt = ds.Tables["CellS1"];

                    c16S1.Text = "";
                    c16S2.Text = "";
                    c16S3.Text = "";
                    for (int i = 0; i < ds.Tables["CellS1"].Rows.Count; i++)
                    {
                        string POnumber = ds.Tables["CellS1"].Rows[i]["POnumber"].ToString();
                        string QtyIn = ds.Tables["CellS1"].Rows[0]["QtyIn"].ToString();
                        string QtyOut = ds.Tables["CellS1"].Rows[0]["QtyOut"].ToString();
                        //  bntc31batch.Text = QtyIn;
                        //  bntc32actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c16S1.Text = POnumber;
                        }
                        else if (i == 1)
                        {
                            c16S2.Text = POnumber;
                        }
                        else if (i == 2)
                        {
                            c16S3.Text = POnumber;
                        }



                    }
                }
                else
                {
                    Isfind20 = false;
                    c16S1.Text = "";
                    c16S2.Text = "";
                    c16S3.Text = "";
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
                conn.Close();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("No Data  Cell 19");
            }


        }

        #endregion

        //check PO 2 จ่ายวัสดุ ครบ ยัง
        #region "CallCheckPO"
        private void CallCheckPO(string tempPO,String cell)
        {
          
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
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


                        /// Cell 6
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
                                    bntFrame6.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame6.BackColor = Color.Red;
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

                            //cell 12
                            if (cell == "CELL12")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly12.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly12.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod12.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod12.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame12.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame12.BackColor = Color.Red;
                                }
                            }

                            //cell 13
                            if (cell == "CELL13")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly13.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly13.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod13.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod13.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame13.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame13.BackColor = Color.Red;
                                }
                            }

                            //cell 14
                            if (cell == "CELL14")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly14.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly14.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod14.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod14.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame14.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame14.BackColor = Color.Red;
                                }
                            }

                            //cell 15
                            if (cell == "CELL15")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly15.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly15.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod15.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod15.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame15.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame15.BackColor = Color.Red;
                                }
                            }


                            //cell T2
                            if (cell == "CELLT2")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly16T.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly16T.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod16T.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod16T.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame16T.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame16T.BackColor = Color.Red;
                                }
                            }

                            //cell S1
                            if (cell == "CELLS1")
                            {
                                if ((Dep == "Poly") && (Status == "Success"))
                                {
                                    bntpoly16S.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Poly") && (Status == "Out"))
                                {
                                    bntpoly16S.BackColor = Color.Red;
                                }

                                if ((Dep == "Roding") && (Status == "Success"))
                                {
                                    bntRod16S.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Roding") && (Status == "Out"))
                                {
                                    bntRod16S.BackColor = Color.Red;
                                }

                                if ((Dep == "Frame") && (Status == "Success"))
                                {
                                    bntFrame16S.BackColor = Color.YellowGreen;
                                }
                                else if ((Dep == "Frame") && (Status == "Out"))
                                {
                                    bntFrame16S.BackColor = Color.Red;
                                }
                            }

                    }
                    conn.Close();
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
                  //  MessageBox.Show("Error" + ex);
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
                lblcell111.Text = "PO: " + c103.Text.Trim();
            }
            else
            {
                c112.BackColor = Color.Red;
            }

            //cell 12
            if ((bntpoly12.BackColor == Color.YellowGreen) && (bntFrame12.BackColor == Color.YellowGreen))
            {
                bntpoly12.BackColor = Color.Gray;
                bntFrame12.BackColor = Color.Gray;
                bntRod12.BackColor = Color.Gray;
                c122.BackColor = Color.Lime;
                c123.BackColor = Color.Red;
                CallCheckPO(c123.Text.Trim(), "CELL12");
                lblcell12.Text = "PO: " + c123.Text.Trim();
            }
            else
            {
                c122.BackColor = Color.Red;
            }

            //cell 13
            if ((bntpoly13.BackColor == Color.YellowGreen) && (bntFrame13.BackColor == Color.YellowGreen))
            {
                bntpoly13.BackColor = Color.Gray;
                bntFrame13.BackColor = Color.Gray;
                bntRod13.BackColor = Color.Gray;
                c132.BackColor = Color.Lime;
                c133.BackColor = Color.Red;
                CallCheckPO(c133.Text.Trim(), "CELL13");
                lblcell13.Text = "PO: " + c133.Text.Trim();
            }
            else
            {
                c132.BackColor = Color.Red;
            }

            //cell 14
            if ((bntpoly14.BackColor == Color.YellowGreen) && (bntFrame14.BackColor == Color.YellowGreen))
            {
                bntpoly14.BackColor = Color.Gray;
                bntFrame14.BackColor = Color.Gray;
                bntRod14.BackColor = Color.Gray;
                c142.BackColor = Color.Lime;
                c143.BackColor = Color.Red;
                CallCheckPO(c143.Text.Trim(), "CELL14");
                lblcell14.Text = "PO: " + c143.Text.Trim();
            }
            else
            {
                c142.BackColor = Color.Red;
            }

            //cell 15
            if ((bntpoly15.BackColor == Color.YellowGreen) && (bntFrame15.BackColor == Color.YellowGreen))
            {
                bntpoly15.BackColor = Color.Gray;
                bntFrame15.BackColor = Color.Gray;
                bntRod15.BackColor = Color.Gray;
                c152.BackColor = Color.Lime;
                c153.BackColor = Color.Red;
                CallCheckPO(c153.Text.Trim(), "CELL15");
                lblcell15.Text = "PO: " + c153.Text.Trim();
            }
            else
            {
                c152.BackColor = Color.Red;
            }


        }
        #endregion

        #region "CallCheckPic"
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
        
        #endregion
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
           // this.lblSS.Text = DateTime.Now.ToString("mm:ss");
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

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


            bntpoly12.BackColor = Color.Gray;
            bntFrame12.BackColor = Color.Gray;
            bntRod12.BackColor = Color.Gray;

            bntpoly13.BackColor = Color.Gray;
            bntFrame13.BackColor = Color.Gray;
            bntRod13.BackColor = Color.Gray;

            bntpoly14.BackColor = Color.Gray;
            bntFrame14.BackColor = Color.Gray;
            bntRod14.BackColor = Color.Gray;

            bntpoly15.BackColor = Color.Gray;
            bntFrame15.BackColor = Color.Gray;
            bntRod15.BackColor = Color.Gray;

            bntpoly16T.BackColor = Color.Gray;
            bntFrame16T.BackColor = Color.Gray;
            bntRod16T.BackColor = Color.Gray;

            bntpoly16S.BackColor = Color.Gray;
            bntFrame16S.BackColor = Color.Gray;
            bntRod16S.BackColor = Color.Gray;
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

            c121.BackColor = Color.Lime;
            c122.BackColor = Color.Red;
            c123.BackColor = Color.CadetBlue;

            c131.BackColor = Color.Lime;
            c132.BackColor = Color.Red;
            c133.BackColor = Color.CadetBlue;
            c141.BackColor = Color.Lime;
            c142.BackColor = Color.Red;
            c143.BackColor = Color.CadetBlue;
            c151.BackColor = Color.Lime;
            c152.BackColor = Color.Red;
            c153.BackColor = Color.CadetBlue;

            c16T1.BackColor = Color.Lime;
            c16T2.BackColor = Color.Red;
            c16T3.BackColor = Color.CadetBlue;

            c16S1.BackColor = Color.Lime;
            c16S2.BackColor = Color.Red;
            c16S3.BackColor = Color.CadetBlue;

            //   วิ่ง update ยอดยิ่ง barcode
            CallUpdateCT(ct1.Text.Trim());
            CallUpdateCT(c11.Text.Trim());
            CallUpdateCT(c21.Text.Trim());
            CallUpdateCT(c31.Text.Trim());
            CallUpdateCT(c41.Text.Trim());
            CallUpdateCT(c51.Text.Trim());
            CallUpdateCT(c61.Text.Trim());
            CallUpdateCT(c71.Text.Trim());
            CallUpdateCT(c81.Text.Trim());
            CallUpdateCT(c91.Text.Trim());
            CallUpdateCT(c101.Text.Trim());
            CallUpdateCT(c111.Text.Trim());
            CallUpdateCT(c121.Text.Trim());
            CallUpdateCT(c131.Text.Trim());
            CallUpdateCT(c141.Text.Trim());
            CallUpdateCT(c151.Text.Trim());

            CallUpdateCT(c16T1.Text.Trim());
            CallUpdateCT(c16S1.Text.Trim());

            //   วิ่งหาข้อมูลแสดง
            CallSearchCellT();
            CallSearchCell1();
            CallSearchCell2();
            CallSearchCell3();
            CallSearchCell4();
            CallSearchCell5();
            CallSearchCell6();
            CallSearchCell7();
            CallSearchCell8();
            CallSearchCell9();
            CallSearchCell10();
            CallSearchCell11();
            CallSearchCell12();
            CallSearchCell13();
            CallSearchCell14();
            CallSearchCell15();

            CallSearchCell16T();
            CallSearchCell16S();
            //2bin
            //CallCellT("CELL", "1"); //Final  Assemble
            //CallCellT("CELL", "2"); //Pressing
            //CallCellT("CELL1", "1"); //Final  Assemble
            //CallCellT("CELL1", "2"); //Pressing
            //CallCellT("CELL2", "1"); //Final  Assemble
            //CallCellT("CELL2", "2"); //Pressing
            //CallCellT("CELL3", "1"); //Final  Assemble
            //CallCellT("CELL3", "2"); //Pressing
            //CallCellT("CELL4", "1"); //Final  Assemble
            //CallCellT("CELL4", "2"); //Pressing
            //CallCellT("CELL5", "1"); //Final  Assemble
            //CallCellT("CELL5", "2"); //Pressing
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
            lblcell12.Text = "PO: " + c122.Text.Trim();
            lblcell13.Text = "PO: " + c132.Text.Trim();
            lblcell14.Text = "PO: " + c142.Text.Trim();
            lblcell15.Text = "PO: " + c152.Text.Trim();

            lblcell16T.Text = "PO: " + c16T2.Text.Trim();
            lblcell16S.Text = "PO: " + c16S2.Text.Trim();


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
            CallCheckPO(c122.Text.Trim(), "CELL12");
            CallCheckPO(c132.Text.Trim(), "CELL13");
            CallCheckPO(c142.Text.Trim(), "CELL14");
            CallCheckPO(c152.Text.Trim(), "CELL15");

            CallCheckPO(c16T2.Text.Trim(), "CELLT2");
            CallCheckPO(c16S2.Text.Trim(), "CELLS1");

            //check Schedule PO 2

            CallCheckSche();

            ////check Schedule PO 1 ครบ set  Poly,Roding,Frame หรือไม่ แสดงเป็นภาพ
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
            ////Cell0
            //if (bntcell0.BackColor == Color.Red)
            //{
            //    //bntcell0.BackColor = Color.FromArgb(171,0,0);
            //    bntcell0.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntcell0.BackColor = Color.YellowGreen;
            //}
            ////Pressing
            //if (bntPressing0.BackColor == Color.Red)
            //{
            //    bntPressing0.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntPressing0.BackColor = Color.YellowGreen;
            //}


            ////cell1
            //if (bntAsemble1.BackColor == Color.Red)
            //{
            //    bntAsemble1.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntAsemble1.BackColor = Color.YellowGreen;
            //}
            //if (bntpressing1.BackColor == Color.Red)
            //{
            //    bntpressing1.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntpressing1.BackColor = Color.YellowGreen;
            //}


            ////cell2
            //if (lblcell1.BackColor == Color.Red)
            //{
            //    lblcell1.BackColor = Color.Orange;
            //}
            //else
            //{
            //    lblcell1.BackColor = Color.YellowGreen;
            //}
            //if (bntpressing2.BackColor == Color.Red)
            //{
            //    bntpressing2.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntpressing2.BackColor = Color.YellowGreen;
            //}


            ////cell3
            //if (bntAsemble3.BackColor == Color.Red)
            //{
            //    bntAsemble3.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntAsemble3.BackColor = Color.YellowGreen;
            //}
            //if (bntpressing3.BackColor == Color.Red)
            //{
            //    bntpressing3.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntpressing3.BackColor = Color.YellowGreen;
            //}

            ////cell4
            //if (bntAsemble4.BackColor == Color.Red)
            //{
            //    bntAsemble4.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntAsemble4.BackColor = Color.YellowGreen;
            //}
            //if (bntpressing4.BackColor == Color.Red)
            //{
            //    bntpressing4.BackColor = Color.Orange;
            //}
            //else
            //{
            //    bntpressing4.BackColor = Color.YellowGreen;
            //}

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

            ////////////////////////cell 12 /////////////////////////////////
            //Poly
            if (bntpoly12.BackColor == Color.Red)
            {
                bntpoly12.BackColor = Color.Orange;
            }
            else if (bntpoly12.BackColor == Color.YellowGreen)
            {
                bntpoly12.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly12.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame12.BackColor == Color.Red)
            {
                bntFrame12.BackColor = Color.Orange;
            }
            else if (bntFrame12.BackColor == Color.YellowGreen)
            {
                bntFrame12.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame12.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod12.BackColor == Color.Red)
            {
                bntRod12.BackColor = Color.Orange;
            }
            else if (bntRod12.BackColor == Color.YellowGreen)
            {
                bntRod12.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod12.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////
            ////////////////////////cell 13 /////////////////////////////////
            //Poly
            if (bntpoly13.BackColor == Color.Red)
            {
                bntpoly13.BackColor = Color.Orange;
            }
            else if (bntpoly13.BackColor == Color.YellowGreen)
            {
                bntpoly13.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly13.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame13.BackColor == Color.Red)
            {
                bntFrame13.BackColor = Color.Orange;
            }
            else if (bntFrame13.BackColor == Color.YellowGreen)
            {
                bntFrame13.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame13.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod13.BackColor == Color.Red)
            {
                bntRod13.BackColor = Color.Orange;
            }
            else if (bntRod13.BackColor == Color.YellowGreen)
            {
                bntRod13.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod13.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 14 /////////////////////////////////
            //Poly
            if (bntpoly14.BackColor == Color.Red)
            {
                bntpoly14.BackColor = Color.Orange;
            }
            else if (bntpoly11.BackColor == Color.YellowGreen)
            {
                bntpoly14.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly14.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame14.BackColor == Color.Red)
            {
                bntFrame14.BackColor = Color.Orange;
            }
            else if (bntFrame14.BackColor == Color.YellowGreen)
            {
                bntFrame14.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame14.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod14.BackColor == Color.Red)
            {
                bntRod14.BackColor = Color.Orange;
            }
            else if (bntRod14.BackColor == Color.YellowGreen)
            {
                bntRod14.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod14.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell 15 /////////////////////////////////
            //Poly
            if (bntpoly15.BackColor == Color.Red)
            {
                bntpoly15.BackColor = Color.Orange;
            }
            else if (bntpoly15.BackColor == Color.YellowGreen)
            {
                bntpoly15.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly15.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame15.BackColor == Color.Red)
            {
                bntFrame15.BackColor = Color.Orange;
            }
            else if (bntFrame15.BackColor == Color.YellowGreen)
            {
                bntFrame15.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame15.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod15.BackColor == Color.Red)
            {
                bntRod15.BackColor = Color.Orange;
            }
            else if (bntRod15.BackColor == Color.YellowGreen)
            {
                bntRod15.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod11.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////



            ////////////////////////cell T2 /////////////////////////////////
            //Poly
            if (bntpoly16T.BackColor == Color.Red)
            {
                bntpoly16T.BackColor = Color.Orange;
            }
            else if (bntpoly16T.BackColor == Color.YellowGreen)
            {
                bntpoly16T.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly16T.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame16T.BackColor == Color.Red)
            {
                bntFrame16T.BackColor = Color.Orange;
            }
            else if (bntFrame16T.BackColor == Color.YellowGreen)
            {
                bntFrame16T.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame16T.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod16T.BackColor == Color.Red)
            {
                bntRod16T.BackColor = Color.Orange;
            }
            else if (bntRod16T.BackColor == Color.YellowGreen)
            {
                bntRod16T.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod16T.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

            ////////////////////////cell S1 /////////////////////////////////
            //Poly
            if (bntpoly16S.BackColor == Color.Red)
            {
                bntpoly16S.BackColor = Color.Orange;
            }
            else if (bntpoly16S.BackColor == Color.YellowGreen)
            {
                bntpoly16S.BackColor = Color.YellowGreen;
            }
            else
            {
                bntpoly16S.BackColor = Color.Gray;
            }
            //Frame
            if (bntFrame16S.BackColor == Color.Red)
            {
                bntFrame16S.BackColor = Color.Orange;
            }
            else if (bntFrame16S.BackColor == Color.YellowGreen)
            {
                bntFrame16S.BackColor = Color.YellowGreen;
            }
            else
            {
                bntFrame16S.BackColor = Color.Gray;
            }
            //Roding
            if (bntRod16S.BackColor == Color.Red)
            {
                bntRod16S.BackColor = Color.Orange;
            }
            else if (bntRod16S.BackColor == Color.YellowGreen)
            {
                bntRod16S.BackColor = Color.YellowGreen;
            }
            else
            {
                bntRod16S.BackColor = Color.Gray;
            }
            ////////////////end////////////////////////

        }
        #endregion

     
     


    }
}
