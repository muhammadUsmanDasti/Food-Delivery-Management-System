using FoodDeliveryManagementSystem.FoodItemss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Menus
{
    public class Menu
    {
        private int menuId;
        private int restaurantId;
        private List<FoodItems> foodItems;

        public int GetMenuId()
        {
            return this.menuId;
        }
        public void SetMenuId(int value)
        {
            this.menuId = value;
        }
        public int GetRestaurantId()
        {
            return this.restaurantId;
        }
        public void SetRestaurantId(int value)
        {
            this.restaurantId = value;
        }
        public Menu()
        {
            foodItems = new List<FoodItems>();
        }
        public List<FoodItems> GetFoodItems()
        {
            return this.foodItems;
        }

        public void AddFoodItem(FoodItems item)
        {
            foodItems.Add(item);
        }

        public void RemoveFoodItem(FoodItems item)
        {
            foodItems.Remove(item);
        }
    }
}
