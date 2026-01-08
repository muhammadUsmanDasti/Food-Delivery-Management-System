using FoodDeliveryManagementSystem.FoodItemss;
using FoodDeliveryManagementSystem.Menus;
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
    public partial class RestaurantMenuForm : Form
    {

        private int _restaurantId;
        private MenuService _menuService;
        public RestaurantMenuForm(int restaurantId)
        {
            InitializeComponent();
            _restaurantId = restaurantId;
            _menuService = new MenuService();
        }

        private void RestaurantMenuForm_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            try
            {
                
                Menu menu = _menuService.GetMenuByRestaurantId(_restaurantId);

                if (menu == null)
                {
                    MessageBox.Show("Menu not found for this restaurant.");
                    return;
                }

                List<FoodItems> foodItems = _menuService.GetFoodItemsByMenuId(menu.GetMenuId());

                if (foodItems == null || foodItems.Count == 0)
                {
                    MessageBox.Show("No food items available.");
                    return;
                }

                // Create DataTable to bind to DataGridView
                DataTable dt = new DataTable();
                dt.Columns.Add("Item ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("Availability", typeof(string));

                foreach (var item in foodItems)
                {
                    dt.Rows.Add(
                        item.GetFoodItemId(),
                        item.GetName(),
                        item.GetPrice(),
                        item.GetAvailability() ? "Available" : "Not Available"
                    );
                }

                
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu: " + ex.Message);
            }
        }
    }
}
