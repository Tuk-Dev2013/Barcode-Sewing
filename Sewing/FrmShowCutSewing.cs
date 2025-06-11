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
    public partial class FrmShowCutSewing : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfindck = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        Boolean Isfind4 = false;
        Boolean Isfind5 = false;
        Boolean Isfind6 = false;
        Boolean Isfind7 = false;
        Boolean Isfind8 = false;
        Boolean Isfind9 = false;
        Boolean Isfinds = false;
        Boolean Isfindr = false;
        Boolean Isfindt = false;
        public FrmShowCutSewing()
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

            //double num = Convert.ToDouble(lbltotal.Text) / Convert.ToDouble(lbltotaltarget.Text);
            //double sumper = num * 100;
            //lblper.Text = sumper.ToString("#,###0") + "%";

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }


        private void FrmShowCutSewing_Load(object sender, EventArgs e)
        {
            string str = ConfigurationManager.AppSettings["SHOW_SCREEN"];
            showOnMonitor(Convert.ToInt16(str));

            CallSewing1();
            CallSewing2();
            CallSewing3();
            CallSewing4();
            CallSewing5();
            CallSewing6();
            CallSewing7();
            CallSewing8();
            CallSewing9();
            CallSewingsofa();
            CallSewingrsofa();
            CallSewingt();
        }

        #region " CallSewing1()"
        private void CallSewing1()
        {
            this.txt1_0.Text = "";
            this.txt1_1.Text = "";
            this.txt1_2.Text = "";
            this.txt1_3.Text = "";
            this.txt1_4.Text = "";
            this.txt1_5.Text = "";
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
              //  strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 1' and Sequence between '4' and '9'  order by Sequence ";

                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 1' )  "
                + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                
                
                if (Isfind1 == true)
                {
                    ds.Tables["CellSewing1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing1");

                if (ds.Tables["CellSewing1"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["CellSewing1"];

                    this.lbll1.BackColor = Color.SeaShell;
                    this.lblf1.BackColor = Color.SeaShell;
                    this.lbls1.BackColor = Color.SeaShell;
                    this.lblp1.BackColor = Color.SeaShell;
                    for (int i = 0; i < ds.Tables["CellSewing1"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing1"].Rows[i]["CkStatusAll"].ToString();

                        if ((i == 0)&&(CkStatusAll=="1"))
                        {
                            this.txt1_0.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                        }
                 
                        if ((i == 1)&&(CkStatusAll=="1"))
                        {
                            this.txt1_1.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                        }
                
                        if ((i == 2)&&(CkStatusAll=="1"))
                        {
                            this.txt1_2.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                        }
                 
                        if ((i == 3)&&(CkStatusAll=="1"))
                        {
                            this.txt1_3.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                        }
                 
                        if ((i == 4)&&(CkStatusAll=="1"))
                        {
                            this.txt1_4.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                        }
               
                        if (CkStatusAll=="3")
                        {
                            this.txt1_5.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing1"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing1"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing1"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing1"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll1.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll1.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf1.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf1.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls1.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls1.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp1.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp1.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind1 = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing2()"
        private void CallSewing2()
        {
            this.txt2_0.Text = "";
            this.txt2_1.Text = "";
            this.txt2_2.Text = "";
            this.txt2_3.Text = "";
            this.txt2_4.Text = "";
            this.txt2_5.Text = "";
   
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 2'  and Sequence between '4' and '9' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
           + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 2' )  "
           + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
           + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                
                if (Isfind2 == true)
                {
                    ds.Tables["CellSewing2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing2");

                if (ds.Tables["CellSewing2"].Rows.Count != 0)
                {
                    Isfind2 = true;
                    dt = ds.Tables["CellSewing2"];

                    this.lbll2.BackColor = Color.SeaShell;
                    this.lblf2.BackColor = Color.SeaShell;
                    this.lbls2.BackColor = Color.SeaShell;
                    this.lblp2.BackColor = Color.SeaShell;
                    for (int i = 0; i < ds.Tables["CellSewing2"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing2"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt2_0.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt2_1.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt2_2.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt2_3.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt2_4.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt2_5.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing2"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing2"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing2"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing2"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll2.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll2.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf2.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf2.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls2.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls2.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp2.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp2.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind2 = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing3()"
        private void CallSewing3()
        {
            this.txt3_0.Text = "";
            this.txt3_1.Text = "";
            this.txt3_2.Text = "";
            this.txt3_3.Text = "";
            this.txt3_4.Text = "";
            this.txt3_5.Text = "";
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " Select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 3'  and Sequence between '4' and '9' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
          + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 3' )  "
          + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
          + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind3 == true)
                {
                    ds.Tables["CellSewing3"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing3");

                if (ds.Tables["CellSewing3"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["CellSewing3"];

                    this.lbll3.BackColor = Color.SeaShell;
                    this.lblf3.BackColor = Color.SeaShell;
                    this.lbls3.BackColor = Color.SeaShell;
                    this.lblp3.BackColor = Color.SeaShell;
                    for (int i = 0; i < ds.Tables["CellSewing3"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing3"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt3_0.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt3_1.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt3_2.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt3_3.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt3_4.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {
                            this.txt3_5.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing3"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing3"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing3"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing3"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll3.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll3.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf3.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf3.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls3.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls3.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp3.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp3.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind3 = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing4()"
        private void CallSewing4()
        {
            this.txt4_0.Text = "";
            this.txt4_1.Text = "";
            this.txt4_2.Text = "";
            this.txt4_3.Text = "";
            this.txt4_4.Text = "";
            this.txt4_5.Text = "";

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, -0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 4'  and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 4' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind4 == true)
                {
                    ds.Tables["CellSewing4"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing4");

                if (ds.Tables["CellSewing4"].Rows.Count != 0)
                {
                    Isfind4 = true;
                    dt = ds.Tables["CellSewing4"];

                    this.lbll4.BackColor = Color.SeaShell;
                    this.lblf4.BackColor = Color.SeaShell;
                    this.lbls4.BackColor = Color.SeaShell;
                    this.lblp4.BackColor = Color.SeaShell;
                    for (int i = 0; i < ds.Tables["CellSewing4"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing4"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt4_0.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt4_1.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt4_2.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt4_3.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt4_4.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt4_5.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing4"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing4"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing4"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing4"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll4.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll4.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf4.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf4.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls4.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls4.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp4.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp4.BackColor = Color.Red;
                            }
                            return;
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
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing5()"
        private void CallSewing5()
        {
            this.txt5_0.Text = "";
            this.txt5_1.Text = "";
            this.txt5_2.Text = "";
            this.txt5_3.Text = "";
            this.txt5_4.Text = "";
            this.txt5_5.Text = "";

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 5' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL,3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 5' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind5 == true)
                {
                    ds.Tables["CellSewing5"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing5");

                this.lbll5.BackColor = Color.SeaShell;
                this.lblf5.BackColor = Color.SeaShell;
                this.lbls5.BackColor = Color.SeaShell;
                this.lblp5.BackColor = Color.SeaShell;
                if (ds.Tables["CellSewing5"].Rows.Count != 0)
                {
                    Isfind5 = true;
                    dt = ds.Tables["CellSewing5"];
 

                    for (int i = 0; i < ds.Tables["CellSewing5"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing5"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt5_0.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt5_1.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt5_2.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt5_3.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt5_4.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt5_5.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing5"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing5"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing5"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing5"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll5.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll5.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf5.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf5.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls5.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls5.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp5.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp5.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind5 = false;
          
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing6()"
        private void CallSewing6()
        {
            this.txt6_0.Text = "";
            this.txt6_1.Text = "";
            this.txt6_2.Text = "";
            this.txt6_3.Text = "";
            this.txt6_4.Text = "";
            this.txt6_5.Text = "";

            this.lbll6.BackColor = Color.SeaShell;
            this.lblf6.BackColor = Color.SeaShell;
            this.lbls6.BackColor = Color.SeaShell;
            this.lblp6.BackColor = Color.SeaShell;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
             //   strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 6' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 6' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind6 == true)
                {
                    ds.Tables["CellSewing6"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing6");

                if (ds.Tables["CellSewing6"].Rows.Count != 0)
                {
                    Isfind6 = true;
                    dt = ds.Tables["CellSewing6"];
                 
                    for (int i = 0; i < ds.Tables["CellSewing6"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing6"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt6_0.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt6_1.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt6_2.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt6_3.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt6_4.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt6_5.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing6"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing6"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing6"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing6"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll6.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll6.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf6.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf6.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls6.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls6.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp6.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp6.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind6 = false;
   
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 6");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing7()"
        private void CallSewing7()
        {
            this.txt7_0.Text = "";
            this.txt7_1.Text = "";
            this.txt7_2.Text = "";
            this.txt7_3.Text = "";
            this.txt7_4.Text = "";
            this.txt7_5.Text = "";
            this.lbll7.BackColor = Color.SeaShell;
            this.lblf7.BackColor = Color.SeaShell;
            this.lbls7.BackColor = Color.SeaShell;
            this.lblp7.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 7' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 7' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind7 == true)
                {
                    ds.Tables["CellSewing7"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing7");

                if (ds.Tables["CellSewing7"].Rows.Count != 0)
                {
                    Isfind7 = true;
                    dt = ds.Tables["CellSewing7"];

              
                    for (int i = 0; i < ds.Tables["CellSewing7"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing7"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt7_0.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt7_1.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt7_2.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt7_3.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt7_4.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt7_5.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing7"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing7"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing7"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing7"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll7.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll7.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf7.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf7.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls7.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls7.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp7.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp7.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind7 = false;
  
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 7");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing8()"
        private void CallSewing8()
        {
            this.txt8_0.Text = "";
            this.txt8_1.Text = "";
            this.txt8_2.Text = "";
            this.txt8_3.Text = "";
            this.txt8_4.Text = "";
            this.txt8_5.Text = "";
            this.lbll8.BackColor = Color.SeaShell;
            this.lblf8.BackColor = Color.SeaShell;
            this.lbls8.BackColor = Color.SeaShell;
            this.lblp8.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 8' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 8' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind8 == true)
                {
                    ds.Tables["CellSewing8"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing8");

                if (ds.Tables["CellSewing8"].Rows.Count != 0)
                {
                    Isfind8 = true;
                    dt = ds.Tables["CellSewing8"];

                    for (int i = 0; i < ds.Tables["CellSewing8"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing8"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt8_0.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt8_1.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt8_2.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt8_3.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt8_4.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt8_5.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing8"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing8"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing8"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing8"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll8.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll8.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf8.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf8.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls8.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls8.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp8.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp8.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind8 = false;
     
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 8");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewing9()"
        private void CallSewing9()
        {
            this.txt9_0.Text = "";
            this.txt9_1.Text = "";
            this.txt9_2.Text = "";
            this.txt9_3.Text = "";
            this.txt9_4.Text = "";
            this.txt9_5.Text = "";
            this.lbll9.BackColor = Color.SeaShell;
            this.lblf9.BackColor = Color.SeaShell;
            this.lbls9.BackColor = Color.SeaShell;
            this.lblp9.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 3' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 3' )  "
        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfind9 == true)
                {
                    ds.Tables["CellSewing9"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing9");

                if (ds.Tables["CellSewing9"].Rows.Count != 0)
                {
                    Isfind9 = true;
                    dt = ds.Tables["CellSewing9"];

         
                    for (int i = 0; i < ds.Tables["CellSewing9"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing9"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt9_0.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt9_1.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt9_2.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt9_3.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt9_4.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt9_5.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewing9"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewing9"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewing9"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewing9"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbll9.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbll9.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblf9.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblf9.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lbls9.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lbls9.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp9.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp9.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfind9 = false;
        
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewingsofa()"
        private void CallSewingsofa()
        {
            this.txt10_0.Text = "";
            this.txt10_1.Text = "";
            this.txt10_2.Text = "";
            this.txt10_3.Text = "";
            this.txt10_4.Text = "";
            this.txt10_5.Text = "";
            this.lbllsofa.BackColor = Color.SeaShell;
            this.lblfsofa.BackColor = Color.SeaShell;
            this.lblssofa.BackColor = Color.SeaShell;
            this.lblp10.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
              //  strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 2'  and Sequence between '4' and '9' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
      + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 2' )  "
      + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
      + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfinds == true)
                {
                    ds.Tables["CellSewings"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewings");

                if (ds.Tables["CellSewings"].Rows.Count != 0)
                {
                    Isfinds = true;
                    dt = ds.Tables["CellSewings"];

           
                    for (int i = 0; i < ds.Tables["CellSewings"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewings"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt10_0.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt10_1.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt10_2.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt10_3.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt10_4.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt10_5.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewings"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewings"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewings"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewings"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbllsofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbllsofa.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblfsofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblfsofa.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lblssofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lblssofa.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp10.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp10.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfinds = false;

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewingrsofa()"
        private void CallSewingrsofa()
        {

            this.txt11_0.Text = "";
            this.txt11_1.Text = "";
            this.txt11_2.Text = "";
            this.txt11_3.Text = "";
            this.txt11_4.Text = "";
            this.txt11_5.Text = "";
            this.lbllrsofa.BackColor = Color.SeaShell;
            this.lblfrsofa.BackColor = Color.SeaShell;
            this.lblsrsofa.BackColor = Color.SeaShell;
            this.lblp11.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 1' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
    + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 1' )  "
    + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
    + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfindr == true)
                {
                    ds.Tables["CellSewingr"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewingr");

                if (ds.Tables["CellSewingr"].Rows.Count != 0)
                {
                    Isfindr = true;
                    dt = ds.Tables["CellSewingr"];


                    for (int i = 0; i < ds.Tables["CellSewingr"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewingr"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt11_0.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt11_1.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt11_2.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                        }
                        if ((i ==3) && (CkStatusAll == "1"))
                        {
                            this.txt11_3.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt11_4.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt11_5.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewingr"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewingr"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewingr"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewingr"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbllrsofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbllrsofa.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblfrsofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblfrsofa.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lblsrsofa.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lblsrsofa.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp11.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp11.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfindr = false;
       
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        #region " CallSewingt()"
        private void CallSewingt()
        {
            this.txt12_0.Text = "";
            this.txt12_1.Text = "";
            this.txt12_2.Text = "";
            this.txt12_3.Text = "";
            this.txt12_4.Text = "";
            this.txt12_5.Text = "";
            this.lbllt.BackColor = Color.SeaShell;
            this.lblft.BackColor = Color.SeaShell;
            this.lblst.BackColor = Color.SeaShell;
            this.lblp12.BackColor = Color.SeaShell;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Training Sewing' and Sequence between '4' and '9'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
+ " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP  FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Training Sewing' )  "
+ " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
+ " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  order by Sequence ";
                if (Isfindt == true)
                {
                    ds.Tables["CellSewingt"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewingt");

                if (ds.Tables["CellSewingt"].Rows.Count != 0)
                {
                    Isfindt = true;
                    dt = ds.Tables["CellSewingt"];


                    for (int i = 0; i < ds.Tables["CellSewingt"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewingt"].Rows[i]["CkStatusAll"].ToString();
                        if ((i == 0) && (CkStatusAll == "1"))
                        {
                            this.txt12_0.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 1) && (CkStatusAll == "1"))
                        {
                            this.txt12_1.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 2) && (CkStatusAll == "1"))
                        {
                            this.txt12_2.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 3) && (CkStatusAll == "1"))
                        {
                            this.txt12_3.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                        }
                        if ((i == 4) && (CkStatusAll == "1"))
                        {
                            this.txt12_4.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                        }
                        if (CkStatusAll == "3")
                        {

                            this.txt12_5.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
                            string StatusL = ds.Tables["CellSewingt"].Rows[i]["StatusL"].ToString();
                            string StatusF = ds.Tables["CellSewingt"].Rows[i]["StatusF"].ToString();
                            string StatusS = ds.Tables["CellSewingt"].Rows[i]["StatusS"].ToString();
                            string StatusP = ds.Tables["CellSewingt"].Rows[i]["StatusP"].ToString();
                            if (StatusL == "1")
                            {
                                this.lbllt.BackColor = Color.ForestGreen;
                            }
                            else if (StatusL == "0")
                            {
                                this.lbllt.BackColor = Color.Red;
                            }
                            if (StatusF == "1")
                            {
                                this.lblft.BackColor = Color.ForestGreen;
                            }
                            else if (StatusF == "0")
                            {
                                this.lblft.BackColor = Color.Red;
                            }
                            if (StatusS == "1")
                            {
                                this.lblst.BackColor = Color.ForestGreen;
                            }
                            else if (StatusS == "0")
                            {
                                this.lblst.BackColor = Color.Red;
                            }
                            if (StatusP == "1")
                            {
                                this.lblp12.BackColor = Color.ForestGreen;
                            }
                            else if (StatusP == "0")
                            {
                                this.lblp12.BackColor = Color.Red;
                            }
                            return;
                        }

                    }
                }
                else
                {
                    Isfindt = false;
              
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            //Sewing Cell1
            if (this.lbll1.BackColor == Color.Red)
            {
                this.lbll1.BackColor = Color.Orange;
            }
            if (this.lblf1.BackColor == Color.Red)
            {
                this.lblf1.BackColor = Color.Orange;
            }
            if (this.lbls1.BackColor == Color.Red)
            {
                this.lbls1.BackColor = Color.Orange;
            }
            if (this.lblp1.BackColor == Color.Red)
            {
                this.lblp1.BackColor = Color.Orange;
            }
            //Sewing Cell2
            if (this.lbll2.BackColor == Color.Red)
            {
                this.lbll2.BackColor = Color.Orange;
            }
            if (this.lblf2.BackColor == Color.Red)
            {
                this.lblf2.BackColor = Color.Orange;
            }
            if (this.lbls2.BackColor == Color.Red)
            {
                this.lbls2.BackColor = Color.Orange;
            }
            if (this.lblp2.BackColor == Color.Red)
            {
                this.lblp2.BackColor = Color.Orange;
            }
            //Sewing Cell3
            if (this.lbll3.BackColor == Color.Red)
            {
                this.lbll3.BackColor = Color.Orange;
            }
            if (this.lblf3.BackColor == Color.Red)
            {
                this.lblf3.BackColor = Color.Orange;
            }
            if (this.lbls3.BackColor == Color.Red)
            {
                this.lbls3.BackColor = Color.Orange;
            }
            if (this.lblp3.BackColor == Color.Red)
            {
                this.lblp3.BackColor = Color.Orange;
            }
            //Sewing Cell4
            if (this.lbll4.BackColor == Color.Red)
            {
                this.lbll4.BackColor = Color.Orange;
            }
            if (this.lblf4.BackColor == Color.Red)
            {
                this.lblf4.BackColor = Color.Orange;
            }
            if (this.lbls4.BackColor == Color.Red)
            {
                this.lbls4.BackColor = Color.Orange;
            }
            if (this.lblp4.BackColor == Color.Red)
            {
                this.lblp4.BackColor = Color.Orange;
            }

            //Sewing Cell5
            if (this.lbll5.BackColor == Color.Red)
            {
                this.lbll5.BackColor = Color.Orange;
            }
            if (this.lblf5.BackColor == Color.Red)
            {
                this.lblf5.BackColor = Color.Orange;
            }
            if (this.lbls5.BackColor == Color.Red)
            {
                this.lbls5.BackColor = Color.Orange;
            }
            if (this.lblp5.BackColor == Color.Red)
            {
                this.lblp5.BackColor = Color.Orange;
            }
            //Sewing Cell6
            if (this.lbll6.BackColor == Color.Red)
            {
                this.lbll6.BackColor = Color.Orange;
            }
            if (this.lblf6.BackColor == Color.Red)
            {
                this.lblf6.BackColor = Color.Orange;
            }
            if (this.lbls6.BackColor == Color.Red)
            {
                this.lbls6.BackColor = Color.Orange;
            }
            if (this.lblp6.BackColor == Color.Red)
            {
                this.lblp6.BackColor = Color.Orange;
            }
            //Sewing Cell7
            if (this.lbll7.BackColor == Color.Red)
            {
                this.lbll7.BackColor = Color.Orange;
            }
            if (this.lblf7.BackColor == Color.Red)
            {
                this.lblf7.BackColor = Color.Orange;
            }
            if (this.lbls7.BackColor == Color.Red)
            {
                this.lbls7.BackColor = Color.Orange;
            }
            if (this.lblp7.BackColor == Color.Red)
            {
                this.lblp7.BackColor = Color.Orange;
            }
            //Sewing Cell8
            if (this.lbll8.BackColor == Color.Red)
            {
                this.lbll8.BackColor = Color.Orange;
            }
            if (this.lblf8.BackColor == Color.Red)
            {
                this.lblf8.BackColor = Color.Orange;
            }
            if (this.lbls8.BackColor == Color.Red)
            {
                this.lbls8.BackColor = Color.Orange;
            }
            if (this.lblp8.BackColor == Color.Red)
            {
                this.lblp8.BackColor = Color.Orange;
            }
            //Sewing Cell9
            if (this.lbll9.BackColor == Color.Red)
            {
                this.lbll9.BackColor = Color.Orange;
            }
            if (this.lblf9.BackColor == Color.Red)
            {
                this.lblf9.BackColor = Color.Orange;
            }
            if (this.lbls9.BackColor == Color.Red)
            {
                this.lbls9.BackColor = Color.Orange;
            }
            if (this.lblp9.BackColor == Color.Red)
            {
                this.lblp9.BackColor = Color.Orange;
            }
            //Sewing Cell10
            if (this.lbllsofa.BackColor == Color.Red)
            {
                this.lbllsofa.BackColor = Color.Orange;
            }
            if (this.lblfsofa.BackColor == Color.Red)
            {
                this.lblfsofa.BackColor = Color.Orange;
            }
            if (this.lblssofa.BackColor == Color.Red)
            {
                this.lblssofa.BackColor = Color.Orange;
            }
            if (this.lblp10.BackColor == Color.Red)
            {
                this.lblp10.BackColor = Color.Orange;
            }
            //Sewing Cell11
            if (this.lbllrsofa.BackColor == Color.Red)
            {
                this.lbllrsofa.BackColor = Color.Orange;
            }
            if (this.lblfrsofa.BackColor == Color.Red)
            {
                this.lblfrsofa.BackColor = Color.Orange;
            }
            if (this.lblsrsofa.BackColor == Color.Red)
            {
                this.lblsrsofa.BackColor = Color.Orange;
            }
            if (this.lblp11.BackColor == Color.Red)
            {
                this.lblp11.BackColor = Color.Orange;
            }
            //Sewing Cell12
            if (this.lbllt.BackColor == Color.Red)
            {
                this.lbllt.BackColor = Color.Orange;
            }
            if (this.lblft.BackColor == Color.Red)
            {
                this.lblft.BackColor = Color.Orange;
            }
            if (this.lblst.BackColor == Color.Red)
            {
                this.lblst.BackColor = Color.Orange;
            }
            if (this.lblp12.BackColor == Color.Red)
            {
                this.lblp12.BackColor = Color.Orange;
            }

        }

        private void timecolor_Tick(object sender, EventArgs e)
        {
            timecolor.Start();
            string resulttime = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            this.lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.lbltime.Text = resulttime;

            if (CGlobal.CkCutShow == "Yes")
            {
                CallSewing1();
                CallSewing2();
                CallSewing3();
                CallSewing4();
                CallSewing5();
                CallSewing6();
                CallSewing7();
                CallSewing8();
                CallSewing9();
                CallSewingsofa();
                CallSewingrsofa();
                CallSewingt();
                CGlobal.CkCutShow = "No";
            }

            //Sewing Cell1
            if (this.lbll1.BackColor == Color.Orange)
            {
                this.lbll1.BackColor = Color.Red;
            }
            if (this.lblf1.BackColor == Color.Orange)
            {
                this.lblf1.BackColor = Color.Red;
            }
            if (this.lbls1.BackColor == Color.Orange)
            {
                this.lbls1.BackColor = Color.Red;
            }
            if (this.lblp1.BackColor == Color.Orange)
            {
                this.lblp1.BackColor = Color.Red;
            }
            //Sewing Cell2
            if (this.lbll2.BackColor == Color.Orange)
            {
                this.lbll2.BackColor = Color.Red;
            }
            if (this.lblf2.BackColor == Color.Orange)
            {
                this.lblf2.BackColor = Color.Red;
            }
            if (this.lbls2.BackColor == Color.Orange)
            {
                this.lbls2.BackColor = Color.Red;
            }
            if (this.lblp2.BackColor == Color.Orange)
            {
                this.lblp2.BackColor = Color.Red;
            }
            //Sewing Cell3
            if (this.lbll3.BackColor == Color.Orange)
            {
                this.lbll3.BackColor = Color.Red;
            }
            if (this.lblf3.BackColor == Color.Orange)
            {
                this.lblf3.BackColor = Color.Red;
            }
            if (this.lbls3.BackColor == Color.Orange)
            {
                this.lbls3.BackColor = Color.Red;
            }
            if (this.lblp3.BackColor == Color.Orange)
            {
                this.lblp3.BackColor = Color.Red;
            }
            //Sewing Cell4
            if (this.lbll4.BackColor == Color.Orange)
            {
                this.lbll4.BackColor = Color.Red;
            }
            if (this.lblf4.BackColor == Color.Orange)
            {
                this.lblf4.BackColor = Color.Red;
            }
            if (this.lbls4.BackColor == Color.Orange)
            {
                this.lbls4.BackColor = Color.Red;
            }
            if (this.lblp4.BackColor == Color.Orange)
            {
                this.lblp4.BackColor = Color.Red;
            }
            //Sewing Cell5
            if (this.lbll5.BackColor == Color.Orange)
            {
                this.lbll5.BackColor = Color.Red;
            }
            if (this.lblf5.BackColor == Color.Orange)
            {
                this.lblf5.BackColor = Color.Red;
            }
            if (this.lbls5.BackColor == Color.Orange)
            {
                this.lbls5.BackColor = Color.Red;
            }
            if (this.lblp5.BackColor == Color.Orange)
            {
                this.lblp5.BackColor = Color.Red;
            }

            //Sewing Cell6
            if (this.lbll6.BackColor == Color.Orange)
            {
                this.lbll6.BackColor = Color.Red;
            }
            if (this.lblf6.BackColor == Color.Orange)
            {
                this.lblf6.BackColor = Color.Red;
            }
            if (this.lbls6.BackColor == Color.Orange)
            {
                this.lbls6.BackColor = Color.Red;
            }
            if (this.lblp6.BackColor == Color.Orange)
            {
                this.lblp6.BackColor = Color.Red;
            }
            //Sewing Cell7
            if (this.lbll7.BackColor == Color.Orange)
            {
                this.lbll7.BackColor = Color.Red;
            }
            if (this.lblf7.BackColor == Color.Orange)
            {
                this.lblf7.BackColor = Color.Red;
            }
            if (this.lbls7.BackColor == Color.Orange)
            {
                this.lbls7.BackColor = Color.Red;
            }
            if (this.lblp7.BackColor == Color.Orange)
            {
                this.lblp7.BackColor = Color.Red;
            }
            //Sewing Cell8
            if (this.lbll8.BackColor == Color.Orange)
            {
                this.lbll8.BackColor = Color.Red;
            }
            if (this.lblf8.BackColor == Color.Orange)
            {
                this.lblf8.BackColor = Color.Red;
            }
            if (this.lbls8.BackColor == Color.Orange)
            {
                this.lbls8.BackColor = Color.Red;
            }
            if (this.lblp8.BackColor == Color.Orange)
            {
                this.lblp8.BackColor = Color.Red;
            }
            //Sewing Cell9
            if (this.lbll9.BackColor == Color.Orange)
            {
                this.lbll9.BackColor = Color.Red;
            }
            if (this.lblf9.BackColor == Color.Orange)
            {
                this.lblf9.BackColor = Color.Red;
            }
            if (this.lbls9.BackColor == Color.Orange)
            {
                this.lbls9.BackColor = Color.Red;
            }
            if (this.lblp9.BackColor == Color.Orange)
            {
                this.lblp9.BackColor = Color.Red;
            }
            //Sewing Cell10
            if (this.lbllsofa.BackColor == Color.Orange)
            {
                this.lbllsofa.BackColor = Color.Red;
            }
            if (this.lblfsofa.BackColor == Color.Orange)
            {
                this.lblfsofa.BackColor = Color.Red;
            }
            if (this.lblssofa.BackColor == Color.Orange)
            {
                this.lblssofa.BackColor = Color.Red;
            }
            if (this.lblp10.BackColor == Color.Orange)
            {
                this.lblp10.BackColor = Color.Red;
            }
            //Sewing Cell11
            if (this.lbllrsofa.BackColor == Color.Orange)
            {
                this.lbllrsofa.BackColor = Color.Red;
            }
            if (this.lblfrsofa.BackColor == Color.Orange)
            {
                this.lblfrsofa.BackColor = Color.Red;
            }
            if (this.lblsrsofa.BackColor == Color.Orange)
            {
                this.lblsrsofa.BackColor = Color.Red;
            }
            if (this.lblp11.BackColor == Color.Orange)
            {
                this.lblp11.BackColor = Color.Red;
            }
            //Sewing Cell12
            if (this.lbllt.BackColor == Color.Orange)
            {
                this.lbllt.BackColor = Color.Red;
            }
            if (this.lblft.BackColor == Color.Orange)
            {
                this.lblft.BackColor = Color.Red;
            }
            if (this.lblst.BackColor == Color.Orange)
            {
                this.lblst.BackColor = Color.Red;
            }
            if (this.lblp12.BackColor == Color.Orange)
            {
                this.lblp12.BackColor = Color.Red;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            CallSewing1();
            CallSewing2();
            CallSewing3();
            CallSewing4();
            CallSewing5();
            CallSewing6();
            CallSewing7();
            CallSewing8();
            CallSewing9();
            CallSewingsofa();
            CallSewingrsofa();
            CallSewingt();
        }

    }
}
