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

namespace PicklistBOM.RateAccount
{
    public partial class FrmRate : Form
    {

        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmRate()
        {
            InitializeComponent();
        }

        private void bntsearch_Click(object sender, EventArgs e)
        {
            this.gridshow.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string Stem2 = startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US")) +" 07:00:38.733";
                String Etem2 = Enddate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US")) + " 23:00:38.733";
                string strSQL1 = "";
                strSQL1 = " select DocNo,DocNote from dbo.DocReceipt  where PostDate between '" + Stem2 + "' and '" + Etem2 + "' and DocNo like 'IM%' and DocStatus='5' order by DocNote";

                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables["Showdata"].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;

                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการ Update Rate  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {


                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string DocNo = Convert.ToString(gridView1.GetDataRow(i)["DocNo"]);
                    string DocNote = Convert.ToString(gridView1.GetDataRow(i)["DocNote"]);
                    CallUpdate(DocNo, DocNote);
                }
                MessageBox.Show("เรียบร้อยค่ะ");
            }

        }

        #region "CallUpdate"
        private void CallUpdate(string DocNo, String DocNote)
       {
        var query = new StringBuilder();
        query.Append("UPDATE dbo.DocReceipt  SET");
        query.Append(" DocNote  = @DocNote");
        query.Append(" WHERE DocNo =  @DocNo");


        using (var db = new DbHelper1())
        {
            try
            {

                db.AddParameter("@DocNote", DocNote);
                db.AddParameter("@DocNo", DocNo);
                db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
         
        }
    
    }




        #endregion

    }
}
