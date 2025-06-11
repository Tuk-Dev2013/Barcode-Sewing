namespace PicklistBOM.Sentwork
{
    partial class SentWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SentWork));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDocRefNo = new System.Windows.Forms.ComboBox();
            this.dBBARCODEDataSet = new PicklistBOM.DBBARCODEDataSet();
            this.viewDocOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_DocOrderTableAdapter = new PicklistBOM.DBBARCODEDataSetTableAdapters.View_DocOrderTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(287, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Report";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDocRefNo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ใบรับ-ส่งงาน  ระหว่างแผนก";
            // 
            // cboDocRefNo
            // 
            this.cboDocRefNo.DataSource = this.viewDocOrderBindingSource;
            this.cboDocRefNo.DisplayMember = "DocRefNo";
            this.cboDocRefNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDocRefNo.FormattingEnabled = true;
            this.cboDocRefNo.Location = new System.Drawing.Point(6, 39);
            this.cboDocRefNo.Name = "cboDocRefNo";
            this.cboDocRefNo.Size = new System.Drawing.Size(275, 24);
            this.cboDocRefNo.TabIndex = 2;
            this.cboDocRefNo.ValueMember = "DocRefNo";
            // 
            // dBBARCODEDataSet
            // 
            this.dBBARCODEDataSet.DataSetName = "DBBARCODEDataSet";
            this.dBBARCODEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewDocOrderBindingSource
            // 
            this.viewDocOrderBindingSource.DataMember = "View_DocOrder";
            this.viewDocOrderBindingSource.DataSource = this.dBBARCODEDataSet;
            // 
            // view_DocOrderTableAdapter
            // 
            this.view_DocOrderTableAdapter.ClearBeforeFill = true;
            // 
            // SentWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 137);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SentWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SentWork";
            this.Load += new System.EventHandler(this.SentWork_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dBBARCODEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocOrderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDocRefNo;
        private DBBARCODEDataSet dBBARCODEDataSet;
        private System.Windows.Forms.BindingSource viewDocOrderBindingSource;
        private DBBARCODEDataSetTableAdapters.View_DocOrderTableAdapter view_DocOrderTableAdapter;
    }
}