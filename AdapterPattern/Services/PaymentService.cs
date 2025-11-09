using AdapterPattern.Interfaces;


namespace AdapterPattern.Services
{
    /// <summary>
    /// Client service that uses IPaymentProcessor interface
    /// It doesn't know about the legacy systems, only the interface
    /// </summary>
    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void MakePayment(decimal amount, string cardNumber)
        {
            string transactionId = _paymentProcessor.ProcessPayment(amount, cardNumber);
            Console.WriteLine("Payment processed successfully!\n");
        }

        public void ProcessRefund(string transactionId)
        {
            bool success = _paymentProcessor.RefundPayment(transactionId);
            if (success)
            {
                Console.WriteLine("Refund processed successfully!\n");
            }
        }
    }
}
