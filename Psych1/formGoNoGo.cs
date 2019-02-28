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
using System.Runtime.Serialization.Formatters.Binary;

namespace Psych1 {
    public partial class formGoNoGo : Form {
        List<PictureBox> stimuli;
        
        Image nonStimulusImage;
        Image nonStimulusImage1;
        Image nonStimulusImage2;

        Random random;
        List<Timer> timers;
        Timer interStimulusTimer;
        Timer stimulusTimer;
        Timer startingTrialsTimer;
        Stopwatch inputStopWatch;
       
        bool practicing;
        bool showingInstructions;
        bool waitingforInput;
        bool usingDerivedStimuli;
        string derivedStimulus;
        string tempStimulus; // This holds the type of derived stimulus for the current trialdata object

        char initialGoCharacter;
        char initialNoGoCharacter;

        char goCharacter;
        char noGoCharacter;

        const int TOTAL_TRIALS = 160; //160
        const int NEGATIVE_TRIALS = 32; //32
        int totalPhases;
        int numberOf1s; // This is to ensure 50/50 showing of B1,B2 A1,A2, C1,C2 for the derived version of this task

        bool[] practiceTrials;
        bool[] trials;

        Participant p;
        List<GoNoGoTrial> trialData;
        GoNoGoTrial currentTrialData;

        int currentTrial;
        int currentPhase;

        public formGoNoGo(Participant participant, char goChar, char noGoChar, bool useStimuli, int numberOfPhases) {
            InitializeComponent();
            usingDerivedStimuli = useStimuli;
            this.KeyPreview = true;
            this.p = participant;
            trialData = new List<GoNoGoTrial>();

            random = new Random();
            timers = new List<Timer>();
            interStimulusTimer = new Timer();
            stimulusTimer = new Timer();
            startingTrialsTimer = new Timer();
            inputStopWatch = new Stopwatch();
            timers.Add(interStimulusTimer);
            timers.Add(stimulusTimer);
            timers.Add(startingTrialsTimer);

            interStimulusTimer.Tick += OnInterstimulusTimerTick;
            stimulusTimer.Tick += OnStimulusTimerTick;
            startingTrialsTimer.Tick += OnStartingTrialsTimerTick;

            startingTrialsTimer.Interval = 2000;

            initialGoCharacter = goChar;
            initialNoGoCharacter = noGoChar;
            goCharacter = goChar;
            noGoCharacter = noGoChar; 

            stimuli = new List<PictureBox>();
            try
            {
                nonStimulusImage = Image.FromFile(Application.StartupPath + "\\images\\star.png");
                nonStimulusImage1 = Image.FromFile(Application.StartupPath + "\\images\\star.png");
                nonStimulusImage2 = Image.FromFile(Application.StartupPath + "\\images\\star.png");
            }
            catch
            {
                MessageBox.Show("Check your file @ \\images\\star.png");
                Application.Exit();
            }

            stimuli.Add(pictureBottomRight);
            stimuli.Add(pictureBottomLeft);
            stimuli.Add(pictureTopLeft);
            stimuli.Add(pictureTopRight);

            totalPhases = numberOfPhases;
            currentPhase = 0;
            numberOf1s = 0;

            CheckGoCharacter();

            //SetInterstimulusPictures();
            //showStimuli();
            showInstructions(goCharacter);
            practicing = true;
            try
            {
                ReadInstructionsFromFile(Application.StartupPath + "\\instructions\\goNoGo.rtf");
            }
            catch
            {
                MessageBox.Show("Check instructions file @ \\instructions\\goNoGo.rtf");
                Application.Exit();
            }
            SetUIPositions();
            FullscreenForm();
        }

