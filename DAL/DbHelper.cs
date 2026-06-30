using System.Configuration;
using Microsoft.Data.SqlClient;

namespace QL_trung_tam_tieng_anh.DAL
{
    public class DbHelper
    {
        private static readonly string connectionString =
            @"Server=WIN-RL373PRKS1G;Database=TrungTamTiengAnh;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}