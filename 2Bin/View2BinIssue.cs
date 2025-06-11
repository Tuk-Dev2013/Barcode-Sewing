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
    public partial class View2BinIssue : Form
    {
        public View2BinIssue()
        {
            InitializeComponent();
        }

        private void View2BinIssue_Load(object sender, EventArgs e)
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report2Bin\\2BinType.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.IssueEdate);
            crReportDocument.SetParameterValue(1, CGlobal.IssueSdate);
            crReportDocument.SetParameterValue(2, CGlobal.IssueType);
        
            crReportDocument.SetParameterValue(3, CGlobal.BinPO);
            crReportDocument.SetParameterValue(4, CGlobal.IssueNo2);
            crReportDocument.SetParameterValue(5, CGlobal.BinBOI);
            crReportDocument.SetParameterValue(6, CGlobal.IssueNo2);

            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;

        }
    }
}
