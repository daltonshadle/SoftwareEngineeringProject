namespace Tutor_Master
{
    partial class EditProfileStart
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
            this.checkBoxTutor = new System.Windows.Forms.CheckBox();
            this.checkBoxTutee = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelPasswordCheck = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPasswordConfirm = new System.Windows.Forms.Button();
            this.buttonPasswordCancel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelWhole.SuspendLayout();
            this.panelPasswordCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhole
            // 
            this.panelWhole.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelWhole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelWhole.Controls.Add(this.panelPasswordCheck);
            this.panelWhole.Controls.Add(this.buttonPasswordCancel);
            this.panelWhole.Controls.Add(this.checkBoxTutor);
            this.panelWhole.Controls.Add(this.checkBoxTutee);
            this.panelWhole.Controls.Add(this.checkBoxName);
            this.panelWhole.Controls.Add(this.checkBoxPassword);
            this.panelWhole.Controls.Add(this.label1);
            this.panelWhole.Controls.Add(this.buttonConfirm);
            this.panelWhole.Location = new System.Drawing.Point(12, 12);
            this.panelWhole.Name = "panelWhole";
            this.panelWhole.Size = new System.Drawing.Size(260, 219);
            this.panelWhole.TabIndex = 0;
            // 
            // checkBoxTutor
            // 
            this.checkBoxTutor.AutoSize = true;
            this.checkBoxTutor.Location = new System.Drawing.Point(80, 113);
            this.checkBoxTutor.Name = "checkBoxTutor";
            this.checkBoxTutor.Size = new System.Drawing.Size(101, 17);
            this.checkBoxTutor.TabIndex = 6;
            this.checkBoxTutor.Text = "Tutor Properties";
            this.checkBoxTutor.UseVisualStyleBackColor = true;
            // 
            // checkBoxTutee
            // 
            this.checkBoxTutee.AutoSize = true;
            this.checkBoxTutee.Location = new System.Drawing.Point(80, 147);
            this.checkBoxTutee.Name = "checkBoxTutee";
            this.checkBoxTutee.Size = new System.Drawing.Size(104, 17);
            this.checkBoxTutee.TabIndex = 5;
            this.checkBoxTutee.Text = "Tutee Properties";
            this.checkBoxTutee.UseVisualStyleBackColor = true;
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Location = new System.Drawing.Point(80, 79);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxName.TabIndex = 4;
            this.checkBoxName.Text = "Name";
            this.checkBoxName.UseVisualStyleBackColor = true;
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Location = new System.Drawing.Point(80, 46);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(72, 17);
            this.checkBoxPassword.TabIndex = 3;
            this.checkBoxPassword.Text = "Password";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "What fields do you want to edit?";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(146, 184);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(40, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelPasswordCheck
            // 
            this.panelPasswordCheck.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelPasswordCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPasswordCheck.Controls.Add(this.txtPassword);
            this.panelPasswordCheck.Controls.Add(this.label2);
            this.panelPasswordCheck.Controls.Add(this.buttonPasswordConfirm);
            this.panelPasswordCheck.Controls.Add(this.btnCancel);
            this.panelPasswordCheck.Location = new System.Drawing.Point(-2, -2);
            this.panelPasswordCheck.Name = "panelPasswordCheck";
            this.panelPasswordCheck.Size = new System.Drawing.Size(260, 219);
            this.panelPasswordCheck.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter password to edit.";
            // 
            // buttonPasswordConfirm
            // 
            this.buttonPasswordConfirm.Location = new System.Drawing.Point(146, 184);
            this.buttonPasswordConfirm.Name = "buttonPasswordConfirm";
            this.buttonPasswordConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonPasswordConfirm.TabIndex = 1;
            this.buttonPasswordConfirm.Text = "Confirm";
            this.buttonPasswordConfirm.UseVisualStyleBackColor = true;
            this.buttonPasswordConfirm.Click += new System.EventHandler(this.buttonPasswordConfirm_Click);
            // 
            // buttonPasswordCancel
            // 
            this.buttonPasswordCancel.Location = new System.Drawing.Point(40, 184);
            this.buttonPasswordCancel.Name = "buttonPasswordCancel";
            this.buttonPasswordCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonPasswordCancel.TabIndex = 0;
            this.buttonPasswordCancel.Text = "Cancel";
            this.buttonPasswordCancel.UseVisualStyleBackColor = true;
            this.buttonPasswordCancel.Click += new System.EventHandler(this.buttonPasswordCancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(55, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // EditProfileStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.panelWhole);
            this.Name = "EditProfileStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Profile";
            this.panelWhole.ResumeLayout(false);
            this.panelWhole.PerformLayout();
            this.panelPasswordCheck.ResumeLayout(false);
            this.panelPasswordCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWhole;
        private System.Windows.Forms.CheckBox checkBoxTutor;
        private System.Windows.Forms.CheckBox checkBoxTutee;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelPasswordCheck;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPasswordConfirm;
        private System.Windows.Forms.Button buttonPasswordCancel;
    }
}