using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.ComponentModel;

namespace Psych1 {
    public class RoundButton : System.Windows.Forms.Button {

        public delegate void TokenEventHandler(object sender, TokenEventArgs e);
        public event TokenEventHandler SpawnToken;
        public event TokenEventHandler TokensDone;

        private const int lineHeight = 16;
        private System.Timers.Timer timer;
        private System.Timers.Timer tokenTotalTimer;
        private System.Timers.Timer leapTokenTimer;
        public int amountInt { get; private set; }
        public int delayInt { get; private set; }
        public string amount { get; private set; }
        public string delay { get; private set; }
        public bool sizeBasedOnValue;
        private int maxSize;
        private Size originalSize;
        private Point originalCenter;
        public Color backgroundColor;
        private double tokenTime;
        private double totalTokenTime;
        public bool displayText;

        private int tokensToAdd;
        private int tokensPerTick;
        private int ticksPerToken;
        private int ticksPerLeapToken = 0;
        private int leapTokensPerTick = 0;
        private int leapTokensNeeded = 0;
        private int tokensAdded;
        private int currentTokenTicks;
        private int currentLeapTokenTicks;
        private int totalTokenTicks;
        private int totalLeapTokenTicks;

        public string number { get; private set; }

        public RoundButton() {
            amountInt = -1;
        }

        public void InitializeDefaults(bool reSize) {
            sizeBasedOnValue = reSize;
            originalSize = this.Size;
            originalCenter = this.Location;
            backgroundColor = Color.Black;
        }

        public void InitializeDefaults(bool reSize, Color color, System.Timers.Timer timer, int initialSize, int maxSize, string number) { 
            sizeBasedOnValue = reSize;
            this.number = number;
            displayText = false;
            this.Size = new Size(new Point(initialSize, initialSize));
            if (this.Size.Height != maxSize) {
                int tempOffset = (maxSize - this.Size.Height) / 2;
                this.Location = new Point(this.Location.X + tempOffset, this.Location.Y + tempOffset);
            }
            originalSize = this.Size;
            this.maxSize = maxSize;
            originalCenter = this.Location;
            backgroundColor = color;
            this.timer = timer;
            leapTokenTimer = new System.Timers.Timer();
            leapTokenTimer.Elapsed += OnLeapTokenTimerTick;
            this.Invalidate();
            this.Update();
        }

        // Calculates Tokens/Tick and starts timer(s).
        // If time == tokens, it's 1 per tick.
        // If more tokens than time, tokensPerTick is set > 1 (tokens/delay) and a leapTokenTimer is set to distribute the odd token(s).
        // If more time than tokens, ticksPerToken is set > 1 (delay/tokens (+1 if only is 1)) and a leapTokenTimer is set to distribute the odd tokens(s).
        // 
        public void DoTokens(int n) {
            tokensToAdd = n;
            tokensAdded = 0;
            int delayInt = this.delayInt;
            if(delayInt == 0) {
                AddTokensNow();
                return;
            }
            if (tokensToAdd == delayInt) {
                tokensPerTick = 1;
                leapTokensPerTick = 0;
                ticksPerLeapToken = 0; //-1
                ticksPerToken = 0; //-1?
            } else if (tokensToAdd > delayInt) {
                if (tokensToAdd % delayInt == 0) {
                    ticksPerLeapToken = 0; //-1
                    leapTokensPerTick = 0;
                    ticksPerToken = 1;
                    totalTokenTicks = delayInt;
                    tokensPerTick = tokensToAdd / delayInt;
                } else {
                    leapTokensNeeded = tokensToAdd % delayInt;
                    tokensPerTick = tokensToAdd / delayInt;
                    ticksPerToken = 1;
                    ticksPerLeapToken = delayInt / leapTokensNeeded;
                    leapTokensPerTick = 1;
                    totalTokenTicks = delayInt;
                    totalLeapTokenTicks = leapTokensNeeded / leapTokensPerTick;
                }
            } else if (tokensToAdd < delayInt) {
                if (delayInt % tokensToAdd == 0) {
                    ticksPerLeapToken = 0;
                    leapTokensPerTick = 0;
                    tokensPerTick = 1;
                    ticksPerToken = delayInt / tokensToAdd;
                    totalTokenTicks = delayInt;
                } else {
                    leapTokensNeeded = 0;
                    leapTokensPerTick = 0;
                    ticksPerLeapToken = 0;
                    tokensPerTick = 1;
                    ticksPerToken = (delayInt / tokensToAdd);
                    if (ticksPerToken == 1) {
                        ticksPerToken++;
                    }
                    if (tokensToAdd > delayInt / 2) {
                        leapTokensNeeded = tokensToAdd - (delayInt / 2);
                        leapTokensPerTick = 1;
                        ticksPerLeapToken = delayInt / leapTokensNeeded;
                    }
                    totalTokenTicks = delayInt / ticksPerToken;
                    if (ticksPerLeapToken != 0) {
                        totalLeapTokenTicks = delayInt / ticksPerLeapToken;
                    }
                }
            }

            currentTokenTicks = 0;
            currentLeapTokenTicks = 0;

            tokenTotalTimer = new System.Timers.Timer();
            tokenTotalTimer.Interval = 1000 * delayInt + 800;
            tokenTotalTimer.Elapsed += OnTokenTotalTimerTick;

            timer.Elapsed += OnTokenTimerTick;
            if (ticksPerLeapToken != 0 && this.BackColor != Color.Red) {
                leapTokenTimer.Interval = timer.Interval * ticksPerLeapToken;
                leapTokenTimer.Start();
            }
            timer.Start();
            tokenTotalTimer.Start();
        }
        
