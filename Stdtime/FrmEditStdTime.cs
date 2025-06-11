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


namespace PicklistBOM.Stdtime
{
    public partial class FrmEditStdTime : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmEditStdTime()
        {
            InitializeComponent();
        }

        private void FrmEditStdTime_Load(object sender, EventArgs e)
        {
            CallSearch();
        }

        #region "CallSearch"
        private void CallSearch()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            //conn.Open();
            try
            {
                Cmd = new System.Data.SqlClient.SqlCommand(" select *  from dbo.Stdtime "
              + " Where StdID='" + CGlobal.IssueNo2 + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();

                while (rs.Read())
                {
                    txtstyle.Text = rs["Style"].ToString();
                    txtcover.Text = rs["Cover"].ToString();
                    txtme.Text = rs["Mechanism"].ToString();
                    txtwood.Text = rs["Wood"].ToString();
                    txtstuffing.Text = rs["Stuffing"].ToString();
                    txtpressing.Text = rs["Pressing"].ToString();
                    txtfront.Text = rs["FrontRail"].ToString();
                    txtlegrest.Text = rs["Legrest"].ToString();
                    txtuphbody.Text = rs["UPHBody"].ToString();
                    txtuphback.Text = rs["UPHBack"].ToString();
                    txtuphseat.Text = rs["UPHSEAT"].ToString();
                    txtpack.Text = rs["FINAL"].ToString();
                    txtfinal.Text = rs["PACK"].ToString();
                    this.lblREPAIR.Text = rs["REPAIR"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
        
        
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการลบข้อมูล นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn.Open();
                try
                {
                    string cmdQuery1 = " Delete  from dbo.Stdtime  where StdID='" + CGlobal.IssueNo2 + "'";
                    SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                MessageBox.Show("Complete..");
                this.Close();
            }
        }

        private void bntsave_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องแก้ไขข้อมูลนี้ หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("UPDATE dbo.Stdtime  SET");
                query.Append(" Mechanism  = @Mechanism");
                query.Append(", Wood  = @Wood");
                query.Append(", Stuffing  = @Stuffing");
                query.Append(", Pressing  = @Pressing");
                query.Append(", FrontRail  = @FrontRail");
                query.Append(", Legrest  = @Legrest");
                query.Append(", UPHBody  = @UPHBody");
                query.Append(", UPHBack  = @UPHBack");
                query.Append(", UPHSEAT  = @UPHSEAT");
                query.Append(", FINAL  = @FINAL");
                query.Append(", PACK  = @PACK");
                query.Append(", TotalTime  = @TotalTime");
                query.Append(", REPAIR  = @REPAIR");
                query.Append(" WHERE StdID =  @StdID");


                using (var db = new DbHelper1())
                {
                    try
                    {
                        double sum = Convert.ToDouble(txtme.Text) + Convert.ToDouble(txtwood.Text) + Convert.ToDouble(txtstuffing.Text) + Convert.ToDouble(txtpressing.Text) + Convert.ToDouble(txtfront.Text) + Convert.ToDouble(txtlegrest.Text) + Convert.ToDouble(txtuphbody.Text) + Convert.ToDouble(txtuphback.Text) + Convert.ToDouble(txtuphseat.Text) + Convert.ToDouble(txtpack.Text) + Convert.ToDouble(txtfinal.Text) + Convert.ToDouble(this.lblREPAIR.Text);
                        db.AddParameter("@Mechanism", txtme.Text);
                        db.AddParameter("@Wood", txtwood.Text);
                        db.AddParameter("@Stuffing", txtstuffing.Text);
                        db.AddParameter("@Pressing", txtpressing.Text);
                        db.AddParameter("@FrontRail", txtfront.Text);
                        db.AddParameter("@Legrest", txtlegrest.Text);
                        db.AddParameter("@UPHBody", txtuphbody.Text);
                        db.AddParameter("@UPHBack", txtuphback.Text);
                        db.AddParameter("@UPHSEAT", txtuphseat.Text);
                        db.AddParameter("@FINAL", txtfinal.Text);
                        db.AddParameter("@PACK", txtpack.Text);
                        db.AddParameter("@TotalTime", sum);
                        db.AddParameter("@StdID", CGlobal.IssueNo2);
                        db.AddParameter("@REPAIR", this.lblREPAIR.Text.Trim());
                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                        MessageBox.Show("Complete..");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("กรุณาป้อนข้อมูลเป็นตัวเลขก่อน");
                    }

              
                }
            }
        }


    }
}
