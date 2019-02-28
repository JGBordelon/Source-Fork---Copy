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
    public partial class formSorting : Form
    {
        private Point _Offset;
        Participant p;
        Random random;

        Timer reprimandTimer;

        SortingTrial currentTrialData;
        Stack<DraggableStimulus> stimuli;
        DraggableStimulus itemBeingDragged;
        DraggableStimulus currentStimulus;
        const int totalTrials = 4;
        int currentTrial;

        public formSorting(Participant participant)
        {
            _Offset = Point.Empty;
            this.p = participant;

            reprimandTimer = new Timer();
            reprimandTimer.Interval = 2000;
            reprimandTimer.Tick += new EventHandler(OnReprimandTimerTick);

            currentTrialData = new SortingTrial();
            InitializeComponent();
            random = new Random();
            try
            {
                pictureBoxTopLeft.Image = Image.FromFile(Application.StartupPath + "\\images\\A1.png");
                pictureBoxTopRight.Image = Image.FromFile(Application.StartupPath + "\\images\\A2.png");
            }
            catch
            {
                MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                Application.Exit();
            }
            stimuli = new Stack<DraggableStimulus>();
            buttonSubmit.Enabled = false;
            labelInitialInstructions.Enabled = true;
            labelInitialInstructions.Visible = true;
            SetUIPositions();
            FullscreenForm();
            
        }

        private void SetUIPositions()
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            screen = this.Bounds;
            var width = this.Width;
            var height = this.Height;

            labelInitialInstructions.Location = new Point(width / 2 - labelInitialInstructions.Width / 2, 45 );
            labelReprimand.Location = new Point(width / 2 - labelReprimand.Width / 2, 45);

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, height / 2 - panelStimuli.Height / 2); ;
            
            /*groupBoxA1.Location = new Point(45, 90);
            groupBoxA2.Location = new Point(width - groupBoxA2.Width - 45, 90);
            buttonSubmit.Location = new Point(width / 2 - buttonSubmit.Width / 2, 180);
            draggableStimulus1.Location = new Point(width / 2 - draggableStimulus1.Width / 2, height / 2 - draggableStimulus1.Height / 2);
            draggableStimulus2.Location = draggableStimulus1.Location;
            draggableStimulus3.Location = draggableStimulus1.Location;
            draggableStimulus4.Location = draggableStimulus1.Location; */

        }

        private void FullscreenForm()
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void StartTrial()
        {
            currentTrial = 0;
            List<DraggableStimulus> temp = new List<DraggableStimulus>();
            try
            {
                draggableStimulus1.Image = Image.FromFile(Application.StartupPath + "\\images\\B1.png");
                draggableStimulus1.stimulus = Stimuli.B1;
                draggableStimulus2.Image = Image.FromFile(Application.StartupPath + "\\images\\B2.png");
                draggableStimulus2.stimulus = Stimuli.B2;
                draggableStimulus3.Image = Image.FromFile(Application.StartupPath + "\\images\\C1.png");
                draggableStimulus3.stimulus = Stimuli.C1;
                draggableStimulus4.Image = Image.FromFile(Application.StartupPath + "\\images\\C2.png");
                draggableStimulus4.stimulus = Stimuli.C2;
            }
            catch
            {
                MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                Application.Exit();
            }
            temp.Add(draggableStimulus1);
            temp.Add(draggableStimulus2);
            temp.Add(draggableStimulus3);
            temp.Add(draggableStimulus4);
            temp.Shuffle<DraggableStimulus>(random);
            foreach(DraggableStimulus d in temp){
                stimuli.Push(d);
            }
            RunTrial();
        }

        public void RunTrial()
        {
            if( currentTrial < totalTrials ){
                currentStimulus = stimuli.Pop();
                currentStimulus.Visible = true;  }
            else{
                List<SortingTrial> temp = new List<SortingTrial>();
                currentTrialData.trialNumber = 0;
                currentTrialData.phaseNumber = 0;
                temp.Add(currentTrialData);
                p.AddTrialData("Sorting", temp);
                this.Close();
            }
        }

        private void draggableStimuls_MouseDown(object sender, MouseEventArgs e)
        {
                itemBeingDragged = (DraggableStimulus)sender;
                Point p = this.PointToClient(Cursor.Position);
               _Offset = new Point(itemBeingDragged.Location.X - p.X, itemBeingDragged.Location.Y - p.Y);
        }

        private void draggableStimuls_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (itemBeingDragged != null)
            {
                
                Point p = this.PointToClient(Cursor.Position);
                itemBeingDragged.Location = new Point(p.X + _Offset.X, p.Y + _Offset.Y);
            }
        }

        private void draggableStimuls_MouseUp(object sender, MouseEventArgs e)
        {
            _Offset = Point.Empty;
            itemBeingDragged = null;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Rectangle A1 = new Rectangle(groupBoxA1.Location.X + panelStimuli.Location.X, groupBoxA1.Location.Y + panelStimuli.Location.Y, groupBoxA1.Width, groupBoxA1.Height);

            Rectangle A2 = new Rectangle(groupBoxA2.Location.X + panelStimuli.Location.X, groupBoxA2.Location.Y + panelStimuli.Location.Y, groupBoxA2.Width, groupBoxA2.Height);           
            if (currentStimulus.Bounds.IntersectsWith(A1))
            {
                currentStimulus.isDraggable = false;
                currentTrialData.A1.Add(currentStimulus.stimulus);
                currentTrial++;
                RunTrial();

            }
            else if (currentStimulus.Bounds.IntersectsWith(A2))
            {
                currentStimulus.isDraggable = false;
                currentTrialData.A2.Add(currentStimulus.stimulus);
                currentTrial++;
                RunTrial();
            }
            else
            {
                labelReprimand.Show();
                reprimandTimer.Start();
            }
        }

        public void OnReprimandTimerTick(object sender, EventArgs e)
        {
            reprimandTimer.Stop();
            labelReprimand.Hide();
        }

        private void formSorting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                buttonSubmit.Enabled = true;
                labelInitialInstructions.Hide();
                labelInitialInstructions.Enabled = false;
                StartTrial();
            }
        }

        private void formDRLDRH_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
        }

    }
}
