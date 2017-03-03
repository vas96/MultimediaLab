using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
#pragma warning disable CS0105 // Using directive appeared previously in this namespace
using Tao.FreeGlut;
using System.Threading;
#pragma warning restore CS0105 // Using directive appeared previously in this namespace

namespace WindowsGlTest1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit(); 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE); 
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, anT.Width, anT.Height); 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity(); 

          //  if (anT.Width <= anT.Height)
           //     Glu.gluOrtho2D(-50, anT.Width, -50, 50.0 * (float)anT.Height / (float)anT.Width);
           // else
           //     Glu.gluOrtho2D(-50, 50.0 * (float)anT.Width / (float)anT.Height, -50, 50.0);


            double aspect = anT.Width / (anT.Height);
            if (anT.Width >= anT.Height)
            {
                Glu.gluOrtho2D(-50.0* aspect, 50.0* aspect, -50.0, 50.0);
            }
            else
            {
                Glu.gluOrtho2D(-50.0, 50.0, -50.0/ aspect, 50.0/ aspect);
            }

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }


        Random rnd = new Random();
        Random MyColor = new Random();
        List<Point> points = new List<Point>();
        int count;

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);


            for (int i = 0; i < numericUpDown1.Value; i++)
            {
               Draw(rnd.Next(-50, 50), rnd.Next(-100, 100));

            //    Thread.Sleep(2000);
            }
             count = (int)numericUpDown1.Value-1;
        }



        private void button2_Click(object sender, EventArgs e)
        {
             Application.Exit();
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
           // anT.Invalidate();
        }


        
        private void button3_Click(object sender, EventArgs e)
        {
         //   points.RemoveAt(count);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            count--;

           /// Destroy(count);
            if (count >= 0) { Destroy(); }
    
            if (count == -1)
            {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                anT.Invalidate();
                MessageBox.Show("All elements destroy");
            }
          
        }

        private void Destroy()
        {
         
            for (int i=0; i <= count; i++)
            {
                Draw(points[i].X, points[i].Y);
            }
               
   //         for (int j = points.Count - 1; j >= count; j--)
  //         {
//                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

                //for (int i = j; i >= 0; i--)
                //{
                 //   Draw(points[i].X, points[i].Y);
                //}
              //  Thread.Sleep(2);
            //}
            anT.Invalidate();
            if (count == -1) { points.Clear(); }
          //  points.Clear();
        }


        static void text(string c)
        {
            for (int i = 0; i < c.Length; i++)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_TIMES_ROMAN_24, c[i]);
            }
        }


        private void Draw(int one, int two)
        {

             points.Add(new Point(one, two));

            float a = (float)MyColor.Next(0, 256) / 255;
            float b = (float)MyColor.Next(0, 256) / 255;
            float c = (float)MyColor.Next(0, 256) / 255;
            //   Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3d(a, b, c);

            Gl.glVertex2d(one, one);

            Gl.glColor3d(a, b, c);

            Gl.glVertex2d(two, one);

            Gl.glColor3d(a, b, c);

            Gl.glVertex2d(one, two);


            Gl.glEnd();

            Gl.glFlush();

            Gl.glColor3d(b, a, c);
            Gl.glRasterPos3f(one-2, one-2, 0);    
            text("R=" + a*255 + ";");
            text("G=" + b * 255 + ";");
            text("B=" + c*255 + ";");

            anT.Invalidate();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
