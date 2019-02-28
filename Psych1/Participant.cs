using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    public class Participant {
        public string participantID;
        public string computerID;
        private Dictionary<string, IEnumerable<Trial>> allTrials;

        public Participant() {
            allTrials = new Dictionary<string, IEnumerable<Trial>>();  // phase name, trial data
        }

        public void AddTrialData(string phaseName, IEnumerable<Trial> t) {
            allTrials.Add(phaseName, t);
        }

        public Dictionary<string, IEnumerable<Trial>> GetAllTrials() {
            return allTrials;
        }
    }
}

