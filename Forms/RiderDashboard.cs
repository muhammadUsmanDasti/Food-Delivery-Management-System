using FoodDeliveryManagementSystem.Orders;
using FoodDeliveryManagementSystem.Payments;
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
    public partial class RiderDashboard : Form
    {
        private User _user;
        private readonly RiderService _riderService;
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;

        public RiderDashboard(User user)
        {
            InitializeComponent();
            _user = user;
            _riderService = new RiderService();
            _orderService = new OrderService();
            _paymentService = new PaymentService();

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

        private void RiderDashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> availableOrders = _orderService.GetAvailableOrders();

            if (availableOrders == null || availableOrders.Count == 0)
            {
                MessageBox.Show("No available orders.");
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Order ID");
            dt.Columns.Add("Date");
            dt.Columns.Add("Status");
            dt.Columns.Add("Amount");

            foreach (var order in availableOrders)
            {
                dt.Rows.Add(
                    order.GetOrderId(),
                    order.GetOrderDate().ToString("dd/MM/yyyy HH:mm"),
                    order.GetOrderStatus(),
                    order.GetTotalAmount()
                );
            }

            dataGridViewAvailableOrders.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void dataGridViewAvailableOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderId = Convert.ToInt32(
                dataGridViewAvailableOrders.Rows[e.RowIndex].Cells["Order ID"].Value
            );

            int riderId = _riderService.GetRiderIdByUserId(_user.GetUserId());

            if (riderId <= 0)
            {
                MessageBox.Show("Rider record not found.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Accept Order {orderId}?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                bool result = _orderService.AssignRiderToOrder(orderId, riderId);

                MessageBox.Show(
                    result ? "Order accepted successfully!" : "Order already taken."
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int orderId))
            {
                MessageBox.Show("Invalid Order ID");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Mark this order as delivered?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                bool orderUpdated = _orderService.UpdateOrderStatus(orderId, "Delivered");

                if (orderUpdated)
                {
                    bool paymentUpdated = _paymentService.UpdatePaymentStatus(orderId, "Paid");

                    MessageBox.Show(
                        paymentUpdated
                        ? "Order delivered & payment completed!"
                        : "Order delivered, payment update failed!"
                    );

                    textBox1.Clear();
                    panel1.Visible = false;
                }
                else
                {
                    MessageBox.Show("Failed to update order.");
                }
            }
        }

        
    }
}
