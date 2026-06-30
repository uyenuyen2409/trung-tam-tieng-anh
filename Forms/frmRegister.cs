using System;
using System.Windows.Forms;
using QL_trung_tam_tieng_anh.DAL;
namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmRegister : Form
    {
        private readonly TaiKhoanDAL dal = new TaiKhoanDAL();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");
            Theme.StyleTextBox(txtTenDangNhap);
            Theme.StyleTextBox(txtMatKhau);
            Theme.StyleTextBox(txtXacNhan);
            Theme.StylePrimaryButton(btnDangKy);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string tdn = txtTenDangNhap.Text.Trim();
            string mk = txtMatKhau.Text;
            string xn = txtXacNhan.Text;

            if (string.IsNullOrWhiteSpace(tdn) || string.IsNullOrWhiteSpace(mk))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }
            if (mk != xn)
            {
                lblError.Text = "Mật khẩu xác nhận không khớp";
                return;
            }

            bool success = dal.Register(tdn, mk);
            if (!success)
            {
                lblError.Text = "Tên đăng nhập đã tồn tại";
                return;
            }

            MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        
    }
}
