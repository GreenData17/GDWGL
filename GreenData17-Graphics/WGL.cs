using GDWGL.Items;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GDWGL
{
    public class WGL
    {
        // Window Vars
        public string title = "New Window";
        public Vector2 size = new Vector2(512, 512);

        public static Window s_window = null;
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

            s_window = new Window(m_doubleBuffered)
            {
                Text = title,
                Size = size.ToSize(),
                FormBorderStyle = FormBorderStyle.FixedSingle,
            };

            s_window.Paint += Renderer;
            s_window.FormClosing += OnWindowClosing;
            s_window.KeyDown += M_window_KeyDown;
            s_window.KeyUp += M_window_KeyUp;
            s_window.MouseDown += M_window_MouseDown; ;
            s_window.MouseUp += M_window_MouseUp;
            s_window.MouseMove += M_window_MouseMove;

            m_Loop = new Thread(Loop);
            m_Loop.Start();

            Debug.LogInfo("Initialized!");
            Debug.LogInfo("Window Opened!");
            Application.Run(s_window);
        }

        private void Loop()
        {
            OnLoad();
            while (m_Loop.IsAlive)
            {
                try
                {
                    s_window.BeginInvoke((MethodInvoker)delegate { s_window.Refresh(); });
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
            s_window.Close();
        }


        // -- Window Events --

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(ClearColor);
            foreach(DrawItem item in items)
            {
                if(!item.hidden)
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
        public static Window GetWindow()
        {
            return s_window;
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
