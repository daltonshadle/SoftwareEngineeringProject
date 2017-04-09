namespace Tutor_Master
{
    partial class MatchingAppointmentForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelApptType = new System.Windows.Forms.Panel();
            this.cbxTypeAppt = new System.Windows.Forms.ComboBox();
            this.lblTypeAppt = new System.Windows.Forms.Label();
            this.panelOtherProfile = new System.Windows.Forms.Panel();
            this.cbxProfileList = new System.Windows.Forms.ComboBox();
            this.lblOtherProfile = new System.Windows.Forms.Label();
            this.panelCourse = new System.Windows.Forms.Panel();
            this.cbxCourseList = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.txtMeetingPlace = new System.Windows.Forms.TextBox();
            this.lblMeetingPlace = new System.Windows.Forms.Label();
            this.panelTime = new System.Windows.Forms.Panel();
            this.dateTimeTime2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTime1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDay2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDay1 = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.panelMeetingPlace = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelWeeklyAppt = new System.Windows.Forms.Panel();
            this.cbxWeeklyApt = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNumberWeeklyAppts = new System.Windows.Forms.Panel();
            this.udbWeeks = new System.Windows.Forms.NumericUpDown();
            this.panelApptType.SuspendLayout();
            this.panelOtherProfile.SuspendLayout();
            this.panelCourse.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelMeetingPlace.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelWeeklyAppt.SuspendLayout();
            this.panelNumberWeeklyAppts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udbWeeks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(122, 323);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelApptType
            // 
            this.panelApptType.BackColor = System.Drawing.Color.Transparent;
            this.panelApptType.Controls.Add(this.cbxTypeAppt);
            this.panelApptType.Controls.Add(this.lblTypeAppt);
            this.panelApptType.Location = new System.Drawing.Point(6, 7);
            this.panelApptType.Name = "panelApptType";
            this.panelApptType.Size = new System.Drawing.Size(291, 33);
            this.panelApptType.TabIndex = 0;
            // 
            // cbxTypeAppt
            // 
            this.cbxTypeAppt.FormattingEnabled = true;
            this.cbxTypeAppt.Items.AddRange(new object[] {
            "Free Time",
            "Teaching (Tutoring)",
            "Learning (Tuteeing)"});
            this.cbxTypeAppt.Location = new System.Drawing.Point(161, 6);
            this.cbxTypeAppt.Name = "cbxTypeAppt";
            this.cbxTypeAppt.Size = new System.Drawing.Size(121, 21);
            this.cbxTypeAppt.TabIndex = 1;
            this.cbxTypeAppt.SelectedIndexChanged += new System.EventHandler(this.cbxTypeAppt_SelectedIndexChanged);
            // 
            // lblTypeAppt
            // 
            this.lblTypeAppt.AutoSize = true;
            this.lblTypeAppt.Location = new System.Drawing.Point(6, 9);
            this.lblTypeAppt.Name = "lblTypeAppt";
            this.lblTypeAppt.Size = new System.Drawing.Size(108, 13);
            this.lblTypeAppt.TabIndex = 1;
            this.lblTypeAppt.Text = "Type of Appointment:";
            // 
            // panelOtherProfile
            // 
            this.panelOtherProfile.BackColor = System.Drawing.Color.Transparent;
            this.panelOtherProfile.Controls.Add(this.cbxProfileList);
            this.panelOtherProfile.Controls.Add(this.lblOtherProfile);
            this.panelOtherProfile.Location = new System.Drawing.Point(6, 152);
            this.panelOtherProfile.Name = "panelOtherProfile";
            this.panelOtherProfile.Size = new System.Drawing.Size(291, 33);
            this.panelOtherProfile.TabIndex = 3;
            // 
            // cbxProfileList
            // 
            this.cbxProfileList.FormattingEnabled = true;
            this.cbxProfileList.Location = new System.Drawing.Point(161, 6);
            this.cbxProfileList.Name = "cbxProfileList";
            this.cbxProfileList.Size = new System.Drawing.Size(121, 21);
            this.cbxProfileList.TabIndex = 1;
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
            // panelCourse
            // 
            this.panelCourse.BackColor = System.Drawing.Color.Transparent;
            this.panelCourse.Controls.Add(this.cbxCourseList);
            this.panelCourse.Controls.Add(this.lblCourse);
            this.panelCourse.Location = new System.Drawing.Point(6, 113);
            this.panelCourse.Name = "panelCourse";
            this.panelCourse.Size = new System.Drawing.Size(291, 33);
            this.panelCourse.TabIndex = 6;
            // 
            // cbxCourseList
            // 
            this.cbxCourseList.FormattingEnabled = true;
            this.cbxCourseList.Location = new System.Drawing.Point(161, 8);
            this.cbxCourseList.Name = "cbxCourseList";
            this.cbxCourseList.Size = new System.Drawing.Size(121, 21);
            this.cbxCourseList.TabIndex = 0;
            this.cbxCourseList.SelectedIndexChanged += new System.EventHandler(this.cbxCourseList_SelectedIndexChanged);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(6, 11);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(46, 13);
            this.lblCourse.TabIndex = 1;
            this.lblCourse.Text = "Course: ";
            // 
            // txtMeetingPlace
            // 
            this.txtMeetingPlace.Location = new System.Drawing.Point(161, 7);
            this.txtMeetingPlace.Name = "txtMeetingPlace";
            this.txtMeetingPlace.Size = new System.Drawing.Size(121, 20);
            this.txtMeetingPlace.TabIndex = 0;
            // 
            // lblMeetingPlace
            // 
            this.lblMeetingPlace.AutoSize = true;
            this.lblMeetingPlace.Location = new System.Drawing.Point(6, 10);
            this.lblMeetingPlace.Name = "lblMeetingPlace";
            this.lblMeetingPlace.Size = new System.Drawing.Size(78, 13);
            this.lblMeetingPlace.TabIndex = 2;
            this.lblMeetingPlace.Text = "Meeting Place:";
            // 
            // panelTime
            // 
            this.panelTime.BackColor = System.Drawing.Color.Transparent;
            this.panelTime.Controls.Add(this.dateTimeTime2);
            this.panelTime.Controls.Add(this.dateTimeTime1);
            this.panelTime.Controls.Add(this.dateTimeDay2);
            this.panelTime.Controls.Add(this.dateTimeDay1);
            this.panelTime.Controls.Add(this.lblEndTime);
            this.panelTime.Controls.Add(this.lblStartTime);
            this.panelTime.Location = new System.Drawing.Point(6, 46);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(291, 61);
            this.panelTime.TabIndex = 2;
            // 
            // dateTimeTime2
            // 
            this.dateTimeTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime2.Location = new System.Drawing.Point(178, 36);
            this.dateTimeTime2.Name = "dateTimeTime2";
            this.dateTimeTime2.Size = new System.Drawing.Size(104, 20);
            this.dateTimeTime2.TabIndex = 3;
            this.dateTimeTime2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimeTime1
            // 
            this.dateTimeTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime1.Location = new System.Drawing.Point(177, 5);
            this.dateTimeTime1.Name = "dateTimeTime1";
            this.dateTimeTime1.Size = new System.Drawing.Size(105, 20);
            this.dateTimeTime1.TabIndex = 1;
            this.dateTimeTime1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimeDay2
            // 
            this.dateTimeDay2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay2.Location = new System.Drawing.Point(70, 36);
            this.dateTimeDay2.Name = "dateTimeDay2";
            this.dateTimeDay2.Size = new System.Drawing.Size(101, 20);
            this.dateTimeDay2.TabIndex = 2;
            // 
            // dateTimeDay1
            // 
            this.dateTimeDay1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay1.Location = new System.Drawing.Point(70, 5);
            this.dateTimeDay1.Name = "dateTimeDay1";
            this.dateTimeDay1.Size = new System.Drawing.Size(101, 20);
            this.dateTimeDay1.TabIndex = 0;
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
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "Start Time:";
            // 
            // panelMeetingPlace
            // 
            this.panelMeetingPlace.BackColor = System.Drawing.Color.Transparent;
            this.panelMeetingPlace.Controls.Add(this.lblMeetingPlace);
            this.panelMeetingPlace.Controls.Add(this.txtMeetingPlace);
            this.panelMeetingPlace.Location = new System.Drawing.Point(6, 191);
            this.panelMeetingPlace.Name = "panelMeetingPlace";
            this.panelMeetingPlace.Size = new System.Drawing.Size(291, 33);
            this.panelMeetingPlace.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panelNumberWeeklyAppts);
            this.panel1.Controls.Add(this.panelWeeklyAppt);
            this.panel1.Controls.Add(this.panelMeetingPlace);
            this.panel1.Controls.Add(this.panelApptType);
            this.panel1.Controls.Add(this.panelOtherProfile);
            this.panel1.Controls.Add(this.panelCourse);
            this.panel1.Controls.Add(this.panelTime);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 312);
            this.panel1.TabIndex = 11;
            // 
            // panelWeeklyAppt
            // 
            this.panelWeeklyAppt.BackColor = System.Drawing.Color.Transparent;
            this.panelWeeklyAppt.Controls.Add(this.cbxWeeklyApt);
            this.panelWeeklyAppt.Location = new System.Drawing.Point(6, 230);
            this.panelWeeklyAppt.Name = "panelWeeklyAppt";
            this.panelWeeklyAppt.Size = new System.Drawing.Size(291, 33);
            this.panelWeeklyAppt.TabIndex = 11;
            // 
            // cbxWeeklyApt
            // 
            this.cbxWeeklyApt.AutoSize = true;
            this.cbxWeeklyApt.Location = new System.Drawing.Point(86, 10);
            this.cbxWeeklyApt.Name = "cbxWeeklyApt";
            this.cbxWeeklyApt.Size = new System.Drawing.Size(124, 17);
            this.cbxWeeklyApt.TabIndex = 1;
            this.cbxWeeklyApt.Text = "Weekly Appointment\r\n";
            this.cbxWeeklyApt.UseVisualStyleBackColor = true;
            this.cbxWeeklyApt.CheckedChanged += new System.EventHandler(this.cbxWeeklyApt_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Weekly Appointments:";
            // 
            // panelNumberWeeklyAppts
            // 
            this.panelNumberWeeklyAppts.BackColor = System.Drawing.Color.Transparent;
            this.panelNumberWeeklyAppts.Controls.Add(this.udbWeeks);
            this.panelNumberWeeklyAppts.Controls.Add(this.label1);
            this.panelNumberWeeklyAppts.Location = new System.Drawing.Point(6, 269);
            this.panelNumberWeeklyAppts.Name = "panelNumberWeeklyAppts";
            this.panelNumberWeeklyAppts.Size = new System.Drawing.Size(291, 33);
            this.panelNumberWeeklyAppts.TabIndex = 12;
            this.panelNumberWeeklyAppts.Visible = false;
            // 
            // udbWeeks
            // 
            this.udbWeeks.Location = new System.Drawing.Point(178, 8);
            this.udbWeeks.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udbWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udbWeeks.Name = "udbWeeks";
            this.udbWeeks.Size = new System.Drawing.Size(103, 20);
            this.udbWeeks.TabIndex = 3;
            this.udbWeeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udbWeeks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MatchingAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(316, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Name = "MatchingAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Maker";
            this.panelApptType.ResumeLayout(false);
            this.panelApptType.PerformLayout();
            this.panelOtherProfile.ResumeLayout(false);
            this.panelOtherProfile.PerformLayout();
            this.panelCourse.ResumeLayout(false);
            this.panelCourse.PerformLayout();
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelMeetingPlace.ResumeLayout(false);
            this.panelMeetingPlace.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelWeeklyAppt.ResumeLayout(false);
            this.panelWeeklyAppt.PerformLayout();
            this.panelNumberWeeklyAppts.ResumeLayout(false);
            this.panelNumberWeeklyAppts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udbWeeks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelApptType;
        private System.Windows.Forms.ComboBox cbxTypeAppt;
        private System.Windows.Forms.Label lblTypeAppt;
        private System.Windows.Forms.Panel panelOtherProfile;
        private System.Windows.Forms.ComboBox cbxProfileList;
        private System.Windows.Forms.Label lblOtherProfile;
        private System.Windows.Forms.Panel panelCourse;
        private System.Windows.Forms.ComboBox cbxCourseList;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.TextBox txtMeetingPlace;
        private System.Windows.Forms.Label lblMeetingPlace;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.DateTimePicker dateTimeTime2;
        private System.Windows.Forms.DateTimePicker dateTimeTime1;
        private System.Windows.Forms.DateTimePicker dateTimeDay2;
        private System.Windows.Forms.DateTimePicker dateTimeDay1;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Panel panelMeetingPlace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelNumberWeeklyAppts;
        private System.Windows.Forms.NumericUpDown udbWeeks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelWeeklyAppt;
        private System.Windows.Forms.CheckBox cbxWeeklyApt;
    }
}