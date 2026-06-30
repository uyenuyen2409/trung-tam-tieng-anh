using System.Collections.Generic;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.Interfaces
{
    public interface IHocVienDAL
    {
        List<HocVien> GetAll();
        HocVien GetById(int id);
        int Add(HocVien hv);
        bool Update(HocVien hv);
        bool Delete(int id);
    }
}