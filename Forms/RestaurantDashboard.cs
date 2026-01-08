using FoodDeliveryManagementSystem.FoodItemss;
using FoodDeliveryManagementSystem.Menus;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace foodDeliveryManagementSys.Forms
{
    public partial class RestaurantDashboard : Form
    {
        private User _user;

        public RestaurantDashboard(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private int GetRestaurantId()
        {
            RestaurantService restaurantService = new RestaurantService();
            return restaurantService.GetRestaurantIdByUserId(_user.GetUserId());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int restaurantId = GetRestaurantId();
            if (restaurantId <= 0)
            {
                MessageBox.Show("Restaurant record not found.");
                return;
            }

            MenuService menuService = new MenuService();
            FoodDeliveryManagementSystem.Menus.Menu menu = menuService.GetMenuByRestaurantId(restaurantId);

            if (menu == null)
            {
                MessageBox.Show("Menu not found.");
                return;
            }

            List<FoodItems> foodItems = menuService.GetFoodItemsByMenuId(menu.GetMenuId());

            DataTable dt = new DataTable();
            dt.Columns.Add("Item ID", typeof(int));
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Available");

            foreach (var item in foodItems)
            {
                dt.Rows.Add(
                    item.GetFoodItemId(),
                    item.GetName(),
                    item.GetPrice(),
                    item.GetAvailability() ? "Yes" : "No"
                );
            }

            dataGridView1.DataSource = dt;
            label2.Text = "My Menu";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            DeleteFoodItemForm form = new DeleteFoodItemForm(_user);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int restaurantId = GetRestaurantId();
            if (restaurantId <= 0)
            {
                MessageBox.Show("Restaurant record not found.");
                return;
            }
            OrderService _orderService = new OrderService();
            List<Order> orders = _orderService.GetOrdersByRestaurantId(restaurantId);
            if (orders == null || orders.Count == 0)
            {
                MessageBox.Show("No orders found");
                return;
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("Order ID", typeof(int));
            dt.Columns.Add("Date");
            dt.Columns.Add("Status");
            dt.Columns.Add("Amount");

            foreach (Order o in orders)
            {
                dt.Rows.Add(
                    o.GetOrderId(),
                    o.GetOrderDate(),
                    o.GetOrderStatus(),
                    o.GetTotalAmount()
                );
            }
            dataGridView1.DataSource = dt;
            label2.Text = "My Orders";

        }

        private void button7_Click(object sender, EventArgs e)
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

        private void RestaurantDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFoodItem form = new AddFoodItem(_user);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int restaurantId = GetRestaurantId();

            if (restaurantId <= 0)
            {
                MessageBox.Show("Restaurant record not found.");
                return;
            }

            UpdateOrderStatusForm form = new UpdateOrderStatusForm(restaurantId);
            form.ShowDialog();
        }
    }
}
