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
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnViewCal = new System.Windows.Forms.Button();
            this.weekCalendar = new Tutor_Master.WeekCalendar();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(979, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbTutor
            // 
            this.lbTutor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTutor.AutoSize = true;
            this.lbTutor.Location = new System.Drawing.Point(200, 22);
            this.lbTutor.Name = "lbTutor";
            this.lbTutor.Size = new System.Drawing.Size(101, 13);
            this.lbTutor.TabIndex = 3;
            this.lbTutor.Text = "Courses for tutoring:";
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Location = new System.Drawing.Point(203, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(119, 101);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.Visible = false;
            // 
            // listView2
            // 
            this.listView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView2.Location = new System.Drawing.Point(456, 56);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(119, 101);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.SmallIcon;
            this.listView2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Courses to be tutored in:";
            // 
            // btnAddApp
            // 
            this.btnAddApp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddApp.Location = new System.Drawing.Point(766, 43);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(97, 23);
            this.btnAddApp.TabIndex = 8;
            this.btnAddApp.Text = "Add appointment";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // btnViewCal
            // 
            this.btnViewCal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewCal.Location = new System.Drawing.Point(766, 73);
            this.btnViewCal.Name = "btnViewCal";
            this.btnViewCal.Size = new System.Drawing.Size(97, 23);
            this.btnViewCal.TabIndex = 9;
            this.btnViewCal.Text = "View Calendar";
            this.btnViewCal.UseVisualStyleBackColor = true;
            this.btnViewCal.Click += new System.EventHandler(this.btnViewCal_Click);
            // 
            // weekCalendar
            // 
            this.weekCalendar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weekCalendar.Location = new System.Drawing.Point(12, 198);
            this.weekCalendar.Name = "weekCalendar";
            this.weekCalendar.Size = new System.Drawing.Size(870, 351);
            this.weekCalendar.TabIndex = 7;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 517);
            this.Controls.Add(this.btnViewCal);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.weekCalendar);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbTutor);
            this.Controls.Add(this.btnLogout);
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbTutor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private WeekCalendar weekCalendar;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.Button btnViewCal;
    }
}