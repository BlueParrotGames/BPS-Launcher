using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BPS.Launcher.Form;

namespace Launcher
{
    public partial class Main_Form : Form
    {
        public static Main_Form Instance;

        public Main_Form()
        {
            Instance = this;

            InitializeComponent();

            new FormManager(this);

            MouseDown += MainForm_MouseDown;
        }

        public void ReSize(int width, int height)
        {
            this.Size = new Size(width, height);
        }
    }
}
