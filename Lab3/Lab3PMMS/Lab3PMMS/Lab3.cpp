#include<glut.h>

BOOL    keys[256];     

GLfloat angl = 0.0;
GLfloat moveRight = 0.0;
GLfloat moveUp = 0.0;
GLfloat temp = 0.0001;

void display() 
{ 
glClear(GL_COLOR_BUFFER_BIT); 
glLoadIdentity(); 
glColor3f(0, 1, 1);

glFlush();
}

void redraw()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glLoadIdentity();
	glColor3f(0, 1, 1);

	double tr1A = -0.6f;
	double tr2A = -0.8f;

	double tr1B = -0.3f;
	double tr2B = -0.2f;

	double tr1C = -0.0f;
	double tr2C = -0.8f;

	double tr1D =  0.2f;
	double tr2D = -0.6f;


	double trMid1 = (tr1A + tr1B + tr1C) / 3;
	double trMid2 = (tr2A + tr2B + tr2C) / 3;
	glPushMatrix();

	glTranslated(moveRight, moveUp, 0.0f);

	glTranslatef(-0.4f-temp, -0.4f - temp, -1);
	glRotatef(angl, 0.0f, 0.0f, -1.0f);
	glTranslatef(0.4f+temp, 0.4f+temp, 1);

	
	
	//glScaled(1, 0.1, 1);
	//glTranslatef(0.1f, 0.0f, -6.0f);
	
	glBegin(GL_TRIANGLE_FAN);
	glColor3f(0.0f, 1.0f, 0.0f); // Green
	glVertex2f(tr1B, tr2B);
	glColor3f(1.0f, 0.0f, 0.0f); // Red
	glVertex2f(tr1A, tr2A);
	glColor3f(0.0f, 0.0f, 1.0f); // Blue
	glVertex2f(tr1C, tr2C);

	glColor3f(0.0f, 0.0f, 0.0f); // Blue
	glVertex2f(tr1D, tr2D);

	glEnd();

	int up = moveUp*10;
	
	if (up == 15) {

		temp = -0.0001;
	}
	if (up == -5) {

		temp = 0.0001;
	}

		moveRight += temp;
		moveUp += temp;
		angl += 0.01;
	
	glPopMatrix();

	glFlush();
}


int main(int argc, char **argv)
{

glutInit(&argc, argv); 
glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
glutInitWindowSize(720, 480);
glutInitWindowPosition(100, 143);
glutCreateWindow("Lab3");

glClearColor(0.0, 0.0, 0.0, 0.0);
glMatrixMode(GL_PROJECTION);
glLoadIdentity();
glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0); 

glutDisplayFunc(display);

glutIdleFunc(redraw);

glutMainLoop(); 

}
