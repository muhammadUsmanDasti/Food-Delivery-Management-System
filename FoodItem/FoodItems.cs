using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.FoodItemss
{
    public class FoodItems
    {
        private int foodItemId;
        private int menuId;
        private string name;
        private decimal price;
        private string description;
        private bool availability;

        public void SetFoodItemId(int value)
        {
            this.foodItemId = value;
        }
        public int GetFoodItemId()
        {
            return this.foodItemId;
        }
        public void SetMenuId(int value)
        {
            this.menuId = value;
        }
        public int GetMenuId()
        {
            return this.menuId;
        }
        public void SetName(string value)
        {
            this.name = value;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetPrice(decimal value)
        {
            this.price = value;
        }
        public decimal GetPrice()
        {
            return this.price;
        }
        public void SetDescription(string value)
        {
            this.description = value;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public void SetAvailability(bool value)
        {
            this.availability = value;
        }
        public bool GetAvailability()
        {
            return this.availability;
        }
        public FoodItems()
        {

        }
        public FoodItems(string name, decimal price, string description, bool availability)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.availability = availability;
        }
    }
}
