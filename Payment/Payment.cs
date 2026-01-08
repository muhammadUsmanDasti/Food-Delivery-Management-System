using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Payments
{
    public class Payment
    {
        private int paymentId;
        private int orderId;
        private decimal amount;
        private string paymentStatus;
        private string paymentMethod;

        public int GetPaymentId()
        {
            return this.paymentId;
        }
        public void SetPaymentId(int value)
        {
            this.paymentId = value;
        }

        public int GetOrderId()
        {
            return this.orderId;
        }
        public void SetOrderId(int value)
        {
            this.orderId = value;
        }
        public decimal GetAmount()
        {
            return this.amount;
        }
        public void SetAmount(decimal value)
        {
            this.amount = value;
        }
        public string GetPaymentStatus()
        {
            return this.paymentStatus;
        }
        public void SetPaymentStatus(string value)
        {
            this.paymentStatus = value;
        }
        public string GetPaymentMethod()
        {
            return this.paymentMethod;
        }
        public void SetPaymentMethod(string value)
        {
            this.paymentMethod = value;
        }
        public Payment() { }

        public Payment(int orderId, decimal amount, string paymentStatus, string paymentMethod)
        {
            this.orderId = orderId;
            this.amount = amount;
            this.paymentStatus = paymentStatus;
            this.paymentMethod = paymentMethod;
        }
        public Payment(int paymentId, int orderId, decimal amount, string paymentStatus, string paymentMethod)
        {
            this.paymentId = paymentId;
            this.orderId = orderId;
            this.amount = amount;
            this.paymentStatus = paymentStatus;
            this.paymentMethod = paymentMethod;
        }

        public enum PaymentMethod { Cash, Card }
    }
}
