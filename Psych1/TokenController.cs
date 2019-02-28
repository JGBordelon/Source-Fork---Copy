using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Psych1 {
    public class TokenController
    {
        private Thread thread;
        private static object locker = new object();
        List<Token> tokens;
        List<Token> staticTokens;
        int nextToken;
        int tokensPerRow;
        Point tokenContainer;
        int tokenPadding;
        int tokenSize;
        public bool allResting;
        int panelWidth = 1920;
        int tokenContainerOffset = 75;

        public TokenController(int panelY) {
            panelWidth = Screen.PrimaryScreen.Bounds.Width;
            allResting = false;
            tokenSize = 20;
            tokens = new List<Token>();
            staticTokens = new List<Token>();
            tokenPadding = 5;
            tokensPerRow = 50;
            nextToken = 0;
            int temp = (panelWidth - (tokensPerRow*tokenPadding + tokensPerRow*tokenSize)) / 2;
            temp = temp + temp / 3;
            Point p = new Point(temp, panelY + tokenContainerOffset);
            tokenContainer = p;
        }

        public Token AddToken(Point p) {
            int nextTokenX = nextToken % tokensPerRow;
            int nextTokenY = nextToken / tokensPerRow;
            nextToken++;

            Point e = new Point(tokenContainer.X + (nextTokenX * tokenSize) + tokenPadding,tokenContainer.Y + (nextTokenY * tokenSize) + tokenPadding);
            Token temp = new Token();
            temp.SetToken(p, e, tokenSize);
            temp.BringToFront();
            lock (locker) {
                tokens.Add(temp);
            }
            return temp;
        }

        public void UpdateStaticTokens() {
            while (!allResting) {
                Thread.Sleep(10);
            } // let rest happen
            staticTokens.AddRange(tokens);
            allResting = false;
            lock (locker) { 
                tokens = new List<Token>();
            }
        }

        public void ClearTokens() {
            foreach (Token t in tokens) {
                t.Dispose();
            }
            foreach (Token t in staticTokens) {
                t.Dispose();
            }
        }

        public void UpdateLocation() {
            for (int index = tokens.Count - 1; index >= 0; index--) {
                Token t = tokens[index];
                if (t != null) {
                        t.UpdateLocation();
                }
            }
        }

        public void AllResting() {
             
            thread = new Thread(new ThreadStart(this.checkResting));
            thread.IsBackground = true;
            thread.Name = "CheckRestingTokens";
            thread.Start();
        }

        private void checkResting() {
            while (allResting == false) {
                bool temp = true;
                for (int index = tokens.Count - 1; index >= 0; index--) {
                    Token t = tokens[index];
                    if (t != null) {
                        if (!t.isResting) {
                            temp = false;
                        }
                    }
                }
                if (temp == true) {
                    allResting = true;
                } else {
                    allResting = false;
                }
                Thread.Sleep(100);
            }
        }

        public void Redraw() {

            lock (locker) {
                UpdateLocation();
                for (int index = tokens.Count - 1; index >= 0; index--) {
                    Token t = tokens[index];
                    if (t != null) {
                        int X = (int)t.currX;
                        int Y = (int)t.currY;
                        t.Location = new Point(X, Y);
                        t.Refresh();
                    }
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)  {
                UpdateLocation();
        }

        
    }
}
