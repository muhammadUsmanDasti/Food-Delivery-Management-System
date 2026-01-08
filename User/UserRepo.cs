using FoodDeliveryManagementSystem.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.Data.SqlClient;

namespace FoodDeliveryManagementSystem.Users
{ 
    internal class UserRepo
    { 
        public readonly string DbConnection = "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";


        public int Create(User user1)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = @"INSERT INTO Users (name, phone, email,password, role)
                                VALUES (@name, @phone, @email, @password,@role);
                                 SELECT CAST(SCOPE_IDENTITY() AS INT)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", user1.GetName());
                cmd.Parameters.AddWithValue("@phone", user1.GetPhone());
                cmd.Parameters.AddWithValue("@email", user1.GetEmail());
                cmd.Parameters.AddWithValue("@password", user1.GetPassword());
                cmd.Parameters.AddWithValue("@role", user1.GetRole());

                conn.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {

                string query = "SELECT userId,name,phone,email,password,role FROM Users WHERE email=@email AND password=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["userId"]);
                    string name = reader["name"].ToString();
                    string phone = reader["phone"].ToString();
                    string Email = reader["email"].ToString();
                    string Password = reader["password"].ToString();
                    string role = reader["role"].ToString();

                    //user = new User(userId,name,phone,Email,password,role);
                    if (role == "Customer" || role == "customer")
                        user = new Customer(userId, name, phone, Email, password, role);
                    else if (role == "Admin" || role == "admin")
                        user = new Admin(userId, name, phone, Email, password, role);
                    else if (role == "Rider" || role == "rider")
                        user = new Rider(userId, name, phone, Email, password, role);
                    else if (role == "Restaurant" || role == "restaurant")
                        user = new Restaurant(userId, name, phone, Email, password, role);


                }
                reader.Close();
            }

            return user;
        }

        public bool Update(User user)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "UPDATE Users SET name = @Name, phone = @Phone, email = @Email, password = @Password, role = @Role WHERE userId = @UserId";


                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@UserId", user.GetUserId());
                cmd.Parameters.AddWithValue("@Name", user.GetName());
                cmd.Parameters.AddWithValue("@Phone", user.GetPhone());
                cmd.Parameters.AddWithValue("@Email", user.GetEmail());
                 cmd.Parameters.AddWithValue("@Password", user.GetPassword());
                cmd.Parameters.AddWithValue("@role", user.GetRole());

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        public List<User> LoadAllUsers()
        {
            List<User> users = new List<User>();


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT userId, name, phone, email, password, role
                             FROM Users";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            User user = null;

                            // Create user object based on role
                            if (role == "Customer" || role == "customer")
                            {
                                user = new Customer();
                            }
                            else if (role == "Rider" || role == "rider")
                            {
                                user = new Rider();
                            }
                            else if (role == "Restaurant" || role == "restaurant")
                            {
                                user = new Restaurant();
                            }
                            else if (role == "Admin" || role == "admin")
                            {
                                user = new Admin();
                            }

                            if (user != null)
                            {
                                user.SetUserId(Convert.ToInt32(reader["userId"]));
                                user.SetName(reader["name"].ToString());
                                user.SetPhone(reader["phone"].ToString());
                                user.SetEmail(reader["email"].ToString());
                                user.SetPassword(reader["password"].ToString());
                                user.SetRole(role);

                                users.Add(user);
                            }
                        }
                    }
                }
            }


            return users;
        }




        public User LoadUserById(int userId)
        {
            User user = null;


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT userId, name, phone, email, password, role
                             FROM Users
                             WHERE userId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString().Trim();

                            // Create user object based on role
                            if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                            {
                                user = new Customer();
                            }
                            else if (role.Equals("Rider", StringComparison.OrdinalIgnoreCase))
                            {
                                user = new Rider();
                            }
                            else if (role.Equals("Restaurant", StringComparison.OrdinalIgnoreCase))
                            {
                                user = new Restaurant();
                            }
                            else if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                user = new Admin();
                            }
                            else
                            {

                                Console.WriteLine($"Warning: Unknown user role '{role}' for userId {userId}");
                                Console.ReadKey();
                                return null;
                            }

                            if (user != null)
                            {
                                user.SetUserId(Convert.ToInt32(reader["userId"]));
                                user.SetName(reader["name"].ToString());
                                user.SetPhone(reader["phone"].ToString());
                                user.SetEmail(reader["email"].ToString());
                                user.SetPassword(reader["password"].ToString());
                                user.SetRole(role);
                            }
                        }
                    }
                }
            }


            return user;
        }

        public bool DeleteUser(int userId)
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

                            int restaurantId = 0;
                            string getRestaurantId = "SELECT restaurantId FROM Restaurants WHERE userId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(getRestaurantId, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                object result = cmd.ExecuteScalar();
                                if (result != null)
                                {
                                    restaurantId = Convert.ToInt32(result);
                                }
                            }


                            int menuId = 0;
                            if (restaurantId > 0)
                            {
                                string getMenuId = "SELECT menuId FROM Menus WHERE restaurantId = @RestaurantId";
                                using (SqlCommand cmd = new SqlCommand(getMenuId, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
                                    object result = cmd.ExecuteScalar();
                                    if (result != null)
                                    {
                                        menuId = Convert.ToInt32(result);
                                    }
                                }
                            }


                            if (menuId > 0)
                            {
                                string deleteFoodItems = "DELETE FROM FoodItems WHERE menuId = @MenuId";
                                using (SqlCommand cmd = new SqlCommand(deleteFoodItems, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MenuId", menuId);
                                    cmd.ExecuteNonQuery();
                                }
                            }


                            if (restaurantId > 0)
                            {
                                string deleteMenu = "DELETE FROM Menus WHERE restaurantId = @RestaurantId";
                                using (SqlCommand cmd = new SqlCommand(deleteMenu, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            string deleteCustomer = "DELETE FROM Customers WHERE userId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(deleteCustomer, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteRider = "DELETE FROM Riders WHERE userId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(deleteRider, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }


                            string deleteRestaurant = "DELETE FROM Restaurants WHERE userId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(deleteRestaurant, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }


                            string deleteUser = "DELETE FROM Users WHERE userId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(deleteUser, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
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
                Console.WriteLine($"Error in DeleteUser: {ex.Message}");
                return false;
            }
        }



    }
}

