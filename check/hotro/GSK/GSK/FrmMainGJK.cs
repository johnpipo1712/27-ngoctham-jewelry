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
            FrmDisplayMain frm = new FrmDisplayMain();
            frm.MdiParent = this;
           
            frm.Show();
        }
       
        public void CleanerFrm()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
        private void DMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanerFrm();
         
            FrmChangePass frm = new FrmChangePass();
            frm.MdiParent = this;
            frm.Show();
         
        }

        private void ThemKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanerFrm();
            FrmGJK frm = new FrmGJK();
            frm.MdiParent = this;
            frm.Show();

          
          
        }

       
        private void chiaKHToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CleanerFrm();
            FrmDivCustomer frm = new FrmDivCustomer();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
