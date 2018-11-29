using Launcher;

using BPS.Launcher.Form.Windows;

namespace BPS.Launcher.Form
{
    public class FormManager
    {
        private Main_Form _mainForm;

        public FormManager(Main_Form mainForm)
        {
            _mainForm = mainForm;

            new WindowLoader(mainForm).LoadWindow(WindowLoader.WindowType.LoginMenu);
        }
    }
}
