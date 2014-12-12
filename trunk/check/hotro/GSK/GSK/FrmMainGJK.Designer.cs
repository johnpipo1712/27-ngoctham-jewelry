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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gJKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DMKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemKHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 47);
            this.panel1.TabIndex = 0;
            // 
            // gJKToolStripMenuItem
            // 
            this.gJKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMKToolStripMenuItem,
            this.ThemKHToolStripMenuItem});
            this.gJKToolStripMenuItem.Name = "gJKToolStripMenuItem";
            this.gJKToolStripMenuItem.Size = new System.Drawing.Size(38, 43);
            this.gJKToolStripMenuItem.Text = "GJK";
            // 
            // DMKToolStripMenuItem
            // 
            this.DMKToolStripMenuItem.Name = "DMKToolStripMenuItem";
            this.DMKToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.DMKToolStripMenuItem.Text = "Đổi mật khẩu";
            this.DMKToolStripMenuItem.Click += new System.EventHandler(this.DMKToolStripMenuItem_Click);
            // 
            // ThemKHToolStripMenuItem
            // 
            this.ThemKHToolStripMenuItem.Name = "ThemKHToolStripMenuItem";
            this.ThemKHToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ThemKHToolStripMenuItem.Text = "Thêm KH";
            this.ThemKHToolStripMenuItem.Click += new System.EventHandler(this.ThemKHToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gJKToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FrmMainGJK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 47);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMainGJK";
            this.Text = "FrmMainGJK";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gJKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DMKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemKHToolStripMenuItem;
    }
}