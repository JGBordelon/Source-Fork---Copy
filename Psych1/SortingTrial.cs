using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psych1
{
    class SortingTrial : Trial
    {
        public List<Stimuli> A1;
        public List<Stimuli> A2;

        public SortingTrial()
        {
            A1 = new List<Stimuli>();
            A2 = new List<Stimuli>();
        }
    }
}
