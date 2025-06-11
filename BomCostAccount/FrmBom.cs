using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using DatabaseHelperOdb;
using DevExpress.XtraGrid.Columns;
using System.Configuration;
using System.Threading;
using System.Diagnostics;

namespace PicklistBOM.BomCostAccount
{

    public partial class FrmBom : Form
    {
        OdbcCommand comm = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds= new DataSet();
        DataSet ds1 = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        Boolean Isfind4 = false;
        Boolean Isfind5 = false;
        Boolean Isfind6 = false;
        Boolean Isfind7 = false;
        public FrmBom()
        {
            InitializeComponent();
        }

        private void FrmBom_Load(object sender, EventArgs e)
        {
            //external
            CallShowGroup();
            CallTimeRate();
            CallEFICIENCY();

            //internal (local)
            CallShowGrouplocal();
            CallTimeRatelocal();
            CallEFICIENCYlocal();
        }

        #region "      CallShowGrouplocal();"
        private void CallShowGrouplocal()
        {
            try
            {
                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccesslocal());
                conn.Open();


                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT GROUPUSE.GROUPTYPE, GROUPUSE.GROUPNAME, GROUPUSE.GPERCENT FROM GROUPUSE ";

                if (Isfind3 == true)
                {
                    ds.Tables["style2"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "style2");
                //*** DropDownList ***// 
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind3 = true;
                    dt = ds.Tables["style2"];
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].Width = 158;
                    dataGridView2.Columns[0].HeaderText = "GROUPTYPE";
                    dataGridView2.Columns[0].ReadOnly = true;
                    dataGridView2.Columns[1].Width = 250;
                    dataGridView2.Columns[1].HeaderText = "GROUPNAME";
                    dataGridView2.Columns[2].Width = 90;
                    dataGridView2.Columns[2].HeaderText = "Use %";
                    //dataGridView1.Columns[2].DefaultHeaderCellType = DataGridViewContentAlignment.MiddleCenter;
                    // dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    Isfind3 = false;
                    //  this.gridshow.DataSource = null;
                    dataGridView2.DataSource = null;
                }

                da = null;
                //conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
        
        
        
        }
        #endregion

