namespace Tutor_Master
{
    partial class MonthCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.profileMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTempDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profileMonthCalendar
            // 
            this.profileMonthCalendar.Location = new System.Drawing.Point(9, 58);
            this.profileMonthCalendar.Name = "profileMonthCalendar";
            this.profileMonthCalendar.TabIndex = 0;
            this.profileMonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.profileMonthCalendar_DateSelected);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(80, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(81, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Profile Calendar";
            // 
            // lblTempDate
            // 
            this.lblTempDate.AutoSize = true;
            this.lblTempDate.Location = new System.Drawing.Point(104, 36);
            this.lblTempDate.Name = "lblTempDate";
            this.lblTempDate.Size = new System.Drawing.Size(26, 13);
            this.lblTempDate.TabIndex = 4;
            this.lblTempDate.Text = "Day";
            // 
            // MonthCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTempDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.profileMonthCalendar);
            this.Name = "MonthCalendar";
            this.Size = new System.Drawing.Size(245, 229);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar profileMonthCalendar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTempDate;
    }
}
