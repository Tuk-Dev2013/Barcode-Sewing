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
    public partial class FrmMeessage : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmMeessage()
        {
            InitializeComponent();
        }

        private void FrmMeessage_Load(object sender, EventArgs e)
        {
            Callsearch();
        }

        #region " Callsearch();"
        private void Callsearch()
        {

            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
               Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.DocMODtlMessage  Where IDMe ='" + ConfigurationManager.AppSettings["MessageCell"] +"'", conn);
             //   Cmd = new System.Data.SqlClient.SqlCommand(" select * from dbo.DocMODtlMessage  Where IDMe ='" + CGlobal.cellStatus + "'", conn); //พี่บูล
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.txtsearch.Text = rs["Message"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }

        #endregion

        private void bntupdate_Click(object sender, EventArgs e)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtlMessage SET");
            query.Append(" Message  = @Message");
            query.Append(" WHERE IDMe =  @IDMe");
   


            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@Message", this.txtsearch.Text.Trim());
                  db.AddParameter("@IDMe", ConfigurationManager.AppSettings["MessageCell"]);
                  //  db.AddParameter("@IDMe", CGlobal.cellStatus);  //พี่บูล
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
            CallInsertLog();
            MessageBox.Show("Complete");
        }

        #region " CallInsertLog();"
        private void CallInsertLog()
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocMODtlMessageLog(Message, DocNo, Sdate, Status)");
            query.Append(" VALUES (@Message, @DocNo, @Sdate, @Status)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    string date ="'GETDATE()'";
                    string resultdate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt", new System.Globalization.CultureInfo("en-US"));
                    //string d1 = DateTime.Now.ToShortDateString();
                   // string time = DateTime.Now.ToShortTimeString();
                    //string temeone = d1 + "  " + time;

                    string PO;
                    if (CGlobal.CheckBDoc == null)
                    {
                        PO = "NOPO1";
                    }
                    else
                    {
                        PO = CGlobal.CheckBDoc;
                    
                    }
                    db.AddParameter("@Message", txtsearch.Text.Trim());
                    db.AddParameter("@DocNo", PO);
                    db.AddParameter("@Sdate", resultdate);
                    db.AddParameter("@Status", ConfigurationManager.AppSettings["SHOW_CELL"]);
                    //db.AddParameter("@Status", CGlobal.cellStatus); //พี่บูล
                    db.ExecuteNonQuery(query.ToString());
                    //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                   // MessageBox.Show("No");

                }
            }
            conn.Close();
        
        
        }

        #endregion

    }
}
