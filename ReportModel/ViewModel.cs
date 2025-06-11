using System;
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

namespace PicklistBOM.ReportModel
{
    public partial class ViewModel : Form
    {
        public ViewModel()
        {
            InitializeComponent();
        }

        private void ViewModel_Load(object sender, EventArgs e)
        {
           // crystalReportViewer1.Refresh();
           
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\ReportOne.rpt");  //report ป้า packing
           // crReportDocument.Load(Application.StartupPath + "\\Report\\ReportRoding.rpt");  //report ป้า Rod

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


          //  crReportDocument.SetParameterValue(0, "1");

            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
            //crystalReportViewer1.Refresh();
            crystalReportViewer1.RefreshReport();
        }
    }
}
