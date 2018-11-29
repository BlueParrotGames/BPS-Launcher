using System.Threading;
using System.Drawing;
using System.Windows.Forms;

using Launcher;

namespace BPS.Launcher.Form.Windows
{
    internal class LoginMenu : LauncherWindow
    {
        private TextBox _emailBox;
        private TextBox _passwordBox;
        private Button _loginButton;

        public LoginMenu(TextBox emailBox, TextBox passwordBox, Button loginButton)
        {
            _emailBox = emailBox;
            _passwordBox = passwordBox;
            _loginButton = loginButton;

            _emailBox.Text = "Insert e-mail...";
            _passwordBox.Text = "Insert password...";
            _emailBox.ForeColor = Color.LightGray;
            _passwordBox.ForeColor = Color.LightGray;
        }

        public override void LoadWindow()
        {
            Main_Form.Instance.ReSize(400, 600);

            _emailBox.Enabled = true;
            _emailBox.Visible = true;

            _passwordBox.Enabled = true;
            _passwordBox.Visible = true;

            _isCurrentWindow = true;
        }
        public override void UnloadWindow()
        {
            _emailBox.Enabled = false;
            _emailBox.Visible = false;

            _passwordBox.Enabled = false;
            _passwordBox.Visible = false;

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
