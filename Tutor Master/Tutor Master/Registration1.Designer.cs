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
            this.btnNext = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.chkTutor = new System.Windows.Forms.CheckBox();
            this.chkTutee = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFreatures = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Location = new System.Drawing.Point(94, 248);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Continue";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(44, 70);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(178, 13);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "What kind of account do you need?";
            // 
            // chkTutor
            // 
            this.chkTutor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutor.AutoSize = true;
            this.chkTutor.Location = new System.Drawing.Point(106, 113);
            this.chkTutor.Name = "chkTutor";
            this.chkTutor.Size = new System.Drawing.Size(51, 17);
            this.chkTutor.TabIndex = 0;
            this.chkTutor.Text = "Tutor";
            this.chkTutor.UseVisualStyleBackColor = true;
            this.chkTutor.CheckedChanged += new System.EventHandler(this.chkTutor_CheckedChanged);
            // 
            // chkTutee
            // 
            this.chkTutee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutee.AutoSize = true;
            this.chkTutee.Location = new System.Drawing.Point(106, 155);
            this.chkTutee.Name = "chkTutee";
            this.chkTutee.Size = new System.Drawing.Size(54, 17);
            this.chkTutee.TabIndex = 1;
            this.chkTutee.Text = "Tutee";
            this.chkTutee.UseVisualStyleBackColor = true;
            this.chkTutee.CheckedChanged += new System.EventHandler(this.chkTutee_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkTutee);
            this.panel1.Controls.Add(this.chkTutor);
            this.panel1.Controls.Add(this.lblIntro);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Location = new System.Drawing.Point(530, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 299);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Tutor_Master.Properties.Resources.BCB_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(450, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblFreatures);
            this.panel2.Controls.Add(this.btnSignIn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(220, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 299);
            this.panel2.TabIndex = 31;
            // 
            // lblFreatures
            // 
            this.lblFreatures.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFreatures.AutoSize = true;
            this.lblFreatures.Location = new System.Drawing.Point(30, 76);
            this.lblFreatures.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblFreatures.Name = "lblFreatures";
            this.lblFreatures.Size = new System.Drawing.Size(67, 13);
            this.lblFreatures.TabIndex = 26;
            this.lblFreatures.Text = "Features List";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignIn.Location = new System.Drawing.Point(90, 260);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Already have a profile? Sign in!";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Registration";
            this.Text = "Registration - Account Type";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.CheckBox chkTutor;
        private System.Windows.Forms.CheckBox chkTutee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFreatures;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
    }
}