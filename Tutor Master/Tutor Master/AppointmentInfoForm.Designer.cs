namespace Tutor_Master
{
    partial class AppointmentInfoForm
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTutor = new System.Windows.Forms.Label();
            this.lblTutee = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.Location = new System.Drawing.Point(56, 227);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Location = new System.Drawing.Point(160, 227);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblTutor
            // 
            this.lblTutor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(77, 47);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(66, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "Tutor profile:";
            // 
            // lblTutee
            // 
            this.lblTutee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTutee.AutoSize = true;
            this.lblTutee.Location = new System.Drawing.Point(74, 73);
            this.lblTutee.Name = "lblTutee";
            this.lblTutee.Size = new System.Drawing.Size(69, 13);
            this.lblTutee.TabIndex = 8;
            this.lblTutee.Text = "Tutee profile:";
            // 
            // lblCourse
            // 
            this.lblCourse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(97, 98);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 9;
            this.lblCourse.Text = "Course:";
            // 
            // lblPlace
            // 
            this.lblPlace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(103, 122);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(37, 13);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "Place:";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(51, 23);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(92, 13);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Appointment type:\r\n";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(107, 146);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "Time:";
            // 
            // AppointmentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblTutee);
            this.Controls.Add(this.lblTutor);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Name = "AppointmentInfoForm";
            this.Text = "AppointmentInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.Label lblTutee;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTime;

    }
}