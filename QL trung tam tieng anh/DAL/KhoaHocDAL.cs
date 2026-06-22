using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using QL_trung_tam_tieng_anh.Interfaces;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class KhoaHocDAL : IKhoaHocDAL
    {
        public List<KhoaHoc> GetAll()
        {
            var list = new List<KhoaHoc>();
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT k.MaKH, k.TenKH, k.MoTa, k.HocPhi, k.ThoiLuong, k.MaGV, g.HoTen
                    FROM KhoaHoc k LEFT JOIN GiangVien g ON k.MaGV = g.MaGV", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(Map(reader));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetAll KhoaHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public KhoaHoc GetById(int id)
        {
            KhoaHoc result = null;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT k.MaKH, k.TenKH, k.MoTa, k.HocPhi, k.ThoiLuong, k.MaGV, g.HoTen
                    FROM KhoaHoc k LEFT JOIN GiangVien g ON k.MaGV = g.MaGV WHERE k.MaKH = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) result = Map(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetById KhoaHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int Add(KhoaHoc kh)
        {
            int newId = 0;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO KhoaHoc (TenKH, MoTa, HocPhi, ThoiLuong, MaGV)
                    VALUES (@TenKH, @MoTa, @HocPhi, @ThoiLuong, @MaGV);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
                AddParams(cmd, kh);
                newId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Add KhoaHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newId;
        }

        public bool Update(KhoaHoc kh)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"UPDATE KhoaHoc SET TenKH=@TenKH, MoTa=@MoTa, HocPhi=@HocPhi,
                    ThoiLuong=@ThoiLuong, MaGV=@MaGV WHERE MaKH=@MaKH", conn);
                AddParams(cmd, kh);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Update KhoaHoc: " + ex.Message);
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
                var cmd = new SqlCommand("DELETE FROM KhoaHoc WHERE MaKH = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Delete KhoaHoc: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool IsTrungTen(string tenKH, int excludeId = 0)
        {
            return GetAll().Any(x => x.TenKH.Trim().ToLower() == tenKH.Trim().ToLower() && x.MaKH != excludeId);
        }

        private void AddParams(SqlCommand cmd, KhoaHoc kh)
        {
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@MoTa", (object)kh.MoTa ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@HocPhi", kh.HocPhi);
            cmd.Parameters.AddWithValue("@ThoiLuong", kh.ThoiLuong);
            cmd.Parameters.AddWithValue("@MaGV", (object)kh.MaGV ?? DBNull.Value);
        }

        private KhoaHoc Map(SqlDataReader reader)
        {
            return new KhoaHoc
            {
                MaKH = reader.GetInt32(0),
                TenKH = reader.GetString(1),
                MoTa = reader.IsDBNull(2) ? null : reader.GetString(2),
                HocPhi = reader.GetDecimal(3),
                ThoiLuong = reader.GetInt32(4),
                MaGV = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                TenGV = reader.IsDBNull(6) ? null : reader.GetString(6)
            };
        }
    }
}