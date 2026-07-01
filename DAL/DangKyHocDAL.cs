using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using QL_trung_tam_tieng_anh.Interfaces;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class DangKyHocDAL : IDangKyHocDAL
    {
        public List<DangKyHoc> GetAll()
        {
            var list = new List<DangKyHoc>();
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT d.MaDK, d.MaHV, d.MaKH, d.NgayDangKy, d.TrangThai, h.HoTen, k.TenKH
                    FROM DangKyHoc d
                    JOIN HocVien h ON d.MaHV = h.MaHV
                    JOIN KhoaHoc k ON d.MaKH = k.MaKH", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(Map(reader));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetAll DangKyHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public DangKyHoc GetById(int id)
        {
            DangKyHoc result = null;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT d.MaDK, d.MaHV, d.MaKH, d.NgayDangKy, d.TrangThai, h.HoTen, k.TenKH
                    FROM DangKyHoc d
                    JOIN HocVien h ON d.MaHV = h.MaHV
                    JOIN KhoaHoc k ON d.MaKH = k.MaKH
                    WHERE d.MaDK = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) result = Map(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetById DangKyHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int Add(DangKyHoc dk)
        {
            int newId = 0;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO DangKyHoc (MaHV, MaKH, NgayDangKy, TrangThai)
                    VALUES (@MaHV, @MaKH, @NgayDangKy, @TrangThai);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
                AddParams(cmd, dk);
                newId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Add DangKyHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newId;
        }

        public bool Update(DangKyHoc dk)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"UPDATE DangKyHoc SET MaHV=@MaHV, MaKH=@MaKH, NgayDangKy=@NgayDangKy,
                    TrangThai=@TrangThai WHERE MaDK=@MaDK", conn);
                AddParams(cmd, dk);
                cmd.Parameters.AddWithValue("@MaDK", dk.MaDK);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Update DangKyHoc: " + ex.Message);
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
                var cmd = new SqlCommand("DELETE FROM DangKyHoc WHERE MaDK = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Delete DangKyHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool IsTrungDangKy(int maHV, int maKH, int excludeId = 0)
        {
            return GetAll().Any(x => x.MaHV == maHV && x.MaKH == maKH && x.MaDK != excludeId);
        }

        private void AddParams(SqlCommand cmd, DangKyHoc dk)
        {
            cmd.Parameters.AddWithValue("@MaHV", dk.MaHV);
            cmd.Parameters.AddWithValue("@MaKH", dk.MaKH);
            cmd.Parameters.AddWithValue("@NgayDangKy", dk.NgayDangKy);
            cmd.Parameters.AddWithValue("@TrangThai", dk.TrangThai);
        }

        private DangKyHoc Map(SqlDataReader reader)
        {
            return new DangKyHoc
            {
                MaDK = reader.GetInt32(0),
                MaHV = reader.GetInt32(1),
                MaKH = reader.GetInt32(2),
                NgayDangKy = reader.GetDateTime(3),
                TrangThai = reader.GetString(4),
                TenHV = reader.GetString(5),
                TenKH = reader.GetString(6)
            };
        }
    }
}