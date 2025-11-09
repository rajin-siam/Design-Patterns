using AdapterPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.ModernPaymentSystem
{
    public class Razorpay : IPaymentProcessor
    {
        public string ProcessPayment(decimal amount, string cardNumber)
        {
            Console.WriteLine($"[Razorpay] Processing payment of ₹{amount:F2} using card ending in {cardNumber}");
            string transactionId = $"razorpay_tx_{Guid.NewGuid().ToString().Substring(0, 8)}";
            Console.WriteLine($"[Razorpay] Transaction ID: {transactionId}");
            return transactionId;
        }
        public bool RefundPayment(string transactionId)
        {
            Console.WriteLine($"[Razorpay] Refunding transaction: {transactionId}");
            Console.WriteLine("[Razorpay] Refund completed");
            return true;
        }
    }
}
