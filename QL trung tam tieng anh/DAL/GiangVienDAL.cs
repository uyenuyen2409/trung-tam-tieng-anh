using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using QL_trung_tam_tieng_anh.Interfaces;
using QL_trung_tam_tieng_anh.Models;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class GiangVienDAL : IGiangVienDAL
    {
        public List<GiangVien> GetAll()
        {
            var list = new List<GiangVien>();
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaGV, HoTen, GioiTinh, NgaySinh, SDT, Email, ChuyenMon FROM GiangVien", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(Map(reader));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetAll GiangVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public GiangVien GetById(int id)
        {
            GiangVien result = null;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaGV, HoTen, GioiTinh, NgaySinh, SDT, Email, ChuyenMon FROM GiangVien WHERE MaGV = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) result = Map(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetById GiangVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int Add(GiangVien gv)
        {
            int newId = 0;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"INSERT INTO GiangVien (HoTen, GioiTinh, NgaySinh, SDT, Email, ChuyenMon)
                    VALUES (@HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @ChuyenMon);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
                AddParams(cmd, gv);
                newId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Add GiangVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return newId;
        }

        public bool Update(GiangVien gv)
        {
            bool success = false;
            var conn = DbHelper.GetConnection();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(@"UPDATE GiangVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh,
                    SDT=@SDT, Email=@Email, ChuyenMon=@ChuyenMon WHERE MaGV=@MaGV", conn);
                AddParams(cmd, gv);
                cmd.Parameters.AddWithValue("@MaGV", gv.MaGV);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Update GiangVien: " + ex.Message);
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
                var cmd = new SqlCommand("DELETE FROM GiangVien WHERE MaGV = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Delete GiangVien: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool IsTrungEmail(string email, int excludeId = 0)
        {
            return GetAll().Any(x => x.Email == email && x.MaGV != excludeId);
        }

        private void AddParams(SqlCommand cmd, GiangVien gv)
        {
            cmd.Parameters.AddWithValue("@HoTen", gv.HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", (object)gv.GioiTinh ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NgaySinh", (object)gv.NgaySinh ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SDT", (object)gv.SDT ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object)gv.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ChuyenMon", (object)gv.ChuyenMon ?? DBNull.Value);
        }

        private GiangVien Map(SqlDataReader reader)
        {
            return new GiangVien
            {
                MaGV = reader.GetInt32(0),
                HoTen = reader.GetString(1),
                GioiTinh = reader.IsDBNull(2) ? null : reader.GetString(2),
                NgaySinh = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                SDT = reader.IsDBNull(4) ? null : reader.GetString(4),
                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                ChuyenMon = reader.IsDBNull(6) ? null : reader.GetString(6)
            };
        }
    }
}