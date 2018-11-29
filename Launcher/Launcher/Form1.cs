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
        public Main_Form()
        {
            InitializeComponent();

            new FormManager(this);

            MouseDown += MainForm_MouseDown;
        }
    }
}
