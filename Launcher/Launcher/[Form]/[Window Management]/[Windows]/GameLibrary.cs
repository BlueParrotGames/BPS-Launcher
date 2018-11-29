using Launcher;

namespace BPS.Launcher.Form.Windows
{
    public class GameLibrary : ILauncherWindow
    {
        private Main_Form _form;

        public GameLibrary(Main_Form form)
        {
            _form = form;
        }

        public void LoadWindow()
        {
        }
        public void UnloadWindow()
        {
        }
    }
}
