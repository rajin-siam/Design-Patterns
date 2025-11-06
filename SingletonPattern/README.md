# Singleton Pattern - A Simple Guide

## What is Singleton Pattern?

Imagine you have a chocolate factory with only ONE chocolate boiler. You don't want two boilers running at the same time because:
- It wastes resources
- It could cause confusion (which boiler has the chocolate?)
- It could cause disasters (mixing batches, overflows, etc.)

**Singleton Pattern makes sure your program creates only ONE instance of a class, and everyone uses that same instance.**

## Real-World Examples

- **Printer Spooler**: You have one print queue manager, not multiple
- **Database Connection Pool**: One manager controls all database connections
- **Configuration Manager**: One place to store app settings
- **Logger**: One log file manager for the entire application

## The Chocolate Boiler Problem (from Head First Design Patterns)

Let's say you're building software for a chocolate factory. The chocolate boiler:
1. Fills with milk and chocolate
2. Boils the mixture
3. Drains it to make chocolate bars

**Problem**: If you accidentally create two ChocolateBoiler objects, you could:
- Fill an already full boiler (overflow!)
- Drain an empty boiler (waste!)
- Boil already boiled mixture (burn it!)

**Solution**: Use Singleton to ensure only ONE boiler exists!

---

## Basic Singleton in C#

### Step 1: The Problem (Without Singleton)

```csharp
// BAD: Anyone can create multiple instances
public class ChocolateBoiler
{
    private bool empty;
    private bool boiled;
    
    public ChocolateBoiler()
    {
        empty = true;
        boiled = false;
    }
}

// Problem: Multiple boilers can be created!
var boiler1 = new ChocolateBoiler(); // Creates first boiler
var boiler2 = new ChocolateBoiler(); // Creates ANOTHER boiler - BAD!
```

### Step 2: Simple Singleton Solution

```csharp
public class ChocolateBoiler
{
    // Step 1: Create a private static variable to hold the ONE instance
    private static ChocolateBoiler _instance;
    
    private bool _empty;
    private bool _boiled;
    
    // Step 2: Make constructor PRIVATE so no one else can create instances
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
        Console.WriteLine("Creating the one and only ChocolateBoiler!");
    }
    
    // Step 3: Provide a public static method to get the instance
    public static ChocolateBoiler Instance
    {
        get
        {
            // Create instance only if it doesn't exist yet (Lazy Creation)
            if (_instance == null)
            {
                _instance = new ChocolateBoiler();
            }
            return _instance;
        }
    }
    
    public void Fill()
    {
        if (_empty)
        {
            _empty = false;
            _boiled = false;
            Console.WriteLine("Filling the boiler with milk and chocolate");
        }
        else
        {
            Console.WriteLine("Boiler is already full!");
        }
    }
    
    public void Boil()
    {
        if (!_empty && !_boiled)
        {
            Console.WriteLine("Bringing the contents to a boil");
            _boiled = true;
        }
        else
        {
            Console.WriteLine("Can't boil - either empty or already boiled!");
        }
    }
    
    public void Drain()
    {
        if (!_empty && _boiled)
        {
            Console.WriteLine("Draining the boiled milk and chocolate");
            _empty = true;
        }
        else
        {
            Console.WriteLine("Can't drain - not ready yet!");
        }
    }
}

// Usage
class Program
{
    static void Main()
    {
        // Can't do this anymore: new ChocolateBoiler() - constructor is private!
        
        // Get the one and only instance
        ChocolateBoiler boiler = ChocolateBoiler.Instance;
        boiler.Fill();
        boiler.Boil();
        boiler.Drain();
        
        // Try to get another "instance"
        ChocolateBoiler anotherBoiler = ChocolateBoiler.Instance;
        
        // Proof they're the same object
        Console.WriteLine($"Same boiler? {ReferenceEquals(boiler, anotherBoiler)}"); // True!
    }
}
```

**Output:**
```
Creating the one and only ChocolateBoiler!
Filling the boiler with milk and chocolate
Bringing the contents to a boil
Draining the boiled milk and chocolate
Same boiler? True
```

---

## Understanding the Three Key Parts

### 1. Private Static Variable
```csharp
private static ChocolateBoiler _instance;
```
- **static** means it belongs to the CLASS, not to individual objects
- Think of it as a "class-level storage box" that holds the one instance
- **private** means only this class can access it

### 2. Private Constructor
```csharp
private ChocolateBoiler() { }
```
- **private** means no one outside this class can call `new ChocolateBoiler()`
- This prevents multiple instances from being created
- Only the class itself can create its instance

### 3. Public Static Property/Method
```csharp
public static ChocolateBoiler Instance { get { ... } }
```
- **static** means you can call it without creating an object first
- **public** means anyone can access it
- This is the "front door" - the only way to get the instance

---

## The Multithreading Problem

The simple singleton has a BIG problem in modern applications with multiple threads (tasks running at the same time).

