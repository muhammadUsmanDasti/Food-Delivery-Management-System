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
    public class CustomerRepo
    {
        private readonly string DbConnection =
            "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";
        public int LoadCustomerIdByUserId(int userId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "SELECT customerId FROM Customers WHERE userId=@userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public bool InsertCustomer(int userId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "INSERT INTO Customers (userId) VALUES (@userId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
