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
using System.IO;

namespace Psych1 {
    public partial class formDRHDRL : Form { 
        Participant p;
        Form efficacyEvaluation;
        Random random;
        const int TRIAL_LENGTH = 2 * 60 * 1000; // 2 minutes in final
        const int DRL_INPUT_INTERVAL = 2000; // 2 second interval in keypresses required to accrue point
        const int NUMBER_OF_TRIALS = 8;
        List<Timer> timers;
        Timer trialTimer;
        Timer drlInputTimer;           
        Stopwatch drhInputStopwatch;
        Stopwatch trapInputTime;
           
        List<DRHDRLTrial> trialData;
        DRHDRLTrial currentTrialData;
        EfficacyEvaluation evaluation;
        List<long> keypressData;

        int participantID;

        int drhKeypresses;
        int points;
        DR currentColor;
        int currentTrial;

        bool showingInstructions;

        public formDRHDRL(Participant participant)
        {
            InitializeComponent();
            trialData = new List<DRHDRLTrial>();
            timers = new List<Timer>();

            random = new Random();
            p = participant;
            showingInstructions = true;
            int.TryParse(p.participantID, out participantID);
            FullscreenForm();
            try
            {
                ReadInstructionsFromFile(Application.StartupPath + "\\instructions\\DRLDRH.rtf");
            }
            catch
            {
                MessageBox.Show("Check instruction file @ \\instructions\\DRLDRH.rtf");
                Application.Exit();
            }
            SetUIPositions();
            FullscreenForm();
            GetStartingStimulus();
        }

        private void StartTrials() {
            stimulus.SizeMode = PictureBoxSizeMode.StretchImage;
            points = 0;
            trialTimer = new Timer();
            drlInputTimer = new Timer();
            timers.Add(trialTimer);
            timers.Add(drlInputTimer);

            drlInputTimer.Interval = DRL_INPUT_INTERVAL;
            trialTimer.Interval = TRIAL_LENGTH;
            trialTimer.Tick += trialTimer_Tick;
            drlInputTimer.Tick += drlInputTimer_Tick;
            drhInputStopwatch = new Stopwatch();
            trapInputTime = new Stopwatch();

            
            currentTrial = 0;
            RunTrial();
        }

        private void RunTrial() {
            keypressData = new List<long>();
            trapInputTime.Reset();
            currentTrialData = new DRHDRLTrial();
            evaluation = new EfficacyEvaluation();
            points = 0;
            labelPoints.Text = "0";
            labelPoints.Show();
            stimulus.Show();

            currentColor = (currentColor == DR.H) ? DR.L : DR.H;
            try
            {
                if (currentColor == DR.H)
                {
                    stimulus.Image = Image.FromFile(Application.StartupPath + "\\images\\A2.png");
                }
                else
                {
                    stimulus.Image = Image.FromFile(Application.StartupPath + "\\images\\A1.png");
                }
            }
            catch
            {
                MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                Application.Exit();
            }
            if (currentTrial < NUMBER_OF_TRIALS) {
                drhKeypresses = 0;
                ShowStimulus();
                trapInputTime.Start();
                drhInputStopwatch.Start();
                trialTimer.Start();
            } else {
                EndTrials();
            }
        }

        private void EndTrials() {
            drhInputStopwatch.Stop();
            trialTimer.Stop();
            stimulus.Hide();
            SaveData();
            this.Close();
        }

        private void GetStartingStimulus() {

            if (participantID % 2 == 0) {
                currentColor = DR.H;
            } else {
                currentColor = DR.L;
            }
        }

        private void ShowStimulus() {
            stimulus.Visible = true;
        }

        private void AwardPoint() {
            points++;
            drhKeypresses = 0;
            drlInputTimer.Stop();
            drhInputStopwatch.Stop();
            drhInputStopwatch.Reset();
            drhInputStopwatch.Start();
            labelPoints.Text = points.ToString();
        }

        private void FullscreenForm() {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void ReadInstructionsFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                richTextBoxInitialInstructions.LoadFile(fileName);
            }
            else
            {
                MessageBox.Show("A problem exists with the instructions file");
                Application.Exit();
            }
        }

        private void SetUIPositions()
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            screen = this.Bounds;
            var width = screen.Width;
            var height = screen.Height;

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, height / 2 - panelStimuli.Height / 2); ;
            richTextBoxInitialInstructions.Location = new Point(width / 2 - richTextBoxInitialInstructions.Width / 2, panelStimuli.Location.Y - 45);
            
        }

        private void trialTimer_Tick(object sender, EventArgs e) {
            ShowEvaluation();
            currentTrialData.points = points;
            currentTrialData.keyPresses.Add(currentTrial, keypressData);
            currentTrialData.DRHDRL = "DR" + currentColor.ToString();
            currentTrialData.trialNumber = currentTrial;
            trialData.Add(currentTrialData);
        }

        private void SaveData() {
            p.AddTrialData("DRHDRL",trialData);
        }

        private void drlInputTimer_Tick(object sender, EventArgs e) {
            AwardPoint();
        }

        private void ShowEvaluation() {
            trialTimer.Stop();
            drlInputTimer.Stop();
            drhInputStopwatch.Stop();
            drhInputStopwatch.Reset();
            evaluation.trialType = TrialTypes.DRHDRL.ToString();
            evaluation.evaluationNumber = currentTrial.ToString();
            efficacyEvaluation = new formEfficacyEvaluation(evaluation);
            efficacyEvaluation.FormClosed += OnEvaluationClosed;
            efficacyEvaluation.Show();
        }

        private void OnEvaluationClosed(object sender, EventArgs e) {
            efficacyEvaluation.FormClosed -= OnEvaluationClosed;
            efficacyEvaluation.Dispose();
            p.AddEvaluation(evaluation);
            currentTrial++;
            RunTrial();
        }

        private void formDRLDRH_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
            panelStimuli.Invalidate();
        }

        public void KillTimers() {
            foreach (Timer t in timers) {
                t.Dispose();
            }
        }

        private void formDRLDRH_FormClosed(object sender, FormClosedEventArgs e) {
            KillTimers();
        }

        private void richTextBoxInitialInstructions_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.SuppressKeyPress = true;
            if (!showingInstructions)
            {
                return;
            }

            if (e.KeyCode == Keys.Space)
            {
                showingInstructions = false;
                richTextBoxInitialInstructions.Hide();
                richTextBoxInitialInstructions.Enabled = false;
                StartTrials();
            }
        }

        private void formDRLDRH_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.SuppressKeyPress = true;
            if (showingInstructions)
            {
                return;
            }

            if (e.KeyCode != Keys.Space)
            {
                return;
            }

            keypressData.Add(trapInputTime.ElapsedMilliseconds);

            if (currentColor == DR.H)
            {
                drhKeypresses++;

                if (drhInputStopwatch.ElapsedMilliseconds > 2000)
                {
                    drhKeypresses = 1;
                    drhInputStopwatch.Stop();
                    drhInputStopwatch.Reset();
                    drhInputStopwatch.Start();
                }
                else if (drhInputStopwatch.ElapsedMilliseconds < 2001 && drhKeypresses == 5)
                {
                    AwardPoint();
                }
            }
            else
            {
                drlInputTimer.Stop();
                drlInputTimer.Start();
            }

        }
    }
}
