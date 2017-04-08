namespace Tutor_Master
{
    partial class UserProfile
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbTutor = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewCal = new System.Windows.Forms.Button();
            this.btnMatchingAppoint = new System.Windows.Forms.Button();
            this.lblNameAndUser = new System.Windows.Forms.Label();
            this.btnViewMessages = new System.Windows.Forms.Button();
            this.btnAddTutorCourses = new System.Windows.Forms.Button();
            this.btnAddTuteeCourses = new System.Windows.Forms.Button();
            this.btnRefinedSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.weekCalendar = new Tutor_Master.WeekCalendar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogout.Location = new System.Drawing.Point(972, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbTutor
            // 
            this.lbTutor.AutoSize = true;
            this.lbTutor.Location = new System.Drawing.Point(23, 18);
            this.lbTutor.Name = "lbTutor";
            this.lbTutor.Size = new System.Drawing.Size(101, 13);
            this.lbTutor.TabIndex = 3;
            this.lbTutor.Text = "Courses for tutoring:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(14, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(119, 101);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.Visible = false;
            // 
            // listView2
            // 
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView2.Location = new System.Drawing.Point(178, 43);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(119, 101);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.SmallIcon;
            this.listView2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Courses to be tutored in:";
            // 
            // btnViewCal
            // 
            this.btnViewCal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnViewCal.Location = new System.Drawing.Point(869, 7);
            this.btnViewCal.Name = "btnViewCal";
            this.btnViewCal.Size = new System.Drawing.Size(97, 23);
            this.btnViewCal.TabIndex = 9;
            this.btnViewCal.Text = "View Calendar";
            this.btnViewCal.UseVisualStyleBackColor = true;
            this.btnViewCal.Click += new System.EventHandler(this.btnViewCal_Click);
            // 
            // btnMatchingAppoint
            // 
            this.btnMatchingAppoint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMatchingAppoint.Location = new System.Drawing.Point(749, 7);
            this.btnMatchingAppoint.Name = "btnMatchingAppoint";
            this.btnMatchingAppoint.Size = new System.Drawing.Size(114, 23);
            this.btnMatchingAppoint.TabIndex = 10;
            this.btnMatchingAppoint.Text = "Make Appointment";
            this.btnMatchingAppoint.UseVisualStyleBackColor = true;
            this.btnMatchingAppoint.Click += new System.EventHandler(this.btnMatchingAppoint_Click);
            // 
            // lblNameAndUser
            // 
            this.lblNameAndUser.AutoSize = true;
            this.lblNameAndUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndUser.Location = new System.Drawing.Point(8, 2);
            this.lblNameAndUser.Name = "lblNameAndUser";
            this.lblNameAndUser.Size = new System.Drawing.Size(86, 31);
            this.lblNameAndUser.TabIndex = 10;
            this.lblNameAndUser.Text = "Name";
            // 
            // btnViewMessages
            // 
            this.btnViewMessages.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnViewMessages.Location = new System.Drawing.Point(653, 7);
            this.btnViewMessages.Name = "btnViewMessages";
            this.btnViewMessages.Size = new System.Drawing.Size(90, 23);
            this.btnViewMessages.TabIndex = 11;
            this.btnViewMessages.Text = "View Messages";
            this.btnViewMessages.UseVisualStyleBackColor = true;
            this.btnViewMessages.Click += new System.EventHandler(this.btnViewMessages_Click);
            // 
            // btnAddTutorCourses
            // 
            this.btnAddTutorCourses.Location = new System.Drawing.Point(35, 72);
            this.btnAddTutorCourses.Name = "btnAddTutorCourses";
            this.btnAddTutorCourses.Size = new System.Drawing.Size(75, 23);
            this.btnAddTutorCourses.TabIndex = 12;
            this.btnAddTutorCourses.Text = "Add Courses";
            this.btnAddTutorCourses.UseVisualStyleBackColor = true;
            this.btnAddTutorCourses.Visible = false;
            this.btnAddTutorCourses.Click += new System.EventHandler(this.btnAddTutorCourses_Click);
            // 
            // btnAddTuteeCourses
            // 
            this.btnAddTuteeCourses.Location = new System.Drawing.Point(201, 72);
            this.btnAddTuteeCourses.Name = "btnAddTuteeCourses";
            this.btnAddTuteeCourses.Size = new System.Drawing.Size(75, 23);
            this.btnAddTuteeCourses.TabIndex = 13;
            this.btnAddTuteeCourses.Text = "Add Courses";
            this.btnAddTuteeCourses.UseVisualStyleBackColor = true;
            this.btnAddTuteeCourses.Visible = false;
            this.btnAddTuteeCourses.Click += new System.EventHandler(this.buttAddTuteeCourses_Click);
            // 
            // btnRefinedSearch
            // 
            this.btnRefinedSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefinedSearch.Location = new System.Drawing.Point(534, 7);
            this.btnRefinedSearch.Name = "btnRefinedSearch";
            this.btnRefinedSearch.Size = new System.Drawing.Size(113, 23);
            this.btnRefinedSearch.TabIndex = 14;
            this.btnRefinedSearch.Text = "Refined Searching";
            this.btnRefinedSearch.UseVisualStyleBackColor = true;
            this.btnRefinedSearch.Click += new System.EventHandler(this.btnRefinedSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnAddTuteeCourses);
            this.panel1.Controls.Add(this.btnAddTutorCourses);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.lbTutor);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 157);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnRefinedSearch);
            this.panel2.Controls.Add(this.btnViewMessages);
            this.panel2.Controls.Add(this.lblNameAndUser);
            this.panel2.Controls.Add(this.btnMatchingAppoint);
            this.panel2.Controls.Add(this.btnViewCal);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1079, 43);
            this.panel2.TabIndex = 16;
            // 
            // weekCalendar
            // 
            this.weekCalendar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.weekCalendar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.weekCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.weekCalendar.Location = new System.Drawing.Point(12, 253);
            this.weekCalendar.Name = "weekCalendar";
            this.weekCalendar.Size = new System.Drawing.Size(1079, 383);
            this.weekCalendar.TabIndex = 7;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1107, 715);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.weekCalendar);
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbTutor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private WeekCalendar weekCalendar;
        private System.Windows.Forms.Button btnViewCal;
        private System.Windows.Forms.Button btnMatchingAppoint;
        private System.Windows.Forms.Label lblNameAndUser;
        private System.Windows.Forms.Button btnViewMessages;
        private System.Windows.Forms.Button btnAddTutorCourses;
        private System.Windows.Forms.Button btnAddTuteeCourses;
        private System.Windows.Forms.Button btnRefinedSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}