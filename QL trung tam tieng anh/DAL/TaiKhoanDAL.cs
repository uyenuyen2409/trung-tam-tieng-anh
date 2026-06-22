using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using QL_trung_tam_tieng_anh.Interfaces;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class TaiKhoanDAL : ITaiKhoanDAL
    {
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public TaiKhoan Login(string tenDangNhap, string matKhau)
        {
            TaiKhoan result = null;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaTK, TenDangNhap, MatKhau, VaiTro FROM TaiKhoan WHERE TenDangNhap = @tdn AND MatKhau = @mk", conn);
                cmd.Parameters.AddWithValue("@tdn", tenDangNhap);
                cmd.Parameters.AddWithValue("@mk", HashPassword(matKhau));
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new TaiKhoan
                    {
                        MaTK = reader.GetInt32(0),
                        TenDangNhap = reader.GetString(1),
                        MatKhau = reader.GetString(2),
                        VaiTro = reader.GetString(3)
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Login: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool Register(string tenDangNhap, string matKhau)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var check = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @tdn", conn);
                check.Parameters.AddWithValue("@tdn", tenDangNhap);
                if ((int)check.ExecuteScalar() > 0) return false;

                var cmd = new SqlCommand("INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro) VALUES (@tdn, @mk, N'Nhân Viên')", conn);
                cmd.Parameters.AddWithValue("@tdn", tenDangNhap);
                cmd.Parameters.AddWithValue("@mk", HashPassword(matKhau));
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Register: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
    }
}