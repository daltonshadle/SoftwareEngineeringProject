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
            this.btnCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxTutee = new System.Windows.Forms.CheckBox();
            this.checkBoxTutor = new System.Windows.Forms.CheckBox();
            this.panelWhole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhole
            // 
            this.panelWhole.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelWhole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelWhole.Controls.Add(this.checkBoxTutor);
            this.panelWhole.Controls.Add(this.checkBoxTutee);
            this.panelWhole.Controls.Add(this.checkBoxName);
            this.panelWhole.Controls.Add(this.checkBoxPassword);
            this.panelWhole.Controls.Add(this.label1);
            this.panelWhole.Controls.Add(this.buttonConfirm);
            this.panelWhole.Controls.Add(this.btnCancel);
            this.panelWhole.Location = new System.Drawing.Point(12, 12);
            this.panelWhole.Name = "panelWhole";
            this.panelWhole.Size = new System.Drawing.Size(260, 219);
            this.panelWhole.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(35, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "What fields do you want to edit?";
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
            // EditProfileStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.panelWhole);
            this.Name = "EditProfileStart";
            this.Text = "Edit Profile";
            this.panelWhole.ResumeLayout(false);
            this.panelWhole.PerformLayout();
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
    }
}