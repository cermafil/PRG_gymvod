using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

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
        bool ellipseFill = false;
        bool rectangleFill = false;
        bool rubber = false;
        bool rubber2 = false;   
        bool picture = false;
        public Form1()
        {
            
            InitializeComponent();

            
            // Set the default selection
            comboBox1.SelectedIndex = 0;
            trackBar2.Value = 100;
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

                        
                        for(int i = 0; i < 50; i++)

                        {
                            Point point = currentPoint;
                            int x = previousPoint.X;
                            int y = previousPoint.Y;

                            int a = rnd.Next(x - size * 8, x + size * 8);
                            int b = rnd.Next(y - size * 8, y + size * 8);
                            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                            pen.Color = randomColor;


                            

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

        
        //size slider
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            size = trackBar1.Value;
        }
        private void cancel()
        {
            pen_is = false;
            shenanigans1 = false;
            shenanigans2 = false;
            gay = false;
            ellipse = false;
            ellipseFill = false;
            rectangle = false;
            rectangleFill = false;
            rubber = false;
            rubber2 = false;
            bool picture = false;
        }
        //brushes combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cancel();
            switch (comboBox1.SelectedIndex)
            {

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
                    rubber2 = true;
                    pen_is = true;
                    brush = Brushes.Pink;
                    this.TransparencyKey = Color.Pink;
                    break;
                default:
                    
                    break;
            }

        }
        //didnt name by buttons and now its too late...
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(Brushes.White, 0, 0, 2000, 2000);
        }
        //red button
        private void button1_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Red;
            }
        }
        //green button
        private void button2_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Green;
            }
        }
        //blue button
        private void button3_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Blue;
            }
        }
        //black button
        private void button4_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Black;
            }
        }
        //cyan button
        private void button6_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Cyan;
            }
        }
        //orange button
        private void button7_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Orange;
            }
        }
        //yellow button
        private void button8_Click(object sender, EventArgs e)
        {
            if (!rubber & !rubber2)
            {
                brush = Brushes.Yellow;
            }
        }
        //purple button
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
            else if(ellipseFill)
            {
                Graphics g = this.CreateGraphics();
                g.FillEllipse(brush, corner1.X, corner1.Y, corner2.X - corner1.X, corner2.Y - corner1.Y);
            }
            else if (rectangleFill)
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
            else if(picture)
            {
                int x = Math.Min(corner1.X, corner2.X);
                int y = Math.Min(corner1.Y, corner2.Y);
                int width = Math.Abs(corner2.X - corner1.X);
                int height = Math.Abs(corner2.Y - corner1.Y);
                Rectangle rect = new Rectangle(x, y, width, height);    
                Graphics g = this.CreateGraphics();
                g.DrawImage(Properties.Resources.oranges, rect);
            }
        }

        private void buttonRect_Click(object sender, EventArgs e)
        {
            cancel();
            rectangle = true;
        }

        private void buttonEll_Click(object sender, EventArgs e)
        {
            cancel();
            ellipse = true;
        }

        private void buttonRectF_Click(object sender, EventArgs e)
        {
            cancel();
            rectangleFill = true;
        }

        private void buttonEllF_Click(object sender, EventArgs e)
        {
            cancel();
            ellipseFill = true;
        }
        //opacity slider
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int opacityValue = trackBar2.Value*2;
            Color color = ((SolidBrush)brush).Color; 
            Color newColor = Color.FromArgb(opacityValue, color.R, color.G, color.B); 
            brush = new SolidBrush(newColor);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            cancel();
            picture = true;
        }
    }
}