using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Psych1 {
    public partial class formDelayDiscount : Form {
        Participant p;
        TrialConfig config;

        List<Trial> trialData;
        DelayDiscountTrial currentTrial;

        Timer interStimulusTimer;
        System.Diagnostics.Stopwatch inputStopwatch;

        Queue<int> delays;

        bool showingInstructions = true;
        int trialNumber = -1;
        int blockNumber = -1;
        int delay;
        int trialsPerBlock;
        int numberOfBlocks;
        int trialValueDelta;
        int minValue;

        public formDelayDiscount(Participant p, TrialConfig c) {
            InitializeComponent();
            DoubleBuffered = true;
            roundButtonMax.InitializeDefaults(false);
            roundButtonMin.InitializeDefaults(false);
            trialData = new List<Trial>();

            this.p = p;
            this.config = c;
            inputStopwatch = new System.Diagnostics.Stopwatch();
            interStimulusTimer = new Timer();
            interStimulusTimer.Interval = 1500;

            this.KeyPreview = true;

            ReadInstructionsFromFile(Application.StartupPath + "//Instructions//TestInstructions.rtf");
            SetUIPositions();
            FullscreenForm();
        }

        private void StartTrials() {
            InitializeTrials();
            if(blockNumber < numberOfBlocks) {
                RunTrial();
            }
            //trialNumber = 0; // hack  =(
        }

        private void RunTrial() {
            panelStimuli.Hide();
            trialNumber++;
            currentTrial = new DelayDiscountTrial();

            if(trialNumber >= trialsPerBlock) {
                InitializeBlock();
                trialNumber++;
            }

            inputStopwatch.Reset();
            inputStopwatch.Stop();
            roundButtonMin.SetAmount(minValue);
            roundButtonMin.SetDelay("Now", 0);
            roundButtonMax.SetAmount(config.maxReward);
            string tempString = "in " + delay + " " + config.delayUnits.ToString();
            if (delay == 1) {
                tempString = tempString.TrimEnd('s');
            }
            roundButtonMax.SetDelay(tempString, delay);
            panelStimuli.Show();
            inputStopwatch.Start();
        }

        private void InitializeTrials() {
            
            this.trialsPerBlock = config.trialsPerBlock;
            this.numberOfBlocks = config.delays.Count;
            delays = config.delays;

            if (config.randomizeBlocks)
            {
                Random random = new Random();
                List<int> tempList = new List<int>();
                
                foreach (int i in delays)
                {
                    tempList.Add(i);
                }
                tempList.Shuffle(random);
                delays = new Queue<int>();

                foreach (int i in tempList) {
                    delays.Enqueue(i);
                }

            }
            InitializeBlock();
        }

        private void InitializeBlock() {
            blockNumber++;
            trialNumber = -1;
            this.minValue = config.maxReward / 2;
            this.trialValueDelta = minValue; // is cut in half before use in input trapping method
            roundButtonMax.Reset();
            roundButtonMin.Reset();
            roundButtonMin.displayText = true;
            roundButtonMax.displayText = true;
            if (delays.Count > 0) {
                this.delay = config.delays.Dequeue();
            }
            else { 
                p.AddTrialData("DelayDiscount", trialData);
                this.Close();
            }
        }

        private void FullscreenForm() {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public void ReadInstructionsFromFile(string fileName) {
            if (File.Exists(fileName)) {
                richTextBoxInitialInstructions.LoadFile(fileName);
            } else {
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

        }

        private void formDelayDiscount_Resize(object sender, EventArgs e) {
            SetUIPositions();
        }

        private void roundButton_Click(object sender, EventArgs e) {
            long time = inputStopwatch.ElapsedMilliseconds;
            trialValueDelta /= 2;

            currentTrial.trialNumber = trialNumber;
            currentTrial.trialBlock = blockNumber;
            currentTrial.maxMagnitude = config.maxReward;
            currentTrial.leftMagnitude = minValue;
            currentTrial.choiceDelay = time;
            currentTrial.choiceMagnitude = (sender as RoundButton).amountInt;

            if ((sender as RoundButton).amountInt == config.maxReward) {
                minValue += trialValueDelta;
                
            } else if((sender as RoundButton).amountInt == minValue) {
                minValue -= trialValueDelta;
                
            } else {
                MessageBox.Show("Something went wrong calculating the min/max values");
                Application.Exit();
            }
            trialData.Add(currentTrial);
            RunTrial();
        }

        private void formDelayDiscount_KeyDown(object sender, KeyEventArgs e) {
            

            if (e.KeyCode == Keys.Space) {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (showingInstructions) {
                    showingInstructions = false;
                    richTextBoxInitialInstructions.Hide();
                    StartTrials();
                }
            }
        }

        
    }
}
