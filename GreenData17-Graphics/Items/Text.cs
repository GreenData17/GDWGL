using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL.Items
{
    public class Text : DrawItem
    {
        public string text = "Text";
        public int TextSize = 12;
        public string FontFamiliyName = "Arial";

        public Text()
        {
            name = "New Button";
        }

        public Text(Vector2 Position)
        {
            this.Position = Position;
            this.Size = Vector2.Zero();
            Setup();
        }

        public override void Update(Graphics g)
        {
            base.Update(g);
            g.DrawString(text, new Font(FontFamiliyName, TextSize), new SolidBrush(ForeGroundColor), Position.X, Position.Y);
        }
    }
}
