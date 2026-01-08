using FoodDeliveryManagementSystem.Orders;
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
    public partial class CustomerDashboard : Form
    {
        private User _user;
        private Customer _customer;


        public CustomerDashboard(User user)
        {
            InitializeComponent();
            _user = user;
            _customer = new Customer();
        }


        private void button4_Click(object sender, EventArgs e)
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

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestaurantService restaurantService = new RestaurantService();
            List<Restaurant> restaurants = restaurantService.ShowAllRestaurants();
            //
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RestaurantID", typeof(int)));
            dt.Columns.Add("Name");
            dt.Columns.Add("Location");
            dt.Columns.Add("Rating");
            dt.Columns.Add("Status");

            foreach (var r in restaurants)
            {
                dt.Rows.Add(r.GetRestaurantId(), r.GetName(), r.GetLocation(), r.GetRating(), r.GetIsOpen() ? "Open" : "Closed");
            }

            dataGridView1.DataSource = dt;

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int restaurantId = Convert.ToInt32(
                dataGridView1.Rows[e.RowIndex].Cells[0].Value
            );

            RestaurantMenuForm menuForm = new RestaurantMenuForm(restaurantId);
            menuForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerService customerService = new CustomerService();
            OrderService orderService = new OrderService();

            int customerId = customerService.GetCustomerIdByUserId(_user.GetUserId());
            List<Order> orders = orderService.ViewOrdersByCustomerId(customerId);

            DataTable dt = new DataTable();
            dt.Columns.Add("Order ID");
            dt.Columns.Add("Date");
            dt.Columns.Add("Status");
            dt.Columns.Add("Total");

            foreach (var o in orders)
            {
                dt.Rows.Add(
                    o.GetOrderId(),
                    o.GetOrderDate(),
                    o.GetOrderStatus(),
                    o.GetTotalAmount()
                );
            }

            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlaceOrderForm placeOrderForm = new PlaceOrderForm(_user);
            placeOrderForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
