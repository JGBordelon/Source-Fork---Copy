namespace Psych1 {
    partial class formGoNoGo {
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
            this.labelTrialInstructions = new System.Windows.Forms.Label();
            this.pictureTopLeft = new System.Windows.Forms.PictureBox();
            this.pictureTopRight = new System.Windows.Forms.PictureBox();
            this.pictureBottomLeft = new System.Windows.Forms.PictureBox();
            this.pictureBottomRight = new System.Windows.Forms.PictureBox();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottomLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottomRight)).BeginInit();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTrialInstructions
            // 
            this.labelTrialInstructions.AutoSize = true;
            this.labelTrialInstructions.Location = new System.Drawing.Point(314, 187);
            this.labelTrialInstructions.Name = "labelTrialInstructions";
            this.labelTrialInstructions.Size = new System.Drawing.Size(424, 13);
            this.labelTrialInstructions.TabIndex = 1;
            this.labelTrialInstructions.Text = "FOR THIS TASK, PRESS THE SPACEBAR ONLLY WHEN YOU SEE THE LETTER \'P\'";
            this.labelTrialInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTrialInstructions.Visible = false;
            // 
            // pictureTopLeft
            // 
            this.pictureTopLeft.Location = new System.Drawing.Point(14, 13);
            this.pictureTopLeft.Name = "pictureTopLeft";
            this.pictureTopLeft.Size = new System.Drawing.Size(90, 90);
            this.pictureTopLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTopLeft.TabIndex = 4;
            this.pictureTopLeft.TabStop = false;
            // 
            // pictureTopRight
            // 
            this.pictureTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureTopRight.Location = new System.Drawing.Point(121, 13);
            this.pictureTopRight.Name = "pictureTopRight";
            this.pictureTopRight.Size = new System.Drawing.Size(90, 90);
            this.pictureTopRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTopRight.TabIndex = 4;
            this.pictureTopRight.TabStop = false;
            // 
            // pictureBottomLeft
            // 
            this.pictureBottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBottomLeft.Location = new System.Drawing.Point(14, 118);
            this.pictureBottomLeft.Name = "pictureBottomLeft";
            this.pictureBottomLeft.Size = new System.Drawing.Size(90, 90);
            this.pictureBottomLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBottomLeft.TabIndex = 4;
            this.pictureBottomLeft.TabStop = false;
            // 
            // pictureBottomRight
            // 
            this.pictureBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBottomRight.Location = new System.Drawing.Point(121, 118);
            this.pictureBottomRight.Name = "pictureBottomRight";
            this.pictureBottomRight.Size = new System.Drawing.Size(90, 90);
            this.pictureBottomRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBottomRight.TabIndex = 4;
            this.pictureBottomRight.TabStop = false;
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.pictureTopLeft);
            this.panelStimuli.Controls.Add(this.pictureTopRight);
            this.panelStimuli.Controls.Add(this.pictureBottomRight);
            this.panelStimuli.Controls.Add(this.pictureBottomLeft);
            this.panelStimuli.Location = new System.Drawing.Point(410, 227);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(223, 224);
            this.panelStimuli.TabIndex = 6;
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BackColor = System.Drawing.Color.White;
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(639, 227);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(500, 300);
            this.richTextBoxInitialInstructions.TabIndex = 7;
            this.richTextBoxInitialInstructions.Text = "Instructions go here";
            this.richTextBoxInitialInstructions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInitialInstructions_KeyDown);
            // 
            // formGoNoGo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1117, 612);
            this.Controls.Add(this.richTextBoxInitialInstructions);
            this.Controls.Add(this.panelStimuli);
            this.Controls.Add(this.labelTrialInstructions);
            this.Name = "formGoNoGo";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formGoNoGo_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formGoNoGo_KeyDown);
            this.Resize += new System.EventHandler(this.formGoNoGo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottomLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottomRight)).EndInit();
            this.panelStimuli.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTrialInstructions;
        private System.Windows.Forms.PictureBox pictureTopLeft;
        private System.Windows.Forms.PictureBox pictureTopRight;
        private System.Windows.Forms.PictureBox pictureBottomLeft;
        private System.Windows.Forms.PictureBox pictureBottomRight;
        private System.Windows.Forms.Panel panelStimuli;
        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
    }
}

