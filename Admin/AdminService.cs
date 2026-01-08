using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Users
{
    public class AdminService
    {
        private readonly UserRepo userRepo;

        public AdminService()
        {
            userRepo = new UserRepo();
        }

        public List<User> GetAllUsers()
        {

            List<User> users = userRepo.LoadAllUsers();

            if (users != null && users.Count > 0)
            {
                return users;
            }
            else
            {
                return new List<User>();
            }


        }
        public User GetUserById(int userId)
        {

            User user = userRepo.LoadUserById(userId);
            return user;

        }

        public bool DeleteUser(int userId)
        {

            bool result = userRepo.DeleteUser(userId);
            return result;
        }
    }
}
