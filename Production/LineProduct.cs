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
    public partial class LineProduct : Form
    {
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        public LineProduct()
        {
            InitializeComponent();
        }

        private void LineProduct_Load(object sender, EventArgs e)
        {
            this.lblCell.Text = ConfigurationManager.AppSettings["SHOW_CELL"];
            textBox1.Focus();
            ShowBarcode();
            SumQty();

        }

        #region " insertDocMODtlBarcode()"
        private void insertDocMODtlBarcode()
        {

            var query = new StringBuilder();
            query.Append("INSERT INTO dbo.DocMODtlBarcodeLine (DocNo, DeptCode, Qty, Barcode, DocPONo, Sdate, Linenumber, TypeCell)");
            query.Append(" VALUES (@DocNo, @DeptCode, @Qty, @Barcode, @DocPONo, @Sdate, @Linenumber, @TypeCell)");

            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            using (var db = new DbHelper1())
            {
                try
                {
                  //  Double num = Convert.ToDouble(CGlobal.QtyOut) + 1;
                   // string d1 = DateTime.Now.ToShortDateString();
                    string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                    db.AddParameter("@DocNo", "-");
                    db.AddParameter("@DeptCode", "W8");
                    db.AddParameter("@Qty", 1);
                    db.AddParameter("@Barcode", textBox1.Text.Trim());
                    db.AddParameter("@DocPONo", "-");
                    db.AddParameter("@Sdate", resultdate);
                    db.AddParameter("@Linenumber", "1");
                    db.AddParameter("@TypeCell", ConfigurationManager.AppSettings["SHOW_CELL"]);
                    db.ExecuteNonQuery(query.ToString());
                    //MessageBox.Show("บันทึกรายการเรียบร้อยแล้ว.");
 
                     //update การยิง barcode ทุกชั่วโมง
                    UpdateLine_Monitor();

                }

                catch (Exception ex)
                {
                    // db.RollbackTransaction();
                    MessageBox.Show("No Transfer");

                }
            }
            conn.Close();
        
        
        }

        #endregion

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

        #region "  CallSumQty()"
        private void CallSumQty(string sql)
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select *  from Line_Monitor  where TagetDate ='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string tempqty  =rs[""+ sql +""].ToString();
                    CGlobal.SumQty27 = Convert.ToString(Convert.ToDouble(tempqty) + 1);
                    string temptotal= rs["TotalOutput"].ToString();
                    CGlobal.Sumtotal27 = Convert.ToString(Convert.ToDouble(temptotal) + 1);
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion

        #region "UpdateMonitor"
        private void UpdateMonitor(string sql)
        {
            string tempday = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_Monitor SET");
            query.Append(" " + sql + "  = @Temp");
            query.Append(", TotalOutput  = @TotalOutput");
            query.Append(" WHERE TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@Temp", CGlobal.SumQty27);
                    db.AddParameter("@TotalOutput", CGlobal.Sumtotal27);
                    db.AddParameter("@TagetDate", tempday);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        
        }
        #endregion

        #region " CalltotalOutput();"
        private void CalltotalOutput()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" select *  from Line_MonitorWeek  where TagetDate ='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    string temptotal = rs["TotalOutput"].ToString();
                    CGlobal.TotalOutput27 = Convert.ToString(Convert.ToDouble(temptotal) + 1);
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        
        }
        #endregion

        #region "UpdateMonitorWeek()"
        private void UpdateMonitorWeek()
        {
            string tempday = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            var query = new StringBuilder();
            query.Append("UPDATE dbo.Line_MonitorWeek SET");
            query.Append(" TotalOutput  = @TotalOutput");
            query.Append(" WHERE TagetDate =  @TagetDate");

            using (var db = new DbHelper1())
            {
                try
                {
                    db.AddParameter("@TotalOutput", CGlobal.TotalOutput27);
                    db.AddParameter("@TagetDate", tempday);
                    db.ExecuteNonQuery(query.ToString(), DatabaseHelper1.DbConnectionState.KeepOpen);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex);
                }
            }
        
        }
        #endregion 

        #region " UpdateLine_Monitor()"
        private void UpdateLine_Monitor()
        {
            string tempday = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            string resultdate = DateTime.Now.ToString("HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            string house = Left(resultdate, 2);
            if ((Convert.ToInt16(house) >= 8)&&(Convert.ToInt16(house) < 9))
            {
               // MessageBox.Show("Ok");
                CallSumQty("total8");
                UpdateMonitor("total8");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 9) && (Convert.ToInt16(house) < 10))
            {
                CallSumQty("total9");
                UpdateMonitor("total9");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 10) && (Convert.ToInt16(house) < 11))
            {
                CallSumQty("total10");
                UpdateMonitor("total10");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 11) && (Convert.ToInt16(house) < 12))
            {
                CallSumQty("total11");
                UpdateMonitor("total11");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 12) && (Convert.ToInt16(house) < 13))
            {
                CallSumQty("total13");
                UpdateMonitor("total13");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 13) && (Convert.ToInt16(house) < 14))
            {
                CallSumQty("total13");
                UpdateMonitor("total13");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 14) && (Convert.ToInt16(house) < 15))
            {
                CallSumQty("total14");
                UpdateMonitor("total14");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 15) && (Convert.ToInt16(house) < 16))
            {
                CallSumQty("total15");
                UpdateMonitor("total15");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 16) && (Convert.ToInt16(house) < 17))
            {
                CallSumQty("total16");
                UpdateMonitor("total16");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 17) && (Convert.ToInt16(house) < 18))
            {
                CallSumQty("total17");
                UpdateMonitor("total17");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 18) && (Convert.ToInt16(house) < 19))
            {
                CallSumQty("total18");
                UpdateMonitor("total18");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
            else if ((Convert.ToInt16(house) >= 19) && (Convert.ToInt16(house) < 20))
            {
                CallSumQty("total19");
                UpdateMonitor("total19");
                CalltotalOutput();
                UpdateMonitorWeek();
            }
           else if ((Convert.ToInt16(house) >= 20) && (Convert.ToInt16(house) < 21))
            {
                CallSumQty("total20");
                UpdateMonitor("total20");
                CalltotalOutput();
                UpdateMonitorWeek();
           
           }
            else 
            {
                CallSumQty("total10");
                UpdateMonitor("total10");
                CalltotalOutput();
                UpdateMonitorWeek();
            }

            CGlobal.SumQty27 = "0";
            CGlobal.Sumtotal27 = "0";
            CGlobal.TotalOutput27 = "0";


        }
        #endregion


        #region " ShowBarcode()"
        private void ShowBarcode()
        {

            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
               string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                string strSQL1 = "";
                strSQL1 = " SELECT  Linenumber,TypeCell,DocNo,DocPONo,Barcode,Qty,DocID  from DocMODtlBarcodeLine"
                + " WHERE TypeCell ='" + this.lblCell.Text + "' and  Sdate ='" + resultdate  + "'";

                if (Isfind == true)
                {
                    ds.Tables["Showdata"].Clear();
                }

                da = new SqlDataAdapter(strSQL1, conn);
                da.Fill(ds, "Showdata");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Isfind = true;
                    dt = ds.Tables["Showdata"];
                    gridshow.DataSource = dt;
                }
                else
                {
                    Isfind = false;
                    this.gridshow.DataSource = null;
                 //   MessageBox.Show("No Data");
                }
                //  dataGridView1.DataBindings();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("No Data");
            }
            conn.Close();

        }
        #endregion

        #region "SumQty()"
        private void SumQty()
        {
            System.Data.SqlClient.SqlCommand Cmd;
            System.Data.SqlClient.SqlDataReader rs;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());

            //conn.Open();
            try
            {
                string resultdate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
                Cmd = new System.Data.SqlClient.SqlCommand(" SELECT Sum(Qty) As total FROM  DocMODtlBarcodeLine where TypeCell ='" + lblCell.Text.Trim () + "' and Sdate='" + resultdate + "'", conn);
                conn.Open();
                rs = Cmd.ExecuteReader();
                while (rs.Read())
                {
                    String  num =Convert.ToDouble(rs["total"]).ToString("#,###0");
                    lbltotal.Text = num;
                }

                // Callgridview();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }
        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox1.Text == "")
                {
                      MessageBox.Show(" คุณยังไม่ได้ยิง Barcode ค่ะ กรุณายิง Barcode ก่อน ?");
                       return;
                }
                else
                {

              
                insertDocMODtlBarcode();
                ShowBarcode();
                SumQty();
                textBox1.Text = "";
                }
            }
        

        }

        #region "      CallDelete temp 2bin"
        private void CallDelete(string tempID)
        {
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            try
            {
                string cmdQuery1 = " Delete  from dbo.DocMODtlBarcodeLine where DocID='" + tempID + "'";
                SqlCommand cmd = new SqlCommand(cmdQuery1, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            conn.Close();
            ShowBarcode();
            SumQty();
        }

        #endregion

        //private void gridshow_DoubleClick(object sender, EventArgs e)
        //{
        //    //if ((MessageBox.Show(" คุณต้องการลบรายการ  นี้หรือไม่ ?", "Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
        //    //{
        //    //    try
        //    //    {
        //    //        int index = gridView1.FocusedRowHandle;
        //    //        DataRow row = gridView1.GetDataRow(index);
        //    //        String tempID = Convert.ToString(gridView1.GetDataRow(index)["DocID"]);
        //    //        // MessageBox.Show(tempID);
        //    //     //   CallDelete(tempID);

        //    //        //ลบข้อมูล
        //    //      //  SearcQty();

        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //    }
        //    //}
        //}

  

        private void reportPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTotalT page1 = new FrmTotalT();
            page1.ShowDialog();
        }

        private void reportModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonitorLine.FrmShowMonitor page = new MonitorLine.FrmShowMonitor();
            page.Show();
        }





    }
}
