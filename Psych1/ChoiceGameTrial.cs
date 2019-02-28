using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psych1 {
    class ChoiceGameTrial : Trial {
        public int trialBlock;
        public int yellowMagnitude;
        public int redMagnitude;
        public int blueMagnitude;
        public int choiceMagnitude;
        public string colorChosen;
        public long choiceDelay;
        public string redOrBlue;
        public string delay;
        public string delayUnits;
        public List<Click> clicks;

        public ChoiceGameTrial() {
            clicks = new List<Click>();
        }

        public void AddClick(string clicked, long time) {
            clicks.Add(new Click(clicked, time));
        }
    }
}
