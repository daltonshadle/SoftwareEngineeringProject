﻿namespace Tutor_Master
{
    partial class Registration2
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
            this.btnNext = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTutorMaster = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.Location = new System.Drawing.Point(299, 322);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Continue";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(246, 147);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(180, 169);
            this.checkedListBox1.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(227, 106);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(219, 13);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Select the courses you want to be a tutor for.";
            // 
            // lblTutorMaster
            // 
            this.lblTutorMaster.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTutorMaster.AutoSize = true;
            this.lblTutorMaster.Font = new System.Drawing.Font("Harlow Solid Italic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorMaster.Location = new System.Drawing.Point(188, 45);
            this.lblTutorMaster.Name = "lblTutorMaster";
            this.lblTutorMaster.Size = new System.Drawing.Size(298, 61);
            this.lblTutorMaster.TabIndex = 4;
            this.lblTutorMaster.Text = "Tutor Classes";
            // 
            // Registration2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 457);
            this.Controls.Add(this.lblTutorMaster);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnNext);
            this.Name = "Registration2";
            this.Text = "Registration - Tutor Courses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTutorMaster;
    }
}