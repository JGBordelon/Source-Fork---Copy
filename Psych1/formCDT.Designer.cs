namespace Psych1 {
    partial class formCDT {
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
            this.stimulus = new System.Windows.Forms.PictureBox();
            this.pictureLeft = new System.Windows.Forms.PictureBox();
            this.pictureRight = new System.Windows.Forms.PictureBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            this.labelCorrectAnswersInARow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stimulus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // stimulus
            // 
            this.stimulus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stimulus.Location = new System.Drawing.Point(205, 0);
            this.stimulus.Name = "stimulus";
            this.stimulus.Size = new System.Drawing.Size(90, 90);
            this.stimulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stimulus.TabIndex = 0;
            this.stimulus.TabStop = false;
            this.stimulus.Visible = false;
            // 
            // pictureLeft
            // 
            this.pictureLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureLeft.Location = new System.Drawing.Point(0, 410);
            this.pictureLeft.Name = "pictureLeft";
            this.pictureLeft.Size = new System.Drawing.Size(90, 90);
            this.pictureLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLeft.TabIndex = 0;
            this.pictureLeft.TabStop = false;
            this.pictureLeft.Visible = false;
            this.pictureLeft.Click += new System.EventHandler(this.picture_Click);
            // 
            // pictureRight
            // 
            this.pictureRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureRight.Location = new System.Drawing.Point(410, 410);
            this.pictureRight.Name = "pictureRight";
            this.pictureRight.Size = new System.Drawing.Size(90, 90);
            this.pictureRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureRight.TabIndex = 0;
            this.pictureRight.TabStop = false;
            this.pictureRight.Visible = false;
            this.pictureRight.Click += new System.EventHandler(this.picture_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedback.Location = new System.Drawing.Point(340, 455);
            this.labelFeedback.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(137, 26);
            this.labelFeedback.TabIndex = 2;
            this.labelFeedback.Text = "CORRECT!";
            this.labelFeedback.Visible = false;
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.labelCorrectAnswersInARow);
            this.panelStimuli.Controls.Add(this.pictureLeft);
            this.panelStimuli.Controls.Add(this.pictureRight);
            this.panelStimuli.Controls.Add(this.stimulus);
            this.panelStimuli.Location = new System.Drawing.Point(181, 31);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(500, 500);
            this.panelStimuli.TabIndex = 3;
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BackColor = System.Drawing.Color.White;
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(778, 139);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(500, 500);
            this.richTextBoxInitialInstructions.TabIndex = 4;
            this.richTextBoxInitialInstructions.Text = "Initial Instructions go Here";
            this.richTextBoxInitialInstructions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInitialInstructions_KeyDown);
            // 
            // labelCorrectAnswersInARow
            // 
            this.labelCorrectAnswersInARow.AutoSize = true;
            this.labelCorrectAnswersInARow.Location = new System.Drawing.Point(185, 226);
            this.labelCorrectAnswersInARow.Name = "labelCorrectAnswersInARow";
            this.labelCorrectAnswersInARow.Size = new System.Drawing.Size(13, 13);
            this.labelCorrectAnswersInARow.TabIndex = 1;
            this.labelCorrectAnswersInARow.Text = "0";
            this.labelCorrectAnswersInARow.Visible = false;
            // 
            // formCDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(916, 617);
            this.Controls.Add(this.richTextBoxInitialInstructions);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.panelStimuli);
            this.Name = "formCDT";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formConditionalDiscriminationTraining_FormClosed);
            this.Resize += new System.EventHandler(this.formConditionalDiscriminationTraining_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.stimulus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            this.panelStimuli.ResumeLayout(false);
            this.panelStimuli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stimulus;
        private System.Windows.Forms.PictureBox pictureLeft;
        private System.Windows.Forms.PictureBox pictureRight;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.Panel panelStimuli;
        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
        private System.Windows.Forms.Label labelCorrectAnswersInARow;
    }
}