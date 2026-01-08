using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodDeliveryManagementSystem.Users
{
    public class Customer : User
    {
        private int customerId;
        public void SetCustomerId(int value)
        {
            customerId = value;
        }
        public int GetCustomerId()
        {
            return customerId;
        }
        public Customer() { }
        public Customer(string name, string phone, string email, string password, string role)
        : base(name, phone, email, password, "customer")
        {

        }
        public Customer(int userId, string name, string phone, string email, string password, string role)
        : base(userId, name, phone, email, password, "customer")
        {

        }

    }
}
