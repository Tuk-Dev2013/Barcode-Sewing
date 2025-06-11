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

namespace PicklistBOM.JinnyBOM
{
    public partial class Frmjinnyreport : Form
    {
        public Frmjinnyreport()
        {
            InitializeComponent();
        }

        private void Frmjinnyreport_Load(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\JinnyR\\JinnyReport.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.BinBOI);


            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        }
    }
}
