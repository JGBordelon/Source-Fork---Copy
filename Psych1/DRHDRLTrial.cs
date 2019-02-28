using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    public class DRHDRLTrial : Trial {
        public string DRHDRL;
        public int points;
        public Dictionary<int, List<long>> keyPresses; // key is trial number, value List of keypresses is milliseconds since trial start

        public DRHDRLTrial() {
            keyPresses = new Dictionary<int, List<long>>();
        }

        public List<long> GetKeyPresses(int trialNumber)
        {
            return keyPresses[trialNumber];
        }
    }
}
