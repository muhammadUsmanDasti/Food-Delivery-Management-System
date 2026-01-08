using FoodDeliveryManagementSystem.Users;
using FoodDeliveryManagementSystem.Usres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{


    public class RestaurantService
    {

        RestaurantRepo restaurantRepo;

        public RestaurantService()
        { 
            restaurantRepo = new RestaurantRepo();
        }

        public List<Restaurant> ShowAllRestaurants()
        {
            return restaurantRepo.GetAllRestaurants();

        }
        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurantRepo.LoadRestaurantById(restaurantId);
        }

        public int GetRestaurantIdByUserId(int userId)
        {
            return restaurantRepo.LoadRestaurantIdByUserId(userId);
        }



    }
}
