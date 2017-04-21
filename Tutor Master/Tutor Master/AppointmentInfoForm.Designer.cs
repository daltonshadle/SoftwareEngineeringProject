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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentInfoForm));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTutor = new System.Windows.Forms.Label();
            this.lblTutee = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTypeVal = new System.Windows.Forms.Label();
            this.lblTutorVal = new System.Windows.Forms.Label();
            this.lblTuteeVal = new System.Windows.Forms.Label();
            this.lblCourseVal = new System.Windows.Forms.Label();
            this.lblPlaceVal = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeVal = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateVal = new System.Windows.Forms.Label();
            this.lblEndDateVal = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblEndTimeVal = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.panelTime = new System.Windows.Forms.Panel();
            this.dateTimeTime2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTime1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDay2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDay1 = new System.Windows.Forms.DateTimePicker();
            this.lblEndTimePanel = new System.Windows.Forms.Label();
            this.lblStartTimePanel = new System.Windows.Forms.Label();
            this.txtMeetingPlace = new System.Windows.Forms.TextBox();
            this.cbxCourseList = new System.Windows.Forms.ComboBox();
            this.lblPlacePanel = new System.Windows.Forms.Label();
            this.lblCoursePanel = new System.Windows.Forms.Label();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.btnConfirmEdit = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTime.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(79, 225);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(78, 254);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(56, 32);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(66, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "Tutor profile:";
            // 
            // lblTutee
            // 
            this.lblTutee.AutoSize = true;
            this.lblTutee.Location = new System.Drawing.Point(53, 58);
            this.lblTutee.Name = "lblTutee";
            this.lblTutee.Size = new System.Drawing.Size(69, 13);
            this.lblTutee.TabIndex = 8;
            this.lblTutee.Text = "Tutee profile:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(76, 83);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 9;
            this.lblCourse.Text = "Course:";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(82, 107);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(37, 13);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "Place:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(30, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(92, 13);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Appointment type:\r\n";
            // 
            // lblTypeVal
            // 
            this.lblTypeVal.AutoSize = true;
            this.lblTypeVal.Location = new System.Drawing.Point(128, 8);
            this.lblTypeVal.Name = "lblTypeVal";
            this.lblTypeVal.Size = new System.Drawing.Size(19, 13);
            this.lblTypeVal.TabIndex = 12;
            this.lblTypeVal.Text = "----";
            // 
            // lblTutorVal
            // 
            this.lblTutorVal.AutoSize = true;
            this.lblTutorVal.Location = new System.Drawing.Point(128, 32);
            this.lblTutorVal.Name = "lblTutorVal";
            this.lblTutorVal.Size = new System.Drawing.Size(19, 13);
            this.lblTutorVal.TabIndex = 13;
            this.lblTutorVal.Text = "----";
            // 
            // lblTuteeVal
            // 
            this.lblTuteeVal.AutoSize = true;
            this.lblTuteeVal.Location = new System.Drawing.Point(128, 58);
            this.lblTuteeVal.Name = "lblTuteeVal";
            this.lblTuteeVal.Size = new System.Drawing.Size(19, 13);
            this.lblTuteeVal.TabIndex = 14;
            this.lblTuteeVal.Text = "----";
            // 
            // lblCourseVal
            // 
            this.lblCourseVal.AutoSize = true;
            this.lblCourseVal.Location = new System.Drawing.Point(128, 83);
            this.lblCourseVal.Name = "lblCourseVal";
            this.lblCourseVal.Size = new System.Drawing.Size(19, 13);
            this.lblCourseVal.TabIndex = 15;
            this.lblCourseVal.Text = "----";
            // 
            // lblPlaceVal
            // 
            this.lblPlaceVal.AutoSize = true;
            this.lblPlaceVal.Location = new System.Drawing.Point(128, 107);
            this.lblPlaceVal.Name = "lblPlaceVal";
            this.lblPlaceVal.Size = new System.Drawing.Size(19, 13);
            this.lblPlaceVal.TabIndex = 16;
            this.lblPlaceVal.Text = "----";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(65, 129);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(54, 13);
            this.lblTime.TabIndex = 17;
            this.lblTime.Text = "Start time:";
            // 
            // lblTimeVal
            // 
            this.lblTimeVal.AutoSize = true;
            this.lblTimeVal.Location = new System.Drawing.Point(128, 129);
            this.lblTimeVal.Name = "lblTimeVal";
            this.lblTimeVal.Size = new System.Drawing.Size(19, 13);
            this.lblTimeVal.TabIndex = 18;
            this.lblTimeVal.Text = "----";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(63, 151);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(56, 13);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Start date:";
            // 
            // lblDateVal
            // 
            this.lblDateVal.AutoSize = true;
            this.lblDateVal.Location = new System.Drawing.Point(128, 151);
            this.lblDateVal.Name = "lblDateVal";
            this.lblDateVal.Size = new System.Drawing.Size(19, 13);
            this.lblDateVal.TabIndex = 20;
            this.lblDateVal.Text = "----";
            // 
            // lblEndDateVal
            // 
            this.lblEndDateVal.AutoSize = true;
            this.lblEndDateVal.Location = new System.Drawing.Point(128, 195);
            this.lblEndDateVal.Name = "lblEndDateVal";
            this.lblEndDateVal.Size = new System.Drawing.Size(19, 13);
            this.lblEndDateVal.TabIndex = 24;
            this.lblEndDateVal.Text = "----";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(63, 195);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 13);
            this.lblEndDate.TabIndex = 23;
            this.lblEndDate.Text = "End date:";
            // 
            // lblEndTimeVal
            // 
            this.lblEndTimeVal.AutoSize = true;
            this.lblEndTimeVal.Location = new System.Drawing.Point(128, 173);
            this.lblEndTimeVal.Name = "lblEndTimeVal";
            this.lblEndTimeVal.Size = new System.Drawing.Size(19, 13);
            this.lblEndTimeVal.TabIndex = 22;
            this.lblEndTimeVal.Text = "----";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(65, 173);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(51, 13);
            this.lblEndTime.TabIndex = 21;
            this.lblEndTime.Text = "End time:";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(79, 284);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 25;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // panelTime
            // 
            this.panelTime.Controls.Add(this.dateTimeTime2);
            this.panelTime.Controls.Add(this.dateTimeTime1);
            this.panelTime.Controls.Add(this.dateTimeDay2);
            this.panelTime.Controls.Add(this.dateTimeDay1);
            this.panelTime.Controls.Add(this.lblEndTimePanel);
            this.panelTime.Controls.Add(this.lblStartTimePanel);
            this.panelTime.Location = new System.Drawing.Point(21, 82);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(291, 61);
            this.panelTime.TabIndex = 49;
            this.panelTime.Visible = false;
            // 
            // dateTimeTime2
            // 
            this.dateTimeTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime2.Location = new System.Drawing.Point(186, 36);
            this.dateTimeTime2.Name = "dateTimeTime2";
            this.dateTimeTime2.ShowUpDown = true;
            this.dateTimeTime2.Size = new System.Drawing.Size(105, 20);
            this.dateTimeTime2.TabIndex = 5;
            this.dateTimeTime2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimeTime1
            // 
            this.dateTimeTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime1.Location = new System.Drawing.Point(186, 5);
            this.dateTimeTime1.Name = "dateTimeTime1";
            this.dateTimeTime1.ShowUpDown = true;
            this.dateTimeTime1.Size = new System.Drawing.Size(105, 20);
            this.dateTimeTime1.TabIndex = 4;
            this.dateTimeTime1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimeDay2
            // 
            this.dateTimeDay2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay2.Location = new System.Drawing.Point(72, 36);
            this.dateTimeDay2.Name = "dateTimeDay2";
            this.dateTimeDay2.Size = new System.Drawing.Size(101, 20);
            this.dateTimeDay2.TabIndex = 2;
            this.dateTimeDay2.ValueChanged += new System.EventHandler(this.dateTimeDay2_ValueChanged);
            // 
            // dateTimeDay1
            // 
            this.dateTimeDay1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay1.Location = new System.Drawing.Point(72, 5);
            this.dateTimeDay1.Name = "dateTimeDay1";
            this.dateTimeDay1.Size = new System.Drawing.Size(101, 20);
            this.dateTimeDay1.TabIndex = 0;
            this.dateTimeDay1.ValueChanged += new System.EventHandler(this.dateTimeDay1_ValueChanged);
            // 
            // lblEndTimePanel
            // 
            this.lblEndTimePanel.AutoSize = true;
            this.lblEndTimePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTimePanel.Location = new System.Drawing.Point(6, 39);
            this.lblEndTimePanel.Name = "lblEndTimePanel";
            this.lblEndTimePanel.Size = new System.Drawing.Size(55, 13);
            this.lblEndTimePanel.TabIndex = 1;
            this.lblEndTimePanel.Text = "End Time:";
            // 
            // lblStartTimePanel
            // 
            this.lblStartTimePanel.AutoSize = true;
            this.lblStartTimePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTimePanel.Location = new System.Drawing.Point(3, 11);
            this.lblStartTimePanel.Name = "lblStartTimePanel";
            this.lblStartTimePanel.Size = new System.Drawing.Size(58, 13);
            this.lblStartTimePanel.TabIndex = 0;
            this.lblStartTimePanel.Text = "Start Time:";
            // 
            // txtMeetingPlace
            // 
            this.txtMeetingPlace.Location = new System.Drawing.Point(93, 66);
            this.txtMeetingPlace.Name = "txtMeetingPlace";
            this.txtMeetingPlace.Size = new System.Drawing.Size(121, 20);
            this.txtMeetingPlace.TabIndex = 48;
            this.txtMeetingPlace.Visible = false;
            // 
            // cbxCourseList
            // 
            this.cbxCourseList.FormattingEnabled = true;
            this.cbxCourseList.Location = new System.Drawing.Point(93, 39);
            this.cbxCourseList.Name = "cbxCourseList";
            this.cbxCourseList.Size = new System.Drawing.Size(121, 21);
            this.cbxCourseList.TabIndex = 47;
            this.cbxCourseList.Visible = false;
            this.cbxCourseList.SelectedIndexChanged += new System.EventHandler(this.cbxCourseList_SelectedIndexChanged);
            // 
            // lblPlacePanel
            // 
            this.lblPlacePanel.AutoSize = true;
            this.lblPlacePanel.Location = new System.Drawing.Point(44, 66);
            this.lblPlacePanel.Name = "lblPlacePanel";
            this.lblPlacePanel.Size = new System.Drawing.Size(37, 13);
            this.lblPlacePanel.TabIndex = 45;
            this.lblPlacePanel.Text = "Place:";
            this.lblPlacePanel.Visible = false;
            // 
            // lblCoursePanel
            // 
            this.lblCoursePanel.AutoSize = true;
            this.lblCoursePanel.Location = new System.Drawing.Point(38, 42);
            this.lblCoursePanel.Name = "lblCoursePanel";
            this.lblCoursePanel.Size = new System.Drawing.Size(43, 13);
            this.lblCoursePanel.TabIndex = 44;
            this.lblCoursePanel.Text = "Course:";
            this.lblCoursePanel.Visible = false;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdit.Controls.Add(this.label1);
            this.panelEdit.Controls.Add(this.panelTime);
            this.panelEdit.Controls.Add(this.txtMeetingPlace);
            this.panelEdit.Controls.Add(this.cbxCourseList);
            this.panelEdit.Controls.Add(this.lblPlacePanel);
            this.panelEdit.Controls.Add(this.lblCoursePanel);
            this.panelEdit.Location = new System.Drawing.Point(276, 72);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(337, 183);
            this.panelEdit.TabIndex = 53;
            this.panelEdit.Visible = false;
            // 
            // btnConfirmEdit
            // 
            this.btnConfirmEdit.Location = new System.Drawing.Point(417, 261);
            this.btnConfirmEdit.Name = "btnConfirmEdit";
            this.btnConfirmEdit.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmEdit.TabIndex = 54;
            this.btnConfirmEdit.Text = "Confirm Edit";
            this.btnConfirmEdit.UseVisualStyleBackColor = true;
            this.btnConfirmEdit.Visible = false;
            this.btnConfirmEdit.Click += new System.EventHandler(this.btnConfirmEdit_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(78, 313);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 55;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.btnReject);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblTutor);
            this.panel1.Controls.Add(this.btnApprove);
            this.panel1.Controls.Add(this.lblTutee);
            this.panel1.Controls.Add(this.lblEndDateVal);
            this.panel1.Controls.Add(this.lblCourse);
            this.panel1.Controls.Add(this.lblEndDate);
            this.panel1.Controls.Add(this.lblPlace);
            this.panel1.Controls.Add(this.lblEndTimeVal);
            this.panel1.Controls.Add(this.lblTypeVal);
            this.panel1.Controls.Add(this.lblEndTime);
            this.panel1.Controls.Add(this.lblTutorVal);
            this.panel1.Controls.Add(this.lblDateVal);
            this.panel1.Controls.Add(this.lblTuteeVal);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblCourseVal);
            this.panel1.Controls.Add(this.lblTimeVal);
            this.panel1.Controls.Add(this.lblPlaceVal);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 347);
            this.panel1.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Edit fields here";
            // 
            // AppointmentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(631, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirmEdit);
            this.Controls.Add(this.panelEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppointmentInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentInfoForm";
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.Label lblTutee;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTypeVal;
        private System.Windows.Forms.Label lblTutorVal;
        private System.Windows.Forms.Label lblTuteeVal;
        private System.Windows.Forms.Label lblCourseVal;
        private System.Windows.Forms.Label lblPlaceVal;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeVal;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateVal;
        private System.Windows.Forms.Label lblEndDateVal;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblEndTimeVal;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.DateTimePicker dateTimeDay2;
        private System.Windows.Forms.DateTimePicker dateTimeDay1;
        private System.Windows.Forms.Label lblEndTimePanel;
        private System.Windows.Forms.Label lblStartTimePanel;
        private System.Windows.Forms.TextBox txtMeetingPlace;
        private System.Windows.Forms.ComboBox cbxCourseList;
        private System.Windows.Forms.Label lblPlacePanel;
        private System.Windows.Forms.Label lblCoursePanel;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.DateTimePicker dateTimeTime2;
        private System.Windows.Forms.DateTimePicker dateTimeTime1;
        private System.Windows.Forms.Button btnConfirmEdit;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}