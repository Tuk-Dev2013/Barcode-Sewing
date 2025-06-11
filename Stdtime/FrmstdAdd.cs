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
    public partial class FrmstdAdd : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmstdAdd()
        {
            InitializeComponent();
        }

        private void bntsave_Click(object sender, EventArgs e)
        {
            if (txtstyle.Text == "")
            {
                MessageBox.Show("กรุณาป้อน Model ก่อน");
                return;
            }
            if (txtcover.Text == "")
            { 
                MessageBox.Show("กรุณาป้อน Cover ก่อน");
                return;
            }
            if ((MessageBox.Show(" คุณต้องการบันทึกข้อมูล นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                var query = new StringBuilder();
                query.Append("INSERT INTO Stdtime(Style, Cover, Mechanism, Wood, Stuffing, Pressing, FrontRail, Legrest, UPHBody, UPHBack, UPHSEAT, FINAL, PACK, Remark, Status, TotalTime,REPAIR)");
                query.Append(" VALUES (@Style, @Cover, @Mechanism, @Wood, @Stuffing, @Pressing, @FrontRail, @Legrest, @UPHBody, @UPHBack, @UPHSEAT, @FINAL, @PACK, @Remark, @Status, @TotalTime,@REPAIR)");

                SqlConnection conn1 = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
                conn1.Open();
                using (var db = new DbHelper1())
                {
                    try
                    {
                        double sum = Convert.ToDouble(txtme.Text) + Convert.ToDouble(txtwood.Text) + Convert.ToDouble(txtstuffing.Text) + Convert.ToDouble(txtpressing.Text) + Convert.ToDouble(txtfront.Text) + Convert.ToDouble(txtlegrest.Text) + Convert.ToDouble(txtuphbody.Text) + Convert.ToDouble(txtuphback.Text) + Convert.ToDouble(txtuphseat.Text) + Convert.ToDouble(txtpack.Text) + Convert.ToDouble(txtfinal.Text) + Convert.ToDouble(this.lblREPAIR.Text);

                        db.AddParameter("@Style", this.txtstyle.Text.Trim());
                        db.AddParameter("@Cover", this.txtcover.Text.Trim());
                        db.AddParameter("@Mechanism", this.txtme.Text.Trim());
                        db.AddParameter("@Wood", this.txtwood.Text.Trim());
                        db.AddParameter("@Stuffing", this.txtstuffing.Text.Trim());
                        db.AddParameter("@Pressing", this.txtpressing.Text.Trim());
                        db.AddParameter("@FrontRail", txtfront.Text.Trim());
                        db.AddParameter("@Legrest", txtlegrest.Text.Trim());
                        db.AddParameter("@UPHBody", txtuphbody.Text.Trim());
                        db.AddParameter("@UPHBack", txtuphback.Text.Trim());
                        db.AddParameter("@UPHSEAT", this.txtuphseat.Text.Trim());
                        db.AddParameter("@FINAL", txtfinal.Text.Trim());
                        db.AddParameter("@PACK", this.txtpack.Text.Trim());
                        db.AddParameter("@Remark", "");
                        db.AddParameter("@Status", "1");
                        db.AddParameter("@TotalTime", sum);
                        db.AddParameter("@REPAIR", this.lblREPAIR.Text.Trim());
                        db.ExecuteNonQuery(query.ToString());


                        conn1.Close();
                        MessageBox.Show("Complete...");
                        CGlobal.Issuemodel = this.txtstyle.Text.Trim();
                        this.Close();
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("กรุณาป้อนข้อมูลจำนวน Std Time เป็นตัวเลขก่อน");
                    }
                }
        

            }
        }

        private void lineShape10_Click(object sender, EventArgs e)
        {

        }

        private void FrmstdAdd_Load(object sender, EventArgs e)
        {

        }


    }
}
