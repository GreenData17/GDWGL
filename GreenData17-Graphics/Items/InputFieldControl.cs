using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDWGL.Items
{
    public partial class InputFieldControl : TextBox
    {

        public InputFieldControl()
        {
            InitializeComponent();

            BorderStyle = BorderStyle.None;
            Font = new Font("Arial", 12);
            Size = new Size(100, 30);

            WGL.GetWindow().BeginInvoke((MethodInvoker)delegate
            { WGL.GetWindow().Controls.Add(this); });
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
        }
    }
}
