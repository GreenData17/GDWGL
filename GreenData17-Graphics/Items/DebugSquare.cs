using System.Drawing;

namespace GDWGL.Items
{
    public class DebugSquare : DrawItem
    {
        public DebugSquare()
        {
            name = "New DebugSquare";
        }

        public DebugSquare(Vector2 Position, Vector2 Size)
        {
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
