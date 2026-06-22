using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.Interfaces
{
    public interface ITaiKhoanDAL
    {
        TaiKhoan Login(string tenDangNhap, string matKhau);
        bool Register(string tenDangNhap, string matKhau);
    }
}