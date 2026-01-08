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
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlRestaurant.Visible = cmbRole.SelectedItem.ToString() == "Restaurant";
        }

        private void signUp_Load(object sender, EventArgs e)
        {

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Customer");
            cmbRole.Items.Add("Rider");
            cmbRole.Items.Add("Restaurant");

            cmbRole.SelectedIndex = 0; // default selection


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string phone = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            User user;
            Restaurant restaurantInfo = null;

            if (role == "Customer")
            {
                user = new Customer(name, phone, email, password, role);
            }
            else if (role == "Rider")
            {
                user = new Rider(name, phone, email, password, role);
            }
            else
            {
                user = new Restaurant(name, phone, email, password, role);

                string resName = txtResName.Text.Trim();
                string resLocation = txtResLocation.Text.Trim();

                if (!decimal.TryParse(txtResRating.Text, out decimal rating))
                {
                    MessageBox.Show("Invalid rating");
                    return;
                }

                restaurantInfo = new Restaurant();
                restaurantInfo.SetName(resName);
                restaurantInfo.SetLocation(resLocation);
                restaurantInfo.SetRating(rating);
            }

            UserService userService = new UserService();
            bool result = userService.SignUp(user, restaurantInfo);

            MessageBox.Show(result ? "Signup successful" : "Signup failed");
        

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
