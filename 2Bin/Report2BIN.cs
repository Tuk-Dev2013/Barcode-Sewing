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

namespace PicklistBOM._2Bin
{
    public partial class Report2BIN : Form
    {
        public Report2BIN()
        {
            InitializeComponent();
        }

        private void Report2BIN_Load(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report2Bin\\2Bin.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.DocNo);
            crReportDocument.SetParameterValue(1, CGlobal.DocDept);
            crReportDocument.SetParameterValue(2, CGlobal.DocProj);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        }
    }
}
