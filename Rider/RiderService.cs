using FoodDeliveryManagementSystem.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    public class RiderService
    {
        RiderRepo riderRepo;
        public RiderService()
        {
            riderRepo = new RiderRepo();
        }

        public int GetRiderIdByUserId(int userId)
        {
            return riderRepo.LoadRiderIdByUserId(userId);
        }
    }
}
