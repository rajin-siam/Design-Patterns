using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Interfaces
{
    /// <summary>
    /// Target interface that our application expects
    /// </summary>
    public interface IPaymentProcessor
    {
        string ProcessPayment(decimal amount, string cardNumber);
        bool RefundPayment(string transactionId);
    }
}
