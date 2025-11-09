using AdapterPattern;
using AdapterPattern.Adapters;
using AdapterPattern.ModernPaymentSystem;
using AdapterPattern.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Payment Processing System ===\n");

        // Scenario 1: Using Stripe through adapter
        Console.WriteLine("Processing payment with Stripe...");
        var stripeAdapter = new StripeAdapter();
        var stripePaymentService = new PaymentService(stripeAdapter);
        stripePaymentService.MakePayment(150.00m, "4111111111111234");

        Console.WriteLine("Processing refund with Stripe...");
        stripePaymentService.ProcessRefund("stripe_tx_abc123");

        Console.WriteLine("---\n");

        // Scenario 2: Using PayPal through adapter
        Console.WriteLine("Processing payment with PayPal...");
        var paypalAdapter = new PayPalAdapter();
        var paypalPaymentService = new PaymentService(paypalAdapter);
        paypalPaymentService.MakePayment(200.00m, "5555555555555678");

        Console.WriteLine("Processing refund with PayPal...");
        paypalPaymentService.ProcessRefund("paypal_pmt_xyz789");
        Console.WriteLine("---\n");


        // Scenario 3: Using Razorpay directly (no adapter needed)
        Console.WriteLine("Processing payment with Razorpay...");
        var razorpayProcessor = new Razorpay();
        var razorpayPaymentService = new PaymentService(razorpayProcessor);
        razorpayPaymentService.MakePayment(3000.00m, "9999888877776666");
        Console.WriteLine("Processing refund with Razorpay...");
        razorpayPaymentService.ProcessRefund("razorpay_tx_def456");


        // Demonstration of polymorphism - same interface, different implementations
        Console.WriteLine("---\n");
        Console.WriteLine("=== Demonstrating Polymorphism ===\n");

        DemoPolymorphism(stripeAdapter, "Stripe");
        DemoPolymorphism(paypalAdapter, "PayPal");
        DemoPolymorphism(razorpayProcessor, "Razorpay");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Demonstrates that we can use any IPaymentProcessor implementation
    /// without knowing the underlying details
    /// </summary>
    static void DemoPolymorphism(AdapterPattern.Interfaces.IPaymentProcessor processor, string processorName)
    {
        Console.WriteLine($"Using {processorName} processor through interface:");
        var service = new PaymentService(processor);
        service.MakePayment(99.99m, "9999888877776666");
    }
}