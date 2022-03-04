using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDWGL;
using GDWGL.Items;
using Button = GDWGL.Items.Button;

namespace TestApp
{
    public class Main : WGL
    {
        public Main() : base("Test App", new Vector2(1080, 720), true) { }

        Button ExitButton;
        Button ChangeTitleButton;
        Text TitleText;
        InputField field;

        public override void OnLoad()
        {
            ClearColor = Color.CornflowerBlue;

            ExitButton = new Button(new Vector2(10, 50), new Vector2(100, 30));
            ExitButton.text = "Exit";
            ExitButton.pressedColor = Color.Red;
            ExitButton.MouseDown += ExitButton_MouseDown;

            ChangeTitleButton = new Button(new Vector2(10, 90), new Vector2(100, 30));
            ChangeTitleButton.text = "Change!";
            ChangeTitleButton.MouseUp += ChangeTitleButton_MouseDown;

            TitleText = new Text(new Vector2(10, 10));
            TitleText.text = "Hello World!";
            TitleText.TextSize = 20;

            field = new InputField(new Vector2(10, 130), new Vector2(100, 30));
        }

        private void ChangeTitleButton_MouseDown(object sender, EventArgs e)
        {
            if(MouseState == MouseButtons.Left)
                TitleText.text = "Hello App!";
        }

        private void ExitButton_MouseDown(object sender, EventArgs e)
        {
            Exit();
        }

        public override void OnUpdate()
        {

            base.OnUpdate();
        }
    }
}
