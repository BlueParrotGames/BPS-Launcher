using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.Launcher.Form.Windows
{
    public interface ILauncherWindow
    {
        void UnloadWindow();
        void LoadWindow();
    }
}
