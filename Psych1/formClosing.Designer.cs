namespace Psych1
{
    partial class formClosing
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
            this.labelInitialInstructions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInitialInstructions
            // 
            this.labelInitialInstructions.AutoSize = true;
            this.labelInitialInstructions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInitialInstructions.Location = new System.Drawing.Point(88, 110);
            this.labelInitialInstructions.Name = "labelInitialInstructions";
            this.labelInitialInstructions.Size = new System.Drawing.Size(675, 21);
            this.labelInitialInstructions.TabIndex = 0;
            this.labelInitialInstructions.Text = "Thank you for your participation. Please see your experimenter to complete your s" +
    "ession.";
            // 
            // formClosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 262);
            this.Controls.Add(this.labelInitialInstructions);
            this.Name = "formClosing";
            this.Text = "formClosing";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formClosing_KeyDown);
            this.Resize += new System.EventHandler(this.formClosing_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInitialInstructions;
    }
}