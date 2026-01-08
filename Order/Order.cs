using FoodDeliveryManagementSystem.FoodItemss;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Orders
{
    public class Order
    {
        private int orderId;
        private int customerId;
        private int restaurantId;
        private int riderId;
        private DateTime orderDate;
        private string deliveryAddress;
        private decimal totalAmount;
        private string orderStatus;


        private List<OrderItem> orderItems;
        public Order()
        {
            orderItems = new List<OrderItem>();
        }
        public Order(int customerId, int restaurantId, int riderId, DateTime orderDate, string deliveryAddress, decimal totalAmount, string orderStatus)
        {
            this.customerId = customerId;
            this.restaurantId = restaurantId;
            this.riderId = riderId;
            this.orderDate = orderDate;
            this.deliveryAddress = deliveryAddress;
            this.totalAmount = totalAmount;
            this.orderStatus = orderStatus;
            orderItems = new List<OrderItem>();
        }

        public Order(int orderId, int customerId, int restaurantId, int riderId, DateTime orderDate, string deliveryAddress, decimal totalAmount, string orderStatus)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.restaurantId = restaurantId;
            this.riderId = riderId;
            this.orderDate = orderDate;
            this.deliveryAddress = deliveryAddress;
            this.totalAmount = totalAmount;
            this.orderStatus = orderStatus;

            orderItems = new List<OrderItem>();
        }



        public int GetOrderId()
        {
            return this.orderId;
        }
        public void SetOrderId(int value)
        {
            orderId = value;
        }
        public int GetCustomerId()
        {
            return this.customerId;
        }
        public void SetCustomerId(int value)
        {
            customerId = value;
        }
        public int GetRestaurantId()
        {
            return this.restaurantId;
        }
        public void SetRestaurantId(int value)
        {
            restaurantId = value;
        }
        public int GetRiderId()
        {
            return this.riderId;
        }
        public void SetRiderId(int value)
        {
            this.riderId = value;
        }
        public DateTime GetOrderDate()
        {
            return this.orderDate;
        }
        public void SetOrderDate(DateTime value)
        {
            this.orderDate = value;
        }
        public string GetDeliveryAddress()
        {
            return this.deliveryAddress;
        }
        public void SetDeliveryAddress(string value)
        {
            deliveryAddress = value;
        }
        public decimal GetTotalAmount()
        {
            return this.totalAmount;
        }
        public void SetTotalAmount(decimal value)
        {
            this.totalAmount = value;
        }
        public string GetOrderStatus()
        {
            return this.orderStatus;
        }
        public void SetOrderStatus(string value)
        {
            this.orderStatus = value;
        }



        public List<OrderItem> GetOrderItems()
        {
            return this.orderItems;
        }
        public void AddOrderItem(OrderItem item)
        {
            orderItems.Add(item);
        }

        public void RemoveOrderItem(OrderItem item)
        {
            orderItems.Remove(item);
        }

        public enum OrderStatus { Pending, Accepted, OnTheWay, Delivered }


    }

}

