using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.AutoScaleBaseSize = new Size(6, 14);
            this.ClientSize = new Size(600, 500);
            this.comboBox1.SelectedIndex = 0;
            this.Paint += new PaintEventHandler(this.Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            drawSun(this.trackBar1.Value * 5 + 40, 100);
            drawTree(10, 300, 500, 130, -PI / 2);
        }

        private Graphics graphics;
        private const double PI = Math.PI;
        private double th1 = 30 * Math.PI / 180;
        private double th2 = 30 * Math.PI / 180;
        private double per1 = 0.65;
        private double per2 = 0.65;
        //private double per3 = 0.8;
        private Random random = new Random();
        private double perRnd = 0.1;
        private struct Point
        {
            public int x;
            public int y;
        }

        private double rnd(double a, double b)
        {
            return (b - a) * random.NextDouble() + a;
        }
        private Point RTh2xy(double r, double theta)
        {
            Point p;
            p.x = (int)(r * Math.Cos(theta * Math.PI / 180));
            p.y = (int)(r * Math.Sin(theta * Math.PI / 180));
            return p;
        }
        private void drawSun(int x, int y)
        {
            graphics.DrawEllipse(new Pen(Color.OrangeRed, 20), x, y, 20, 20);
            for (int i = 0; i < 12; i++)
            {
                Point p1 = RTh2xy(25, i * 30);
                Point p2 = RTh2xy(40, i * 30);
                graphics.DrawLine(new Pen(Color.OrangeRed, 2),
                    p1.x + x + 10, p1.y + y + 10, p2.x + x + 10, p2.y + y + 10);
            }
        }
        private void drawTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            if (leng < 5) leng = 5;
            double x1 = x0 + leng * Math.Cos(th) * rnd(1 - perRnd, 1);
            double y1 = y0 + leng * Math.Sin(th) * rnd(1 - perRnd, 1);
            double x2 = x0 + leng * Math.Cos(th) * rnd(1 - perRnd, 1);
            double y2 = y0 + leng * Math.Sin(th) * rnd(1 - perRnd, 1);
            double x3 = x0 + leng * Math.Cos(th);
            double y3 = y0 + leng * Math.Sin(th);
            double x4 = x0 + leng * Math.Cos(th + 0.3);
            double y4 = y0 + leng * Math.Sin(th + 0.3);
            double x5 = x0 + leng * Math.Cos(th - 0.3);
            double y5 = y0 + leng * Math.Sin(th - 0.3);
            if (n <= 2)
            {
                drawLine(x0, y0, x3, y3, n / 2, Color.Green);
                drawLine(x0, y0, x4, y4, n / 2, Color.Green);
                drawLine(x0, y0, x5, y5, n / 2, Color.Green);
            }
            else if (n <= 4)
            {
                drawLine(x0, y0, x3, y3, n / 2, Color.Green);
            }
            else
            {
                drawLine(x0, y0, x3, y3, n / 2, Color.SaddleBrown);
            }
            drawTree(n - 1, x2, y2, per2 * leng * rnd(1 - perRnd, 1 + perRnd), th - th2 + rnd(-perRnd/2, perRnd));
            drawTree(n - 1, x1, y1, per1 * leng * rnd(1 - perRnd, 1 + perRnd), th + th1 + rnd(-perRnd, perRnd/2));
        }
        private void drawLine(double x0, double y0, double x1, double y1, int width, Color col)
        {
            graphics.DrawLine(new Pen(col, width), (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.per1 = 0.65 + (this.trackBar1.Value - 50) * 0.003;
            this.per2 = 0.65 - (this.trackBar1.Value - 50) * 0.003;
            this.th1 = 30 * Math.PI / 180 + (this.trackBar1.Value - 50) * 0.1 * Math.PI / 180;
            this.th2 = 30 * Math.PI / 180 - (this.trackBar1.Value - 50) * 0.1 * Math.PI / 180;
            this.label1.Text = this.trackBar1.Value.ToString();
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            perRnd = (this.comboBox1.SelectedIndex + 1) * 0.1;
            this.Invalidate();
        }
    }
}





 
