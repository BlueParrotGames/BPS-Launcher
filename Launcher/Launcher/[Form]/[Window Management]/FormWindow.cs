using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPS.Launcher.Form.Windows
{
    public enum WindowType
    {
        LoginWindow,
    }

    public struct FormWindow
    {
        public readonly int WindowWidth;
        public readonly int WindowHeight;
        public readonly Panel Panel;

        public FormWindow(int windowWidth, int windowHeight, Panel panel)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            Panel = panel;
        }
    }
}
