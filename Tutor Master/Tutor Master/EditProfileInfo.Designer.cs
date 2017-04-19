namespace Tutor_Master
{
    partial class EditProfileInfo
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
            this.panelWhole = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panelTutee = new System.Windows.Forms.Panel();
            this.checkTutee = new System.Windows.Forms.CheckBox();
            this.checkListTuteeCourses = new System.Windows.Forms.CheckedListBox();
            this.panelTutor = new System.Windows.Forms.Panel();
            this.checkTutor = new System.Windows.Forms.CheckBox();
            this.checkListTutorCourses = new System.Windows.Forms.CheckedListBox();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.panelWhole.SuspendLayout();
            this.panelTutee.SuspendLayout();
            this.panelTutor.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panelPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhole
            // 
            this.panelWhole.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelWhole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelWhole.Controls.Add(this.btnCancel);
            this.panelWhole.Controls.Add(this.btnConfirm);
            this.panelWhole.Controls.Add(this.panelTutee);
            this.panelWhole.Controls.Add(this.panelTutor);
            this.panelWhole.Controls.Add(this.panelName);
            this.panelWhole.Controls.Add(this.panelPassword);
            this.panelWhole.Location = new System.Drawing.Point(6, 7);
            this.panelWhole.Name = "panelWhole";
            this.panelWhole.Size = new System.Drawing.Size(305, 342);
            this.panelWhole.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(72, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(158, 312);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panelTutee
            // 
            this.panelTutee.Controls.Add(this.checkTutee);
            this.panelTutee.Controls.Add(this.checkListTuteeCourses);
            this.panelTutee.Location = new System.Drawing.Point(158, 147);
            this.panelTutee.Name = "panelTutee";
            this.panelTutee.Size = new System.Drawing.Size(140, 158);
            this.panelTutee.TabIndex = 15;
            // 
            // checkTutee
            // 
            this.checkTutee.AutoSize = true;
            this.checkTutee.Location = new System.Drawing.Point(44, 7);
            this.checkTutee.Name = "checkTutee";
            this.checkTutee.Size = new System.Drawing.Size(54, 17);
            this.checkTutee.TabIndex = 2;
            this.checkTutee.Text = "Tutee";
            this.checkTutee.UseVisualStyleBackColor = true;
            // 
            // checkListTuteeCourses
            // 
            this.checkListTuteeCourses.FormattingEnabled = true;
            this.checkListTuteeCourses.Location = new System.Drawing.Point(11, 30);
            this.checkListTuteeCourses.Name = "checkListTuteeCourses";
            this.checkListTuteeCourses.Size = new System.Drawing.Size(120, 124);
            this.checkListTuteeCourses.TabIndex = 1;
            // 
            // panelTutor
            // 
            this.panelTutor.Controls.Add(this.checkTutor);
            this.panelTutor.Controls.Add(this.checkListTutorCourses);
            this.panelTutor.Location = new System.Drawing.Point(7, 147);
            this.panelTutor.Name = "panelTutor";
            this.panelTutor.Size = new System.Drawing.Size(140, 158);
            this.panelTutor.TabIndex = 14;
            // 
            // checkTutor
            // 
            this.checkTutor.AutoSize = true;
            this.checkTutor.Location = new System.Drawing.Point(42, 7);
            this.checkTutor.Name = "checkTutor";
            this.checkTutor.Size = new System.Drawing.Size(51, 17);
            this.checkTutor.TabIndex = 1;
            this.checkTutor.Text = "Tutor";
            this.checkTutor.UseVisualStyleBackColor = true;
            // 
            // checkListTutorCourses
            // 
            this.checkListTutorCourses.FormattingEnabled = true;
            this.checkListTutorCourses.Location = new System.Drawing.Point(9, 30);
            this.checkListTutorCourses.Name = "checkListTutorCourses";
            this.checkListTutorCourses.Size = new System.Drawing.Size(120, 124);
            this.checkListTutorCourses.TabIndex = 0;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.Transparent;
            this.panelName.Controls.Add(this.txtLastName);
            this.panelName.Controls.Add(this.label2);
            this.panelName.Controls.Add(this.label3);
            this.panelName.Controls.Add(this.txtFirstName);
            this.panelName.Location = new System.Drawing.Point(7, 76);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(291, 65);
            this.panelName.TabIndex = 13;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(161, 36);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(161, 7);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.Transparent;
            this.panelPassword.Controls.Add(this.txtConfirmPassword);
            this.panelPassword.Controls.Add(this.lblConfirmPassword);
            this.panelPassword.Controls.Add(this.lblNewPassword);
            this.panelPassword.Controls.Add(this.txtNewPassword);
            this.panelPassword.Location = new System.Drawing.Point(7, 5);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(291, 65);
            this.panelPassword.TabIndex = 10;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(161, 36);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(121, 20);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 39);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(119, 13);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm New Password:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(6, 10);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(81, 13);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(161, 7);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(121, 20);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // EditProfileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(316, 355);
            this.Controls.Add(this.panelWhole);
            this.Name = "EditProfileInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Profile";
            this.panelWhole.ResumeLayout(false);
            this.panelTutee.ResumeLayout(false);
            this.panelTutee.PerformLayout();
            this.panelTutor.ResumeLayout(false);
            this.panelTutor.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWhole;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panelTutee;
        private System.Windows.Forms.CheckBox checkTutee;
        private System.Windows.Forms.CheckedListBox checkListTuteeCourses;
        private System.Windows.Forms.Panel panelTutor;
        private System.Windows.Forms.CheckBox checkTutor;
        private System.Windows.Forms.CheckedListBox checkListTutorCourses;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
    }
}