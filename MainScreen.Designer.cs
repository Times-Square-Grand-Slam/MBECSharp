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
            this.btBDPack2 = new System.Windows.Forms.Button();
            this.btCorpPack = new System.Windows.Forms.Button();
            this.btCalendarView = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btBDPack
            // 
            this.btBDPack.Location = new System.Drawing.Point(117, 132);
            this.btBDPack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBDPack.Name = "btBDPack";
            this.btBDPack.Size = new System.Drawing.Size(192, 91);
            this.btBDPack.TabIndex = 0;
            this.btBDPack.Text = "Open Birthday Packages 1";
            this.btBDPack.UseVisualStyleBackColor = true;
            this.btBDPack.Click += new System.EventHandler(this.BtBDPack_Click);
            // 
            // btBDPack2
            // 
            this.btBDPack2.Location = new System.Drawing.Point(348, 132);
            this.btBDPack2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBDPack2.Name = "btBDPack2";
            this.btBDPack2.Size = new System.Drawing.Size(192, 91);
            this.btBDPack2.TabIndex = 1;
            this.btBDPack2.Text = "Open Birthday Packages 2";
            this.btBDPack2.UseVisualStyleBackColor = true;
            this.btBDPack2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btCorpPack
            // 
            this.btCorpPack.Location = new System.Drawing.Point(117, 257);
            this.btCorpPack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCorpPack.Name = "btCorpPack";
            this.btCorpPack.Size = new System.Drawing.Size(192, 91);
            this.btCorpPack.TabIndex = 2;
            this.btCorpPack.Text = "Open Corporate Packages";
            this.btCorpPack.UseVisualStyleBackColor = true;
            this.btCorpPack.Click += new System.EventHandler(this.btCorpPack_Click);
            // 
            // btCalendarView
            // 
            this.btCalendarView.Location = new System.Drawing.Point(348, 257);
            this.btCalendarView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCalendarView.Name = "btCalendarView";
            this.btCalendarView.Size = new System.Drawing.Size(192, 91);
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
            this.btExit.Location = new System.Drawing.Point(12, 604);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(170, 76);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "EXIT";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCalendarView);
            this.Controls.Add(this.btCorpPack);
            this.Controls.Add(this.btBDPack2);
            this.Controls.Add(this.btBDPack);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainScreen";
            this.Text = "Marketing Booking and Events";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBDPack;
        private System.Windows.Forms.Button btBDPack2;
        private System.Windows.Forms.Button btCorpPack;
        private System.Windows.Forms.Button btCalendarView;
        private System.Windows.Forms.Button btExit;
    }
}

