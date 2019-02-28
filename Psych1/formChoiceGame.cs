using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace Psych1 {
    public partial class formChoiceGame : Form {
        const int tokenOffset = 55;
        int screenWidth;

        #region Members
        Participant p;
        TrialConfig config;
        Random random;

        List<Trial> trialData;
        ChoiceGameTrial currentTrial;

        System.Timers.Timer timerProgressMax1;
        System.Timers.Timer timerProgressMax2;

        System.Timers.Timer interStimulusTimer;
        System.Diagnostics.Stopwatch inputStopwatch;

        TokenController tc;
        System.Timers.Timer tcTimer;
        BackgroundWorker tcBgw;
        private BackgroundWorker bgw; // this handles the waiting for tokens to be done in the background

        Queue<int> delays;
        int[] delayValues;
        int maxDelay;


        bool randomizePositions = false;
        bool waitingforInput;
        bool showingInitialInstructions = true;
        int phaseNumber = 0;
        int trialNumber = -1;
        int blockNumber = -1;
        int delay;
        int trialsPerBlock;
        int numberOfBlocks;

        string blueOrRed;
        bool useOneTrialValueDelta = true;
        int trialValueDelta1;
        int trialValueDelta2;
        int minValue1;
        int minValue2;

        int points;
        int totalPoints;
        int tokens;

        bool buttonRedPracticed = false;
        bool buttonBluePracticed = false;
        bool buttonYellowPracticed = false;
        bool buttonYellowPracticedOnce = false;
        #endregion

        public formChoiceGame(Participant p, TrialConfig c) {
            InitializeComponent();
            random = new Random();

            timerProgressMax2 = new System.Timers.Timer();
            timerProgressMax1 = new System.Timers.Timer();
            timerProgressMax1.Elapsed += OnProgressTimer1Tick;
            timerProgressMax2.Elapsed += OnProgressTimer2Tick;
            timerProgressMax1.Interval = 1000;
            timerProgressMax2.Interval = 1000;
            bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                while (!tc.allResting) {
                    Thread.Sleep(10);
                } // wait till all are at rest
                interStimulusTimer.Start();
            };
            /*tc = new TokenController(screenWidth);
            tcTimer = new System.Timers.Timer();
            tcTimer.Interval = 1000 / 30;
            tcTimer.Elapsed += OnTcTimerTick;
            tcTimer.Start();
            tcBgw = new BackgroundWorker();
            tcBgw.DoWork += delegate {
                while (true) {
                    tc.UpdateLocation();
                    Thread.Sleep(1000 / 80);
                }
            };
            tcBgw.RunWorkerAsync();*/

            roundButtonMax1.SpawnToken += Token;
            roundButtonMax2.SpawnToken += Token;
            roundButtonMin.SpawnToken += Token;
            roundButtonMax1.TokensDone += OnTokensDone;
            roundButtonMax2.TokensDone += OnTokensDone;
            roundButtonMin.TokensDone += OnTokensDone;

            DoubleBuffered = true;
            roundButtonMin.InitializeDefaults(true, Color.Yellow, null, 100, 200, "0");
            roundButtonMax1.InitializeDefaults(true, Color.Red, timerProgressMax1, 200, 200, "1");
            roundButtonMax2.InitializeDefaults(true, Color.Blue, timerProgressMax2, 200, 200, "2");
            trialData = new List<Trial>();

            this.p = p;
            this.config = c;

            delayValues = c.delays.ToArray();
            maxDelay = delayValues.Max();

            inputStopwatch = new System.Diagnostics.Stopwatch();
            interStimulusTimer = new System.Timers.Timer();
            interStimulusTimer.Interval = 1500;
            interStimulusTimer.Elapsed += OnInterstimulusTimerTick;

            this.KeyPreview = true;

            ReadInstructionsFromFile(Application.StartupPath + "//Instructions//GameInstructions.rtf");

            
            SetUIPositions();
            //FullscreenForm();
        }

        private void StartPractice() {
            tcTimer = new System.Timers.Timer();
            tcTimer.Interval = 1000 / 30;
            tcTimer.Elapsed += OnTcTimerTick;
            InitializeTokenController();
            tcBgw = new BackgroundWorker();
            tcBgw.DoWork += delegate {
                while (true) {
                    tc.UpdateLocation();
                    Thread.Sleep(1000 / 80);
                }
            };
            //tcBgw.RunWorkerAsync(); // maybe not the best place to put this runonce code.. we shall see

            labelMax1Instructions.Text = "Click this button to earn " + config.maxReward + " points."; 
            labelMax2Instructions.Text = "Click this button to earn " + config.maxReward + " points.";
            labelMinInstructions.Text = "Click this button to earn " + config.maxReward + " points.";
            panelStimuli.Show();
            labelInstructions.Show();
            labelPhase.Show();
            delay = 8;
            minValue1 = config.maxReward / 2;
            minValue2 = config.maxReward / 2;
            progressMax1.Maximum = delay;
            progressMax1.Minimum = 0;
            progressMax1.Value = delay;
            progressMax2.Maximum = delay;
            progressMax2.Minimum = 0;
            progressMax2.Value = delay;
            RunPractice();
        }
        private void StartTrials() {
            points = 0;
            totalPoints = 0;
            phaseNumber = 1;
            labelPhase.Text = "MAIN ROUND";
            labelInstructions.Text = "Earn as many points as you can.";
            labelMax1Instructions.Hide();
            labelMinInstructions.Hide();
            labelMax2Instructions.Hide();
            labelTotalPoints.Text = "0";
            labelTokens.Text = "0";
            labelPoints.Text = "0";

            InitializeTrials();
            if (blockNumber < numberOfBlocks) {
                RunTrial();
            }
            
        }
        private void RunPractice() {

            MethodInvoker inv = delegate {
                SetButtons();
                roundButtonMax1.Enabled = true;
                roundButtonMax2.Enabled = true;
                roundButtonMin.Enabled = true;
                if (buttonRedPracticed) {
                roundButtonMax1.Enabled = false;
                progressMax1.Hide();
            }
            if (buttonBluePracticed) {
                roundButtonMax2.Enabled = false;
                progressMax2.Hide();
            }
            if (buttonYellowPracticed) {
                roundButtonMin.Enabled = false;
                progressMin.Hide();
            }
                if (!buttonYellowPracticed && buttonYellowPracticedOnce) {
                    roundButtonMax1.Enabled = false;
                    roundButtonMax2.Enabled = false;
                }
                if (buttonBluePracticed && buttonRedPracticed && buttonYellowPracticed) {
                    roundButtonMax1.Hide();
                    roundButtonMax2.Hide();
                    roundButtonMin.Hide();
                    labelInstructions.Text = "";
                    labelPhase.Text = "";
                    labelTokens.Text = "";
                    roundButtonMax1.Enabled = true;
                    roundButtonMax2.Enabled = true;
                    roundButtonMin.Enabled = true;
                    StartTrials();
                    return;
                } else {
                    waitingforInput = true;
                }
            };
            Invoke(inv);
        }
        private void RunTrial() {
            roundButtonMax1.Hide();
            roundButtonMax2.Hide();
            roundButtonMin.Hide();
            progressMin.Hide();
            progressMax1.Hide();
            progressMax2.Hide();

            trialNumber++;
            currentTrial = new ChoiceGameTrial();

            if (trialNumber >= trialsPerBlock) {
                if (blockNumber < numberOfBlocks) {
                    InitializeBlock();
                    trialNumber++; // increment back to 0
                }
                if (delay == -1) {
                    /*if (phaseNumber == 1) {
                        blockNumber = -1;
                        phaseNumber++;
                        labelPhase.Text = "LEVEL 2";
                        InitializeTrials();
                        trialNumber++; // increment back to 0
                    } else if (phaseNumber == 2) {*/
                        tcTimer.Stop();
                        timerProgressMax1.Stop();
                        timerProgressMax2.Stop();
                        interStimulusTimer.Stop();
                        p.AddTrialData("GameTrial", trialData);
                        Thread.Sleep(1000);
                        this.Close();
                    //}
                }
            }

            inputStopwatch.Reset();
            inputStopwatch.Stop();

            SetButtons();
            this.Refresh();
            waitingforInput = true;

            //labelControlsNum.Text = blockNumber.ToString();
            //labelTokenNum.Text = trialNumber.ToString();

            inputStopwatch.Start();
        }

        private void InitializeTrials() {
            
            randomizePositions = config.randomizePositions;
            panelStimuli.Show();
            tokens = 0;
            points = 0;
            labelPoints.Text = "0";
            this.trialsPerBlock = config.trialsPerBlock;
            this.numberOfBlocks = config.delays.Count;
            int[] temp = config.delays.ToArray();
            delays = new Queue<int>();
            foreach(int i in temp) {
                delays.Enqueue(i);
            }
            if (config.useSeparateRedBlueDeltas) {
                useOneTrialValueDelta = false;
            }
            if (config.randomizeBlocks) {
                RandomizeBlocks();
            }
            InitializeBlock();
        }
        private void InitializeBlock() {
            tc.ClearTokens();
            InitializeTokenController();
            tokens = 0;
            labelTokens.Text = "0";
            blockNumber++;
            trialNumber = -1;
            this.minValue1 = config.maxReward / 2;
            this.minValue2 = config.maxReward / 2;
            this.trialValueDelta1 = minValue1; // is cut in half before use in input trapping method
            this.trialValueDelta2 = minValue2;
            roundButtonMin.Reset();
            roundButtonMax1.Reset();
            roundButtonMax2.Reset();
            this.delay = -1;
            if (delays.Count > 0) {
                this.delay = delays.Dequeue();
            } else {
                return;
            }

            labelTokens.Text = "";
            progressMax1.Maximum = maxDelay;
            progressMax1.Minimum = 0;
            progressMax1.Value = delay;
            progressMax2.Maximum = maxDelay;
            progressMax2.Minimum = 0;
            progressMax2.Value = delay;

            Thread.Sleep(2000);
            labelTokens.Text = "0";

        }
        private void InitializeTokenController()
        {
            Point locationOnForm = panelStimuli.FindForm().PointToClient(
   panelStimuli.Parent.PointToScreen(panelStimuli.Location));
            tc = new TokenController(locationOnForm.Y);
            tcTimer.Start();
            
        }

        private void SetButtons() {
            if (random.Next(2) == 1) {
                blueOrRed = "RED";
                roundButtonMin.SetAmount(minValue1);
            } else {
                blueOrRed = "BLUE";
                roundButtonMin.SetAmount(minValue2);
            }
            progressMax1.Value = delay;
            progressMax2.Value = delay;

            roundButtonMin.SetDelay("Now", 0);
            roundButtonMax1.SetAmount(config.maxReward);
            roundButtonMax2.SetAmount(config.maxReward);
            string tempString = "in " + delay + " " + config.delayUnits.ToString();
            if (delay == 1) {
                tempString = tempString.TrimEnd('s');
            }
            roundButtonMax1.SetDelay(tempString, delay);
            roundButtonMax2.SetDelay(tempString, delay);
            if (randomizePositions) {
                RandomizePositions();
            }

            if (/*phaseNumber == 2 || */phaseNumber == 0) {
                roundButtonMax1.Show();
                roundButtonMax2.Show();
                progressMax1.Show();
                progressMax2.Show();
            } else if (phaseNumber == 1) {
                if (blueOrRed == "RED") {
                    roundButtonMax1.Show();
                    progressMax1.Show();
                    
                } else if (blueOrRed == "BLUE"){
                    roundButtonMax2.Show();
                    progressMax2.Show();
                }
            } 
            roundButtonMin.Show();
            progressMin.Show();

            roundButtonMax1.Refresh();
            roundButtonMax2.Refresh();
            roundButtonMin.Refresh();
        }
        private void RandomizeBlocks() {
            Random random = new Random();
            List<int> tempList = new List<int>();

            foreach (int i in delays) {
                tempList.Add(i);
            }
            tempList.Shuffle(random);
            delays = new Queue<int>();

            foreach (int i in tempList) {
                delays.Enqueue(i);
            }
        }
        private void RandomizePositions() {
            List<Point> locations = new List<Point>();
            Point offset = new Point(Math.Abs(roundButtonMin.Location.Y - roundButtonMax1.Location.Y), Math.Abs(roundButtonMin.Location.Y - roundButtonMax1.Location.Y));
            locations.Add(new Point(roundButtonMin.Location.X - offset.X, roundButtonMin.Location.Y - offset.Y));
            locations.Add(roundButtonMax1.Location);
            locations.Add(roundButtonMax2.Location);
            locations.Shuffle(random);
            Queue<Point> loq = new Queue<Point>();
            foreach (Point p in locations) {
                loq.Enqueue(p);
            }
            Point temp = loq.Dequeue();


            roundButtonMin.Location = new Point(temp.X + offset.X, temp.Y + offset.Y);
            progressMin.Location = new Point(temp.X, temp.Y + 260);
            roundButtonMax1.Location = loq.Dequeue();
            progressMax1.Location = new Point(roundButtonMax1.Location.X, temp.Y + 260);
            roundButtonMax2.Location = loq.Dequeue();
            progressMax2.Location = new Point(roundButtonMax2.Location.X, temp.Y + 260);
            roundButtonMax2.Refresh();
            progressMax2.Refresh();
            roundButtonMax1.Refresh();
            progressMax1.Refresh();
            roundButtonMin.Refresh();
            progressMin.Refresh();
        }
        
        private void Token(object sender, TokenEventArgs e) {
            MethodInvoker inv = delegate {
                tokens += e.numTokens;
                points += e.numTokens;
                totalPoints += e.numTokens;
                labelTokens.Text = tokens.ToString();
                labelPoints.Text = points.ToString();
                labelTotalPoints.Text = totalPoints.ToString();
                labelTotalPoints.Refresh();
                labelTotalPointsText.Refresh();
                labelTokens.Refresh();
                RoundButton tempButton = (RoundButton)sender;
                for (int i = 0; i < e.numTokens; i++) {
                    Point p = new Point(panelStimuli.PointToScreen(tempButton.Location).X + (tempButton.Width / 2), panelStimuli.PointToScreen(tempButton.Location).Y - tokenOffset);
                    Token temp;
                    temp = tc.AddToken(p);
                    temp.Click += new EventHandler(token_MouseClick);
                    temp.Parent = this;
                    temp.BringToFront();
                }
            };
            this.Invoke(inv);
            
            
        }
        private void OnTokensDone(object sender, TokenEventArgs e) {
            tc.AllResting();
            bgw.RunWorkerAsync(); 
        }

        private void form_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (showingInitialInstructions) {
                    showingInitialInstructions = false;
                    richTextBoxInitialInstructions.Hide();
                    StartPractice();
                }
            }
        }
        private void button_Click(object sender, EventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                Color tempColor = (sender as RoundButton).backgroundColor;
                currentTrial.AddClick(tempColor.ToString() + "Button", time);
                if (!waitingforInput) {
                    return;
                }
                waitingforInput = false;
                ProcessGameInput((sender as RoundButton), time, tempColor);
            }
            if (phaseNumber == 0) {
                ProcessPracticeInput(sender);
            }
        }
        private void ProcessGameInput(RoundButton clicked, long time, Color color) {
            if (useOneTrialValueDelta) {
                trialValueDelta1 /= 2;
            } else {
                if (blueOrRed == "RED") {
                    trialValueDelta1 /= 2;
                } else if (blueOrRed == "BLUE") {
                    trialValueDelta2 /= 2;
                }
            }

            currentTrial.phaseNumber = phaseNumber;
            currentTrial.trialNumber = trialNumber;
            currentTrial.trialBlock = blockNumber;
            currentTrial.redMagnitude = config.maxReward;
            currentTrial.blueMagnitude = config.maxReward;
            if (blueOrRed == "BLUE") {
                currentTrial.yellowMagnitude = minValue2;
            } else {
                currentTrial.yellowMagnitude = minValue1;
            }
            currentTrial.choiceDelay = time;
            currentTrial.colorChosen = color.ToString();
            currentTrial.choiceMagnitude = clicked.amountInt;
            currentTrial.redOrBlue = blueOrRed;
            currentTrial.delayUnits = config.delayUnits.ToString();
            currentTrial.delay = delay.ToString();

            if (clicked.amountInt == config.maxReward) {
                clicked.DoTokens(config.maxReward);
                if (useOneTrialValueDelta) {
                    minValue1 += trialValueDelta1;
                } else {
                    if (blueOrRed == "RED") {
                        minValue1 += trialValueDelta1;
                    } else if (blueOrRed == "BLUE") {
                        minValue2 += trialValueDelta2;
                    }
                }
            } else if (clicked.amountInt == minValue1 || clicked.amountInt == minValue2) {
                if (clicked.amountInt == minValue1) {
                    clicked.DoTokens(minValue1);
                } else {
                    clicked.DoTokens(minValue2);
                }

                if (useOneTrialValueDelta) {
                    minValue1 -= trialValueDelta1;
                } else {
                    if (blueOrRed == "RED") {
                        minValue1 -= trialValueDelta1;
                    } else if (blueOrRed == "BLUE") {
                        minValue2 -= trialValueDelta2;
                    }
                }

                //interStimulusTimer.Start(); // Start timer for yellow button clicked
            } else {
                MessageBox.Show("Something went wrong calculating the min/max values");
                Application.Exit();
            }
            trialData.Add(currentTrial);

        }
        private void ProcessPracticeInput(object sender) {
            if (!waitingforInput) {
                return;
            }
            waitingforInput = false;
            if ((sender as RoundButton).amountInt == config.maxReward) {
                (sender as RoundButton).DoTokens(config.maxReward);
                if ((sender as RoundButton).number == "1") {
                    buttonRedPracticed = true;
                    roundButtonMax2.Enabled = false;
                    roundButtonMin.Enabled = false;
                } else if ((sender as RoundButton).number == "2") {
                    buttonBluePracticed = true;
                    roundButtonMax1.Enabled = false;
                    roundButtonMin.Enabled = false;
                }
            } else if ((sender as RoundButton).amountInt == minValue1) {
                (sender as RoundButton).DoTokens(minValue1);
                if (buttonYellowPracticedOnce) {
                    buttonYellowPracticed = true;
                }
                buttonYellowPracticedOnce = true;
                roundButtonMax1.Enabled = false;
                roundButtonMax2.Enabled = false;
                //interStimulusTimer.Start();
            }
        }
        
        private void OnProgressTimer1Tick(object sender, EventArgs e) {
            progressMax1.Value--;
            if (progressMax1.Value < 0) {
                timerProgressMax1.Stop();
                timerProgressMax2.Stop();
            }
        }
        private void OnProgressTimer2Tick(object sender, EventArgs e) {
            progressMax2.Value--;
            if (progressMax1.Value < 0) {
                timerProgressMax1.Stop();
                timerProgressMax2.Stop();
            }
        }
        private void OnInterstimulusTimerTick(object sender, EventArgs e) {
            interStimulusTimer.Stop();
            tc.UpdateStaticTokens();
            if (phaseNumber == 0) {
                RunPractice();

            } else {
                MethodInvoker inv = delegate {
                    RunTrial();
                };
                this.Invoke(inv);
            }
        }

        private void bg_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Background", time);
            }
        }
        private void instructions_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Background", time);
            }
        }
        private void pointsLabel_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Points Label", time);
            }
        }
        private void labelTotalPointsText_Click(object sender, EventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Total Points Label", time);
            }
        }
        private void progressBarRed_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Red Progress Bar", time);
            }
        }
        private void progressBarBlue_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Blue Progress Bar", time);
            }
        }
        private void progressBarYellow_MouseClick(object sender, MouseEventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Yellow Progress Bar", time);
            }
        }
        private void token_MouseClick(object sender, EventArgs e) {
            if (phaseNumber != 0) {
                long time = inputStopwatch.ElapsedMilliseconds;
                currentTrial.AddClick("Token", time);
            }
        }

        private void formChoiceGame_FormClosing(object sender, FormClosingEventArgs e) {
            timerProgressMax1.Dispose();
            timerProgressMax2.Dispose();
            tcTimer.Stop();
            tcTimer.Dispose();
        }
        private void formChoiceGame_Resize(object sender, EventArgs e) {
            SetUIPositions();
        }
        private void OnTcTimerTick(object sender, EventArgs e) {
            //tc.UpdateLocation();
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;
            string tempString = "";

            foreach (ProcessThread thread in currentThreads) {
                tempString += thread.Id.ToString() + Environment.NewLine;
            }
            
            if (this.InvokeRequired) {
                MethodInvoker inv = delegate {
                    // label4.Text = tempString; // THIS IS THREAD NUMBERS FOR ACTIVE THREADS FOR  DEBUG
                    tc.Redraw();
                };
                this.Invoke(inv);
            }
        }

        private void SetUIPositions() {
            var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            screen = this.Bounds;
            var width = screen.Width;
            var height = screen.Height;

            panelStimuli.Location = new Point(width / 2 - panelStimuli.Width / 2, 15); ;
            richTextBoxInitialInstructions.Location = new Point(width / 2 - richTextBoxInitialInstructions.Width / 2, panelStimuli.Location.Y + 45);

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

        
    }
}
