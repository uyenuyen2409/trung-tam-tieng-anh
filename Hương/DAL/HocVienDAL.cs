using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using QL_trung_tam_tieng_anh.Interfaces;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class HocVienDAL : IHocVienDAL
    {
        public List<HocVien> GetAll()
        {
            var list = new List<HocVien>();
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaHV, HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi FROM HocVien", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(Map(reader));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetAll HocVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public HocVien GetById(int id)
        {
            HocVien result = null;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaHV, HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi FROM HocVien WHERE MaHV = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) result = Map(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetById HocVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int Add(HocVien hv)
        {
            int newId = 0;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO HocVien (HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi)
                    VALUES (@HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @DiaChi);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
                AddParams(cmd, hv);
                newId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Add HocVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newId;
        }

        public bool Update(HocVien hv)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"UPDATE HocVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh,
                    SDT=@SDT, Email=@Email, DiaChi=@DiaChi WHERE MaHV=@MaHV", conn);
                AddParams(cmd, hv);
                cmd.Parameters.AddWithValue("@MaHV", hv.MaHV);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Update HocVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool Delete(int id)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM HocVien WHERE MaHV = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Delete HocVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool IsTrungSDT(string sdt, int excludeId = 0)
        {
            return GetAll().Any(x => x.SDT == sdt && x.MaHV != excludeId);
        }

        private void AddParams(SqlCommand cmd, HocVien hv)
        {
            cmd.Parameters.AddWithValue("@HoTen", hv.HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", (object)hv.GioiTinh ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NgaySinh", (object)hv.NgaySinh ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SDT", (object)hv.SDT ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object)hv.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DiaChi", (object)hv.DiaChi ?? DBNull.Value);
        }

        private HocVien Map(SqlDataReader reader)
        {
            return new HocVien
            {
                MaHV = reader.GetInt32(0),
                HoTen = reader.GetString(1),
                GioiTinh = reader.IsDBNull(2) ? null : reader.GetString(2),
                NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                SDT = reader.IsDBNull(4) ? null : reader.GetString(4),
                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                DiaChi = reader.IsDBNull(6) ? null : reader.GetString(6)
            };
        }
    }
}