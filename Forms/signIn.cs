using FoodDeliveryManagementSystem.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foodDeliveryManagementSys.Forms
{
    public partial class signIn : Form
    {
        public signIn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void signIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password");
                return;
            }
            UserService userService = new UserService();
            User loggedInUser = userService.SignIn(email, password);

            if (loggedInUser == null)
            {
                MessageBox.Show("Invalid email or password");
                return;
            }

            MessageBox.Show("Welcome " + loggedInUser.GetName());

            OpenDashboard(loggedInUser);

        }
        private void OpenDashboard(User user)
        {
            this.Hide();
            string role = user.GetRole()?.Trim().ToLower();
            switch (role)
            {

                case "admin":
                    new AdminDashboard(user).Show();
                    break;

                case "customer":
                    new CustomerDashboard(user).Show();
                    break;

                case "rider":
                    new RiderDashboard(user).Show();
                    break;

                case "restaurant":
                    new RestaurantDashboard(user).Show();
                    break;

                default:
                    MessageBox.Show(
                    $"Unknown role: {user.GetRole()}",
                    "Role Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                    this.Show();
                    break;

            }
        }

        
    }
}
