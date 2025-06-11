using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicklistBOM.PictureModel
{
    public partial class bntpic1 : Form
    {
        public bntpic1()
        {
            InitializeComponent();
        }

        private void bntpic1_Load(object sender, EventArgs e)
        {

        }

        private void LoadNewFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
    
                txtpic1.Text = ofd.FileName;
                pic1.ImageLocation = ofd.FileName;
                Size size = new Size(77, 50);
                pic1.Size = size;

              //  pic1.SizeMode = PictureBoxSizeMode.AutoSize;
             //   pic1.Height =77;
              //  pic1.Width = 50;


            }
        }
        private void LoadNewFile2()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtpic2.Text = ofd.FileName;
                pic2.ImageLocation = ofd.FileName;
              //  pic2.SizeMode = PictureBoxSizeMode.AutoSize;

            }
        }
        private void bntpic11_Click(object sender, EventArgs e)
        {
            LoadNewFile();
        }

        private void bntpic22_Click(object sender, EventArgs e)
        {
            LoadNewFile2();
        }

    }
}
