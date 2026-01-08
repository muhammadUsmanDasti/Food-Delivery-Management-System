using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    internal class CustomerService
    {
        private readonly CustomerRepo customerRepo;
        public CustomerService()
        {
            customerRepo = new CustomerRepo();
        }

        public int GetCustomerIdByUserId(int userId)
        {
            return customerRepo.LoadCustomerIdByUserId(userId);
        }
    }
}
