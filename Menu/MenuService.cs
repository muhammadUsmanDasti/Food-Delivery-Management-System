using FoodDeliveryManagementSystem.FoodItemss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Menus
{
    public class MenuService
    {

        private readonly MenuRepo menuRepo;
        public MenuService()
        {
            menuRepo = new MenuRepo();
        }


        public Menu GetMenuByRestaurantId(int restaurantId)
        {
            Menu menu = menuRepo.LoadMenuByRestaurantId(restaurantId);
            return menu;
        }

        public List<FoodItems> GetFoodItemsByMenuId(int menuId)
        {
            List<FoodItems> foodItems = menuRepo.LoadFoodItemsByMenuId(menuId);
            return foodItems;
        }



        public bool CreateMenu(int restaurantId)
        {

            bool result = menuRepo.CreateMenu(restaurantId);
            return result;


        }

        public bool AddFoodItem(FoodItems foodItem)
        {
            bool result = menuRepo.InsertFoodItem(foodItem);
            return result;
        }

        public bool DeleteFoodItem(int foodItemId)
        {


            bool result = menuRepo.DeleteFoodItem(foodItemId);
            return result;
        }


    }
}
