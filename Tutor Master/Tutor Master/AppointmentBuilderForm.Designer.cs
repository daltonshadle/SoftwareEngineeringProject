namespace Tutor_Master
{
    partial class AppointmentBuilderForm
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
            this.panelTime = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.panelCourseAndPlace = new System.Windows.Forms.Panel();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cbxCourseList = new System.Windows.Forms.ComboBox();
            this.lblMeetingPlace = new System.Windows.Forms.Label();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.panelOtherProfile = new System.Windows.Forms.Panel();
            this.lblOtherProfile = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelApptType = new System.Windows.Forms.Panel();
            this.lblTypeAppt = new System.Windows.Forms.Label();
            this.cbxTypeAppt = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelTime.SuspendLayout();
            this.panelCourseAndPlace.SuspendLayout();
            this.panelOtherProfile.SuspendLayout();
            this.panelApptType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTime
            // 
            this.panelTime.Controls.Add(this.dateTimePicker2);
            this.panelTime.Controls.Add(this.dateTimePicker1);
            this.panelTime.Controls.Add(this.lblEndTime);
            this.panelTime.Controls.Add(this.lblStartTime);
            this.panelTime.Location = new System.Drawing.Point(12, 12);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(273, 61);
            this.panelTime.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(70, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(70, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(6, 39);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 13);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "End Time:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(6, 8);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time:";
            // 
            // panelCourseAndPlace
            // 
            this.panelCourseAndPlace.Controls.Add(this.txtPlace);
            this.panelCourseAndPlace.Controls.Add(this.lblMeetingPlace);
            this.panelCourseAndPlace.Controls.Add(this.cbxCourseList);
            this.panelCourseAndPlace.Controls.Add(this.lblCourse);
            this.panelCourseAndPlace.Location = new System.Drawing.Point(12, 96);
            this.panelCourseAndPlace.Name = "panelCourseAndPlace";
            this.panelCourseAndPlace.Size = new System.Drawing.Size(273, 61);
            this.panelCourseAndPlace.TabIndex = 1;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(6, 11);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(46, 13);
            this.lblCourse.TabIndex = 0;
            this.lblCourse.Text = "Course: ";
            // 
            // cbxCourseList
            // 
            this.cbxCourseList.FormattingEnabled = true;
            this.cbxCourseList.Location = new System.Drawing.Point(149, 8);
            this.cbxCourseList.Name = "cbxCourseList";
            this.cbxCourseList.Size = new System.Drawing.Size(121, 21);
            this.cbxCourseList.TabIndex = 1;
            // 
            // lblMeetingPlace
            // 
            this.lblMeetingPlace.AutoSize = true;
            this.lblMeetingPlace.Location = new System.Drawing.Point(6, 41);
            this.lblMeetingPlace.Name = "lblMeetingPlace";
            this.lblMeetingPlace.Size = new System.Drawing.Size(78, 13);
            this.lblMeetingPlace.TabIndex = 2;
            this.lblMeetingPlace.Text = "Meeting Place:";
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(149, 35);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(121, 20);
            this.txtPlace.TabIndex = 3;
            // 
            // panelOtherProfile
            // 
            this.panelOtherProfile.Controls.Add(this.textBox1);
            this.panelOtherProfile.Controls.Add(this.lblOtherProfile);
            this.panelOtherProfile.Location = new System.Drawing.Point(12, 173);
            this.panelOtherProfile.Name = "panelOtherProfile";
            this.panelOtherProfile.Size = new System.Drawing.Size(273, 30);
            this.panelOtherProfile.TabIndex = 2;
            // 
            // lblOtherProfile
            // 
            this.lblOtherProfile.AutoSize = true;
            this.lblOtherProfile.Location = new System.Drawing.Point(6, 9);
            this.lblOtherProfile.Name = "lblOtherProfile";
            this.lblOtherProfile.Size = new System.Drawing.Size(68, 13);
            this.lblOtherProfile.TabIndex = 0;
            this.lblOtherProfile.Text = "Other Profile:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 1;
            // 
            // panelApptType
            // 
            this.panelApptType.Controls.Add(this.cbxTypeAppt);
            this.panelApptType.Controls.Add(this.lblTypeAppt);
            this.panelApptType.Location = new System.Drawing.Point(12, 220);
            this.panelApptType.Name = "panelApptType";
            this.panelApptType.Size = new System.Drawing.Size(273, 33);
            this.panelApptType.TabIndex = 3;
            // 
            // lblTypeAppt
            // 
            this.lblTypeAppt.AutoSize = true;
            this.lblTypeAppt.Location = new System.Drawing.Point(6, 9);
            this.lblTypeAppt.Name = "lblTypeAppt";
            this.lblTypeAppt.Size = new System.Drawing.Size(108, 13);
            this.lblTypeAppt.TabIndex = 0;
            this.lblTypeAppt.Text = "Type of Appointment:";
            // 
            // cbxTypeAppt
            // 
            this.cbxTypeAppt.FormattingEnabled = true;
            this.cbxTypeAppt.Location = new System.Drawing.Point(149, 6);
            this.cbxTypeAppt.Name = "cbxTypeAppt";
            this.cbxTypeAppt.Size = new System.Drawing.Size(121, 21);
            this.cbxTypeAppt.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(105, 281);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // AppointmentBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 359);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelApptType);
            this.Controls.Add(this.panelOtherProfile);
            this.Controls.Add(this.panelCourseAndPlace);
            this.Controls.Add(this.panelTime);
            this.Name = "AppointmentBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Builder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelCourseAndPlace.ResumeLayout(false);
            this.panelCourseAndPlace.PerformLayout();
            this.panelOtherProfile.ResumeLayout(false);
            this.panelOtherProfile.PerformLayout();
            this.panelApptType.ResumeLayout(false);
            this.panelApptType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Panel panelCourseAndPlace;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblMeetingPlace;
        private System.Windows.Forms.ComboBox cbxCourseList;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Panel panelOtherProfile;
        private System.Windows.Forms.Label lblOtherProfile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelApptType;
        private System.Windows.Forms.ComboBox cbxTypeAppt;
        private System.Windows.Forms.Label lblTypeAppt;
        private System.Windows.Forms.Button btnAdd;
    }
}