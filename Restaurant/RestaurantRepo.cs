using FoodDeliveryManagementSystem.Users;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FoodDeliveryManagementSystem.Usres
{
    public class RestaurantRepo
    {

        public readonly string DbConnection = "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";
        public List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT restaurantId, userId, name, location, rating, isOpen
                                 FROM Restaurants";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Restaurant restaurant = new Restaurant();
                    restaurant.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                    restaurant.SetUserId(Convert.ToInt32(reader["userId"]));
                    restaurant.SetName(Convert.ToString(reader["name"]));
                    restaurant.SetLocation(Convert.ToString(reader["location"]));
                    restaurant.SetRating(Convert.ToDecimal(reader["rating"]));
                    restaurant.SetIsOpen(Convert.ToBoolean(reader["isOpen"]));

                    restaurants.Add(restaurant);
                }
            }
            return restaurants;
        }



        public Restaurant LoadRestaurantById(int restaurantId)
        {
            Restaurant restaurant = null;
            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT restaurantId, userId, name, location, rating, isOpen
                                 FROM Restaurants where restaurantId = @RestaurantId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    restaurant = new Restaurant();

                    restaurant.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                    restaurant.SetUserId(Convert.ToInt32(reader["userId"]));
                    restaurant.SetName(Convert.ToString(reader["name"]));
                    restaurant.SetLocation(Convert.ToString(reader["location"]));
                    restaurant.SetRating(Convert.ToDecimal(reader["rating"]));
                    restaurant.SetIsOpen(Convert.ToBoolean(reader["isOpen"]));

                }
            }
            return restaurant;
        }


        //public bool InsertRestaurant(int userId)
        //{
        //    using (SqlConnection conn = new SqlConnection(DbConnection))
        //    {

        //        string query = @"INSERT INTO Restaurants (userId, name, location, rating, isOpen) 
        //                        VALUES (@userId, '', '', 0, 0)";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@userId", userId);

        //        conn.Open();
        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        return rowsAffected > 0;
        //    }
        //}
        public bool InsertRestaurant(int userId, string name, string location, decimal rating, bool isOpen)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = @"INSERT INTO Restaurants (userId, name, location, rating, isOpen) 
                        VALUES (@userId, @name, @location, @rating, @isOpen)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.Parameters.AddWithValue("@isOpen", isOpen);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        public int LoadRestaurantIdByUserId(int userId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "SELECT restaurantId FROM Restaurants WHERE userId=@userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
