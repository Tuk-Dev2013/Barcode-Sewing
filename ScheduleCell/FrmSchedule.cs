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

namespace PicklistBOM.ScheduleCell
{
    public partial class FrmSchedule : Form
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
        Boolean Isfind11 = false;
        Boolean Isfind12 = false;
        Boolean Isfind13 = false;
        Boolean Isfind14 = false;
        Boolean Isfind15 = false;
        Boolean Isfind16 = false;
        Boolean Isfind17 = false;
        Boolean Isfind18 = false;
        public FrmSchedule()
        {
            InitializeComponent();
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet8.View_PORefQty' table. You can move, or remove it, as needed.
            this.view_PORefQtyTableAdapter.Fill(this.dBBARCODEDataSet8.View_PORefQty);
            // TODO: This line of code loads data into the 'dBBARCODEDataSet7.A_CellType' table. You can move, or remove it, as needed.
            this.a_CellTypeTableAdapter.Fill(this.dBBARCODEDataSet7.A_CellType);
            // TODO: This line of code loads data into the 'dBBARCODEDataSet6.View_DocOrder' table. You can move, or remove it, as needed.
            //   this.view_DocOrderTableAdapter.Fill(this.dBBARCODEDataSet6.View_DocOrder);

            //showcell
            ShowCell0();
            ShowCellT2();
            ShowCell1();
            ShowCell2();
            ShowCell3();
            ShowCell4();
            ShowCell5();
            ShowCell6();
            ShowCell7();

            ShowCell8();
            ShowCell9();
            ShowCell10();
            ShowCell11();

            ShowCell12();
            ShowCell13();
            ShowCell14();
            ShowCell15();
            ShowCellS1();
        }

