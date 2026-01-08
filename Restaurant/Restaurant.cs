using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    public class Restaurant : User
    {
        private int restaurantId;
        private string location;
        private decimal rating;
        private bool isOpen;

        public void SetRestaurantId(int value)
        {
            restaurantId = value;
        }
        public int GetRestaurantId()
        {
            return this.restaurantId;
        }
        public void SetLocation(string value)
        {
            location = value;
        }
        public string GetLocation()
        {
            return this.location;
        }
        public void SetRating(decimal value)
        {
            rating = value;
        }
        public decimal GetRating()
        {
            return this.rating;
        }
        public void SetIsOpen(bool value)
        {
            isOpen = value;
        }
        public bool GetIsOpen()
        {
            return this.isOpen;
        }
        public Restaurant()
        {

        }
        public Restaurant(string name, string phone, string email, string password, string role) : base(name, phone, email, password, role) { }
        public Restaurant(int userId, string name, string phone, string email, string password, string role)
        : base(userId, name, phone, email, password, "restaurant")
        {

        }
        public Restaurant(string name, string phone, string email, string password, string location, decimal rating, bool isOpen) : base(name, phone, email, password, "restuarant")
        {
            this.location = location;
            this.rating = rating;
            this.isOpen = isOpen;

        }
        public override string ToString()
        {
            return GetName();
        }

    }
}
