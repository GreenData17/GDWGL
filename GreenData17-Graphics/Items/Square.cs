using System.Drawing;

namespace GDWGL.Items
{
    public class Square : DrawItem
    {
        public Square()
        {
            name = "New DebugSquare";
        }

        public Square(Vector2 Position, Vector2 Size)
        {
            name = "New DebugSquare";
            this.Position = Position;
            this.Size = Size;
            BackgroundColor = Color.Red;
            Setup();
        }

        public override void Update(Graphics g)
        {
            base.Update(g);
            g.FillRectangle(new SolidBrush(BackgroundColor), Position.X, Position.Y, Size.X, Size.Y);
        }
    }
}
