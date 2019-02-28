namespace Psych1
{
    partial class formWriting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxInitialInstructions = new System.Windows.Forms.RichTextBox();
            this.textBoxWriting = new System.Windows.Forms.TextBox();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.panelYesNo = new System.Windows.Forms.Panel();
            this.labelYesNo = new System.Windows.Forms.Label();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.smoothProgressBar1 = new Psych1.SmoothProgressBar();
            this.panelYesNo.SuspendLayout();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxInitialInstructions
            // 
            this.richTextBoxInitialInstructions.BackColor = System.Drawing.Color.White;
            this.richTextBoxInitialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInitialInstructions.Location = new System.Drawing.Point(405, 10);
            this.richTextBoxInitialInstructions.Name = "richTextBoxInitialInstructions";
            this.richTextBoxInitialInstructions.ReadOnly = true;
            this.richTextBoxInitialInstructions.Size = new System.Drawing.Size(390, 35);
            this.richTextBoxInitialInstructions.TabIndex = 0;
            this.richTextBoxInitialInstructions.Text = "Instructions go here";
            // 
            // textBoxWriting
            // 
            this.textBoxWriting.Location = new System.Drawing.Point(193, 51);
            this.textBoxWriting.Multiline = true;
            this.textBoxWriting.Name = "textBoxWriting";
            this.textBoxWriting.Size = new System.Drawing.Size(745, 243);
            this.textBoxWriting.TabIndex = 1;
            // 
            // buttonBegin
            // 
            this.buttonBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBegin.Location = new System.Drawing.Point(193, 323);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(118, 39);
            this.buttonBegin.TabIndex = 2;
            this.buttonBegin.Text = "Begin";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // panelYesNo
            // 
            this.panelYesNo.Controls.Add(this.labelYesNo);
            this.panelYesNo.Controls.Add(this.buttonNo);
            this.panelYesNo.Controls.Add(this.buttonYes);
            this.panelYesNo.Location = new System.Drawing.Point(417, 323);
            this.panelYesNo.Name = "panelYesNo";
            this.panelYesNo.Size = new System.Drawing.Size(296, 112);
            this.panelYesNo.TabIndex = 3;
            // 
            // labelYesNo
            // 
            this.labelYesNo.AutoSize = true;
            this.labelYesNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYesNo.Location = new System.Drawing.Point(21, 19);
            this.labelYesNo.Name = "labelYesNo";
            this.labelYesNo.Size = new System.Drawing.Size(248, 20);
            this.labelYesNo.TabIndex = 3;
            this.labelYesNo.Text = "May we keep your writing sample?";
            // 
            // buttonNo
            // 
            this.buttonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNo.Location = new System.Drawing.Point(174, 57);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(95, 39);
            this.buttonNo.TabIndex = 2;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonYes.Location = new System.Drawing.Point(25, 57);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(95, 39);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.buttonBegin);
            this.panelStimuli.Controls.Add(this.richTextBoxInitialInstructions);
            this.panelStimuli.Controls.Add(this.panelYesNo);
            this.panelStimuli.Controls.Add(this.textBoxWriting);
            this.panelStimuli.Location = new System.Drawing.Point(34, 74);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(1111, 441);
            this.panelStimuli.TabIndex = 4;
            // 
            // smoothProgressBar1
            // 
            this.smoothProgressBar1.Location = new System.Drawing.Point(227, 16);
            this.smoothProgressBar1.Maximum = 100;
            this.smoothProgressBar1.Minimum = 0;
            this.smoothProgressBar1.Name = "smoothProgressBar1";
            this.smoothProgressBar1.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            this.smoothProgressBar1.Size = new System.Drawing.Size(745, 40);
            this.smoothProgressBar1.TabIndex = 5;
            this.smoothProgressBar1.Value = 0;
            // 
            // formWriting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 530);
            this.Controls.Add(this.smoothProgressBar1);
            this.Controls.Add(this.panelStimuli);
            this.Name = "formWriting";
            this.Text = "formWriting";
            this.panelYesNo.ResumeLayout(false);
            this.panelYesNo.PerformLayout();
            this.panelStimuli.ResumeLayout(false);
            this.panelStimuli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInitialInstructions;
        private System.Windows.Forms.TextBox textBoxWriting;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Panel panelYesNo;
        private System.Windows.Forms.Label labelYesNo;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Panel panelStimuli;
        private SmoothProgressBar smoothProgressBar1;
    }
}