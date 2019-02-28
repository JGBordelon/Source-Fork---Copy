using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace Psych1
{
    public partial class formStartExperiment : Form
    {
        Participant p;
        Form currentTrial;
        Stack<Form> trials;
        TrialConfig config = new TrialConfig();
        TrialConfig gameConfig = new TrialConfig();

        public formStartExperiment()
        {
            InitializeComponent();
            ReadConfig();
            ReadGameConfig();
        }

        private void ReadConfig() {
            string path = null;
            try {
                path = Application.StartupPath + "\\config\\config.txt";

                using (CsvFileReader reader = new CsvFileReader(path)) {
                    CsvRow row = new CsvRow();
                    reader.ReadRow(row);
                    if (row[0] != "MAX_REWARD" || row[1] != "DELAY_UNITS" || row[2] != "DELAY0" || row[3] != "DELAY1"
                        || row[4] != "DELAY2" || row[5] != "DELAY3" || row[6] != "DELAY4"
                        || row[7] != "RANDOM?" || row[8] != "TRIALS_PER_BLOCK") {
                        MessageBox.Show("Please quit the program and ensure that your input config is configured correctly for this experiment.");
                    }
                    reader.ReadRow(row);
                    int.TryParse(row[0].ToString(), out config.maxReward);
                    int tempInt = 0;

                    config.delayUnits = (DelayUnits) Enum.Parse(typeof(DelayUnits), row[1].ToString());

                    for (int i = 0; i < 5; i++) {
                        tempInt = int.Parse(row[i + 2].ToString());
                        if (tempInt >= 0) {
                            config.AddDelay(tempInt);
                        }
                    }
                    string tempString = row[7].ToString();
                    config.randomizeBlocks = bool.Parse(tempString);
                    config.trialsPerBlock = int.Parse(row[8]);  
                }
            } catch {
                MessageBox.Show("Check file @ \\config\\config.txt");
                Application.Exit();
            }
        }

        private void ReadGameConfig() {
            string path = null;
            try {
                path = Application.StartupPath + "\\config\\gameConfig.txt";

                using (CsvFileReader reader = new CsvFileReader(path)) {
                    CsvRow row = new CsvRow();
                    reader.ReadRow(row);
                    if (row[0] != "MAX_REWARD" || row[1] != "DELAY_UNITS" || row[2] != "DELAY0" || row[3] != "DELAY1"
                        || row[4] != "DELAY2" || row[5] != "DELAY3" || row[6] != "DELAY4"
                        || row[7] != "RANDOM?" || row[8] != "TRIALS_PER_BLOCK" || row[9] != "RANDOMIZE_POSITIONS"
                        || row[10] != "USE_SEPARATE_BLUE_RED_DELTAS") {
                        MessageBox.Show("Please quit the program and ensure that your input config is configured correctly for this experiment.");
                    }
                    reader.ReadRow(row);
                    int.TryParse(row[0].ToString(), out gameConfig.maxReward);
                    int tempInt = 0;

                    gameConfig.delayUnits = (DelayUnits)Enum.Parse(typeof(DelayUnits), row[1].ToString());

                    for (int i = 0; i < 5; i++) {
                        tempInt = int.Parse(row[i + 2].ToString());
                        if (tempInt >= 0) {
                            gameConfig.AddDelay(tempInt);
                        }
                    }
                    string tempString = row[7].ToString();
                    gameConfig.randomizeBlocks = bool.Parse(tempString);
                    gameConfig.trialsPerBlock = int.Parse(row[8]);
                    gameConfig.randomizePositions = bool.Parse(row[9]);
                    gameConfig.useSeparateRedBlueDeltas = bool.Parse(row[10]);
                }
            } catch {
                MessageBox.Show("Check file @ \\config\\config.txt");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Participant();
            trials = new Stack<Form>();

            if (textBoxComputerID.Text != "" && textBoxParticipantID.Text != "")
            {
                p.computerID = textBoxComputerID.Text;
                p.participantID = textBoxParticipantID.Text;

                if (CheckDatabaseForParticipant())
                {
                    MessageBox.Show("That User ID already exists in the database. Please use another.");

                    return;
                }
                formDelayDiscount trial1 = new formDelayDiscount(p, config);
                formChoiceGame trial2 = new formChoiceGame(p, gameConfig);
                formClosing trial6 = new formClosing();
                trials.Push(trial6);
                if (radioButtonRandom.Checked) {
                    Random random = new Random();
                    if(random.Next(2) == 1) {
                        trials.Push(trial2);
                        trials.Push(trial1);
                    } else {
                        trials.Push(trial1);
                        trials.Push(trial2);
                    }
                } else {
                    trials.Push(trial2);
                    trials.Push(trial1);
                }
                RunTrial();
 
            }
        }

        public void RunTrial()
        {
            if (trials.Count > 0)
            {
                currentTrial = trials.Pop();
                currentTrial.FormClosed += new FormClosedEventHandler(OnTrialEnd);
                if (currentTrial is formClosing)
                {
                    WriteData();
                }
                currentTrial.Show();
                return;
            }
            
           return;

        }

        private void OnTrialEnd(object sender, EventArgs e)
        {
            currentTrial.FormClosed -= OnTrialEnd;
            RunTrial();
        }

        private void WriteData()
        {
            DataWriter dw = new DataWriter(p);
            dw.WriteData();
        }

        private bool CheckDatabaseForParticipant()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Psych"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from tblParticipants where fldParticipantID = @ID", con);
                OleDbParameter param = new OleDbParameter();
                param.ParameterName = "@ID";
                param.Value = textBoxParticipantID.Text;
                cmd.Parameters.Add(param);
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
        }

        private void buttonWriteData_Click(object sender, EventArgs e)
        {
            WriteData();
        }
    }
}
