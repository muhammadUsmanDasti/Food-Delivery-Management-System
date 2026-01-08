using FoodDeliveryManagementSystem.FoodItemss;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace FoodDeliveryManagementSystem.Menus
{
    public class MenuRepo
    {
        private readonly string DbConnection = "Server=localhost;Database=FoodDeliveryDataBase;Trusted_Connection=True;TrustServerCertificate=True;";


        public Menu LoadMenuByRestaurantId(int restaurantId)
        {
            Menu menu = null;


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT menuId, restaurantId
                             FROM Menus
                             WHERE restaurantId = @RestaurantId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            menu = new Menu();
                            menu.SetMenuId(Convert.ToInt32(reader["menuId"]));
                            menu.SetRestaurantId(Convert.ToInt32(reader["restaurantId"]));
                        }
                    }
                }
            }


            return menu;
        }


        public List<FoodItems> LoadFoodItemsByMenuId(int menuId)
        {
            List<FoodItems> foodItems = new List<FoodItems>();


            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"SELECT foodItemId, menuId, name, price, description, availability
                             FROM FoodItems
                             WHERE menuId = @MenuId ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MenuId", menuId);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodItems foodItem = new FoodItems();
                            foodItem.SetFoodItemId(Convert.ToInt32(reader["foodItemId"]));
                            foodItem.SetMenuId(Convert.ToInt32(reader["menuId"]));
                            foodItem.SetName(reader["name"].ToString());
                            foodItem.SetPrice(Convert.ToDecimal(reader["price"]));
                            foodItem.SetDescription(reader["description"].ToString());
                            foodItem.SetAvailability(Convert.ToBoolean(reader["availability"]));

                            foodItems.Add(foodItem);
                        }
                    }
                }
            }


            return foodItems;
        }


        public bool CreateMenu(int restaurantId)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = "INSERT INTO Menus (restaurantId) VALUES (@RestaurantId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

        }

        public bool InsertFoodItem(FoodItems foodItem)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = @"INSERT INTO FoodItems (menuId, name, price, description, availability)
                                    VALUES (@MenuId, @Name, @Price, @Description, @Availability)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MenuId", foodItem.GetMenuId());
                    cmd.Parameters.AddWithValue("@Name", foodItem.GetName());
                    cmd.Parameters.AddWithValue("@Price", foodItem.GetPrice());
                    cmd.Parameters.AddWithValue("@Description", foodItem.GetDescription());
                    cmd.Parameters.AddWithValue("@Availability", foodItem.GetAvailability());

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

        }

        public bool DeleteFoodItem(int foodItemId)
        {

            using (SqlConnection con = new SqlConnection(DbConnection))
            {
                string query = "DELETE FROM FoodItems WHERE foodItemId = @FoodItemId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FoodItemId", foodItemId);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
