using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Psych1 {
    public class Token : Control {
        Point goal;
        public double currX;
        public double currY; 
        double velocityX;
        double velocityY;
        int pixelsPerTick;
        public bool isResting {
            get; private set;
        }

        public Token() {
            pixelsPerTick = 50;
            velocityX = pixelsPerTick;
            velocityY = pixelsPerTick;
            isResting = false;
        }

        public void SetToken(Point p, Point e, int size) {
            this.Height = size;
            this.Width = size;
            this.Size = new Size(size, size);
            this.currX = p.X;
            this.currY = p.Y;
            goal = e;

            double rise = Math.Abs(currY - e.Y);
            double run = Math.Abs(currX - e.X);
            double hypo = Math.Sqrt((rise * rise) + (run * run));
            velocityX = ((run / hypo) + (hypo - rise) / (hypo)) * 4; // was 9
            velocityY =((rise / hypo) + (hypo - rise) / (hypo)) * 2; // done!
            velocityX = run / hypo;
            velocityY = rise / hypo;

            if (currX > goal.X) {
                velocityX *= -1;
            }
            if (currY > goal.Y) {
                velocityY *= -1;
            }
            
            velocityY *= pixelsPerTick;
            velocityX *= pixelsPerTick;
        }

        public void UpdateLocation() {
             if (isResting) {
                 return;
             }
             if (this.currX != goal.X || this.currY != goal.Y) {
                 if (this.currX != goal.X) {
                     this.currX += velocityX;
                 }

                 if (this.currY != goal.Y) {
                         this.currY += velocityY;
                 }
             } else {
                 isResting = true;
             }

             if (this.velocityX < 0 && this.currX < goal.X) {
                 this.currX = goal.X;
             } else if (this.velocityX > 0 && this.currX > goal.X) {
                 this.currX = goal.X;
             }

             if (this.velocityY < 0 && this.currY < goal.Y) {
                 this.currY = goal.Y;
             } else if (this.velocityY < 0 && this.currY < goal.Y) {
                 this.currY = goal.Y;
             }   

         }


        protected override void OnPaint(PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            graphics.Clear(this.BackColor);
            this.BackColor = Color.Silver;

            SolidBrush myBrush;
            myBrush = new SolidBrush(this.BackColor);


            graphics.FillEllipse(myBrush, 0, 0, this.Bounds.Width - this.Bounds.Width / 100, this.Bounds.Height - this.Bounds.Height / 100);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle newRect = this.ClientRectangle;
            newRect.Inflate(-5, -5);
            gp.AddEllipse(newRect);
            this.Region = new Region(gp);

            myBrush.Dispose();

        }
    }
}