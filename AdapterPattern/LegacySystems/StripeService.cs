using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LegacySystems
{
    /// <summary>
    /// Legacy Stripe service with incompatible interface (Adaptee)
    /// </summary>
    public class StripeService
    {
        public string Charge(double amountInDollars, string cardDetails)
        {
            Console.WriteLine($"[Stripe] Charging ${amountInDollars:F2} to card ending in {cardDetails}");
            string transactionId = $"stripe_tx_{Guid.NewGuid().ToString().Substring(0, 8)}";
            Console.WriteLine($"[Stripe] Transaction ID: {transactionId}");
            return transactionId;
        }

        public void CancelCharge(string chargeId)
        {
            Console.WriteLine($"[Stripe] Canceling transaction: {chargeId}");
            Console.WriteLine("[Stripe] Refund completed");
        }
    }
}
