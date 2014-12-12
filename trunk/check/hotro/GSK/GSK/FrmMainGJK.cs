using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSK
{
    public partial class FrmMainGJK : Form
    {
        public FrmMainGJK()
        {
            InitializeComponent();
        }

        private void DMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePass frm = new FrmChangePass();
            frm.Show();
        }

        private void ThemKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGJK frm = new FrmGJK();
            frm.Show();
        }
    }
}
