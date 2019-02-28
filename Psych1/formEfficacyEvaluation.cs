using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Psych1 {
    public partial class formEfficacyEvaluation : Form {
        public string eval;
        EfficacyEvaluation evaluation;
        
        public formEfficacyEvaluation(EfficacyEvaluation evaluation) {
            InitializeComponent();
            this.evaluation = evaluation;
            SetUIPositions();
            FullscreenForm();
            efficacySlider.Init(evaluation);
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
            var width = screen.Width;
            var height = screen.Height;

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, height / 2 - panelStimuli.Height / 2); ;
            
        }

        private void formEfficacyEvaluation_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
            panelStimuli.Invalidate();
        }

        private void efficacySlider_ValueChanged(object sender, EventArgs e)
        {
            //efficacySlider.SetChoice((sender as TrackBar).Value);S
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int temp = efficacySlider.GetChoice();
            if (temp != -1)
            {
                evaluation.evaluationResponse = temp.ToString();
                this.Close();
            }
        }

        private void efficacySlider_MouseDown(object sender, MouseEventArgs e)
        {
            efficacySlider.MousePressed(); // Fix These
        }

        private void efficacySlider_MouseUp(object sender, MouseEventArgs e)
        {
            efficacySlider.MouseReleased(); // Fix These
        }

        private void efficacySlider_MouseMove(object sender, MouseEventArgs e)
        {
            efficacySlider.MoveSlider((double)e.X); 
        }


    }
}
