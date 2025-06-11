namespace PicklistBOM.Sewing
{
    partial class frmoperator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmoperator));
            this.label1 = new System.Windows.Forms.Label();
            this.txtperson = new System.Windows.Forms.TextBox();
            this.bntadd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(38, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 39);
            this.label1.TabIndex = 112;
            this.label1.Text = "Total Operator";
            // 
            // txtperson
            // 
            this.txtperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtperson.Location = new System.Drawing.Point(110, 75);
            this.txtperson.Name = "txtperson";
            this.txtperson.Size = new System.Drawing.Size(100, 45);
            this.txtperson.TabIndex = 111;
            this.txtperson.Text = "0";
            this.txtperson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bntadd
            // 
            this.bntadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bntadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bntadd.Image = ((System.Drawing.Image)(resources.GetObject("bntadd.Image")));
            this.bntadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntadd.Location = new System.Drawing.Point(92, 125);
            this.bntadd.Name = "bntadd";
            this.bntadd.Size = new System.Drawing.Size(130, 39);
            this.bntadd.TabIndex = 113;
            this.bntadd.Text = "Save";
            this.bntadd.UseVisualStyleBackColor = false;
            this.bntadd.Click += new System.EventHandler(this.bntadd_Click);
            // 
            // frmoperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(333, 189);
            this.Controls.Add(this.bntadd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtperson);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmoperator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operator";
            this.Load += new System.EventHandler(this.frmoperator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtperson;
        private System.Windows.Forms.Button bntadd;
    }
}