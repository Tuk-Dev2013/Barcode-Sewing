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
    public partial class FrmOT : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        public FrmOT()
        {
            InitializeComponent();
        }

        private void FrmOT_Load(object sender, EventArgs e)
        {
            Callstdtime();
        }

        #region " Callstdtime()"
        private void Callstdtime()
        {
            string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string strSQL1 = "";
                strSQL1 = " select * from dbo.StdtimeTimeCell  order by stdcode  ";

                if (Isfind == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata2"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data1");
            }
            conn.Close();

        }
        #endregion

        private void bntsave_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องแก้ไขข้อมูลนี้ ใช่หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {     
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                string stdcode = Convert.ToString(gridView1.GetDataRow(i)["stdcode"]);
                string TmpHour = Convert.ToString(gridView1.GetDataRow(i)["TmpHour"]);
                string TmpMin = Convert.ToString(gridView1.GetDataRow(i)["TmpMin"]);
                string TmpWorker = Convert.ToString(gridView1.GetDataRow(i)["TmpWorker"]);
                string Typecell = Convert.ToString(gridView1.GetDataRow(i)["Typecell"]);

               var query = new StringBuilder();
               query.Append("UPDATE dbo.StdtimeTimeCell  SET");
               query.Append(" TmpHour  = @TmpHour");
               query.Append(", TmpMin  = @TmpMin");
               query.Append(", TmpWorker  = @TmpWorker");
                query.Append(" WHERE stdcode =  @stdcode");


                  using (var db = new DbHelper1())
                   {
                    try
                    {

                        db.AddParameter("@stdcode", stdcode);
                        db.AddParameter("@TmpHour", TmpHour);
                        db.AddParameter("@TmpMin", TmpMin);
                        db.AddParameter("@TmpWorker", TmpWorker);

                        db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                    }
                     catch (Exception ex)
                    {
                        MessageBox.Show("กรุณาป้อนข้อมูลเป็นตัวเลขก่อน");
                    }

                   }
                    
                 
               }
                MessageBox.Show("Complete...");
                Callstdtime();
            }
        }
    }
}