        private void FullscreenForm() {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void startTesting() {
            currentTrial = 0;
            interStimulusTimer.Interval = 1500;
            stimulusTimer.Interval = 500;
            if (practicing) {
                startPractice();
            } else {
                //InitializeTrials();
                RunTrial();
            }
        }

        private void startPractice() {
           
            practiceTrials = new bool[15 - random.Next(6)];
            for (int i = 0; i < practiceTrials.Length; i++) {
                if (random.Next(2) == 1) {
                    practiceTrials[i] = true;
                } else {
                    practiceTrials[i] = false;
                }
            }
            //showStimuli();
            RunPractice();
        }

        private void RunPractice() {
            
            if (currentTrial >= practiceTrials.Length) {
                PracticeIsOver();
                return;
            }
            if (practiceTrials[currentTrial]) {
                try
                {
                    stimuli[random.Next(4)].Image = Image.FromFile(Application.StartupPath + "\\images\\" + goCharacter + ".png");
                }
                catch
                {
                    MessageBox.Show("Check stimulus file @ \\images\\[whatever your go character is].png");
                    Application.Exit();
                }
            } else {
                try
                {
                    stimuli[random.Next(4)].Image = Image.FromFile(Application.StartupPath + "\\images\\" + noGoCharacter + ".png");
                }
                catch
                {
                    MessageBox.Show("Check stimulus file @ \\images\\[whatever your noGo character is].png");
                    Application.Exit();
                }
            }
            showStimuli();
            stimulusTimer.Start();
            interStimulusTimer.Stop();
            waitingforInput = false;
            currentTrial++;
        }

        private void PracticeIsOver() {
            practicing = false;
            hideStimuli();
            CheckGoCharacter();
            showInstructions(goCharacter);  // PorR QorO
            interStimulusTimer.Stop();
        }

        private void TrialsAreOver() {
            interStimulusTimer.Stop();
            currentTrial = 0;
            currentPhase++;
            numberOf1s = 0;

            if (currentPhase == totalPhases) {
                CheckGoCharacter();
                showInstructions(goCharacter);
            }
        }

        private void RunTrial() {
            hideStimuli();
            if (currentTrial >= trials.Length) {
                //hideStimuli();
                TrialsAreOver();
                return;
            }
            currentTrialData = new GoNoGoTrial();


            if (trials[currentTrial]) {
                try {
                    stimuli[random.Next(4)].Image = Image.FromFile(Application.StartupPath + "\\images\\" + goCharacter + ".png");
                } catch {
                    MessageBox.Show("Check stimulus file @ \\images\\[whatever your go character is].png");
                    Application.Exit();
                }
            } else {

                try {
                    stimuli[random.Next(4)].Image = Image.FromFile(Application.StartupPath + "\\images\\" + noGoCharacter + ".png");
                } catch {
                    MessageBox.Show("Check stimulus file @ \\images\\[whatever your go character is].png");
                    Application.Exit();
                }
            }
            //SetInterstimulusPictures();
            showStimuli();
            waitingforInput = true;
           
            stimulusTimer.Start();
            inputStopWatch.Start();
            interStimulusTimer.Stop();
            currentTrialData.trialNumber = currentTrial;
            currentTrialData.phaseNumber = currentPhase;
        }

        private void InitializeTrials() {

            int temp;
            trials = new bool[TOTAL_TRIALS];
            for (int i = 0; i < TOTAL_TRIALS; i++) {
                trials[i] = true;
            }
            for (int i = 0; i < NEGATIVE_TRIALS; i++) {                                                                   //THIS IS TO GUARANTEE 32 of the 160 trials are false
                if (i == 0) {
                    trials[temp = random.Next(TOTAL_TRIALS)] = false;
                } else {
                    while (!trials[temp = random.Next(TOTAL_TRIALS)]) {    
                    }
                    trials[temp] = false;
                }
            }
            SetInterstimulusPictures();
            showStimuli();
        }

        private void CheckGoCharacter() {

            if (usingDerivedStimuli) {
                switch (currentPhase) {
                    case 0:
                        derivedStimulus = "C";
                        try
                        {
                            initialGoCharacter = 'E';
                            initialNoGoCharacter = 'F';
                            nonStimulusImage1 = Image.FromFile(Application.StartupPath + "\\images\\C1.png");
                            nonStimulusImage2 = Image.FromFile(Application.StartupPath + "\\images\\C2.png");
                            
                        }
                        catch
                        {
                            MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                            Application.Exit();
                        }
                        break;
                    case 1:
                        // same images
                        break;
                    case 2:
                        derivedStimulus = "B";
                        try
                        {
                            initialNoGoCharacter = 'O';
                            initialGoCharacter = 'Q';
                            nonStimulusImage1 = Image.FromFile(Application.StartupPath + "\\images\\B1.png");
                            nonStimulusImage2 = Image.FromFile(Application.StartupPath + "\\images\\B2.png");
                        }
                        catch
                        {
                            MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                            Application.Exit();
                        }
                        break;
                    case 3:
                        // same images
                        break;
                    case 4:
                        derivedStimulus = "A";
                        try
                        {
                            initialGoCharacter = 'J';
                            initialNoGoCharacter = 'U';
                            nonStimulusImage1 = Image.FromFile(Application.StartupPath + "\\images\\A1.png");
                            nonStimulusImage2 = Image.FromFile(Application.StartupPath + "\\images\\A2.png");
                        }
                        catch
                        {
                            MessageBox.Show("Check stimulus files @ \\images\\A1.png - C2.png");
                            Application.Exit();
                        }
                        break;
                    case 5:
                        // same images
                        break;
                }
            }

            switch (currentPhase%2) {
                case 0:
                    goCharacter = initialGoCharacter;
                    noGoCharacter = initialNoGoCharacter;
                    break;
                case 1:
                    goCharacter = initialNoGoCharacter;
                    noGoCharacter = initialGoCharacter;
                    break;
                default:
                    MessageBox.Show("Something is wrong with the phase number");
                    break;
            }
        }

        private void showInstructions(char go) {
            labelTrialInstructions.Text = "PRESS SPACEBAR ONLY WHEN YOU SEE '" + go.ToString() + "'.";
            showingInstructions = true;
            labelTrialInstructions.Visible = true;
            //showStimuli();
        }

        private void hideStimuli() {
            foreach (PictureBox p in stimuli) {
                p.Visible = false;
            }
        }
        private void showStimuli() {
            foreach (PictureBox p in stimuli) {
                if (usingDerivedStimuli) {
                    //SetInterstimulusPictures();
                }
                p.Show();
            }
        }

        private void hideInitialInstructions() {

            richTextBoxInitialInstructions.Hide();
            labelTrialInstructions.Visible = true;
            showingInstructions = true;
        }

        private void hideInstructions() {
            showingInstructions = false;
            labelTrialInstructions.Visible = false;
            
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

        private void SetUIPositions() {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            screen = this.Bounds;
            var width = screen.Width;
            var height = screen.Height;

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, height / 2 - panelStimuli.Height / 2); ;
            richTextBoxInitialInstructions.Location = new Point(width / 2 - richTextBoxInitialInstructions.Width / 2, panelStimuli.Location.Y - 45);
            labelTrialInstructions.Location = new Point(width / 2 - labelTrialInstructions.Width / 2, panelStimuli.Location.Y - 45); 
        }

        private void SetInterstimulusPictures() {
            Image temp;
            if (usingDerivedStimuli) {
                if (numberOf1s < 80) {
                    int tempInt = random.Next(2);
                    if (tempInt == 1) {
                        temp = nonStimulusImage1;
                        tempStimulus = derivedStimulus + "1";
                        numberOf1s++;
                    } else {
                        tempStimulus = derivedStimulus + "2";
                        temp = nonStimulusImage2;
                    }
                } else {
                    tempStimulus = derivedStimulus + "1";
                    temp = nonStimulusImage1;
                }

                foreach (PictureBox pb in stimuli) {
                    pb.Image = temp;
                    pb.Height = 100;
                    pb.Width = 100;
                }
            } else {
                tempStimulus = "n/a";
                foreach (PictureBox pb in stimuli) {
                    pb.Image = nonStimulusImage;
                    pb.Height = 100;
                    pb.Width = 100;
                }
            }
           
        }

        private void ProcessData() {
            if (usingDerivedStimuli)
            {
                p.AddTrialData("ModifiedGoNoGo", trialData);
            }
            else
            {
                p.AddTrialData("GoNoGo", trialData);
            }
            this.Close();
        }

        private void OnStimulusTimerTick(object sender, EventArgs e) {
            SetInterstimulusPictures();
            waitingforInput = false;
            inputStopWatch.Stop();
            interStimulusTimer.Start();
            if (!practicing) {
                if (!currentTrialData.CorrectResponse && !currentTrialData.ErrorOfComission && !trials[currentTrial]) {
                    currentTrialData.CorrectlyWithheld = true;
                }
                if (!currentTrialData.CorrectResponse && !currentTrialData.ErrorOfComission && !currentTrialData.CorrectlyWithheld) {
                    currentTrialData.ErrorOfOmission = true;
                }
            }
            
            stimulusTimer.Stop();
        }

        private void OnInterstimulusTimerTick(object sender, EventArgs e) {
            interStimulusTimer.Stop();
            currentTrial++;
            if (practicing) {
                RunPractice();
            } else {
                currentTrialData.stimulus = tempStimulus;
                trialData.Add(currentTrialData);
                RunTrial();
            }
        }

        private void OnStartingTrialsTimerTick(object sender, EventArgs e)
        {
            startingTrialsTimer.Stop();
            startTesting();
        }

        private void formGoNoGo_Resize(object sender, EventArgs e)
        {
            SetUIPositions();
            panelStimuli.Invalidate();
        }

        private void KillTimers() {
            foreach (Timer t in timers) {
                t.Dispose();
            }
        }

        private void formGoNoGo_FormClosed(object sender, FormClosedEventArgs e) {
            KillTimers();
        }

        private void formGoNoGo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Space)
            {
                if (richTextBoxInitialInstructions.Visible) {
                    hideInitialInstructions();
                    return;
                    
                }

                if (showingInstructions)
                {
                    hideInstructions();

                    SetInterstimulusPictures();
                    showStimuli();
                    InitializeTrials();
                    startingTrialsTimer.Start();
                    //startTesting();
                    
                    return;
                }
                if (waitingforInput)
                {
                    currentTrialData.responseTime = inputStopWatch.ElapsedMilliseconds;
                    inputStopWatch.Stop();
                    inputStopWatch.Reset();
                    waitingforInput = false;
                    if (trials[currentTrial])
                    {
                        currentTrialData.CorrectResponse = true;
                    }
                    else
                    {
                        currentTrialData.ErrorOfComission = true;
                    }
                }
            }
        }

        private void richTextBoxInitialInstructions_KeyDown(object sender, KeyEventArgs e)
        {
            if (showingInstructions)
            {
                hideInitialInstructions();
                return;
            }
        }
        
    }
}