        #region "CallTimeRatelocal()"
        private void CallTimeRatelocal()
        {
            try
            {

                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccesslocal());
                conn.Open();


                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT GROUPUSE.TimeRate FROM GROUPUSE ";

                if (Isfind5 == true)
                {
                    ds.Tables["show2"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "show2");
                //*** DropDownList ***// 
                if (ds.Tables["show2"].Rows.Count != 0)
                {
                    Isfind5 = true;
                    // dt = ds.Tables["show"];
                    lo_AL_RATE.Text = Convert.ToDouble(ds.Tables["show2"].Rows[0]["TimeRate"]).ToString("#,###.00");


                }
                else
                {
                    Isfind5 = false;
                }

                da = null;
                //conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
        
        }
        #endregion

        #region "   CallEFICIENCYlocal();"
        private void CallEFICIENCYlocal()
        {
            try
            {  //ConfigurationManager.AppSettings["ConnectAccess"];

                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccesslocal());
                conn.Open();


                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT EFICIENCY_RATE,DL_RATE,OH_RATE,CH_RATE,SALE_RATE,EXPFG_RATE  FROM ALLOWANCE ";

                if (Isfind6 == true)
                {
                    ds.Tables["EFICIENCY2"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "EFICIENCY2");
                //*** DropDownList ***// 
                if (ds.Tables["EFICIENCY2"].Rows.Count != 0)
                {
                    Isfind6 = true;
                    // dt = ds.Tables["show"];
                    lo_EFICIENCY_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["EFICIENCY_RATE"]).ToString("#,###.00");
                    lo_DL_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["DL_RATE"]).ToString("#,###.00");
                    lo_OH_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["OH_RATE"]).ToString("#,###.00");
                    lo_CH_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["CH_RATE"]).ToString("#,###.00");
                    lo_SALE_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["SALE_RATE"]).ToString("#,###.00");
                    lo_EXPFG_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY2"].Rows[0]["EXPFG_RATE"]).ToString("#,###.00");


                }
                else
                {
                    Isfind6 = false;
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
        #region " CallShowGroup"
        private void CallShowGroup()
        {
            try
            {
                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccess());
                conn.Open();
           

                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT GROUPUSE.GROUPTYPE, GROUPUSE.GROUPNAME, GROUPUSE.GPERCENT FROM GROUPUSE ";

                if (Isfind1 == true)
                {
                    ds.Tables["style"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "style");
                //*** DropDownList ***// 
                if (ds.Tables["style"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["style"];
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 158;
                    dataGridView1.Columns[0].HeaderText = "GROUPTYPE";
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].Width = 250;
                    dataGridView1.Columns[1].HeaderText = "GROUPNAME";
                    dataGridView1.Columns[2].Width = 90;
                    dataGridView1.Columns[2].HeaderText = "Use %";
                   //dataGridView1.Columns[2].DefaultHeaderCellType = DataGridViewContentAlignment.MiddleCenter;
                   // dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    Isfind1 = false;
                  //  this.gridshow.DataSource = null;
                    dataGridView1.DataSource = null;
                }

                da = null;
                //conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
        
        
        }
        #endregion

        #region "CallTimeRate()"
        private void CallTimeRate()
        {
          try
            {
              
              OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccess());
                conn.Open();
           

                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT GROUPUSE.TimeRate FROM GROUPUSE ";

                if (Isfind2 == true)
                {
                    ds.Tables["show"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "show");
                //*** DropDownList ***// 
                if (ds.Tables["show"].Rows.Count != 0)
                {
                    Isfind2= true;
                   // dt = ds.Tables["show"];
                    AL_RATE.Text = Convert.ToDouble(ds.Tables["show"].Rows[0]["TimeRate"]).ToString("#,###.00");

                 
                }
                else
                {
                    Isfind2 = false;
                }

                da = null;
                //conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
        }
        #endregion

        #region "  CallEFICIENCY()"
        private void CallEFICIENCY()
        {
            try
            {  //ConfigurationManager.AppSettings["ConnectAccess"];

                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccess());
                conn.Open();


                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT EFICIENCY_RATE,DL_RATE,OH_RATE,CH_RATE,SALE_RATE,EXPFG_RATE  FROM ALLOWANCE ";

                if (Isfind == true)
                {
                    ds.Tables["EFICIENCY"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "EFICIENCY");
                //*** DropDownList ***// 
                if (ds.Tables["EFICIENCY"].Rows.Count != 0)
                {
                    Isfind = true;
                    // dt = ds.Tables["show"];
                    EFICIENCY_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["EFICIENCY_RATE"]).ToString("#,###.00");
                    DL_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["DL_RATE"]).ToString("#,###.00");
                    OH_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["OH_RATE"]).ToString("#,###.00");
                    CH_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["CH_RATE"]).ToString("#,###.00");
                    SALE_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["SALE_RATE"]).ToString("#,###.00");
                    EXPFG_RATE.Text = Convert.ToDouble(ds.Tables["EFICIENCY"].Rows[0]["EXPFG_RATE"]).ToString("#,###.00");


                }
                else
                {
                    Isfind = false;
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

        private void bntsave_Click(object sender, EventArgs e)
        {
            //if (cbowip.Text == "")
            //{
            //    MessageBox.Show("กรุณาเลือก Wip ที่จะคำนวณด้วย");
            //    return;
            //}

            if ((MessageBox.Show(" คุณต้องการบันทึกรายการ EXPORT นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                UpdateGroup();//ยังไม่มี Update Table GROUPUSE 
                UpdateEficiencyTT();//Update Table  TOTALBOM
                UpdateALLOWANCE(); //Update Table ALLOWANCE
                UpdateEficiencyBOM(); //Update table MBOM
                if (cbowip.Text == "")
                {
                    MessageBox.Show("กรุณาเลือก Wip ที่จะคำนวณด้วย");
                    return;
                }
                Upitem(this.cbowip.Text); //update table items
                MessageBox.Show("Save Complete");
            }
        }

        #region "UpdateGroupuse()"\
        private void UpdateGroup()
        {

            //for update
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
             try
              {

                string GROUPTYPE = dr.Cells["GROUPTYPE"].Value.ToString();
               
                string GROUPNAME = dr.Cells["GROUPNAME"].Value.ToString();
                string GPERCENT = dr.Cells["GPERCENT"].Value.ToString();

                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update GROUPUSE SET GROUPTYPE='" + GROUPTYPE + "',GROUPNAME='" + GROUPNAME + "',GPERCENT='" + GPERCENT + "',TimeRate='" + AL_RATE.Text.Trim() + "' WHERE GROUPTYPE=@GROUPTYPE";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
              //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                cmdUpdate.Connection = OCon;

                cmdUpdate.ExecuteNonQuery();
                OCon.Close();

          
              }
                 catch (Exception ex)
              {
                  //   MessageBox.Show("Error" + ex);
                  return;
             }

                //}
            }

           
        
        }

        #endregion "UpdateEFICIENCY()"

        #region "UpdateEficiencyTT"
        private void UpdateEficiencyTT()
        {
            try
            {
                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update TOTALBOM  SET EFICIENCY ='" + EFICIENCY_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Connection = OCon;
                cmdUpdate.ExecuteNonQuery();
                OCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error EFICIENCY" + ex);
             //   return;
            }
        
        }
        #endregion

        #region "UpdateALLOWANCE()"
        private void UpdateALLOWANCE()
        { 
        try
              {

                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update ALLOWANCE  SET AL_RATE='" + AL_RATE.Text.Trim() + "',DL_RATE='" + DL_RATE.Text.Trim() + "',OH_RATE='" + OH_RATE.Text.Trim() + "',CH_RATE='" + CH_RATE.Text.Trim() + "',EXCHANGE_RATE='" + CH_RATE.Text.Trim() + "',EFICIENCY_RATE='" + EFICIENCY_RATE.Text.Trim() + "',SALE_RATE='" + SALE_RATE.Text.Trim() + "',EXPFG_RATE='" + EXPFG_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
              //  cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
              //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                cmdUpdate.Connection = OCon;

                cmdUpdate.ExecuteNonQuery();
                OCon.Close();

          
              }
                 catch (Exception ex)
              {
                 MessageBox.Show("Error ALLOWANCE" + ex);
                  return;
               }

                //}
            }
       
        #endregion 

        #region "UpdateEficiencyBOM"
        private void UpdateEficiencyBOM()
        {

            try
            {
                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update MBOM SET EFICIENCY_RATE='" + EFICIENCY_RATE.Text.Trim() + "',SALE_RATE='" + SALE_RATE.Text.Trim() + "',EXPFG_RATE='" + EXPFG_RATE.Text.Trim() + "',CH_RATE='" + CH_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                //cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
                //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                cmdUpdate.Connection = OCon;

                cmdUpdate.ExecuteNonQuery();
                OCon.Close();


            }
            catch (Exception ex)
            {
                //   MessageBox.Show("Error" + ex);
                return;
            }
        }
        #endregion

        #region "Upitem"
        private void Upitem(String tempsql)
        {
            try
            {

                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccess());
                conn.Open();


                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT FMTITEMNO,TDLOH_Hour,DLOH_Hour FROM Items  WHERE FMTITEMNO LIKE '" +tempsql +"%' ";

                if (Isfind4 == true)
                {
                    ds.Tables["showItems"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "showItems");
                //*** DropDownList ***// 
                if (ds.Tables["showItems"].Rows.Count != 0)
                {
                    Isfind4 = true;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = ds.Tables["showItems"].Rows.Count-1;

                    for (int i = 0; i < ds.Tables["showItems"].Rows.Count; i++)
                    {//FMTITEMNO
                        // Grs1!TDLOH_Hour = Format((Grs1!DLOH_Hour * (AL_RATE + 100)) / 100, "####0.00")
                        // Grs1!DL = Format((Grs1!TDLOH_Hour / 60) * DL_RATE, "####0.00")
                        // OH Format((Grs1!TDLOH_Hour / 60) * OH_RATE, "####0.00")
                   try
                      {
                        String TDLOH_Hour = Convert.ToDouble(ds.Tables["showItems"].Rows[i]["TDLOH_Hour"]).ToString("#,###.00");
                        String DLOH_Hour = Convert.ToDouble(ds.Tables["showItems"].Rows[i]["DLOH_Hour"]).ToString("#,###.00");
                        String FMTITEMNO = ds.Tables["showItems"].Rows[i]["FMTITEMNO"].ToString();

                        double TDLOH_Hour1 =(Convert.ToDouble(DLOH_Hour)*(Convert.ToDouble(AL_RATE.Text.Trim()) + 100)) / 100;
                        double DL1 =(Convert.ToDouble(TDLOH_Hour)/60)* Convert.ToDouble(DL_RATE.Text.Trim());
                        double OH1 = (Convert.ToDouble(TDLOH_Hour) / 60) * Convert.ToDouble(OH_RATE.Text.Trim());

                        string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                        OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                        OCon.ConnectionString = ConnectAccess;
                        string query;

                        OleDbCommand cmdUpdate = new OleDbCommand();
                        OCon.Open();
                        query = "Update Items  SET TDLOH_Hour='" + TDLOH_Hour1 + "',DLRATE='" + DL_RATE.Text.Trim() + "',OHRATE='" + OH_RATE.Text.Trim() + "',DL='" + DL1 + "',OH='" + OH1 + "'  WHERE FMTITEMNO=@FMTITEMNO";
                        cmdUpdate.Parameters.Clear();
                        cmdUpdate.CommandText = query;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.Parameters.Add("@FMTITEMNO", FMTITEMNO);
                        //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                        cmdUpdate.Connection = OCon;

                        cmdUpdate.ExecuteNonQuery();
                        OCon.Close();


                       ///status
                        progressBar1.Value = i;


                      }
                       catch (Exception ex)
                      {

                          MessageBox.Show("Error Item" + ex);
                       }
                    
                    }

                }
                else
                {
                    Isfind4 = false;
                }

                da = null;
                //conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
        }
        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการบันทึกรายการ Local นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                UpdateGrouplocal();//ยังไม่มี Update Table GROUPUSE 
               UpdateEficiencyTTlocal();//Update Table  TOTALBOM
               UpdateALLOWANCElocal(); //Update Table ALLOWANCE
                UpdateEficiencyBOMlocal(); //Update table MBOM
                if (lo_cbowip.Text == "")
                {
                    MessageBox.Show("กรุณาเลือก Wip ที่จะคำนวณด้วย");
                    return;
                }
              Upitemlocal(this.lo_cbowip.Text); //update table items
                MessageBox.Show("Save Complete");
            }
        }

        #region "UpdateGrouplocal"
        private void UpdateGrouplocal()
        {
            //for update
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                try
                {

                    string GROUPTYPE = dr.Cells["GROUPTYPE"].Value.ToString();

                    string GROUPNAME = dr.Cells["GROUPNAME"].Value.ToString();
                    string GPERCENT = dr.Cells["GPERCENT"].Value.ToString();

                    string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccesslocal"];
                    OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                    OCon.ConnectionString = ConnectAccess;
                    string query;

                    OleDbCommand cmdUpdate = new OleDbCommand();
                    OCon.Open();
                    query = "Update GROUPUSE SET GROUPTYPE='" + GROUPTYPE + "',GROUPNAME='" + GROUPNAME + "',GPERCENT='" + GPERCENT + "',TimeRate='" + lo_AL_RATE.Text.Trim() + "' WHERE GROUPTYPE=@GROUPTYPE";
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.CommandText = query;
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
                    //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                    cmdUpdate.Connection = OCon;

                    cmdUpdate.ExecuteNonQuery();
                    OCon.Close();


                }
                catch (Exception ex)
                {
                    //   MessageBox.Show("Error" + ex);
                    return;
                }

                //}
            }
        
        
        }

        #endregion

        #region "UpdateEficiencyTTlocal"
        private void UpdateEficiencyTTlocal()
        {
            try
            {
                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccesslocal"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update TOTALBOM  SET EFICIENCY ='" + lo_EFICIENCY_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Connection = OCon;
                cmdUpdate.ExecuteNonQuery();
                OCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error EFICIENCY" + ex);
                //   return;
            }
        }
        #endregion 

        #region "UpdateALLOWANCElocal"
        private void UpdateALLOWANCElocal()
        {
            try
            {

                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccesslocal"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update ALLOWANCE  SET AL_RATE='" + lo_AL_RATE.Text.Trim() + "',DL_RATE='" + lo_DL_RATE.Text.Trim() + "',OH_RATE='" + lo_OH_RATE.Text.Trim() + "',CH_RATE='" + lo_CH_RATE.Text.Trim() + "',EXCHANGE_RATE='" + lo_CH_RATE.Text.Trim() + "',EFICIENCY_RATE='" + lo_EFICIENCY_RATE.Text.Trim() + "',SALE_RATE='" + lo_SALE_RATE.Text.Trim() + "',EXPFG_RATE='" + lo_EXPFG_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                //  cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
                //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                cmdUpdate.Connection = OCon;

                cmdUpdate.ExecuteNonQuery();
                OCon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ALLOWANCE" + ex);
                return;
            }

            //}
        
        }
        #endregion

        #region "UpdateEficiencyBOMlocal()"
        private void UpdateEficiencyBOMlocal()
        {
            try
            {
                string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccesslocal"];
                OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                OCon.ConnectionString = ConnectAccess;
                string query;

                OleDbCommand cmdUpdate = new OleDbCommand();
                OCon.Open();
                query = "Update MBOM SET EFICIENCY_RATE='" + lo_EFICIENCY_RATE.Text.Trim() + "',SALE_RATE='" + lo_SALE_RATE.Text.Trim() + "',EXPFG_RATE='" + lo_EXPFG_RATE.Text.Trim() + "',CH_RATE='" + lo_CH_RATE.Text.Trim() + "'";
                cmdUpdate.Parameters.Clear();
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;
                //cmdUpdate.Parameters.Add("@GROUPTYPE", GROUPTYPE);
                //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                cmdUpdate.Connection = OCon;

                cmdUpdate.ExecuteNonQuery();
                OCon.Close();


            }
            catch (Exception ex)
            {
                //   MessageBox.Show("Error" + ex);
                return;
            }
        }

        #endregion

        #region "Upitemlocal(this.cbowip.Text)"
        private void Upitemlocal(String tempsql)
      {
          try
          {

              OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccesslocal());
              conn.Open();


              OdbcDataAdapter dtAdapter;
              DataTable dt = new DataTable();

              string strSQL1 = "";
              strSQL1 = " SELECT FMTITEMNO,TDLOH_Hour,DLOH_Hour FROM Items  WHERE FMTITEMNO LIKE '" + tempsql + "%' ";

              if (Isfind7 == true)
              {
                  ds.Tables["showItems2"].Clear();
              }

              da = new OdbcDataAdapter(strSQL1, conn);
              da.Fill(ds, "showItems2");
              //*** DropDownList ***// 
              if (ds.Tables["showItems2"].Rows.Count != 0)
              {
                  Isfind7 = true;

                  progressBar2.Minimum = 0;
                  progressBar2.Maximum = ds.Tables["showItems2"].Rows.Count - 1;

                  for (int i = 0; i < ds.Tables["showItems2"].Rows.Count; i++)
                  {//FMTITEMNO
                      // Grs1!TDLOH_Hour = Format((Grs1!DLOH_Hour * (AL_RATE + 100)) / 100, "####0.00")
                      // Grs1!DL = Format((Grs1!TDLOH_Hour / 60) * DL_RATE, "####0.00")
                      // OH Format((Grs1!TDLOH_Hour / 60) * OH_RATE, "####0.00")
                      try
                      {
                          String TDLOH_Hour = Convert.ToDouble(ds.Tables["showItems2"].Rows[i]["TDLOH_Hour"]).ToString("#,###.00");
                          String DLOH_Hour = Convert.ToDouble(ds.Tables["showItems2"].Rows[i]["DLOH_Hour"]).ToString("#,###.00");
                          String FMTITEMNO = ds.Tables["showItems2"].Rows[i]["FMTITEMNO"].ToString();

                          double TDLOH_Hour1 = (Convert.ToDouble(DLOH_Hour) * (Convert.ToDouble(lo_AL_RATE.Text.Trim()) + 100)) / 100;
                          double DL1 = (Convert.ToDouble(TDLOH_Hour) / 60) * Convert.ToDouble(lo_DL_RATE.Text.Trim());
                          double OH1 = (Convert.ToDouble(TDLOH_Hour) / 60) * Convert.ToDouble(lo_OH_RATE.Text.Trim());

                          string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                          OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                          OCon.ConnectionString = ConnectAccess;
                          string query;

                          OleDbCommand cmdUpdate = new OleDbCommand();
                          OCon.Open();
                          query = "Update Items  SET TDLOH_Hour='" + TDLOH_Hour1 + "',DLRATE='" + lo_DL_RATE.Text.Trim() + "',OHRATE='" + lo_OH_RATE.Text.Trim() + "',DL='" + DL1 + "',OH='" + OH1 + "'  WHERE FMTITEMNO=@FMTITEMNO";
                          cmdUpdate.Parameters.Clear();
                          cmdUpdate.CommandText = query;
                          cmdUpdate.CommandType = CommandType.Text;
                          cmdUpdate.Parameters.Add("@FMTITEMNO", FMTITEMNO);
                          //  cmdUpdate.Parameters["@LIKeys"].Value = txtLIKey.Text;

                          cmdUpdate.Connection = OCon;

                          cmdUpdate.ExecuteNonQuery();
                          OCon.Close();


                          ///status
                          progressBar2.Value = i;


                      }
                      catch (Exception ex)
                      {

                          MessageBox.Show("Error Item" + ex);
                      }

                  }

              }
              else
              {
                  Isfind7 = false;
              }

              da = null;
              //conn.Close();
              //conn = null;
          }
          catch (Exception ex)
          {


          }
    
      }
        #endregion

        //private void bntexport_Click(object sender, EventArgs e)
        //{
        //  //  string tempsta= ConfigurationManager.AppSettings["ConnectAccess"];
        //    string str = @"" + ConfigurationManager.AppSettings["ConnectAccessFile"];
        //    Process process = new Process();
        //    process.StartInfo.FileName = str;
        //    process.Start();

        //}


    }
}
