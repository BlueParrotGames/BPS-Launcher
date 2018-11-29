using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.Launcher.Form.Windows
{
    internal class LauncherWindow : ILauncherWindow
    {
        protected bool _isCurrentWindow = false;

        public virtual void LoadWindow() { }
        public virtual void UnloadWindow() { }

        public virtual void DoThreadLoop() { }
    }
}
