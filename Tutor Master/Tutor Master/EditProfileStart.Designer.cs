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
            this.panelPasswordCheck = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPasswordConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.buttonPasswordCancel = new System.Windows.Forms.Button();
            this.checkBoxTutor = new System.Windows.Forms.CheckBox();
            this.checkBoxTutee = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.panelEditOrDelete = new System.Windows.Forms.Panel();
            this.buttonEditOnSecondPanel = new System.Windows.Forms.Button();
            this.buttonDeleteStuff = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancelEdtorDel = new System.Windows.Forms.Button();
            this.panelWhole.SuspendLayout();
            this.panelPasswordCheck.SuspendLayout();
            this.panelEditOrDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhole
            // 
            this.panelWhole.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelWhole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            // panelPasswordCheck
            // 
            this.panelPasswordCheck.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelPasswordCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPasswordCheck.Controls.Add(this.txtPassword);
            this.panelPasswordCheck.Controls.Add(this.label2);
            this.panelPasswordCheck.Controls.Add(this.buttonPasswordConfirm);
            this.panelPasswordCheck.Controls.Add(this.btnCancel);
            this.panelPasswordCheck.Location = new System.Drawing.Point(12, 12);
            this.panelPasswordCheck.Name = "panelPasswordCheck";
            this.panelPasswordCheck.Size = new System.Drawing.Size(260, 219);
            this.panelPasswordCheck.TabIndex = 7;
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
            // panelEditOrDelete
            // 
            this.panelEditOrDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelEditOrDelete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEditOrDelete.Controls.Add(this.buttonCancelEdtorDel);
            this.panelEditOrDelete.Controls.Add(this.label3);
            this.panelEditOrDelete.Controls.Add(this.buttonEditOnSecondPanel);
            this.panelEditOrDelete.Controls.Add(this.buttonDeleteStuff);
            this.panelEditOrDelete.Location = new System.Drawing.Point(12, 12);
            this.panelEditOrDelete.Name = "panelEditOrDelete";
            this.panelEditOrDelete.Size = new System.Drawing.Size(260, 219);
            this.panelEditOrDelete.TabIndex = 8;
            // 
            // buttonEditOnSecondPanel
            // 
            this.buttonEditOnSecondPanel.Location = new System.Drawing.Point(90, 99);
            this.buttonEditOnSecondPanel.Name = "buttonEditOnSecondPanel";
            this.buttonEditOnSecondPanel.Size = new System.Drawing.Size(75, 23);
            this.buttonEditOnSecondPanel.TabIndex = 1;
            this.buttonEditOnSecondPanel.Text = "Edit";
            this.buttonEditOnSecondPanel.UseVisualStyleBackColor = true;
            this.buttonEditOnSecondPanel.Click += new System.EventHandler(this.buttonEditOnSecondPanel_Click);
            // 
            // buttonDeleteStuff
            // 
            this.buttonDeleteStuff.Location = new System.Drawing.Point(90, 128);
            this.buttonDeleteStuff.Name = "buttonDeleteStuff";
            this.buttonDeleteStuff.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteStuff.TabIndex = 0;
            this.buttonDeleteStuff.Text = "Delete";
            this.buttonDeleteStuff.UseVisualStyleBackColor = true;
            this.buttonDeleteStuff.Click += new System.EventHandler(this.buttonDeleteStuff_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Would you like to edit or delete your profile?";
            // 
            // buttonCancelEdtorDel
            // 
            this.buttonCancelEdtorDel.Location = new System.Drawing.Point(90, 157);
            this.buttonCancelEdtorDel.Name = "buttonCancelEdtorDel";
            this.buttonCancelEdtorDel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelEdtorDel.TabIndex = 3;
            this.buttonCancelEdtorDel.Text = "Cancel";
            this.buttonCancelEdtorDel.UseVisualStyleBackColor = true;
            this.buttonCancelEdtorDel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditProfileStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.panelPasswordCheck);
            this.Controls.Add(this.panelEditOrDelete);
            this.Controls.Add(this.panelWhole);
            this.Name = "EditProfileStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Profile";
            this.panelWhole.ResumeLayout(false);
            this.panelWhole.PerformLayout();
            this.panelPasswordCheck.ResumeLayout(false);
            this.panelPasswordCheck.PerformLayout();
            this.panelEditOrDelete.ResumeLayout(false);
            this.panelEditOrDelete.PerformLayout();
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
        private System.Windows.Forms.Panel panelEditOrDelete;
        private System.Windows.Forms.Button buttonCancelEdtorDel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEditOnSecondPanel;
        private System.Windows.Forms.Button buttonDeleteStuff;
    }
}