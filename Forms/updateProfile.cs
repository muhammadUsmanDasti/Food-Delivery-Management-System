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
    public partial class updateProfile : Form
    {
        public updateProfile()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateProfile_Load(object sender, EventArgs e)
        {
            
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Customer");
            cmbRole.Items.Add("Rider");
            cmbRole.Items.Add("Restaurant");

            cmbRole.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            string currentEmail = textBox1.Text.Trim();
            string currentPassword = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentEmail) || string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Please enter your current email and password");
                return;
            }

            // 🔐 Authenticate user first
            User existingUser = userService.SignIn(currentEmail, currentPassword);

            if (existingUser == null)
            {
                MessageBox.Show("Invalid email or password");
                return;
            }

            
            string newName = textBox6.Text.Trim();
            string newPhone = textBox5.Text.Trim();
            string newEmail = textBox3.Text.Trim();
            string newPassword = textBox4.Text.Trim();
            string newRole = cmbRole.SelectedItem.ToString();

            
            if (string.IsNullOrWhiteSpace(newName) ||
                string.IsNullOrWhiteSpace(newPhone) ||
                string.IsNullOrWhiteSpace(newEmail) ||
                string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            
            existingUser.SetName(newName);
            existingUser.SetPhone(newPhone);
            existingUser.SetEmail(newEmail);
            existingUser.SetPassword(newPassword);
            existingUser.SetRole(newRole);

            
            bool result = userService.UpdateProfile(existingUser);

            if (result)
            {
                MessageBox.Show("Profile updated successfully!");
                this.Close();
              
            }
            else
            {
                MessageBox.Show("Profile update failed!");
            }
        }
    }
}
