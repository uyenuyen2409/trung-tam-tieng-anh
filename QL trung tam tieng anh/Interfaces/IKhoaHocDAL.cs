using System.Collections.Generic;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.Interfaces
{
    public interface IKhoaHocDAL
    {
        List<KhoaHoc> GetAll();
        KhoaHoc GetById(int id);
        int Add(KhoaHoc kh);
        bool Update(KhoaHoc kh);
        bool Delete(int id);
    }
}