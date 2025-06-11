namespace PicklistBOM
{
    partial class FrmTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeam));
            this.lbltotal = new System.Windows.Forms.Label();
            this.lbltotaltarget = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltotal
            // 
            this.lbltotal.BackColor = System.Drawing.Color.Black;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotal.ForeColor = System.Drawing.Color.Yellow;
            this.lbltotal.Location = new System.Drawing.Point(123, 305);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(390, 120);
            this.lbltotal.TabIndex = 88;
            this.lbltotal.Text = "0";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotaltarget
            // 
            this.lbltotaltarget.BackColor = System.Drawing.Color.Black;
            this.lbltotaltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltotaltarget.ForeColor = System.Drawing.Color.Red;
            this.lbltotaltarget.Location = new System.Drawing.Point(134, 83);
            this.lbltotaltarget.Name = "lbltotaltarget";
            this.lbltotaltarget.Size = new System.Drawing.Size(352, 118);
            this.lbltotaltarget.TabIndex = 87;
            this.lbltotaltarget.Text = "0";
            this.lbltotaltarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Purple;
            this.label8.Location = new System.Drawing.Point(122, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(378, 64);
            this.label8.TabIndex = 90;
            this.label8.Text = "Today Target";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.Purple;
            this.label9.Location = new System.Drawing.Point(122, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(391, 64);
            this.label9.TabIndex = 89;
            this.label9.Text = "Today Output";
            // 
            // FrmTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 470);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lbltotaltarget);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team";
            this.Load += new System.EventHandler(this.FrmTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lbltotaltarget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}