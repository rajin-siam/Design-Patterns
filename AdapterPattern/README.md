
# 🧩 Adapter Design Pattern Demo (C# / .NET)

## 🌟 Overview

This project shows how the **Adapter Design Pattern** works in C#.
The Adapter pattern helps **connect classes that don’t match** — it acts like a *bridge* between two different systems so they can work together.

---

## 📘 What Is the Adapter Pattern?

The Adapter pattern **converts one interface into another** that the client expects.
It lets two classes with **incompatible interfaces** work together smoothly.

**Think of it like a power adapter:**
It lets your laptop charger (one type of plug) work with a different power socket.

## Diagram of Adapter Pattern

![Adapter Pattern](./diagram.png)

---

## 💡 Example Scenario

Imagine a **Payment System** where:

* Your app uses a modern interface called `IPaymentProcessor`
* But you also need to connect **old payment systems** like Stripe and PayPal
* Their method names and formats are different
* So, we create **adapters** to make them “fit” with your app’s interface

---

## 🧱 UML Diagram (Simplified)

```
Client (PaymentService)
     ↓ uses
IPaymentProcessor (Target Interface)
     ↑
     ├── StripeAdapter  → uses → StripeService (Old System)
     └── PayPalAdapter  → uses → PayPalApi (Old System)
     └── uses RazorPay  (New System)
     
```

---

## 🧩 Class Diagram (Simplified)

```
IPaymentProcessor
+ ProcessPayment(amount, card)
+ RefundPayment(transactionId)

StripeAdapter               PayPalAdapter
- stripeService              - paypalApi
+ ProcessPayment()           + ProcessPayment()
+ RefundPayment()            + RefundPayment()

StripeService                PayPalApi
+ Charge()                   + SendMoney()
+ Cancel()                   + Void()
```

---

## 🗂️ Project Structure

```
AdapterPatternDemo/
├── Program.cs
├── Interfaces/
│   └── IPaymentProcessor.cs
├── LegacySystems/
│   ├── StripeService.cs
│   └── PayPalApi.cs
├── Adapters/
│   ├── StripeAdapter.cs
│   └── PayPalAdapter.cs
└── Services/
    └── PaymentService.cs
```

---

## 🧠 Key Parts Explained

| Component                         | Description                                                                                |
| --------------------------------- | ------------------------------------------------------------------------------------------ |
| **IPaymentProcessor**             | The interface your app expects to use                                                      |
| **StripeService / PayPalApi**     | Old systems with different methods                                                         |
| **StripeAdapter / PayPalAdapter** | Middle layers that translate between your interface and the old ones                       |
| **PaymentService**                | The client that uses `IPaymentProcessor` — it doesn’t care about the actual payment system |

---

## ▶️ How to Run It

1. Install **.NET 6 or higher**
2. Open a terminal and run:

```bash
cd AdapterPattern
dotnet run
```

---

## 🧾 Example Output

```
=== Payment Processing System ===

Processing payment with Stripe...
[Stripe] Charging $150.00 to card ending in 1234
Payment processed successfully!

Processing refund with Stripe...
[Stripe] Canceling transaction...
Refund processed successfully!

---

Processing payment with PayPal...
[PayPal] Sending $200.00 from card ending in 5678
Payment processed successfully!

Processing refund with PayPal...
[PayPal] Voiding payment...
Refund processed successfully!
```

---

## ✅ Why Use the Adapter Pattern?

1. **Clean separation** – keeps conversion logic out of main code
2. **Easily extendable** – add new gateways without changing old code
3. **Compatible** – lets different systems work together
4. **Reusable** – adapters can be used across projects

---

## 🌍 Real-World Examples

* Payment gateways (Stripe, PayPal, Razorpay, etc.)
* Database drivers (ADO.NET adapters)
* API integrations with different formats
* Legacy software modernization

---

## 🔗 Related Patterns

| Pattern       | Difference                                              |
| ------------- | ------------------------------------------------------- |
| **Bridge**    | Separates abstraction from implementation               |
| **Decorator** | Adds new behavior instead of changing interfaces        |
| **Facade**    | Simplifies complex subsystems; doesn’t adapt interfaces |

---
