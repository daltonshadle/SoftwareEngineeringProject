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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthCalendarForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDailyAppointments = new System.Windows.Forms.Label();
            this.monthCalendar1 = new Tutor_Master.MonthCalendar();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(282, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 285);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // lblDailyAppointments
            // 
            this.lblDailyAppointments.AutoSize = true;
            this.lblDailyAppointments.Location = new System.Drawing.Point(279, 12);
            this.lblDailyAppointments.Name = "lblDailyAppointments";
            this.lblDailyAppointments.Size = new System.Drawing.Size(99, 13);
            this.lblDailyAppointments.TabIndex = 2;
            this.lblDailyAppointments.Text = "Daily appointments:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(245, 229);
            this.monthCalendar1.TabIndex = 0;
            // 
            // MonthCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(548, 326);
            this.Controls.Add(this.lblDailyAppointments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthCalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Month Calendar";
            this.Activated += new System.EventHandler(this.MonthCalendarForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDailyAppointments;
    }
}