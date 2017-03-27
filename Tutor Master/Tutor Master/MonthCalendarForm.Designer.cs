namespace Tutor_Master
{
    partial class MonthCalendarForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new Tutor_Master.MonthCalendar();
            this.lblDailyAppointments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(333, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 525);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.monthCalendar1.Location = new System.Drawing.Point(82, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(245, 229);
            this.monthCalendar1.TabIndex = 0;
            // 
            // lblDailyAppointments
            // 
            this.lblDailyAppointments.AutoSize = true;
            this.lblDailyAppointments.Location = new System.Drawing.Point(333, 12);
            this.lblDailyAppointments.Name = "lblDailyAppointments";
            this.lblDailyAppointments.Size = new System.Drawing.Size(99, 13);
            this.lblDailyAppointments.TabIndex = 2;
            this.lblDailyAppointments.Text = "Daily appointments:";
            // 
            // MonthCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 326);
            this.Controls.Add(this.lblDailyAppointments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "MonthCalendarForm";
            this.Text = "MonthCalendarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDailyAppointments;
    }
}