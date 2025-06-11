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
using System.Timers;
using System.Configuration;

namespace PicklistBOM
{
    public partial class FrmTeam : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmTeam()
        {
            InitializeComponent();
        }

        private void FrmTeam_Load(object sender, EventArgs e)
        {
            CallCalulateSumTotal();
        }


        #region "CallCalulateSumTotal()"
        private void CallCalulateSumTotal()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select TotalOutput,TotalTarget  from dbo.Line_MonitorWeek where TagetDate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                 
                    String num1 = Convert.ToDouble(rs["TotalTarget"]).ToString("#,###0");
                    lbltotaltarget.Text = num1;

                    String num = Convert.ToDouble(rs["TotalOutput"]).ToString("#,###0");
                    this.lbltotal.Text = num;

                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }

        #endregion 


    }
}
