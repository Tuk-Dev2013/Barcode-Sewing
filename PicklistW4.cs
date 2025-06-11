using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace PicklistBOM
{
    public partial class PicklistW4 : Form
    {
        public PicklistW4()
        {
            InitializeComponent();
        }

        private void PicklistW4_Load(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW4.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        }
    }
}
