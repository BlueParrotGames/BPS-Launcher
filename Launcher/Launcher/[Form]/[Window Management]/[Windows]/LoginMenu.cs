using System;
using System.Drawing;
using System.Windows.Forms;

using Launcher;

namespace BPS.Launcher.Form.Windows
{
    public class LoginMenu : ILauncherWindow
    {
        private TextBox _emailBox;
        private TextBox _passwordBox;

        public LoginMenu(TextBox emailBox, TextBox passwordBox)
        {
            _emailBox = emailBox;
            _passwordBox = passwordBox;

            _emailBox.Text = "Insert e-mail...";
            _passwordBox.Text = "Insert password...";
            _emailBox.ForeColor = Color.LightGray;
            _passwordBox.ForeColor = Color.LightGray;
        }

        public void LoadWindow()
        {
            Main_Form.Instance.ReSize(400, 600);

            _emailBox.Enabled = true;
            _emailBox.Visible = true;
            _emailBox.GotFocus += BoxGotFocus;
            _emailBox.LostFocus += BoxLostFocus;

            _passwordBox.Enabled = true;
            _passwordBox.Visible = true;
            _passwordBox.GotFocus += BoxGotFocus;
            _passwordBox.LostFocus += BoxLostFocus;

        }
        public void UnloadWindow()
        {
            _emailBox.Enabled = false;
            _emailBox.Visible = false;
            _emailBox.GotFocus -= BoxGotFocus;
            _emailBox.LostFocus -= BoxLostFocus;

            _passwordBox.Enabled = false;
            _passwordBox.Visible = false;
            _passwordBox.GotFocus -= BoxGotFocus;
            _passwordBox.LostFocus -= BoxLostFocus;
        }

        private void BoxGotFocus(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;

            if (box.Text == "Insert e-mail...")
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }
            else if (box.Text == "Insert password...")
            {
                box.Text = "";
                box.PasswordChar = '●';
                box.ForeColor = Color.Black;
            }
        }
        private void BoxLostFocus(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;

            if (box.Text == "")
            {
                if (_emailBox.Focused)
                {
                    box.Text = "Insert password...";
                    box.PasswordChar = '\0';
                }
                else
                {
                    box.Text = "Insert e-mail...";
                }

                box.ForeColor = Color.LightGray;
            }
        }
    }
}
