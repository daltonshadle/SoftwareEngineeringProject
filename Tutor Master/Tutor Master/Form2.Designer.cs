namespace Tutor_Master
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkTutor = new System.Windows.Forms.CheckBox();
            this.chkTutee = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What type of account do you need?";
            // 
            // chkTutor
            // 
            this.chkTutor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutor.AutoSize = true;
            this.chkTutor.Location = new System.Drawing.Point(58, 114);
            this.chkTutor.Name = "chkTutor";
            this.chkTutor.Size = new System.Drawing.Size(51, 17);
            this.chkTutor.TabIndex = 1;
            this.chkTutor.Text = "Tutor";
            this.chkTutor.UseVisualStyleBackColor = true;
            this.chkTutor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkTutee
            // 
            this.chkTutee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTutee.AutoSize = true;
            this.chkTutee.Location = new System.Drawing.Point(179, 114);
            this.chkTutee.Name = "chkTutee";
            this.chkTutee.Size = new System.Drawing.Size(54, 17);
            this.chkTutee.TabIndex = 2;
            this.chkTutee.Text = "Tutee";
            this.chkTutee.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnContinue.Location = new System.Drawing.Point(179, 195);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.chkTutee);
            this.Controls.Add(this.chkTutor);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkTutor;
        private System.Windows.Forms.CheckBox chkTutee;
        private System.Windows.Forms.Button btnContinue;
    }
}