using System.Drawing;
using System.Collections.Generic;

using Launcher;

namespace BPS.Launcher.Form.Windows
{
    public class WindowLoader
    {
        private Main_Form _form;
        private Dictionary<WindowType, FormWindow> _presetWindows;

        private FormWindow _currentWindow;

        public WindowLoader(Main_Form form)
        {
            _form = form;

            _presetWindows = new Dictionary<WindowType, FormWindow>();

            InitializePresetWindows();

            LoadWindow(WindowType.LoginWindow);
        }
        private void InitializePresetWindows()
        {
            _presetWindows.Add(WindowType.LoginWindow, new FormWindow(1000, 1000, _form.LoginPanel));
        }

        public void LoadWindow(WindowType windowType)
        {
            if(_presetWindows.TryGetValue(windowType, out FormWindow window))
            {
                LoadWindow(window);
            }
        }
        public void LoadWindow(FormWindow window)
        {
            _currentWindow.Panel.Enabled = false;
            _currentWindow.Panel.Visible = false;

            _form.Size = new Size(window.WindowWidth, window.WindowHeight);
            window.Panel.Visible = true;
            window.Panel.Enabled = true;

            _currentWindow = window;
        }
    }
}
