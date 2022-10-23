using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace Chidesa
{
    class SimpleWindow : GameWindow
    {
        public float A = 0;
        public float B = 0.5f;
        public float C = -0.5f;
        public float D = -0.5f;
        public float E = 0.5f;
        public float F = -0.5f;

        //Numepad8 => Sus
        //Numepad2 => Jos
        //NumePad6 => Dreapta
        //Numepad4 => Stanga

        public SimpleWindow() : base(1024, 768)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            if (e.Key == Key.Keypad8)
                Sus();

            if (e.Key == Key.Keypad2)
                Jos();

            if (e.Key == Key.Keypad6)
                Dreapta();

            if (e.Key == Key.Keypad4)
                Stanga();

        }

        private void Sus()
        {
            if (B < 3.9f)
            {
                B += 0.1f;
                D += 0.1f;
                F += 0.1f;
            }
        }

        private void Jos()
        {
            if (B > -2.9f)
            {
                B += -0.1f;
                D += -0.1f;
                F += -0.1f;
            }
        }

        private void Dreapta()
        {
            if (E < 3.9f)
            {
                A += 0.1f;
                C += 0.1f;
                E += 0.1f;
            }
        }

        private void Stanga()
        {
            if (C > -3.9f)
            {
                A += -0.1f;
                C += -0.1f;
                E += -0.1f;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.LightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-4.0, 4.0, -4.0, 4.0, 0.0, 6.0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            DeseneazaTriunghi();

            this.SwapBuffers();
        }

        private void DeseneazaTriunghi()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.IndianRed);
            GL.Vertex2(A, B);
            GL.Color3(Color.GreenYellow);
            GL.Vertex2(C, D);
            GL.Color3(Color.Black);
            GL.Vertex2(E, F);

            GL.End();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}

/// Chidesa Catalin Andrei  
/// Gr. 3131A