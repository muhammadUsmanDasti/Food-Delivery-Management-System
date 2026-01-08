using FoodDeliveryManagementSystem.Orders;
using FoodDeliveryManagementSystem.Usres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    internal class UserService
    {
        private readonly UserRepo repo = new UserRepo();
        private readonly CustomerRepo customerRepo = new CustomerRepo();
        private readonly RiderRepo riderRepo = new RiderRepo();
        private readonly RestaurantRepo restaurantRepo = new RestaurantRepo();

        public bool SignUp(User user, Restaurant restaurantInfo)
        {
            if (user.GetRole().ToLower() == "admin")
            {
                Console.WriteLine("Admin accounts cannot be created");
                return false;
            }

            int userId = repo.Create(user);
            if (userId <= 0)
            {
                return false;
            }
            switch (user.GetRole().ToLower())
            {
                case "customer":
                    customerRepo.InsertCustomer(userId);
                    break;
                case "rider":
                    riderRepo.InsertRider(userId);
                    break;
                case "restaurant":
                    string name = restaurantInfo.GetName();
                    string location = restaurantInfo.GetLocation();
                    decimal rating = restaurantInfo.GetRating();

                    restaurantRepo.InsertRestaurant(userId, name, location, rating, true);
                    break;

                default:
                    customerRepo.InsertCustomer(userId);
                    break;
            }
            return true;

        }

        public User SignIn(string email, string password)
        {
            return repo.GetByEmailAndPassword(email, password);
        }

        public bool UpdateProfile(User user)
        {
            return repo.Update(user);
        }
    }

}
