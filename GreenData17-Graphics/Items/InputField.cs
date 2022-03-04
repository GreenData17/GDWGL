using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL.Items
{
    public class InputField : DrawItem
    {
        public string text = "";
        public string tempText = "|";
        public string placeholder = "Text here...";

        public string FontFamilyName = "Arial";
        public int TextSize = 12;

        public int selectorCounter = 0;
        public bool selectorShowing;

        public InputField()
        {
            name = "New Button";
        }

        public InputField(Vector2 Position, Vector2 Size)
        {
            this.Position = Position;
            this.Size = Size;
            Setup();
        }

        public override void Update(Graphics g)
        {
            base.Update(g);

            if(WGL.s_currentKeyInfo.KeyCode.ToString() != "None")
                text += WGL.s_currentKeyInfo.KeyCode;


            if (selectorCounter == 100) { tempText = text + "|"; selectorShowing = true; }
            else if(selectorCounter >= 200) { selectorCounter = 0; selectorShowing = false; }
            else { selectorCounter++; }

            g.FillRectangle(new SolidBrush(BackgroundColor), Position.X, Position.Y, Size.X, Size.Y);
            if (selectorShowing)
                g.DrawString(tempText, new Font(FontFamilyName, TextSize), new SolidBrush(ForeGroundColor), Position.X + 2, Position.Y + 2);
            else
                g.DrawString(text, new Font(FontFamilyName, TextSize), new SolidBrush(ForeGroundColor), Position.X + 2, Position.Y + 2);
        }
    }
}
