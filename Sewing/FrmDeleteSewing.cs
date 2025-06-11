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
    public partial class FrmDeleteSewing : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        public FrmDeleteSewing()
        {
            InitializeComponent();
        }
        #region "Mid, Right,Left'

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }

        #endregion
        private void FrmDeleteSewing_Load(object sender, EventArgs e)
        {
            this.lblpo.Text = CGlobal.CkSPOCell;
            this.lblmodel.Text = Left(CGlobal.CkSItemmodel,16);
            this.lblbarcode.Text = CGlobal.CkSBarcode;
            this.lblqtyseat.Text = CGlobal.CkSQtyseat;

            ///string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            ///15/09/2017 09:21:30       2017-09-15 09:21:22
            string dd = Left(CGlobal.CkSDatetime, 2);
            string MM = Mid(CGlobal.CkSDatetime, 3, 2);
            string yy = Mid(CGlobal.CkSDatetime, 6, 4);
            string hms = Right(CGlobal.CkSDatetime, 8);


            this.lbldatetime.Text = yy + "-" + MM + "-" + dd + " " + hms;
            CallSeartPO();
        }


        #region "CallSeart()"
        private void CallSeartPO()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
                string tmpcell = CGlobal.Sew_deletecell;
                string tmpdate = DateTime.Now.ToString("MM-dd-yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand("  select QtyIn,QtyOut,QtyBack,QtySeat,QtyBody from dbo.Sewing_Schedule where cellname='" + tmpcell + "'and docno='" + this.lblpo.Text.Trim() + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    this.lblQty.Text = rs["QtyIn"].ToString();
                    this.lblbal.Text = rs["QtyOut"].ToString();
                    this.lblback.Text = rs["QtyBack"].ToString();
                    this.lblbody.Text = rs["QtyBody"].ToString();
                    this.lblseat.Text = rs["QtySeat"].ToString();
                }

            }
            catch (Exception ex)
            {

            }
            conn.Close();
        }
        #endregion

        private void lineShape10_Click(object sender, EventArgs e)
        {

        }

        private void lbldelte_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(" คุณต้องการลบ PO#." + this.lblpo.Text.Trim() + ":" + this.lblmodel.Text.Trim() + " Qty. 1 Set นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                CallBarcode();
                UpdateDocMODtl();  //updatemodtl

                DeletebSewing_DtlBarcode();  //Sewing_DtlBarcode

                UpdateSewingSchedule(); // SewingSchedule


                string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                UpdateOutput(tmpdate);  //Sewing_TargetDay

                CGlobal.Sew_itemModelNew1 = "";
                CGlobal.Sew_itemModelNewSofa1 = "";

                CGlobal.Sew_QtyOut = "";
                CGlobal.Sew_QtyBal = "";
                CGlobal.Sew_Qtywip = "";
                CGlobal.Sew_itemModelNew1 = "";
                CGlobal.Sew_itemModelNewSofa1 = "";
                MessageBox.Show("Complete.");
                CGlobal.DocID = "";

                this.Close();
            }
        }

        #region " UpdateSewingSchedule();"
        private void UpdateSewingSchedule()
        {
            string tmpcell = CGlobal.Sew_deletecell;

            var query = new StringBuilder();
            query.Append("UPDATE dbo.Sewing_Schedule SET");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(", QtyBack  = @QtyBack");
            query.Append(", QtySeat  = @QtySeat");
            query.Append(", QtyBody  = @QtyBody");
            query.Append(" WHERE docno =  @docno"); //DocPoNo =  @Docno
            query.Append(" and Cellname =  @Cellname");

            using (var db = new DbHelper1())
            {
                try
                {
                    double Qtyout = Convert.ToDouble(this.lblbal.Text.Trim()) - 1;
                    double QtyBack = Convert.ToDouble(this.lblback.Text.Trim()) - 1;
                    double QtySeat = Convert.ToDouble(this.lblseat.Text.Trim()) - 1;
                    double QtyBody = Convert.ToDouble(this.lblbody.Text.Trim()) - 1;

                        db.AddParameter("@Qtyout", Qtyout);
                        db.AddParameter("@QtyBack", QtyBack);
                        db.AddParameter("@QtySeat", QtySeat);
                        db.AddParameter("@QtyBody", QtyBody);
                        db.AddParameter("@Docno", this.lblpo.Text.Trim());
                        db.AddParameter("@Cellname", tmpcell.Trim());

                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }
        }
        #endregion

        #region "DeletebSewing_DtlBarcode()"
        private void DeletebSewing_DtlBarcode()
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionBarcode());
            conn.Open();
            try
            {
                //  CGlobal.FrmcountLine
                string tmpcell = CGlobal.Sew_deletecell;
                string tmpdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));

               // double nend = Convert.ToInt32(CGlobal.DocID.Trim()) + 3;

                string cmdQuery1 = " Delete  from dbo.Sewing_DtlBarcode Where typecell = '" + tmpcell + "' and sdate='" + tmpdate + "' and docno='" + lblpo.Text.Trim() + "' and barcode='" + lblbarcode.Text.Trim() + "' and  Linenumber=" + CGlobal.FrmcountLine + "";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        
        }
        #endregion

        #region "UpdateOutput"
        private void UpdateOutput(string docdate)
        {
            var query = new StringBuilder();

            string tmpcell = CGlobal.Sew_deletecell;
            query.Append("Update  dbo.Sewing_TargetDay set Output=(select  Isnull(sum(qty),0) as qty   from dbo.Sewing_DtlBarcode");
            query.Append(" where sdate='" + docdate + "'  and TypeCell ='" + tmpcell + "' and remark='BACK')");
            query.Append(" WHERE sdate =  @sdate");
            query.Append(" and CellName =  @CellName");
            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@sdate", docdate);
                    db.AddParameter("@CellName", tmpcell);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }

        }
        #endregion

        #region "CallBarcode()"
        private void CallBarcode()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            try
            {
         
                Cmd = new System.Data.SqlClient.SqlCommand(" Select left(Itemcode,5)+'%'+substring(Itemcode,7,10)+'%' as Rsofa,Left(Itemcode,16) as itemnew,DocPoNo,DocNo,DeptCode,QtyBom,QtyOut,QtyBal,QtyUse,Qtywip,itemflag,Barcode,DocPoNo,SUBSTRING(ItemCode,3,19) as item,right(itemcode,4) as remark,left(ItemCode,16) as model   from dbo.DocMODtl  where  Barcode ='" + this.lblbarcode.Text.Trim() + "' and deptcode='W2'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
           
                    CGlobal.Sew_QtyOut = rs["QtyOut"].ToString();
                    CGlobal.Sew_QtyBal = rs["QtyBal"].ToString();
                    CGlobal.Sew_Qtywip = rs["Qtywip"].ToString();
                    CGlobal.Sew_itemModelNew1 = rs["itemnew"].ToString();
                    CGlobal.Sew_itemModelNewSofa1 = rs["Rsofa"].ToString();
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Search Sewing_DtlBarcode");
            }
            conn.Close();

        }
        #endregion

        #region "UpdateSewing_Schedule"
        private void UpdateDocMODtl()
        {
            var query = new StringBuilder();
            query.Append("UPDATE dbo.DocMODtl SET");
            query.Append(" QtyOut  = @QtyOut");
            query.Append(", QtyBal  = @QtyBal");
            query.Append(", QtyWip  = @QtyWip");
            query.Append(", ItemFlag  = @ItemType");
            query.Append(" WHERE Docno =  @Docno"); //DocPoNo =  @Docno
            query.Append(" and Itemcode like  @Itemcode");
            query.Append(" and deptcode='W2'");


            using (var db = new DbHelper1())
            {
                try
                {

                    double Qtyout = Convert.ToDouble(CGlobal.Sew_QtyOut) - 1;
                    double QtyBal = Convert.ToDouble(CGlobal.Sew_QtyBal) - 1;
                    double QtyWip = Convert.ToDouble(CGlobal.Sew_Qtywip) - 1;

                    string tmpdocno = Left(lblpo.Text.Trim(), 6);
                    if (tmpdocno == "R-SOFA")
                    { //R-sofa
                        db.AddParameter("@QtyOut", Qtyout);
                        db.AddParameter("@QtyBal", QtyBal);
                        db.AddParameter("@QtyWip", QtyWip);
                        db.AddParameter("@ItemType", "3");
                        db.AddParameter("@Docno", this.lblpo.Text.Trim());
                        db.AddParameter("@Itemcode", CGlobal.Sew_itemModelNewSofa1);
                    }
                    else
                    {  //sofa chair
                        db.AddParameter("@QtyOut", Qtyout);
                        db.AddParameter("@QtyBal", QtyBal);
                        db.AddParameter("@QtyWip", QtyWip);
                        db.AddParameter("@ItemType", "3");
                        db.AddParameter("@Docno", this.lblpo.Text.Trim());
                        db.AddParameter("@Itemcode", CGlobal.Sew_itemModelNew1 + "%");

                    }

                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);

                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error" + ex);
                }

            }

        }
        #endregion

    }
}