        #region "  ShowCell0();"
        private void ShowCell0()
        {
            this.ShowCellT.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL TRAINING' and QtyIn<>QtyOut  order by ScheduleID";
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
                    ShowCellT.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                    this.ShowCellT.DataSource = null;

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

        #region "  ShowCellT2();"
        private void ShowCellT2()
        {
            this.ShowCellT21.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL T2' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind12 == true)
                {
                    ds.Tables["ShowdataT2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "ShowdataT2");

                if (ds.Tables["ShowdataT2"].Rows.Count != 0)
                {
                    Isfind12 = true;
                    dt = ds.Tables["ShowdataT2"];
                    ShowCellT21.DataSource = dt;
                }
                else
                {
                    Isfind12 = false;
                    this.ShowCellT21.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show 12");
            }
            conn.Close();


        }

        #endregion

        #region "ShowCell1"
        private void ShowCell1()
        {
            this.Cell1.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 1' and QtyIn<>QtyOut  order by ScheduleID";
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
                    Cell1.DataSource = dt;
                }
                else
                {
                    Isfind2 = false;
                    this.Cell1.DataSource = null;
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

        #region "ShowCell2"
        private void ShowCell2()
        {
            this.Cell2.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 2' and QtyIn<>QtyOut  order by ScheduleID";
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
                    Cell2.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.Cell2.DataSource = null;
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

        #region "ShowCell3"
        private void ShowCell3()
        {
            this.Cell3.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 3' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind3 == true)
                {
                    ds.Tables["Cell3"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell3");

                if (ds.Tables["Cell3"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["Cell3"];
                    Cell3.DataSource = dt;
                }
                else
                {
                    Isfind3 = false;
                    this.Cell3.DataSource = null;
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

        #region "ShowCell4"
        private void ShowCell4()
        {
            this.Cell4.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 4' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind4 == true)
                {
                    ds.Tables["Cell4"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell4");

                if (ds.Tables["Cell4"].Rows.Count != 0)
                {
                    Isfind4 = true;
                    dt = ds.Tables["Cell4"];
                    Cell4.DataSource = dt;
                }
                else
                {
                    Isfind4 = false;
                    this.Cell4.DataSource = null;
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

        #region "ShowCell5"
        private void ShowCell5()
        {
            this.Cell5.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 5' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind5 == true)
                {
                    ds.Tables["Cell5"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell5");

                if (ds.Tables["Cell5"].Rows.Count != 0)
                {
                    Isfind5 = true;
                    dt = ds.Tables["Cell5"];
                    Cell5.DataSource = dt;
                }
                else
                {
                    Isfind5 = false;
                    this.Cell5.DataSource = null;
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

        #region "ShowCell6"
        private void ShowCell6()
        {
            this.Cell6.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 6' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind6 == true)
                {
                    ds.Tables["Cell6"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell6");

                if (ds.Tables["Cell6"].Rows.Count != 0)
                {
                    Isfind6 = true;
                    dt = ds.Tables["Cell6"];
                    Cell6.DataSource = dt;
                }
                else
                {
                    Isfind6 = false;
                    this.Cell6.DataSource = null;
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

        #region "ShowCell7"
        private void ShowCell7()
        {
            this.Cell7.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 7' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind7 == true)
                {
                    ds.Tables["Cell7"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell7");

                if (ds.Tables["Cell7"].Rows.Count != 0)
                {
                    Isfind7 = true;
                    dt = ds.Tables["Cell7"];
                    Cell7.DataSource = dt;
                }
                else
                {
                    Isfind7 = false;
                    this.Cell7.DataSource = null;
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

        #region "ShowCell8"
        private void ShowCell8()
        {
            this.Cell8.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 8' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind8 == true)
                {
                    ds.Tables["Cell8"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell8");

                if (ds.Tables["Cell8"].Rows.Count != 0)
                {
                    Isfind8 = true;
                    dt = ds.Tables["Cell8"];
                    Cell8.DataSource = dt;
                }
                else
                {
                    Isfind8 = false;
                    this.Cell8.DataSource = null;
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

        #region "ShowCell9"
        private void ShowCell9()
        {
            this.Cell9.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 9' and QtyIn<>QtyOut  order by ScheduleID";
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
                    Cell9.DataSource = dt;
                }
                else
                {
                    Isfind9 = false;
                    this.Cell9.DataSource = null;
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

        #region "ShowCell10"
        private void ShowCell10()
        {
            this.Cell10.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 10' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind10 == true)
                {
                    ds.Tables["Cell10"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell10");

                if (ds.Tables["Cell10"].Rows.Count != 0)
                {
                    Isfind10 = true;
                    dt = ds.Tables["Cell10"];
                    Cell10.DataSource = dt;
                }
                else
                {
                    Isfind10 = false;
                    this.Cell10.DataSource = null;
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


        #region "ShowCell11"
        private void ShowCell11()
        {
            this.Cell11.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 11' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind11 == true)
                {
                    ds.Tables["Cell11"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell11");

                if (ds.Tables["Cell11"].Rows.Count != 0)
                {
                    Isfind11 = true;
                    dt = ds.Tables["Cell11"];
                    Cell11.DataSource = dt;
                }
                else
                {
                    Isfind11 = false;
                    this.Cell11.DataSource = null;
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

        #region "ShowCell12"
        private void ShowCell12()
        {
            this.Cell12.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 12' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind13 == true)
                {
                    ds.Tables["Cell12"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell12");

                if (ds.Tables["Cell12"].Rows.Count != 0)
                {
                    Isfind13 = true;
                    dt = ds.Tables["Cell12"];
                    Cell12.DataSource = dt;
                }
                else
                {
                    Isfind13 = false;
                    this.Cell12.DataSource = null;
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

        #region "ShowCell13"
        private void ShowCell13()
        {
            this.Cell13.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 13' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind14 == true)
                {
                    ds.Tables["Cell13"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell13");

                if (ds.Tables["Cell13"].Rows.Count != 0)
                {
                    Isfind14 = true;
                    dt = ds.Tables["Cell13"];
                    Cell13.DataSource = dt;
                }
                else
                {
                    Isfind14 = false;
                    this.Cell13.DataSource = null;
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

        #region "ShowCell14"
        private void ShowCell14()
        {
            this.Cell14.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 14' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind15 == true)
                {
                    ds.Tables["Cell14"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell14");

                if (ds.Tables["Cell14"].Rows.Count != 0)
                {
                    Isfind15 = true;
                    dt = ds.Tables["Cell14"];
                    Cell14.DataSource = dt;
                }
                else
                {
                    Isfind15 = false;
                    this.Cell14.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 14");
            }
            conn.Close();
        }
        #endregion

        #region "ShowCell15"
        private void ShowCell15()
        {
            this.Cell15.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL 15' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind16 == true)
                {
                    ds.Tables["Cell15"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Cell15");

                if (ds.Tables["Cell15"].Rows.Count != 0)
                {
                    Isfind16 = true;
                    dt = ds.Tables["Cell15"];
                    Cell15.DataSource = dt;
                }
                else
                {
                    Isfind16 = false;
                    this.Cell15.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell 15");
            }
            conn.Close();
        }
        #endregion

        #region "ShowCellS1"
        private void ShowCellS1()
        {
            this.CellS1.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select Sequence,POnumber,QtyIn,Cellname FROM A_ScheduleCell where Cellname ='CELL S1' and QtyIn<>QtyOut  order by ScheduleID";
                if (Isfind17 == true)
                {
                    ds.Tables["CellS1"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "CellS1");

                if (ds.Tables["CellS1"].Rows.Count != 0)
                {
                    Isfind17 = true;
                    dt = ds.Tables["CellS1"];
                    CellS1.DataSource = dt;
                }
                else
                {
                    Isfind17 = false;
                    this.CellS1.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  Cell S1");
            }
            conn.Close();
        }
        #endregion

        #region "check"
        private void CallBarcode()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                Cmd = new System.Data.SqlClient.SqlCommand(" select POnumber from A_ScheduleCell  where POnumber ='" + cboCell.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.tmpcheck10 = "YES";

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }

        #endregion

        #region "CallBarcodeQry"
        private void CallBarcodeQry(string po)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {

                string temp = ConfigurationManager.AppSettings["BomCell"];
             //   Cmd = new System.Data.SqlClient.SqlCommand(" select SUM(qtyBom) as Qty  from dbo.DocMODtl  where DocNo ='" + po + "' and BomNo In (" + temp + ") and ItemCode like 'W8%' and DeptCode='W8' ", conn);

                Cmd = new System.Data.SqlClient.SqlCommand(" select  SUM(docqty)  as Qty  from dbo.DocOrderDtl  where DocNo ='" + po + "' and BomNo In (" + temp + ")", conn);  
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.qtytotalE = rs["Qty"].ToString(); ;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }
        #endregion


        #region "Select PO"
        private void bntadd_Click(object sender, EventArgs e)
        {
            //if (CboS.Text == "")
            //{
            //    MessageBox.Show("กรุณาป้อนข้อมูลให้ครบด้วย");
            //    return;
            //}

            CallBarcode();

            if (CGlobal.tmpcheck10 == "YES")
            {
                MessageBox.Show("คุณป้อน PO ซ้ำ หรือ PO ผลิตจบไปแล้ว");
                CGlobal.tmpcheck10 = "No";
                return;
            }

            if ((MessageBox.Show(" คุณต้องการบันทึก PO#. " + this.cboCell.Text + " ไป . " + this.Cbotype.Text + "   นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO A_ScheduleCell(POnumber, Cellname, QtyIn, QtyOut, Startday, Remark, TempType, Status, Sequence)");
                query.Append(" VALUES (@POnumber, @Cellname, @QtyIn, @QtyOut, @Startday, @Remark, @TempType, @Status, @Sequence)");

                SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn1.Open();
                using (var db = new DbHelper1())
                {
                    try
                    {
                        CallBarcodeQry(cboCell.Text.Trim());
                        DateTime sdate1 = DateTime.Now;
                        string tempdate = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));

                        string tmpstr = "";
                        if (Cbotype.Text.Trim() == "CELL TRAINING2")
                        {
                            tmpstr = "CELL T2";
                        }
                        else
                        {
                            tmpstr = Cbotype.Text.Trim();
                        }


                        db.AddParameter("@POnumber", cboCell.Text.Trim());
                        db.AddParameter("@Cellname", tmpstr);
                        //  db.AddParameter("@QtyIn", cboCell.SelectedValue);
                        db.AddParameter("@QtyIn", CGlobal.qtytotalE);
                        db.AddParameter("@QtyOut", "0");
                        db.AddParameter("@Startday", DateTime.Now);
                        db.AddParameter("@Remark", "");
                        db.AddParameter("@TempType", "");
                        db.AddParameter("@Status", "1");
                        db.AddParameter("@Sequence", CboS.Text.Trim());
                        db.ExecuteNonQuery(query.ToString());
                    }

                    catch (Exception ex)
                    {
                        // db.RollbackTransaction();
                        MessageBox.Show("No Save  Data");

                    }
                }
                conn1.Close();
                CGlobal.qtytotalE = "0";


                ShowCell0();
                ShowCellT2();
                ShowCell1();
                ShowCell2();
                ShowCell3();
                ShowCell4();
                ShowCell5();
                ShowCell6();
                ShowCell7();

                // 19/01/2015
                ShowCell8();
                ShowCell9();
                ShowCell10();
                ShowCell11();


                // 05/09/2015
                ShowCell12();
                ShowCell13();
                ShowCell14();
                ShowCell15();
                ShowCellS1();
            }
        }
        #endregion

        #region "No"
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView3_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView4_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView5_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView6_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView7_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView8_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        #endregion

        #region "delte"

        #region "delete cell0"
        private void ShowCellT_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);

            string DocItem = Convert.ToString(gridView1.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell0();
            }
        }
        #endregion

        #region "delect Cell1"
        private void Cell1_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            DataRow row = gridView2.GetDataRow(index);

            string DocItem = Convert.ToString(gridView2.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell1();
            }
        }
        #endregion

        #region " Delete cell2"
        private void Cell2_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView3.FocusedRowHandle;
            DataRow row = gridView3.GetDataRow(index);

            string DocItem = Convert.ToString(gridView3.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell2();
            }
        }
        #endregion

        #region "delete cell3"
        private void Cell3_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView4.FocusedRowHandle;
            DataRow row = gridView4.GetDataRow(index);

            string DocItem = Convert.ToString(gridView4.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell3();
            }
        }
        #endregion

        #region "Delete cell4"
        private void Cell4_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView5.FocusedRowHandle;
            DataRow row = gridView5.GetDataRow(index);

            string DocItem = Convert.ToString(gridView5.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell4();
            }
        }
        #endregion

        #region "delete Cell5"
        private void Cell5_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView6.FocusedRowHandle;
            DataRow row = gridView6.GetDataRow(index);

            string DocItem = Convert.ToString(gridView6.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell5();
            }
        }
        #endregion


        #region "delete cell6"
        private void Cell6_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView7.FocusedRowHandle;
            DataRow row = gridView7.GetDataRow(index);

            string DocItem = Convert.ToString(gridView7.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell6();
            }
        }
        #endregion

        #region "delete cell7"
        private void Cell7_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView8.FocusedRowHandle;
            DataRow row = gridView8.GetDataRow(index);

            string DocItem = Convert.ToString(gridView8.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell7();
            }
        }
        #endregion

        #endregion


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSchedule));
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Cbotype = new System.Windows.Forms.ComboBox();
            this.aCellTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBARCODEDataSet7 = new PicklistBOM.DBBARCODEDataSet7();
            this.bntadd = new System.Windows.Forms.Button();
            this.cboCell = new System.Windows.Forms.ComboBox();
            this.viewPORefQtyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBARCODEDataSet8 = new PicklistBOM.DBBARCODEDataSet8();
            this.CboS = new System.Windows.Forms.ComboBox();
            this.viewDocOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBARCODEDataSet6 = new PicklistBOM.DBBARCODEDataSet6();
            this.view_DocOrderTableAdapter = new PicklistBOM.DBBARCODEDataSet6TableAdapters.View_DocOrderTableAdapter();
            this.a_CellTypeTableAdapter = new PicklistBOM.DBBARCODEDataSet7TableAdapters.A_CellTypeTableAdapter();
            this.ShowCellT = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DocQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.view_PORefQtyTableAdapter = new PicklistBOM.DBBARCODEDataSet8TableAdapters.View_PORefQtyTableAdapter();
            this.Cell1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView2 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell2 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView3 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell3 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView4 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell4 = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView5 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell5 = new DevExpress.XtraGrid.GridControl();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView6 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell6 = new DevExpress.XtraGrid.GridControl();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView7 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn61 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell7 = new DevExpress.XtraGrid.GridControl();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView8 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn68 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn70 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn71 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cachedReportPODate1 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.cachedReportPODate2 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Cell11 = new DevExpress.XtraGrid.GridControl();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn72 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn73 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn74 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView9 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn75 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn76 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn77 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn78 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn79 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn80 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell10 = new DevExpress.XtraGrid.GridControl();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn81 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn82 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn83 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView10 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn84 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn85 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn86 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn87 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn88 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn89 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell9 = new DevExpress.XtraGrid.GridControl();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn90 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn91 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn92 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView11 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn93 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn95 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell8 = new DevExpress.XtraGrid.GridControl();
            this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn100 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn101 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView12 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn102 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn103 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn104 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn105 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn106 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn107 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Cell12 = new DevExpress.XtraGrid.GridControl();
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn108 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn109 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn110 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView13 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn111 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn112 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn113 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn114 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn115 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn116 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell13 = new DevExpress.XtraGrid.GridControl();
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn117 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn118 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn119 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView14 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn120 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn121 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn122 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn123 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn124 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn125 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell14 = new DevExpress.XtraGrid.GridControl();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn126 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn127 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn128 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView15 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn129 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn130 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn131 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn132 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn133 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn134 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cell15 = new DevExpress.XtraGrid.GridControl();
            this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn135 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn136 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn137 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView16 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn138 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn139 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn140 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn141 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn142 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn143 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CellS1 = new DevExpress.XtraGrid.GridControl();
            this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn144 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn145 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn146 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView17 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn147 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn148 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn149 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn150 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn151 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn152 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShowCellT21 = new DevExpress.XtraGrid.GridControl();
            this.gridView18 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn153 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn154 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn155 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView18 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn156 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn157 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn158 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn159 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn160 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn161 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCellTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPORefQtyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCellT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCellT21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView18)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(2, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 26);
            this.label11.TabIndex = 109;
            this.label11.Text = "CELL T1";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 110;
            this.label1.Text = "Schedule Cell";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(513, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 26);
            this.label2.TabIndex = 111;
            this.label2.Text = "CELL 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(769, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 26);
            this.label3.TabIndex = 112;
            this.label3.Text = "CELL 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(1025, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 26);
            this.label4.TabIndex = 113;
            this.label4.Text = "CELL 3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(4, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 26);
            this.label5.TabIndex = 114;
            this.label5.Text = "CELL 4";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(255, 223);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 26);
            this.label6.TabIndex = 115;
            this.label6.Text = "CELL 5";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(514, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 26);
            this.label7.TabIndex = 116;
            this.label7.Text = "CELL 6";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(776, 222);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 25);
            this.label8.TabIndex = 117;
            this.label8.Text = "CELL 7";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Cbotype);
            this.groupBox1.Controls.Add(this.bntadd);
            this.groupBox1.Controls.Add(this.cboCell);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(220, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 52);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Cell";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(316, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 122;
            this.label10.Text = "Cell. :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 121;
            this.label9.Text = "PO. :";
            // 
            // Cbotype
            // 
            this.Cbotype.DataSource = this.aCellTypeBindingSource;
            this.Cbotype.DisplayMember = "CellName";
            this.Cbotype.FormattingEnabled = true;
            this.Cbotype.Location = new System.Drawing.Point(365, 21);
            this.Cbotype.Name = "Cbotype";
            this.Cbotype.Size = new System.Drawing.Size(134, 24);
            this.Cbotype.TabIndex = 2;
            this.Cbotype.ValueMember = "CellName";
            // 
            // aCellTypeBindingSource
            // 
            this.aCellTypeBindingSource.DataMember = "A_CellType";
            this.aCellTypeBindingSource.DataSource = this.dBBARCODEDataSet7;
            // 
            // dBBARCODEDataSet7
            // 
            this.dBBARCODEDataSet7.DataSetName = "DBBARCODEDataSet7";
            this.dBBARCODEDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bntadd
            // 
            this.bntadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bntadd.Image = ((System.Drawing.Image)(resources.GetObject("bntadd.Image")));
            this.bntadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntadd.Location = new System.Drawing.Point(503, 18);
            this.bntadd.Name = "bntadd";
            this.bntadd.Size = new System.Drawing.Size(86, 29);
            this.bntadd.TabIndex = 1;
            this.bntadd.Text = "Add.";
            this.bntadd.UseVisualStyleBackColor = true;
            this.bntadd.Click += new System.EventHandler(this.bntadd_Click);
            // 
            // cboCell
            // 
            this.cboCell.DataSource = this.viewPORefQtyBindingSource;
            this.cboCell.DisplayMember = "DocRefNo";
            this.cboCell.FormattingEnabled = true;
            this.cboCell.Location = new System.Drawing.Point(48, 23);
            this.cboCell.Name = "cboCell";
            this.cboCell.Size = new System.Drawing.Size(265, 24);
            this.cboCell.TabIndex = 0;
            this.cboCell.ValueMember = "QtyTotal";
            // 
            // viewPORefQtyBindingSource
            // 
            this.viewPORefQtyBindingSource.DataMember = "View_PORefQty";
            this.viewPORefQtyBindingSource.DataSource = this.dBBARCODEDataSet8;
            // 
            // dBBARCODEDataSet8
            // 
            this.dBBARCODEDataSet8.DataSetName = "DBBARCODEDataSet8";
            this.dBBARCODEDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CboS
            // 
            this.CboS.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CboS.FormattingEnabled = true;
            this.CboS.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CboS.Location = new System.Drawing.Point(870, 33);
            this.CboS.Name = "CboS";
            this.CboS.Size = new System.Drawing.Size(73, 21);
            this.CboS.TabIndex = 120;
            this.CboS.Visible = false;
            // 
            // viewDocOrderBindingSource
            // 
            this.viewDocOrderBindingSource.DataMember = "View_DocOrder";
            this.viewDocOrderBindingSource.DataSource = this.dBBARCODEDataSet6;
            // 
            // dBBARCODEDataSet6
            // 
            this.dBBARCODEDataSet6.DataSetName = "DBBARCODEDataSet6";
            this.dBBARCODEDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_DocOrderTableAdapter
            // 
            this.view_DocOrderTableAdapter.ClearBeforeFill = true;
            // 
            // a_CellTypeTableAdapter
            // 
            this.a_CellTypeTableAdapter.ClearBeforeFill = true;
            // 
            // ShowCellT
            // 
            this.ShowCellT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ShowCellT.Location = new System.Drawing.Point(3, 93);
            this.ShowCellT.MainView = this.gridView1;
            this.ShowCellT.Name = "ShowCellT";
            this.ShowCellT.Size = new System.Drawing.Size(249, 126);
            this.ShowCellT.TabIndex = 119;
            this.ShowCellT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.cardView1});
            this.ShowCellT.DoubleClick += new System.EventHandler(this.ShowCellT_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.DocQty});
            this.gridView1.GridControl = this.ShowCellT;
            this.gridView1.GroupPanelText = "PO Cell Training1";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.ViewCaption = "Show Detail PO Number";
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "No.";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 20;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "PO Number";
            this.gridColumn1.FieldName = "POnumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // DocQty
            // 
            this.DocQty.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DocQty.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.DocQty.AppearanceCell.Options.UseFont = true;
            this.DocQty.AppearanceCell.Options.UseForeColor = true;
            this.DocQty.AppearanceCell.Options.UseTextOptions = true;
            this.DocQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DocQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.DocQty.AppearanceHeader.Options.UseFont = true;
            this.DocQty.AppearanceHeader.Options.UseTextOptions = true;
            this.DocQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DocQty.Caption = "Qty";
            this.DocQty.FieldName = "QtyIn";
            this.DocQty.Name = "DocQty";
            this.DocQty.OptionsColumn.AllowFocus = false;
            this.DocQty.OptionsColumn.ReadOnly = true;
            this.DocQty.Visible = true;
            this.DocQty.VisibleIndex = 2;
            this.DocQty.Width = 40;
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.ShowCellT;
            this.cardView1.Name = "cardView1";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView1.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Line";
            this.gridColumn4.FieldName = "DocLine";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 58;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Item NO.";
            this.gridColumn6.FieldName = "DocItem";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 141;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Description";
            this.gridColumn7.FieldName = "ItemName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 140;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.Caption = "Quantity";
            this.gridColumn8.FieldName = "DocQty";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 106;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Location";
            this.gridColumn9.FieldName = "DocStock";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 71;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Status";
            this.gridColumn10.FieldName = "DocFlag";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 50;
            // 
            // view_PORefQtyTableAdapter
            // 
            this.view_PORefQtyTableAdapter.ClearBeforeFill = true;
            // 
            // Cell1
            // 
            this.Cell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell1.Location = new System.Drawing.Point(518, 93);
            this.Cell1.MainView = this.gridView2;
            this.Cell1.Name = "Cell1";
            this.Cell1.Size = new System.Drawing.Size(249, 125);
            this.Cell1.TabIndex = 120;
            this.Cell1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.cardView2});
            this.Cell1.DoubleClick += new System.EventHandler(this.Cell1_DoubleClick);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView2.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView2.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView2.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView2.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.Preview.Options.UseFont = true;
            this.gridView2.Appearance.Preview.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseForeColor = true;
            this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn11});
            this.gridView2.GridControl = this.Cell1;
            this.gridView2.GroupPanelText = "PO Cell 1";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.ViewCaption = "Show Detail PO Number";
            this.gridView2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView2_CustomColumnDisplayText);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "No.";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 20;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "PO Number";
            this.gridColumn5.FieldName = "POnumber";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn11.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn11.Caption = "Qty";
            this.gridColumn11.FieldName = "QtyIn";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 40;
            // 
            // cardView2
            // 
            this.cardView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.cardView2.FocusedCardTopFieldIndex = 0;
            this.cardView2.GridControl = this.Cell1;
            this.cardView2.Name = "cardView2";
            this.cardView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView2.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "Line";
            this.gridColumn12.FieldName = "DocLine";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 58;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn13.AppearanceHeader.Options.UseFont = true;
            this.gridColumn13.Caption = "Item NO.";
            this.gridColumn13.FieldName = "DocItem";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 141;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.Caption = "Description";
            this.gridColumn14.FieldName = "ItemName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 140;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn15.Caption = "Quantity";
            this.gridColumn15.FieldName = "DocQty";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 106;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "Location";
            this.gridColumn16.FieldName = "DocStock";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            this.gridColumn16.Width = 71;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "Status";
            this.gridColumn17.FieldName = "DocFlag";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            this.gridColumn17.Width = 50;
            // 
            // Cell2
            // 
            this.Cell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell2.Location = new System.Drawing.Point(771, 92);
            this.Cell2.MainView = this.gridView3;
            this.Cell2.Name = "Cell2";
            this.Cell2.Size = new System.Drawing.Size(252, 126);
            this.Cell2.TabIndex = 121;
            this.Cell2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.cardView3});
            this.Cell2.DoubleClick += new System.EventHandler(this.Cell2_DoubleClick);
            // 
            // gridView3
            // 
            this.gridView3.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView3.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView3.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView3.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView3.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView3.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView3.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView3.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView3.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView3.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView3.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView3.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView3.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView3.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView3.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView3.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView3.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView3.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.Preview.Options.UseFont = true;
            this.gridView3.Appearance.Preview.Options.UseForeColor = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseForeColor = true;
            this.gridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView3.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView3.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20});
            this.gridView3.GridControl = this.Cell2;
            this.gridView3.GroupPanelText = "PO Cell 2";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView3.OptionsView.EnableAppearanceOddRow = true;
            this.gridView3.ViewCaption = "Show Detail PO Number";
            this.gridView3.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView3_CustomColumnDisplayText);
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "No.";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 20;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn19.AppearanceHeader.Options.UseFont = true;
            this.gridColumn19.Caption = "PO Number";
            this.gridColumn19.FieldName = "POnumber";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 100;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn20.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn20.AppearanceCell.Options.UseFont = true;
            this.gridColumn20.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn20.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn20.AppearanceHeader.Options.UseFont = true;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn20.Caption = "Qty";
            this.gridColumn20.FieldName = "QtyIn";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 2;
            this.gridColumn20.Width = 40;
            // 
            // cardView3
            // 
            this.cardView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26});
            this.cardView3.FocusedCardTopFieldIndex = 0;
            this.cardView3.GridControl = this.Cell2;
            this.cardView3.Name = "cardView3";
            this.cardView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView3.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn21.AppearanceHeader.Options.UseFont = true;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "Line";
            this.gridColumn21.FieldName = "DocLine";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            this.gridColumn21.Width = 58;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn22.AppearanceHeader.Options.UseFont = true;
            this.gridColumn22.Caption = "Item NO.";
            this.gridColumn22.FieldName = "DocItem";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            this.gridColumn22.Width = 141;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn23.AppearanceHeader.Options.UseFont = true;
            this.gridColumn23.Caption = "Description";
            this.gridColumn23.FieldName = "ItemName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 2;
            this.gridColumn23.Width = 140;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn24.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn24.AppearanceHeader.Options.UseFont = true;
            this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn24.Caption = "Quantity";
            this.gridColumn24.FieldName = "DocQty";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 3;
            this.gridColumn24.Width = 106;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn25.AppearanceHeader.Options.UseFont = true;
            this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.Caption = "Location";
            this.gridColumn25.FieldName = "DocStock";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 4;
            this.gridColumn25.Width = 71;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.Caption = "Status";
            this.gridColumn26.FieldName = "DocFlag";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 5;
            this.gridColumn26.Width = 50;
            // 
            // Cell3
            // 
            this.Cell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell3.Location = new System.Drawing.Point(1027, 91);
            this.Cell3.MainView = this.gridView4;
            this.Cell3.Name = "Cell3";
            this.Cell3.Size = new System.Drawing.Size(244, 126);
            this.Cell3.TabIndex = 122;
            this.Cell3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4,
            this.cardView4});
            this.Cell3.DoubleClick += new System.EventHandler(this.Cell3_DoubleClick);
            // 
            // gridView4
            // 
            this.gridView4.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView4.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView4.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView4.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView4.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView4.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView4.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView4.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView4.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView4.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView4.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView4.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView4.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView4.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView4.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView4.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView4.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView4.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView4.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView4.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView4.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView4.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView4.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView4.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView4.Appearance.Preview.Options.UseFont = true;
            this.gridView4.Appearance.Preview.Options.UseForeColor = true;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseForeColor = true;
            this.gridView4.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView4.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView4.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView4.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView4.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29});
            this.gridView4.GridControl = this.Cell3;
            this.gridView4.GroupPanelText = "PO Cell 3";
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView4.OptionsView.EnableAppearanceOddRow = true;
            this.gridView4.ViewCaption = "Show Detail PO Number";
            this.gridView4.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView4_CustomColumnDisplayText);
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn27.AppearanceCell.Options.UseFont = true;
            this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn27.AppearanceHeader.Options.UseFont = true;
            this.gridColumn27.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.Caption = "No.";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 0;
            this.gridColumn27.Width = 20;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn28.AppearanceHeader.Options.UseFont = true;
            this.gridColumn28.Caption = "PO Number";
            this.gridColumn28.FieldName = "POnumber";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            this.gridColumn28.Width = 100;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn29.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn29.AppearanceCell.Options.UseFont = true;
            this.gridColumn29.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn29.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn29.AppearanceHeader.Options.UseFont = true;
            this.gridColumn29.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn29.Caption = "Qty";
            this.gridColumn29.FieldName = "QtyIn";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 2;
            this.gridColumn29.Width = 40;
            // 
            // cardView4
            // 
            this.cardView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35});
            this.cardView4.FocusedCardTopFieldIndex = 0;
            this.cardView4.GridControl = this.Cell3;
            this.cardView4.Name = "cardView4";
            this.cardView4.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView4.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn30
            // 
            this.gridColumn30.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn30.AppearanceHeader.Options.UseFont = true;
            this.gridColumn30.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.Caption = "Line";
            this.gridColumn30.FieldName = "DocLine";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 0;
            this.gridColumn30.Width = 58;
            // 
            // gridColumn31
            // 
            this.gridColumn31.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn31.AppearanceHeader.Options.UseFont = true;
            this.gridColumn31.Caption = "Item NO.";
            this.gridColumn31.FieldName = "DocItem";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.ReadOnly = true;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 1;
            this.gridColumn31.Width = 141;
            // 
            // gridColumn32
            // 
            this.gridColumn32.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn32.AppearanceHeader.Options.UseFont = true;
            this.gridColumn32.Caption = "Description";
            this.gridColumn32.FieldName = "ItemName";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 2;
            this.gridColumn32.Width = 140;
            // 
            // gridColumn33
            // 
            this.gridColumn33.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn33.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn33.AppearanceHeader.Options.UseFont = true;
            this.gridColumn33.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn33.Caption = "Quantity";
            this.gridColumn33.FieldName = "DocQty";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 3;
            this.gridColumn33.Width = 106;
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn34.AppearanceHeader.Options.UseFont = true;
            this.gridColumn34.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn34.Caption = "Location";
            this.gridColumn34.FieldName = "DocStock";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 4;
            this.gridColumn34.Width = 71;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn35.AppearanceHeader.Options.UseFont = true;
            this.gridColumn35.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn35.Caption = "Status";
            this.gridColumn35.FieldName = "DocFlag";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 5;
            this.gridColumn35.Width = 50;
            // 
            // Cell4
            // 
            this.Cell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell4.Location = new System.Drawing.Point(3, 251);
            this.Cell4.MainView = this.gridView5;
            this.Cell4.Name = "Cell4";
            this.Cell4.Size = new System.Drawing.Size(249, 138);
            this.Cell4.TabIndex = 123;
            this.Cell4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5,
            this.cardView5});
            this.Cell4.DoubleClick += new System.EventHandler(this.Cell4_DoubleClick);
            // 
            // gridView5
            // 
            this.gridView5.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView5.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView5.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView5.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView5.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView5.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView5.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView5.Appearance.Empty.Options.UseBackColor = true;
            this.gridView5.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView5.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView5.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView5.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView5.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView5.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView5.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView5.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView5.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView5.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView5.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView5.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView5.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView5.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView5.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView5.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView5.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView5.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView5.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView5.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView5.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView5.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView5.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView5.Appearance.Preview.Options.UseFont = true;
            this.gridView5.Appearance.Preview.Options.UseForeColor = true;
            this.gridView5.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView5.Appearance.Row.Options.UseBackColor = true;
            this.gridView5.Appearance.Row.Options.UseForeColor = true;
            this.gridView5.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView5.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView5.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView5.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView5.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView5.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView5.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView5.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.gridView5.GridControl = this.Cell4;
            this.gridView5.GroupPanelText = "PO Cell 4";
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView5.OptionsView.EnableAppearanceOddRow = true;
            this.gridView5.ViewCaption = "Show Detail PO Number";
            this.gridView5.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView5_CustomColumnDisplayText);
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn36.AppearanceCell.Options.UseFont = true;
            this.gridColumn36.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn36.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn36.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn36.AppearanceHeader.Options.UseFont = true;
            this.gridColumn36.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn36.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn36.Caption = "No.";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.OptionsColumn.ReadOnly = true;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 0;
            this.gridColumn36.Width = 20;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn37.AppearanceHeader.Options.UseFont = true;
            this.gridColumn37.Caption = "PO Number";
            this.gridColumn37.FieldName = "POnumber";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.OptionsColumn.ReadOnly = true;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 1;
            this.gridColumn37.Width = 100;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn38.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn38.AppearanceCell.Options.UseFont = true;
            this.gridColumn38.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn38.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn38.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn38.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn38.AppearanceHeader.Options.UseFont = true;
            this.gridColumn38.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn38.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn38.Caption = "Qty";
            this.gridColumn38.FieldName = "QtyIn";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.OptionsColumn.ReadOnly = true;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 2;
            this.gridColumn38.Width = 40;
            // 
            // cardView5
            // 
            this.cardView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn44});
            this.cardView5.FocusedCardTopFieldIndex = 0;
            this.cardView5.GridControl = this.Cell4;
            this.cardView5.Name = "cardView5";
            this.cardView5.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView5.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn39
            // 
            this.gridColumn39.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn39.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn39.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn39.AppearanceHeader.Options.UseFont = true;
            this.gridColumn39.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn39.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn39.Caption = "Line";
            this.gridColumn39.FieldName = "DocLine";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.ReadOnly = true;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 0;
            this.gridColumn39.Width = 58;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn40.AppearanceHeader.Options.UseFont = true;
            this.gridColumn40.Caption = "Item NO.";
            this.gridColumn40.FieldName = "DocItem";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.ReadOnly = true;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 1;
            this.gridColumn40.Width = 141;
            // 
            // gridColumn41
            // 
            this.gridColumn41.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn41.AppearanceHeader.Options.UseFont = true;
            this.gridColumn41.Caption = "Description";
            this.gridColumn41.FieldName = "ItemName";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 2;
            this.gridColumn41.Width = 140;
            // 
            // gridColumn42
            // 
            this.gridColumn42.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn42.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn42.AppearanceHeader.Options.UseFont = true;
            this.gridColumn42.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn42.Caption = "Quantity";
            this.gridColumn42.FieldName = "DocQty";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 3;
            this.gridColumn42.Width = 106;
            // 
            // gridColumn43
            // 
            this.gridColumn43.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn43.AppearanceHeader.Options.UseFont = true;
            this.gridColumn43.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.Caption = "Location";
            this.gridColumn43.FieldName = "DocStock";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 4;
            this.gridColumn43.Width = 71;
            // 
            // gridColumn44
            // 
            this.gridColumn44.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn44.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn44.AppearanceHeader.Options.UseFont = true;
            this.gridColumn44.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn44.Caption = "Status";
            this.gridColumn44.FieldName = "DocFlag";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 5;
            this.gridColumn44.Width = 50;
            // 
            // Cell5
            // 
            this.Cell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell5.Location = new System.Drawing.Point(255, 252);
            this.Cell5.MainView = this.gridView6;
            this.Cell5.Name = "Cell5";
            this.Cell5.Size = new System.Drawing.Size(256, 137);
            this.Cell5.TabIndex = 124;
            this.Cell5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView6,
            this.cardView6});
            this.Cell5.DoubleClick += new System.EventHandler(this.Cell5_DoubleClick);
            // 
            // gridView6
            // 
            this.gridView6.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView6.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView6.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView6.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView6.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView6.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView6.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView6.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView6.Appearance.Empty.Options.UseBackColor = true;
            this.gridView6.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView6.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView6.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView6.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView6.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView6.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView6.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView6.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView6.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView6.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView6.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView6.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView6.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView6.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView6.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView6.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView6.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView6.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView6.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView6.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView6.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView6.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView6.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView6.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView6.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView6.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView6.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView6.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView6.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView6.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView6.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView6.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView6.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView6.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView6.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView6.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView6.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView6.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView6.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView6.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView6.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView6.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView6.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView6.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView6.Appearance.Preview.Options.UseFont = true;
            this.gridView6.Appearance.Preview.Options.UseForeColor = true;
            this.gridView6.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView6.Appearance.Row.Options.UseBackColor = true;
            this.gridView6.Appearance.Row.Options.UseForeColor = true;
            this.gridView6.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView6.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView6.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView6.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView6.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView6.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView6.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView6.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView6.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView6.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47});
            this.gridView6.GridControl = this.Cell5;
            this.gridView6.GroupPanelText = "PO Cell 5";
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView6.OptionsView.EnableAppearanceOddRow = true;
            this.gridView6.ViewCaption = "Show Detail PO Number";
            this.gridView6.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView6_CustomColumnDisplayText);
            // 
            // gridColumn45
            // 
            this.gridColumn45.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn45.AppearanceCell.Options.UseFont = true;
            this.gridColumn45.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn45.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn45.AppearanceHeader.Options.UseFont = true;
            this.gridColumn45.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn45.Caption = "No.";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.OptionsColumn.AllowFocus = false;
            this.gridColumn45.OptionsColumn.ReadOnly = true;
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 0;
            this.gridColumn45.Width = 20;
            // 
            // gridColumn46
            // 
            this.gridColumn46.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn46.AppearanceHeader.Options.UseFont = true;
            this.gridColumn46.Caption = "PO Number";
            this.gridColumn46.FieldName = "POnumber";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.OptionsColumn.AllowFocus = false;
            this.gridColumn46.OptionsColumn.ReadOnly = true;
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 1;
            this.gridColumn46.Width = 100;
            // 
            // gridColumn47
            // 
            this.gridColumn47.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn47.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn47.AppearanceCell.Options.UseFont = true;
            this.gridColumn47.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn47.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn47.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn47.AppearanceHeader.Options.UseFont = true;
            this.gridColumn47.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn47.Caption = "Qty";
            this.gridColumn47.FieldName = "QtyIn";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowFocus = false;
            this.gridColumn47.OptionsColumn.ReadOnly = true;
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 2;
            this.gridColumn47.Width = 40;
            // 
            // cardView6
            // 
            this.cardView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn48,
            this.gridColumn49,
            this.gridColumn50,
            this.gridColumn51,
            this.gridColumn52,
            this.gridColumn53});
            this.cardView6.FocusedCardTopFieldIndex = 0;
            this.cardView6.GridControl = this.Cell5;
            this.cardView6.Name = "cardView6";
            this.cardView6.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView6.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn48
            // 
            this.gridColumn48.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn48.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn48.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn48.AppearanceHeader.Options.UseFont = true;
            this.gridColumn48.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn48.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn48.Caption = "Line";
            this.gridColumn48.FieldName = "DocLine";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.AllowEdit = false;
            this.gridColumn48.OptionsColumn.ReadOnly = true;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 0;
            this.gridColumn48.Width = 58;
            // 
            // gridColumn49
            // 
            this.gridColumn49.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn49.AppearanceHeader.Options.UseFont = true;
            this.gridColumn49.Caption = "Item NO.";
            this.gridColumn49.FieldName = "DocItem";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.OptionsColumn.ReadOnly = true;
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 1;
            this.gridColumn49.Width = 141;
            // 
            // gridColumn50
            // 
            this.gridColumn50.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn50.AppearanceHeader.Options.UseFont = true;
            this.gridColumn50.Caption = "Description";
            this.gridColumn50.FieldName = "ItemName";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.Visible = true;
            this.gridColumn50.VisibleIndex = 2;
            this.gridColumn50.Width = 140;
            // 
            // gridColumn51
            // 
            this.gridColumn51.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn51.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn51.AppearanceHeader.Options.UseFont = true;
            this.gridColumn51.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn51.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn51.Caption = "Quantity";
            this.gridColumn51.FieldName = "DocQty";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 3;
            this.gridColumn51.Width = 106;
            // 
            // gridColumn52
            // 
            this.gridColumn52.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn52.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn52.AppearanceHeader.Options.UseFont = true;
            this.gridColumn52.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn52.Caption = "Location";
            this.gridColumn52.FieldName = "DocStock";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 4;
            this.gridColumn52.Width = 71;
            // 
            // gridColumn53
            // 
            this.gridColumn53.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn53.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn53.AppearanceHeader.Options.UseFont = true;
            this.gridColumn53.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn53.Caption = "Status";
            this.gridColumn53.FieldName = "DocFlag";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 5;
            this.gridColumn53.Width = 50;
            // 
            // Cell6
            // 
            this.Cell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell6.Location = new System.Drawing.Point(515, 252);
            this.Cell6.MainView = this.gridView7;
            this.Cell6.Name = "Cell6";
            this.Cell6.Size = new System.Drawing.Size(260, 137);
            this.Cell6.TabIndex = 125;
            this.Cell6.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7,
            this.cardView7});
            this.Cell6.DoubleClick += new System.EventHandler(this.Cell6_DoubleClick);
            // 
            // gridView7
            // 
            this.gridView7.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView7.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView7.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView7.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView7.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView7.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView7.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView7.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView7.Appearance.Empty.Options.UseBackColor = true;
            this.gridView7.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView7.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView7.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView7.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView7.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView7.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView7.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView7.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView7.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView7.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView7.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView7.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView7.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView7.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView7.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView7.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView7.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView7.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView7.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView7.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView7.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView7.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView7.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView7.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView7.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView7.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView7.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView7.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView7.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView7.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView7.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView7.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView7.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView7.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView7.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView7.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView7.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView7.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView7.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView7.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView7.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView7.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView7.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView7.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView7.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView7.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView7.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView7.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView7.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView7.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView7.Appearance.Preview.Options.UseFont = true;
            this.gridView7.Appearance.Preview.Options.UseForeColor = true;
            this.gridView7.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView7.Appearance.Row.Options.UseBackColor = true;
            this.gridView7.Appearance.Row.Options.UseForeColor = true;
            this.gridView7.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView7.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView7.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView7.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView7.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView7.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView7.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView7.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView7.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView7.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView7.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56});
            this.gridView7.GridControl = this.Cell6;
            this.gridView7.GroupPanelText = "PO Cell 6";
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView7.OptionsView.EnableAppearanceOddRow = true;
            this.gridView7.ViewCaption = "Show Detail PO Number";
            this.gridView7.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView7_CustomColumnDisplayText);
            // 
            // gridColumn54
            // 
            this.gridColumn54.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn54.AppearanceCell.Options.UseFont = true;
            this.gridColumn54.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn54.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn54.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn54.AppearanceHeader.Options.UseFont = true;
            this.gridColumn54.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn54.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn54.Caption = "No.";
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.OptionsColumn.AllowFocus = false;
            this.gridColumn54.OptionsColumn.ReadOnly = true;
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 0;
            this.gridColumn54.Width = 20;
            // 
            // gridColumn55
            // 
            this.gridColumn55.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn55.AppearanceHeader.Options.UseFont = true;
            this.gridColumn55.Caption = "PO Number";
            this.gridColumn55.FieldName = "POnumber";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.OptionsColumn.AllowFocus = false;
            this.gridColumn55.OptionsColumn.ReadOnly = true;
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 1;
            this.gridColumn55.Width = 100;
            // 
            // gridColumn56
            // 
            this.gridColumn56.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn56.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn56.AppearanceCell.Options.UseFont = true;
            this.gridColumn56.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn56.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn56.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn56.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn56.AppearanceHeader.Options.UseFont = true;
            this.gridColumn56.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn56.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn56.Caption = "Qty";
            this.gridColumn56.FieldName = "QtyIn";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.OptionsColumn.AllowFocus = false;
            this.gridColumn56.OptionsColumn.ReadOnly = true;
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 2;
            this.gridColumn56.Width = 40;
            // 
            // cardView7
            // 
            this.cardView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn57,
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62});
            this.cardView7.FocusedCardTopFieldIndex = 0;
            this.cardView7.GridControl = this.Cell6;
            this.cardView7.Name = "cardView7";
            this.cardView7.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView7.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn57
            // 
            this.gridColumn57.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn57.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn57.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn57.AppearanceHeader.Options.UseFont = true;
            this.gridColumn57.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn57.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn57.Caption = "Line";
            this.gridColumn57.FieldName = "DocLine";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.OptionsColumn.AllowEdit = false;
            this.gridColumn57.OptionsColumn.ReadOnly = true;
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 0;
            this.gridColumn57.Width = 58;
            // 
            // gridColumn58
            // 
            this.gridColumn58.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn58.AppearanceHeader.Options.UseFont = true;
            this.gridColumn58.Caption = "Item NO.";
            this.gridColumn58.FieldName = "DocItem";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.OptionsColumn.ReadOnly = true;
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 1;
            this.gridColumn58.Width = 141;
            // 
            // gridColumn59
            // 
            this.gridColumn59.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn59.AppearanceHeader.Options.UseFont = true;
            this.gridColumn59.Caption = "Description";
            this.gridColumn59.FieldName = "ItemName";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 2;
            this.gridColumn59.Width = 140;
            // 
            // gridColumn60
            // 
            this.gridColumn60.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn60.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn60.AppearanceHeader.Options.UseFont = true;
            this.gridColumn60.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn60.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn60.Caption = "Quantity";
            this.gridColumn60.FieldName = "DocQty";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.Visible = true;
            this.gridColumn60.VisibleIndex = 3;
            this.gridColumn60.Width = 106;
            // 
            // gridColumn61
            // 
            this.gridColumn61.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn61.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn61.AppearanceHeader.Options.UseFont = true;
            this.gridColumn61.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn61.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn61.Caption = "Location";
            this.gridColumn61.FieldName = "DocStock";
            this.gridColumn61.Name = "gridColumn61";
            this.gridColumn61.Visible = true;
            this.gridColumn61.VisibleIndex = 4;
            this.gridColumn61.Width = 71;
            // 
            // gridColumn62
            // 
            this.gridColumn62.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn62.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn62.AppearanceHeader.Options.UseFont = true;
            this.gridColumn62.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn62.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn62.Caption = "Status";
            this.gridColumn62.FieldName = "DocFlag";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 5;
            this.gridColumn62.Width = 50;
            // 
            // Cell7
            // 
            this.Cell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell7.Location = new System.Drawing.Point(777, 249);
            this.Cell7.MainView = this.gridView8;
            this.Cell7.Name = "Cell7";
            this.Cell7.Size = new System.Drawing.Size(246, 140);
            this.Cell7.TabIndex = 126;
            this.Cell7.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView8,
            this.cardView8});
            this.Cell7.DoubleClick += new System.EventHandler(this.Cell7_DoubleClick);
            // 
            // gridView8
            // 
            this.gridView8.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView8.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView8.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView8.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView8.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView8.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView8.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView8.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView8.Appearance.Empty.Options.UseBackColor = true;
            this.gridView8.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView8.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView8.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView8.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView8.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView8.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView8.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView8.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView8.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView8.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView8.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView8.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView8.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView8.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView8.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView8.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView8.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView8.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView8.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView8.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView8.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView8.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView8.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView8.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView8.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView8.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView8.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView8.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView8.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView8.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView8.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView8.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView8.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView8.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView8.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView8.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView8.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView8.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView8.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView8.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView8.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView8.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView8.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView8.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView8.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView8.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView8.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView8.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView8.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView8.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView8.Appearance.Preview.Options.UseFont = true;
            this.gridView8.Appearance.Preview.Options.UseForeColor = true;
            this.gridView8.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView8.Appearance.Row.Options.UseBackColor = true;
            this.gridView8.Appearance.Row.Options.UseForeColor = true;
            this.gridView8.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView8.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView8.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView8.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView8.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView8.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView8.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView8.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView8.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView8.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView8.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn63,
            this.gridColumn64,
            this.gridColumn65});
            this.gridView8.GridControl = this.Cell7;
            this.gridView8.GroupPanelText = "PO Cell 7";
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView8.OptionsView.EnableAppearanceOddRow = true;
            this.gridView8.ViewCaption = "Show Detail PO Number";
            this.gridView8.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView8_CustomColumnDisplayText);
            // 
            // gridColumn63
            // 
            this.gridColumn63.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn63.AppearanceCell.Options.UseFont = true;
            this.gridColumn63.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn63.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn63.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn63.AppearanceHeader.Options.UseFont = true;
            this.gridColumn63.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn63.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn63.Caption = "No.";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.OptionsColumn.AllowFocus = false;
            this.gridColumn63.OptionsColumn.ReadOnly = true;
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 0;
            this.gridColumn63.Width = 20;
            // 
            // gridColumn64
            // 
            this.gridColumn64.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn64.AppearanceHeader.Options.UseFont = true;
            this.gridColumn64.Caption = "PO Number";
            this.gridColumn64.FieldName = "POnumber";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.OptionsColumn.AllowFocus = false;
            this.gridColumn64.OptionsColumn.ReadOnly = true;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 1;
            this.gridColumn64.Width = 100;
            // 
            // gridColumn65
            // 
            this.gridColumn65.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn65.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn65.AppearanceCell.Options.UseFont = true;
            this.gridColumn65.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn65.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn65.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn65.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn65.AppearanceHeader.Options.UseFont = true;
            this.gridColumn65.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn65.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn65.Caption = "Qty";
            this.gridColumn65.FieldName = "QtyIn";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsColumn.AllowFocus = false;
            this.gridColumn65.OptionsColumn.ReadOnly = true;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 2;
            this.gridColumn65.Width = 40;
            // 
            // cardView8
            // 
            this.cardView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn66,
            this.gridColumn67,
            this.gridColumn68,
            this.gridColumn69,
            this.gridColumn70,
            this.gridColumn71});
            this.cardView8.FocusedCardTopFieldIndex = 0;
            this.cardView8.GridControl = this.Cell7;
            this.cardView8.Name = "cardView8";
            this.cardView8.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView8.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn66
            // 
            this.gridColumn66.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn66.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn66.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn66.AppearanceHeader.Options.UseFont = true;
            this.gridColumn66.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn66.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn66.Caption = "Line";
            this.gridColumn66.FieldName = "DocLine";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowEdit = false;
            this.gridColumn66.OptionsColumn.ReadOnly = true;
            this.gridColumn66.Visible = true;
            this.gridColumn66.VisibleIndex = 0;
            this.gridColumn66.Width = 58;
            // 
            // gridColumn67
            // 
            this.gridColumn67.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn67.AppearanceHeader.Options.UseFont = true;
            this.gridColumn67.Caption = "Item NO.";
            this.gridColumn67.FieldName = "DocItem";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.ReadOnly = true;
            this.gridColumn67.Visible = true;
            this.gridColumn67.VisibleIndex = 1;
            this.gridColumn67.Width = 141;
            // 
            // gridColumn68
            // 
            this.gridColumn68.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn68.AppearanceHeader.Options.UseFont = true;
            this.gridColumn68.Caption = "Description";
            this.gridColumn68.FieldName = "ItemName";
            this.gridColumn68.Name = "gridColumn68";
            this.gridColumn68.Visible = true;
            this.gridColumn68.VisibleIndex = 2;
            this.gridColumn68.Width = 140;
            // 
            // gridColumn69
            // 
            this.gridColumn69.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn69.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn69.AppearanceHeader.Options.UseFont = true;
            this.gridColumn69.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn69.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn69.Caption = "Quantity";
            this.gridColumn69.FieldName = "DocQty";
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn69.Visible = true;
            this.gridColumn69.VisibleIndex = 3;
            this.gridColumn69.Width = 106;
            // 
            // gridColumn70
            // 
            this.gridColumn70.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn70.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn70.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn70.AppearanceHeader.Options.UseFont = true;
            this.gridColumn70.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn70.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn70.Caption = "Location";
            this.gridColumn70.FieldName = "DocStock";
            this.gridColumn70.Name = "gridColumn70";
            this.gridColumn70.Visible = true;
            this.gridColumn70.VisibleIndex = 4;
            this.gridColumn70.Width = 71;
            // 
            // gridColumn71
            // 
            this.gridColumn71.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn71.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn71.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn71.AppearanceHeader.Options.UseFont = true;
            this.gridColumn71.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn71.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn71.Caption = "Status";
            this.gridColumn71.FieldName = "DocFlag";
            this.gridColumn71.Name = "gridColumn71";
            this.gridColumn71.Visible = true;
            this.gridColumn71.VisibleIndex = 5;
            this.gridColumn71.Width = 50;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(514, 392);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(261, 25);
            this.label12.TabIndex = 130;
            this.label12.Text = "CELL 11";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label13.Location = new System.Drawing.Point(255, 392);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(256, 25);
            this.label13.TabIndex = 129;
            this.label13.Text = "CELL 10";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label14.Location = new System.Drawing.Point(3, 392);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(249, 25);
            this.label14.TabIndex = 128;
            this.label14.Text = "CELL 9";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(1024, 222);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(247, 23);
            this.label15.TabIndex = 127;
            this.label15.Text = "CELL 8";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Cell11
            // 
            this.Cell11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell11.Location = new System.Drawing.Point(516, 420);
            this.Cell11.MainView = this.gridView9;
            this.Cell11.Name = "Cell11";
            this.Cell11.Size = new System.Drawing.Size(259, 152);
            this.Cell11.TabIndex = 134;
            this.Cell11.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView9,
            this.cardView9});
            this.Cell11.DoubleClick += new System.EventHandler(this.Cell11_DoubleClick);
            // 
            // gridView9
            // 
            this.gridView9.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView9.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView9.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView9.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView9.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView9.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView9.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView9.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView9.Appearance.Empty.Options.UseBackColor = true;
            this.gridView9.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView9.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView9.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView9.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView9.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView9.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView9.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView9.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView9.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView9.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView9.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView9.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView9.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView9.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView9.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView9.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView9.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView9.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView9.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView9.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView9.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView9.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView9.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView9.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView9.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView9.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView9.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView9.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView9.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView9.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView9.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView9.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView9.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView9.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView9.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView9.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView9.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView9.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView9.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView9.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView9.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView9.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView9.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView9.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView9.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView9.Appearance.Preview.Options.UseFont = true;
            this.gridView9.Appearance.Preview.Options.UseForeColor = true;
            this.gridView9.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView9.Appearance.Row.Options.UseBackColor = true;
            this.gridView9.Appearance.Row.Options.UseForeColor = true;
            this.gridView9.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView9.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView9.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView9.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView9.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView9.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView9.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView9.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView9.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView9.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn72,
            this.gridColumn73,
            this.gridColumn74});
            this.gridView9.GridControl = this.Cell11;
            this.gridView9.GroupPanelText = "PO Cell 11";
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView9.OptionsView.EnableAppearanceOddRow = true;
            this.gridView9.ViewCaption = "Show Detail PO Number";
            this.gridView9.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView9_CustomColumnDisplayText);
            // 
            // gridColumn72
            // 
            this.gridColumn72.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn72.AppearanceCell.Options.UseFont = true;
            this.gridColumn72.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn72.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn72.AppearanceHeader.Options.UseFont = true;
            this.gridColumn72.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn72.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn72.Caption = "No.";
            this.gridColumn72.Name = "gridColumn72";
            this.gridColumn72.OptionsColumn.AllowFocus = false;
            this.gridColumn72.OptionsColumn.ReadOnly = true;
            this.gridColumn72.Visible = true;
            this.gridColumn72.VisibleIndex = 0;
            this.gridColumn72.Width = 20;
            // 
            // gridColumn73
            // 
            this.gridColumn73.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn73.AppearanceHeader.Options.UseFont = true;
            this.gridColumn73.Caption = "PO Number";
            this.gridColumn73.FieldName = "POnumber";
            this.gridColumn73.Name = "gridColumn73";
            this.gridColumn73.OptionsColumn.AllowFocus = false;
            this.gridColumn73.OptionsColumn.ReadOnly = true;
            this.gridColumn73.Visible = true;
            this.gridColumn73.VisibleIndex = 1;
            this.gridColumn73.Width = 100;
            // 
            // gridColumn74
            // 
            this.gridColumn74.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn74.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn74.AppearanceCell.Options.UseFont = true;
            this.gridColumn74.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn74.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn74.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn74.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn74.AppearanceHeader.Options.UseFont = true;
            this.gridColumn74.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn74.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn74.Caption = "Qty";
            this.gridColumn74.FieldName = "QtyIn";
            this.gridColumn74.Name = "gridColumn74";
            this.gridColumn74.OptionsColumn.AllowFocus = false;
            this.gridColumn74.OptionsColumn.ReadOnly = true;
            this.gridColumn74.Visible = true;
            this.gridColumn74.VisibleIndex = 2;
            this.gridColumn74.Width = 40;
            // 
            // cardView9
            // 
            this.cardView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn75,
            this.gridColumn76,
            this.gridColumn77,
            this.gridColumn78,
            this.gridColumn79,
            this.gridColumn80});
            this.cardView9.FocusedCardTopFieldIndex = 0;
            this.cardView9.GridControl = this.Cell11;
            this.cardView9.Name = "cardView9";
            this.cardView9.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView9.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn75
            // 
            this.gridColumn75.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn75.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn75.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn75.AppearanceHeader.Options.UseFont = true;
            this.gridColumn75.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn75.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn75.Caption = "Line";
            this.gridColumn75.FieldName = "DocLine";
            this.gridColumn75.Name = "gridColumn75";
            this.gridColumn75.OptionsColumn.AllowEdit = false;
            this.gridColumn75.OptionsColumn.ReadOnly = true;
            this.gridColumn75.Visible = true;
            this.gridColumn75.VisibleIndex = 0;
            this.gridColumn75.Width = 58;
            // 
            // gridColumn76
            // 
            this.gridColumn76.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn76.AppearanceHeader.Options.UseFont = true;
            this.gridColumn76.Caption = "Item NO.";
            this.gridColumn76.FieldName = "DocItem";
            this.gridColumn76.Name = "gridColumn76";
            this.gridColumn76.OptionsColumn.ReadOnly = true;
            this.gridColumn76.Visible = true;
            this.gridColumn76.VisibleIndex = 1;
            this.gridColumn76.Width = 141;
            // 
            // gridColumn77
            // 
            this.gridColumn77.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn77.AppearanceHeader.Options.UseFont = true;
            this.gridColumn77.Caption = "Description";
            this.gridColumn77.FieldName = "ItemName";
            this.gridColumn77.Name = "gridColumn77";
            this.gridColumn77.Visible = true;
            this.gridColumn77.VisibleIndex = 2;
            this.gridColumn77.Width = 140;
            // 
            // gridColumn78
            // 
            this.gridColumn78.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn78.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn78.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn78.AppearanceHeader.Options.UseFont = true;
            this.gridColumn78.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn78.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn78.Caption = "Quantity";
            this.gridColumn78.FieldName = "DocQty";
            this.gridColumn78.Name = "gridColumn78";
            this.gridColumn78.Visible = true;
            this.gridColumn78.VisibleIndex = 3;
            this.gridColumn78.Width = 106;
            // 
            // gridColumn79
            // 
            this.gridColumn79.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn79.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn79.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn79.AppearanceHeader.Options.UseFont = true;
            this.gridColumn79.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn79.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn79.Caption = "Location";
            this.gridColumn79.FieldName = "DocStock";
            this.gridColumn79.Name = "gridColumn79";
            this.gridColumn79.Visible = true;
            this.gridColumn79.VisibleIndex = 4;
            this.gridColumn79.Width = 71;
            // 
            // gridColumn80
            // 
            this.gridColumn80.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn80.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn80.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn80.AppearanceHeader.Options.UseFont = true;
            this.gridColumn80.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn80.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn80.Caption = "Status";
            this.gridColumn80.FieldName = "DocFlag";
            this.gridColumn80.Name = "gridColumn80";
            this.gridColumn80.Visible = true;
            this.gridColumn80.VisibleIndex = 5;
            this.gridColumn80.Width = 50;
            // 
            // Cell10
            // 
            this.Cell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell10.Location = new System.Drawing.Point(254, 420);
            this.Cell10.MainView = this.gridView10;
            this.Cell10.Name = "Cell10";
            this.Cell10.Size = new System.Drawing.Size(257, 152);
            this.Cell10.TabIndex = 133;
            this.Cell10.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView10,
            this.cardView10});
            this.Cell10.DoubleClick += new System.EventHandler(this.Cell10_DoubleClick);
            // 
            // gridView10
            // 
            this.gridView10.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView10.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView10.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView10.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView10.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView10.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView10.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView10.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView10.Appearance.Empty.Options.UseBackColor = true;
            this.gridView10.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView10.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView10.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView10.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView10.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView10.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView10.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView10.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView10.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView10.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView10.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView10.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView10.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView10.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView10.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView10.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView10.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView10.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView10.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView10.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView10.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView10.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView10.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView10.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView10.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView10.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView10.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView10.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView10.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView10.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView10.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView10.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView10.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView10.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView10.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView10.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView10.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView10.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView10.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView10.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView10.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView10.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView10.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView10.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView10.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView10.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView10.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView10.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView10.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView10.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView10.Appearance.Preview.Options.UseFont = true;
            this.gridView10.Appearance.Preview.Options.UseForeColor = true;
            this.gridView10.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView10.Appearance.Row.Options.UseBackColor = true;
            this.gridView10.Appearance.Row.Options.UseForeColor = true;
            this.gridView10.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView10.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView10.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView10.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView10.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView10.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView10.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView10.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView10.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView10.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView10.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn81,
            this.gridColumn82,
            this.gridColumn83});
            this.gridView10.GridControl = this.Cell10;
            this.gridView10.GroupPanelText = "PO Cell 10";
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView10.OptionsView.EnableAppearanceOddRow = true;
            this.gridView10.ViewCaption = "Show Detail PO Number";
            this.gridView10.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView10_CustomColumnDisplayText);
            // 
            // gridColumn81
            // 
            this.gridColumn81.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn81.AppearanceCell.Options.UseFont = true;
            this.gridColumn81.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn81.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn81.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn81.AppearanceHeader.Options.UseFont = true;
            this.gridColumn81.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn81.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn81.Caption = "No.";
            this.gridColumn81.Name = "gridColumn81";
            this.gridColumn81.OptionsColumn.AllowFocus = false;
            this.gridColumn81.OptionsColumn.ReadOnly = true;
            this.gridColumn81.Visible = true;
            this.gridColumn81.VisibleIndex = 0;
            this.gridColumn81.Width = 20;
            // 
            // gridColumn82
            // 
            this.gridColumn82.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn82.AppearanceHeader.Options.UseFont = true;
            this.gridColumn82.Caption = "PO Number";
            this.gridColumn82.FieldName = "POnumber";
            this.gridColumn82.Name = "gridColumn82";
            this.gridColumn82.OptionsColumn.AllowFocus = false;
            this.gridColumn82.OptionsColumn.ReadOnly = true;
            this.gridColumn82.Visible = true;
            this.gridColumn82.VisibleIndex = 1;
            this.gridColumn82.Width = 100;
            // 
            // gridColumn83
            // 
            this.gridColumn83.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn83.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn83.AppearanceCell.Options.UseFont = true;
            this.gridColumn83.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn83.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn83.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn83.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn83.AppearanceHeader.Options.UseFont = true;
            this.gridColumn83.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn83.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn83.Caption = "Qty";
            this.gridColumn83.FieldName = "QtyIn";
            this.gridColumn83.Name = "gridColumn83";
            this.gridColumn83.OptionsColumn.AllowFocus = false;
            this.gridColumn83.OptionsColumn.ReadOnly = true;
            this.gridColumn83.Visible = true;
            this.gridColumn83.VisibleIndex = 2;
            this.gridColumn83.Width = 40;
            // 
            // cardView10
            // 
            this.cardView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn84,
            this.gridColumn85,
            this.gridColumn86,
            this.gridColumn87,
            this.gridColumn88,
            this.gridColumn89});
            this.cardView10.FocusedCardTopFieldIndex = 0;
            this.cardView10.GridControl = this.Cell10;
            this.cardView10.Name = "cardView10";
            this.cardView10.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView10.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn84
            // 
            this.gridColumn84.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn84.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn84.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn84.AppearanceHeader.Options.UseFont = true;
            this.gridColumn84.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn84.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn84.Caption = "Line";
            this.gridColumn84.FieldName = "DocLine";
            this.gridColumn84.Name = "gridColumn84";
            this.gridColumn84.OptionsColumn.AllowEdit = false;
            this.gridColumn84.OptionsColumn.ReadOnly = true;
            this.gridColumn84.Visible = true;
            this.gridColumn84.VisibleIndex = 0;
            this.gridColumn84.Width = 58;
            // 
            // gridColumn85
            // 
            this.gridColumn85.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn85.AppearanceHeader.Options.UseFont = true;
            this.gridColumn85.Caption = "Item NO.";
            this.gridColumn85.FieldName = "DocItem";
            this.gridColumn85.Name = "gridColumn85";
            this.gridColumn85.OptionsColumn.ReadOnly = true;
            this.gridColumn85.Visible = true;
            this.gridColumn85.VisibleIndex = 1;
            this.gridColumn85.Width = 141;
            // 
            // gridColumn86
            // 
            this.gridColumn86.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn86.AppearanceHeader.Options.UseFont = true;
            this.gridColumn86.Caption = "Description";
            this.gridColumn86.FieldName = "ItemName";
            this.gridColumn86.Name = "gridColumn86";
            this.gridColumn86.Visible = true;
            this.gridColumn86.VisibleIndex = 2;
            this.gridColumn86.Width = 140;
            // 
            // gridColumn87
            // 
            this.gridColumn87.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn87.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn87.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn87.AppearanceHeader.Options.UseFont = true;
            this.gridColumn87.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn87.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn87.Caption = "Quantity";
            this.gridColumn87.FieldName = "DocQty";
            this.gridColumn87.Name = "gridColumn87";
            this.gridColumn87.Visible = true;
            this.gridColumn87.VisibleIndex = 3;
            this.gridColumn87.Width = 106;
            // 
            // gridColumn88
            // 
            this.gridColumn88.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn88.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn88.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn88.AppearanceHeader.Options.UseFont = true;
            this.gridColumn88.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn88.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn88.Caption = "Location";
            this.gridColumn88.FieldName = "DocStock";
            this.gridColumn88.Name = "gridColumn88";
            this.gridColumn88.Visible = true;
            this.gridColumn88.VisibleIndex = 4;
            this.gridColumn88.Width = 71;
            // 
            // gridColumn89
            // 
            this.gridColumn89.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn89.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn89.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn89.AppearanceHeader.Options.UseFont = true;
            this.gridColumn89.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn89.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn89.Caption = "Status";
            this.gridColumn89.FieldName = "DocFlag";
            this.gridColumn89.Name = "gridColumn89";
            this.gridColumn89.Visible = true;
            this.gridColumn89.VisibleIndex = 5;
            this.gridColumn89.Width = 50;
            // 
            // Cell9
            // 
            this.Cell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell9.Location = new System.Drawing.Point(3, 420);
            this.Cell9.MainView = this.gridView11;
            this.Cell9.Name = "Cell9";
            this.Cell9.Size = new System.Drawing.Size(248, 152);
            this.Cell9.TabIndex = 132;
            this.Cell9.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView11,
            this.cardView11});
            this.Cell9.DoubleClick += new System.EventHandler(this.Cell9_DoubleClick);
            // 
            // gridView11
            // 
            this.gridView11.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView11.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView11.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView11.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView11.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView11.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView11.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView11.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView11.Appearance.Empty.Options.UseBackColor = true;
            this.gridView11.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView11.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView11.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView11.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView11.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView11.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView11.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView11.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView11.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView11.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView11.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView11.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView11.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView11.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView11.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView11.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView11.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView11.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView11.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView11.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView11.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView11.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView11.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView11.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView11.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView11.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView11.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView11.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView11.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView11.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView11.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView11.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView11.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView11.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView11.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView11.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView11.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView11.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView11.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView11.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView11.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView11.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView11.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView11.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView11.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView11.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView11.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView11.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView11.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView11.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView11.Appearance.Preview.Options.UseFont = true;
            this.gridView11.Appearance.Preview.Options.UseForeColor = true;
            this.gridView11.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView11.Appearance.Row.Options.UseBackColor = true;
            this.gridView11.Appearance.Row.Options.UseForeColor = true;
            this.gridView11.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView11.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView11.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView11.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView11.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView11.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView11.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView11.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView11.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView11.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView11.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn90,
            this.gridColumn91,
            this.gridColumn92});
            this.gridView11.GridControl = this.Cell9;
            this.gridView11.GroupPanelText = "PO Cell 9";
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView11.OptionsView.EnableAppearanceOddRow = true;
            this.gridView11.ViewCaption = "Show Detail PO Number";
            this.gridView11.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView11_CustomColumnDisplayText);
            // 
            // gridColumn90
            // 
            this.gridColumn90.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn90.AppearanceCell.Options.UseFont = true;
            this.gridColumn90.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn90.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn90.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn90.AppearanceHeader.Options.UseFont = true;
            this.gridColumn90.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn90.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn90.Caption = "No.";
            this.gridColumn90.Name = "gridColumn90";
            this.gridColumn90.OptionsColumn.AllowFocus = false;
            this.gridColumn90.OptionsColumn.ReadOnly = true;
            this.gridColumn90.Visible = true;
            this.gridColumn90.VisibleIndex = 0;
            this.gridColumn90.Width = 20;
            // 
            // gridColumn91
            // 
            this.gridColumn91.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn91.AppearanceHeader.Options.UseFont = true;
            this.gridColumn91.Caption = "PO Number";
            this.gridColumn91.FieldName = "POnumber";
            this.gridColumn91.Name = "gridColumn91";
            this.gridColumn91.OptionsColumn.AllowFocus = false;
            this.gridColumn91.OptionsColumn.ReadOnly = true;
            this.gridColumn91.Visible = true;
            this.gridColumn91.VisibleIndex = 1;
            this.gridColumn91.Width = 100;
            // 
            // gridColumn92
            // 
            this.gridColumn92.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn92.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn92.AppearanceCell.Options.UseFont = true;
            this.gridColumn92.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn92.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn92.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn92.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn92.AppearanceHeader.Options.UseFont = true;
            this.gridColumn92.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn92.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn92.Caption = "Qty";
            this.gridColumn92.FieldName = "QtyIn";
            this.gridColumn92.Name = "gridColumn92";
            this.gridColumn92.OptionsColumn.AllowFocus = false;
            this.gridColumn92.OptionsColumn.ReadOnly = true;
            this.gridColumn92.Visible = true;
            this.gridColumn92.VisibleIndex = 2;
            this.gridColumn92.Width = 40;
            // 
            // cardView11
            // 
            this.cardView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn93,
            this.gridColumn94,
            this.gridColumn95,
            this.gridColumn96,
            this.gridColumn97,
            this.gridColumn98});
            this.cardView11.FocusedCardTopFieldIndex = 0;
            this.cardView11.GridControl = this.Cell9;
            this.cardView11.Name = "cardView11";
            this.cardView11.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView11.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn93
            // 
            this.gridColumn93.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn93.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn93.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn93.AppearanceHeader.Options.UseFont = true;
            this.gridColumn93.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn93.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn93.Caption = "Line";
            this.gridColumn93.FieldName = "DocLine";
            this.gridColumn93.Name = "gridColumn93";
            this.gridColumn93.OptionsColumn.AllowEdit = false;
            this.gridColumn93.OptionsColumn.ReadOnly = true;
            this.gridColumn93.Visible = true;
            this.gridColumn93.VisibleIndex = 0;
            this.gridColumn93.Width = 58;
            // 
            // gridColumn94
            // 
            this.gridColumn94.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn94.AppearanceHeader.Options.UseFont = true;
            this.gridColumn94.Caption = "Item NO.";
            this.gridColumn94.FieldName = "DocItem";
            this.gridColumn94.Name = "gridColumn94";
            this.gridColumn94.OptionsColumn.ReadOnly = true;
            this.gridColumn94.Visible = true;
            this.gridColumn94.VisibleIndex = 1;
            this.gridColumn94.Width = 141;
            // 
            // gridColumn95
            // 
            this.gridColumn95.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn95.AppearanceHeader.Options.UseFont = true;
            this.gridColumn95.Caption = "Description";
            this.gridColumn95.FieldName = "ItemName";
            this.gridColumn95.Name = "gridColumn95";
            this.gridColumn95.Visible = true;
            this.gridColumn95.VisibleIndex = 2;
            this.gridColumn95.Width = 140;
            // 
            // gridColumn96
            // 
            this.gridColumn96.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn96.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn96.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn96.AppearanceHeader.Options.UseFont = true;
            this.gridColumn96.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn96.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn96.Caption = "Quantity";
            this.gridColumn96.FieldName = "DocQty";
            this.gridColumn96.Name = "gridColumn96";
            this.gridColumn96.Visible = true;
            this.gridColumn96.VisibleIndex = 3;
            this.gridColumn96.Width = 106;
            // 
            // gridColumn97
            // 
            this.gridColumn97.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn97.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn97.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn97.AppearanceHeader.Options.UseFont = true;
            this.gridColumn97.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn97.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn97.Caption = "Location";
            this.gridColumn97.FieldName = "DocStock";
            this.gridColumn97.Name = "gridColumn97";
            this.gridColumn97.Visible = true;
            this.gridColumn97.VisibleIndex = 4;
            this.gridColumn97.Width = 71;
            // 
            // gridColumn98
            // 
            this.gridColumn98.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn98.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn98.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn98.AppearanceHeader.Options.UseFont = true;
            this.gridColumn98.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn98.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn98.Caption = "Status";
            this.gridColumn98.FieldName = "DocFlag";
            this.gridColumn98.Name = "gridColumn98";
            this.gridColumn98.Visible = true;
            this.gridColumn98.VisibleIndex = 5;
            this.gridColumn98.Width = 50;
            // 
            // Cell8
            // 
            this.Cell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell8.Location = new System.Drawing.Point(1027, 247);
            this.Cell8.MainView = this.gridView12;
            this.Cell8.Name = "Cell8";
            this.Cell8.Size = new System.Drawing.Size(244, 142);
            this.Cell8.TabIndex = 131;
            this.Cell8.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView12,
            this.cardView12});
            this.Cell8.DoubleClick += new System.EventHandler(this.Cell8_DoubleClick);
            // 
            // gridView12
            // 
            this.gridView12.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView12.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView12.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView12.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView12.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView12.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView12.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView12.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView12.Appearance.Empty.Options.UseBackColor = true;
            this.gridView12.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView12.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView12.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView12.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView12.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView12.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView12.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView12.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView12.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView12.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView12.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView12.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView12.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView12.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView12.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView12.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView12.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView12.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView12.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView12.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView12.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView12.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView12.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView12.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView12.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView12.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView12.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView12.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView12.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView12.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView12.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView12.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView12.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView12.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView12.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView12.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView12.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView12.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView12.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView12.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView12.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView12.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView12.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView12.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView12.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView12.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView12.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView12.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView12.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView12.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView12.Appearance.Preview.Options.UseFont = true;
            this.gridView12.Appearance.Preview.Options.UseForeColor = true;
            this.gridView12.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView12.Appearance.Row.Options.UseBackColor = true;
            this.gridView12.Appearance.Row.Options.UseForeColor = true;
            this.gridView12.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView12.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView12.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView12.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView12.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView12.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView12.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView12.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView12.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView12.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView12.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn99,
            this.gridColumn100,
            this.gridColumn101});
            this.gridView12.GridControl = this.Cell8;
            this.gridView12.GroupPanelText = "PO Cell 8";
            this.gridView12.Name = "gridView12";
            this.gridView12.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView12.OptionsView.EnableAppearanceOddRow = true;
            this.gridView12.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn99
            // 
            this.gridColumn99.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn99.AppearanceCell.Options.UseFont = true;
            this.gridColumn99.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn99.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn99.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn99.AppearanceHeader.Options.UseFont = true;
            this.gridColumn99.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn99.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn99.Caption = "No.";
            this.gridColumn99.Name = "gridColumn99";
            this.gridColumn99.OptionsColumn.AllowFocus = false;
            this.gridColumn99.OptionsColumn.ReadOnly = true;
            this.gridColumn99.Visible = true;
            this.gridColumn99.VisibleIndex = 0;
            this.gridColumn99.Width = 20;
            // 
            // gridColumn100
            // 
            this.gridColumn100.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn100.AppearanceHeader.Options.UseFont = true;
            this.gridColumn100.Caption = "PO Number";
            this.gridColumn100.FieldName = "POnumber";
            this.gridColumn100.Name = "gridColumn100";
            this.gridColumn100.OptionsColumn.AllowFocus = false;
            this.gridColumn100.OptionsColumn.ReadOnly = true;
            this.gridColumn100.Visible = true;
            this.gridColumn100.VisibleIndex = 1;
            this.gridColumn100.Width = 100;
            // 
            // gridColumn101
            // 
            this.gridColumn101.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn101.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn101.AppearanceCell.Options.UseFont = true;
            this.gridColumn101.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn101.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn101.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn101.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn101.AppearanceHeader.Options.UseFont = true;
            this.gridColumn101.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn101.Caption = "Qty";
            this.gridColumn101.FieldName = "QtyIn";
            this.gridColumn101.Name = "gridColumn101";
            this.gridColumn101.OptionsColumn.AllowFocus = false;
            this.gridColumn101.OptionsColumn.ReadOnly = true;
            this.gridColumn101.Visible = true;
            this.gridColumn101.VisibleIndex = 2;
            this.gridColumn101.Width = 40;
            // 
            // cardView12
            // 
            this.cardView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn102,
            this.gridColumn103,
            this.gridColumn104,
            this.gridColumn105,
            this.gridColumn106,
            this.gridColumn107});
            this.cardView12.FocusedCardTopFieldIndex = 0;
            this.cardView12.GridControl = this.Cell8;
            this.cardView12.Name = "cardView12";
            this.cardView12.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView12.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn102
            // 
            this.gridColumn102.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn102.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn102.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn102.AppearanceHeader.Options.UseFont = true;
            this.gridColumn102.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn102.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn102.Caption = "Line";
            this.gridColumn102.FieldName = "DocLine";
            this.gridColumn102.Name = "gridColumn102";
            this.gridColumn102.OptionsColumn.AllowEdit = false;
            this.gridColumn102.OptionsColumn.ReadOnly = true;
            this.gridColumn102.Visible = true;
            this.gridColumn102.VisibleIndex = 0;
            this.gridColumn102.Width = 58;
            // 
            // gridColumn103
            // 
            this.gridColumn103.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn103.AppearanceHeader.Options.UseFont = true;
            this.gridColumn103.Caption = "Item NO.";
            this.gridColumn103.FieldName = "DocItem";
            this.gridColumn103.Name = "gridColumn103";
            this.gridColumn103.OptionsColumn.ReadOnly = true;
            this.gridColumn103.Visible = true;
            this.gridColumn103.VisibleIndex = 1;
            this.gridColumn103.Width = 141;
            // 
            // gridColumn104
            // 
            this.gridColumn104.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn104.AppearanceHeader.Options.UseFont = true;
            this.gridColumn104.Caption = "Description";
            this.gridColumn104.FieldName = "ItemName";
            this.gridColumn104.Name = "gridColumn104";
            this.gridColumn104.Visible = true;
            this.gridColumn104.VisibleIndex = 2;
            this.gridColumn104.Width = 140;
            // 
            // gridColumn105
            // 
            this.gridColumn105.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn105.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn105.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn105.AppearanceHeader.Options.UseFont = true;
            this.gridColumn105.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn105.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn105.Caption = "Quantity";
            this.gridColumn105.FieldName = "DocQty";
            this.gridColumn105.Name = "gridColumn105";
            this.gridColumn105.Visible = true;
            this.gridColumn105.VisibleIndex = 3;
            this.gridColumn105.Width = 106;
            // 
            // gridColumn106
            // 
            this.gridColumn106.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn106.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn106.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn106.AppearanceHeader.Options.UseFont = true;
            this.gridColumn106.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn106.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn106.Caption = "Location";
            this.gridColumn106.FieldName = "DocStock";
            this.gridColumn106.Name = "gridColumn106";
            this.gridColumn106.Visible = true;
            this.gridColumn106.VisibleIndex = 4;
            this.gridColumn106.Width = 71;
            // 
            // gridColumn107
            // 
            this.gridColumn107.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn107.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn107.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn107.AppearanceHeader.Options.UseFont = true;
            this.gridColumn107.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn107.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn107.Caption = "Status";
            this.gridColumn107.FieldName = "DocFlag";
            this.gridColumn107.Name = "gridColumn107";
            this.gridColumn107.Visible = true;
            this.gridColumn107.VisibleIndex = 5;
            this.gridColumn107.Width = 50;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(257, 65);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(254, 26);
            this.label16.TabIndex = 135;
            this.label16.Text = "CELL T2";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(777, 392);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(246, 25);
            this.label17.TabIndex = 136;
            this.label17.Text = "CELL 12";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label18.Location = new System.Drawing.Point(1025, 392);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(246, 25);
            this.label18.TabIndex = 137;
            this.label18.Text = "CELL 13";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label19.Location = new System.Drawing.Point(1, 574);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(246, 25);
            this.label19.TabIndex = 138;
            this.label19.Text = "CELL 14";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label20.Location = new System.Drawing.Point(257, 574);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(246, 25);
            this.label20.TabIndex = 139;
            this.label20.Text = "CELL 15";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(509, 573);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(266, 25);
            this.label21.TabIndex = 140;
            this.label21.Text = "CELL S1";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Cell12
            // 
            this.Cell12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell12.Location = new System.Drawing.Point(779, 420);
            this.Cell12.MainView = this.gridView13;
            this.Cell12.Name = "Cell12";
            this.Cell12.Size = new System.Drawing.Size(244, 152);
            this.Cell12.TabIndex = 141;
            this.Cell12.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView13,
            this.cardView13});
            this.Cell12.DoubleClick += new System.EventHandler(this.Cell12_DoubleClick);
            // 
            // gridView13
            // 
            this.gridView13.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView13.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView13.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView13.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView13.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView13.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView13.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView13.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView13.Appearance.Empty.Options.UseBackColor = true;
            this.gridView13.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView13.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView13.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView13.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView13.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView13.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView13.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView13.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView13.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView13.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView13.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView13.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView13.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView13.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView13.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView13.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView13.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView13.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView13.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView13.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView13.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView13.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView13.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView13.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView13.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView13.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView13.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView13.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView13.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView13.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView13.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView13.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView13.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView13.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView13.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView13.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView13.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView13.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView13.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView13.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView13.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView13.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView13.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView13.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView13.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView13.Appearance.Preview.Options.UseFont = true;
            this.gridView13.Appearance.Preview.Options.UseForeColor = true;
            this.gridView13.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView13.Appearance.Row.Options.UseBackColor = true;
            this.gridView13.Appearance.Row.Options.UseForeColor = true;
            this.gridView13.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView13.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView13.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView13.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView13.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView13.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView13.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView13.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView13.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView13.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn108,
            this.gridColumn109,
            this.gridColumn110});
            this.gridView13.GridControl = this.Cell12;
            this.gridView13.GroupPanelText = "PO Cell 12";
            this.gridView13.Name = "gridView13";
            this.gridView13.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView13.OptionsView.EnableAppearanceOddRow = true;
            this.gridView13.ViewCaption = "Show Detail PO Number";
            this.gridView13.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView13_CustomColumnDisplayText);
            // 
            // gridColumn108
            // 
            this.gridColumn108.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn108.AppearanceCell.Options.UseFont = true;
            this.gridColumn108.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn108.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn108.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn108.AppearanceHeader.Options.UseFont = true;
            this.gridColumn108.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn108.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn108.Caption = "No.";
            this.gridColumn108.Name = "gridColumn108";
            this.gridColumn108.OptionsColumn.AllowFocus = false;
            this.gridColumn108.OptionsColumn.ReadOnly = true;
            this.gridColumn108.Visible = true;
            this.gridColumn108.VisibleIndex = 0;
            this.gridColumn108.Width = 20;
            // 
            // gridColumn109
            // 
            this.gridColumn109.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn109.AppearanceHeader.Options.UseFont = true;
            this.gridColumn109.Caption = "PO Number";
            this.gridColumn109.FieldName = "POnumber";
            this.gridColumn109.Name = "gridColumn109";
            this.gridColumn109.OptionsColumn.AllowFocus = false;
            this.gridColumn109.OptionsColumn.ReadOnly = true;
            this.gridColumn109.Visible = true;
            this.gridColumn109.VisibleIndex = 1;
            this.gridColumn109.Width = 100;
            // 
            // gridColumn110
            // 
            this.gridColumn110.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn110.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn110.AppearanceCell.Options.UseFont = true;
            this.gridColumn110.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn110.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn110.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn110.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn110.AppearanceHeader.Options.UseFont = true;
            this.gridColumn110.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn110.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn110.Caption = "Qty";
            this.gridColumn110.FieldName = "QtyIn";
            this.gridColumn110.Name = "gridColumn110";
            this.gridColumn110.OptionsColumn.AllowFocus = false;
            this.gridColumn110.OptionsColumn.ReadOnly = true;
            this.gridColumn110.Visible = true;
            this.gridColumn110.VisibleIndex = 2;
            this.gridColumn110.Width = 40;
            // 
            // cardView13
            // 
            this.cardView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn111,
            this.gridColumn112,
            this.gridColumn113,
            this.gridColumn114,
            this.gridColumn115,
            this.gridColumn116});
            this.cardView13.FocusedCardTopFieldIndex = 0;
            this.cardView13.GridControl = this.Cell12;
            this.cardView13.Name = "cardView13";
            this.cardView13.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView13.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn111
            // 
            this.gridColumn111.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn111.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn111.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn111.AppearanceHeader.Options.UseFont = true;
            this.gridColumn111.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn111.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn111.Caption = "Line";
            this.gridColumn111.FieldName = "DocLine";
            this.gridColumn111.Name = "gridColumn111";
            this.gridColumn111.OptionsColumn.AllowEdit = false;
            this.gridColumn111.OptionsColumn.ReadOnly = true;
            this.gridColumn111.Visible = true;
            this.gridColumn111.VisibleIndex = 0;
            this.gridColumn111.Width = 58;
            // 
            // gridColumn112
            // 
            this.gridColumn112.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn112.AppearanceHeader.Options.UseFont = true;
            this.gridColumn112.Caption = "Item NO.";
            this.gridColumn112.FieldName = "DocItem";
            this.gridColumn112.Name = "gridColumn112";
            this.gridColumn112.OptionsColumn.ReadOnly = true;
            this.gridColumn112.Visible = true;
            this.gridColumn112.VisibleIndex = 1;
            this.gridColumn112.Width = 141;
            // 
            // gridColumn113
            // 
            this.gridColumn113.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn113.AppearanceHeader.Options.UseFont = true;
            this.gridColumn113.Caption = "Description";
            this.gridColumn113.FieldName = "ItemName";
            this.gridColumn113.Name = "gridColumn113";
            this.gridColumn113.Visible = true;
            this.gridColumn113.VisibleIndex = 2;
            this.gridColumn113.Width = 140;
            // 
            // gridColumn114
            // 
            this.gridColumn114.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn114.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn114.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn114.AppearanceHeader.Options.UseFont = true;
            this.gridColumn114.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn114.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn114.Caption = "Quantity";
            this.gridColumn114.FieldName = "DocQty";
            this.gridColumn114.Name = "gridColumn114";
            this.gridColumn114.Visible = true;
            this.gridColumn114.VisibleIndex = 3;
            this.gridColumn114.Width = 106;
            // 
            // gridColumn115
            // 
            this.gridColumn115.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn115.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn115.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn115.AppearanceHeader.Options.UseFont = true;
            this.gridColumn115.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn115.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn115.Caption = "Location";
            this.gridColumn115.FieldName = "DocStock";
            this.gridColumn115.Name = "gridColumn115";
            this.gridColumn115.Visible = true;
            this.gridColumn115.VisibleIndex = 4;
            this.gridColumn115.Width = 71;
            // 
            // gridColumn116
            // 
            this.gridColumn116.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn116.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn116.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn116.AppearanceHeader.Options.UseFont = true;
            this.gridColumn116.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn116.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn116.Caption = "Status";
            this.gridColumn116.FieldName = "DocFlag";
            this.gridColumn116.Name = "gridColumn116";
            this.gridColumn116.Visible = true;
            this.gridColumn116.VisibleIndex = 5;
            this.gridColumn116.Width = 50;
            // 
            // Cell13
            // 
            this.Cell13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell13.Location = new System.Drawing.Point(1027, 420);
            this.Cell13.MainView = this.gridView14;
            this.Cell13.Name = "Cell13";
            this.Cell13.Size = new System.Drawing.Size(244, 152);
            this.Cell13.TabIndex = 142;
            this.Cell13.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView14,
            this.cardView14});
            this.Cell13.DoubleClick += new System.EventHandler(this.Cell13_DoubleClick);
            // 
            // gridView14
            // 
            this.gridView14.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView14.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView14.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView14.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView14.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView14.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView14.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView14.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView14.Appearance.Empty.Options.UseBackColor = true;
            this.gridView14.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView14.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView14.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView14.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView14.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView14.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView14.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView14.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView14.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView14.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView14.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView14.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView14.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView14.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView14.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView14.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView14.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView14.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView14.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView14.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView14.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView14.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView14.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView14.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView14.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView14.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView14.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView14.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView14.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView14.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView14.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView14.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView14.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView14.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView14.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView14.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView14.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView14.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView14.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView14.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView14.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView14.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView14.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView14.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView14.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView14.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView14.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView14.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView14.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView14.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView14.Appearance.Preview.Options.UseFont = true;
            this.gridView14.Appearance.Preview.Options.UseForeColor = true;
            this.gridView14.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView14.Appearance.Row.Options.UseBackColor = true;
            this.gridView14.Appearance.Row.Options.UseForeColor = true;
            this.gridView14.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView14.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView14.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView14.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView14.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView14.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView14.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView14.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView14.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView14.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView14.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView14.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn117,
            this.gridColumn118,
            this.gridColumn119});
            this.gridView14.GridControl = this.Cell13;
            this.gridView14.GroupPanelText = "PO Cell 13";
            this.gridView14.Name = "gridView14";
            this.gridView14.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView14.OptionsView.EnableAppearanceOddRow = true;
            this.gridView14.ViewCaption = "Show Detail PO Number";
            this.gridView14.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView14_CustomColumnDisplayText);
            // 
            // gridColumn117
            // 
            this.gridColumn117.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn117.AppearanceCell.Options.UseFont = true;
            this.gridColumn117.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn117.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn117.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn117.AppearanceHeader.Options.UseFont = true;
            this.gridColumn117.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn117.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn117.Caption = "No.";
            this.gridColumn117.Name = "gridColumn117";
            this.gridColumn117.OptionsColumn.AllowFocus = false;
            this.gridColumn117.OptionsColumn.ReadOnly = true;
            this.gridColumn117.Visible = true;
            this.gridColumn117.VisibleIndex = 0;
            this.gridColumn117.Width = 20;
            // 
            // gridColumn118
            // 
            this.gridColumn118.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn118.AppearanceHeader.Options.UseFont = true;
            this.gridColumn118.Caption = "PO Number";
            this.gridColumn118.FieldName = "POnumber";
            this.gridColumn118.Name = "gridColumn118";
            this.gridColumn118.OptionsColumn.AllowFocus = false;
            this.gridColumn118.OptionsColumn.ReadOnly = true;
            this.gridColumn118.Visible = true;
            this.gridColumn118.VisibleIndex = 1;
            this.gridColumn118.Width = 100;
            // 
            // gridColumn119
            // 
            this.gridColumn119.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn119.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn119.AppearanceCell.Options.UseFont = true;
            this.gridColumn119.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn119.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn119.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn119.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn119.AppearanceHeader.Options.UseFont = true;
            this.gridColumn119.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn119.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn119.Caption = "Qty";
            this.gridColumn119.FieldName = "QtyIn";
            this.gridColumn119.Name = "gridColumn119";
            this.gridColumn119.OptionsColumn.AllowFocus = false;
            this.gridColumn119.OptionsColumn.ReadOnly = true;
            this.gridColumn119.Visible = true;
            this.gridColumn119.VisibleIndex = 2;
            this.gridColumn119.Width = 40;
            // 
            // cardView14
            // 
            this.cardView14.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn120,
            this.gridColumn121,
            this.gridColumn122,
            this.gridColumn123,
            this.gridColumn124,
            this.gridColumn125});
            this.cardView14.FocusedCardTopFieldIndex = 0;
            this.cardView14.GridControl = this.Cell13;
            this.cardView14.Name = "cardView14";
            this.cardView14.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView14.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn120
            // 
            this.gridColumn120.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn120.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn120.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn120.AppearanceHeader.Options.UseFont = true;
            this.gridColumn120.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn120.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn120.Caption = "Line";
            this.gridColumn120.FieldName = "DocLine";
            this.gridColumn120.Name = "gridColumn120";
            this.gridColumn120.OptionsColumn.AllowEdit = false;
            this.gridColumn120.OptionsColumn.ReadOnly = true;
            this.gridColumn120.Visible = true;
            this.gridColumn120.VisibleIndex = 0;
            this.gridColumn120.Width = 58;
            // 
            // gridColumn121
            // 
            this.gridColumn121.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn121.AppearanceHeader.Options.UseFont = true;
            this.gridColumn121.Caption = "Item NO.";
            this.gridColumn121.FieldName = "DocItem";
            this.gridColumn121.Name = "gridColumn121";
            this.gridColumn121.OptionsColumn.ReadOnly = true;
            this.gridColumn121.Visible = true;
            this.gridColumn121.VisibleIndex = 1;
            this.gridColumn121.Width = 141;
            // 
            // gridColumn122
            // 
            this.gridColumn122.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn122.AppearanceHeader.Options.UseFont = true;
            this.gridColumn122.Caption = "Description";
            this.gridColumn122.FieldName = "ItemName";
            this.gridColumn122.Name = "gridColumn122";
            this.gridColumn122.Visible = true;
            this.gridColumn122.VisibleIndex = 2;
            this.gridColumn122.Width = 140;
            // 
            // gridColumn123
            // 
            this.gridColumn123.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn123.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn123.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn123.AppearanceHeader.Options.UseFont = true;
            this.gridColumn123.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn123.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn123.Caption = "Quantity";
            this.gridColumn123.FieldName = "DocQty";
            this.gridColumn123.Name = "gridColumn123";
            this.gridColumn123.Visible = true;
            this.gridColumn123.VisibleIndex = 3;
            this.gridColumn123.Width = 106;
            // 
            // gridColumn124
            // 
            this.gridColumn124.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn124.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn124.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn124.AppearanceHeader.Options.UseFont = true;
            this.gridColumn124.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn124.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn124.Caption = "Location";
            this.gridColumn124.FieldName = "DocStock";
            this.gridColumn124.Name = "gridColumn124";
            this.gridColumn124.Visible = true;
            this.gridColumn124.VisibleIndex = 4;
            this.gridColumn124.Width = 71;
            // 
            // gridColumn125
            // 
            this.gridColumn125.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn125.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn125.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn125.AppearanceHeader.Options.UseFont = true;
            this.gridColumn125.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn125.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn125.Caption = "Status";
            this.gridColumn125.FieldName = "DocFlag";
            this.gridColumn125.Name = "gridColumn125";
            this.gridColumn125.Visible = true;
            this.gridColumn125.VisibleIndex = 5;
            this.gridColumn125.Width = 50;
            // 
            // Cell14
            // 
            this.Cell14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell14.Location = new System.Drawing.Point(2, 600);
            this.Cell14.MainView = this.gridView15;
            this.Cell14.Name = "Cell14";
            this.Cell14.Size = new System.Drawing.Size(244, 152);
            this.Cell14.TabIndex = 143;
            this.Cell14.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView15,
            this.cardView15});
            this.Cell14.DoubleClick += new System.EventHandler(this.Cell14_DoubleClick);
            // 
            // gridView15
            // 
            this.gridView15.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView15.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView15.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView15.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView15.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView15.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView15.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView15.Appearance.Empty.Options.UseBackColor = true;
            this.gridView15.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView15.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView15.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView15.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView15.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView15.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView15.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView15.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView15.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView15.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView15.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView15.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView15.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView15.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView15.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView15.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView15.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView15.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView15.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView15.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView15.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView15.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView15.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView15.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView15.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView15.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView15.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView15.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView15.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView15.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView15.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView15.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView15.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView15.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView15.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView15.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView15.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView15.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView15.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView15.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView15.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView15.Appearance.Preview.Options.UseFont = true;
            this.gridView15.Appearance.Preview.Options.UseForeColor = true;
            this.gridView15.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.Row.Options.UseBackColor = true;
            this.gridView15.Appearance.Row.Options.UseForeColor = true;
            this.gridView15.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView15.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView15.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView15.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView15.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView15.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView15.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView15.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView15.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView15.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView15.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn126,
            this.gridColumn127,
            this.gridColumn128});
            this.gridView15.GridControl = this.Cell14;
            this.gridView15.GroupPanelText = "PO Cell 14";
            this.gridView15.Name = "gridView15";
            this.gridView15.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView15.OptionsView.EnableAppearanceOddRow = true;
            this.gridView15.ViewCaption = "Show Detail PO Number";
            this.gridView15.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView15_CustomColumnDisplayText);
            // 
            // gridColumn126
            // 
            this.gridColumn126.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn126.AppearanceCell.Options.UseFont = true;
            this.gridColumn126.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn126.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn126.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn126.AppearanceHeader.Options.UseFont = true;
            this.gridColumn126.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn126.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn126.Caption = "No.";
            this.gridColumn126.Name = "gridColumn126";
            this.gridColumn126.OptionsColumn.AllowFocus = false;
            this.gridColumn126.OptionsColumn.ReadOnly = true;
            this.gridColumn126.Visible = true;
            this.gridColumn126.VisibleIndex = 0;
            this.gridColumn126.Width = 20;
            // 
            // gridColumn127
            // 
            this.gridColumn127.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn127.AppearanceHeader.Options.UseFont = true;
            this.gridColumn127.Caption = "PO Number";
            this.gridColumn127.FieldName = "POnumber";
            this.gridColumn127.Name = "gridColumn127";
            this.gridColumn127.OptionsColumn.AllowFocus = false;
            this.gridColumn127.OptionsColumn.ReadOnly = true;
            this.gridColumn127.Visible = true;
            this.gridColumn127.VisibleIndex = 1;
            this.gridColumn127.Width = 100;
            // 
            // gridColumn128
            // 
            this.gridColumn128.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn128.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn128.AppearanceCell.Options.UseFont = true;
            this.gridColumn128.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn128.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn128.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn128.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn128.AppearanceHeader.Options.UseFont = true;
            this.gridColumn128.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn128.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn128.Caption = "Qty";
            this.gridColumn128.FieldName = "QtyIn";
            this.gridColumn128.Name = "gridColumn128";
            this.gridColumn128.OptionsColumn.AllowFocus = false;
            this.gridColumn128.OptionsColumn.ReadOnly = true;
            this.gridColumn128.Visible = true;
            this.gridColumn128.VisibleIndex = 2;
            this.gridColumn128.Width = 40;
            // 
            // cardView15
            // 
            this.cardView15.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn129,
            this.gridColumn130,
            this.gridColumn131,
            this.gridColumn132,
            this.gridColumn133,
            this.gridColumn134});
            this.cardView15.FocusedCardTopFieldIndex = 0;
            this.cardView15.GridControl = this.Cell14;
            this.cardView15.Name = "cardView15";
            this.cardView15.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView15.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn129
            // 
            this.gridColumn129.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn129.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn129.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn129.AppearanceHeader.Options.UseFont = true;
            this.gridColumn129.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn129.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn129.Caption = "Line";
            this.gridColumn129.FieldName = "DocLine";
            this.gridColumn129.Name = "gridColumn129";
            this.gridColumn129.OptionsColumn.AllowEdit = false;
            this.gridColumn129.OptionsColumn.ReadOnly = true;
            this.gridColumn129.Visible = true;
            this.gridColumn129.VisibleIndex = 0;
            this.gridColumn129.Width = 58;
            // 
            // gridColumn130
            // 
            this.gridColumn130.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn130.AppearanceHeader.Options.UseFont = true;
            this.gridColumn130.Caption = "Item NO.";
            this.gridColumn130.FieldName = "DocItem";
            this.gridColumn130.Name = "gridColumn130";
            this.gridColumn130.OptionsColumn.ReadOnly = true;
            this.gridColumn130.Visible = true;
            this.gridColumn130.VisibleIndex = 1;
            this.gridColumn130.Width = 141;
            // 
            // gridColumn131
            // 
            this.gridColumn131.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn131.AppearanceHeader.Options.UseFont = true;
            this.gridColumn131.Caption = "Description";
            this.gridColumn131.FieldName = "ItemName";
            this.gridColumn131.Name = "gridColumn131";
            this.gridColumn131.Visible = true;
            this.gridColumn131.VisibleIndex = 2;
            this.gridColumn131.Width = 140;
            // 
            // gridColumn132
            // 
            this.gridColumn132.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn132.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn132.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn132.AppearanceHeader.Options.UseFont = true;
            this.gridColumn132.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn132.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn132.Caption = "Quantity";
            this.gridColumn132.FieldName = "DocQty";
            this.gridColumn132.Name = "gridColumn132";
            this.gridColumn132.Visible = true;
            this.gridColumn132.VisibleIndex = 3;
            this.gridColumn132.Width = 106;
            // 
            // gridColumn133
            // 
            this.gridColumn133.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn133.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn133.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn133.AppearanceHeader.Options.UseFont = true;
            this.gridColumn133.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn133.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn133.Caption = "Location";
            this.gridColumn133.FieldName = "DocStock";
            this.gridColumn133.Name = "gridColumn133";
            this.gridColumn133.Visible = true;
            this.gridColumn133.VisibleIndex = 4;
            this.gridColumn133.Width = 71;
            // 
            // gridColumn134
            // 
            this.gridColumn134.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn134.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn134.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn134.AppearanceHeader.Options.UseFont = true;
            this.gridColumn134.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn134.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn134.Caption = "Status";
            this.gridColumn134.FieldName = "DocFlag";
            this.gridColumn134.Name = "gridColumn134";
            this.gridColumn134.Visible = true;
            this.gridColumn134.VisibleIndex = 5;
            this.gridColumn134.Width = 50;
            // 
            // Cell15
            // 
            this.Cell15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Cell15.Location = new System.Drawing.Point(255, 600);
            this.Cell15.MainView = this.gridView16;
            this.Cell15.Name = "Cell15";
            this.Cell15.Size = new System.Drawing.Size(251, 152);
            this.Cell15.TabIndex = 144;
            this.Cell15.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView16,
            this.cardView16});
            this.Cell15.DoubleClick += new System.EventHandler(this.Cell15_DoubleClick);
            // 
            // gridView16
            // 
            this.gridView16.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView16.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView16.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView16.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView16.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView16.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView16.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView16.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView16.Appearance.Empty.Options.UseBackColor = true;
            this.gridView16.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView16.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView16.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView16.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView16.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView16.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView16.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView16.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView16.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView16.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView16.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView16.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView16.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView16.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView16.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView16.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView16.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView16.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView16.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView16.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView16.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView16.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView16.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView16.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView16.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView16.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView16.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView16.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView16.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView16.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView16.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView16.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView16.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView16.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView16.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView16.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView16.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView16.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView16.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView16.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView16.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView16.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView16.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView16.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView16.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView16.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView16.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView16.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView16.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView16.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView16.Appearance.Preview.Options.UseFont = true;
            this.gridView16.Appearance.Preview.Options.UseForeColor = true;
            this.gridView16.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView16.Appearance.Row.Options.UseBackColor = true;
            this.gridView16.Appearance.Row.Options.UseForeColor = true;
            this.gridView16.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView16.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView16.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView16.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView16.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView16.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView16.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView16.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView16.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView16.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView16.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn135,
            this.gridColumn136,
            this.gridColumn137});
            this.gridView16.GridControl = this.Cell15;
            this.gridView16.GroupPanelText = "PO Cell 15";
            this.gridView16.Name = "gridView16";
            this.gridView16.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView16.OptionsView.EnableAppearanceOddRow = true;
            this.gridView16.ViewCaption = "Show Detail PO Number";
            this.gridView16.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView16_CustomColumnDisplayText);
            // 
            // gridColumn135
            // 
            this.gridColumn135.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn135.AppearanceCell.Options.UseFont = true;
            this.gridColumn135.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn135.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn135.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn135.AppearanceHeader.Options.UseFont = true;
            this.gridColumn135.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn135.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn135.Caption = "No.";
            this.gridColumn135.Name = "gridColumn135";
            this.gridColumn135.OptionsColumn.AllowFocus = false;
            this.gridColumn135.OptionsColumn.ReadOnly = true;
            this.gridColumn135.Visible = true;
            this.gridColumn135.VisibleIndex = 0;
            this.gridColumn135.Width = 20;
            // 
            // gridColumn136
            // 
            this.gridColumn136.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn136.AppearanceHeader.Options.UseFont = true;
            this.gridColumn136.Caption = "PO Number";
            this.gridColumn136.FieldName = "POnumber";
            this.gridColumn136.Name = "gridColumn136";
            this.gridColumn136.OptionsColumn.AllowFocus = false;
            this.gridColumn136.OptionsColumn.ReadOnly = true;
            this.gridColumn136.Visible = true;
            this.gridColumn136.VisibleIndex = 1;
            this.gridColumn136.Width = 100;
            // 
            // gridColumn137
            // 
            this.gridColumn137.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn137.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn137.AppearanceCell.Options.UseFont = true;
            this.gridColumn137.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn137.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn137.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn137.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn137.AppearanceHeader.Options.UseFont = true;
            this.gridColumn137.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn137.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn137.Caption = "Qty";
            this.gridColumn137.FieldName = "QtyIn";
            this.gridColumn137.Name = "gridColumn137";
            this.gridColumn137.OptionsColumn.AllowFocus = false;
            this.gridColumn137.OptionsColumn.ReadOnly = true;
            this.gridColumn137.Visible = true;
            this.gridColumn137.VisibleIndex = 2;
            this.gridColumn137.Width = 40;
            // 
            // cardView16
            // 
            this.cardView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn138,
            this.gridColumn139,
            this.gridColumn140,
            this.gridColumn141,
            this.gridColumn142,
            this.gridColumn143});
            this.cardView16.FocusedCardTopFieldIndex = 0;
            this.cardView16.GridControl = this.Cell15;
            this.cardView16.Name = "cardView16";
            this.cardView16.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView16.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn138
            // 
            this.gridColumn138.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn138.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn138.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn138.AppearanceHeader.Options.UseFont = true;
            this.gridColumn138.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn138.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn138.Caption = "Line";
            this.gridColumn138.FieldName = "DocLine";
            this.gridColumn138.Name = "gridColumn138";
            this.gridColumn138.OptionsColumn.AllowEdit = false;
            this.gridColumn138.OptionsColumn.ReadOnly = true;
            this.gridColumn138.Visible = true;
            this.gridColumn138.VisibleIndex = 0;
            this.gridColumn138.Width = 58;
            // 
            // gridColumn139
            // 
            this.gridColumn139.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn139.AppearanceHeader.Options.UseFont = true;
            this.gridColumn139.Caption = "Item NO.";
            this.gridColumn139.FieldName = "DocItem";
            this.gridColumn139.Name = "gridColumn139";
            this.gridColumn139.OptionsColumn.ReadOnly = true;
            this.gridColumn139.Visible = true;
            this.gridColumn139.VisibleIndex = 1;
            this.gridColumn139.Width = 141;
            // 
            // gridColumn140
            // 
            this.gridColumn140.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn140.AppearanceHeader.Options.UseFont = true;
            this.gridColumn140.Caption = "Description";
            this.gridColumn140.FieldName = "ItemName";
            this.gridColumn140.Name = "gridColumn140";
            this.gridColumn140.Visible = true;
            this.gridColumn140.VisibleIndex = 2;
            this.gridColumn140.Width = 140;
            // 
            // gridColumn141
            // 
            this.gridColumn141.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn141.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn141.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn141.AppearanceHeader.Options.UseFont = true;
            this.gridColumn141.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn141.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn141.Caption = "Quantity";
            this.gridColumn141.FieldName = "DocQty";
            this.gridColumn141.Name = "gridColumn141";
            this.gridColumn141.Visible = true;
            this.gridColumn141.VisibleIndex = 3;
            this.gridColumn141.Width = 106;
            // 
            // gridColumn142
            // 
            this.gridColumn142.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn142.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn142.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn142.AppearanceHeader.Options.UseFont = true;
            this.gridColumn142.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn142.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn142.Caption = "Location";
            this.gridColumn142.FieldName = "DocStock";
            this.gridColumn142.Name = "gridColumn142";
            this.gridColumn142.Visible = true;
            this.gridColumn142.VisibleIndex = 4;
            this.gridColumn142.Width = 71;
            // 
            // gridColumn143
            // 
            this.gridColumn143.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn143.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn143.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn143.AppearanceHeader.Options.UseFont = true;
            this.gridColumn143.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn143.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn143.Caption = "Status";
            this.gridColumn143.FieldName = "DocFlag";
            this.gridColumn143.Name = "gridColumn143";
            this.gridColumn143.Visible = true;
            this.gridColumn143.VisibleIndex = 5;
            this.gridColumn143.Width = 50;
            // 
            // CellS1
            // 
            this.CellS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CellS1.Location = new System.Drawing.Point(512, 600);
            this.CellS1.MainView = this.gridView17;
            this.CellS1.Name = "CellS1";
            this.CellS1.Size = new System.Drawing.Size(260, 152);
            this.CellS1.TabIndex = 145;
            this.CellS1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView17,
            this.cardView17});
            this.CellS1.DoubleClick += new System.EventHandler(this.CellS1_DoubleClick);
            // 
            // gridView17
            // 
            this.gridView17.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView17.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView17.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView17.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView17.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView17.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView17.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView17.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView17.Appearance.Empty.Options.UseBackColor = true;
            this.gridView17.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView17.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView17.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView17.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView17.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView17.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView17.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView17.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView17.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView17.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView17.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView17.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView17.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView17.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView17.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView17.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView17.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView17.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView17.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView17.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView17.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView17.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView17.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView17.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView17.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView17.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView17.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView17.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView17.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView17.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView17.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView17.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView17.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView17.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView17.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView17.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView17.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView17.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView17.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView17.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView17.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView17.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView17.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView17.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView17.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView17.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView17.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView17.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView17.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView17.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView17.Appearance.Preview.Options.UseFont = true;
            this.gridView17.Appearance.Preview.Options.UseForeColor = true;
            this.gridView17.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView17.Appearance.Row.Options.UseBackColor = true;
            this.gridView17.Appearance.Row.Options.UseForeColor = true;
            this.gridView17.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView17.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView17.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView17.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView17.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView17.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView17.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView17.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView17.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView17.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView17.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView17.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn144,
            this.gridColumn145,
            this.gridColumn146});
            this.gridView17.GridControl = this.CellS1;
            this.gridView17.GroupPanelText = "PO Cell S1";
            this.gridView17.Name = "gridView17";
            this.gridView17.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView17.OptionsView.EnableAppearanceOddRow = true;
            this.gridView17.ViewCaption = "Show Detail PO Number";
            this.gridView17.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView17_CustomColumnDisplayText);
            // 
            // gridColumn144
            // 
            this.gridColumn144.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn144.AppearanceCell.Options.UseFont = true;
            this.gridColumn144.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn144.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn144.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn144.AppearanceHeader.Options.UseFont = true;
            this.gridColumn144.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn144.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn144.Caption = "No.";
            this.gridColumn144.Name = "gridColumn144";
            this.gridColumn144.OptionsColumn.AllowFocus = false;
            this.gridColumn144.OptionsColumn.ReadOnly = true;
            this.gridColumn144.Visible = true;
            this.gridColumn144.VisibleIndex = 0;
            this.gridColumn144.Width = 20;
            // 
            // gridColumn145
            // 
            this.gridColumn145.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn145.AppearanceHeader.Options.UseFont = true;
            this.gridColumn145.Caption = "PO Number";
            this.gridColumn145.FieldName = "POnumber";
            this.gridColumn145.Name = "gridColumn145";
            this.gridColumn145.OptionsColumn.AllowFocus = false;
            this.gridColumn145.OptionsColumn.ReadOnly = true;
            this.gridColumn145.Visible = true;
            this.gridColumn145.VisibleIndex = 1;
            this.gridColumn145.Width = 100;
            // 
            // gridColumn146
            // 
            this.gridColumn146.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn146.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn146.AppearanceCell.Options.UseFont = true;
            this.gridColumn146.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn146.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn146.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn146.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn146.AppearanceHeader.Options.UseFont = true;
            this.gridColumn146.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn146.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn146.Caption = "Qty";
            this.gridColumn146.FieldName = "QtyIn";
            this.gridColumn146.Name = "gridColumn146";
            this.gridColumn146.OptionsColumn.AllowFocus = false;
            this.gridColumn146.OptionsColumn.ReadOnly = true;
            this.gridColumn146.Visible = true;
            this.gridColumn146.VisibleIndex = 2;
            this.gridColumn146.Width = 40;
            // 
            // cardView17
            // 
            this.cardView17.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn147,
            this.gridColumn148,
            this.gridColumn149,
            this.gridColumn150,
            this.gridColumn151,
            this.gridColumn152});
            this.cardView17.FocusedCardTopFieldIndex = 0;
            this.cardView17.GridControl = this.CellS1;
            this.cardView17.Name = "cardView17";
            this.cardView17.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView17.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn147
            // 
            this.gridColumn147.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn147.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn147.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn147.AppearanceHeader.Options.UseFont = true;
            this.gridColumn147.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn147.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn147.Caption = "Line";
            this.gridColumn147.FieldName = "DocLine";
            this.gridColumn147.Name = "gridColumn147";
            this.gridColumn147.OptionsColumn.AllowEdit = false;
            this.gridColumn147.OptionsColumn.ReadOnly = true;
            this.gridColumn147.Visible = true;
            this.gridColumn147.VisibleIndex = 0;
            this.gridColumn147.Width = 58;
            // 
            // gridColumn148
            // 
            this.gridColumn148.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn148.AppearanceHeader.Options.UseFont = true;
            this.gridColumn148.Caption = "Item NO.";
            this.gridColumn148.FieldName = "DocItem";
            this.gridColumn148.Name = "gridColumn148";
            this.gridColumn148.OptionsColumn.ReadOnly = true;
            this.gridColumn148.Visible = true;
            this.gridColumn148.VisibleIndex = 1;
            this.gridColumn148.Width = 141;
            // 
            // gridColumn149
            // 
            this.gridColumn149.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn149.AppearanceHeader.Options.UseFont = true;
            this.gridColumn149.Caption = "Description";
            this.gridColumn149.FieldName = "ItemName";
            this.gridColumn149.Name = "gridColumn149";
            this.gridColumn149.Visible = true;
            this.gridColumn149.VisibleIndex = 2;
            this.gridColumn149.Width = 140;
            // 
            // gridColumn150
            // 
            this.gridColumn150.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn150.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn150.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn150.AppearanceHeader.Options.UseFont = true;
            this.gridColumn150.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn150.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn150.Caption = "Quantity";
            this.gridColumn150.FieldName = "DocQty";
            this.gridColumn150.Name = "gridColumn150";
            this.gridColumn150.Visible = true;
            this.gridColumn150.VisibleIndex = 3;
            this.gridColumn150.Width = 106;
            // 
            // gridColumn151
            // 
            this.gridColumn151.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn151.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn151.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn151.AppearanceHeader.Options.UseFont = true;
            this.gridColumn151.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn151.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn151.Caption = "Location";
            this.gridColumn151.FieldName = "DocStock";
            this.gridColumn151.Name = "gridColumn151";
            this.gridColumn151.Visible = true;
            this.gridColumn151.VisibleIndex = 4;
            this.gridColumn151.Width = 71;
            // 
            // gridColumn152
            // 
            this.gridColumn152.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn152.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn152.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn152.AppearanceHeader.Options.UseFont = true;
            this.gridColumn152.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn152.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn152.Caption = "Status";
            this.gridColumn152.FieldName = "DocFlag";
            this.gridColumn152.Name = "gridColumn152";
            this.gridColumn152.Visible = true;
            this.gridColumn152.VisibleIndex = 5;
            this.gridColumn152.Width = 50;
            // 
            // ShowCellT21
            // 
            this.ShowCellT21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ShowCellT21.Location = new System.Drawing.Point(258, 93);
            this.ShowCellT21.MainView = this.gridView18;
            this.ShowCellT21.Name = "ShowCellT21";
            this.ShowCellT21.Size = new System.Drawing.Size(249, 126);
            this.ShowCellT21.TabIndex = 146;
            this.ShowCellT21.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView18,
            this.cardView18});
            this.ShowCellT21.DoubleClick += new System.EventHandler(this.ShowCellT21_DoubleClick);
            // 
            // gridView18
            // 
            this.gridView18.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView18.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView18.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView18.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView18.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView18.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView18.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView18.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView18.Appearance.Empty.Options.UseBackColor = true;
            this.gridView18.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView18.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView18.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView18.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView18.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView18.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView18.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView18.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView18.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView18.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView18.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.gridView18.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView18.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView18.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView18.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView18.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.gridView18.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.gridView18.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView18.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView18.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView18.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView18.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView18.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView18.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView18.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView18.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView18.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView18.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView18.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView18.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView18.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView18.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView18.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView18.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView18.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView18.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.gridView18.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView18.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView18.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView18.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.gridView18.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView18.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView18.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView18.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView18.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView18.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView18.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView18.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView18.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView18.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView18.Appearance.Preview.Options.UseFont = true;
            this.gridView18.Appearance.Preview.Options.UseForeColor = true;
            this.gridView18.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView18.Appearance.Row.Options.UseBackColor = true;
            this.gridView18.Appearance.Row.Options.UseForeColor = true;
            this.gridView18.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.gridView18.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView18.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView18.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.gridView18.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView18.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView18.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView18.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView18.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView18.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.gridView18.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView18.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn153,
            this.gridColumn154,
            this.gridColumn155});
            this.gridView18.GridControl = this.ShowCellT21;
            this.gridView18.GroupPanelText = "PO Cell Training2";
            this.gridView18.Name = "gridView18";
            this.gridView18.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView18.OptionsView.EnableAppearanceOddRow = true;
            this.gridView18.ViewCaption = "Show Detail PO Number";
            this.gridView18.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView18_CustomColumnDisplayText);
            // 
            // gridColumn153
            // 
            this.gridColumn153.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn153.AppearanceCell.Options.UseFont = true;
            this.gridColumn153.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn153.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn153.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn153.AppearanceHeader.Options.UseFont = true;
            this.gridColumn153.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn153.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn153.Caption = "No.";
            this.gridColumn153.Name = "gridColumn153";
            this.gridColumn153.OptionsColumn.AllowFocus = false;
            this.gridColumn153.OptionsColumn.ReadOnly = true;
            this.gridColumn153.Visible = true;
            this.gridColumn153.VisibleIndex = 0;
            this.gridColumn153.Width = 20;
            // 
            // gridColumn154
            // 
            this.gridColumn154.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn154.AppearanceHeader.Options.UseFont = true;
            this.gridColumn154.Caption = "PO Number";
            this.gridColumn154.FieldName = "POnumber";
            this.gridColumn154.Name = "gridColumn154";
            this.gridColumn154.OptionsColumn.AllowFocus = false;
            this.gridColumn154.OptionsColumn.ReadOnly = true;
            this.gridColumn154.Visible = true;
            this.gridColumn154.VisibleIndex = 1;
            this.gridColumn154.Width = 100;
            // 
            // gridColumn155
            // 
            this.gridColumn155.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn155.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn155.AppearanceCell.Options.UseFont = true;
            this.gridColumn155.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn155.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn155.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn155.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn155.AppearanceHeader.Options.UseFont = true;
            this.gridColumn155.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn155.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn155.Caption = "Qty";
            this.gridColumn155.FieldName = "QtyIn";
            this.gridColumn155.Name = "gridColumn155";
            this.gridColumn155.OptionsColumn.AllowFocus = false;
            this.gridColumn155.OptionsColumn.ReadOnly = true;
            this.gridColumn155.Visible = true;
            this.gridColumn155.VisibleIndex = 2;
            this.gridColumn155.Width = 40;
            // 
            // cardView18
            // 
            this.cardView18.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn156,
            this.gridColumn157,
            this.gridColumn158,
            this.gridColumn159,
            this.gridColumn160,
            this.gridColumn161});
            this.cardView18.FocusedCardTopFieldIndex = 0;
            this.cardView18.GridControl = this.ShowCellT21;
            this.cardView18.Name = "cardView18";
            this.cardView18.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView18.ViewCaption = "Show Detail PO Number";
            // 
            // gridColumn156
            // 
            this.gridColumn156.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn156.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn156.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn156.AppearanceHeader.Options.UseFont = true;
            this.gridColumn156.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn156.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn156.Caption = "Line";
            this.gridColumn156.FieldName = "DocLine";
            this.gridColumn156.Name = "gridColumn156";
            this.gridColumn156.OptionsColumn.AllowEdit = false;
            this.gridColumn156.OptionsColumn.ReadOnly = true;
            this.gridColumn156.Visible = true;
            this.gridColumn156.VisibleIndex = 0;
            this.gridColumn156.Width = 58;
            // 
            // gridColumn157
            // 
            this.gridColumn157.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn157.AppearanceHeader.Options.UseFont = true;
            this.gridColumn157.Caption = "Item NO.";
            this.gridColumn157.FieldName = "DocItem";
            this.gridColumn157.Name = "gridColumn157";
            this.gridColumn157.OptionsColumn.ReadOnly = true;
            this.gridColumn157.Visible = true;
            this.gridColumn157.VisibleIndex = 1;
            this.gridColumn157.Width = 141;
            // 
            // gridColumn158
            // 
            this.gridColumn158.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn158.AppearanceHeader.Options.UseFont = true;
            this.gridColumn158.Caption = "Description";
            this.gridColumn158.FieldName = "ItemName";
            this.gridColumn158.Name = "gridColumn158";
            this.gridColumn158.Visible = true;
            this.gridColumn158.VisibleIndex = 2;
            this.gridColumn158.Width = 140;
            // 
            // gridColumn159
            // 
            this.gridColumn159.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn159.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn159.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn159.AppearanceHeader.Options.UseFont = true;
            this.gridColumn159.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn159.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn159.Caption = "Quantity";
            this.gridColumn159.FieldName = "DocQty";
            this.gridColumn159.Name = "gridColumn159";
            this.gridColumn159.Visible = true;
            this.gridColumn159.VisibleIndex = 3;
            this.gridColumn159.Width = 106;
            // 
            // gridColumn160
            // 
            this.gridColumn160.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn160.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn160.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn160.AppearanceHeader.Options.UseFont = true;
            this.gridColumn160.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn160.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn160.Caption = "Location";
            this.gridColumn160.FieldName = "DocStock";
            this.gridColumn160.Name = "gridColumn160";
            this.gridColumn160.Visible = true;
            this.gridColumn160.VisibleIndex = 4;
            this.gridColumn160.Width = 71;
            // 
            // gridColumn161
            // 
            this.gridColumn161.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn161.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn161.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn161.AppearanceHeader.Options.UseFont = true;
            this.gridColumn161.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn161.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn161.Caption = "Status";
            this.gridColumn161.FieldName = "DocFlag";
            this.gridColumn161.Name = "gridColumn161";
            this.gridColumn161.Visible = true;
            this.gridColumn161.VisibleIndex = 5;
            this.gridColumn161.Width = 50;
            // 
            // FrmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 750);
            this.Controls.Add(this.ShowCellT21);
            this.Controls.Add(this.CellS1);
            this.Controls.Add(this.Cell15);
            this.Controls.Add(this.Cell14);
            this.Controls.Add(this.Cell13);
            this.Controls.Add(this.Cell12);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Cell11);
            this.Controls.Add(this.Cell10);
            this.Controls.Add(this.Cell9);
            this.Controls.Add(this.Cell8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Cell7);
            this.Controls.Add(this.Cell6);
            this.Controls.Add(this.Cell5);
            this.Controls.Add(this.CboS);
            this.Controls.Add(this.Cell4);
            this.Controls.Add(this.Cell3);
            this.Controls.Add(this.Cell2);
            this.Controls.Add(this.Cell1);
            this.Controls.Add(this.ShowCellT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSchedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCellTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPORefQtyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCellT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cell15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCellT21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView18)).EndInit();
            this.ResumeLayout(false);

        }

        private void Cell8_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView12.FocusedRowHandle;
            DataRow row = gridView12.GetDataRow(index);

            string DocItem = Convert.ToString(gridView12.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell8();
            }
        }

        private void Cell9_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView11.FocusedRowHandle;
            DataRow row = gridView11.GetDataRow(index);

            string DocItem = Convert.ToString(gridView11.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell9();
            }

        }

        private void Cell10_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView10.FocusedRowHandle;
            DataRow row = gridView10.GetDataRow(index);

            string DocItem = Convert.ToString(gridView10.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell10();
            }


        }

        #region "cell11"
        private void Cell11_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView9.FocusedRowHandle;
            DataRow row = gridView9.GetDataRow(index);

            string DocItem = Convert.ToString(gridView9.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell11();
            }
        }
        #endregion

        private void gridView18_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView11_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView10_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView9_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView13_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView14_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }



        private void gridView16_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);

        }

        private void gridView17_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void gridView15_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")

                // string num = Convert.ToString(Convert.ToInt16(e.RowHandle) + 1);
                e.DisplayText = Convert.ToString(Convert.ToInt16(e.ListSourceRowIndex) + 1);
        }

        private void ShowCellT21_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView18.FocusedRowHandle;
            DataRow row = gridView18.GetDataRow(index);

            string DocItem = Convert.ToString(gridView18.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCellT2();
            }
        }

        #region " delete cell12"
        private void Cell12_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView13.FocusedRowHandle;
            DataRow row = gridView13.GetDataRow(index);

            string DocItem = Convert.ToString(gridView13.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell12();
            }
        }
        #endregion

        #region "cell13"
        private void Cell13_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView14.FocusedRowHandle;
            DataRow row = gridView14.GetDataRow(index);

            string DocItem = Convert.ToString(gridView14.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell13();
            }
        }
        #endregion

        #region "delete Cell14"
        private void Cell14_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView15.FocusedRowHandle;
            DataRow row = gridView15.GetDataRow(index);

            string DocItem = Convert.ToString(gridView15.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell14();
            }
        }
        #endregion

        #region "cell 15"
        private void Cell15_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView16.FocusedRowHandle;
            DataRow row = gridView16.GetDataRow(index);

            string DocItem = Convert.ToString(gridView16.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCell15();
            }
        }
        #endregion

        private void CellS1_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView17.FocusedRowHandle;
            DataRow row = gridView17.GetDataRow(index);

            string DocItem = Convert.ToString(gridView17.GetDataRow(index)["POnumber"]);
            if ((MessageBox.Show(" คุณต้องการลบ PO : " + DocItem + " นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.A_ScheduleCell where POnumber='" + DocItem + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                ShowCellS1();
            }
        }

    }
}
