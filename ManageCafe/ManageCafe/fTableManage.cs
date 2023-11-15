using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageCafe
{
    public partial class fTableManage : Form
    {
        public fTableManage()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            //f.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.fDoanhThu f = new Admin.fDoanhThu();
            f.ShowDialog();
        }

        private void thứcĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.fFood f = new Admin.fFood();
            f.ShowDialog();
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.fDanhMuc f = new Admin.fDanhMuc();
            f.ShowDialog();
        }

        private void bànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.fBanAn f = new Admin.fBanAn();
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin.fTaiKhoan f = new Admin.fTaiKhoan();
            f.ShowDialog();
        }
    }
}
