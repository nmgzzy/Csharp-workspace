using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsPractice
{
    public partial class Form1 : Form
    {
        private int mode = 0;
        private const int modemax = 6;
        public Form1()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Text = DateTime.Now.ToLongDateString();
        }

        private int fromString(string s)
        {
            return (int)(Convert.ToInt32(s, 16) | 0xff000000);
        }
        private PointF fromRtheta(PointF start, float r, float theta)
        {
            PointF pf = new PointF();
            pf.X = start.X + r * (float)Math.Sin(theta * Math.PI / 180);
            pf.Y = start.Y - r * (float)Math.Cos(theta * Math.PI / 180);
            return pf;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            PointF lefttop = new PointF(0, 0);
            float len = Math.Min(this.panel1.Size.Width, this.panel1.Size.Height);
            PointF pcenter = new PointF(len / 2, len / 2);
            SizeF size = new SizeF(len, len);
            RectangleF rect = new RectangleF(lefttop, size);
            Color[] colors = {
                Color.FromArgb(fromString("f7797d")),
                Color.FromArgb(fromString("c6ffdd")),
                Color.FromArgb(fromString("12c2e9")),
                Color.FromArgb(fromString("f64f59")),
                Color.FromArgb(fromString("96c93d")),
                Color.FromArgb(fromString("00b09b")),
                Color.FromArgb(fromString("7f7fd5")),
                Color.FromArgb(fromString("91eae4")),
                Color.FromArgb(fromString("544a7d")),
                Color.FromArgb(fromString("ffd452")),
                Color.FromArgb(fromString("a8ff78")),
                Color.FromArgb(fromString("78ffd6"))
            };
            DateTime dt = DateTime.Now;
            Random rnd = new Random();
            Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);
            Graphics g = Graphics.FromImage(bmp);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = colors[mode*2];
            Color[] surroundColors = { colors[mode * 2 + 1] };
            pthGrBrush.SurroundColors = surroundColors;

            Pen Phour = new Pen(Color.Black, 6);
            Pen Pmin = new Pen(Color.Black, 4);
            Pen Psec = new Pen(Color.Black, 2);
            g.FillEllipse(pthGrBrush, rect);

            int fontSize = (int)(len / 30);
            PointF Pstr;
            PointF PstrCenter = new PointF(pcenter.X - fontSize, pcenter.Y - 2 * fontSize);
            SolidBrush brush = new SolidBrush(Color.Black);
            for (int i = 1; i <= 12; i++)
            {
                Pstr = fromRtheta(PstrCenter, len / 2 * 0.87f, i > 9 ? i * 30 - 4 : i * 30);
                g.DrawString(i.ToString(), new Font("微软雅黑", fontSize), brush, Pstr);
            }
            
            g.DrawLine(Phour, pcenter, fromRtheta(pcenter, len / 2 * 0.55f, (dt.Hour % 12) * 30 + dt.Minute / 2f));
            g.DrawLine(Pmin, pcenter, fromRtheta(pcenter, len / 2 * 0.65f, dt.Minute * 6f));
            g.DrawLine(Psec, pcenter, fromRtheta(pcenter, len / 2 * 0.75f, dt.Second * 6f));
            e.Graphics.DrawImage(bmp, 0, 0);

            Phour.Dispose();
            Pmin.Dispose();
            Psec.Dispose();
            brush.Dispose();
            path.Dispose();
            bmp.Dispose();
            pthGrBrush.Dispose();
            g.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            mode = (mode + 1) % modemax;
        }
    }
}
