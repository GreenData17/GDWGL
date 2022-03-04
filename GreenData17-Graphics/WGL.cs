using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GDWGL.Items;

namespace GDWGL
{
    public class WGL
    {
        // Window Vars
        public string title = "New Window";
        public Vector2 size = new Vector2(512, 512);

        private Window m_window = null;
        private bool m_doubleBuffered = false;
        private Thread m_Loop;
        public static KeyEventArgs s_currentKeyInfo = new KeyEventArgs(Keys.None);

        // States
        public static Vector2 MousePosition = new Vector2(0);
        public static MouseButtons MouseState = MouseButtons.None;

        // Config Vars
        public int UpdateFrequenzy = 10;
        public Color ClearColor = Color.White;
        public static List<object> items = new List<object>();

        // INIT
        public WGL()
        {
            Setup();
        }

        public WGL(string title, Vector2 size, bool doubleBuffered = false)
        {
            this.title = title;
            this.size = size;
            this.m_doubleBuffered = doubleBuffered;

            Setup();
        }

        private void Setup()
        {
            Debug.LogInfo("Initialize...");

            m_window = new Window(m_doubleBuffered)
            {
                Text = title,
                Size = size.ToSize(),
                FormBorderStyle = FormBorderStyle.FixedSingle,
            };

            m_window.Paint += Renderer;
            m_window.FormClosing += OnWindowClosing;
            m_window.KeyDown += M_window_KeyDown;
            m_window.KeyUp += M_window_KeyUp;
            m_window.MouseDown += M_window_MouseDown; ;
            m_window.MouseUp += M_window_MouseUp;
            m_window.MouseMove += M_window_MouseMove;

            m_Loop = new Thread(Loop);
            m_Loop.Start();

            Debug.LogInfo("Initialized!");
            Debug.LogInfo("Window Opened!");
            Application.Run(m_window);
        }

        private void Loop()
        {
            OnLoad();
            while (m_Loop.IsAlive)
            {
                try
                {
                    m_window.BeginInvoke((MethodInvoker)delegate { m_window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(UpdateFrequenzy);
                }
                catch
                {
                    Debug.LogError("Can't Update the Window!");
                }
            }
        }

        public void Exit()
        {
            m_window.Close();
        }


        // -- Window Events --

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(ClearColor);
            foreach(DrawItem item in items)
            {
                item.Update(g);
            }
        }

        private void OnWindowClosing(object sender, FormClosingEventArgs e)
        {
            OnClosing();
            m_Loop.Abort();
        }
        private void M_window_KeyUp(object sender, KeyEventArgs e)
        {
            s_currentKeyInfo = new KeyEventArgs(Keys.None);
        }
        private void M_window_KeyDown(object sender, KeyEventArgs e)
        {
            s_currentKeyInfo = e;
        }
        private void M_window_MouseUp(object sender, MouseEventArgs e)
        {
            MouseState = MouseButtons.None;
        }
        private void M_window_MouseDown(object sender, MouseEventArgs e)
        {
            MouseState = e.Button;
        }
        private void M_window_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = new Vector2(e.Location);
        }


        // -- Static Functions --

        /// <summary>
        /// Check if key is pressed.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>returns true if key is pressed.</returns>
        public static bool ReadKey(Keys key)
        {
            if (s_currentKeyInfo.KeyCode == key) return true;
            return false;
        }
        public static Vector2 DragItem(Vector2 size)
        {
            return MousePosition - (size / new Vector2(2));
        }


        // -- Override functions --

        /// <summary>
        /// Runs one time on startup. 
        /// Used for variable Initializing and to preload resources.
        /// </summary>
        public virtual void OnLoad() { }
        /// <summary>
        /// Runs every predefined milliseconds. 
        /// Set {UpdateFrequenzy} to change update speed
        /// </summary>
        public virtual void OnUpdate() { }
        /// <summary>
        /// Runs right before closing. Use it to save application state and to unload resources.
        /// </summary>
        public virtual void OnClosing() { }
    }
}
