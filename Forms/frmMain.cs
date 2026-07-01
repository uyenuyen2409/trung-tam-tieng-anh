using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnHocVien_Click(object sender, EventArgs e)
        {
            var f = new Forms.frmHocVien();
            f.MdiParent = this;
            
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            
        }


        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            var f = new Forms.frmGiangVien();
            f.MdiParent = this;
            
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            

        }


        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            var f = new Forms.frmKhoaHoc();
            f.MdiParent = this;
            
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var f = new Forms.frmDangKy();
            f.MdiParent = this;
        
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new Forms.frmTongQuan();
            f.MdiParent = this;
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            var f = new Forms.frmTongQuan();
            f.MdiParent = this;
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
