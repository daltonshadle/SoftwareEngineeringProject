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
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblTutor = new System.Windows.Forms.Label();
            this.comboTutor = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dateTimeStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnMoreFields = new System.Windows.Forms.Button();
            this.checkDates = new System.Windows.Forms.CheckBox();
            this.checkTutor = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dateTimeEndDate = new System.Windows.Forms.DateTimePicker();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.lvMatches = new System.Windows.Forms.ListView();
            this.btnAskToJoin = new System.Windows.Forms.Button();
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
            this.btnSearch.Location = new System.Drawing.Point(107, 163);
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
            this.comboCourse.Location = new System.Drawing.Point(118, 64);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(121, 21);
            this.comboCourse.TabIndex = 2;
            this.comboCourse.SelectedIndexChanged += new System.EventHandler(this.comboCourse_SelectedIndexChanged);
            // 
            // lblByCourse
            // 
            this.lblByCourse.AutoSize = true;
            this.lblByCourse.Location = new System.Drawing.Point(55, 67);
            this.lblByCourse.Name = "lblByCourse";
            this.lblByCourse.Size = new System.Drawing.Size(57, 13);
            this.lblByCourse.TabIndex = 3;
            this.lblByCourse.Text = "By course:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(296, 67);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 13);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End date:";
            this.lblEndDate.Visible = false;
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(313, 113);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(35, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "Tutor:";
            this.lblTutor.Visible = false;
            // 
            // comboTutor
            // 
            this.comboTutor.FormattingEnabled = true;
            this.comboTutor.Location = new System.Drawing.Point(354, 110);
            this.comboTutor.Name = "comboTutor";
            this.comboTutor.Size = new System.Drawing.Size(121, 21);
            this.comboTutor.TabIndex = 6;
            this.comboTutor.Visible = false;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(293, 41);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(56, 13);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Start date:";
            this.lblStartDate.Visible = false;
            // 
            // dateTimeStartDate
            // 
            this.dateTimeStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStartDate.Location = new System.Drawing.Point(355, 35);
            this.dateTimeStartDate.Name = "dateTimeStartDate";
            this.dateTimeStartDate.Size = new System.Drawing.Size(121, 20);
            this.dateTimeStartDate.TabIndex = 12;
            this.dateTimeStartDate.Visible = false;
            this.dateTimeStartDate.ValueChanged += new System.EventHandler(this.dateTimeStartDate_ValueChanged);
            // 
            // btnMoreFields
            // 
            this.btnMoreFields.Location = new System.Drawing.Point(86, 91);
            this.btnMoreFields.Name = "btnMoreFields";
            this.btnMoreFields.Size = new System.Drawing.Size(121, 23);
            this.btnMoreFields.TabIndex = 13;
            this.btnMoreFields.Text = "Show More Criteria";
            this.btnMoreFields.UseVisualStyleBackColor = true;
            this.btnMoreFields.Click += new System.EventHandler(this.btnMoreFields_Click);
            // 
            // checkDates
            // 
            this.checkDates.AutoSize = true;
            this.checkDates.Location = new System.Drawing.Point(482, 51);
            this.checkDates.Name = "checkDates";
            this.checkDates.Size = new System.Drawing.Size(15, 14);
            this.checkDates.TabIndex = 14;
            this.checkDates.UseVisualStyleBackColor = true;
            this.checkDates.Visible = false;
            // 
            // checkTutor
            // 
            this.checkTutor.AutoSize = true;
            this.checkTutor.Location = new System.Drawing.Point(481, 113);
            this.checkTutor.Name = "checkTutor";
            this.checkTutor.Size = new System.Drawing.Size(15, 14);
            this.checkTutor.TabIndex = 16;
            this.checkTutor.UseVisualStyleBackColor = true;
            this.checkTutor.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(313, 160);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(163, 26);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = "Check the box next to the criteria\r\nto search with those criteria.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Visible = false;
            // 
            // dateTimeEndDate
            // 
            this.dateTimeEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEndDate.Location = new System.Drawing.Point(354, 61);
            this.dateTimeEndDate.Name = "dateTimeEndDate";
            this.dateTimeEndDate.Size = new System.Drawing.Size(121, 20);
            this.dateTimeEndDate.TabIndex = 19;
            this.dateTimeEndDate.Visible = false;
            this.dateTimeEndDate.ValueChanged += new System.EventHandler(this.dateTimeEndDate_ValueChanged);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInfo.Location = new System.Drawing.Point(277, 250);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(220, 141);
            this.rtbInfo.TabIndex = 21;
            this.rtbInfo.Text = "";
            // 
            // lvMatches
            // 
            this.lvMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMatches.Location = new System.Drawing.Point(37, 250);
            this.lvMatches.Name = "lvMatches";
            this.lvMatches.Size = new System.Drawing.Size(220, 216);
            this.lvMatches.TabIndex = 20;
            this.lvMatches.UseCompatibleStateImageBehavior = false;
            this.lvMatches.View = System.Windows.Forms.View.List;
            this.lvMatches.SelectedIndexChanged += new System.EventHandler(this.lvMatches_SelectedIndexChanged);
            // 
            // btnAskToJoin
            // 
            this.btnAskToJoin.Location = new System.Drawing.Point(316, 397);
            this.btnAskToJoin.Name = "btnAskToJoin";
            this.btnAskToJoin.Size = new System.Drawing.Size(141, 23);
            this.btnAskToJoin.TabIndex = 22;
            this.btnAskToJoin.Text = "Request this appointment";
            this.btnAskToJoin.UseVisualStyleBackColor = true;
            this.btnAskToJoin.Click += new System.EventHandler(this.btnAskToJoin_Click);
            // 
            // SearchRefinementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 494);
            this.Controls.Add(this.btnAskToJoin);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.lvMatches);
            this.Controls.Add(this.dateTimeEndDate);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.checkTutor);
            this.Controls.Add(this.checkDates);
            this.Controls.Add(this.btnMoreFields);
            this.Controls.Add(this.dateTimeStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblTutor);
            this.Controls.Add(this.comboTutor);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblByCourse);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(400, 100);
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(290, 250);
            this.Name = "SearchRefinementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SearchRefinementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.Label lblByCourse;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.ComboBox comboTutor;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimeStartDate;
        private System.Windows.Forms.Button btnMoreFields;
        private System.Windows.Forms.CheckBox checkDates;
        private System.Windows.Forms.CheckBox checkTutor;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DateTimePicker dateTimeEndDate;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.ListView lvMatches;
        private System.Windows.Forms.Button btnAskToJoin;
    }
}