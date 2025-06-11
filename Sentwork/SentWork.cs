using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicklistBOM.Sentwork
{
    public partial class SentWork : Form
    {
        public SentWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (this.txtsearch.Text == "")
            //{
            //    MessageBox.Show("กรุณาป้อนข้อมูลด้วยค่ะ");
            //    return;
            //}
            CGlobal.DocNo = this.cboDocRefNo.Text;
            PicklistBOM.Sentwork.ReportSentwork page = new PicklistBOM.Sentwork.ReportSentwork();
            page.Show();


        }

        private void SentWork_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet.View_DocOrder' table. You can move, or remove it, as needed.
            this.view_DocOrderTableAdapter.Fill(this.dBBARCODEDataSet.View_DocOrder);

        }
    }
}
