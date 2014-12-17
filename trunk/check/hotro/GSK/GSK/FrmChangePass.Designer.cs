namespace GSK
{
    partial class FrmChangePass
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowserGJK = new System.Windows.Forms.WebBrowser();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.BtnGo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnFile = new System.Windows.Forms.Button();
            this.TxtfileExcel = new System.Windows.Forms.TextBox();
            this.Btnback = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowserGJK);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 911);
            this.panel2.TabIndex = 3;
            // 
            // webBrowserGJK
            // 
            this.webBrowserGJK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserGJK.Location = new System.Drawing.Point(0, 20);
            this.webBrowserGJK.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGJK.Name = "webBrowserGJK";
            this.webBrowserGJK.Size = new System.Drawing.Size(980, 891);
            this.webBrowserGJK.TabIndex = 0;
            this.webBrowserGJK.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TxtUrl);
            this.panel5.Controls.Add(this.BtnGo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(980, 20);
            this.panel5.TabIndex = 1;
            // 
            // TxtUrl
            // 
            this.TxtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUrl.Location = new System.Drawing.Point(0, 0);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(947, 20);
            this.TxtUrl.TabIndex = 0;
            this.TxtUrl.Text = "https://gsk-uat.np.accenture.com/dms_vn/logon.aspx";
            // 
            // BtnGo
            // 
            this.BtnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnGo.Location = new System.Drawing.Point(947, 0);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(33, 20);
            this.BtnGo.TabIndex = 2;
            this.BtnGo.Text = "Go";
            this.BtnGo.UseVisualStyleBackColor = true;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(980, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 911);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnFile);
            this.groupBox2.Controls.Add(this.TxtfileExcel);
            this.groupBox2.Controls.Add(this.Btnback);
            this.groupBox2.Controls.Add(this.BtnLogin);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 93);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn file";
            // 
            // BtnFile
            // 
            this.BtnFile.Location = new System.Drawing.Point(187, 19);
            this.BtnFile.Name = "BtnFile";
            this.BtnFile.Size = new System.Drawing.Size(75, 23);
            this.BtnFile.TabIndex = 6;
            this.BtnFile.Text = "Chọn file";
            this.BtnFile.UseVisualStyleBackColor = true;
            this.BtnFile.Click += new System.EventHandler(this.BtnFile_Click);
            // 
            // TxtfileExcel
            // 
            this.TxtfileExcel.Location = new System.Drawing.Point(13, 21);
            this.TxtfileExcel.Name = "TxtfileExcel";
            this.TxtfileExcel.ReadOnly = true;
            this.TxtfileExcel.Size = new System.Drawing.Size(168, 20);
            this.TxtfileExcel.TabIndex = 7;
            // 
            // Btnback
            // 
            this.Btnback.Location = new System.Drawing.Point(187, 58);
            this.Btnback.Name = "Btnback";
            this.Btnback.Size = new System.Drawing.Size(75, 23);
            this.Btnback.TabIndex = 5;
            this.Btnback.Text = "Trở về";
            this.Btnback.UseVisualStyleBackColor = true;
            this.Btnback.Click += new System.EventHandler(this.Btnback_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(100, 58);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Đồng ý";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(296, 39);
            this.panel4.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Công cụ hổ trợ cập nhật mật khẩu";
            // 
            // FrmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 911);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser webBrowserGJK;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btnback;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnFile;
        private System.Windows.Forms.TextBox TxtfileExcel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
    }
}