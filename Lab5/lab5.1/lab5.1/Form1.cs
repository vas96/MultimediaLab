using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace lab5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            anTvas.InitializeContexts();
        }


        private int angl = 0;
        private int anglCloud = 361;
        private bool textureIsLoad = false;

        public string texture_name = "";
        public int imageIdEarth = 0;
        public int imageIdBackTexture = 1;
        public int imageIdCloudTexture = 2;

        public uint mGlTextureObjectEarth = 0;
        public uint mGlTextureObjectBack = 1;
        public uint mGlTextureObjectCloud = 2;

        private void Form1_Load(object sender, EventArgs e)
        { Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            //Devil
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, anTvas.Width, anTvas.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            Glu.gluPerspective(30, anTvas.Width / anTvas.Height, 1, 100);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            timerMove.Start();

            EarthTexture();
            BackTexture();
            CloudTexture();
        }

        void EarthTexture()
        {
            {
                Il.ilGenImages(1, out imageIdEarth);

                Il.ilBindImage(imageIdEarth);

                if (Il.ilLoadImage(System.IO.Path.GetFullPath(@"Images\earth.jpg")))
                {

                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp)
                    {
                        case 24:
                            mGlTextureObjectEarth = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObjectEarth = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    textureIsLoad = true;

                    Il.ilDeleteImages(1, ref imageIdEarth);
                }
            }
        }

        void BackTexture()
        {
            {
                Il.ilGenImages(1, out imageIdBackTexture);

                Il.ilBindImage(imageIdBackTexture);

                if (Il.ilLoadImage(System.IO.Path.GetFullPath(@"Images\tumblr_static_outer-space-hd-wallpaper.jpg")))
                {

                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp)
                    {
                        case 24:
                            mGlTextureObjectBack = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObjectBack = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    textureIsLoad = true;

                    Il.ilDeleteImages(1, ref imageIdEarth);
                }
            }
        }

        void CloudTexture()
        {
            {
                Il.ilGenImages(1, out imageIdCloudTexture);

                Il.ilBindImage(imageIdCloudTexture);

                if (Il.ilLoadImage((System.IO.Path.GetFullPath(@"Images\p1Jf722.png"))))
                {

                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp)
                    {
                        case 24:
                          //  mGlTextureObjectCloud = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            mGlTextureObjectCloud = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObjectCloud = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    textureIsLoad = true;

                    Il.ilDeleteImages(1, ref imageIdEarth);
                }
            }
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            switch (Format)
            {
                case Gl.GL_RGB:
                     Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            return texObject;
        }


        private void DrawEarthAndBackground()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();

            if (textureIsLoad)
            {
                angl++;
                anglCloud--;
                if (angl > 361)
                    angl = 0;

                if (anglCloud > 0)
                    anglCloud = 361;

                #region Fon
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjectBack);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -1, -5);
                Gl.glBegin(Gl.GL_QUADS);

                Gl.glTexCoord2f(0, 0);
                Gl.glVertex3f(-1.33f, 2.33f, 0.0f);

                Gl.glTexCoord2f(0, 1);
                Gl.glVertex3f(-1.33f, -0.5f, 0.0f);

                Gl.glTexCoord2f(1, 0);
                Gl.glVertex3f(1.33f, -0.5f, 0.0f);

                Gl.glTexCoord2f(1, 1);
                Gl.glVertex3f(1.33f, 2.33f, 0.0f);
               
                Gl.glEnd();
                Gl.glPopMatrix();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                #endregion

           
                #region Cloud
       
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjectCloud);
               

                Gl.glEnable(Gl.GL_ALPHA_TEST);
                Gl.glAlphaFunc(Gl.GL_GREATER, 0.66f);
            //    Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ZERO);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -0, -4);
                Gl.glRotated(-90, 1, 0, 0);
                Gl.glRotated(angl, 0, 0, 1);

                Glu.GLUquadric quadr2;
                quadr2 = Glu.gluNewQuadric();
                Glu.gluQuadricTexture(quadr2, Gl.GL_TRUE);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Glu.gluSphere(quadr2, 0.7f, 32, 32);
               // Gl.glDisable(Gl.GL_BLEND);
                Gl.glDisable(Gl.GL_TEXTURE_2D);

                Gl.glDisable(Gl.GL_BLEND);
                Gl.glDisable(Gl.GL_ALPHA_TEST);

               // Gl.auxSwapBuffers();

                Gl.glPopMatrix();
       
                #endregion


                #region Earth
               
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjectEarth);
                //   Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObjectCloud);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -0, -4);
                Gl.glRotated(-90, 1, 0, 0);
                Gl.glRotated(angl, 0, 0, 1);

                Glu.GLUquadric quadr;
                quadr = Glu.gluNewQuadric();
                Glu.gluQuadricTexture(quadr, Gl.GL_TRUE);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Glu.gluSphere(quadr, 0.7f, 32, 32);

                Gl.glDisable(Gl.GL_TEXTURE_2D);

                Gl.glPopMatrix();
                #endregion

            

                anTvas.Invalidate();
            }

        }



        private void timerMove_Tick(object sender, EventArgs e)
        {
          //  Draw();
            DrawEarthAndBackground();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timerMove.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerMove.Start();
        }
    }
}
