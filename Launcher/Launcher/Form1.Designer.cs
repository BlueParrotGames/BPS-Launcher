using System;
using System.Runtime.InteropServices;

namespace Launcher
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Borderless window dragging

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int width, int lenght);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs args)
        {
            if (args.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Email_Input = new System.Windows.Forms.TextBox();
            this.Password_Input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Email_Input
            // 
            this.Email_Input.AcceptsReturn = true;
            this.Email_Input.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Email_Input.Font = new System.Drawing.Font("Roboto Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_Input.Location = new System.Drawing.Point(12, 258);
            this.Email_Input.MaxLength = 50;
            this.Email_Input.Name = "Email_Input";
            this.Email_Input.Size = new System.Drawing.Size(376, 32);
            this.Email_Input.TabIndex = 0;
            this.Email_Input.WordWrap = false;
            // 
            // Password_Input
            // 
            this.Password_Input.AcceptsReturn = true;
            this.Password_Input.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Password_Input.Font = new System.Drawing.Font("Roboto Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Input.Location = new System.Drawing.Point(12, 296);
            this.Password_Input.MaxLength = 50;
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Size = new System.Drawing.Size(376, 32);
            this.Password_Input.TabIndex = 1;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.Email_Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Main_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public System.Windows.Forms.TextBox Email_Input;
        public System.Windows.Forms.TextBox Password_Input;
    }
}

