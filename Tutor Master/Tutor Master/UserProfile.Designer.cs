﻿namespace Tutor_Master
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
            this.weekCalendar1 = new Tutor_Master.WeekCalendar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
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
            // weekCalendar1
            // 
            this.weekCalendar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weekCalendar1.Location = new System.Drawing.Point(100, 252);
            this.weekCalendar1.Name = "weekCalendar1";
            this.weekCalendar1.Size = new System.Drawing.Size(869, 240);
            this.weekCalendar1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Location = new System.Drawing.Point(203, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(177, 170);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // listView2
            // 
            this.listView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView2.Location = new System.Drawing.Point(456, 56);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(178, 170);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
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
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 517);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbTutor);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.weekCalendar1);
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeekCalendar weekCalendar1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbTutor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
    }
}