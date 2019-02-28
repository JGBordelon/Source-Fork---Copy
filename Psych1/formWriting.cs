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
    public partial class formWriting : Form
    {
        Timer trialTimer;

        public formWriting()
        {
            InitializeComponent();
            trialTimer = new Timer();
            trialTimer.Interval = 5 * 60 * 1000; // 5 minutes for release
            trialTimer.Tick += new EventHandler(OnTrialTimerTick);
        }

        private void buttonBegin_Click(object sender, EventArgs e)
        {
            trialTimer.Start();
            (sender as Button).Hide();
        }

        private void OnTrialTimerTick(object sender, EventArgs e)
        {
            trialTimer.Stop();
            textBoxWriting.ReadOnly = true;
            panelYesNo.Show();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            // add textBoxWriting.Text to p.writingsample or something
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
