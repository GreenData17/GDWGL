using System;
using System.IO;
using rImage = System.Drawing.Image;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDWGL.Items
{
    public class Image : DrawItem
    {
        rImage image;

        public Image(Vector2 Position, Vector2 Size)
        {
            name = "new Image";
            this.Position = Position;
            this.Size = Size;

            Setup();
        }

        public Image(Vector2 Position, Vector2 Size, string filePath)
        {
            name = "new Image";
            this.Position = Position;
            this.Size = Size;

            if(File.Exists(Application.StartupPath + @"\assets\" + filePath))
                image = rImage.FromFile(Application.StartupPath + @"\assets\" + filePath);

            Setup();
        }

        public Image(Vector2 Position, Vector2 Size, rImage image)
        {
            name = "new Image";
            this.Position = Position;
            this.Size = Size;

            this.image = image;
            Setup();
        }

        public override void Update(System.Drawing.Graphics g)
        {
            base.Update(g);

            if(image == null)
                image = rImage.FromFile(Application.StartupPath + @"\assets\NotFound.png");

            g.DrawImage(image, Position.X, Position.Y, Size.X, Size.Y);
        }
    }
}
