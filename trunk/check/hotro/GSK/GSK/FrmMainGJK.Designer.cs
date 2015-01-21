namespace GSK
{
    partial class FrmMainGJK
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gJKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DMKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemKHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiaKHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gJKToolStripMenuItem,
            this.cPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(174, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gJKToolStripMenuItem
            // 
            this.gJKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMKToolStripMenuItem,
            this.ThemKHToolStripMenuItem});
            this.gJKToolStripMenuItem.Name = "gJKToolStripMenuItem";
            this.gJKToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.gJKToolStripMenuItem.Text = "GSK";
            // 
            // DMKToolStripMenuItem
            // 
            this.DMKToolStripMenuItem.Name = "DMKToolStripMenuItem";
            this.DMKToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DMKToolStripMenuItem.Text = "Đổi mật khẩu";
            this.DMKToolStripMenuItem.Click += new System.EventHandler(this.DMKToolStripMenuItem_Click);
            // 
            // ThemKHToolStripMenuItem
            // 
            this.ThemKHToolStripMenuItem.Name = "ThemKHToolStripMenuItem";
            this.ThemKHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ThemKHToolStripMenuItem.Text = "Thêm KH";
            this.ThemKHToolStripMenuItem.Click += new System.EventHandler(this.ThemKHToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 23);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 518);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 23);
            this.panel3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Liên hệ : nhtai1712@gmail.com";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Người thực hiện : Nguyễn Hữu Tài";
            // 
            // cPToolStripMenuItem
            // 
            this.cPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiaKHToolStripMenuItem});
            this.cPToolStripMenuItem.Name = "cPToolStripMenuItem";
            this.cPToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.cPToolStripMenuItem.Text = "CP";
            // 
            // chiaKHToolStripMenuItem
            // 
            this.chiaKHToolStripMenuItem.Name = "chiaKHToolStripMenuItem";
            this.chiaKHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.chiaKHToolStripMenuItem.Text = "Chia KH";
            this.chiaKHToolStripMenuItem.Click += new System.EventHandler(this.chiaKHToolStripMenuItem_Click_1);
            // 
            // FrmMainGJK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 541);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMainGJK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainGJK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gJKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DMKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemKHToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem cPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiaKHToolStripMenuItem;

    }
}