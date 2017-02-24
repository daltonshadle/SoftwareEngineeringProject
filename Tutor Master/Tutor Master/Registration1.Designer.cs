namespace Tutor_Master
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.btnNext = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.chkTutor = new System.Windows.Forms.CheckBox();
            this.chkTutee = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Location = new System.Drawing.Point(109, 177);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Continue";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(57, 62);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(178, 13);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "What kind of account do you need?";
            // 
            // chkTutor
            // 
            this.chkTutor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutor.AutoSize = true;
            this.chkTutor.Location = new System.Drawing.Point(83, 114);
            this.chkTutor.Name = "chkTutor";
            this.chkTutor.Size = new System.Drawing.Size(51, 17);
            this.chkTutor.TabIndex = 2;
            this.chkTutor.Text = "Tutor";
            this.chkTutor.UseVisualStyleBackColor = true;
            this.chkTutor.CheckedChanged += new System.EventHandler(this.chkTutor_CheckedChanged);
            // 
            // chkTutee
            // 
            this.chkTutee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutee.AutoSize = true;
            this.chkTutee.Location = new System.Drawing.Point(161, 114);
            this.chkTutee.Name = "chkTutee";
            this.chkTutee.Size = new System.Drawing.Size(54, 17);
            this.chkTutee.TabIndex = 3;
            this.chkTutee.Text = "Tutee";
            this.chkTutee.UseVisualStyleBackColor = true;
            this.chkTutee.CheckedChanged += new System.EventHandler(this.chkTutee_CheckedChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.chkTutee);
            this.Controls.Add(this.chkTutor);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.btnNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registration";
            this.Text = "Registration - Account Type";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.CheckBox chkTutor;
        private System.Windows.Forms.CheckBox chkTutee;
    }
}