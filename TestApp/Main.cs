using GDWGL;
using GDWGL.Items;
using System;
using System.Drawing;
using rImage = System.Drawing.Image;
using Image = GDWGL.Items.Image;
using Button = GDWGL.Items.Button;

namespace TestApp
{
    public class Main : WGL
    {
        public Main() : base("Test App", new Vector2(1080, 720), true) { }

        // -- Layout --
        readonly Vector2 m_LeftMenuPosition = new Vector2(0, 0);
        readonly Vector2 m_FirstPagePosition = new Vector2(60, 10);

        // -- states --
        int m_currentPage = 0;

        // -- Left Menu --
        Square m_LeftMenu;
        const int c_defaultMinMenuSize = 50;
        const int c_defaultMaxMenuSize = 200;
        Button m_expandButton;
        Button m_goToSecondPage;
        // ...
        Button m_exitButton;

        // -- first Page --
        Text m_fPageTitle;


        // -- SecondPage --
        Text m_sPageTitle;
        Image m_sPageImage;

        public override void OnLoad()
        {
            // INIT
            ClearColor = Color.LightGray;
            UpdateFrequenzy = 90;

            // FIRST PAGE

            FirstPage();
            SecondPage();
            LeftMenu();


            //InputFieldControl test = new InputFieldControl();
            InputDebug debug = new InputDebug();
        }

        public override void OnUpdate()
        {
            // change page display

            if(m_currentPage == 0)
            {
                m_fPageTitle.hidden = false;

                m_sPageTitle.hidden = true;
                m_sPageImage.hidden = true;
            }
            else if(m_currentPage == 1)
            {
                m_fPageTitle.hidden = true;

                m_sPageTitle.hidden = false;
                m_sPageImage.hidden = false;

                if (m_sPageImage.Size < new Vector2(140))
                {
                    m_sPageImage.Size += new Vector2(4);
                }
                else
                {
                    m_sPageTitle.text = "XD";
                }
            }

            // change left menu button sizes

            if(m_LeftMenu.Size.X == c_defaultMinMenuSize)
            {
                m_goToSecondPage.Size.X = 40;
                m_goToSecondPage.text = "S";
                m_exitButton.Size.X = 40;
                m_exitButton.text = "Q";
            }
            else
            {
                m_goToSecondPage.Size.X = c_defaultMaxMenuSize - 10;
                m_goToSecondPage.text = "Second Page";
                m_exitButton.Size.X = c_defaultMaxMenuSize - 10;
                m_exitButton.text = "Quit";
            }

            base.OnUpdate();
        }

        void FirstPage()
        {
            // all first bage items

            m_fPageTitle = new Text(m_FirstPagePosition);
            m_fPageTitle.text = "Overview";
            m_fPageTitle.TextSize = 20;
        }

        void SecondPage()
        {
            // all second bage items

            m_sPageTitle = new Text(m_FirstPagePosition);
            m_sPageTitle.text = "Hello World!";
            m_sPageTitle.TextSize = 20;

            m_sPageImage = new Image(m_FirstPagePosition + new Vector2(5, 40), new Vector2(0), "triggered.png");
        }

        void LeftMenu()
        {
            // all left menu items

            m_LeftMenu = new Square(m_LeftMenuPosition, new Vector2(c_defaultMinMenuSize, s_window.Height - m_LeftMenuPosition.Y));
            m_LeftMenu.BackgroundColor = Color.White;

            m_expandButton = new Button(m_LeftMenuPosition + new Vector2(5), new Vector2(40));
            m_expandButton.text = "=";
            m_expandButton.TextSize = 20;
            m_expandButton.HasBorder = false;
            m_expandButton.MouseDown += m_expandButton_MouseDown;

            m_goToSecondPage = new Button(m_LeftMenuPosition + new Vector2(5, 50), new Vector2(40));
            m_goToSecondPage.text = "S";
            m_goToSecondPage.TextSize = 20;
            m_goToSecondPage.MouseDown += M_goToSecondPage_MouseDown;

            m_exitButton = new Button(new Vector2(5, s_window.Height - 5 - 80), new Vector2(40));
            m_exitButton.text = "Q";
            m_exitButton.TextSize = 20;
            m_exitButton.pressedColor = Color.Red;
            m_exitButton.MouseDown += ExitButton_MouseDown;
        }

        private void M_goToSecondPage_MouseDown(object sender, EventArgs e)
        {
            // jump tp second page

            m_currentPage = 1;
            m_LeftMenu.Size.X = c_defaultMinMenuSize;
        }

        private void m_expandButton_MouseDown(object sender, EventArgs e)
        {
            // change left menu size

            if (m_LeftMenu.Size.X == c_defaultMinMenuSize)
            {
                m_LeftMenu.Size.X = c_defaultMaxMenuSize;
            }
            else
            {
                m_LeftMenu.Size.X = c_defaultMinMenuSize;
            }
        }

        private void ExitButton_MouseDown(object sender, EventArgs e)
        {
            Exit();
        }

    }
}
