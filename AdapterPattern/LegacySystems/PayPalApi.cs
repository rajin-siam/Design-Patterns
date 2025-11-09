using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LegacySystems
{
    /// <summary>
    /// Legacy PayPal service with different incompatible interface (Adaptee)
    /// </summary>
    public class PayPalApi
    {
        public string SendMoney(string sourceCard, decimal totalAmount)
        {
            Console.WriteLine($"[PayPal] Sending ${totalAmount:F2} from card ending in {sourceCard}");
            string paymentId = $"paypal_pmt_{Guid.NewGuid().ToString().Substring(0, 8)}";
            Console.WriteLine($"[PayPal] Payment ID: {paymentId}");
            return paymentId;
        }

        public bool VoidTransaction(string paymentId)
        {
            Console.WriteLine($"[PayPal] Voiding payment: {paymentId}");
            Console.WriteLine("[PayPal] Refund issued");
            return true;
        }
    }
}
