using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psych1
{
    public partial class formClosing : Form
    {
        public formClosing()
        {
            InitializeComponent();
            SetUIPositions();
           // FullscreenForm();
        }

        private void FullscreenForm()
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void SetUIPositions()
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            screen = this.Bounds;
            var width = this.Width;
            var height = this.Height;

            labelInitialInstructions.Location = new Point(width / 2 - labelInitialInstructions.Width / 2, height / 2 - labelInitialInstructions.Height / 2);
            
        }

        private void formClosing_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
            labelInitialInstructions.Invalidate();
        }

        private void formClosing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0)
            {
                this.Close();
            }
        }
    }
}
