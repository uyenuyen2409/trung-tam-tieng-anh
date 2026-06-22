using System.Collections.Generic;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.Interfaces
{
    public interface IDangKyHocDAL
    {
        List<DangKyHoc> GetAll();
        DangKyHoc GetById(int id);
        int Add(DangKyHoc dk);
        bool Update(DangKyHoc dk);
        bool Delete(int id);
    }
}