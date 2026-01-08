using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryManagementSystem.Payments
{
    public class PaymentRepo
    {
        private readonly string DbConnection = "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool InsertPayment(Payment payment)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"INSERT INTO Payments (orderId, amount, paymentStatus, paymentMethod)
                                     VALUES (@OrderId, @Amount, @PaymentStatus, @PaymentMethod)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", payment.GetOrderId());
                    cmd.Parameters.AddWithValue("@Amount", payment.GetAmount());
                    cmd.Parameters.AddWithValue("@PaymentStatus", payment.GetPaymentStatus());
                    cmd.Parameters.AddWithValue("@PaymentMethod", payment.GetPaymentMethod());

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();


                    return rowsAffected > 0;
                }
            }

        }

        public bool UpdatePaymentStatus(int orderId, string newStatus)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"UPDATE Payments 
                                     SET paymentStatus = @NewStatus
                                     WHERE orderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

        }

        public Payment GetPaymentByOrderId(int orderId)
        {
            Payment payment = null;


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT paymentId, orderId, amount, paymentStatus, paymentMethod
                                     FROM Payments
                                     WHERE orderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            payment = new Payment();
                            payment.SetPaymentId(Convert.ToInt32(reader["paymentId"]));
                            payment.SetOrderId(Convert.ToInt32(reader["orderId"]));
                            payment.SetAmount(Convert.ToDecimal(reader["amount"]));
                            payment.SetPaymentStatus(reader["paymentStatus"].ToString());
                            payment.SetPaymentMethod(reader["paymentMethod"].ToString());
                        }
                    }
                }
            }


            return payment;
        }
    }
}
