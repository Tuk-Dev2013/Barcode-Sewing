namespace PicklistBOM.DeletePOCell
{
    partial class frmEditPO1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPO1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbopo = new System.Windows.Forms.ComboBox();
            this.bntsearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bntupdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtout = new System.Windows.Forms.TextBox();
            this.txtbal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bntbarcode = new System.Windows.Forms.ComboBox();
            this.lblfg = new System.Windows.Forms.Label();
            this.txtedit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntbarcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bntsearch);
            this.groupBox1.Controls.Add(this.cbopo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(543, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select ";
            // 
            // cbopo
            // 
            this.cbopo.FormattingEnabled = true;
            this.cbopo.Location = new System.Drawing.Point(91, 18);
            this.cbopo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbopo.Name = "cbopo";
            this.cbopo.Size = new System.Drawing.Size(321, 24);
            this.cbopo.TabIndex = 0;
            this.cbopo.SelectedIndexChanged += new System.EventHandler(this.cbopo_SelectedIndexChanged);
            // 
            // bntsearch
            // 
            this.bntsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bntsearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bntsearch.Image = ((System.Drawing.Image)(resources.GetObject("bntsearch.Image")));
            this.bntsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntsearch.Location = new System.Drawing.Point(422, 38);
            this.bntsearch.Name = "bntsearch";
            this.bntsearch.Size = new System.Drawing.Size(108, 35);
            this.bntsearch.TabIndex = 6;
            this.bntsearch.Text = "Search";
            this.bntsearch.UseVisualStyleBackColor = false;
            this.bntsearch.Click += new System.EventHandler(this.bntsearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "PO#.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtedit);
            this.groupBox2.Controls.Add(this.lblfg);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtbal);
            this.groupBox2.Controls.Add(this.txtout);
            this.groupBox2.Controls.Add(this.txtqty);
            this.groupBox2.Location = new System.Drawing.Point(7, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Detail";
            // 
            // bntupdate
            // 
            this.bntupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bntupdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bntupdate.Image = ((System.Drawing.Image)(resources.GetObject("bntupdate.Image")));
            this.bntupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntupdate.Location = new System.Drawing.Point(433, 286);
            this.bntupdate.Name = "bntupdate";
            this.bntupdate.Size = new System.Drawing.Size(123, 35);
            this.bntupdate.TabIndex = 7;
            this.bntupdate.Text = "Update";
            this.bntupdate.UseVisualStyleBackColor = false;
            this.bntupdate.Click += new System.EventHandler(this.bntupdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Barcode";
            // 
            // txtbarcode
            // 
            this.txtbarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbarcode.Location = new System.Drawing.Point(316, 286);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(53, 23);
            this.txtbarcode.TabIndex = 9;
            this.txtbarcode.Visible = false;
            // 
            // txtqty
            // 
            this.txtqty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtqty.Location = new System.Drawing.Point(89, 102);
            this.txtqty.Name = "txtqty";
            this.txtqty.ReadOnly = true;
            this.txtqty.Size = new System.Drawing.Size(100, 30);
            this.txtqty.TabIndex = 0;
            this.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtout
            // 
            this.txtout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtout.Location = new System.Drawing.Point(195, 102);
            this.txtout.Name = "txtout";
            this.txtout.ReadOnly = true;
            this.txtout.Size = new System.Drawing.Size(100, 30);
            this.txtout.TabIndex = 1;
            this.txtout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbal
            // 
            this.txtbal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtbal.Location = new System.Drawing.Point(300, 102);
            this.txtbal.Name = "txtbal";
            this.txtbal.ReadOnly = true;
            this.txtbal.Size = new System.Drawing.Size(100, 30);
            this.txtbal.TabIndex = 2;
            this.txtbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(29, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(146, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qty.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(255, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Out";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(364, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bal";
            // 
            // bntbarcode
            // 
            this.bntbarcode.FormattingEnabled = true;
            this.bntbarcode.Location = new System.Drawing.Point(91, 47);
            this.bntbarcode.Margin = new System.Windows.Forms.Padding(4);
            this.bntbarcode.Name = "bntbarcode";
            this.bntbarcode.Size = new System.Drawing.Size(321, 24);
            this.bntbarcode.TabIndex = 10;
            // 
            // lblfg
            // 
            this.lblfg.AutoSize = true;
            this.lblfg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblfg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblfg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblfg.Location = new System.Drawing.Point(79, 32);
            this.lblfg.Name = "lblfg";
            this.lblfg.Size = new System.Drawing.Size(43, 25);
            this.lblfg.TabIndex = 14;
            this.lblfg.Text = "FG";
            // 
            // txtedit
            // 
            this.txtedit.BackColor = System.Drawing.Color.White;
            this.txtedit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtedit.Location = new System.Drawing.Point(435, 102);
            this.txtedit.Name = "txtedit";
            this.txtedit.Size = new System.Drawing.Size(100, 30);
            this.txtedit.TabIndex = 15;
            this.txtedit.Text = "1";
            this.txtedit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(463, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Qty. Edit";
            // 
            // frmEditPO1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(568, 330);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.bntupdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEditPO1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditPO1";
            this.Load += new System.EventHandler(this.frmEditPO1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbopo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntsearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bntupdate;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbal;
        private System.Windows.Forms.TextBox txtout;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.ComboBox bntbarcode;
        private System.Windows.Forms.Label lblfg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtedit;
    }
}