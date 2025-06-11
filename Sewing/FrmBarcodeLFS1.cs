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
    public partial class FrmBarcodeLFS1 : Form
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
        Boolean Isfindck1 = false;
        public FrmBarcodeLFS1()
        {
            InitializeComponent();
        }


        #region " CallDetail();"
        private void CallDetail()
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();



                string strSQL1 = "";

                strSQL1 = "  select DocNo,Cellname from dbo.Sewing_Schedule where QtyIn <> QtyOut   and ckstatusall is null order by DocNo";

                if (Isfindck1 == true)
                {
                    ds.Tables["style11"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "style11");
                //*** DropDownList ***// 
                if (ds.Tables["style11"].Rows.Count != 0)
                {
                    Isfindck1 = true;
                    this.CboLine.DisplayMember = "DocNo";
                    this.CboLine.ValueMember = "DocNo";
                    this.CboLine.DataSource = ds.Tables["style11"];

                    this.CboLine.SelectedValue = "2";

                }
                else
                {
                    Isfindck1 = false;
                    this.CboLine.DataSource = null;
                }

                da = null;
                conn.Close();
                conn = null;
            }
            catch (Exception ex)
            {


            }
        }

        #endregion

        private void FrmBarcodeLFS1_Load(object sender, EventArgs e)
        {
            ToolStripStatusForm.Text = CGlobal.UserID;
            ToolStripStatusVersionName.Text = CGlobal.Username;
            ToolStripStatusUserName.Text = CGlobal.EmpPost;

            lblcell.Text = CGlobal.EmpPost + "(Q6):";
            CallDetail();
            CallSewing1();
            CkCallSewing1();

            CallSewing2();
            CkCallSewing2();

            CallSewing3();
            CkCallSewing3();

            CallSewing4();
            CkCallSewing4();

            CallSewing5();
            CkCallSewing5();

            CallSewing6();
            CkCallSewing6();

            CallSewing7();
            CkCallSewing7();

            CallSewing8();
            CkCallSewing8();

            CallSewing9();
            CkCallSewing9();

            CallSewingsofa();
            CkCallSewingsofa();

            CallSewingrsofa();
            CkCallSewingrsofa();

            CallSewingt();
            CkCallSewingt();

            txtbarcode.Focus();

        
        }

        #region "clear"
        private void Clearall()
        {
            this.lblcell1.Text = "";
            this.lblcell2.Text = "";
            this.lblcell3.Text = "";
            this.lblcell4.Text = "";
            this.lblcell5.Text = "";
            this.lblcell6.Text = "";
            this.lblcell7.Text = "";
            this.lblcell8.Text = "";
            this.lblcell9.Text = "";
            lblcellsofa.Text = "";
            lblcellrsofa.Text  = "";
            lblcellt.Text = "";

            this.lbll1.BackColor = Color.SeaShell;
            this.lblf1.BackColor = Color.SeaShell;
            this.lbls1.BackColor = Color.SeaShell;
            this.lblp1.BackColor = Color.SeaShell;

            this.lbll2.BackColor = Color.SeaShell;
            this.lblf2.BackColor = Color.SeaShell;
            this.lbls2.BackColor = Color.SeaShell;
            this.lblp2.BackColor = Color.SeaShell;

            this.lbll3.BackColor = Color.SeaShell;
            this.lblf3.BackColor = Color.SeaShell;
            this.lbls3.BackColor = Color.SeaShell;
            this.lblp3.BackColor = Color.SeaShell;

            this.lbll4.BackColor = Color.SeaShell;
            this.lblf4.BackColor = Color.SeaShell;
            this.lbls4.BackColor = Color.SeaShell;
            this.lblp4.BackColor = Color.SeaShell;

            this.lbll5.BackColor = Color.SeaShell;
            this.lblf5.BackColor = Color.SeaShell;
            this.lbls5.BackColor = Color.SeaShell;
            this.lblp5.BackColor = Color.SeaShell;

            this.lbll6.BackColor = Color.SeaShell;
            this.lblf6.BackColor = Color.SeaShell;
            this.lbls6.BackColor = Color.SeaShell;
            this.lblp6.BackColor = Color.SeaShell;

            this.lbll7.BackColor = Color.SeaShell;
            this.lblf7.BackColor = Color.SeaShell;
            this.lbls7.BackColor = Color.SeaShell;
            this.lblp7.BackColor = Color.SeaShell;

            this.lbll8.BackColor = Color.SeaShell;
            this.lblf8.BackColor = Color.SeaShell;
            this.lbls8.BackColor = Color.SeaShell;
            this.lblp8.BackColor = Color.SeaShell;

            this.lbll9.BackColor = Color.SeaShell;
            this.lblf9.BackColor = Color.SeaShell;
            this.lbls9.BackColor = Color.SeaShell;
            this.lblp9.BackColor = Color.SeaShell;

            this.lbllsofa.BackColor = Color.SeaShell;
            this.lblfsofa.BackColor = Color.SeaShell;
            this.lblssofa.BackColor = Color.SeaShell;
            this.lblp10.BackColor = Color.SeaShell;

            this.lbllrsofa.BackColor = Color.SeaShell;
            this.lblfrsofa.BackColor = Color.SeaShell;
            this.lblsrsofa.BackColor = Color.SeaShell;
            this.lblp11.BackColor = Color.SeaShell;

            this.lbllt.BackColor = Color.SeaShell;
            this.lblft.BackColor = Color.SeaShell;
            this.lblst.BackColor = Color.SeaShell;
            this.lblp12.BackColor = Color.SeaShell;

        }
        #endregion

        #region " CallSewing1()"
        private void  CallSewing1()
        {
            this.Sewing1.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
               
                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 1' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 1' )  "
                + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
                
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
                    this.Sewing1.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing1"].Rows.Count; i++)
                    {
                        string CkStatusAll = ds.Tables["CellSewing1"].Rows[i]["CkStatusAll"].ToString();
                         if (i == 5)
                        {

                            lblcell1.Text = ds.Tables["CellSewing1"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind1 = false;
                    this.Sewing1.DataSource = null;
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
        #region "CkCallSewing1"
        private void CkCallSewing1()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 1' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                       string CkStatusAll = rs["CkStatusAll"].ToString();
                       lblcell1.Text = rs["Docno"].ToString();
                       string StatusL = rs["StatusL"].ToString();
                       string StatusF = rs["StatusF"].ToString();
                       string StatusS = rs["StatusS"].ToString();
                       string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data No Data  Cell 1");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing2()"
        private void CallSewing2()
        {
            this.Sewing2.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 2'  and Sequence between '4' and '8' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS,  ISNULL(CkStatusAll, 3 ) As CkStatusAll,"
               + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 2' )  "
               + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
               + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing2.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing2"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                     
                            lblcell2.Text = ds.Tables["CellSewing2"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind2 = false;
                    this.Sewing2.DataSource = null;
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
        #region "CkCallSewing2"
        private void CkCallSewing2()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 2' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell2.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 2");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing3()"
        private void CallSewing3()
        {
            this.Sewing3.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
              //  strSQL1 = " Select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 3'  and Sequence between '4' and '8' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
              + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 3' )  "
              + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
              + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing3.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing3"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                            lblcell3.Text = ds.Tables["CellSewing3"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind3 = false;
                    this.Sewing3.DataSource = null;
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
        #region "CkCallSewing3"
        private void CkCallSewing3()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 3' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell3.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 3");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing4()"
        private void CallSewing4()
        {
            this.Sewing4.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, -0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 4'  and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
           + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 4' )  "
           + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
           + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing4.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing4"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                     
                            lblcell4.Text = ds.Tables["CellSewing4"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind4 = false;
                    this.Sewing4.DataSource = null;
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
        #region "CkCallSewing4"
        private void CkCallSewing4()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 4' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell4.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 4");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing5()"
        private void CallSewing5()
        {
            this.Sewing5.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 5' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                          + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 5' )  "
                          + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                          + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1  order by Sequence ";
                if (Isfind5 == true)
                {
                    ds.Tables["CellSewing5"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellSewing5");

                if (ds.Tables["CellSewing5"].Rows.Count != 0)
                {
                    Isfind5 = true;
                    dt = ds.Tables["CellSewing5"];
                    this.Sewing5.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing5"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                     
                            lblcell5.Text = ds.Tables["CellSewing5"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind5 = false;
                    this.Sewing5.DataSource = null;
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
        #region "CkCallSewing5"
        private void CkCallSewing5()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 5' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell5.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 5");
            }
            conn.Close();
        }
        #endregion
       
        #region " CallSewing6()"
        private void CallSewing6()
        {
            this.Sewing6.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 6' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 6' )  "
                        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing5.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing6"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {

                            lblcell6.Text = ds.Tables["CellSewing6"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind6 = false;
                    this.Sewing6.DataSource = null;
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
        #region "CkCallSewing6"
        private void CkCallSewing6()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 6' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell6.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 6");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing7()"
        private void CallSewing7()
        {
            this.Sewing7.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 7' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 7' )  "
                        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing5.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing7"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
  
                            lblcell7.Text = ds.Tables["CellSewing7"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind7 = false;
                    this.Sewing7.DataSource = null;
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
        #region "CkCallSewing7"
        private void CkCallSewing7()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 7' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell7.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 7");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing8()"
        private void CallSewing8()
        {
            this.Sewing8.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 8' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Cell Sewing 8' )  "
                        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing8.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing8"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
            
                            lblcell8.Text = ds.Tables["CellSewing8"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind8 = false;
                    this.Sewing8.DataSource = null;
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
        #region "CkCallSewing8"
        private void CkCallSewing8()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Cell Sewing 8' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell8.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 8");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewing9()"
        private void CallSewing9()
        {
            this.Sewing9.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                //strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 3' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                        + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 3' )  "
                        + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                        + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9  and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing9.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewing9"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {

                            lblcell9.Text = ds.Tables["CellSewing9"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfind9 = false;
                    this.Sewing9.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 9");
            }
            conn.Close();

        }
        #endregion
        #region "CkCallSewing9"
        private void CkCallSewing9()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Sewing 3' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcell9.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 9");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewingsofa()"
        private void CallSewingsofa()
        {
            this.Sewingsofa.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
              //  strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 2'  and Sequence between '4' and '8' order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                      + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 2' )  "
                      + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                      + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewingsofa.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewings"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
              
                            lblcellsofa.Text = ds.Tables["CellSewings"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfinds = false;
                    this.Sewingsofa.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 10");
            }
            conn.Close();

        }
        #endregion
        #region "CkCallSewingSofa"
        private void CkCallSewingsofa()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Sewing 2' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcellsofa.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  sofa");
            }
            conn.Close();
        }
        #endregion

        #region " CallSewingrsofa()"
        private void CallSewingrsofa()
        {
            this.Sewingrsofa.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
               // strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 1' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                 + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Sewing 1' )  "
                 + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                 + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewingrsofa.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewingr"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
            
                            lblcellrsofa.Text = ds.Tables["CellSewingr"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfindr = false;
                    this.Sewingrsofa.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 11");
            }
            conn.Close();

        }
        #endregion
        #region "CkCallSewingrSofa"
        private void CkCallSewingrsofa()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Sewing 1' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcellrsofa.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Rsofa");
            }
            conn.Close();
        }
        #endregion


        #region " CallSewingt()"
        private void CallSewingt()
        {
            this.Sewingt.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
              //  strSQL1 = " select Startday,Docno,Sequence,ISNULL(StatusL, 0 ) As StatusL, ISNULL(StatusF, 0 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS from dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Training Sewing' and Sequence between '4' and '8'  order by Sequence ";
                strSQL1 = " WITH Cell AS ( SELECT Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, "
                + " ROW_NUMBER() OVER (ORDER BY Sequence) AS RowNumber, ISNULL(StatusP, 3 ) As StatusP   FROM dbo.Sewing_Schedule  where  Qtyin<>Qtyout  and Cellname='Training Sewing' )  "
                + " SELECT RowNumber,Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP  "
                + " FROM Cell   WHERE RowNumber BETWEEN 4 AND 9 and CkStatusAll=1 order by Sequence ";
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
                    this.Sewing9.DataSource = dt;

                    for (int i = 0; i < ds.Tables["CellSewingt"].Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                           
                            lblcellt.Text = ds.Tables["CellSewingt"].Rows[i]["Docno"].ToString();
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
                        }

                    }
                }
                else
                {
                    Isfindt = false;
                    this.Sewingt.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("No Data  show T");
            }
            conn.Close();

        }
        #endregion
        #region "CkCallSewingt"
        private void CkCallSewingt()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select top 1 Startday,Docno,Sequence,ISNULL(StatusL, 3 ) As StatusL, ISNULL(StatusF, 3 ) As StatusF, ISNULL(StatusS, 0 ) As StatusS, ISNULL(CkStatusAll, 3 ) As CkStatusAll, ISNULL(StatusP, 3 ) As StatusP "
                     + " from dbo.Sewing_Schedule where qtyin<>qtyout and Cellname='Training Sewing' and ISNULL(CkStatusAll, 3 )= 3 order by Sequence", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {

                    string CkStatusAll = rs["CkStatusAll"].ToString();
                    lblcellt.Text = rs["Docno"].ToString();
                    string StatusL = rs["StatusL"].ToString();
                    string StatusF = rs["StatusF"].ToString();
                    string StatusS = rs["StatusS"].ToString();
                    string StatusP = rs["StatusP"].ToString();
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
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Training Sewing");
            }
            conn.Close();
        }
        #endregion


        #region "key number gridview"
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);

        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView3_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView4_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView5_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView6_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView7_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView8_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView9_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);  .ForeColor = Drawing.Color.Blue;
                e.DisplayText = "Q" + Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        #endregion

        static string MinifyA(string p)
        {
            p = p.Replace("  ", string.Empty);
            p = p.Replace(Environment.NewLine, string.Empty);
            //p = p.Replace("\\t", string.Empty);
            //p = p.Replace(" {", "{");
            //p = p.Replace(" :", ":");
            p = p.Replace("%", "(");
            p = p.Replace("-0A", ")");
            p = p.Replace("+", "#");
            // p = p.Replace(";}", "}");
            return p;
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e) 
    {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtbarcode.Text == "")
                {
                    MessageBox.Show("No Barcode " + lblcell.Text.Trim());
                    return;
                }
                string tempsql1 = MinifyA(this.txtbarcode.Text.Trim());
                this.txtbarcode.Text = tempsql1;
                CGlobal.CkBarcodeStatus = "N";
                if (lblcell1.Text.Trim() ==this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell2.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell3.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell4.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell5.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell6.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell7.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell8.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcell9.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcellsofa.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcellrsofa.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if (lblcellt.Text.Trim() == this.txtbarcode.Text.Trim())
                {
                    CGlobal.CkBarcodeStatus = "Y";
                }
                if  (CGlobal.CkBarcodeStatus=="Y")
                {
                    //MessageBox.Show("ok");
                    var query = new StringBuilder();
                    query.Append("UPDATE  dbo.Sewing_Schedule SET");
                    if (CGlobal.EmpPost == "Leather")
                    { 
                        query.Append(" StatusL  = @Status");
                        query.Append(" WHERE docno =  @docno");
                        query.Append(" and StatusL <>3");
                    }
                    else if (CGlobal.EmpPost == "Fabric")
                    { 
                        query.Append(" StatusF  = @Status");
                        query.Append(" WHERE docno =  @docno");
                        query.Append(" and StatusF <>3");
                    }
                    else if (CGlobal.EmpPost == "Support")
                    { 
                        query.Append(" StatusS  = @Status");
                        query.Append(" WHERE docno =  @docno");
                    }
                    else if (CGlobal.EmpPost == "PVC")
                    {
                        query.Append(" StatusP  = @Status");
                        query.Append(" WHERE docno =  @docno");
                        query.Append(" and StatusP <>3");
                    }
                    using (var db = new DbHelper1())
                    {
                        try
                        {
                            db.AddParameter("@docno", this.txtbarcode.Text.Trim());
                            db.AddParameter("@Status", 1);
                            db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show("Error" + ex);
                            MessageBox.Show("No Insert Sewing_Schedule PO#(Q6) : " + lblcell.Text.Trim());
                            this.txtbarcode.Text = "";
                            this.txtbarcode.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Barcode PO#(Q6) : " + lblcell.Text.Trim());
                    this.txtbarcode.Text = "";
                    this.txtbarcode.Focus();
                    return;
                }
                Clearall();

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

                CkCallSewing1();
                CkCallSewing2();
                CkCallSewing3();
                CkCallSewing4();
                CkCallSewing5();
                CkCallSewing6();
                CkCallSewing7();
                CkCallSewing8();
                CkCallSewing9();
                CkCallSewingsofa();
                CkCallSewingrsofa();
                CkCallSewingt();
                CGlobal.CkCutShow = "Yes";
            

                MessageBox.Show("Barcode Complete");
                this.txtbarcode.Text = "";
                this.cklbl.Visible = false;

            }
        }

        private void bntlogoff_Click(object sender, EventArgs e)
        {
            Sewing.FrmBarcodeLFS page = new Sewing.FrmBarcodeLFS();  //Sewing                  
            page.Show();
            this.Hide();
        }

        private void CboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbarcode.Text = this.CboLine.Text.Trim();
           this.cklbl.Visible =true;
           this.txtbarcode.Focus();
        }

        private void lblf1_Click(object sender, EventArgs e)
        {

        }
       
    
    }
}
