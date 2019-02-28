namespace Psych1 {
    partial class formChoiceGame {
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
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelTotalPoints = new System.Windows.Forms.Label();
            this.labelTokens = new System.Windows.Forms.Label();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.labelPhase = new System.Windows.Forms.Label();
            this.labelMinInstructions = new System.Windows.Forms.Label();
            this.labelMax2Instructions = new System.Windows.Forms.Label();
            this.labelTokenNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelControlsNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMax1Instructions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPointsText = new System.Windows.Forms.Label();
            this.labelTotalPointsText = new System.Windows.Forms.Label();
            this.progressMin = new Psych1.SmoothProgressBar();
            this.progressMax2 = new Psych1.SmoothProgressBar();
            this.progressMax1 = new Psych1.SmoothProgressBar();
            this.roundButtonMin = new Psych1.RoundButton();
            this.roundButtonMax2 = new Psych1.RoundButton();
            this.roundButtonMax1 = new Psych1.RoundButton();
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.labelPoints);
            this.panelStimuli.Controls.Add(this.labelTotalPoints);
            this.panelStimuli.Controls.Add(this.labelTokens);
            this.panelStimuli.Controls.Add(this.labelInstructions);
            this.panelStimuli.Controls.Add(this.labelPhase);
            this.panelStimuli.Controls.Add(this.labelMinInstructions);
            this.panelStimuli.Controls.Add(this.labelMax2Instructions);
            this.panelStimuli.Controls.Add(this.labelTokenNum);
            this.panelStimuli.Controls.Add(this.label7);
            this.panelStimuli.Controls.Add(this.labelControlsNum);
            this.panelStimuli.Controls.Add(this.label3);
            this.panelStimuli.Controls.Add(this.labelMax1Instructions);
            this.panelStimuli.Controls.Add(this.label2);
            this.panelStimuli.Controls.Add(this.labelPointsText);
            this.panelStimuli.Controls.Add(this.labelTotalPointsText);
            this.panelStimuli.Controls.Add(this.progressMin);
            this.panelStimuli.Controls.Add(this.progressMax2);
            this.panelStimuli.Controls.Add(this.progressMax1);
            this.panelStimuli.Controls.Add(this.roundButtonMin);
            this.panelStimuli.Controls.Add(this.roundButtonMax2);
            this.panelStimuli.Controls.Add(this.roundButtonMax1);
            this.panelStimuli.Location = new System.Drawing.Point(43, 32);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(1350, 799);
            this.panelStimuli.TabIndex = 4;
            this.panelStimuli.Visible = false;
            this.panelStimuli.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoints.Location = new System.Drawing.Point(1286, 28);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(13, 14);
            this.labelPoints.TabIndex = 5;
            this.labelPoints.Text = "0";
            this.labelPoints.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointsLabel_MouseClick);
            // 
            // labelTotalPoints
            // 
            this.labelTotalPoints.AutoSize = true;
            this.labelTotalPoints.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPoints.Location = new System.Drawing.Point(1286, 11);
            this.labelTotalPoints.Name = "labelTotalPoints";
            this.labelTotalPoints.Size = new System.Drawing.Size(13, 14);
            this.labelTotalPoints.TabIndex = 5;
            this.labelTotalPoints.Text = "0";
            this.labelTotalPoints.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointsLabel_MouseClick);
            // 
            // labelTokens
            // 
            this.labelTokens.AutoSize = true;
            this.labelTokens.Location = new System.Drawing.Point(68, 9);
            this.labelTokens.Name = "labelTokens";
            this.labelTokens.Size = new System.Drawing.Size(13, 13);
            this.labelTokens.TabIndex = 5;
            this.labelTokens.Text = "0";
            this.labelTokens.Visible = false;
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructions.Location = new System.Drawing.Point(563, 27);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(149, 14);
            this.labelInstructions.TabIndex = 5;
            this.labelInstructions.Text = "Pick which button to practice.";
            this.labelInstructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.instructions_MouseClick);
            // 
            // labelPhase
            // 
            this.labelPhase.AutoSize = true;
            this.labelPhase.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhase.Location = new System.Drawing.Point(562, 5);
            this.labelPhase.Name = "labelPhase";
            this.labelPhase.Size = new System.Drawing.Size(165, 22);
            this.labelPhase.TabIndex = 5;
            this.labelPhase.Text = "PRACTICE ROUND";
            this.labelPhase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.instructions_MouseClick);
            // 
            // labelMinInstructions
            // 
            this.labelMinInstructions.AutoSize = true;
            this.labelMinInstructions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinInstructions.Location = new System.Drawing.Point(984, 659);
            this.labelMinInstructions.Name = "labelMinInstructions";
            this.labelMinInstructions.Size = new System.Drawing.Size(47, 14);
            this.labelMinInstructions.TabIndex = 5;
            this.labelMinInstructions.Text = "Tokens: ";
            this.labelMinInstructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // labelMax2Instructions
            // 
            this.labelMax2Instructions.AutoSize = true;
            this.labelMax2Instructions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax2Instructions.Location = new System.Drawing.Point(534, 659);
            this.labelMax2Instructions.Name = "labelMax2Instructions";
            this.labelMax2Instructions.Size = new System.Drawing.Size(47, 14);
            this.labelMax2Instructions.TabIndex = 5;
            this.labelMax2Instructions.Text = "Tokens: ";
            this.labelMax2Instructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // labelTokenNum
            // 
            this.labelTokenNum.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.labelTokenNum.AutoSize = true;
            this.labelTokenNum.Location = new System.Drawing.Point(563, 766);
            this.labelTokenNum.Name = "labelTokenNum";
            this.labelTokenNum.Size = new System.Drawing.Size(49, 13);
            this.labelTokenNum.TabIndex = 5;
            this.labelTokenNum.Text = "Tokens: ";
            this.labelTokenNum.Visible = false;
            this.labelTokenNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 766);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tokens";
            this.label7.Visible = false;
            this.label7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // labelControlsNum
            // 
            this.labelControlsNum.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.labelControlsNum.AutoSize = true;
            this.labelControlsNum.Location = new System.Drawing.Point(126, 766);
            this.labelControlsNum.Name = "labelControlsNum";
            this.labelControlsNum.Size = new System.Drawing.Size(49, 13);
            this.labelControlsNum.TabIndex = 5;
            this.labelControlsNum.Text = "Tokens: ";
            this.labelControlsNum.Visible = false;
            this.labelControlsNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 766);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Controls";
            this.label3.Visible = false;
            this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // labelMax1Instructions
            // 
            this.labelMax1Instructions.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.labelMax1Instructions.AutoSize = true;
            this.labelMax1Instructions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMax1Instructions.Location = new System.Drawing.Point(100, 659);
            this.labelMax1Instructions.Name = "labelMax1Instructions";
            this.labelMax1Instructions.Size = new System.Drawing.Size(47, 14);
            this.labelMax1Instructions.TabIndex = 5;
            this.labelMax1Instructions.Text = "Tokens: ";
            this.labelMax1Instructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tokens: ";
            this.label2.Visible = false;
            // 
            // labelPointsText
            // 
            this.labelPointsText.AutoSize = true;
            this.labelPointsText.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPointsText.Location = new System.Drawing.Point(1175, 27);
            this.labelPointsText.Name = "labelPointsText";
            this.labelPointsText.Size = new System.Drawing.Size(61, 15);
            this.labelPointsText.TabIndex = 5;
            this.labelPointsText.Text = "POINTS: ";
            this.labelPointsText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointsLabel_MouseClick);
            // 
            // labelTotalPointsText
            // 
            this.labelTotalPointsText.AutoSize = true;
            this.labelTotalPointsText.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPointsText.Location = new System.Drawing.Point(1175, 10);
            this.labelTotalPointsText.Name = "labelTotalPointsText";
            this.labelTotalPointsText.Size = new System.Drawing.Size(105, 15);
            this.labelTotalPointsText.TabIndex = 5;
            this.labelTotalPointsText.Text = "TOTAL POINTS: ";
            this.labelTotalPointsText.Click += new System.EventHandler(this.labelTotalPointsText_Click);
            this.labelTotalPointsText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointsLabel_MouseClick);
            // 
            // progressMin
            // 
            this.progressMin.Location = new System.Drawing.Point(963, 598);
            this.progressMin.Maximum = 100;
            this.progressMin.Minimum = 0;
            this.progressMin.Name = "progressMin";
            this.progressMin.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            this.progressMin.Size = new System.Drawing.Size(250, 31);
            this.progressMin.TabIndex = 4;
            this.progressMin.Value = 0;
            this.progressMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBarYellow_MouseClick);
            // 
            // progressMax2
            // 
            this.progressMax2.Location = new System.Drawing.Point(516, 598);
            this.progressMax2.Maximum = 100;
            this.progressMax2.Minimum = 0;
            this.progressMax2.Name = "progressMax2";
            this.progressMax2.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            this.progressMax2.Size = new System.Drawing.Size(250, 31);
            this.progressMax2.TabIndex = 4;
            this.progressMax2.Value = 0;
            this.progressMax2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBarBlue_MouseClick);
            // 
            // progressMax1
            // 
            this.progressMax1.Location = new System.Drawing.Point(83, 598);
            this.progressMax1.Maximum = 100;
            this.progressMax1.Minimum = 0;
            this.progressMax1.Name = "progressMax1";
            this.progressMax1.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            this.progressMax1.Size = new System.Drawing.Size(250, 31);
            this.progressMax1.TabIndex = 4;
            this.progressMax1.Value = 0;
            this.progressMax1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBarRed_MouseClick);
            // 
            // roundButtonMin
            // 
            this.roundButtonMin.Location = new System.Drawing.Point(987, 342);
            this.roundButtonMin.Name = "roundButtonMin";
            this.roundButtonMin.Size = new System.Drawing.Size(250, 250);
            this.roundButtonMin.TabIndex = 0;
            this.roundButtonMin.Text = "roundButton1";
            this.roundButtonMin.UseVisualStyleBackColor = true;
            this.roundButtonMin.Visible = false;
            this.roundButtonMin.Click += new System.EventHandler(this.button_Click);
            // 
            // roundButtonMax2
            // 
            this.roundButtonMax2.Location = new System.Drawing.Point(537, 342);
            this.roundButtonMax2.Name = "roundButtonMax2";
            this.roundButtonMax2.Size = new System.Drawing.Size(250, 250);
            this.roundButtonMax2.TabIndex = 0;
            this.roundButtonMax2.Text = "roundButton1";
            this.roundButtonMax2.UseVisualStyleBackColor = true;
            this.roundButtonMax2.Visible = false;
            this.roundButtonMax2.Click += new System.EventHandler(this.button_Click);
            // 
            // roundButtonMax1
            // 
            this.roundButtonMax1.Location = new System.Drawing.Point(103, 342);
            this.roundButtonMax1.Name = "roundButtonMax1";
            this.roundButtonMax1.Size = new System.Drawing.Size(250, 250);
            this.roundButtonMax1.TabIndex = 0;
            this.roundButtonMax1.Text = "roundButton1";
            this.roundButtonMax1.UseVisualStyleBackColor = true;
            this.roundButtonMax1.Visible = false;
            this.roundButtonMax1.Click += new System.EventHandler(this.button_Click);
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BackColor = System.Drawing.Color.White;
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(1139, 605);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(500, 250);
            this.richTextBoxInitialInstructions.TabIndex = 3;
            this.richTextBoxInitialInstructions.Text = "";
            this.richTextBoxInitialInstructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            // 
            // formChoiceGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1450, 855);
            this.Controls.Add(this.panelStimuli);
            this.Controls.Add(this.richTextBoxInitialInstructions);
            this.Name = "formChoiceGame";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formChoiceGame_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bg_MouseClick);
            this.Resize += new System.EventHandler(this.formChoiceGame_Resize);
            this.panelStimuli.ResumeLayout(false);
            this.panelStimuli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStimuli;
        private RoundButton roundButtonMin;
        private RoundButton roundButtonMax1;
        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
        private RoundButton roundButtonMax2;
        private SmoothProgressBar progressMax2;
        private SmoothProgressBar progressMax1;
        private System.Windows.Forms.Label labelTotalPoints;
        private System.Windows.Forms.Label labelTokens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalPointsText;
        private SmoothProgressBar progressMin;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Label labelPhase;
        private System.Windows.Forms.Label labelMinInstructions;
        private System.Windows.Forms.Label labelMax2Instructions;
        private System.Windows.Forms.Label labelMax1Instructions;
        private System.Windows.Forms.Label labelTokenNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelControlsNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPointsText;
        private System.Windows.Forms.Label labelPoints;
    }
}