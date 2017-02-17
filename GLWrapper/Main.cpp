#pragma comment(lib, "opengl32.lib")
#pragma comment(lib, "glu32.lib")
#pragma comment(lib, "user32.lib")
#pragma comment(lib, "gdi32.lib")

#include <Windows.h>
#include <gl/GL.h>
#include <gl/GLU.h>
#include <math.h>
#define PI 3.14159

namespace GLWrapper {
	using namespace System;

	public ref class Renderer {
	public:
		// intialize
		Renderer(IntPtr windowHandle) {
			// nullify everything first to avoid illegal usage
			hwnd = NULL;
			hdc = NULL;
			hglrc = NULL;

			hwnd = (HWND)windowHandle.ToPointer();

			// get the drawing context of the window
			hdc = GetDC(hwnd);

			// set up rendering context
			PIXELFORMATDESCRIPTOR pfd = { 0 };
			pfd.nSize = sizeof(PIXELFORMATDESCRIPTOR);
			pfd.nVersion = 1; // always 1
			pfd.cColorBits = 32; // just some commonly 
			pfd.cDepthBits = 24; // seen parameters
			pfd.cStencilBits = 8;
			pfd.iLayerType = PFD_MAIN_PLANE;
			pfd.dwFlags = PFD_DOUBLEBUFFER |
				PFD_SUPPORT_OPENGL |
				PFD_DRAW_TO_WINDOW;
			pfd.iPixelType = PFD_TYPE_RGBA;

			SetPixelFormat(hdc, ChoosePixelFormat(hdc, &pfd),
				&pfd);

			hglrc = wglCreateContext(hdc);
			if (!hglrc)
				throw gcnew Exception(
					"Cannot create rendering context");

			latitude = PI / 4;
			longitude = 0;
		}

		/////////////////////////////////////////////////////////////
		// the Dispose function
		~Renderer() {
			// call the finalizer
			this->!Renderer();
		}

		/////////////////////////////////////////////////////////////
		// main rendering method
		void Draw() {
			// make the rendering context current
			wglMakeCurrent(hdc, hglrc);

			glEnable(GL_DEPTH_TEST);
			glDisable(GL_LIGHTING);

			// get the size of client
			RECT rect;
			GetClientRect(hwnd, &rect);
			glViewport(rect.left, rect.top,
				rect.right, rect.bottom);

			glClearColor(0, 0, 0, 0);
			glClear(GL_COLOR_BUFFER_BIT |
				GL_DEPTH_BUFFER_BIT);

			// set up perspective projection
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			gluPerspective(45.0f, (double)rect.right / rect.bottom,
				0.1, 1000.0);

			// precalculate some values
			double clat, clong, slat, slong;
			clat = cos(latitude);
			clong = cos(longitude);
			slat = sin(latitude);
			slong = sin(longitude);

			// set up camera
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();
			gluLookAt(10 * clat*clong, 10 * slat, 10 * clat*slong,
				0, 0, 0,
				0, 1, 0);

			// draw the cube
			glBegin(GL_QUADS);
			// top/bottom face
			glColor3d(1, 0, 0);
			glVertex3d(-1, 1, -1);
			glVertex3d(1, 1, -1);
			glVertex3d(1, 1, 1);
			glVertex3d(-1, 1, 1);

			glVertex3d(-1, -1, 1);
			glVertex3d(1, -1, 1);
			glVertex3d(1, -1, -1);
			glVertex3d(-1, -1, -1);

			// left/right face
			glColor3d(0, 1, 0);
			glVertex3d(-1, 1, -1);
			glVertex3d(-1, 1, 1);
			glVertex3d(-1, -1, 1);
			glVertex3d(-1, -1, -1);

			glVertex3d(1, -1, -1);
			glVertex3d(1, -1, 1);
			glVertex3d(1, 1, 1);
			glVertex3d(1, 1, -1);

			// front/back face
			glColor3d(0, 0, 1);
			glVertex3d(-1, 1, 1);
			glVertex3d(1, 1, 1);
			glVertex3d(1, -1, 1);
			glVertex3d(-1, -1, 1);

			glVertex3d(-1, -1, -1);
			glVertex3d(1, -1, -1);
			glVertex3d(1, 1, -1);
			glVertex3d(-1, 1, -1);
			glEnd();

			glFlush();
			SwapBuffers(hdc);

			wglMakeCurrent(hdc, NULL);
		}

		/////////////////////////////////////////////////////////////
		property double Latitude {
			double get() { return latitude; }
			void set(double v) { latitude = v; }
		}

		property double Longitude {
			double get() { return longitude; }
			void set(double v) { longitude = v; }
		}
		/////////////////////////////////////////////////////////////

	private:
		// finalizer
		!Renderer() {
			wglDeleteContext(hglrc);
			hglrc = NULL;

			ReleaseDC(hwnd, hdc);
			hwnd = NULL;
			hdc = NULL;
		}

		/////////////////////////////////////////////////////////////
		// fields
		HDC hdc;
		HWND hwnd;
		HGLRC hglrc;

		double latitude;
		double longitude;
	};
}