        // FOR BLUE BUTTON
        private void AddToken(object sender, EventArgs e) {
            if (ticksPerToken > 0) {
                if (currentTokenTicks % ticksPerToken != 0) {
                    return;
                }
            }
            if (SpawnToken != null) {
                if (tokensPerTick > 0) {
                    
                    if(tokensAdded >= tokensToAdd) {
                        tokensPerTick = tokensToAdd - tokensAdded;
                        tokensAdded = tokensToAdd;
                    }
                    
                        tokensAdded += tokensPerTick;
                        if (tokensPerTick > 0) {

                        BackgroundWorker t = new BackgroundWorker();
                        t.DoWork += delegate {
                            for (int i = 0; i < tokensPerTick; i++) {
                                if (SpawnToken != null) {
                                    SpawnToken(this, new TokenEventArgs(1, this.Location));
                                    Thread.Sleep(30);
                                }
                            }
                        };
                        t.RunWorkerAsync();
                    }
                } 
            }
        }
        // FOR RED BUTTON
        private void AddAllTokens(object sender, EventArgs e) {
            tokenTime -= timer.Interval;
            if (tokenTime <= 0) {
                timer.Stop();
                BackgroundWorker t = new BackgroundWorker();
                t.DoWork += delegate {


                    for (int i = 0; i < amountInt; i++) {
                        if (SpawnToken != null) {

                            SpawnToken(this, new TokenEventArgs(1, this.Location));
                            Thread.Sleep(30);
                        }
                    }
                    TokensDone(null, null);
                };
                t.RunWorkerAsync();
            }
        }
        // FOR YELLOW BUTTON
        private void AddTokensNow() {
            BackgroundWorker t = new BackgroundWorker();
            t.DoWork += delegate {
                for (int i = 0; i < amountInt; i++) {
                    if (SpawnToken != null) {

                        SpawnToken(this, new TokenEventArgs(1, this.Location));
                        Thread.Sleep(30);
                    }
                }
            TokensDone(null, null);
            };
            t.RunWorkerAsync();
        }

