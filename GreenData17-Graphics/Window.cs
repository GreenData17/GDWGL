using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL
{
    public class Window : Form
    {
        public Window(bool doubleBuffered)
        {
            DoubleBuffered = doubleBuffered;
        }
    }
}
