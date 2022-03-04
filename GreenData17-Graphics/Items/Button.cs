using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL.Items
{
    public class Button : DrawItem
    {
        public Color highlightColor = Color.Gray;
        public Color pressedColor = Color.Cyan;

        public bool HasBorder = true;

        public string text = "Button";
        public string FontFamilyName = "Arial";
        public int TextSize = 12;
        public Vector2 TextOffset = new Vector2(5);

        public Button()
        {
            name = "New Button";
        }

        public Button(Vector2 Position, Vector2 Size)
        {
            this.Position = Position;
            this.Size = Size;
            BackgroundColor = Color.LightGray;
            Setup();
        }

        public override void Update(Graphics g)
        {
            base.Update(g);
            Color tempC = BackgroundColor;
            if (hovering) { tempC = highlightColor; }
            if (mouseDown) { tempC = pressedColor; }

            g.FillRectangle(new SolidBrush(tempC), Position.X, Position.Y, Size.X, Size.Y);

            tempC = pressedColor;
            if (mouseDown) tempC = highlightColor;

            g.DrawString(text, new Font(FontFamilyName, TextSize), new SolidBrush(ForeGroundColor), Position.X + TextOffset.X, Position.Y + TextOffset.Y);

            if(HasBorder)
                g.DrawRectangle(new Pen(tempC, 2), Position.X + 4, Position.Y + 4, Size.X - 7, Size.Y - 7);
        }
    }
}