        public void SetAmount(int amount) {
            int tempOffset = (int)((this.Size.Height - this.Size.Height * 1.25) / 2);
            if (amount != -1) {
                if (amount < amountInt && sizeBasedOnValue) {
                    this.Size = new Size((int)(this.Size.Height * .75), (int)(this.Size.Width * .75));
                    this.Location = new Point(this.Location.X - tempOffset, this.Location.Y - tempOffset);
                } else if (amount > amountInt && sizeBasedOnValue) {
                    this.Size = new Size((int)(this.Size.Height * 1.25), (int)(this.Size.Width * 1.25));
                    this.Location = new Point(this.Location.X + tempOffset, this.Location.Y + tempOffset);
                }
            }
            this.amount = "$" + amount.ToString();
            amountInt = amount;
            this.Invalidate();
            this.Update();
        }

        public void Reset() {
            amountInt = -1;
            this.Size = originalSize;
            this.Location = originalCenter;
            this.Invalidate();
            this.Update();
        }

        public void SetDelay(string delay, int delayInt) {
            this.delay = delay;
            this.delayInt = delayInt;

            if (this.backgroundColor == Color.Blue) {
                timer.Elapsed -= AddToken;
                timer.Elapsed += AddToken;
                totalTokenTime = 0;
            } else if (this.backgroundColor == Color.Red) {
                timer.Elapsed -= AddAllTokens;
                timer.Elapsed += AddAllTokens;
                tokenTime = delayInt * 1000;
                totalTokenTime = tokenTime;
            }

            this.Invalidate();
            this.Update();
        }

        private void OnLeapTokenTimerTick(object sender, EventArgs e) {
            currentLeapTokenTicks++;
            
            if (tokensAdded >= tokensToAdd) {
                leapTokensPerTick = tokensToAdd - tokensAdded;
                tokensAdded = tokensToAdd;
            }
            if (SpawnToken != null) {
                tokensAdded += 1;
                    if (leapTokensPerTick > 0) {
                    BackgroundWorker t = new BackgroundWorker();
                    t.DoWork += delegate {
                        for (int i = 0; i < leapTokensPerTick; i++) {
                            if (SpawnToken != null) {
                                SpawnToken(this, new TokenEventArgs(1, this.Location));
                                Thread.Sleep(30);
                            }
                        }
                    };
                    t.RunWorkerAsync();
                }
                
            }
            if(currentLeapTokenTicks == totalLeapTokenTicks) {
                leapTokenTimer.Stop();
            }
        }

        private void OnTokenTotalTimerTick(object sender, EventArgs e) {
            tokenTotalTimer.Stop();
            leapTokenTimer.Stop();
            timer.Stop();
            timer.Elapsed -= OnTokenTimerTick;
            if (totalTokenTime == 0) {
                TokensDone(null, null);
            }
        }

        private void OnTokenTimerTick(object sender, EventArgs e) {
            currentTokenTicks++;
            if (currentTokenTicks == delayInt) {
                timer.Elapsed -= OnTokenTimerTick;
                timer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            SolidBrush myBrush;
            Pen myPen;

            graphics.Clear(this.BackColor);

            if (backgroundColor != Color.Black) {
                this.BackColor = this.backgroundColor;

                if (this.Enabled) {
                    myBrush = new SolidBrush(backgroundColor);
                } else {
                    myBrush = new SolidBrush(Color.Gray);
                }

                graphics.FillEllipse(myBrush, 0, 0, this.Bounds.Width - this.Bounds.Width / 100, this.Bounds.Height - this.Bounds.Height / 100);
                myBrush.Dispose();
            } 

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle newRect = this.ClientRectangle;
            newRect.Inflate(-5, -5);
            gp.AddEllipse(newRect);
            this.Region = new Region(gp);

            if (displayText) {
                myPen = new Pen(Color.Black);
                graphics.DrawEllipse(myPen, 10, 10, this.Bounds.Width - 20, this.Bounds.Height - 20);
                myPen.Dispose();
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString(this.amount, new Font("Arial", lineHeight), new SolidBrush(Color.Black), new Point(this.Width / 2, this.Height / 2 - lineHeight), stringFormat);
                graphics.DrawString(this.delay, new Font("Arial", lineHeight), new SolidBrush(Color.Black), new Point(this.Width / 2, this.Height / 2 + lineHeight), stringFormat);
            }
            
            
            
    }

        public static int gcf(int a, int b) {
            while(b != 0) {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
