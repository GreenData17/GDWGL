using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL.Items
{
    public class InputDebug : DrawItem
    {
        Text MouseState;
        Text KeyState;

        public InputDebug()
        {
            name = "New DebugText";
            MouseState = new Text(new Vector2(WGL.s_window.Width - 300, WGL.s_window.Height - 100));

            KeyState = new Text(new Vector2(WGL.s_window.Width - 300, WGL.s_window.Height - 70));
            Setup();
        }

        public override void Update(Graphics g)
        {
            base.Update(g);

            MouseState.text = "MouseState: " + WGL.MouseState.ToString();
            KeyState.text = "KeyState: " + WGL.s_currentKeyInfo.KeyCode;
        }
    }
}
