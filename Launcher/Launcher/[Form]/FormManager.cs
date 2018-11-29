using Launcher;
using BPS.Launcher.Form.Windows;

namespace BPS.Launcher.Form
{
    public class FormManager
    {
        private Main_Form _mainForm;

        //External managers
        private WindowLoader _windowLoader;

        public FormManager(Main_Form mainForm)
        {
            _mainForm = mainForm;

            _windowLoader = new WindowLoader(mainForm);
        }
    }
}
