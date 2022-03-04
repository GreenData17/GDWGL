using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL.Items
{
    public class DrawItem
    {
        // meta data
        public string name = "%default%";
        public Vector2 Position = Vector2.Zero();
        public Vector2 Size = Vector2.One();

        // Looks
        public Color BackgroundColor = Color.White;
        public Color ForeGroundColor = Color.Black;

        // States
        public bool hovering = false;
        public bool mouseDown = false;

        // Events
        public event EventHandler MouseDown;
        public event EventHandler MouseUp;

        public void Setup()
        {
            WGL.items.Add(this);
            Debug.Log($"\"{name}\" created!");
        }

        public void Delete()
        {
            WGL.items.Remove(this);
            Debug.Log($"\"{name}\" Deleted!");
        }

        public virtual void Update(Graphics g) 
        {
            if (MouseHoveringItem())
            {
                hovering = true;
            }
            else
            {
                hovering = false;
            }

            if (MouseHoveringItem() && WGL.MouseState == System.Windows.Forms.MouseButtons.Left)
            {
                OnMouseDown(new EventArgs());
                mouseDown = true;
            }
            if (MouseHoveringItem() && WGL.MouseState == System.Windows.Forms.MouseButtons.None)
            {
                OnMouseUp(new EventArgs());
                mouseDown = false;
            }
        }

        // private functions
        bool MouseHoveringItem()
        {
            if(WGL.MousePosition > Position && WGL.MousePosition < (Position + Size))
            {
                return true;
            }
            return false;
        }

        // Events
        protected virtual void OnMouseDown(EventArgs e)
        {
            EventHandler handler = MouseDown;
            handler?.Invoke(this, e);
        }
        protected virtual void OnMouseUp(EventArgs e)
        {
            EventHandler handler = MouseUp;
            handler?.Invoke(this, e);
        }
    }
}
