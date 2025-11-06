# Simple Factory Pattern - Pizza Store Example

## What is the Simple Factory Pattern?

The Simple Factory Pattern is a creational design pattern that provides a single place (a factory class) to create objects. Instead of creating objects directly using the `new` keyword scattered throughout your code, you ask a factory to create them for you.

Think of it like a real pizza restaurant kitchen:
- **Without Factory**: Every waiter makes pizzas themselves (messy and inconsistent)
- **With Factory**: All waiters ask the kitchen to make pizzas (organized and consistent)

## Key Components

### 1. **Product (Pizza)**
The base class or interface that defines what all products should have.
```
Pizza (abstract class)
??? Properties: Name
??? Methods: Prepare(), Bake(), Cut(), Box()
```

### 2. **Concrete Products**
Specific implementations of the product:
- `CheesePizza`
- `PepperoniPizza`
- `VeggiePizza`

### 3. **Factory (SimplePizzaFactory)**
The class responsible for creating products based on input.
- Has one main method: `CreatePizza(string type)`
- Contains the logic to decide which concrete product to create

### 4. **Client (PizzaStore)**
The class that uses the factory to get products.
- Doesn't know how pizzas are created
- Just asks the factory and uses what it gets

## How This Code Works

### Class Structure

![Diagram](./diagram.png)

### Program Flow Diagram

```
???????????????
?   Program   ?
?   (Main)    ?
???????????????
       ? 1. Creates factory and store
       ?
       ?
???????????????????
?  PizzaStore     ?
?                 ?
?  OrderPizza()   ?????? 2. Call OrderPizza("cheese")
???????????????????
         ? 3. Ask factory to create pizza
         ?
         ?
????????????????????????
? SimplePizzaFactory   ?
?                      ?
?  CreatePizza(type)   ?????? 4. Factory receives "cheese"
????????????????????????
           ? 5. Factory creates CheesePizza
           ?
           ?
    ????????????????
    ? CheesePizza  ?
    ?   object     ?
    ????????????????
           ? 6. Return pizza to store
           ?
???????????????????
?  PizzaStore     ?
?                 ?
?  - Prepare()    ?????? 7. Store prepares, bakes,
?  - Bake()       ?      cuts, and boxes the pizza
?  - Cut()        ?
?  - Box()        ?
???????????????????
```

### Step-by-Step Execution

When you run the program with `store.OrderPizza("cheese")`:

1. **Main creates objects**
   ```csharp
   SimplePizzaFactory factory = new SimplePizzaFactory();
   PizzaStore store = new PizzaStore(factory);
   ```

2. **Store receives order**
   ```csharp
   store.OrderPizza("cheese");
   ```

3. **Store asks factory to create pizza**
   ```csharp
   Pizza pizza = _factory.CreatePizza(type);
   ```

4. **Factory decides which pizza to create**
   ```csharp
   switch (type.ToLower())
   {
       case "cheese":
           pizza = new CheesePizza();  // Creates this one!
           break;
   }
   ```

5. **Store processes the pizza**
   ```csharp
   pizza.Prepare();  // "Preparing Cheese Pizza"
   pizza.Bake();     // "Baking for 25 minutes at 350"
   pizza.Cut();      // "Cutting the pizza into diagonal slices"
   pizza.Box();      // "Placing pizza in official PizzaStore box"
   ```

### Output Example

```
Preparing Cheese Pizza
Baking for 25 minutes at 350
Cutting the pizza into diagonal slices
Placing pizza in official PizzaStore box

Preparing Veggie Pizza
Baking for 25 minutes at 350
Cutting the pizza into diagonal slices
Placing pizza in official PizzaStore box

Preparing Pepperoni Pizza
Baking for 25 minutes at 350
Cutting the pizza into diagonal slices
Placing pizza in official PizzaStore box
```

## When Should You Use This Pattern?

### ? Use Simple Factory When:

1. **You have multiple similar objects to create**
   - Example: Different types of pizzas, cars, documents, or notifications

2. **Object creation logic is complex**
   - Creating an object requires multiple steps or decisions
   - You want to hide this complexity from the rest of your code

3. **You want to centralize object creation**
   - All creation logic is in one place
   - Easy to modify or add new types

4. **You want loose coupling**
   - Client code doesn't need to know about specific classes
   - Client only knows about the abstract type (Pizza)

### ? Don't Use Simple Factory When:

1. **You only have one type of object**
   - Unnecessary complexity for single objects

2. **Object creation is very simple**
   - If `new MyClass()` is enough, don't complicate it

3. **You need more flexibility**
   - Consider Factory Method or Abstract Factory patterns instead

## Why Use This Pattern?

### Benefits

1. **Single Responsibility**
   - Factory handles creation
   - Store handles business logic
   - Each class has one clear job

2. **Easy to Extend**
   - Want to add "Hawaiian Pizza"? Just:
     - Create `HawaiianPizza` class
     - Add one case in the factory switch
     - No changes needed in `PizzaStore`

3. **Loose Coupling**
   - `PizzaStore` doesn't depend on concrete pizza classes
   - It only knows about the `Pizza` abstract class

4. **Centralized Logic**
   - All object creation is in one place
   - Easy to maintain and debug

5. **Testing Made Easier**
   - You can mock the factory in tests
   - Test `PizzaStore` without creating real pizzas

### Real-World Example

Imagine a document editor application:

```csharp
// Without Factory - BAD
if (type == "pdf")
    doc = new PdfDocument();
else if (type == "word")
    doc = new WordDocument();
else if (type == "excel")
    doc = new ExcelDocument();
// This code is repeated everywhere!

// With Factory - GOOD
doc = documentFactory.CreateDocument(type);
// Clean and simple!
```

## How to Extend This Code

### Adding a New Pizza Type

1. **Create the new pizza class:**
   ```csharp
   public class HawaiianPizza : Pizza
   {
       public HawaiianPizza() => Name = "Hawaiian Pizza";
   }
   ```

2. **Update the factory:**
   ```csharp
   case "hawaiian":
       pizza = new HawaiianPizza();
       break;
   ```

3. **That's it!** No changes needed in `PizzaStore` or `Program`.

## Summary

The Simple Factory Pattern is like having a dedicated chef in a restaurant. Instead of everyone making their own food (creating objects everywhere), you have one expert (the factory) who knows how to make everything. This makes your code:

- **Cleaner**: Object creation in one place
- **Safer**: Less chance of errors
- **Flexible**: Easy to add new types
- **Maintainable**: Changes happen in one location

This pattern is perfect for beginners learning design patterns because it's simple to understand and immediately useful in real projects!