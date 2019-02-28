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
    public partial class formCDT : Form {
        
        Participant p;

        EfficacyEvaluation evaluation;

        Random random;
        const int stimulusTime = 1500;
        const int delayBetweenStimulusAndChoices = 50;
        const int feedbackDisplayTime = 1000;
        List<Timer> timers;
        Timer stimulusTimer;
        Timer delayTimer;
        Timer feedbackTimer;
        

        Stopwatch inputStopwatch;

        Dictionary<Stimuli, Image> stimuli;

        CDTTrial currentTrialData;

        bool areWeTesting;
        bool showingInstructions;

        int currentTrial;
        int correctAnswersInARow;
        bool failedOnce;

        CDTTrialBlock trialType;

        List<CDTStimulus> trials;
        List<CDTTrial> trialData;

        public formCDT(Participant participant) {
            InitializeComponent();

            p = participant;
            showingInstructions = true;
            areWeTesting = false; //false for final
            random = new Random();
            timers = new List<Timer>();
            stimulusTimer = new Timer();
            delayTimer = new Timer();
            feedbackTimer = new Timer();
            timers.Add(stimulusTimer);
            timers.Add(delayTimer);
            timers.Add(feedbackTimer);

            stimulusTimer.Interval = stimulusTime;
            delayTimer.Interval = delayBetweenStimulusAndChoices;
            feedbackTimer.Interval = feedbackDisplayTime;
            stimulusTimer.Tick += OnStimulusTimerTick;
            feedbackTimer.Tick += OnFeedbackTimerTick;
            delayTimer.Tick += OnDelayTimerTick;

            inputStopwatch = new Stopwatch();

            failedOnce = false;
            stimuli = new Dictionary<Stimuli, Image>();
            InitializeStimuli();
            trialType = CDTTrialBlock.ConsecutiveTraining; //Consecutive for final
            areWeTesting = false;
            trialData = new List<CDTTrial>();
            try { 
                ReadInstructionsFromFile(Application.StartupPath + "\\instructions\\ConditionalDiscriminationTraining.rtf");
            }
            catch
                        {
                            MessageBox.Show("Check instructions files @ \\instructions\\ConditionalDiscriminationTraining.rtf");
                            Application.Exit();
                        }
            SetUIPositions();
            FullscreenForm();
            this.Focus();
        }

        private void FullscreenForm()
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void ReadTrainingStimuliSets() {
            trials = new List<CDTStimulus>();
            string path = null;
            try
            {
                if (!areWeTesting)
                {
                    path = Application.StartupPath + "\\csv\\CDTStimuliSetsTraining.txt";
                }
                else
                {
                    if (trialType == CDTTrialBlock.TrialBlock1)
                    {
                        path = Application.StartupPath + "\\csv\\CDTStimuliSetsTrial1.txt";
                    }
                    else if (trialType == CDTTrialBlock.TrialBlock2)
                    {
                        path = Application.StartupPath + "\\csv\\CDTStimuliSetsTrial2.txt";
                    }
                }

            }
            catch
            {
                MessageBox.Show("Check file @ \\csv\\CDTStimuliSets[xxx].txt");
                Application.Exit();
            }
            using (CsvFileReader reader = new CsvFileReader(path)) {
                CsvRow row = new CsvRow();
                Stimuli [] stimuli = new Stimuli[3];
                reader.ReadRow(row);
                if(row[0] != "STIMULUS" || row[1] != "CORRECT" || row[2] != "WRONG") {
                    MessageBox.Show("Please quit the program and ensure that your input CSV is configured correctly for this experiment.");
                }
                while (reader.ReadRow(row)) {
                    int i = 0;
                    foreach (string s in row) {
                        Stimuli stimulus = (Stimuli)Enum.Parse(typeof(Stimuli), s);
                        stimuli[i] = stimulus;
                        i++;
                    }
                    trials.Add(new CDTStimulus(stimuli[0], stimuli[1], stimuli[2]));
                }
            }
        }

        private void RandomizeTrials() {                              
            trials.Shuffle<CDTStimulus>(random);
        }

        private void InitializeStimuli() {
            Image temp;

            try
            {
                temp = Image.FromFile(Application.StartupPath + "\\images\\A1.png");
                stimuli.Add(Stimuli.A1, temp);
                temp = Image.FromFile(Application.StartupPath + "\\images\\A2.png");
                stimuli.Add(Stimuli.A2, temp);
                temp = Image.FromFile(Application.StartupPath + "\\images\\B1.png");
                stimuli.Add(Stimuli.B1, temp);
                temp = Image.FromFile(Application.StartupPath + "\\images\\B2.png");
                stimuli.Add(Stimuli.B2, temp);
                temp = Image.FromFile(Application.StartupPath + "\\images\\C1.png");
                stimuli.Add(Stimuli.C1, temp);
                temp = Image.FromFile(Application.StartupPath + "\\images\\C2.png");
                stimuli.Add(Stimuli.C2, temp);
            }
            catch
            {
                MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                Application.Exit();
            }
        }

        private void InitializeTrial() {
            stimulus.Image = stimuli[trials[currentTrial].stimulus];
            if (random.Next(2) == 1) {
                pictureLeft.Image = stimuli[trials[currentTrial].correct];
                pictureLeft.Tag = "correct";
                pictureRight.Image = stimuli[trials[currentTrial].wrong];
                pictureRight.Tag = "wrong";
            } else {
                pictureRight.Image = stimuli[trials[currentTrial].correct];
                pictureLeft.Image = stimuli[trials[currentTrial].wrong];
                pictureRight.Tag = "correct";
                pictureLeft.Tag = "wrong";
            }
        }

        private void ShowStimulus() {
            stimulus.Show();
            stimulusTimer.Start();
        }

        private void HideStimulus() {
            stimulus.Hide();
            delayTimer.Start();
        }

        private void ShowChoices() {
            pictureRight.Show();
            pictureLeft.Show();
        }

        private void HideChoices() {
            pictureLeft.Hide();
            pictureRight.Hide();
        }

        private void ShowFeedback() {
            labelFeedback.Show();
            feedbackTimer.Start();
        }

        private void HideFeedback() {
            labelFeedback.Hide();
        }

        private void StartTrials() {
            currentTrial = 0;
            ReadTrainingStimuliSets();
            correctAnswersInARow = 0; // 0 for final
            RunTrial();
        }

        private void RunTrial()
        {
            if (currentTrial < trials.Count)
            {
                if (trialType != CDTTrialBlock.ConsecutiveTraining)
                {
                    if (trialType == CDTTrialBlock.MixedTraining && correctAnswersInARow == 12)
                    {
                        DidWePass();
                    }
                }
                    {
                        InitializeTrial();
                        currentTrialData = new CDTTrial();
                        ShowStimulus();
                        inputStopwatch.Start();
                    }
                
            }
            else
            {
                DidWePass();
            }

        }

        private void DidWePass() {
            if (!areWeTesting)
            {
                if (trialType == CDTTrialBlock.ConsecutiveTraining)
                {
                    trialType = CDTTrialBlock.MixedTraining;
                    correctAnswersInARow = 0;
                    currentTrial = 0;
                    RandomizeTrials();
                    RunTrial();
                    return;
                }
                else if (trialType == CDTTrialBlock.MixedTraining && correctAnswersInARow == 12) //12
                {
                    trialType = CDTTrialBlock.TrialBlock1;
                    correctAnswersInARow = 0;
                    currentTrial = 0;
                    areWeTesting = true;
                    ReadTrainingStimuliSets();
                    RandomizeTrials();
                    RunTrial();
                    return;
                }
                else
                {
                    trialType = CDTTrialBlock.MixedTraining;
                    areWeTesting = false;
                    currentTrial = 0;
                    ReadTrainingStimuliSets();
                    RandomizeTrials();
                    RunTrial();
                    return;
                }
            }
            else
            {
                if (correctAnswersInARow == 4) //4
                {
                    if (trialType == CDTTrialBlock.TrialBlock1)
                    {
                        correctAnswersInARow = 0;
                        currentTrial = 0;
                        trialType = CDTTrialBlock.TrialBlock2;
                        RunTrial();
                        return;
                    }
                    else if (trialType == CDTTrialBlock.TrialBlock2)
                    {
                        foreach (Timer t in timers)
                        {
                            t.Dispose();
                        }
                        evaluation = new EfficacyEvaluation();
                        evaluation.evaluationNumber = "0";
                        evaluation.trialType = "Conditional Discrimination";
                        Form temp = new formEfficacyEvaluation(evaluation);
                        temp.FormClosed += new FormClosedEventHandler(OnEfficacyEvaluationClosed);
                        temp.Show();
                    }
                    
                } else {
                    if (failedOnce) {
                        p.failedCDT = true;
                        ProcessData();
                        Form c = new formClosing();
                        c.Show();
                        this.Close();
                    } else {
                        failedOnce = true;
                        trialType = CDTTrialBlock.MixedTraining;
                        areWeTesting = false;
                        correctAnswersInARow = 0;
                        currentTrial = 0;
                        ReadTrainingStimuliSets();
                        RandomizeTrials();
                        RunTrial();
                        return;

                    }
                }
            }
            
        }

        private void ProcessData() {
            p.AddEvaluation(evaluation);
            p.AddTrialData("CDT", trialData);
            this.Close();
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
            var width = this.Width;
            var height = this.Height;

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, height / 2 - panelStimuli.Height / 2); ;
            richTextBoxInitialInstructions.Location = new Point(width / 2 - richTextBoxInitialInstructions.Width / 2, panelStimuli.Location.Y - 45);
            labelFeedback.Location = new Point(width / 2 - labelFeedback.Width / 2, height / 2 - labelFeedback.Height / 2);
        }

   
        private void OnStimulusTimerTick(object sender, EventArgs e) {
            HideStimulus();
            stimulusTimer.Stop();
        }

        private void OnDelayTimerTick(object sender, EventArgs e) {
            ShowChoices();
            delayTimer.Stop();
        }

        private void OnFeedbackTimerTick(object sender, EventArgs e) {
            HideFeedback();
            feedbackTimer.Stop();
            RunTrial();
        }

        private void picture_Click(object sender, EventArgs e) {
            if (sender is PictureBox) {
                inputStopwatch.Stop();
                currentTrialData.responseTime = inputStopwatch.ElapsedMilliseconds;
                inputStopwatch.Reset();
                
                if ((sender as PictureBox).Tag.ToString() == "correct") {
                    correctAnswersInARow++;
                    currentTrialData.correct = true;
                    
                } else {
                    correctAnswersInARow = 0;
                    currentTrialData.correct = false;
                }
                trialData.Add(currentTrialData);
                currentTrialData.trialNumber = currentTrial;
                currentTrial++;
                currentTrialData.testingOrTraining = trialType.ToString();

                HideChoices();
                if (!areWeTesting)
                {
                    if (currentTrialData.correct)
                    {
                        labelFeedback.Text = "CORRECT!";

                    }
                    else
                    {
                        labelFeedback.Text = "WRONG!";

                    }
                    //label1.Text = correctAnswersInARow.ToString();
                    ShowFeedback();
                }
                else
                {
                    RunTrial();
                }
            }
        }

        private void formConditionalDiscriminationTraining_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
            panelStimuli.Invalidate();
        }

        private void KillTimers() {
            foreach(Timer t in timers) {
                t.Dispose();
            }
        }

        private void formConditionalDiscriminationTraining_FormClosed(object sender, FormClosedEventArgs e) {
            KillTimers();
        }

        private void OnEfficacyEvaluationClosed(object sender, FormClosedEventArgs e)
        {
            ProcessData();
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
                StartTrials();
            }
        }
    }
}
