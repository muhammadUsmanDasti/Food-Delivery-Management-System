using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    public class Rider : User
    {
        private int riderId;
        private bool availability;
        public int GetRiderId()
        {
            return riderId;
        }
        public void SetRiderId(int value)
        {
            this.riderId = value;
        }
        public void SetAvailability(bool value)
        {
            this.availability = value;
        }
        public bool GetAvailability()
        {
            return this.availability;
        }

        public Rider()
        {

        }
        public Rider(string name, string phone, string email, string password, string role)
        : base(name, phone, email, password, role)
        {

        }
        public Rider(int userId, string name, string phone, string email, string password, string role)
        : base(userId, name, phone, email, password, "rider")
        {

        }


    }
}
