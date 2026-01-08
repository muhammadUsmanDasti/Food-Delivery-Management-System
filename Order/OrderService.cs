using FoodDeliveryManagementSystem.Payments;
using FoodDeliveryManagementSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Orders
{
    internal class OrderService
    {
        private readonly OrderRepo orderRepo;

        public OrderService()
        {
            orderRepo = new OrderRepo();
        }

        public List<Order> ViewOrdersByCustomerId(int customerId)
        {
            return orderRepo.GetOrdersByCustomerId(customerId);
        }



        public bool PlaceOrder(Order order, List<OrderItem> orderItems, string paymentMethod)
        {
            try
            {
                bool result = orderRepo.PlaceOrderWithPayment(order, orderItems, paymentMethod);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service Error: {ex.Message}");
                return false;
            }
        }



        public List<Order> GetAvailableOrders()
        {

            List<Order> orders = orderRepo.LoadAvailableOrders();

            if (orders != null && orders.Count > 0)
            {
                return orders;
            }
            else
            {
                return new List<Order>();
            }

        }
        public bool AssignRiderToOrder(int orderId, int riderId)
        {
            bool result = orderRepo.AssignRiderToOrder(orderId, riderId);

            return result;
        }


        public List<Order> GetOrdersByRiderId(int riderId)
        {

            List<Order> orders = orderRepo.LoadOrdersByRiderId(riderId);

            if (orders != null && orders.Count > 0)
            {
                return orders;
            }
            else
            {
                return new List<Order>();
            }

        }


        public bool UpdateOrderStatus(int orderId, string newStatus)
        {

            bool result = orderRepo.UpdateOrderStatus(orderId, newStatus);
            return result;
        }

        public List<Order> GetOrdersByRestaurantId(int restaurantId)
        {

            List<Order> orders = orderRepo.LoadOrdersByRestaurantId(restaurantId);

            if (orders != null && orders.Count > 0)
            {
                return orders;
            }
            else
            {
                return new List<Order>();
            }

        }
    }
}
