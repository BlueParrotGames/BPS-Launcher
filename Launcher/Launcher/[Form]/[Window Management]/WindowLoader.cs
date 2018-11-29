using System.Threading;
using System.Collections.Generic;
using Launcher;

namespace BPS.Launcher.Form.Windows
{
    public class WindowLoader
    {
        public static WindowLoader Instance;

        public enum WindowType { LoginMenu, GameLibrary}

        private Dictionary<WindowType, ILauncherWindow> _windows;
        private ILauncherWindow _currentWindow;

        Main_Form _form;

        Thread loopThread;

        public WindowLoader(Main_Form form)
        {
            Instance = this;

            _form = form;

            _windows = new Dictionary<WindowType, ILauncherWindow>();
            InitializeWindows();
        }
        private void InitializeWindows()
        {
            _windows.Add(WindowType.LoginMenu, new LoginMenu(_form.Email_Input, _form.Password_Input, _form.Login_Button));
            _windows.Add(WindowType.GameLibrary, new GameLibrary());
        }

        public void LoadWindow(WindowType windowType)
        {
            _currentWindow?.UnloadWindow();
            loopThread?.Abort();

            if(_windows.TryGetValue(windowType, out ILauncherWindow window))
            {
                _currentWindow = window;
                window.LoadWindow();

                loopThread = new Thread(window.DoThreadLoop);
                loopThread.Start();
            }
        }
    }
}
