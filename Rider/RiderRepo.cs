using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryManagementSystem.Users
{
    public class RiderRepo
    {

        private readonly string DbConnection =
            "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool InsertRider(int userId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "INSERT INTO Riders (userId, availability) VALUES (@userId, 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        public int LoadRiderIdByUserId(int userId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "SELECT riderId FROM Riders WHERE userId=@userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
