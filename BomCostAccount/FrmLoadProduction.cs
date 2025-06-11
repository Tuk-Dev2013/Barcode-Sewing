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
using System.Configuration;

namespace PicklistBOM.BomCostAccount
{
    public partial class FrmLoadProduction : Form
    {
        OdbcCommand comm = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmLoadProduction()
        {
            InitializeComponent();
        }

        private void FrmLoadProduction_Load(object sender, EventArgs e)
        {
            CallShowGrouplocal();
        }

        #region "      CallShowGrouplocal();"
        private void CallShowGrouplocal()
        {
            try
            {
                OdbcConnection conn = new OdbcConnection(WebConfig.GetconnectionAccess());
                conn.Open();
           

                OdbcDataAdapter dtAdapter;
                DataTable dt = new DataTable();

                string strSQL1 = "";
                strSQL1 = " SELECT *  FROM T_ShipingLabel order by this_id";

                if (Isfind == true)
                {
                    ds.Tables["style2"].Clear();
                }

                da = new OdbcDataAdapter(strSQL1, conn);
                da.Fill(ds, "style2");
                //*** DropDownList ***// 
                if (ds.Tables["style2"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["style2"];
                    gridshow.DataSource = dt;
              
                }
                else
                {
                    Isfind = false;

                    gridshow.DataSource = null;
                }

                da = null;
              conn.Close();
                //conn = null;
            }
            catch (Exception ex)
            {


            }
       


        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการ Update 999--> 502 นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                try
                {
         

                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {

                        string this_id = Convert.ToString(gridView1.GetDataRow(i)["this_id"]);
                        string LabelType = Convert.ToString(gridView1.GetDataRow(i)["LabelType"]);
                        string Country = Convert.ToString(gridView1.GetDataRow(i)["Country"]);
                      //  string STyleDes1 = Convert.ToString(gridView1.GetDataRow(i)["STyleDes1"]);


                        string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                        OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                        OCon.ConnectionString = ConnectAccess;
                        string query;
                        OleDbCommand cmdUpdate = new OleDbCommand(); // where LabelType ='999' or LabelType Is Null ";
                        OCon.Open();
                        query = "Update T_ShipingLabel  SET LabelType='" + LabelType.Trim() + "', FabricCareLabelNo='" + LabelType.Trim() + "', Country='" + Country.Trim() + "'  where  this_id =" + this_id + "";
                        cmdUpdate.Parameters.Clear();
                        cmdUpdate.CommandText = query;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.Connection = OCon;
                        cmdUpdate.ExecuteNonQuery();
                        OCon.Close();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error EFICIENCY" + ex);
                    //   return;
                }

            }
            MessageBox.Show("Complete");
            CallShowGrouplocal();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการ Update ARWICK --> FB 990508 นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                try
                {
                    string ConnectAccess = ConfigurationManager.AppSettings["ConnectAccess"];
                    OleDbConnection OCon = new OleDbConnection();  //D:\AccBomCost
                    OCon.ConnectionString = ConnectAccess;
                    string query;

                    OleDbCommand cmdUpdate = new OleDbCommand();
                    OCon.Open();
                    query = "Update T_ShipingLabel  SET SuppCover1 ='FB  990508' where SuppCover1 like '%ARWICK' ";
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
                CallShowGrouplocal();
            }
        }


    }
}
