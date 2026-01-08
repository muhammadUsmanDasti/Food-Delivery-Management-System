using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryManagementSystem.Orders
{
    public class OrderRepo
    {
        private readonly string DbConnection =
            "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = "SELECT orderId, orderDate, totalAmount, orderStatus FROM Orders WHERE customerId = @CustomerId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();


                    order.SetOrderId(Convert.ToInt32(reader["orderId"]));
                    order.SetOrderDate(Convert.ToDateTime(reader["orderDate"]));
                    order.SetTotalAmount(Convert.ToDecimal(reader["totalAmount"]));
                    order.SetOrderStatus(Convert.ToString(reader["orderStatus"]));

                    orders.Add(order);
                }
            }
            return orders;
        }






        public List<Order> LoadAvailableOrders()
        {
            List<Order> orders = new List<Order>();


            using (SqlConnection con = new SqlConnection(DbConnection))
            {


                string query = @"SELECT orderId, customerId, restaurantId, orderDate, totalAmount, orderStatus 
                 FROM Orders 
                 WHERE riderId IS NULL 
                 AND orderStatus IN ('Pending', 'Ready')
                 ORDER BY orderDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.SetOrderId(Convert.ToInt32(reader["orderId"]));
                            order.SetCustomerId(Convert.ToInt32(reader["customerId"]));
                            order.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                            order.SetOrderDate(Convert.ToDateTime(reader["orderDate"]));
                            order.SetTotalAmount(Convert.ToDecimal(reader["totalAmount"]));
                            order.SetOrderStatus(reader["orderStatus"].ToString());

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        public bool AssignRiderToOrder(int orderId, int riderId)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"UPDATE Orders 
                             SET riderId = @RiderId, 
                                 orderStatus = 'Accepted'
                             WHERE orderId = @OrderId 
                             AND riderId IS NULL
                             AND orderStatus = 'Ready'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RiderId", riderId);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

        }



        public List<Order> LoadOrdersByRiderId(int riderId)
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (SqlConnection con = new SqlConnection(DbConnection))
                {
                    string query = @"SELECT orderId, customerId, restaurantId, riderId, 
                             orderDate, totalAmount, orderStatus 
                             FROM Orders 
                             WHERE riderId = @RiderId
                             ORDER BY orderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RiderId", riderId);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Order order = new Order();
                                order.SetOrderId(Convert.ToInt32(reader["orderId"]));
                                order.SetCustomerId(Convert.ToInt32(reader["customerId"]));
                                order.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                                order.SetRiderId(Convert.ToInt32(reader["riderId"]));
                                order.SetOrderDate(Convert.ToDateTime(reader["orderDate"]));
                                order.SetTotalAmount(Convert.ToDecimal(reader["totalAmount"]));
                                order.SetOrderStatus(reader["orderStatus"].ToString());

                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetOrdersByRiderId: {ex.Message}");
                throw;
            }

            return orders;
        }


        public bool UpdateOrderStatus(int orderId, string newStatus)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"UPDATE Orders 
                             SET orderStatus = @NewStatus
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



        public List<Order> LoadOrdersByRestaurantId(int restaurantId)
        {
            List<Order> orders = new List<Order>();


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT orderId, customerId, restaurantId, riderId, 
                             orderDate, totalAmount, orderStatus 
                             FROM Orders 
                             WHERE restaurantId = @RestaurantId
                             ORDER BY orderDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.SetOrderId(Convert.ToInt32(reader["orderId"]));
                            order.SetCustomerId(Convert.ToInt32(reader["customerId"]));
                            order.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                            //to fix the crash
                            if (reader["riderId"] == DBNull.Value)
                            {
                                order.SetRiderId(0);
                            }
                            else
                            {
                                order.SetRiderId(Convert.ToInt32(reader["riderId"]));
                            }

                            order.SetOrderDate(Convert.ToDateTime(reader["orderDate"]));
                            order.SetTotalAmount(Convert.ToDecimal(reader["totalAmount"]));
                            order.SetOrderStatus(reader["orderStatus"].ToString());

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }


        public bool PlaceOrderWithPayment(Order order, List<OrderItem> orderItems, string paymentMethod)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DbConnection))
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {

                            string insertOrder = @"INSERT INTO Orders (customerId, restaurantId, riderId, orderDate, totalAmount, orderStatus)
                                          VALUES (@CustomerId, @RestaurantId, NULL, @OrderDate, @TotalAmount, @OrderStatus);
                                          SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            int orderId = 0;
                            using (SqlCommand cmd = new SqlCommand(insertOrder, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@CustomerId", order.GetCustomerId());
                                cmd.Parameters.AddWithValue("@RestaurantId", order.GetRestaurantId());
                                cmd.Parameters.AddWithValue("@OrderDate", order.GetOrderDate());
                                cmd.Parameters.AddWithValue("@TotalAmount", order.GetTotalAmount());
                                cmd.Parameters.AddWithValue("@OrderStatus", order.GetOrderStatus());

                                orderId = (int)cmd.ExecuteScalar();
                                order.SetOrderId(orderId);
                            }

                            if (orderId <= 0)
                            {
                                transaction.Rollback();
                                return false;
                            }


                            foreach (var item in orderItems)
                            {
                                item.SetOrderId(orderId);

                                string insertItem = @"INSERT INTO OrderItems (orderId, foodItemId, quantity, price)
                                             VALUES (@OrderId, @FoodItemId, @Quantity, @Price)";

                                using (SqlCommand cmd = new SqlCommand(insertItem, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderId", item.GetOrderId());
                                    cmd.Parameters.AddWithValue("@FoodItemId", item.GetFoodItemId());
                                    cmd.Parameters.AddWithValue("@Quantity", item.GetQuantity());
                                    cmd.Parameters.AddWithValue("@Price", item.GetPrice());

                                    cmd.ExecuteNonQuery();
                                }
                            }


                            string insertPayment = @"INSERT INTO Payments (orderId, amount, paymentStatus, paymentMethod)
                                            VALUES (@OrderId, @Amount, @PaymentStatus, @PaymentMethod)";

                            using (SqlCommand cmd = new SqlCommand(insertPayment, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", orderId);
                                cmd.Parameters.AddWithValue("@Amount", order.GetTotalAmount());
                                cmd.Parameters.AddWithValue("@PaymentStatus", "Pending");
                                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                                cmd.ExecuteNonQuery();
                            }


                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PlaceOrderWithPayment: {ex.Message}");
                return false;
            }
        }
    }
}


