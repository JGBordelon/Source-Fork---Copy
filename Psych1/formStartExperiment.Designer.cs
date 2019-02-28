namespace Psych1
{
    partial class formStartExperiment
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxComputerID = new System.Windows.Forms.TextBox();
            this.textBoxParticipantID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonRandom = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Computer ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Participant ID";
            // 
            // textBoxComputerID
            // 
            this.textBoxComputerID.Location = new System.Drawing.Point(182, 61);
            this.textBoxComputerID.Name = "textBoxComputerID";
            this.textBoxComputerID.Size = new System.Drawing.Size(100, 20);
            this.textBoxComputerID.TabIndex = 1;
            // 
            // textBoxParticipantID
            // 
            this.textBoxParticipantID.Location = new System.Drawing.Point(182, 35);
            this.textBoxParticipantID.Name = "textBoxParticipantID";
            this.textBoxParticipantID.Size = new System.Drawing.Size(100, 20);
            this.textBoxParticipantID.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Begin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonRandom
            // 
            this.radioButtonRandom.AutoSize = true;
            this.radioButtonRandom.Location = new System.Drawing.Point(102, 138);
            this.radioButtonRandom.Name = "radioButtonRandom";
            this.radioButtonRandom.Size = new System.Drawing.Size(163, 17);
            this.radioButtonRandom.TabIndex = 3;
            this.radioButtonRandom.TabStop = true;
            this.radioButtonRandom.Text = "Randomize Game/Trial Order";
            this.radioButtonRandom.UseVisualStyleBackColor = true;
            // 
            // formStartExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 176);
            this.Controls.Add(this.radioButtonRandom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxParticipantID);
            this.Controls.Add(this.textBoxComputerID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "formStartExperiment";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxComputerID;
        private System.Windows.Forms.TextBox textBoxParticipantID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonRandom;
    }
}