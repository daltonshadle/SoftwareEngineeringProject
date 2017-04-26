namespace Tutor_Master
{
    partial class FacultyForm
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
            this.lblMessages = new System.Windows.Forms.Label();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Done = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInbox = new System.Windows.Forms.Button();
            this.btnSent = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessageDetails = new System.Windows.Forms.Label();
            this.rtbMessageDetails = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNameAndUser = new System.Windows.Forms.Label();
            this.lvCourses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTutors = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.Location = new System.Drawing.Point(4, 8);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(71, 29);
            this.lblMessages.TabIndex = 0;
            this.lblMessages.Text = "Inbox";
            // 
            // lvMessages
            // 
            this.lvMessages.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.Subject,
            this.Date,
            this.Done,
            this.To});
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMessages.Location = new System.Drawing.Point(9, 41);
            this.lvMessages.MultiSelect = false;
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(608, 340);
            this.lvMessages.TabIndex = 1;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.SelectedIndexChanged += new System.EventHandler(this.lvMessages_SelectedIndexChanged_1);
            // 
            // From
            // 
            this.From.Text = "From";
            this.From.Width = 69;
            // 
            // Subject
            // 
            this.Subject.Text = "To";
            this.Subject.Width = 108;
            // 
            // Date
            // 
            this.Date.Text = "Subject";
            this.Date.Width = 205;
            // 
            // Done
            // 
            this.Done.Text = "Date";
            this.Done.Width = 161;
            // 
            // To
            // 
            this.To.Text = "Done";
            // 
            // btnInbox
            // 
            this.btnInbox.Location = new System.Drawing.Point(504, 8);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(75, 23);
            this.btnInbox.TabIndex = 2;
            this.btnInbox.Text = "Inbox";
            this.btnInbox.UseVisualStyleBackColor = true;
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnSent
            // 
            this.btnSent.Location = new System.Drawing.Point(387, 8);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(75, 23);
            this.btnSent.TabIndex = 3;
            this.btnSent.Text = "Sent";
            this.btnSent.UseVisualStyleBackColor = true;
            this.btnSent.Click += new System.EventHandler(this.btnSent_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(504, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Message Details";
            // 
            // lblMessageDetails
            // 
            this.lblMessageDetails.AutoSize = true;
            this.lblMessageDetails.BackColor = System.Drawing.Color.White;
            this.lblMessageDetails.Location = new System.Drawing.Point(8, 44);
            this.lblMessageDetails.Name = "lblMessageDetails";
            this.lblMessageDetails.Size = new System.Drawing.Size(0, 13);
            this.lblMessageDetails.TabIndex = 7;
            // 
            // rtbMessageDetails
            // 
            this.rtbMessageDetails.BackColor = System.Drawing.Color.White;
            this.rtbMessageDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessageDetails.Location = new System.Drawing.Point(14, 44);
            this.rtbMessageDetails.Name = "rtbMessageDetails";
            this.rtbMessageDetails.ReadOnly = true;
            this.rtbMessageDetails.Size = new System.Drawing.Size(350, 125);
            this.rtbMessageDetails.TabIndex = 8;
            this.rtbMessageDetails.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Approve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Reject";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Image = global::Tutor_Master.Properties.Resources.Door_50_1_;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.Location = new System.Drawing.Point(1006, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(55, 59);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.rtbMessageDetails);
            this.panel1.Controls.Add(this.lblMessageDetails);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(716, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 213);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSent);
            this.panel2.Controls.Add(this.btnInbox);
            this.panel2.Controls.Add(this.lvMessages);
            this.panel2.Controls.Add(this.lblMessages);
            this.panel2.Location = new System.Drawing.Point(12, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 418);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblNameAndUser);
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Location = new System.Drawing.Point(12, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1087, 73);
            this.panel3.TabIndex = 14;
            // 
            // lblNameAndUser
            // 
            this.lblNameAndUser.AutoSize = true;
            this.lblNameAndUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameAndUser.Location = new System.Drawing.Point(10, 17);
            this.lblNameAndUser.Name = "lblNameAndUser";
            this.lblNameAndUser.Size = new System.Drawing.Size(86, 31);
            this.lblNameAndUser.TabIndex = 12;
            this.lblNameAndUser.Text = "Name";
            // 
            // lvCourses
            // 
            this.lvCourses.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvCourses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lvCourses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvCourses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCourses.Location = new System.Drawing.Point(16, 21);
            this.lvCourses.MultiSelect = false;
            this.lvCourses.Name = "lvCourses";
            this.lvCourses.Size = new System.Drawing.Size(162, 151);
            this.lvCourses.TabIndex = 15;
            this.lvCourses.UseCompatibleStateImageBehavior = false;
            this.lvCourses.View = System.Windows.Forms.View.Details;
            this.lvCourses.SelectedIndexChanged += new System.EventHandler(this.lvCourses_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Your courses:";
            this.columnHeader1.Width = 145;
            // 
            // lvTutors
            // 
            this.lvTutors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvTutors.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lvTutors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvTutors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTutors.Location = new System.Drawing.Point(204, 21);
            this.lvTutors.MultiSelect = false;
            this.lvTutors.Name = "lvTutors";
            this.lvTutors.Size = new System.Drawing.Size(162, 151);
            this.lvTutors.TabIndex = 16;
            this.lvTutors.UseCompatibleStateImageBehavior = false;
            this.lvTutors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tutors for course:";
            this.columnHeader2.Width = 145;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lvCourses);
            this.panel4.Controls.Add(this.lvTutors);
            this.panel4.Location = new System.Drawing.Point(716, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 193);
            this.panel4.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Tutor_Master.Properties.Resources.BCB_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(535, 556);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1111, 887);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FacultyForm";
            this.Text = "Faculty Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.Button btnInbox;
        private System.Windows.Forms.Button btnSent;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessageDetails;
        private System.Windows.Forms.RichTextBox rtbMessageDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader Done;
        private System.Windows.Forms.ColumnHeader To;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNameAndUser;
        private System.Windows.Forms.ListView lvCourses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvTutors;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}