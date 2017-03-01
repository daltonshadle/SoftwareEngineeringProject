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
            this.weekCalendar1 = new Tutor_Master.WeekCalendar();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weekCalendar1
            // 
            this.weekCalendar1.Location = new System.Drawing.Point(100, 252);
            this.weekCalendar1.Name = "weekCalendar1";
            this.weekCalendar1.Size = new System.Drawing.Size(869, 240);
            this.weekCalendar1.TabIndex = 0;
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
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 517);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.weekCalendar1);
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private WeekCalendar weekCalendar1;
        private System.Windows.Forms.Button btnLogout;
    }
}