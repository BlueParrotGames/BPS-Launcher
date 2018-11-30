using System.Threading;
using System.Drawing;
using System.Windows.Forms;

using Launcher;

namespace BPS.Launcher.Form.Windows
{
    internal class LoginMenu : ILauncherWindow
    {
        private const string emailPlaceholderText = "Insert e-mail...";
        private const string passwordPlaceholderText = "Insert password...";

        private TextBox _emailBox;
        private TextBox _passwordBox;
        private Button _loginButton;

        public LoginMenu(TextBox emailBox, TextBox passwordBox, Button loginButton)
        {
            _emailBox = emailBox;
            _passwordBox = passwordBox;
            _loginButton = loginButton;

            _emailBox.Text = emailPlaceholderText;
            _passwordBox.Text = passwordPlaceholderText;
            _emailBox.ForeColor = Color.LightGray;
            _passwordBox.ForeColor = Color.LightGray;
        }

        public void LoadWindow()
        {
            Main_Form.Instance.ReSize(400, 600);

            _emailBox.Enabled = true;
            _emailBox.Visible = true;

            _passwordBox.Enabled = true;
            _passwordBox.Visible = true;

            _loginButton.Enabled = true;
            _loginButton.Visible = true;
        }
        public void UnloadWindow()
        {
            _emailBox.Enabled = false;
            _emailBox.Visible = false;

            _passwordBox.Enabled = false;
            _passwordBox.Visible = false;

            _loginButton.Enabled = false;
            _loginButton.Visible = false;
        }
    }
}
