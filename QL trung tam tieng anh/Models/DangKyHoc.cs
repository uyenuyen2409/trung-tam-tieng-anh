using System;

namespace QL_trung_tam_tieng_anh.Models
{
    public class DangKyHoc
    {
        public int MaDK { get; set; }
        public int MaHV { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string TrangThai { get; set; }
        public string TenHV { get; set; }
        public string TenKH { get; set; }
    }
}