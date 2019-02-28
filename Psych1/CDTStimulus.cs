using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    class CDTStimulus {
        public Stimuli stimulus { get; private set; }
        public Stimuli correct { get; private set; }
        public Stimuli wrong { get; private set; }

        public CDTStimulus(Stimuli stimulus, Stimuli correct, Stimuli wrong) {
            this.stimulus = stimulus;
            this.correct = correct;
            this.wrong = wrong;
        }
    }
}
