using System.Collections.Generic;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.Interfaces
{
    public interface IGiangVienDAL
    {
        List<GiangVien> GetAll();
        GiangVien GetById(int id);
        int Add(GiangVien gv);
        bool Update(GiangVien gv);
        bool Delete(int id);
    }
}