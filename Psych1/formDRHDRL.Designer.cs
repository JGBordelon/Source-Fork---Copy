namespace Psych1 {
    partial class formDRHDRL {
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
            this.labelPoints = new System.Windows.Forms.Label();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.stimulus)).BeginInit();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // stimulus
            // 
            this.stimulus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stimulus.Location = new System.Drawing.Point(255, 0);
            this.stimulus.Margin = new System.Windows.Forms.Padding(2);
            this.stimulus.Name = "stimulus";
            this.stimulus.Size = new System.Drawing.Size(90, 90);
            this.stimulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stimulus.TabIndex = 1;
            this.stimulus.TabStop = false;
            this.stimulus.Visible = false;
            // 
            // labelPoints
            // 
            this.labelPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoints.Location = new System.Drawing.Point(536, 29);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(24, 26);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "0";
            this.labelPoints.Visible = false;
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.stimulus);
            this.panelStimuli.Controls.Add(this.labelPoints);
            this.panelStimuli.Location = new System.Drawing.Point(233, 145);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(600, 153);
            this.panelStimuli.TabIndex = 3;
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BackColor = System.Drawing.Color.White;
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(255, 321);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(500, 300);
            this.richTextBoxInitialInstructions.TabIndex = 4;
            this.richTextBoxInitialInstructions.Text = "Initial instructions go here";
            this.richTextBoxInitialInstructions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInitialInstructions_KeyDown);
            // 
            // formDRLDRH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1122, 481);
            this.Controls.Add(this.richTextBoxInitialInstructions);
            this.Controls.Add(this.panelStimuli);
            this.Name = "formDRLDRH";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formDRLDRH_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formDRLDRH_KeyDown);
            this.Resize += new System.EventHandler(this.formDRLDRH_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.stimulus)).EndInit();
            this.panelStimuli.ResumeLayout(false);
            this.panelStimuli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox stimulus;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Panel panelStimuli;
        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
    }
}