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
    public partial class frmoperator : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public frmoperator()
        {
            InitializeComponent();
        }

        private void frmoperator_Load(object sender, EventArgs e)
        {
            string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            CallSearch(tmpdate);
        }

        #region "CallSearch()"
        private void CallSearch(string tmpdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            //conn.Open();
            try
            {
                string tmpname = ConfigurationManager.AppSettings["SHOW_CELL1"];
                CGlobal.IssueNumber2 = "1";
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT SewID,Sdate, Mantotal, Unitperhead, target, Issuedate, UserID, Target8hr, Target3hr, Total11hr FROM  Sewing_TargetDay Where Sdate='" + tmpdate + "' and Cellname='" + tmpname + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    txtperson.Text = rs["Mantotal"].ToString();
                }

            }
            catch (Exception ex)
            {
                CGlobal.IssueNumber2 = "1";
            }
            conn.Close();

        }
        #endregion

        private void bntadd_Click(object sender, EventArgs e)
        {
                   
                        var query = new StringBuilder();
                        query.Append("UPDATE dbo.Sewing_TargetDay  SET");
                        query.Append(" Mantotal  = @Mantotal");
                        query.Append(" WHERE Sdate =  @Sdate");
                        query.Append(" and Cellname =  @Cellname");
                        using (var db = new DbHelper1())
                        {
                            try
                            {
                                string tmpdate1 = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                                string tmpname = ConfigurationManager.AppSettings["SHOW_CELL1"];
                                db.AddParameter("@Mantotal", this.txtperson.Text);
                                db.AddParameter("@Sdate", tmpdate1);
                                db.AddParameter("@Cellname", tmpname);

                                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                                MessageBox.Show("Complete");
                                this.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error" + ex);
                                return;
                            }

                        }
                     
                    
        }
    }
}
