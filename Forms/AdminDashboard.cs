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
    public partial class AdminDashboard : Form
    {
        private User _user;

        public AdminDashboard(User user)
        {
            InitializeComponent();
            _user = user;
        }
        public AdminDashboard()
        {
            InitializeComponent();
            this.Load += AdminDashboard_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminService adminService = new AdminService();
            List<User> users = adminService.GetAllUsers();

            if (users == null || users.Count == 0)
            {
                MessageBox.Show("No users found");
                return;
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("User ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Role");

            foreach (var user in users)
            {
                dt.Rows.Add(user.GetUserId(), user.GetName(), user.GetEmail(), user.GetPhone(), user.GetRole());
            }


            dataGridViewUsers.DataSource = dt;
        }

        private void panelDeleteUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDeleteUser.Visible = true;
        }

        private void buttonConfirmDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a User ID");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int userId))
            {
                MessageBox.Show("User ID must be a number");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete user with ID {userId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                AdminService userService = new AdminService();
                bool success = userService.DeleteUser(userId);


                if (success)
                {
                    MessageBox.Show("User deleted successfully!");
                    textBox1.Clear();
                    panelDeleteUser.Visible = false;
                }
                else
                {
                    MessageBox.Show("Failed to delete user. ID may not exist.");
                }
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            panelDeleteUser.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _user = null;
                this.Hide();
                signIn loginForm = new signIn();
                loginForm.Show();
            }
        }
    }
}
