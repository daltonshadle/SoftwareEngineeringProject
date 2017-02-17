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
            this.button1 = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.chkTutor = new System.Windows.Forms.CheckBox();
            this.chkTutee = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.chkTutee);
            this.Controls.Add(this.chkTutor);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.button1);
            this.Name = "Registration";
            this.Text = "Resitration1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.CheckBox chkTutor;
        private System.Windows.Forms.CheckBox chkTutee;
    }
}