using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Timer timer;
        public bool mouseDown = false;
        Brush brush = Brushes.Black;
        int size = 5;
        Point previousPoint;
        bool pen_is = false;
        bool shenanigans1 = false;
        bool shenanigans2 = false;
        bool gay = false;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            previousPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            if (mouseDown)
            {
                Point currentPoint = e.Location;
                using (Graphics g = this.CreateGraphics())
                {
                    Pen pen = new Pen(brush, size);
                    if (pen_is)
                    {
                        
                        g.DrawLine(pen, previousPoint, currentPoint);
                        
                    }
                    else if(shenanigans1)
                    {
                        
                        int a = rnd.Next(0, 2000);
                        int b = rnd.Next(0, 2000);
                        Point randPoint = new Point(a, b);
                        g.DrawLine(pen, previousPoint, randPoint);
                    }
                    else if(shenanigans2)
                    {
                        for(int i = 0; i < 50; i++)
                        {
                            Point point = currentPoint;
                            int x = previousPoint.X;
                            int y = previousPoint.Y;
                            int a = rnd.Next(x - size*8, x+size*8);
                            int b = rnd.Next(y- size*8, y + size*8);
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            
                            pen.Color = randomColor;
                            
                            pen.Width = 5;
                            g.DrawEllipse(pen, a, b, 5, 5);
                        }
                    }
                    else if(gay)
                    {
                        
                        Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        pen.Color = randomColor;


                        // Start the timer
                        
                        g.DrawLine(pen, previousPoint, currentPoint);
                    }
                            
                    previousPoint = currentPoint;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    

    private void Form1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brush = Brushes.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            brush = Brushes.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            brush = Brushes.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            brush = Brushes.Black;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            size = trackBar1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                pen_is = true;
                shenanigans1 = false;
                shenanigans2 = false;
                gay = false;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                shenanigans1 = true;
                pen_is = false;
                shenanigans2 = false;
                gay = false;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                shenanigans2 = true;
                shenanigans1 = false;
                pen_is = false;
                gay = false;
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                shenanigans1 = false;
                shenanigans2 = false;
                pen_is = false;
                gay = true;
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(brush, 0, 0, 2000, 2000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            brush = Brushes.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            brush = Brushes.Orange;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            brush = Brushes.Yellow;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            brush = Brushes.Purple;
        }
    }
}
