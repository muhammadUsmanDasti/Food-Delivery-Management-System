using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    internal class Admin : User
    {
        private int adminId;
        public void SetAdminId(int value)
        {
            adminId = value;
        }
        public int GetAdminId()
        {
            return this.adminId;
        }
        public Admin()
        {

        }
        public Admin(string name, string phone, string email, string password, string role)
        : base(name, phone, email, password, role)
        {

        }
        public Admin(int userId, string name, string phone, string email, string password, string role)
        : base(userId, name, phone, email, password, "Admin")
        {

        }
    }
}
