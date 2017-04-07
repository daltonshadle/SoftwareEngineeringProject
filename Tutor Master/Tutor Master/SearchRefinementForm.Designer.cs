namespace Tutor_Master
{
    partial class SearchRefinementForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.lblByCourse = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTutor = new System.Windows.Forms.Label();
            this.comboTutor = new System.Windows.Forms.ComboBox();
            this.dateTimeTime1 = new System.Windows.Forms.DateTimePicker();
            this.lblPlace = new System.Windows.Forms.Label();
            this.comboPlace = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimeDay1 = new System.Windows.Forms.DateTimePicker();
            this.btnMoreFields = new System.Windows.Forms.Button();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.checkTime = new System.Windows.Forms.CheckBox();
            this.checkTutor = new System.Windows.Forms.CheckBox();
            this.checkPlace = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(73, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(147, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Refine your search for a tutor.";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(96, 194);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboCourse
            // 
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(108, 100);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(121, 21);
            this.comboCourse.TabIndex = 2;
            // 
            // lblByCourse
            // 
            this.lblByCourse.AutoSize = true;
            this.lblByCourse.Location = new System.Drawing.Point(45, 103);
            this.lblByCourse.Name = "lblByCourse";
            this.lblByCourse.Size = new System.Drawing.Size(57, 13);
            this.lblByCourse.TabIndex = 3;
            this.lblByCourse.Text = "By course:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(279, 76);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "By time:";
            this.lblTime.Visible = false;
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(275, 116);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(46, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "By tutor:";
            this.lblTutor.Visible = false;
            // 
            // comboTutor
            // 
            this.comboTutor.FormattingEnabled = true;
            this.comboTutor.Location = new System.Drawing.Point(327, 113);
            this.comboTutor.Name = "comboTutor";
            this.comboTutor.Size = new System.Drawing.Size(121, 21);
            this.comboTutor.TabIndex = 6;
            this.comboTutor.Visible = false;
            // 
            // dateTimeTime1
            // 
            this.dateTimeTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime1.Location = new System.Drawing.Point(329, 76);
            this.dateTimeTime1.Name = "dateTimeTime1";
            this.dateTimeTime1.ShowUpDown = true;
            this.dateTimeTime1.Size = new System.Drawing.Size(120, 20);
            this.dateTimeTime1.TabIndex = 8;
            this.dateTimeTime1.Visible = false;
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(271, 155);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(51, 13);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "By place:";
            this.lblPlace.Visible = false;
            // 
            // comboPlace
            // 
            this.comboPlace.FormattingEnabled = true;
            this.comboPlace.Location = new System.Drawing.Point(328, 152);
            this.comboPlace.Name = "comboPlace";
            this.comboPlace.Size = new System.Drawing.Size(121, 21);
            this.comboPlace.TabIndex = 9;
            this.comboPlace.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(279, 38);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(46, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "By date:";
            this.lblDate.Visible = false;
            // 
            // dateTimeDay1
            // 
            this.dateTimeDay1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay1.Location = new System.Drawing.Point(328, 38);
            this.dateTimeDay1.Name = "dateTimeDay1";
            this.dateTimeDay1.Size = new System.Drawing.Size(121, 20);
            this.dateTimeDay1.TabIndex = 12;
            this.dateTimeDay1.Visible = false;
            // 
            // btnMoreFields
            // 
            this.btnMoreFields.Location = new System.Drawing.Point(76, 127);
            this.btnMoreFields.Name = "btnMoreFields";
            this.btnMoreFields.Size = new System.Drawing.Size(121, 23);
            this.btnMoreFields.TabIndex = 13;
            this.btnMoreFields.Text = "Show More Criteria";
            this.btnMoreFields.UseVisualStyleBackColor = true;
            this.btnMoreFields.Click += new System.EventHandler(this.btnMoreFields_Click);
            // 
            // checkDate
            // 
            this.checkDate.AutoSize = true;
            this.checkDate.Location = new System.Drawing.Point(456, 40);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(15, 14);
            this.checkDate.TabIndex = 14;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.checkDate_CheckedChanged);
            // 
            // checkTime
            // 
            this.checkTime.AutoSize = true;
            this.checkTime.Location = new System.Drawing.Point(455, 82);
            this.checkTime.Name = "checkTime";
            this.checkTime.Size = new System.Drawing.Size(15, 14);
            this.checkTime.TabIndex = 15;
            this.checkTime.UseVisualStyleBackColor = true;
            this.checkTime.CheckedChanged += new System.EventHandler(this.checkTime_CheckedChanged);
            // 
            // checkTutor
            // 
            this.checkTutor.AutoSize = true;
            this.checkTutor.Location = new System.Drawing.Point(454, 116);
            this.checkTutor.Name = "checkTutor";
            this.checkTutor.Size = new System.Drawing.Size(15, 14);
            this.checkTutor.TabIndex = 16;
            this.checkTutor.UseVisualStyleBackColor = true;
            this.checkTutor.CheckedChanged += new System.EventHandler(this.checkTutor_CheckedChanged);
            // 
            // checkPlace
            // 
            this.checkPlace.AutoSize = true;
            this.checkPlace.Location = new System.Drawing.Point(454, 155);
            this.checkPlace.Name = "checkPlace";
            this.checkPlace.Size = new System.Drawing.Size(15, 14);
            this.checkPlace.TabIndex = 17;
            this.checkPlace.UseVisualStyleBackColor = true;
            this.checkPlace.CheckedChanged += new System.EventHandler(this.checkPlace_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(286, 192);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(163, 26);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = "Check the box next to the criteria\r\nto search with that criteria.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchRefinementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 262);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.checkPlace);
            this.Controls.Add(this.checkTutor);
            this.Controls.Add(this.checkTime);
            this.Controls.Add(this.checkDate);
            this.Controls.Add(this.btnMoreFields);
            this.Controls.Add(this.dateTimeDay1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.comboPlace);
            this.Controls.Add(this.dateTimeTime1);
            this.Controls.Add(this.lblTutor);
            this.Controls.Add(this.comboTutor);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblByCourse);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblHeader);
            this.Name = "SearchRefinementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchRefinementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.Label lblByCourse;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.ComboBox comboTutor;
        private System.Windows.Forms.DateTimePicker dateTimeTime1;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.ComboBox comboPlace;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimeDay1;
        private System.Windows.Forms.Button btnMoreFields;
        private System.Windows.Forms.CheckBox checkDate;
        private System.Windows.Forms.CheckBox checkTime;
        private System.Windows.Forms.CheckBox checkTutor;
        private System.Windows.Forms.CheckBox checkPlace;
        private System.Windows.Forms.Label lblInfo;
    }
}