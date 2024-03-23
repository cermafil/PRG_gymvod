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
        Point corner1;
        Point corner2;
        bool pen_is = false;
        bool shenanigans1 = false;
        bool shenanigans2 = false;
        bool gay = false;
        bool ellipse = false;
        bool rectangle = false;
        bool ellipse_fill = false;
        bool rectangle_fill = false;
        bool rubber = false;
        bool rubber2 = false;   
        public Form1()
        {
            
            InitializeComponent();

            
            // Set the default selection
            comboBox1.SelectedIndex = 0;
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
            

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            corner1 = e.Location;
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
                    else if (shenanigans1)
                    {

                        int a = rnd.Next(0, 2000);
                        int b = rnd.Next(0, 2000);
                        Point randPoint = new Point(a, b);
                        g.DrawLine(pen, previousPoint, randPoint);
                    }
                    else if (shenanigans2)
                    {
<<<<<<< HEAD
                        for (int i = 0; i < 50; i++)
=======
                        for(int i = 0; i < 50; i++)
>>>>>>> 6c5b0e663fd924fef48b366da0429664a748d627
                        {
                            Point point = currentPoint;
                            int x = previousPoint.X;
                            int y = previousPoint.Y;
<<<<<<< HEAD
                            int a = rnd.Next(x - size * 8, x + size * 8);
                            int b = rnd.Next(y - size * 8, y + size * 8);
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                            pen.Color = randomColor;

=======
                            int a = rnd.Next(x - size*8, x+size*8);
                            int b = rnd.Next(y- size*8, y + size*8);
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            
                            pen.Color = randomColor;
                            
>>>>>>> 6c5b0e663fd924fef48b366da0429664a748d627
                            pen.Width = 5;
                            g.DrawEllipse(pen, a, b, 5, 5);
                        }
                    }
                    else if (gay)
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

        

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            size = trackBar1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pen_is = false;
            shenanigans1 = false;
            shenanigans2 = false;
            gay = false;
            ellipse = false;
            rectangle = false;
            rubber = false;
            rubber2 = false;
            switch (comboBox1.SelectedIndex)
            {
<<<<<<< HEAD
                case 0:
                    pen_is = true;
                    break;
                case 1:
                    shenanigans1 = true;
                    break;
                case 2:
                    shenanigans2 = true;
                    break;
                case 3:
                    gay = true;
                    break;
                case 4:
                    pen_is = true;
                    rubber = true;
                    brush = Brushes.White;
                    break;
                case 5:
                    ellipse = true;
                    break;
                case 6:
                    ellipse_fill = true;
                    break;

                case 7:
                    rectangle = true;
                    break;
                case 8:
                    rectangle_fill = true;
                    break;
                case 9:
                    rubber2 = true;
                    pen_is = true;
                    brush = Brushes.Pink;
                    this.TransparencyKey = Color.Pink;
                    break;
                default:
                    
                    break;
            }

=======
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
            
            
>>>>>>> 6c5b0e663fd924fef48b366da0429664a748d627
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(Brushes.White, 0, 0, 2000, 2000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Green;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Blue;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Black;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Cyan;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Orange;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Yellow;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Purple;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(brush, size);
            corner2 = e.Location;
            if (ellipse)
            {
                Graphics g = this.CreateGraphics();
                //ellipses are gigachads
                g.DrawEllipse(pen, corner1.X, corner1.Y, corner2.X - corner1.X, corner2.Y - corner1.Y);
            }
            else if(ellipse_fill)
            {
                Graphics g = this.CreateGraphics();
                g.FillEllipse(brush, corner1.X, corner1.Y, corner2.X - corner1.X, corner2.Y - corner1.Y);
            }
            else if (rectangle_fill)
            {
                Graphics g = this.CreateGraphics();

                
                int x = Math.Min(corner1.X, corner2.X);
                int y = Math.Min(corner1.Y, corner2.Y);
                int width = Math.Abs(corner2.X - corner1.X);
                int height = Math.Abs(corner2.Y - corner1.Y);
                g.FillRectangle(brush, x, y, width, height);

            }
            else if (rectangle)
            {
             Graphics g = this.CreateGraphics();

             //since rectangle was being a little bitch and doesn't work with negative values I had to give him training wheels...
             int x = Math.Min(corner1.X, corner2.X);
             int y = Math.Min(corner1.Y, corner2.Y);
             int width = Math.Abs(corner2.X - corner1.X);
             int height = Math.Abs(corner2.Y - corner1.Y);
             g.DrawRectangle(pen, x, y, width, height);

            }
        }
    }
}