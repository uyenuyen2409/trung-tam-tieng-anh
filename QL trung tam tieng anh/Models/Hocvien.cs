using System;

namespace QL_trung_tam_tieng_anh.Models
{
    public class HocVien
    {
        public int MaHV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }
}