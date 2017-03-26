namespace Tutor_Master
{
    partial class AppointmentBlock
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
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.lblTimeAndPlace = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAppointmentType.AutoSize = true;
            this.lblAppointmentType.Location = new System.Drawing.Point(17, 5);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(66, 13);
            this.lblAppointmentType.TabIndex = 0;
            this.lblAppointmentType.Text = "Appointment";
            // 
            // lblTimeAndPlace
            // 
            this.lblTimeAndPlace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimeAndPlace.AutoSize = true;
            this.lblTimeAndPlace.Location = new System.Drawing.Point(10, 20);
            this.lblTimeAndPlace.Name = "lblTimeAndPlace";
            this.lblTimeAndPlace.Size = new System.Drawing.Size(81, 13);
            this.lblTimeAndPlace.TabIndex = 1;
            this.lblTimeAndPlace.Text = "Time and Place";
            // 
            // lblCourse
            // 
            this.lblCourse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(30, 35);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(40, 13);
            this.lblCourse.TabIndex = 2;
            this.lblCourse.Text = "Course";
            // 
            // lblFirst
            // 
            this.lblFirst.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(32, 50);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(32, 13);
            this.lblFirst.TabIndex = 3;
            this.lblFirst.Text = "Tutor";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(30, 63);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(35, 13);
            this.lblSecond.TabIndex = 4;
            this.lblSecond.Text = "Tutee";
            // 
            // AppointmentBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblTimeAndPlace);
            this.Controls.Add(this.lblAppointmentType);
            this.Name = "AppointmentBlock";
            this.Size = new System.Drawing.Size(100, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.Label lblTimeAndPlace;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblSecond;
    }
}
