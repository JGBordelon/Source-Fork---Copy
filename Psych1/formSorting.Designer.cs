namespace Psych1
{
    partial class formSorting
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
            this.labelReprimand = new System.Windows.Forms.Label();
            this.labelInitialInstructions = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.groupBoxA1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTopLeft = new System.Windows.Forms.PictureBox();
            this.groupBoxA2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTopRight = new System.Windows.Forms.PictureBox();
            this.draggableStimulus1 = new Psych1.DraggableStimulus();
            this.draggableStimulus3 = new Psych1.DraggableStimulus();
            this.draggableStimulus4 = new Psych1.DraggableStimulus();
            this.draggableStimulus2 = new Psych1.DraggableStimulus();
            this.panelStimuli = new System.Windows.Forms.Panel();
            this.groupBoxA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).BeginInit();
            this.groupBoxA2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus2)).BeginInit();
            this.panelStimuli.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelReprimand
            // 
            this.labelReprimand.AutoSize = true;
            this.labelReprimand.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReprimand.Location = new System.Drawing.Point(92, 23);
            this.labelReprimand.Name = "labelReprimand";
            this.labelReprimand.Size = new System.Drawing.Size(689, 24);
            this.labelReprimand.TabIndex = 4;
            this.labelReprimand.Text = "You must choose a place in a box for that stimulus before clicking this button.";
            this.labelReprimand.Visible = false;
            // 
            // labelInitialInstructions
            // 
            this.labelInitialInstructions.AutoSize = true;
            this.labelInitialInstructions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInitialInstructions.Location = new System.Drawing.Point(92, 26);
            this.labelInitialInstructions.Name = "labelInitialInstructions";
            this.labelInitialInstructions.Size = new System.Drawing.Size(723, 21);
            this.labelInitialInstructions.TabIndex = 5;
            this.labelInitialInstructions.Text = "Drag Each Stimulus to the Box Where it Belongs. Then Press the Button. Press Spac" +
    "e to Begin.";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(330, 82);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(252, 32);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "This Belongs Here";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // groupBoxA1
            // 
            this.groupBoxA1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxA1.BackColor = System.Drawing.Color.White;
            this.groupBoxA1.Controls.Add(this.pictureBoxTopLeft);
            this.groupBoxA1.Location = new System.Drawing.Point(717, 82);
            this.groupBoxA1.Name = "groupBoxA1";
            this.groupBoxA1.Size = new System.Drawing.Size(200, 493);
            this.groupBoxA1.TabIndex = 1;
            this.groupBoxA1.TabStop = false;
            // 
            // pictureBoxTopLeft
            // 
            this.pictureBoxTopLeft.Location = new System.Drawing.Point(52, 36);
            this.pictureBoxTopLeft.Name = "pictureBoxTopLeft";
            this.pictureBoxTopLeft.Size = new System.Drawing.Size(90, 90);
            this.pictureBoxTopLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTopLeft.TabIndex = 0;
            this.pictureBoxTopLeft.TabStop = false;
            // 
            // groupBoxA2
            // 
            this.groupBoxA2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBoxA2.BackColor = System.Drawing.Color.White;
            this.groupBoxA2.Controls.Add(this.pictureBoxTopRight);
            this.groupBoxA2.Location = new System.Drawing.Point(12, 82);
            this.groupBoxA2.Name = "groupBoxA2";
            this.groupBoxA2.Size = new System.Drawing.Size(200, 493);
            this.groupBoxA2.TabIndex = 1;
            this.groupBoxA2.TabStop = false;
            // 
            // pictureBoxTopRight
            // 
            this.pictureBoxTopRight.Location = new System.Drawing.Point(52, 36);
            this.pictureBoxTopRight.Name = "pictureBoxTopRight";
            this.pictureBoxTopRight.Size = new System.Drawing.Size(90, 90);
            this.pictureBoxTopRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTopRight.TabIndex = 0;
            this.pictureBoxTopRight.TabStop = false;
            // 
            // draggableStimulus1
            // 
            this.draggableStimulus1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.draggableStimulus1.Location = new System.Drawing.Point(415, 203);
            this.draggableStimulus1.Name = "draggableStimulus1";
            this.draggableStimulus1.Size = new System.Drawing.Size(90, 90);
            this.draggableStimulus1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draggableStimulus1.TabIndex = 2;
            this.draggableStimulus1.TabStop = false;
            this.draggableStimulus1.Visible = false;
            this.draggableStimulus1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseDown);
            this.draggableStimulus1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseMove);
            this.draggableStimulus1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseUp);
            // 
            // draggableStimulus3
            // 
            this.draggableStimulus3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.draggableStimulus3.Location = new System.Drawing.Point(415, 203);
            this.draggableStimulus3.Name = "draggableStimulus3";
            this.draggableStimulus3.Size = new System.Drawing.Size(90, 90);
            this.draggableStimulus3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draggableStimulus3.TabIndex = 2;
            this.draggableStimulus3.TabStop = false;
            this.draggableStimulus3.Visible = false;
            this.draggableStimulus3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseDown);
            this.draggableStimulus3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseMove);
            this.draggableStimulus3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseUp);
            // 
            // draggableStimulus4
            // 
            this.draggableStimulus4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.draggableStimulus4.Location = new System.Drawing.Point(415, 203);
            this.draggableStimulus4.Name = "draggableStimulus4";
            this.draggableStimulus4.Size = new System.Drawing.Size(90, 90);
            this.draggableStimulus4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draggableStimulus4.TabIndex = 2;
            this.draggableStimulus4.TabStop = false;
            this.draggableStimulus4.Visible = false;
            this.draggableStimulus4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseDown);
            this.draggableStimulus4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseMove);
            this.draggableStimulus4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseUp);
            // 
            // draggableStimulus2
            // 
            this.draggableStimulus2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.draggableStimulus2.Location = new System.Drawing.Point(415, 203);
            this.draggableStimulus2.Name = "draggableStimulus2";
            this.draggableStimulus2.Size = new System.Drawing.Size(90, 90);
            this.draggableStimulus2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.draggableStimulus2.TabIndex = 2;
            this.draggableStimulus2.TabStop = false;
            this.draggableStimulus2.Visible = false;
            this.draggableStimulus2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseDown);
            this.draggableStimulus2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseMove);
            this.draggableStimulus2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draggableStimuls_MouseUp);
            // 
            // panelStimuli
            // 
            this.panelStimuli.Controls.Add(this.groupBoxA2);
            this.panelStimuli.Controls.Add(this.groupBoxA1);
            this.panelStimuli.Controls.Add(this.buttonSubmit);
            this.panelStimuli.Location = new System.Drawing.Point(0, 0);
            this.panelStimuli.Name = "panelStimuli";
            this.panelStimuli.Size = new System.Drawing.Size(929, 586);
            this.panelStimuli.TabIndex = 6;
            // 
            // formSorting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 668);
            this.Controls.Add(this.labelReprimand);
            this.Controls.Add(this.labelInitialInstructions);
            this.Controls.Add(this.draggableStimulus1);
            this.Controls.Add(this.draggableStimulus3);
            this.Controls.Add(this.draggableStimulus4);
            this.Controls.Add(this.draggableStimulus2);
            this.Controls.Add(this.panelStimuli);
            this.Name = "formSorting";
            this.Text = "formSorting";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSorting_KeyDown);
            this.Resize += new System.EventHandler(this.formDRLDRH_Resize);
            this.groupBoxA1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).EndInit();
            this.groupBoxA2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.draggableStimulus2)).EndInit();
            this.panelStimuli.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReprimand;
        private System.Windows.Forms.Label labelInitialInstructions;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.GroupBox groupBoxA1;
        private System.Windows.Forms.PictureBox pictureBoxTopLeft;
        private System.Windows.Forms.GroupBox groupBoxA2;
        private System.Windows.Forms.PictureBox pictureBoxTopRight;
        private DraggableStimulus draggableStimulus4;
        private DraggableStimulus draggableStimulus3;
        private DraggableStimulus draggableStimulus2;
        private DraggableStimulus draggableStimulus1;
        private System.Windows.Forms.Panel panelStimuli;
    }
}