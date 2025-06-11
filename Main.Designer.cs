namespace PicklistBOM
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cbosuper = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpo = new System.Windows.Forms.ComboBox();
            this.viewPORefQtyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBARCODEDataSet12 = new PicklistBOM.DBBARCODEDataSet12();
            this.bntreport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusMain = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusVersionName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabelConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitLotPOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportPicklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportPicklistToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.view_PORefQtyTableAdapter = new PicklistBOM.DBBARCODEDataSet12TableAdapters.View_PORefQtyTableAdapter();
            this.cachedReportPODate1 = new PicklistBOM.bin.Debug.Report.CachedReportPODate();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPORefQtyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet12)).BeginInit();
            this.StatusMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbosuper
            // 
            this.cbosuper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbosuper.FormattingEnabled = true;
            this.cbosuper.Items.AddRange(new object[] {
            "Leather Pick List",
            "Sewing Pick List  1",
            "Sewing Pick List  2",
            "Sewing Pick List  3",
            "Frame Pick List",
            "Roding Pick List",
            "Pressing Pick List",
            "Poly  Pick List 1",
            "Poly  Pick List 2",
            "Final Assemble Pick List",
            "Packing  Pick List"});
            this.cbosuper.Location = new System.Drawing.Point(109, 18);
            this.cbosuper.Name = "cbosuper";
            this.cbosuper.Size = new System.Drawing.Size(209, 24);
            this.cbosuper.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpo);
            this.groupBox1.Controls.Add(this.bntreport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbosuper);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtpo
            // 
            this.txtpo.DataSource = this.viewPORefQtyBindingSource;
            this.txtpo.DisplayMember = "DocRefNo";
            this.txtpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtpo.FormattingEnabled = true;
            this.txtpo.Location = new System.Drawing.Point(360, 18);
            this.txtpo.Name = "txtpo";
            this.txtpo.Size = new System.Drawing.Size(227, 24);
            this.txtpo.TabIndex = 104;
            this.txtpo.ValueMember = "DocRefNo";
            // 
            // viewPORefQtyBindingSource
            // 
            this.viewPORefQtyBindingSource.DataMember = "View_PORefQty";
            this.viewPORefQtyBindingSource.DataSource = this.dBBARCODEDataSet12;
            // 
            // dBBARCODEDataSet12
            // 
            this.dBBARCODEDataSet12.DataSetName = "DBBARCODEDataSet12";
            this.dBBARCODEDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bntreport
            // 
            this.bntreport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntreport.Image = ((System.Drawing.Image)(resources.GetObject("bntreport.Image")));
            this.bntreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntreport.Location = new System.Drawing.Point(592, 13);
            this.bntreport.Name = "bntreport";
            this.bntreport.Size = new System.Drawing.Size(90, 36);
            this.bntreport.TabIndex = 103;
            this.bntreport.Text = "Search";
            this.bntreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntreport.UseVisualStyleBackColor = true;
            this.bntreport.Click += new System.EventHandler(this.bntreport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "PO.  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Super Market :";
            // 
            // StatusMain
            // 
            this.StatusMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.StatusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusForm,
            this.ToolStripStatusLabel2,
            this.ToolStripStatusLabel3,
            this.ToolStripStatusLabel4,
            this.ToolStripStatusUserName,
            this.ToolStripStatusLabel5,
            this.ToolStripStatusLabel6,
            this.ToolStripStatusLabel7,
            this.ToolStripStatusVersionName,
            this.ToolStripStatusLabel8,
            this.ToolStripStatusLabelConnect});
            this.StatusMain.Location = new System.Drawing.Point(0, 722);
            this.StatusMain.Name = "StatusMain";
            this.StatusMain.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.StatusMain.Size = new System.Drawing.Size(1018, 22);
            this.StatusMain.TabIndex = 61;
            this.StatusMain.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.ToolStripStatusLabel1.Text = "ระบบ :";
            this.ToolStripStatusLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // ToolStripStatusForm
            // 
            this.ToolStripStatusForm.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusForm.Name = "ToolStripStatusForm";
            this.ToolStripStatusForm.Size = new System.Drawing.Size(50, 17);
            this.ToolStripStatusForm.Text = "Pick List";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(79, 17);
            this.ToolStripStatusLabel2.Text = "                        ";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.ToolStripStatusLabel3.Text = "|";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(58, 17);
            this.ToolStripStatusLabel4.Text = "ผู้ใช้ระบบ :";
            // 
            // ToolStripStatusUserName
            // 
            this.ToolStripStatusUserName.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusUserName.Name = "ToolStripStatusUserName";
            this.ToolStripStatusUserName.Size = new System.Drawing.Size(27, 17);
            this.ToolStripStatusUserName.Text = "MIS";
            this.ToolStripStatusUserName.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Size = new System.Drawing.Size(67, 17);
            this.ToolStripStatusLabel5.Text = "                    ";
            // 
            // ToolStripStatusLabel6
            // 
            this.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            this.ToolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.ToolStripStatusLabel6.Text = "|";
            // 
            // ToolStripStatusLabel7
            // 
            this.ToolStripStatusLabel7.ForeColor = System.Drawing.Color.Black;
            this.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7";
            this.ToolStripStatusLabel7.Size = new System.Drawing.Size(52, 17);
            this.ToolStripStatusLabel7.Text = "Version :";
            // 
            // ToolStripStatusVersionName
            // 
            this.ToolStripStatusVersionName.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusVersionName.Name = "ToolStripStatusVersionName";
            this.ToolStripStatusVersionName.Size = new System.Drawing.Size(22, 17);
            this.ToolStripStatusVersionName.Text = "1.0";
            // 
            // ToolStripStatusLabel8
            // 
            this.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8";
            this.ToolStripStatusLabel8.Size = new System.Drawing.Size(37, 17);
            this.ToolStripStatusLabel8.Text = "          ";
            // 
            // ToolStripStatusLabelConnect
            // 
            this.ToolStripStatusLabelConnect.ForeColor = System.Drawing.Color.Indigo;
            this.ToolStripStatusLabelConnect.Name = "ToolStripStatusLabelConnect";
            this.ToolStripStatusLabelConnect.Size = new System.Drawing.Size(124, 17);
            this.ToolStripStatusLabelConnect.Text = "LA-Z-BOY-THAILAND";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitLotPOToolStripMenuItem,
            this.reportPicklistToolStripMenuItem,
            this.reportPicklistToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
            this.menuStrip1.TabIndex = 102;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitLotPOToolStripMenuItem
            // 
            this.splitLotPOToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.splitLotPOToolStripMenuItem.Name = "splitLotPOToolStripMenuItem";
            this.splitLotPOToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.splitLotPOToolStripMenuItem.Text = "Split Lot PO.";
            this.splitLotPOToolStripMenuItem.Click += new System.EventHandler(this.splitLotPOToolStripMenuItem_Click);
            // 
            // reportPicklistToolStripMenuItem
            // 
            this.reportPicklistToolStripMenuItem.Name = "reportPicklistToolStripMenuItem";
            this.reportPicklistToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
            this.reportPicklistToolStripMenuItem.Text = "||";
            // 
            // reportPicklistToolStripMenuItem1
            // 
            this.reportPicklistToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.reportPicklistToolStripMenuItem1.Name = "reportPicklistToolStripMenuItem1";
            this.reportPicklistToolStripMenuItem1.Size = new System.Drawing.Size(100, 20);
            this.reportPicklistToolStripMenuItem1.Text = "Report Picklist";
            this.reportPicklistToolStripMenuItem1.Click += new System.EventHandler(this.reportPicklistToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(27, 20);
            this.toolStripMenuItem1.Text = "||";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.AutoScroll = true;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 91);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1018, 628);
            this.crystalReportViewer1.TabIndex = 103;
            this.crystalReportViewer1.ToolPanelWidth = 0;
            // 
            // view_PORefQtyTableAdapter
            // 
            this.view_PORefQtyTableAdapter.ClearBeforeFill = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 744);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StatusMain);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPORefQtyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet12)).EndInit();
            this.StatusMain.ResumeLayout(false);
            this.StatusMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbosuper;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.StatusStrip StatusMain;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusForm;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusUserName;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel5;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel6;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel7;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusVersionName;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel8;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabelConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem splitLotPOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportPicklistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportPicklistToolStripMenuItem1;
        private System.Windows.Forms.Button bntreport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox txtpo;
        private DBBARCODEDataSet12 dBBARCODEDataSet12;
        private System.Windows.Forms.BindingSource viewPORefQtyBindingSource;
        private DBBARCODEDataSet12TableAdapters.View_PORefQtyTableAdapter view_PORefQtyTableAdapter;
        private bin.Debug.Report.CachedReportPODate cachedReportPODate1;
    }
}