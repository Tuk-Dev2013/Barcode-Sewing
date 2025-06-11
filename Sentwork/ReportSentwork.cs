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

namespace PicklistBOM.Sentwork
{
    public partial class ReportSentwork : Form
    {
        public ReportSentwork()
        {
            InitializeComponent();
        }

        private void ReportSentwork_Load(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Sentwork\\Sentwork1.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.DocNo);
            // crReportDocument.SetParameterValue(1, CGlobal.DocDept);
            // crReportDocument.SetParameterValue(2, CGlobal.DocProj);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = true;
        }
    }
}
