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
    public partial class FrmBarcodeLFS : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmBarcodeLFS()
        {
            InitializeComponent();
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtbarcode.Text == "")
                {
                    return;
                }
                try
                {

                    SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                    conn.Open();

                    //string temp = this.txtpassword.Text.Trim();
                    //string tpw = Encode(temp);
                    string strSQL1 = "";
                    strSQL1 = " SELECT  UserName, Barcode, BarcodeType, Status FROM   Sewing_ScheduleUser "
                       + " where Barcode='" + this.txtbarcode.Text.Trim() + "'";
           
                    if (Isfind == true)
                    {
                        ds.Tables["Barcodetab6"].Clear();
                    }

                    da = new SqlDataAdapter(strSQL1, conn);
                    da.Fill(ds, "Barcodetab6");

                    if (ds.Tables["Barcodetab6"].Rows.Count != 0)
                    {
                        Isfind = true;
                        CGlobal.UserID = ds.Tables["Barcodetab6"].Rows[0]["Barcode"].ToString();
                        CGlobal.Username = ds.Tables["Barcodetab6"].Rows[0]["UserName"].ToString();
                        CGlobal.EmpPost = ds.Tables["Barcodetab6"].Rows[0]["BarcodeType"].ToString();
                        CGlobal.Version = "1.0";
                        CGlobal.VersionName = "Barcode Cell";



                        Sewing.FrmBarcodeLFS1 page = new Sewing.FrmBarcodeLFS1();  //Sewing                  
                        page.Show();
                        this.Hide();


                        conn.Close();//
                    }
                    else
                    {
                        MessageBox.Show("คุณยิง Barcode ไม่ถูกต้อง กรุณายิงใหม่.");
                        this.txtbarcode.Text = "";
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถ ติดต่ฐานข้อมูลได้ กรุณาติดต่อเจ้าหน้าที");
                    return;
                }



            }
        }

        private void FrmBarcodeLFS_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowCutSewing page = new FrmShowCutSewing();  
            page.Show();
        }
    }
}
