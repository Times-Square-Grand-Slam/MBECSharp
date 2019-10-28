namespace MBECSharp
{
    partial class About
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
            this.lbName = new System.Windows.Forms.Label();
            this.lklbGithub = new System.Windows.Forms.LinkLabel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lklbReleaseNotes = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(43, 46);
            this.lbName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(153, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Marketing Booking and Events";
            // 
            // lklbGithub
            // 
            this.lklbGithub.AutoSize = true;
            this.lklbGithub.Location = new System.Drawing.Point(82, 149);
            this.lklbGithub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lklbGithub.Name = "lklbGithub";
            this.lklbGithub.Size = new System.Drawing.Size(72, 13);
            this.lklbGithub.TabIndex = 1;
            this.lklbGithub.TabStop = true;
            this.lklbGithub.Text = "TSGS GitHub";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(84, 81);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(69, 13);
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "Version 0.0.3";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lklbReleaseNotes
            // 
            this.lklbReleaseNotes.AutoSize = true;
            this.lklbReleaseNotes.Location = new System.Drawing.Point(80, 107);
            this.lklbReleaseNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lklbReleaseNotes.Name = "lklbReleaseNotes";
            this.lklbReleaseNotes.Size = new System.Drawing.Size(77, 13);
            this.lklbReleaseNotes.TabIndex = 3;
            this.lklbReleaseNotes.TabStop = true;
            this.lklbReleaseNotes.Text = "Release Notes";
            this.lklbReleaseNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklbReleaseNotes_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 197);
            this.Controls.Add(this.lklbReleaseNotes);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lklbGithub);
            this.Controls.Add(this.lbName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.LinkLabel lklbGithub;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.LinkLabel lklbReleaseNotes;
    }
}