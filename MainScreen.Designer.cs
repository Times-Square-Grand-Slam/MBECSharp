namespace MBECSharp
{
    partial class MainScreen
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
            this.btBDPack = new System.Windows.Forms.Button();
            this.btCorpPack = new System.Windows.Forms.Button();
            this.btCalendarView = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBDPack
            // 
            this.btBDPack.Location = new System.Drawing.Point(78, 88);
            this.btBDPack.Name = "btBDPack";
            this.btBDPack.Size = new System.Drawing.Size(128, 59);
            this.btBDPack.TabIndex = 1;
            this.btBDPack.Text = "Open Birthday Packages";
            this.btBDPack.UseVisualStyleBackColor = true;
            this.btBDPack.Click += new System.EventHandler(this.btBDPack_Click);
            // 
            // btCorpPack
            // 
            this.btCorpPack.Location = new System.Drawing.Point(78, 153);
            this.btCorpPack.Name = "btCorpPack";
            this.btCorpPack.Size = new System.Drawing.Size(128, 59);
            this.btCorpPack.TabIndex = 2;
            this.btCorpPack.Text = "Open Corporate Packages";
            this.btCorpPack.UseVisualStyleBackColor = true;
            this.btCorpPack.Click += new System.EventHandler(this.btCorpPack_Click);
            // 
            // btCalendarView
            // 
            this.btCalendarView.Location = new System.Drawing.Point(78, 219);
            this.btCalendarView.Name = "btCalendarView";
            this.btCalendarView.Size = new System.Drawing.Size(128, 59);
            this.btCalendarView.TabIndex = 3;
            this.btCalendarView.Text = "Open Calendar";
            this.btCalendarView.UseVisualStyleBackColor = true;
            this.btCalendarView.Click += new System.EventHandler(this.btCalendarView_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btExit.ForeColor = System.Drawing.Color.Black;
            this.btExit.Location = new System.Drawing.Point(78, 283);
            this.btExit.Margin = new System.Windows.Forms.Padding(2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(128, 49);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "EXIT";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.editToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(292, 450);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCalendarView);
            this.Controls.Add(this.btCorpPack);
            this.Controls.Add(this.btBDPack);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "Marketing Booking and Events";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btBDPack;
        private System.Windows.Forms.Button btCorpPack;
        private System.Windows.Forms.Button btCalendarView;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

