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
    /// Adapter that makes PayPalApi compatible with IPaymentProcessor
    /// </summary>
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalApi _paypalApi;

        public PayPalAdapter()
        {
            _paypalApi = new PayPalApi();
        }

        public string ProcessPayment(decimal amount, string cardNumber)
        {
            // Extract last 4 digits for PayPal
            string last4Digits = cardNumber.Length >= 4
                ? cardNumber.Substring(cardNumber.Length - 4)
                : cardNumber;

            // Adapt the interface: our method calls PayPal's SendMoney method
            return _paypalApi.SendMoney(last4Digits, amount);
        }

        public bool RefundPayment(string transactionId)
        {
            // Adapt the interface: our method calls PayPal's VoidTransaction method
            return _paypalApi.VoidTransaction(transactionId);
        }
    }
}
