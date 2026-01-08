using FoodDeliveryManagementSystem.Orders;
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
    public partial class UpdateOrderStatusForm : Form
    {
        private int restaurantId;
        private OrderService _orderService = new OrderService();
        public UpdateOrderStatusForm(int resId)
        {
            InitializeComponent();
            restaurantId = resId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateOrderStatusForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        private void LoadOrders()
        {
            List<Order> orders = _orderService.GetOrdersByRestaurantId(restaurantId);

            if (orders == null || orders.Count == 0)
            {
                MessageBox.Show("No orders found.");
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
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStatus("Preparing");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateStatus("Ready");
        }

        private void UpdateStatus(string newStatus)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Order ID"].Value);

            string currentStatus = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();

            if (currentStatus == newStatus)
            {
                MessageBox.Show("Order already has this status.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Update order status to '{newStatus}'?",
                "Confirm Update",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                bool result = _orderService.UpdateOrderStatus(orderId, newStatus);

                if (result)
                {
                    MessageBox.Show("Order status updated successfully!");
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Failed to update order status.");
                }
            }
        }

    }
}
