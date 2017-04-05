namespace Tutor_Master
{
    partial class TuteeMatcher
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
            this.lblDailyAppointments = new System.Windows.Forms.Label();
            this.monthCalendar1 = new Tutor_Master.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar2 = new Tutor_Master.MonthCalendar();
            this.SuspendLayout();
            // 
            // lblDailyAppointments
            // 
            this.lblDailyAppointments.AutoSize = true;
            this.lblDailyAppointments.Location = new System.Drawing.Point(-6, -115);
            this.lblDailyAppointments.Name = "lblDailyAppointments";
            this.lblDailyAppointments.Size = new System.Drawing.Size(99, 13);
            this.lblDailyAppointments.TabIndex = 5;
            this.lblDailyAppointments.Text = "Daily appointments:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(-76, -115);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(48, 229);
            this.monthCalendar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Daily appointments:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(311, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 525);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(41, 25);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.Size = new System.Drawing.Size(245, 229);
            this.monthCalendar2.TabIndex = 6;
            // 
            // TuteeMatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 591);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.lblDailyAppointments);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "TuteeMatcher";
            this.Text = "TuteeMatcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDailyAppointments;
        private MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private MonthCalendar monthCalendar2;
    }
}