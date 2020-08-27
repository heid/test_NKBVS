namespace Server
{
    partial class MainForm
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
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblNet = new System.Windows.Forms.Label();
            this.gbStat = new System.Windows.Forms.GroupBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.gbStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.White;
            this.tbConsole.Location = new System.Drawing.Point(12, 12);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(374, 230);
            this.tbConsole.TabIndex = 0;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(84, 81);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(201, 13);
            this.lblImage.TabIndex = 3;
            this.lblImage.Text = "The image was generated in 0 ms";
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Location = new System.Drawing.Point(102, 57);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(148, 13);
            this.lblNet.TabIndex = 4;
            this.lblNet.Text = "Data transferred in 0 ms";
            // 
            // gbStat
            // 
            this.gbStat.Controls.Add(this.lblFps);
            this.gbStat.Controls.Add(this.lblImage);
            this.gbStat.Controls.Add(this.lblNet);
            this.gbStat.Location = new System.Drawing.Point(12, 248);
            this.gbStat.Name = "gbStat";
            this.gbStat.Size = new System.Drawing.Size(371, 113);
            this.gbStat.TabIndex = 5;
            this.gbStat.TabStop = false;
            this.gbStat.Text = "Statistics";
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(151, 32);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(37, 13);
            this.lblFps.TabIndex = 5;
            this.lblFps.Text = "Fps 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 376);
            this.Controls.Add(this.gbStat);
            this.Controls.Add(this.tbConsole);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbStat.ResumeLayout(false);
            this.gbStat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.GroupBox gbStat;
        private System.Windows.Forms.Label lblFps;
    }
}

