using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psych1 {
    public class Click {
        public string clicked { get; private set; }
        public long time { get; private set; }

        public Click(string c, long t) {
            clicked = c;
            time = t;
        }
    }
}
