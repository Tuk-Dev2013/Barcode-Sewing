using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicklistBOM.MonitorCell
{
    public partial class FrmMain1 : Form
    {
        public FrmMain1()
        {
            InitializeComponent();
        }

        private void bntwk_Click(object sender, EventArgs e)
        {
            //Application.Run(new PicklistBOM.SumCell.frmSum());
            SumCell.frmSum page = new SumCell.frmSum();  // ยิง barcode จ่าย Poly Batch
            page.Show();
          //  this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonitorCell.FrmCell0 page = new MonitorCell.FrmCell0();  // ยิง barcode จ่าย Poly Batch
            page.Show();
        }

        private void bntcell1_Click(object sender, EventArgs e)
        {
            MonitorCell.FrmCell1 page = new MonitorCell.FrmCell1();  // ยิง barcode จ่าย Poly Batch
            page.Show();
        }

        private void bntcell2_Click(object sender, EventArgs e)
        {
            MonitorCell.FrmCell2 page = new MonitorCell.FrmCell2();  // ยิง barcode จ่าย Poly Batch
            page.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MonitorCell.FrmCell3 page = new MonitorCell.FrmCell3();  // ยิง barcode จ่าย Poly Batch
            page.Show();
        }

        private void FrmMain1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScheduleCell.FrmShowSchedule page = new ScheduleCell.FrmShowSchedule();  // ยิง barcode จ่าย Poly Batch
            page.Show();
        }
    }
}
