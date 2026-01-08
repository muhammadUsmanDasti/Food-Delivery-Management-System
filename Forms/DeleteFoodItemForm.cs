using FoodDeliveryManagementSystem.FoodItemss;
using FoodDeliveryManagementSystem.Menus;
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
    public partial class DeleteFoodItemForm : Form
    {
        private User _user;
        private MenuService _menuService = new MenuService();
        private RestaurantService _restaurantService = new RestaurantService();

        public DeleteFoodItemForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void DeleteFoodItemForm_Load(object sender, EventArgs e)
        {
            LoadFoodItems();
        }
        private void LoadFoodItems()
        {
            int restaurantId =
                _restaurantService.GetRestaurantIdByUserId(_user.GetUserId());

            if (restaurantId <= 0)
            {
                MessageBox.Show("Restaurant not found.");
                return;
            }

            Menu menu = _menuService.GetMenuByRestaurantId(restaurantId);

            if (menu == null)
            {
                MessageBox.Show("Menu not found.");
                return;
            }

            List<FoodItems> items = _menuService.GetFoodItemsByMenuId(menu.GetMenuId());

            if (items == null || items.Count == 0)
            {
                MessageBox.Show("No food items to delete.");
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("FoodItemId", typeof(int));
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Available");

            foreach (var item in items)
            {
                dt.Rows.Add(
                    item.GetFoodItemId(),
                    item.GetName(),
                    item.GetPrice(),
                    item.GetAvailability() ? "Yes" : "No"
                );
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["FoodItemId"].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            int foodItemId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["FoodItemId"].Value
            );

            string itemName =
                dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{itemName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool success = _menuService.DeleteFoodItem(foodItemId);

                MessageBox.Show(success
                    ? "Food item deleted successfully!"
                    : "Failed to delete food item.");

                if (success)
                    LoadFoodItems(); // refresh grid
            }
        

        }
    }
}