**Scenario:**
```
Time    Thread 1                           Thread 2
----    ---------------------------------  ---------------------------------
1       if (_instance == null)            
2       // _instance is null, so enter    if (_instance == null)
3       // About to create instance...    // _instance is STILL null!
4       _instance = new ChocolateBoiler() _instance = new ChocolateBoiler()
```

**Result:** Two boilers get created! Disaster! 🔥

---

## Thread-Safe Solutions in C#

### Solution 1: Eager Initialization (Simplest & Safest)

```csharp
public class ChocolateBoiler
{
    // Create the instance immediately when class is loaded
    // C# guarantees this is thread-safe!
    private static readonly ChocolateBoiler _instance = new ChocolateBoiler();
    
    private bool _empty;
    private bool _boiled;
    
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
    }
    
    public static ChocolateBoiler Instance
    {
        get { return _instance; }
    }
    
    // Other methods...
}
```

**Pros:**
- Super simple
- Thread-safe automatically
- No performance overhead

**Cons:**
- Instance is created even if you never use it
- Can't pass parameters to constructor

---

### Solution 2: Lazy with Lock (Most Common)

```csharp
public class ChocolateBoiler
{
    private static ChocolateBoiler _instance;
    private static readonly object _lock = new object();
    
    private bool _empty;
    private bool _boiled;
    
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
    }
    
    public static ChocolateBoiler Instance
    {
        get
        {
            // Only one thread can enter this block at a time
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ChocolateBoiler();
                }
                return _instance;
            }
        }
    }
    
    // Other methods...
}
```

**How `lock` works:**
- Think of it as a bathroom door
- Only one person (thread) can be inside at a time
- Others have to wait outside until it's free
- Prevents two threads from creating instances simultaneously

**Pros:**
- Thread-safe
- Lazy initialization (creates only when needed)

**Cons:**
- Lock overhead on EVERY access (even after instance is created)

---

### Solution 3: Double-Checked Locking (Best Performance)

```csharp
public class ChocolateBoiler
{
    private static ChocolateBoiler _instance;
    private static readonly object _lock = new object();
    
    private bool _empty;
    private bool _boiled;
    
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
    }
    
    public static ChocolateBoiler Instance
    {
        get
        {
            // First check (no lock) - fast!
            if (_instance == null)
            {
                // Only lock if we might need to create
                lock (_lock)
                {
                    // Second check (with lock) - safe!
                    if (_instance == null)
                    {
                        _instance = new ChocolateBoiler();
                    }
                }
            }
            return _instance;
        }
    }
    
    // Other methods...
}
```

**Why two checks?**
1. **First check (outside lock):** Fast! If instance exists, return it immediately
2. **Second check (inside lock):** Safe! Make sure no one created it while we were waiting for the lock

**Pros:**
- Best performance
- Thread-safe
- Lazy initialization

**Cons:**
- More complex code

---

### Solution 4: C# Lazy<T> (Modern & Recommended)

```csharp
public class ChocolateBoiler
{
    // Lazy<T> handles all the thread-safety for you!
    private static readonly Lazy<ChocolateBoiler> _instance = 
        new Lazy<ChocolateBoiler>(() => new ChocolateBoiler());
    
    private bool _empty;
    private bool _boiled;
    
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
    }
    
    public static ChocolateBoiler Instance
    {
        get { return _instance.Value; }
    }
    
    public void Fill()
    {
        if (_empty)
        {
            _empty = false;
            _boiled = false;
            Console.WriteLine("Filling the boiler");
        }
    }
    
    public void Boil()
    {
        if (!_empty && !_boiled)
        {
            Console.WriteLine("Boiling the contents");
            _boiled = true;
        }
    }
    
    public void Drain()
    {
        if (!_empty && _boiled)
        {
            Console.WriteLine("Draining the boiler");
            _empty = true;
        }
    }
}
```

**This is the BEST way in modern C#!**
- Thread-safe automatically
- Lazy initialization
- Simple code
- Built into .NET

---

## Complete Example: Chocolate Factory

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

public class ChocolateBoiler
{
    private static readonly Lazy<ChocolateBoiler> _instance = 
        new Lazy<ChocolateBoiler>(() => new ChocolateBoiler());
    
    private bool _empty;
    private bool _boiled;
    private int _batchNumber;
    
    private ChocolateBoiler()
    {
        _empty = true;
        _boiled = false;
        _batchNumber = 0;
        Console.WriteLine("🍫 Chocolate Boiler initialized!");
    }
    
    public static ChocolateBoiler Instance => _instance.Value;
    
    public void Fill()
    {
        if (_empty)
        {
            _empty = false;
            _boiled = false;
            _batchNumber++;
            Console.WriteLine($"✅ Filling boiler with batch #{_batchNumber}");
            Thread.Sleep(1000); // Simulate filling time
        }
        else
        {
            Console.WriteLine("❌ Can't fill - boiler is already full!");
        }
    }
    
