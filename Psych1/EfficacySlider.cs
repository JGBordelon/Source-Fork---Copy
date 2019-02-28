using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Psych1
{
    public class EfficacySlider : TrackBar
    {
        EfficacyEvaluation evaluation;
        bool mouseIsClicked;
        int lastChoice;
        Stopwatch inputStopwatch;

        public EfficacySlider() 
            :base()
        {
            inputStopwatch = new Stopwatch();
        }

        public void Init(EfficacyEvaluation e)
        {
            evaluation = e;
            mouseIsClicked = false;
            lastChoice = -1;
        }

        private void updateChoice()
        {
            if (!(lastChoice == Value + 1))
            {
                lastChoice = Value + 1;
                evaluation.AddChoice(lastChoice.ToString(), inputStopwatch.ElapsedMilliseconds);
                inputStopwatch.Reset();
            }
        }

        private void updateSlidertoMouse(double X)
        {
            double dblValue;
            dblValue = (X / (double)this.Width) * (this.Maximum - this.Minimum);
            if (dblValue < this.Minimum)
            {
                dblValue = this.Minimum;
            }else if(dblValue > this.Maximum) {
                 dblValue = this.Maximum;
            }
            this.Value = Convert.ToInt32(dblValue);
        }

        public void MoveSlider(double X)
        {
            if (mouseIsClicked)
            {
                updateSlidertoMouse(X);
            }
        }

        public void MouseReleased()
        {
            inputStopwatch.Stop();
            mouseIsClicked = false;
            updateChoice();
        }

        public void MousePressed()
        {
            mouseIsClicked = true;
            inputStopwatch.Start();
        }

        public void SetChoice(int choice)
        {
            if (lastChoice == ++choice)
            {
                return;
            }

            lastChoice = choice;
            evaluation.AddChoice(choice.ToString());
        }

        public int GetChoice()
        {
            return lastChoice;
        }
    }
}
