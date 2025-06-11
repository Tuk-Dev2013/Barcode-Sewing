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

namespace PicklistBOM.Production
{
    public partial class FrmTotalT : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmTotalT()
        {
            InitializeComponent();
        }

        private void FrmTotalT_Load(object sender, EventArgs e)
        {
      
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.txtdate.Text = resultdate;
            this.txttarget.Text = "0";
            CallSearch(resultdate);
        }
    

        private void bntupdate_Click(object sender, EventArgs e)
        {
               if (this.txttarget.Text == "")
            {
                MessageBox.Show("กรุณาป้อนข้อมูล Target ด้วย.");
                return;
            }
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
          //  CallSearch(resultdate);
            if (CGlobal.targetsumtotay == null)
            {
                CallSave(resultdate, this.txttarget.Text.Trim());

            }
            else
            {
                CallUpdate(resultdate, this.txttarget.Text.Trim());
            }

            CallSearch(resultdate);
        }

        #region CallSave"
        private void CallSave(string sdate, string num)
        {

            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocMODtlTarget (TargetOutput, Sdate, Status)");
            query.Append(" VALUES (@TargetOutput, @Sdate, @Status)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    Double numtoal = Convert.ToDouble(num);
                    db.AddParameter("@TargetOutput", numtoal);
                    db.AddParameter("@Sdate", sdate);
                    db.AddParameter("@Status", ConfigurationManager.AppSettings["SHOW_CELL"]); //line cell
                  //  db.AddParameter("@Status",  CGlobal.cellStatus) ;  //พี่บูล
                    db.ExecuteNonQuery(query.ToString());
                    MessageBox.Show("Complete.");
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("ต้องป้อนเป็นต้วเลขเท่านั้นครับ");
                    this.txttarget.Text = "0";
                    this.txttarget.Focus();

                }
            }
            conn.Close();
        
        
        }

        #endregion

        #region "CallUpdate"
        private void CallUpdate(string sdate, string num)
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtlTarget SET");
            query.Append(" TargetOutput  = @TargetOutput");
            query.Append(" WHERE Sdate =  @Sdate");
            query.Append(" and Status =  @Status");



            using (var db = new DbHelper1())
            {
                try
                {
                    Double numtoal = Convert.ToDouble(num);
                    db.AddParameter("@TargetOutput", numtoal);
                    db.AddParameter("@Sdate", sdate);
                    db.AddParameter("@Status", ConfigurationManager.AppSettings["SHOW_CELL"]);
                   // db.AddParameter("@Status", CGlobal.cellStatus); //พี่บูล
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
     
            MessageBox.Show("Complete");
        
        
        }
        #endregion

        #region "CallSearch()"
        private void CallSearch(string sdate)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {


             Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + sdate + "' and Status ='" + ConfigurationManager.AppSettings["SHOW_CELL"] +"'", conn);

              //  Cmd = new System.Data.SqlClient.SqlCommand(" SELECT  TargetID, TargetOutput, Sdate  from dbo.DocMODtlTarget  where  Sdate ='" + sdate + "' and Status ='" + CGlobal.cellStatus + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    CGlobal.targetsumtotay = rs["TargetOutput"].ToString();
                    CGlobal.targetdate = rs["Sdate"].ToString();

                   this.txttarget.Text = rs["TargetOutput"].ToString();
                   this.txtdate.Text= rs["Sdate"].ToString();

                }
       
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        
        }

        #endregion




    }
}
