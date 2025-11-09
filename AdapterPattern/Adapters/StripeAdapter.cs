using AdapterPattern.Interfaces;
using AdapterPattern.LegacySystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adapters
{
    /// <summary>
    /// Adapter that makes StripeService compatible with IPaymentProcessor
    /// </summary>
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeService _stripeService;

        public StripeAdapter()
        {
            _stripeService = new StripeService();
        }

        public string ProcessPayment(decimal amount, string cardNumber)
        {
            // Convert decimal to double and extract last 4 digits
            double amountInDollars = (double)amount;
            string last4Digits = cardNumber.Length >= 4
                ? cardNumber.Substring(cardNumber.Length - 4)
                : cardNumber;

            // Adapt the interface: our method calls Stripe's Charge method
            return _stripeService.Charge(amountInDollars, last4Digits);
        }

        public bool RefundPayment(string transactionId)
        {
            // Adapt the interface: our method calls Stripe's CancelCharge method
            _stripeService.CancelCharge(transactionId);
            return true;
        }
    }
}
