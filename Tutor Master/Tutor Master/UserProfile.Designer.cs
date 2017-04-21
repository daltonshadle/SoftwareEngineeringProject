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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbTutor = new System.Windows.Forms.Label();
            this.tutorListView = new System.Windows.Forms.ListView();
            this.tuteeListView = new System.Windows.Forms.ListView();
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
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.weekCalendar = new Tutor_Master.WeekCalendar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelAdmin.SuspendLayout();
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
            this.lbTutor.Location = new System.Drawing.Point(45, 18);
            this.lbTutor.Name = "lbTutor";
            this.lbTutor.Size = new System.Drawing.Size(101, 13);
            this.lbTutor.TabIndex = 3;
            this.lbTutor.Text = "Courses for tutoring:";
            // 
            // tutorListView
            // 
            this.tutorListView.Location = new System.Drawing.Point(24, 43);
            this.tutorListView.Name = "tutorListView";
            this.tutorListView.Size = new System.Drawing.Size(150, 101);
            this.tutorListView.TabIndex = 4;
            this.tutorListView.UseCompatibleStateImageBehavior = false;
            this.tutorListView.View = System.Windows.Forms.View.SmallIcon;
            this.tutorListView.Visible = false;
            // 
            // tuteeListView
            // 
            this.tuteeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.tuteeListView.Location = new System.Drawing.Point(199, 43);
            this.tuteeListView.Name = "tuteeListView";
            this.tuteeListView.Size = new System.Drawing.Size(150, 101);
            this.tuteeListView.TabIndex = 6;
            this.tuteeListView.UseCompatibleStateImageBehavior = false;
            this.tuteeListView.View = System.Windows.Forms.View.SmallIcon;
            this.tuteeListView.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 18);
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
            this.btnAddTutorCourses.Location = new System.Drawing.Point(59, 72);
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
            this.btnAddTuteeCourses.Location = new System.Drawing.Point(238, 72);
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
            this.panel1.Controls.Add(this.tuteeListView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tutorListView);
            this.panel1.Controls.Add(this.lbTutor);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 157);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnRefinedSearch);
            this.panel2.Controls.Add(this.buttonEditProfile);
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
            // buttonEditProfile
            // 
            this.buttonEditProfile.Location = new System.Drawing.Point(453, 7);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonEditProfile.TabIndex = 17;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Location = new System.Drawing.Point(20, 27);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(423, 27);
            this.lblAdmin.TabIndex = 17;
            this.lblAdmin.Text = "YOU ARE VIEWING AS AN ADMIN.";
            this.lblAdmin.Visible = false;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdmin.Location = new System.Drawing.Point(163, 56);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(149, 23);
            this.btnAdmin.TabIndex = 18;
            this.btnAdmin.Text = "Return to admin page.\r\n";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAdmin.BackColor = System.Drawing.Color.DarkRed;
            this.panelAdmin.Controls.Add(this.lblAdmin);
            this.panelAdmin.Controls.Add(this.btnAdmin);
            this.panelAdmin.Location = new System.Drawing.Point(514, 107);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(466, 100);
            this.panelAdmin.TabIndex = 19;
            this.panelAdmin.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Image = global::Tutor_Master.Properties.Resources.small_animated_pizza;
            this.button1.Location = new System.Drawing.Point(1040, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 50);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.weekCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.UserProfile_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbTutor;
        private System.Windows.Forms.ListView tutorListView;
        private System.Windows.Forms.ListView tuteeListView;
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
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Button button1;
    }
}