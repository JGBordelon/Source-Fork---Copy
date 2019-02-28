using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psych1 {
    public partial class formTester : Form {
        int tokensToAdd;
        int tokensAdded;
        int delayInt;
        int tokensPerTick;
        int leapTokensPerTick = 0;
        int ticksPerLeapToken = 0;
        int ticksPerLeapToken2 = 0;
        int ticksPerToken;
        int totalTokenTicks;
        int totalLeapTokenTicks;
        int LEAPNEEDED;
        int currentTokenTicks;
        int currentLeapTokenTicks;
        bool useTicksPerToken;
        Token tempToken;

        public formTester() {
            InitializeComponent();
            tempToken = new Token();
            tempToken.SetToken(new Point(100, 100), new Point(100, 100), 100);
            this.Controls.Add(tempToken);
            tempToken.Update();
        }
        public void DoTokens(int n) { // MAY NEED TO START OVER FROM SCRATCH
            tokensToAdd = n;
            tokensAdded = 0;
           
            if (tokensToAdd == delayInt) {
                tokensPerTick = 1;
                leapTokensPerTick = 0;
                ticksPerLeapToken = -1;
                ticksPerToken = -1;
                ticksPerLeapToken2 = 0;
            } else if (tokensToAdd > delayInt) {
                if (tokensToAdd % delayInt == 0) {
                    ticksPerLeapToken = -1;
                    ticksPerLeapToken2 = 0;
                    leapTokensPerTick = 0;
                    ticksPerToken = 1;
                    totalTokenTicks = delayInt;
                    tokensPerTick = tokensToAdd / delayInt;
                } else {
                    ticksPerLeapToken2 = 0;
                    LEAPNEEDED = tokensToAdd % delayInt;
                    tokensPerTick = tokensToAdd / delayInt;
                    ticksPerToken = 1;
                    ticksPerLeapToken = delayInt / LEAPNEEDED;
                    leapTokensPerTick = 1;
                    totalTokenTicks = delayInt;
                    totalLeapTokenTicks = LEAPNEEDED / leapTokensPerTick;
                }
            } else if (tokensToAdd < delayInt) {
                if (delayInt % tokensToAdd == 0) {
                    ticksPerLeapToken2 = 0;
                    ticksPerLeapToken = 0;
                    leapTokensPerTick = 0;
                    tokensPerTick = 1;
                    ticksPerToken = delayInt / tokensToAdd;
                    totalTokenTicks = delayInt;
                } else {
                    ticksPerLeapToken2 = 0;
                    LEAPNEEDED=0;
                    leapTokensPerTick = 0;
                    ticksPerLeapToken = 0;
                    tokensPerTick = 1;
                    ticksPerToken = (delayInt / tokensToAdd);
                    if(ticksPerToken == 1) {
                        ticksPerToken++;
                    }
                    if (tokensToAdd > delayInt / 2) {
                        LEAPNEEDED = tokensToAdd - (delayInt / 2);
                        leapTokensPerTick = 1;
                        ticksPerLeapToken = Math.Abs(delayInt - LEAPNEEDED);
                    }
                    totalTokenTicks = delayInt / ticksPerToken;
                    if (ticksPerLeapToken != 0) {
                        totalLeapTokenTicks = delayInt / ticksPerLeapToken;
                        if (ticksPerLeapToken2 != 0) {
                            totalLeapTokenTicks += delayInt / ticksPerLeapToken2;
                        }
                    }
                }
            }
            int temp;
            if (ticksPerToken != 1) { delayInt /= ticksPerToken;  }
            temp = tokensPerTick * delayInt;
            temp += LEAPNEEDED;
            labelTokens.Text = temp.ToString();
            labelLTokens.Text = LEAPNEEDED.ToString();
            labelLTT.Text = totalLeapTokenTicks.ToString();
            labelTT.Text = totalTokenTicks.ToString();
            labelTPTick.Text = tokensPerTick.ToString();
            labelLTPTick.Text = leapTokensPerTick.ToString();
            labelTPToken.Text = ticksPerToken.ToString();
        }
        private int gcf(int a, int b) {
            while (b != 0) {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e) {
            delayInt = int.Parse(textBoxDelay.Text);
            tokensToAdd = int.Parse(textBoxTokens.Text);
            DoTokens(tokensToAdd);
        }

        private void button2_Click(object sender, EventArgs e) {
            int a = int.Parse(textBoxDelay.Text);
            int b = int.Parse(textBoxTokens.Text);
            labelGCF.Text = gcf(a, b).ToString();
        }
    }
}
