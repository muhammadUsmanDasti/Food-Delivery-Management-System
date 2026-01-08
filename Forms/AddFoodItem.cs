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
using System.Xml.Linq;

namespace foodDeliveryManagementSys.Forms
{
    public partial class AddFoodItem : Form
    {
        private User _user;

        public AddFoodItem(User user)
        {
            InitializeComponent();
            _user = user;
        }


        private void AddFoodItem_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            RestaurantService restaurantService = new RestaurantService();
            MenuService menuService = new MenuService();

            int restaurantId =
                restaurantService.GetRestaurantIdByUserId(_user.GetUserId());

            if (restaurantId <= 0)
            {
                MessageBox.Show("Restaurant record not found.");
                return;
            }

            Menu menu = menuService.GetMenuByRestaurantId(restaurantId);

            if (menu == null)
            {
                DialogResult res = MessageBox.Show(
                    "Menu not found. Create menu?",
                    "Create Menu",
                    MessageBoxButtons.YesNo
                );

                if (res == DialogResult.No) return;

                if (!menuService.CreateMenu(restaurantId))
                {
                    MessageBox.Show("Failed to create menu.");
                    return;
                }
                menu = menuService.GetMenuByRestaurantId(restaurantId);
            }

            string name = textBox1.Text.Trim();
            decimal price = numericUpDown1.Value;
            string description = textBox2.Text.Trim();
            bool available = checkBox1.Checked;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Food name is required.");
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            FoodItems item = new FoodItems();
            item.SetMenuId(menu.GetMenuId());
            item.SetName(name);
            item.SetPrice(price);
            item.SetDescription(description);
            item.SetAvailability(available);

            bool success = menuService.AddFoodItem(item);

            MessageBox.Show(success
                ? "Food item added successfully!"
                : "Failed to add food item.");
        

        }
    }
}