    public void Boil()
    {
        if (!_empty && !_boiled)
        {
            Console.WriteLine($"🔥 Boiling batch #{_batchNumber}...");
            Thread.Sleep(2000); // Simulate boiling time
            _boiled = true;
            Console.WriteLine($"✅ Batch #{_batchNumber} boiled!");
        }
        else
        {
            Console.WriteLine("❌ Can't boil - wrong state!");
        }
    }
    
    public void Drain()
    {
        if (!_empty && _boiled)
        {
            Console.WriteLine($"✅ Draining batch #{_batchNumber}");
            Thread.Sleep(1000); // Simulate draining time
            _empty = true;
            Console.WriteLine($"🎉 Batch #{_batchNumber} complete!");
        }
        else
        {
            Console.WriteLine("❌ Can't drain - not ready!");
        }
    }
    
    public int GetBatchNumber() => _batchNumber;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Chocolate Factory Starting ===\n");
        
        // Simulate multiple workers trying to use the boiler
        Task worker1 = Task.Run(() =>
        {
            var boiler = ChocolateBoiler.Instance;
            Console.WriteLine($"Worker 1 got boiler (hash: {boiler.GetHashCode()})");
            boiler.Fill();
        });
        
        Task worker2 = Task.Run(() =>
        {
            var boiler = ChocolateBoiler.Instance;
            Console.WriteLine($"Worker 2 got boiler (hash: {boiler.GetHashCode()})");
            Thread.Sleep(500);
        });
        
        Task.WaitAll(worker1, worker2);
        
        // Continue with production
        var mainBoiler = ChocolateBoiler.Instance;
        Console.WriteLine($"\nMain got boiler (hash: {mainBoiler.GetHashCode()})");
        mainBoiler.Boil();
        mainBoiler.Drain();
        
        // Next batch
        Console.WriteLine("\n=== Starting new batch ===");
        mainBoiler.Fill();
        mainBoiler.Boil();
        mainBoiler.Drain();
        
        Console.WriteLine($"\n🏆 Total batches produced: {mainBoiler.GetBatchNumber()}");
        Console.WriteLine("\nAll workers used the SAME boiler instance!");
    }
}
```

---

## Quick Comparison Table

| Solution | Thread-Safe? | Lazy? | Performance | Complexity | Recommended? |
|----------|-------------|-------|-------------|------------|--------------|
| **Simple** | ❌ No | ✅ Yes | ⭐⭐⭐⭐⭐ | ⭐ Simple | ❌ No (not safe) |
| **Eager** | ✅ Yes | ❌ No | ⭐⭐⭐⭐⭐ | ⭐ Simple | ✅ Yes (if always needed) |
| **Lock** | ✅ Yes | ✅ Yes | ⭐⭐ Slow | ⭐⭐ Medium | ⚠️ OK (but not best) |
| **Double-Check** | ✅ Yes | ✅ Yes | ⭐⭐⭐⭐ Fast | ⭐⭐⭐⭐ Complex | ⚠️ OK (harder to maintain) |
| **Lazy<T>** | ✅ Yes | ✅ Yes | ⭐⭐⭐⭐ Fast | ⭐⭐ Simple | ✅ YES! (best choice) |

---

## When to Use Singleton

✅ **Good Uses:**
- **Logger**: One log file manager for the whole app
- **Configuration Manager**: One place for settings
- **Connection Pool**: One manager for database connections
- **Cache**: One shared cache for the application
- **Device Manager**: One manager for hardware access

❌ **Bad Uses (Avoid):**
- When you just want a "global variable" (use dependency injection instead)
- When you need multiple instances in tests
- When the class has mutable state that multiple parts of your app change
- "Just because" - don't make everything a singleton!

---

## Common Mistakes to Avoid

### 1. Forgetting Thread Safety
```csharp
// BAD - Not thread-safe!
if (_instance == null)
    _instance = new ChocolateBoiler();
```

### 2. Making Constructor Public
```csharp
// BAD - Anyone can create instances!
public ChocolateBoiler() { }
```

### 3. Not Using `static`
```csharp
// BAD - Each object would have its own instance variable!
private ChocolateBoiler _instance;
```

### 4. Overusing Singleton
```csharp
// BAD - Not everything should be a singleton!
public class UserSingleton { } // Users should have multiple instances!
```

---

## Key Takeaways

1. **Singleton = Only ONE instance** of a class in the entire application
2. **Three parts**: Private static variable, private constructor, public static accessor
3. **Thread safety matters** in modern applications - use `Lazy<T>` in C#
4. **Use when needed**, don't overuse
5. The **Chocolate Boiler** example shows why: you don't want two boilers running at once!

---

## Further Reading

- Head First Design Patterns (Chapter 5)
- Microsoft Docs: Implementing Singleton in C#
- Singleton Pattern on Refactoring Guru

Happy coding! 🍫☕