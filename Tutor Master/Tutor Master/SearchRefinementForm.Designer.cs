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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchRefinementForm));
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
<<<<<<< HEAD
            this.lvMatches = new System.Windows.Forms.ListView();
            this.columnAppointments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAskToJoin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
=======
            this.btnAskToJoin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvMatches = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
>>>>>>> 83b7ccb164e50703e68835c3f90606c47b703771
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(35, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(147, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Refine your search for a tutor.";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(68, 138);
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
            this.comboCourse.Location = new System.Drawing.Point(79, 39);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(121, 21);
            this.comboCourse.TabIndex = 2;
            this.comboCourse.SelectedIndexChanged += new System.EventHandler(this.comboCourse_SelectedIndexChanged);
            // 
            // lblByCourse
            // 
            this.lblByCourse.AutoSize = true;
            this.lblByCourse.Location = new System.Drawing.Point(16, 42);
            this.lblByCourse.Name = "lblByCourse";
            this.lblByCourse.Size = new System.Drawing.Size(57, 13);
            this.lblByCourse.TabIndex = 3;
            this.lblByCourse.Text = "By course:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(15, 47);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 13);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End date:";
            this.lblEndDate.Visible = false;
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(32, 93);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(35, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "Tutor:";
            this.lblTutor.Visible = false;
            // 
            // comboTutor
            // 
            this.comboTutor.FormattingEnabled = true;
            this.comboTutor.Location = new System.Drawing.Point(73, 90);
            this.comboTutor.Name = "comboTutor";
            this.comboTutor.Size = new System.Drawing.Size(121, 21);
            this.comboTutor.TabIndex = 6;
            this.comboTutor.Visible = false;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(12, 21);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(56, 13);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Start date:";
            this.lblStartDate.Visible = false;
            // 
            // dateTimeStartDate
            // 
            this.dateTimeStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStartDate.Location = new System.Drawing.Point(74, 15);
            this.dateTimeStartDate.Name = "dateTimeStartDate";
            this.dateTimeStartDate.Size = new System.Drawing.Size(121, 20);
            this.dateTimeStartDate.TabIndex = 12;
            this.dateTimeStartDate.Visible = false;
            this.dateTimeStartDate.ValueChanged += new System.EventHandler(this.dateTimeStartDate_ValueChanged);
            // 
            // btnMoreFields
            // 
            this.btnMoreFields.Location = new System.Drawing.Point(47, 66);
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
            this.checkDates.Location = new System.Drawing.Point(201, 31);
            this.checkDates.Name = "checkDates";
            this.checkDates.Size = new System.Drawing.Size(15, 14);
            this.checkDates.TabIndex = 14;
            this.checkDates.UseVisualStyleBackColor = true;
            this.checkDates.Visible = false;
            // 
            // checkTutor
            // 
            this.checkTutor.AutoSize = true;
            this.checkTutor.Location = new System.Drawing.Point(200, 93);
            this.checkTutor.Name = "checkTutor";
            this.checkTutor.Size = new System.Drawing.Size(15, 14);
            this.checkTutor.TabIndex = 16;
            this.checkTutor.UseVisualStyleBackColor = true;
            this.checkTutor.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(32, 140);
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
            this.dateTimeEndDate.Location = new System.Drawing.Point(73, 41);
            this.dateTimeEndDate.Name = "dateTimeEndDate";
            this.dateTimeEndDate.Size = new System.Drawing.Size(121, 20);
            this.dateTimeEndDate.TabIndex = 19;
            this.dateTimeEndDate.Visible = false;
            this.dateTimeEndDate.ValueChanged += new System.EventHandler(this.dateTimeEndDate_ValueChanged);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInfo.Location = new System.Drawing.Point(302, 250);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(220, 141);
            this.rtbInfo.TabIndex = 21;
            this.rtbInfo.Text = "";
            // 
<<<<<<< HEAD
            // lvMatches
            // 
            this.lvMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAppointments});
            this.lvMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMatches.FullRowSelect = true;
            this.lvMatches.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMatches.Location = new System.Drawing.Point(37, 250);
            this.lvMatches.Name = "lvMatches";
            this.lvMatches.Size = new System.Drawing.Size(220, 80);
            this.lvMatches.TabIndex = 20;
            this.lvMatches.UseCompatibleStateImageBehavior = false;
            this.lvMatches.View = System.Windows.Forms.View.Details;
            this.lvMatches.SelectedIndexChanged += new System.EventHandler(this.lvMatches_SelectedIndexChanged);
            // 
            // columnAppointments
            // 
            this.columnAppointments.Text = "Appointments";
            this.columnAppointments.Width = 203;
            // 
=======
>>>>>>> 83b7ccb164e50703e68835c3f90606c47b703771
            // btnAskToJoin
            // 
            this.btnAskToJoin.Location = new System.Drawing.Point(341, 397);
            this.btnAskToJoin.Name = "btnAskToJoin";
            this.btnAskToJoin.Size = new System.Drawing.Size(141, 23);
            this.btnAskToJoin.TabIndex = 22;
            this.btnAskToJoin.Text = "Request this appointment";
            this.btnAskToJoin.UseVisualStyleBackColor = true;
            this.btnAskToJoin.Click += new System.EventHandler(this.btnAskToJoin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboCourse);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblByCourse);
            this.panel1.Controls.Add(this.btnMoreFields);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Location = new System.Drawing.Point(37, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 182);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Controls.Add(this.lblEndDate);
            this.panel2.Controls.Add(this.comboTutor);
            this.panel2.Controls.Add(this.lblTutor);
            this.panel2.Controls.Add(this.lblStartDate);
            this.panel2.Controls.Add(this.dateTimeEndDate);
            this.panel2.Controls.Add(this.dateTimeStartDate);
            this.panel2.Controls.Add(this.checkDates);
            this.panel2.Controls.Add(this.checkTutor);
            this.panel2.Location = new System.Drawing.Point(302, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 182);
            this.panel2.TabIndex = 24;
            // 
<<<<<<< HEAD
=======
            // lvMatches
            // 
            this.lvMatches.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvMatches.FullRowSelect = true;
            this.lvMatches.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMatches.Location = new System.Drawing.Point(76, 132);
            this.lvMatches.Name = "lvMatches";
            this.lvMatches.Size = new System.Drawing.Size(220, 313);
            this.lvMatches.TabIndex = 25;
            this.lvMatches.UseCompatibleStateImageBehavior = false;
            this.lvMatches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Usernames:";
            this.columnHeader1.Width = 199;
            // 
>>>>>>> 83b7ccb164e50703e68835c3f90606c47b703771
            // SearchRefinementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(564, 494);
            this.Controls.Add(this.lvMatches);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAskToJoin);
            this.Controls.Add(this.rtbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 100);
            this.MaximumSize = new System.Drawing.Size(570, 550);
            this.MinimumSize = new System.Drawing.Size(290, 250);
            this.Name = "SearchRefinementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Refined Searching";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnAskToJoin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvMatches;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}