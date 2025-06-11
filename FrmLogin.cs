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

namespace PicklistBOM
{

    public partial class FrmLogin : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void bntexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (this.txtusername.Text == "")
            {
                MessageBox.Show("กรุณากรอก Username ด้วย");
                this.txtusername.Text = "";
                this.txtpassword.Text = "";
                this.txtusername.Focus();
                return;
            }
            if (this.txtpassword.Text == "")
            {
                MessageBox.Show("กรุณากรอก Password ด้วย");
               // this.txtusername.Text = "";
                this.txtpassword.Text = "";
                this.txtusername.Focus();
                return;
            }

            //if ((this.txtusername.Text == "admin")||(this.txtusername.Text == "Admin")||(this.txtusername.Text == "ADMIN"))
            //{
            //    MessageBox.Show("กรุณากรอก Username ใหม่ด้วย Admin ไม่สามารถเข้าระบบได้ ");
            //    this.txtusername.Text = "";
            //    this.txtpassword.Text = "";
            //    this.txtusername.Focus();
            //    return;
            //}

            try
            {

                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();

                //string temp = this.txtpassword.Text.Trim();
                //string tpw = Encode(temp);
                string strSQL1 = "";
                strSQL1 = " select EmpCode,EmpName,EmpPost,(select  Postname From DatPost where DatPost.PostIndx =DatEmp.EmpPost)as Positionname  from DatEmp "
                   + " where Username='" + this.txtusername.Text.Trim() + "'"
                   + "  and Password='" + this.txtpassword.Text.Trim() + "'";

                if (Isfind == true)
                {
                    ds.Tables["tab6"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "tab6");

                if (ds.Tables["tab6"].Rows.Count != 0)
                {
                    Isfind = true;
                    CGlobal.UserID = ds.Tables["tab6"].Rows[0]["EmpCode"].ToString();
                    CGlobal.Username = ds.Tables["tab6"].Rows[0]["EmpName"].ToString();
                    CGlobal.EmpPost = ds.Tables["tab6"].Rows[0]["EmpPost"].ToString();
                    CGlobal.Version = "1.0";
                    CGlobal.VersionName = "Line Cell";


                    //15/03/2016 program sewing
                    Sewing.FrmSewingBarcode page = new Sewing.FrmSewingBarcode();  //Sewing
                 
               // txtPOSearch1 page = new txtPOSearch1();  //lot number
              //Receipt2Bin.FrmRecipt2Bin page = new Receipt2Bin.FrmRecipt2Bin();  //รับ 2bin line cell
              //StoreOut.FrmStoreOut page = new StoreOut.FrmStoreOut();  // ยิง barcode จ่าย store

            //  _2Bin.Frm2BinDefault page = new _2Bin.Frm2BinDefault();  // Admin Center Store
            // _2Bin.FrmReceive2Bin page = new _2Bin.FrmReceive2Bin();  //รับ 2bin Production 03/06/2015

                // Barcode page = new Barcode();  // barcode line cell all and User all cell
  
                // StorePowerWip.FrmMainPowerwip page = new StorePowerWip.FrmMainPowerwip(); // Power-wip Store

            //  Poly.FrmPoly page = new Poly.FrmPoly();  // ยิง barcode จ่าย Poly Batch
               // Poly.FrmPolyCell page = new Poly.FrmPolyCell();  // ยิงรับ barcode จ่าย Poly Batch
                   page.Show();
                  this.Hide();
                   
                 
                    conn.Close();//
                }
                else
                {
                    MessageBox.Show("Username และ Password ของคุณไม่ถูกต้อง กรุณาป้อนใหม่.");
                    //this.txtusername.Text = "";
                    this.txtpassword.Text = "";
                    txtusername.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถ ติดต่ฐานข้อมูลได้ กรุณาติดต่อเจ้าหน้าที");
                return;
            }

        }

        private void bntLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.bntLogin_Click(sender, e);
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.bntLogin_Click(sender, e);
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.bntLogin_Click(sender, e);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

   
    }
}
