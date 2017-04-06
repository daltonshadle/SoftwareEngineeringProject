namespace Tutor_Master
{
    partial class SearchRefinementForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.lblByCourse = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTutor = new System.Windows.Forms.Label();
            this.comboTutor = new System.Windows.Forms.ComboBox();
            this.dateTimeTime1 = new System.Windows.Forms.DateTimePicker();
            this.lblPlace = new System.Windows.Forms.Label();
            this.comboPlace = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimeDay1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(73, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(147, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Refine your search for a tutor.";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(106, 226);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // comboCourse
            // 
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(114, 37);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(121, 21);
            this.comboCourse.TabIndex = 2;
            this.comboCourse.SelectedIndexChanged += new System.EventHandler(this.comboCourse_SelectedIndexChanged);
            // 
            // lblByCourse
            // 
            this.lblByCourse.AutoSize = true;
            this.lblByCourse.Location = new System.Drawing.Point(51, 40);
            this.lblByCourse.Name = "lblByCourse";
            this.lblByCourse.Size = new System.Drawing.Size(57, 13);
            this.lblByCourse.TabIndex = 3;
            this.lblByCourse.Text = "By course:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(65, 115);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "By time:";
            this.lblTime.Visible = false;
            // 
            // lblTutor
            // 
            this.lblTutor.AutoSize = true;
            this.lblTutor.Location = new System.Drawing.Point(61, 155);
            this.lblTutor.Name = "lblTutor";
            this.lblTutor.Size = new System.Drawing.Size(46, 13);
            this.lblTutor.TabIndex = 7;
            this.lblTutor.Text = "By tutor:";
            this.lblTutor.Visible = false;
            // 
            // comboTutor
            // 
            this.comboTutor.FormattingEnabled = true;
            this.comboTutor.Location = new System.Drawing.Point(113, 152);
            this.comboTutor.Name = "comboTutor";
            this.comboTutor.Size = new System.Drawing.Size(121, 21);
            this.comboTutor.TabIndex = 6;
            this.comboTutor.Visible = false;
            this.comboTutor.SelectedIndexChanged += new System.EventHandler(this.comboTutor_SelectedIndexChanged);
            // 
            // dateTimeTime1
            // 
            this.dateTimeTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTime1.Location = new System.Drawing.Point(115, 115);
            this.dateTimeTime1.Name = "dateTimeTime1";
            this.dateTimeTime1.Size = new System.Drawing.Size(120, 20);
            this.dateTimeTime1.TabIndex = 8;
            this.dateTimeTime1.Visible = false;
            this.dateTimeTime1.ValueChanged += new System.EventHandler(this.dateTimeTime1_ValueChanged);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(57, 194);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(51, 13);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "By place:";
            this.lblPlace.Visible = false;
            // 
            // comboPlace
            // 
            this.comboPlace.FormattingEnabled = true;
            this.comboPlace.Location = new System.Drawing.Point(114, 191);
            this.comboPlace.Name = "comboPlace";
            this.comboPlace.Size = new System.Drawing.Size(121, 21);
            this.comboPlace.TabIndex = 9;
            this.comboPlace.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(65, 77);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(46, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "By date:";
            this.lblDate.Visible = false;
            // 
            // dateTimeDay1
            // 
            this.dateTimeDay1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDay1.Location = new System.Drawing.Point(114, 77);
            this.dateTimeDay1.Name = "dateTimeDay1";
            this.dateTimeDay1.Size = new System.Drawing.Size(121, 20);
            this.dateTimeDay1.TabIndex = 12;
            this.dateTimeDay1.Visible = false;
            this.dateTimeDay1.ValueChanged += new System.EventHandler(this.dateTimeDay1_ValueChanged);
            // 
            // SearchRefinementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dateTimeDay1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.comboPlace);
            this.Controls.Add(this.dateTimeTime1);
            this.Controls.Add(this.lblTutor);
            this.Controls.Add(this.comboTutor);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblByCourse);
            this.Controls.Add(this.comboCourse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblHeader);
            this.Name = "SearchRefinementForm";
            this.Text = "SearchRefinementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.Label lblByCourse;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTutor;
        private System.Windows.Forms.ComboBox comboTutor;
        private System.Windows.Forms.DateTimePicker dateTimeTime1;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.ComboBox comboPlace;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimeDay1;
    }
}