using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace PicklistBOM
{
    public partial class MainReportModel : Form
    {
        public MainReportModel()
        {
            InitializeComponent();
        }

        private void reportPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainReport page = new MainReport();
            page.Show();
            this.Hide();
        }

        private void reportModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainReportModel page = new MainReportModel();
            page.Show();
            this.Hide();
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\ReportModel.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            string sdate = this.startdate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));
            string edate = this.enddate.Value.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US"));

            string startDate = sdate + " 00:00:00.000";
            string EndtDate = edate + " 00:00:00.000";


            crReportDocument.SetParameterValue(0, EndtDate);
            crReportDocument.SetParameterValue(1, startDate);


            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        }

        private void reportMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainReportMessage page = new MainReportMessage();
            page.Show();
            this.Hide();
        }

        private void MainReportModel_Load(object sender, EventArgs e)
        {

        }

        private void reportPODateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainReportDate page = new MainReportDate();
            page.Show();
            this.Hide();
        }

        private void reportModelDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainReportModelDate page = new MainReportModelDate();
            page.Show();
            this.Hide();
        }
    }
}
