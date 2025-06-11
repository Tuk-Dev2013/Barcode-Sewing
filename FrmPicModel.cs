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


namespace PicklistBOM
{
    public partial class FrmPicModel : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;

        public FrmPicModel()
        {
            InitializeComponent();
        }

        private void FrmPicModel_Load(object sender, EventArgs e)
        {
            //CGlobal.DocNoPic = Convert.ToString(gridView1.GetDataRow(index)["DocNo"]);
          //  CGlobal.BarcodePic = Convert.ToString(gridView1.GetDataRow(index)["Barcode"]);
            this.lblmodel.Text = CGlobal.DocNoPic;
            CallSearchDocMODtl();
            CallModelPicture();
            CallModelColor();
        }

        #region "CallSearchDocMODtl()"
        private void CallSearchDocMODtl()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand("Select SUBSTRING(ItemCode,3,6) As Item,SUBSTRING(ItemCode,9,2) As Code,SUBSTRING(ItemCode,11,14) As Color from dbo.DocMODtl  where  DocNo ='" + CGlobal.DocNoPic + "' and Barcode='" + CGlobal.BarcodePic  + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                   this.lblModel0.Text= rs["Item"].ToString();
                   lblM.Text = rs["Item"].ToString();
                   this.lblcode0.Text= rs["Code"].ToString();
                   this.lblcolor0.Text = rs["Color"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }
        #endregion

        #region " CallPicture"
        private void CallModelPicture()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.A_ModelPic where  model+modelname  ='" + this.lblModel0.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                  //  this.lblcode.Text = rs["COLOR_NAME"].ToString();
                    String pic1 = rs["modelpic"].ToString();
                //   String pic2= rs["IMG_2"].ToString();
                    string filepath ="//192.168.1.4/Modelpicture/" + pic1;
                  //  string filepath2 = "//192.168.1.4/Modelpicture/" + pic2;
                    pictureBox1.ImageLocation = filepath;
                   // pictureBox2.ImageLocation = filepath2;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }
        #endregion

        #region "     CallModelColor();"
        private void CallModelColor()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.A_ModelColor where  CODE  ='" + this.lblcode0.Text.Trim() + "'and COLOR ='" + this.lblcolor0.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblcode.Text = rs["ColorName"].ToString();
                    String pic1 = rs["ColorPic"].ToString();
                    //   String pic2= rs["IMG_2"].ToString();
                    string filepath = "//192.168.1.4/Modelpicture/" + pic1;
                    //  string filepath2 = "//192.168.1.4/Modelpicture/" + pic2;
                    pictureBox2.ImageLocation = filepath;
                    // pictureBox2.ImageLocation = filepath2;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();


        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}
