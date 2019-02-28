using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psych1 {
    public class TrialConfig {
        public bool randomizeGamePosition;
        public int maxReward;
        public Queue<int> delays;
        public bool randomizeBlocks = false;
        public bool randomizePositions = false;
        public int trialsPerBlock;
        public DelayUnits delayUnits;
        public bool useSeparateRedBlueDeltas;

        public TrialConfig() {
            delays = new Queue<int>();
        }

        public void AddDelay(int delay) {
            delays.Enqueue(delay);
        }
        
    }
}
