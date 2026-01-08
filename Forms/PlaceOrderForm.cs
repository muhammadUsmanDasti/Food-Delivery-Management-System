using FoodDeliveryManagementSystem.FoodItemss;
using FoodDeliveryManagementSystem.Menus;
using FoodDeliveryManagementSystem.Orders;
using FoodDeliveryManagementSystem.Users;
using System.Windows.Forms;
namespace foodDeliveryManagementSys.Forms
{

    public partial class PlaceOrderForm : System.Windows.Forms.Form

    {
        private User _user;
        private RestaurantService _restaurantService = new RestaurantService();
        private MenuService _menuService = new MenuService();
        private OrderService _orderService = new OrderService();
        private CustomerService _customerService = new CustomerService();


        public PlaceOrderForm()
        {
            InitializeComponent();
        }
        public PlaceOrderForm(User user) : this()
        {
            _user = user;
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            List<Restaurant> restaurants = _restaurantService.ShowAllRestaurants();

            comboBox1.DataSource = restaurants;
            

            SetupMenuGrid();
            
        }

        private void SetupMenuGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("FoodItemId", "ID");
            dataGridView1.Columns["FoodItemId"].Visible = false;

            dataGridView1.Columns.Add("Name", "Item Name");
            dataGridView1.Columns.Add("Price", "Price");

            DataGridViewTextBoxColumn dt = new DataGridViewTextBoxColumn();
            dt.Name = "Quantity";
            dt.HeaderText = "Quantity";
            dataGridView1.Columns.Add(dt);

            dataGridView1.Columns.Add("Availability", "Availability");

        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
            {
                decimal totalAmount = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Quantity"].Value == null) continue;

                    int qty;
                    if (!int.TryParse(row.Cells["Quantity"].Value.ToString(), out qty)) continue;

                    if (qty <= 0) continue;

                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    totalAmount += price * qty;
                }

                total.Text = totalAmount.ToString("0.00");

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            Restaurant selectedRestaurant = (Restaurant)comboBox1.SelectedItem;

            int restaurantId = selectedRestaurant.GetRestaurantId();

   

            if (!selectedRestaurant.GetIsOpen())
            {
                MessageBox.Show("This restaurant is closed.");
                return;
            }

            Menu menu = _menuService.GetMenuByRestaurantId(restaurantId);
            if (menu == null) return;

            List<FoodItems> items = _menuService.GetFoodItemsByMenuId(menu.GetMenuId());

            dataGridView1.Rows.Clear();

            foreach (var item in items)
            {
                dataGridView1.Rows.Add(
                    item.GetFoodItemId(),
                    item.GetName(),
                    item.GetPrice(),
                    0,
                    item.GetAvailability() ? "Available" : "Not Available"
                );
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a restaurant.");
                return;
            }

            Restaurant selectedRestaurant = (Restaurant)comboBox1.SelectedItem;

            List<OrderItem> orderItems = new List<OrderItem>();
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Quantity"].Value == null) continue;

                if (!int.TryParse(row.Cells["Quantity"].Value.ToString(), out int qty)) continue;
                if (qty <= 0) continue;

                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                OrderItem item = new OrderItem();
                item.SetFoodItemId(Convert.ToInt32(row.Cells["FoodItemId"].Value));
                item.SetQuantity(qty);
                item.SetPrice(price);

                orderItems.Add(item);
                totalAmount += price * qty;
            }

            if (orderItems.Count == 0)
            {
                MessageBox.Show("Please select at least one item.");
                return;
            }

            int customerId = _customerService.GetCustomerIdByUserId(_user.GetUserId());

            Order order = new Order();
            order.SetCustomerId(customerId);
            order.SetRestaurantId(selectedRestaurant.GetRestaurantId());
            order.SetOrderDate(DateTime.Now);
            order.SetTotalAmount(totalAmount);
            order.SetOrderStatus("Pending");

            bool result = _orderService.PlaceOrder(order, orderItems, "Cash on Delivery");

            MessageBox.Show(result ? "Order placed successfully!" : "Order failed!");
            this.Hide();
        }

    }
}
