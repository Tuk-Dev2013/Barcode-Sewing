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
    public partial class FrmShowSchedulePoly : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmShowSchedulePoly()
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
        private void FrmShowSchedule_Load(object sender, EventArgs e)
        {

            CallSearchCellT();
            CallSearchCell1();
            CallSearchCell2();

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
                        string TempQtyIn = ds.Tables["Showdata2"].Rows[i]["QtyIn"].ToString();
                        bntctbatch.Text = QtyIn;
                        bntctactual.Text = QtyOut;

                        if (i == 0)
                        {
                            ct1.Text = POnumber;
                            c0q1.Text = TempQtyIn;
                        }
                        else if (i == 1)
                        {
                            ct2.Text = POnumber;
                            c0q2.Text = TempQtyIn;
                        }
                        else if (i == 2)
                        {
                            ct3.Text = POnumber;
                            c0q3.Text = TempQtyIn;
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
                        string TempQtyIn = ds.Tables["Cell1"].Rows[i]["QtyIn"].ToString();
                        bntc11batch.Text = QtyIn;
                        bntc12actual.Text = QtyOut;

                        if (i == 0)
                        {
                            c11.Text = POnumber;
                            c1q1.Text = TempQtyIn;
                        }
                        else if (i == 1)
                        {
                            c12.Text = POnumber;
                            c1q2.Text = TempQtyIn;
                        }
                        else if (i == 2)
                        {
                            c13.Text = POnumber;
                            c1q3.Text = TempQtyIn;
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
                        string TempQtyIn = ds.Tables["Cell2"].Rows[i]["QtyIn"].ToString();
                        bntc21batch.Text = QtyIn;
                        bntc22actual.Text = QtyOut;


                        if (i == 0)
                        {
                            c21.Text = POnumber;
                            c2q1.Text = TempQtyIn;
                        }
                        else if (i == 1)
                        {
                            c22.Text = POnumber;
                            c2q2.Text = TempQtyIn;
                        }
                        else if (i == 2)
                        {
                            c23.Text = POnumber;
                            c2q3.Text = TempQtyIn;
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

        #region "CallUpdateCT"
        private void CallUpdateCT(String POnumber)
        {

            string temp = ConfigurationManager.AppSettings["BomCell"];

            var query = new StringBuilder();
            query.Append("UPDATE A_ScheduleCell  SET");
            query.Append(" QtyOut  = (Select SUM(QtyOut) As QtyOut  from  dbo.DocMODtl  where  DocNo ='" + POnumber + "' and  DeptCode='W8' and Barcode <> '' and  BomNo In (" + temp + "))");
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

                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables["Showdata"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    //วิ่งไล่สี
                    if ((tmpremark == "1") && (tmpCell == "CELL"))
                    {
                        bntcell0.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL"))
                    {
                        bntPressing0.BackColor = Color.Lime;
                    }

                    //Cell 1
                    else if ((tmpremark == "1") && (tmpCell == "CELL1"))
                    {
                        bntAsemble1.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL1"))
                    {
                        bntpressing1.BackColor = Color.Lime;
                    }


                      //Cell 2
                    else if ((tmpremark == "1") && (tmpCell == "CELL2"))
                    {
                        bntAsemble2.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL2"))
                    {
                        bntpressing2.BackColor = Color.Lime;
                    }


                }
                else
                {
                    Isfind = false;
                    //กรณี 2bin line cell หมด
                    //วิ่งไล่สี
                    if ((tmpremark == "1") && (tmpCell == "CELL"))
                    {
                        bntcell0.BackColor = Color.RosyBrown;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL"))
                    {
                        bntPressing0.BackColor = Color.Yellow;
                    }


                       //Cell 1
                    else if ((tmpremark == "1") && (tmpCell == "CELL1"))
                    {
                        bntAsemble1.BackColor = Color.RosyBrown;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL1"))
                    {
                        bntpressing1.BackColor = Color.Yellow;
                    }


                       //Cell 2
                    else if ((tmpremark == "1") && (tmpCell == "CELL2"))
                    {
                        bntAsemble2.BackColor = Color.RosyBrown;
                    }
                    else if ((tmpremark == "2") && (tmpCell == "CELL2"))
                    {
                        bntpressing2.BackColor = Color.Yellow;
                    }


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data");
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

        #region " CallpolyFram()"
        private void CallCellCheck(String tmpCell, String tmpremark)
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
                strSQL1 = " select * from   Lean_BatchPoly"
                + " where LineCell ='" + tmpCell + "' and Status<>'Success' and Dep ='" + tmpremark + "'";

                if (Isfind3 == true)
                {
                    ds.Tables["showPoly"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "showPoly");

                if (ds.Tables["showPoly"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["showPoly"];
                    //วิ่งไล่สี

                    //Cell 0
                    if ((tmpremark == "Poly") && (tmpCell == "CELL"))
                    {
                        bntpoly0.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL"))
                    {
                        bntFrame0.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL"))
                    {
                        bntRod0.BackColor = Color.Lime;
                    }
                    //Cell 1
                    else if ((tmpremark == "Poly") && (tmpCell == "CELL1"))
                    {
                        bntpoly1.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL1"))
                    {
                        bntFrame1.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL1"))
                    {
                        bntRod1.BackColor = Color.Lime;
                    }
                      //Cell 2
                    else if ((tmpremark == "Poly") && (tmpCell == "CELL2"))
                    {
                        bntpoly2.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL2"))
                    {
                        bntFrame2.BackColor = Color.Lime;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL2"))
                    {
                        bntRod2.BackColor = Color.Lime;
                    }
                }
                else
                {
                    Isfind3 = false;
                    //กรณี 2bin line cell หมด
                    //วิ่งไล่สี
                    if ((tmpremark == "Poly") && (tmpCell == "CELL"))
                    {
                        bntpoly0.BackColor = Color.Fuchsia;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL"))
                    {
                        bntFrame0.BackColor = Color.Turquoise;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL"))
                    {
                        bntRod0.BackColor = Color.BlueViolet;
                    }
                       //Cell 1
                    else if ((tmpremark == "Poly") && (tmpCell == "CELL1"))
                    {
                        bntpoly1.BackColor = Color.Fuchsia;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL1"))
                    {
                        bntFrame1.BackColor = Color.Turquoise;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL1"))
                    {
                        bntRod1.BackColor = Color.BlueViolet;
                    }
                    //Cell 2
                    else if ((tmpremark == "Poly") && (tmpCell == "CELL2"))
                    {
                        bntpoly2.BackColor = Color.Fuchsia;
                    }
                    else if ((tmpremark == "Frame") && (tmpCell == "CELL2"))
                    {
                        bntFrame2.BackColor = Color.Turquoise;
                    }
                    else if ((tmpremark == "Roding") && (tmpCell == "CELL2"))
                    {
                        bntRod2.BackColor = Color.BlueViolet;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No Data");
            }



        }

        #endregion



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
          //  this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
          this.lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
         

            bntctbatch.Text = "0";
            bntctactual.Text = "0";
            bntc11batch.Text = "0";
            bntc12actual.Text = "0";
            bntc21batch.Text = "0";
            bntc22actual.Text = "0";

            //   วิ่ง update ยอดยิ่ง barcode
          //  CallUpdateCT(ct1.Text.Trim()); 
          //  CallUpdateCT(c11.Text.Trim());
          //  CallUpdateCT(c21.Text.Trim());


           //   วิ่งหาข้อมูลแสดง
            CallSearchCellT();
            CallSearchCell1();
            CallSearchCell2();

            ct2.BackColor = Color.Red;
            c12.BackColor = Color.Red;
            c22.BackColor = Color.Red;


            //cell 2bin
            CallCellT("CELL", "1"); //Final  Assemble
            CallCellT("CELL", "2"); //Pressing
            CallCellCheck("CELL", "Poly"); //Poly
            CallCellCheck("CELL", "Frame"); //Frame
            CallCellCheck("CELL", "Roding"); //Roding

            //Cell 1
            CallCellT("CELL1", "1"); //Final  Assemble
            CallCellT("CELL1", "2"); //Pressing
            CallCellCheck("CELL1", "Poly"); //Poly
            CallCellCheck("CELL1", "Frame"); //Frame
            CallCellCheck("CELL1", "Roding"); //Roding

            //Cell 2
            CallCellT("CELL2", "1"); //Final  Assemble
            CallCellT("CELL2", "2"); //Pressing
            CallCellCheck("CELL2", "Poly"); //Poly
            CallCellCheck("CELL2", "Frame"); //Frame
            CallCellCheck("CELL2", "Roding"); //Roding


        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            if (ct2.BackColor == Color.Red)
            {
                ct2.BackColor = Color.DarkGray;
            }
            if (c12.BackColor == Color.Red)
            {
                c12.BackColor = Color.DarkGray;
            }
            if (c22.Text == "")
            { }
            else 
            if (c22.BackColor == Color.Red)
            {
                c22.BackColor = Color.DarkGray;
            }

            //Cell0
            if (bntcell0.BackColor == Color.RosyBrown)
            {
                //bntcell0.BackColor = Color.FromArgb(171,0,0);
               bntcell0.BackColor =Color.Orange;
            }
            else
            {
                bntcell0.BackColor = Color.Lime;
            }
            //Pressing
            if (bntPressing0.BackColor == Color.Yellow)
            {
                bntPressing0.BackColor = Color.Orange;
            }
            else
            {
                bntPressing0.BackColor = Color.Lime;
            }


            //cell1
            if (bntAsemble1.BackColor == Color.RosyBrown)
            {
                bntAsemble1.BackColor = Color.Orange;
            }
            else
            {
                bntAsemble1.BackColor = Color.Lime;
            }
            if (bntpressing1.BackColor == Color.Yellow)
            {
                bntpressing1.BackColor = Color.Orange;
            }
            else
            {
                bntpressing1.BackColor = Color.Lime;
            }


            //cell2
            if (bntAsemble2.BackColor == Color.RosyBrown)
            {
                bntAsemble2.BackColor = Color.Orange;
            }
            else
            {
                bntAsemble2.BackColor = Color.Lime;
            }
            if (bntpressing2.BackColor == Color.Yellow)
            {
                bntpressing2.BackColor = Color.Orange;
            }
            else
            {
                bntpressing2.BackColor = Color.Lime;
            }

            //poly
            if (bntpoly0.BackColor == Color.Fuchsia)
            {
                bntpoly0.BackColor = Color.Orange;
            }
            else
            {
                bntpoly0.BackColor = Color.Lime;
            }

            if (bntpoly1.BackColor == Color.Fuchsia)
            {
                bntpoly1.BackColor = Color.Orange;
            }
            else
            {
                bntpoly1.BackColor = Color.Lime;
            }

            if (bntpoly2.BackColor == Color.Fuchsia)
            {
                bntpoly2.BackColor = Color.Orange;
            }
            else
            {
                bntpoly2.BackColor = Color.Lime;
            }

            //Frame
            if (bntFrame0.BackColor == Color.Turquoise)
            {
                bntFrame0.BackColor = Color.Orange;
            }
            else
            {
                bntFrame0.BackColor = Color.Lime;
            }

            if (bntFrame1.BackColor == Color.Turquoise)
            {
                bntFrame1.BackColor = Color.Orange;
            }
            else
            {
                bntFrame1.BackColor = Color.Lime;
            }

            if (bntFrame2.BackColor == Color.Turquoise)
            {
                bntFrame2.BackColor = Color.Orange;
            }
            else
            {
                bntFrame2.BackColor = Color.Lime;
            }


            //Roding
            if (bntRod0.BackColor == Color.BlueViolet)
            {
                bntRod0.BackColor = Color.Orange;
            }
            else
            {
                bntRod0.BackColor = Color.Lime;
            }

            if (bntRod1.BackColor == Color.BlueViolet)
            {
                bntRod1.BackColor = Color.Orange;
            }
            else
            {
                bntRod1.BackColor = Color.Lime;
            }

            if (bntRod2.BackColor == Color.BlueViolet)
            {
                bntRod2.BackColor = Color.Orange;
            }
            else
            {
                bntRod2.BackColor = Color.Lime;
            }
        }
    }
}
