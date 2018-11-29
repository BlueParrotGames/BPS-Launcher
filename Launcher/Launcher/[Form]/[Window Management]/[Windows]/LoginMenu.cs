using Launcher;

namespace BPS.Launcher.Form.Windows
{
    public class LoginMenu : ILauncherWindow
    {
        private Main_Form _form;

        public LoginMenu(Main_Form form)
        {
            _form = form;
        }

        public void LoadWindow()
        {
            _form.Size = new System.Drawing.Size(400, 600);

            _form.Email_Input.Enabled = true;
            _form.Email_Input.Visible = true;

            _form.Password_Input.Enabled = true;
            _form.Password_Input.Visible = true;
        }
        public void UnloadWindow()
        {
            _form.Email_Input.Enabled = false;
            _form.Email_Input.Visible = false;

            _form.Password_Input.Enabled = false;
            _form.Password_Input.Visible = false;
        }
    }
}
