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
            this.monthCalendar1 = new Tutor_Master.MonthCalendar();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.monthCalendar1.Location = new System.Drawing.Point(243, 85);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(245, 229);
            this.monthCalendar1.TabIndex = 0;
            // 
            // MonthCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 326);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "MonthCalendarForm";
            this.Text = "MonthCalendarForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MonthCalendar monthCalendar1;
    }
}