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
            this.SuspendLayout();
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.Location = new System.Drawing.Point(7, 23);
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
            this.lvMessages.Location = new System.Drawing.Point(12, 56);
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
<<<<<<< HEAD
            this.Date.Width = 242;
=======
            this.Date.Width = 205;
>>>>>>> e45103dee646a663c30f142d7e26cde73a00d4af
            // 
            // Done
            // 
            this.Done.Text = "Date";
<<<<<<< HEAD
            this.Done.Width = 89;
=======
            this.Done.Width = 161;
>>>>>>> e45103dee646a663c30f142d7e26cde73a00d4af
            // 
            // To
            // 
            this.To.Text = "Done";
            // 
            // btnInbox
            // 
            this.btnInbox.Location = new System.Drawing.Point(507, 23);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(75, 23);
            this.btnInbox.TabIndex = 2;
            this.btnInbox.Text = "Inbox";
            this.btnInbox.UseVisualStyleBackColor = true;
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnSent
            // 
            this.btnSent.Location = new System.Drawing.Point(390, 23);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(75, 23);
            this.btnSent.TabIndex = 3;
            this.btnSent.Text = "Sent";
            this.btnSent.UseVisualStyleBackColor = true;
            this.btnSent.Click += new System.EventHandler(this.btnSent_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(507, 402);
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
            this.label1.Location = new System.Drawing.Point(753, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Message Details";
            // 
            // lblMessageDetails
            // 
            this.lblMessageDetails.AutoSize = true;
            this.lblMessageDetails.BackColor = System.Drawing.Color.White;
            this.lblMessageDetails.Location = new System.Drawing.Point(653, 56);
            this.lblMessageDetails.Name = "lblMessageDetails";
            this.lblMessageDetails.Size = new System.Drawing.Size(0, 13);
            this.lblMessageDetails.TabIndex = 7;
            // 
            // rtbMessageDetails
            // 
            this.rtbMessageDetails.BackColor = System.Drawing.Color.White;
            this.rtbMessageDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessageDetails.Location = new System.Drawing.Point(659, 56);
            this.rtbMessageDetails.Name = "rtbMessageDetails";
            this.rtbMessageDetails.ReadOnly = true;
            this.rtbMessageDetails.Size = new System.Drawing.Size(350, 125);
            this.rtbMessageDetails.TabIndex = 8;
            this.rtbMessageDetails.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Approve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(859, 187);
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
            this.btnLogout.Location = new System.Drawing.Point(1103, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 591);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbMessageDetails);
            this.Controls.Add(this.lblMessageDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSent);
            this.Controls.Add(this.btnInbox);
            this.Controls.Add(this.lvMessages);
            this.Controls.Add(this.lblMessages);
            this.Name = "FacultyForm";
            this.Text = "Faculty Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}