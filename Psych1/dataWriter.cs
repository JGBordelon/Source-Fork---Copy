using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Psych1
{
    public class DataWriter
    {
        OleDbCommand getPrimaryKey; 
        string connectionString;
        Participant p;
        Dictionary<string, IEnumerable<Trial>> allTrials;

        public DataWriter(Participant participant)
        {
            getPrimaryKey = new OleDbCommand("SELECT @@IDENTITY");
            p = participant;
            connectionString = ConfigurationManager.ConnectionStrings["Psych"].ConnectionString;
            allTrials = p.GetAllTrials();
        }
        
        public void WriteData() {
            try {
                using (OleDbConnection con = new OleDbConnection(connectionString)) {
                    con.Open();
                    getPrimaryKey.Connection = con;

                    try { CreateParticipantRecord(con);
                    } catch {
                        MessageBox.Show("Problem with creating Participant Record");
                    }
                    try {
                        CreateDelayDiscountTrialRecords(con);
                    } catch {
                        MessageBox.Show("Problem with creating DD Trial Records");
                    }
                    try {
                        CreateGameTrialRecords(con);
                    } catch {
                        MessageBox.Show("Problem with creating Game Records");
                    }
                }
            } catch {
                MessageBox.Show("Database Not Found");
            }

        }


        private void CreateParticipantRecord(OleDbConnection con)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO tblParticipants ([fldParticipantID], [fldComputerID]) VALUES (@fldParticipantID, @fldComputerID)";
            cmd.Parameters.AddRange(new OleDbParameter[]
           {
               new OleDbParameter("@fldParticipantID", p.participantID),
               new OleDbParameter("@fldComputerID", p.computerID), 
           });
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        
        private void CreateDelayDiscountTrialRecords(OleDbConnection con)
        {
            if (!allTrials.ContainsKey("DelayDiscount"))
            {
                return;
            }
            List<Trial> trials = (List<Trial>)allTrials["DelayDiscount"];

            foreach (Trial tp in trials)
            {
                DelayDiscountTrial t = (DelayDiscountTrial)tp;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO tblDelayedRewardTrials ([fldParticipantID], [fldTrialNumber], "
                    + "[fldTrialBlock], [fldResponseTime], [fldMaxReward],  [fldLeftMagnitude], "
                    + "[fldChoiceMagnitude]) "
                + "VALUES (@fldParticipantID, @fldTrialNumber, @fldTrialBlock, @fldResponseTime, "
                + "@fldMaxReward, @fldLeftMagnitude, @fldChoiceMagnitude)";
                cmd.Parameters.AddRange(new OleDbParameter[]
           {
               new OleDbParameter("@fldParticipantID", p.participantID),
               new OleDbParameter("@fldTrialNumber", t.trialNumber),
               new OleDbParameter("@fldTrialBlock", t.trialBlock),
               new OleDbParameter("@fldResponseTime", t.choiceDelay),
               new OleDbParameter("@fldMaxReward", t.maxMagnitude),
               new OleDbParameter("@fldLeftMagnitude", t.leftMagnitude),
               new OleDbParameter("@fldChoiceMagnitude", t.choiceMagnitude)
           });
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }

        private void CreateGameTrialRecords(OleDbConnection con) {
            if (!allTrials.ContainsKey("GameTrial")) {
                return;
            }
            List<Trial> trials = (List<Trial>)allTrials["GameTrial"];

            foreach (Trial tp in trials) {
                ChoiceGameTrial t = (ChoiceGameTrial)tp;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO tblGameTrials ([fldParticipantID], [fldTrialNumber], "
                    + "[fldTrialBlock], [fldPhaseNumber], [fldYellowMagnitude],  [fldBlueMagnitude], "
                    + "[fldRedMagnitude], [fldColorChosen], [fldResponseTime], [fldBlueOrRed], [fldDelay], [fldDelayUnits]) "
                + "VALUES (@fldParticipantID, @fldTrialNumber, @fldTrialBlock, @fldPhaseNumber, "
                + "@fldYellowMagnitude, @fldBlueMagnitude, @fldRedMagnitude, @fldColorChosen, "
                + "@fldResponseTime, @fldBlueOrRed, @fldDelay, @fldDelayUnits)";
                cmd.Parameters.AddRange(new OleDbParameter[]
           {
               new OleDbParameter("@fldParticipantID", p.participantID),
               new OleDbParameter("@fldTrialNumber", t.trialNumber),
               new OleDbParameter("@fldTrialBlock", t.trialBlock),
               new OleDbParameter("@fldPhaseNumber", t.phaseNumber),
               new OleDbParameter("@fldYellowMagnitude", t.yellowMagnitude),
               new OleDbParameter("@fldBlueMagnitude", t.blueMagnitude),
               new OleDbParameter("@fldRedMagnitude", t.redMagnitude),
               new OleDbParameter("@fldColorChosen", t.colorChosen),
               new OleDbParameter("@fldResponseTime", t.choiceDelay),
               new OleDbParameter("@fldBlueOrRed", t.redOrBlue),
               new OleDbParameter("@fldDelay", t.delay),
               new OleDbParameter("@fldDelayUnits", t.delayUnits)
           });
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                string primaryKey = getPrimaryKey.ExecuteScalar().ToString();

                List<Click> clicks = t.clicks;
                if (clicks == null) {
                    break;
                }

                foreach (Click c in clicks) {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "INSERT INTO tblGameClicks ([fldParticipantID], [fldGameID], [fldTime], [fldObject]) "
                        + "VALUES (@fldParticipantID, @fldGameID, @fldTime, @fldObject)";
                    cmd.Parameters.AddRange(new OleDbParameter[]
           {
               new OleDbParameter("@fldParticipantID", p.participantID), 
               new OleDbParameter("@fldGameID", primaryKey),
               new OleDbParameter("@fldTime", c.time),
               new OleDbParameter("@fldObject", c.clicked)
           });
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
