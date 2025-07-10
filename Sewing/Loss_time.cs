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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
namespace PicklistBOM.Sewing
{
    public partial class Loss_time : Form
    {

        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Boolean Isfind = false;
        Boolean Isfind1 = false;
        Boolean Isfind2 = false;
        Boolean Isfind3 = false;
        int id;
        public Loss_time()
        {
            InitializeComponent();
        }

        private void Loss_time_Load(object sender, EventArgs e)
        {
            gridView1.CustomRowCellEdit += gridView1_CustomRowCellEdit_1;

            // สร้างปุ่ม
            Edit();

  

            Showdata();
        }
      

        private void Edit()
        {
            RepositoryItemButtonEdit repoStart = new RepositoryItemButtonEdit();
            repoStart.TextEditStyle = TextEditStyles.HideTextEditor;
            repoStart.Buttons[0].Kind = ButtonPredefines.Glyph;
            repoStart.Buttons[0].Caption = "Receive";

            RepositoryItemButtonEdit repoEnd = new RepositoryItemButtonEdit();
            repoEnd.TextEditStyle = TextEditStyles.HideTextEditor;
            repoEnd.Buttons[0].Kind = ButtonPredefines.Glyph;
            repoEnd.Buttons[0].Caption = "On process";

            RepositoryItemButtonEdit repocomplete = new RepositoryItemButtonEdit();
            repocomplete.TextEditStyle = TextEditStyles.HideTextEditor;
            repocomplete.Buttons[0].Kind = ButtonPredefines.Glyph;
            repocomplete.Buttons[0].Caption = "Complete";

            // เพิ่มทั้งสองปุ่มเข้า RepositoryItems
            gridshow.RepositoryItems.Add(repoStart);
            gridshow.RepositoryItems.Add(repoEnd);
            gridshow.RepositoryItems.Add(repocomplete);

            // ผูก Default (ชั่วคราว) ให้กับคอลัมน์ก่อน
            gridView1.Columns["Losscode"].ColumnEdit = repoStart;

            // กำหนดให้แก้ไขได้
            gridView1.Columns["Losscode"].OptionsColumn.AllowEdit = true;


            // กำหนดเหตุการณ์เมื่อคลิกปุ่ม
            // ปุ่ม "รับ"
            repoStart.ButtonClick += (object sender, ButtonPressedEventArgs e) =>
            {
                int rowHandle = gridView1.FocusedRowHandle;

                var id = gridView1.GetRowCellValue(rowHandle, "Losscode");
                if (id == null || id == DBNull.Value)
                {
                    MessageBox.Show("ไม่พบ Losscode ในแถวนี้");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode()))
                {
                    conn.Open();
                    string sql = "UPDATE DocMODtlBarcodeLossWip SET ProcessStartDate = GETDATE() WHERE Losscode = @ID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("เริ่มกระบวนการแล้ว ");
                Showdata();
            };

            // ปุ่ม "จบ"
            repoEnd.ButtonClick += (object sender, ButtonPressedEventArgs e) =>
            {
                int rowHandle = gridView1.FocusedRowHandle;

                var id = gridView1.GetRowCellValue(rowHandle, "Losscode");
                var DeptStart = gridView1.GetRowCellValue(rowHandle, "DeptStart");
                if (id == null || id == DBNull.Value)
                {
                    MessageBox.Show("ไม่พบ Losscode ในแถวนี้");
                    return;
                }
                if (DeptStart.ToString() == "Sewing")
                {
                    using (SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode()))
                    {
                        conn.Open();
                        string sql = "UPDATE DocMODtlBarcodeLossWip SET ProcessEndWip='Sewing',ProcessEndDate = GETDATE(),DeptEnd=@DeptEnd,Status=@Status,Endtime=@Endtime,UserName_Wip=@UserName_Wip WHERE Losscode = @ID";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Parameters.AddWithValue("@DeptEnd", "Sewing");
                            cmd.Parameters.AddWithValue("@Status", "complete");
                            cmd.Parameters.AddWithValue("@Endtime", DateTime.Now.ToString());
                            cmd.Parameters.AddWithValue("@UserName_Wip", ConfigurationManager.AppSettings["SHOW_CELL1"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    CGlobal.CheckOn = "Yes";
                }
                else 
                {
              
                    using (SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode()))
                    {
                        conn.Open();
                        string sql = "UPDATE DocMODtlBarcodeLossWip SET ProcessEndWip='Sewing',ProcessEndDate = GETDATE() WHERE Losscode = @ID";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                
                }


                MessageBox.Show("สิ้นสุดกระบวนการแล้ว");
                Showdata();
            };
            // ปุ่ม "repocomplete"
            repocomplete.ButtonClick += (object sender, ButtonPressedEventArgs e) =>
            {
                int rowHandle = gridView1.FocusedRowHandle;

                var id = gridView1.GetRowCellValue(rowHandle, "Losscode");
                if (id == null || id == DBNull.Value)
                {
                    MessageBox.Show("ไม่พบ Losscode ในแถวนี้");
                    return;
                }


                MessageBox.Show("สิ้นสุดกระบวนการแล้ว");
                Showdata();
            };

            CGlobal.CheckOn = "Yes";
        }

     
        private void Showdata()
        {
            this.gridshow.DataSource = null;
            SqlConnection conn = new SqlConnection(WebConfig.GetconnectionLeanBarcode());
            conn.Open();
            string strSQL1 = "";
            strSQL1 = " SELECT * from   DocMODtlBarcodeLossWip where ProcessStartWip='Sewing' and Status='on process'";

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
           
        }

        private void gridView1_CustomRowCellEdit_1(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Losscode")
            {
                var processStart = gridView1.GetRowCellValue(e.RowHandle, "ProcessStartDate");
                var ProcessEndDate = gridView1.GetRowCellValue(e.RowHandle, "ProcessEndDate");
                if (processStart != DBNull.Value && processStart != null && processStart.ToString() != "" && ProcessEndDate == DBNull.Value)
                {
                    // แถวนี้มี ProcessStartDate → ใช้ปุ่ม "จบ"
                    e.RepositoryItem = gridshow.RepositoryItems
                        .OfType<RepositoryItemButtonEdit>()
                        .FirstOrDefault(r => r.Buttons[0].Caption == "On process");
                }
                else if (processStart != DBNull.Value && ProcessEndDate != DBNull.Value && ProcessEndDate != null && ProcessEndDate.ToString() != "")
                {
                    // แถวนี้มี ProcessStartDate → ใช้ปุ่ม "จบ"
                    e.RepositoryItem = gridshow.RepositoryItems
                        .OfType<RepositoryItemButtonEdit>()
                        .FirstOrDefault(r => r.Buttons[0].Caption == "Complete");
                }
                else if (processStart == DBNull.Value && ProcessEndDate == DBNull.Value && ProcessEndDate == null && ProcessEndDate.ToString() == "")
                {
                    // แถวนี้ยังไม่มี ProcessStartDate → ใช้ปุ่ม "รับ"
                    e.RepositoryItem = gridshow.RepositoryItems
                        .OfType<RepositoryItemButtonEdit>()
                        .FirstOrDefault(r => r.Buttons[0].Caption == "Receive");
                }
            }
        }
    }
}
