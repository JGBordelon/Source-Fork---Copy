using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Psych1 {
    public class TokenEventArgs : EventArgs {
        public int numTokens { get; private set; }
        public Point spawnLoc { get; private set; }
        public TokenEventArgs(int i, Point p) {
            spawnLoc = p;
            numTokens = i;
        }
    }
}
