namespace Client
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblNetStat = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblNetReceive = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.gbStat = new System.Windows.Forms.GroupBox();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.gbStat.SuspendLayout();
            this.gbConnection.SuspendLayout();
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
            this.tbConsole.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(76, 72);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(87, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblNetStat
            // 
            this.lblNetStat.AutoSize = true;
            this.lblNetStat.Location = new System.Drawing.Point(6, 60);
            this.lblNetStat.Name = "lblNetStat";
            this.lblNetStat.Size = new System.Drawing.Size(159, 13);
            this.lblNetStat.TabIndex = 5;
            this.lblNetStat.Text = "Receive packets: 0 Lost: 0";
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(60, 20);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(103, 21);
            this.tbIp.TabIndex = 6;
            this.tbIp.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(60, 46);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(103, 21);
            this.tbPort.TabIndex = 7;
            this.tbPort.Text = "8888";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(29, 23);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(24, 13);
            this.lblIp.TabIndex = 8;
            this.lblIp.Text = "IP:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(19, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 13);
            this.lblPort.TabIndex = 9;
            this.lblPort.Text = "Port:";
            // 
            // lblNetReceive
            // 
            this.lblNetReceive.AutoSize = true;
            this.lblNetReceive.Location = new System.Drawing.Point(6, 34);
            this.lblNetReceive.Name = "lblNetReceive";
            this.lblNetReceive.Size = new System.Drawing.Size(133, 13);
            this.lblNetReceive.TabIndex = 10;
            this.lblNetReceive.Text = "Data received in 0 ms";
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(12, 245);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(66, 13);
            this.lblPreview.TabIndex = 11;
            this.lblPreview.Text = "Preview ()";
            // 
            // gbStat
            // 
            this.gbStat.Controls.Add(this.lblNetReceive);
            this.gbStat.Controls.Add(this.lblNetStat);
            this.gbStat.Location = new System.Drawing.Point(186, 351);
            this.gbStat.Name = "gbStat";
            this.gbStat.Size = new System.Drawing.Size(200, 100);
            this.gbStat.TabIndex = 12;
            this.gbStat.TabStop = false;
            this.gbStat.Text = "Statistics";
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.tbIp);
            this.gbConnection.Controls.Add(this.btnConnect);
            this.gbConnection.Controls.Add(this.tbPort);
            this.gbConnection.Controls.Add(this.lblPort);
            this.gbConnection.Controls.Add(this.lblIp);
            this.gbConnection.Location = new System.Drawing.Point(186, 245);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(200, 100);
            this.gbConnection.TabIndex = 13;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 465);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.gbStat);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.tbConsole);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbStat.ResumeLayout(false);
            this.gbStat.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblNetStat;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblNetReceive;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.GroupBox gbStat;
        private System.Windows.Forms.GroupBox gbConnection;
    }
}

