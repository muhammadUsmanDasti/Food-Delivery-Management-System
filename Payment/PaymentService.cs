using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryManagementSystem.Payments
{

    public class PaymentService
    {
        private readonly PaymentRepo paymentRepo;

        public PaymentService()
        {
            paymentRepo = new PaymentRepo();
        }

        public bool CreatePayment(Payment payment)
        {

            bool result = paymentRepo.InsertPayment(payment);
            return result;


        }

        public bool UpdatePaymentStatus(int orderId, string newStatus)
        {

            bool result = paymentRepo.UpdatePaymentStatus(orderId, newStatus);
            return result;
        }

        public Payment GetPaymentByOrderId(int orderId)
        {

            Payment payment = paymentRepo.GetPaymentByOrderId(orderId);
            return payment;

        }
    }

}
