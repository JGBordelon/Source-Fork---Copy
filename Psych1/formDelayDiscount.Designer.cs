namespace Psych1 {
    partial class formDelayDiscount {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.roundButtonMax = new Psych1.RoundButton();
            this.roundButtonMin = new Psych1.RoundButton();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(301, 12);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(500, 250);
            this.richTextBoxInitialInstructions.TabIndex = 1;
            this.richTextBoxInitialInstructions.Text = "";
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.roundButtonMax);
            this.panelStimuli.Controls.Add(this.roundButtonMin);
            this.panelStimuli.Location = new System.Drawing.Point(38, 65);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(1019, 279);
            this.panelStimuli.TabIndex = 2;
            this.panelStimuli.Visible = false;
            // 
            // roundButtonMax
            // 
            this.roundButtonMax.Location = new System.Drawing.Point(769, 3);
            this.roundButtonMax.Name = "roundButtonMax";
            this.roundButtonMax.Size = new System.Drawing.Size(250, 250);
            this.roundButtonMax.TabIndex = 0;
            this.roundButtonMax.Text = "roundButton1";
            this.roundButtonMax.UseVisualStyleBackColor = true;
            this.roundButtonMax.Click += new System.EventHandler(this.roundButton_Click);
            // 
            // roundButtonMin
            // 
            this.roundButtonMin.Location = new System.Drawing.Point(3, 3);
            this.roundButtonMin.Name = "roundButtonMin";
            this.roundButtonMin.Size = new System.Drawing.Size(250, 250);
            this.roundButtonMin.TabIndex = 0;
            this.roundButtonMin.Text = "roundButton1";
            this.roundButtonMin.UseVisualStyleBackColor = true;
            this.roundButtonMin.Click += new System.EventHandler(this.roundButton_Click);
            // 
            // formDelayDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 426);
            this.Controls.Add(this.richTextBoxInitialInstructions);
            this.Controls.Add(this.panelStimuli);
            this.Name = "formDelayDiscount";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formDelayDiscount_KeyDown);
            this.Resize += new System.EventHandler(this.formDelayDiscount_Resize);
            this.panelStimuli.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundButton roundButtonMin;
        private RoundButton roundButtonMax;
        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
        private System.Windows.Forms.Panel panelStimuli;
    }
}