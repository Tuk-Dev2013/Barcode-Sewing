using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PicklistBOM.Sewing
{
    public partial class MassgeBox : Form
    {
        public MassgeBox()
        {
            InitializeComponent();
            this.Load += MassgeBox_Load;
            this.Shown += MassgeBox_Shown;
        }

        private void MassgeBox_Load(object sender, EventArgs e)
        {
            MakeFormRounded(25);

            // ปิด focus สีน้ำเงิน และใส่ flat style
            btnCircle.FlatStyle = FlatStyle.Flat;
            btnCircle.FlatAppearance.BorderSize = 0;
            btnCircle.TabStop = false;
        }

        private void MassgeBox_Shown(object sender, EventArgs e)
        {
            MakeButtonCircular(btnCircle); // เรียกที่นี่เพื่อให้แน่ใจว่าปุ่มมีขนาดแล้ว
        }

        private void MakeFormRounded(int radius = 20)
        {
            Rectangle bounds = this.ClientRectangle;
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90); // Top-left
            path.AddArc(new Rectangle(bounds.Width - radius, 0, radius, radius), 270, 90); // Top-right
            path.AddArc(new Rectangle(bounds.Width - radius, bounds.Height - radius, radius, radius), 0, 90); // Bottom-right
            path.AddArc(new Rectangle(0, bounds.Height - radius, radius, radius), 90, 90); // Bottom-left
            path.CloseFigure();

            this.Region = new Region(path);
        }

        private void MakeButtonCircular(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
