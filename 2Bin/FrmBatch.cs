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
using DevExpress.XtraGrid.Columns;

namespace PicklistBOM._2Bin
{
    public partial class FrmBatch : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmBatch()
        {
            InitializeComponent();
        }

        private void splitLotPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPOSearch1 page = new txtPOSearch1();
            page.Show();
            this.Hide();
        }

        private void reportPicklistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            page.Show();
            this.Hide();
        }

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void bacthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmBatch page = new PicklistBOM._2Bin.FrmBatch();
            page.Show();
            this.Hide();
        }

        private void FrmBatch_Load(object sender, EventArgs e)
        {
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username; 
            this.ck1.Checked = true;
           // CallWipCode();
            //string tempstation = cbowipcode.Text;
            //CallWipstation();
        }

        private void bntreport_Click(object sender, EventArgs e)
        {
            CallGridViewPO();
        }

        #region "viewPO"
        private void CallGridViewPO()
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select DocNo,convert(datetime, DocDate, 110) as DocDate,DocRefNo,DocDept,"
                + " (select StateName From  DatStation Where StateCode =DocDept)As itemGroup,"
                + " (select StatName From  DatStatus Where StatCode =DocStatus)As status,'View Print'as Print1,DocProj ,'View 2Bin'as Bin"
                + " FROM   dbo.DocIssue  WHERE DocRefNo ='" + this.txtorderNO.Text.Trim() + "'";

                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                    MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();



        }

        #endregion

        #region "printview"
        private void gridshow_DoubleClick(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(index);


            string DocItem = Convert.ToString(gridView1.GetDataRow(index)["Print1"]);
            if (DocItem == "View Print")
            {
                CGlobal.DocNo = Convert.ToString(gridView1.GetDataRow(index)["DocNo"]);
                CGlobal.DocDept = Convert.ToString(gridView1.GetDataRow(index)["itemGroup"]);
                CGlobal.DocProj = Convert.ToString(gridView1.GetDataRow(index)["DocProj"]);

                if (ck1.Checked == true)
                {
                    PicklistBOM._2Bin.ReportBatch page = new PicklistBOM._2Bin.ReportBatch();
                    page.Show();
                }
                else if (ck2.Checked == true)
                {
                    PicklistBOM._2Bin.Report2BIN page = new PicklistBOM._2Bin.Report2BIN();
                    page.Show();
                }
                else
                {
                    MessageBox.Show("No Data Print");
                }
            
            }



                 

        }

        #endregion

        private void ck1_CheckedChanged(object sender, EventArgs e)
        {
           // ck1.Checked=true;
            if (ck1.Checked == true)
            {
                ck2.Checked = false;
            }


        }

        private void ck2_CheckedChanged(object sender, EventArgs e)
        {
            if (ck2.Checked == true)
            {
                ck1.Checked = false;
            }

        }







        //#region "station"
        //private void CallWipstation()
        //{

        //    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
        //    conn.Open();
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da;

        //        string strSQL1 = "";
        //        strSQL1 = "  select StateIndx,StateName from dbo.DatStation where StateFlag =1 and StateCode='" + cbowipcode.Text + "'";

        //        da = new SqlDataAdapter(strSQL1, conn);
        //        da.Fill(ds, "wipstation");

        //        //*** DropDownList ***//    

        //        this.cbostation.DisplayMember = "StateName";
        //        this.cbostation.ValueMember = "StateIndx";
        //        this.cbostation.DataSource = ds.Tables["wipstation"];
        //        //this.CboPer.Text = "Please Select";

        //        da = null;
        //        conn.Close();
        //        conn = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        //alert(ex.ToString);
        //    }
        //}


     //   #endregion

 

    }
}
