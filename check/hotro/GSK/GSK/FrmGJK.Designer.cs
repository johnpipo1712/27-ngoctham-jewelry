namespace GSK
{
    partial class FrmGJK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTiepTuc = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.Btnback = new System.Windows.Forms.Button();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnFile = new System.Windows.Forms.Button();
            this.TxtfileExcel = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowserGJK = new System.Windows.Forms.WebBrowser();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnGo = new System.Windows.Forms.Button();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(482, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 413);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 45);
            this.panel3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Liên hệ : nhtai1712@gmail.com";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Người thực hiện : Nguyễn Hữu Tài";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTiepTuc);
            this.groupBox1.Controls.Add(this.BtnNext);
            this.groupBox1.Controls.Add(this.Btnback);
            this.groupBox1.Controls.Add(this.TxtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtPass);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 181);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng nhập";
            // 
            // BtnTiepTuc
            // 
            this.BtnTiepTuc.Location = new System.Drawing.Point(187, 146);
            this.BtnTiepTuc.Name = "BtnTiepTuc";
            this.BtnTiepTuc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnTiepTuc.Size = new System.Drawing.Size(75, 23);
            this.BtnTiepTuc.TabIndex = 9;
            this.BtnTiepTuc.Text = "Tiếp tục";
            this.BtnTiepTuc.UseVisualStyleBackColor = true;
            this.BtnTiepTuc.Click += new System.EventHandler(this.BtnTiepTuc_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(97, 146);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 8;
            this.BtnNext.Text = "Dừng";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // Btnback
            // 
            this.Btnback.Location = new System.Drawing.Point(187, 106);
            this.Btnback.Name = "Btnback";
            this.Btnback.Size = new System.Drawing.Size(75, 23);
            this.Btnback.TabIndex = 5;
            this.Btnback.Text = "Trở về";
            this.Btnback.UseVisualStyleBackColor = true;
            this.Btnback.Click += new System.EventHandler(this.Btnback_Click);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(97, 17);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(165, 20);
            this.TxtUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(97, 106);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Đồng ý";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên đăng nhập";
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(97, 68);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '*';
            this.TxtPass.Size = new System.Drawing.Size(165, 20);
            this.TxtPass.TabIndex = 2;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnFile);
            this.groupBox2.Controls.Add(this.TxtfileExcel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 56);
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
            this.label3.Size = new System.Drawing.Size(270, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Công cụ hổ trợ thêm khách hàng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowserGJK);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 413);
            this.panel2.TabIndex = 1;
            // 
            // webBrowserGJK
            // 
            this.webBrowserGJK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserGJK.Location = new System.Drawing.Point(0, 20);
            this.webBrowserGJK.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGJK.Name = "webBrowserGJK";
            this.webBrowserGJK.Size = new System.Drawing.Size(482, 393);
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
            this.panel5.Size = new System.Drawing.Size(482, 20);
            this.panel5.TabIndex = 1;
            // 
            // BtnGo
            // 
            this.BtnGo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnGo.Location = new System.Drawing.Point(449, 0);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(33, 20);
            this.BtnGo.TabIndex = 2;
            this.BtnGo.Text = "Go";
            this.BtnGo.UseVisualStyleBackColor = true;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // TxtUrl
            // 
            this.TxtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUrl.Location = new System.Drawing.Point(0, 0);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(449, 20);
            this.TxtUrl.TabIndex = 0;
            this.TxtUrl.Text = "https://vn.gsk.dmsone.biz/dms_vn/Logon.aspx";
            // 
            // FrmGJK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 413);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGJK";
            this.Text = "Nhập liệu GSK";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.TextBox TxtfileExcel;
        private System.Windows.Forms.Button BtnFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button Btnback;
        private System.Windows.Forms.WebBrowser webBrowserGJK;
        private System.Windows.Forms.Button BtnTiepTuc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.TextBox TxtUrl;
    }
}

