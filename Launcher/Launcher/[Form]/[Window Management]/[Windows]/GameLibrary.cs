using Launcher;

namespace BPS.Launcher.Form.Windows
{
    internal class GameLibrary : LauncherWindow
    {

        public GameLibrary()
        {
        }

        public override void LoadWindow()
        {
            _isCurrentWindow = true;
        }
        public override void UnloadWindow()
        {
            _isCurrentWindow = false;
        }

        public override void DoThreadLoop()
        {
            while (_isCurrentWindow)
            {

            }
        }
    }
}
