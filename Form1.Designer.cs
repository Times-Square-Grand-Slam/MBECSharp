namespace MBECSharp
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // btBDPack
            // 
            this.btBDPack.Location = new System.Drawing.Point(78, 86);
            this.btBDPack.Name = "btBDPack";
            this.btBDPack.Size = new System.Drawing.Size(128, 59);
            this.btBDPack.TabIndex = 0;
            this.btBDPack.Text = "Open Birthday Packages 1";
            this.btBDPack.UseVisualStyleBackColor = true;
            this.btBDPack.Click += new System.EventHandler(this.BtBDPack_Click);
            // 
            // btBDPack2
            // 
            this.btBDPack2.Location = new System.Drawing.Point(232, 86);
            this.btBDPack2.Name = "btBDPack2";
            this.btBDPack2.Size = new System.Drawing.Size(128, 59);
            this.btBDPack2.TabIndex = 1;
            this.btBDPack2.Text = "Open Birthday Packages 2";
            this.btBDPack2.UseVisualStyleBackColor = true;
            this.btBDPack2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btBDPack2);
            this.Controls.Add(this.btBDPack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBDPack;
        private System.Windows.Forms.Button btBDPack2;
    }
}

