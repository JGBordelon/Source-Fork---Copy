using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    public class GoNoGoTrial : Trial {
        public string stimulus; // This is the non go/nogo stimulus for the modified trials
        public long responseTime;
        public bool CorrectResponse;
        public bool CorrectlyWithheld;
        public bool ErrorOfOmission;
        public bool ErrorOfComission;

        public GoNoGoTrial() {
            responseTime = 0;
            stimulus = "n/a";
        }
    }
}
