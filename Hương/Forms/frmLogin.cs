using System;
using System.Windows.Forms;
using QL_trung_tam_tieng_anh.DAL;

namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmLogin : Form
    {
        private readonly TaiKhoanDAL dal = new TaiKhoanDAL();

        public static string CurrentUser = "";
        public static string CurrentRole = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");
            Theme.StyleTextBox(txtTenDangNhap);
            Theme.StyleTextBox(txtMatKhau);
            Theme.StylePrimaryButton(btnDangNhap);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string tdn = txtTenDangNhap.Text.Trim();
            string mk = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tdn) || string.IsNullOrWhiteSpace(mk))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }

            var tk = dal.Login(tdn, mk);
            if (tk == null)
            {
                lblError.Text = "Sai tên đăng nhập hoặc mật khẩu";
                return;
            }

            CurrentUser = tk.TenDangNhap;
            CurrentRole = tk.VaiTro;

            this.Hide();
            var main = new QL_trung_tam_tieng_anh.frmMain();
            main.FormClosed += (s, args) => this.Close();
            main.Show();
        }

        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new frmRegister();
            f.ShowDialog();
        }
    }
}
