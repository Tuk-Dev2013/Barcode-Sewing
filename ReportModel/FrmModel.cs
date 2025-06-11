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
namespace PicklistBOM.ReportModel
{
    public partial class FrmModel : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public FrmModel()
        {
            InitializeComponent();
        }

        private void FrmModel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet3.View_DocOrder' table. You can move, or remove it, as needed.
            this.view_DocOrderTableAdapter.Fill(this.dBBARCODEDataSet3.View_DocOrder);
            Calldelete();
        }

        #region " Calldelete();"
        private void Calldelete()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " delete from A_ReportOne ";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
       
        }

        #endregion


        private void bntsave_Click(object sender, EventArgs e)
        {
            if (cboDocRefNo.Text == "")
            {
                MessageBox.Show("No Data");
                return;
            }

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " select DocNo,substring(ItemCode,2,6) as Model ,sum(QtyBom) As Qty,"
                + " (select DocProj from dbo.DocMO where DocNo = '" + cboDocRefNo.Text + "') as DocProj "
                + " from dbo.DocMODtl where DocNo ='" + cboDocRefNo.Text + "'"
                + " and substring(ItemCode,2,6)=substring(ItemCode,2,6) and DeptCode='F'"
                + " and BomNo<>'OPT' and  BomNo<>'OPT-GB'  group by DocNo,substring(ItemCode,2,6)";

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
                    //gridshow.DataSource = dt;

                    for (int i = 0; i < ds.Tables["Showdata"].Rows.Count; i++)
                    {
                        string DocNo = ds.Tables["Showdata"].Rows[i]["DocNo"].ToString();
                        string Model = ds.Tables["Showdata"].Rows[i]["Model"].ToString();
                        string Qty = ds.Tables["Showdata"].Rows[i]["Qty"].ToString();
                        string DocProj = ds.Tables["Showdata"].Rows[i]["DocProj"].ToString();
                        CallInsert(DocNo, Model, Qty, DocProj);

                    }

                  

                }
                else
                {
                    Isfind = false;
                  //  this.gridshow.DataSource = null;
                    MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
            }
            conn.Close();


            Call2Bin();



        }


        #region "search2bin"
        private void Call2Bin()
        {
            this.Show1.DataSource = null;

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {

                string strSQL1 = "";
                strSQL1 = " SELECT  Distinct(DocNo),Boi FROM  A_ReportOne ";
                if (Isfind1 == true)
                {
                    ds.Tables["Showdata2"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata2");

                if (ds.Tables["Showdata2"].Rows.Count != 0)
                {
                    Isfind1 = true;
                    dt = ds.Tables["Showdata2"];
                    Show1.DataSource = dt;
                }
                else
                {
                    Isfind1 = false;
                    this.Show1.DataSource = null;
                    //  MessageBox.Show("No Data");
                    return;
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data  show");
            }
            conn.Close();
        }
        #endregion


        #region " CallInsert(DocNo, Model, Qty, DocProj);"
        private void CallInsert(String DocNo, String Model, String Qty, String  DocProj)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO A_ReportOne(DocNo, Boi, Model, Qty, ReMark, Status)");
            query.Append(" VALUES (@DocNo, @Boi, @Model, @Qty, @ReMark, @Status)");

            SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn1.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                    // DateTime sdate1 = DateTime.Now;
                    // this.txtdate.Text = sdate1.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
                    db.AddParameter("@DocNo", DocNo);
                    db.AddParameter("@Boi", DocProj);
                    db.AddParameter("@Model", Model);
                    db.AddParameter("@Qty", Qty);
                    db.AddParameter("@ReMark","");
                    db.AddParameter("@Status", "1");  // 0 : ยังไม่รับ 1: รับ
                    db.ExecuteNonQuery(query.ToString());
                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("No Transfer");

                }
            }
            conn1.Close();
        
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Calldelete();
            Call2Bin();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.Show1.DataSource == null)
            {
                MessageBox.Show("No Data PO.");
                return;
            }
            else
            {
                ReportModel.ViewModel page = new ReportModel.ViewModel();  // ยิง barcode จ่าย store
                page.Show();
              //  this.Hide();
            }
        }


    }
}
