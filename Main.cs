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
    public partial class Main : Form
    {

        private PicklistW5 PicklistW5;
        private PicklistW6 PicklistW6;
        private PicklistW4 PicklistW4;
        private PicklistW3 PicklistW3;
        private txtPOSearch1 paytime;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBBARCODEDataSet12.View_PORefQty' table. You can move, or remove it, as needed.
            this.view_PORefQtyTableAdapter.Fill(this.dBBARCODEDataSet12.View_PORefQty);
            ToolStripStatusForm.Text = CGlobal.VersionName;
            ToolStripStatusVersionName.Text = CGlobal.Version;
            ToolStripStatusUserName.Text = CGlobal.Username;
        }


        private void splitLotPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paytime = new txtPOSearch1();
            paytime.Show();
            this.Hide();
        }

        private void reportPicklistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Main page = new Main();
            page.Show();
            this.Hide();
        }

        #region "report"
        private void bntreport_Click(object sender, EventArgs e)
        {
            if (this.txtpo.Text == "")
            {
                MessageBox.Show("กรุณาป้อน PO. ด้วยค่ะ");
                this.txtpo.Focus();
                return;
            }
            if (this.cbosuper.Text == "Leather Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW5 = new PicklistW5();
                //PicklistW5.Show();
                CallW1();
            }
            if (this.cbosuper.Text == "Sewing Pick List  1")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW5 = new PicklistW5();
                //PicklistW5.Show();
                CallW2();
            }

            if (this.cbosuper.Text == "Sewing Pick List  2")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW5 = new PicklistW5();
                //PicklistW5.Show();
                CallW2_1();
            }

            if (this.cbosuper.Text == "Sewing Pick List  3")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                CallW2_2();
            }
            if (this.cbosuper.Text == "Pressing Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW5 = new PicklistW5();
                //PicklistW5.Show();
                CallW5();
            }
            else if (this.cbosuper.Text == "Poly  Pick List 1")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW6 = new PicklistW6();
                //PicklistW6.Show();
                CallW6();

            }

            else if (this.cbosuper.Text == "Poly  Pick List 2")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW6 = new PicklistW6();
                //PicklistW6.Show();
                CallW6_1();

            }
            else if (this.cbosuper.Text == "Roding Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW4 = new PicklistW4();
                //PicklistW4.Show();
                CallW4();

            }
            else if (this.cbosuper.Text == "Frame Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW3 = new PicklistW3();
                //PicklistW3.Show();
                CallW3();

            }
            else if (this.cbosuper.Text == "Final Assemble Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW3 = new PicklistW3();
                //PicklistW3.Show();
                CallW7();

            }
            else if (this.cbosuper.Text == "Packing  Pick List")
            {
                CGlobal.PO = this.txtpo.Text.Trim();
                //PicklistW3 = new PicklistW3();
                //PicklistW3.Show();
                CallW8();

            }
        }

        #endregion

        #region " CallW1();"
        private void CallW1()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW1.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        
        
        }
        #endregion


        #region " CallW2();"
        private void CallW2()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW2.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }
        #endregion

        #region " CallW2_1();"
        private void CallW2_1()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW2_1.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }
        #endregion

        #region " CallW2_2();"
        private void CallW2_2()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW2_2.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }
        #endregion


        #region"CallW5();"
        private void CallW5()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW5.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);


            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        
        }
        #endregion

        #region "CallW6();"
        private void CallW6()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW6.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        
        
        }

        #endregion


        #region "CallW6_1();"
        private void CallW6_1()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW6_1.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }

        #endregion





        #region " CallW4();"
        private void CallW4()
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
        #endregion

        #region "  CallW3()";
        private void CallW3()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW3.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;
        
        
        }
        #endregion


        #region "  CallW7()";
        private void CallW7()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW7.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }
        #endregion

        #region "  CallW8()";
        private void CallW8()
        {
            ReportDocument crReportDocument = new ReportDocument();
            crReportDocument.Load(Application.StartupPath + "\\Report\\PicklistW8.rpt");

            ReportExportDemo.Reports.ReportLogin(crReportDocument, ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);

            crReportDocument.SetParameterValue(0, CGlobal.PO);
            // crReportDocument.SetParameterValue(1, CGlobal.style);
            //crReportDocument.SetParameterValue(2, CGlobal.model);
            //crReportDocument.SetParameterValue(3, CGlobal.HeadDetail);
            //crReportDocument.SetParameterValue(4, CGlobal.Commnet);
            crystalReportViewer1.ReportSource = crReportDocument;
            crystalReportViewer1.DisplayGroupTree = false;


        }
        #endregion

        private void txtpo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtpo.Text == "")
                {
                    MessageBox.Show("กรุณาป้อน PO. ด้วยค่ะ");
                    this.txtpo.Focus();
                    return;
                }
                if (this.cbosuper.Text == "Leather Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW5 = new PicklistW5();
                    //PicklistW5.Show();
                    CallW1();
                }
                if (this.cbosuper.Text == "Sewing Pick List  1")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW5 = new PicklistW5();
                    //PicklistW5.Show();
                    CallW2();
                }

                if (this.cbosuper.Text == "Sewing Pick List  2")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW5 = new PicklistW5();
                    //PicklistW5.Show();
                    CallW2_1();
                }
                if (this.cbosuper.Text == "Pressing Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW5 = new PicklistW5();
                    //PicklistW5.Show();
                    CallW5();
                }
                else if (this.cbosuper.Text == "Poly  Pick List 1")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW6 = new PicklistW6();
                    //PicklistW6.Show();
                    CallW6();

                }

                else if (this.cbosuper.Text == "Poly  Pick List 2")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW6 = new PicklistW6();
                    //PicklistW6.Show();
                    CallW6_1();

                }
                else if (this.cbosuper.Text == "Roding Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW4 = new PicklistW4();
                    //PicklistW4.Show();
                    CallW4();

                }
                else if (this.cbosuper.Text == "Frame Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW3 = new PicklistW3();
                    //PicklistW3.Show();
                    CallW3();

                }
                else if (this.cbosuper.Text == "Final Assemble Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW3 = new PicklistW3();
                    //PicklistW3.Show();
                    CallW7();

                }
                else if (this.cbosuper.Text == "Packing  Pick List")
                {
                    CGlobal.PO = this.txtpo.Text.Trim();
                    //PicklistW3 = new PicklistW3();
                    //PicklistW3.Show();
                    CallW8();

                }
                }
            }

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.Frm2BinDefault page = new PicklistBOM._2Bin.Frm2BinDefault();
            page.Show();
            this.Hide();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicklistBOM._2Bin.FrmBatch page = new PicklistBOM._2Bin.FrmBatch();
            page.Show();
            this.Hide();
        }
        
    
    
    }
}
