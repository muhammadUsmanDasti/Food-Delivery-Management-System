using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Orders
{
    public class OrderItem

    {
        private int orderItemId;
        private int orderId;
        private int foodItemId;
        private int quantity;
        private decimal price;

        public void SetOrderItemId(int value)
        {
            this.orderItemId = value;
        }
        public int GetOrderItemId()
        {
            return this.orderItemId;
        }
        public void SetOrderId(int value)
        {
            this.orderId = value;
        }
        public int GetOrderId()
        {
            return this.orderId;
        }
        public void SetFoodItemId(int value)
        {
            this.foodItemId = value;
        }
        public int GetFoodItemId()
        {
            return this.foodItemId;
        }

        public void SetQuantity(int value)
        {
            this.quantity = value;
        }
        public int GetQuantity()
        {
            return this.quantity;
        }
        public void SetPrice(decimal value)
        {
            this.price = value;
        }
        public decimal GetPrice()
        {
            return this.price;
        }
        public OrderItem()
        {

        }
        public OrderItem(int orderId, int foodItemId, int quantity, decimal price)
        {
            this.orderId = orderId;
            this.foodItemId = foodItemId;
            this.quantity = quantity;
            this.price = price;
        }
        public OrderItem(int orderItemId, int orderId, int foodItemId, int quantity, decimal price)
        {
            this.orderItemId = orderItemId;
            this.orderId = orderId;
            this.foodItemId = foodItemId;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
