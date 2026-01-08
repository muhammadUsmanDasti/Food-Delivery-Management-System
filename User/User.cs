using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    public abstract class User
    {
        protected int userId;
        public string name;
        protected string phone;
        protected string email;
        protected string password;
        protected string role;
        public void SetUserId(int value)
        {
            this.userId = value;
        }
        public int GetUserId()
        {
            return userId;
        }
        public void SetName(string value)
        {
            this.name = value;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetPhone(string value)
        {
            this.phone = value;
        }
        public string GetPhone()
        {
            return this.phone;
        }
        public void SetEmail(string value)
        {
            this.email = value;
        }
        public string GetEmail()
        {
            return this.email;
        }
        public void SetPassword(string value)
        {
            this.password = value;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public void SetRole(string value)
        {
            this.role = value;
        }
        public string GetRole()
        {
            return this.role;
        }

        public User() { }

        public User(string name, string phone, string email, string password, string role)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.password = password;
            this.role = role;
        }
        public User(int userId, string name, string phone, string email, string password, string role)
        {
            this.userId = userId;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.password = password;
            this.role = role;
        }
    }
}
