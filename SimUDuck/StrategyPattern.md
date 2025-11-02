
# ?? Strategy Pattern – SimUDuck

## ?? Overview

This project demonstrates the **Strategy Pattern**, a **behavioral design pattern** that defines a family of algorithms, encapsulates each one, and makes them interchangeable.
It allows the algorithm to **vary independently from clients** that use it.

---

## ??? Pattern Structure

### **Key Components**

1. **Context (Duck)** – Abstract base class that uses behavior interfaces.
2. **Strategy Interfaces** – Define contracts for interchangeable behaviors:

   * `FlyBehavior` – Defines flying algorithms
   * `QuackBehavior` – Defines quacking algorithms
3. **Concrete Strategies** – Implement specific behaviors:

   * **Fly behaviors:** `FlyWithWings`, `FlyNoWay`, `FlyRocketPowered`
   * **Quack behaviors:** `Quack`, `Squeak`, `MuteQuack`
4. **Concrete Ducks** – Different duck types with specific behavior combinations

---

## ?? Class Diagram (Text Representation)

```
Duck (Abstract)
??? FlyBehavior (interface)
??? QuackBehavior (interface)
??? Methods: display(), performFly(), performQuack(), swim()

Concrete Ducks:
??? MallardDuck (FlyWithWings + Quack)
??? RedheadDuck (FlyWithWings + Quack)
??? RubberDuck (FlyNoWay + Squeak)
??? DecoyDuck (FlyNoWay + MuteQuack)
??? ModelDuck (FlyNoWay + Quack)
```

---

## ?? Benefits

* **Flexibility** – Behaviors can be changed at runtime.
* **Code Reuse** – Behaviors are encapsulated and reusable.
* **Open/Closed Principle** – Easy to add new behaviors without modifying existing code.
* **Composition over Inheritance** – Uses *“has-a”* instead of *“is-a”* relationships.

---

## ?? Design Principles Applied

1. **Encapsulate what varies** – Fly and quack behaviors are separated from Duck classes.
2. **Program to an interface, not an implementation** – Ducks depend on behavior interfaces.
3. **Favor composition over inheritance** – Behaviors are composed, not inherited.

---

## ?? Project Structure

```
SimUDuck/
??? Ducks/
?   ??? Duck.cs (Abstract base)
?   ??? MallardDuck.cs
?   ??? RedheadDuck.cs
?   ??? RubberDuck.cs
?   ??? DecoyDuck.cs
?   ??? ModelDuck.cs
??? Behaviors/
?   ??? FlyBehavior.cs (Interface)
?   ??? FlyWithWings.cs
?   ??? FlyNoWay.cs
?   ??? FlyRocketPowered.cs
?   ??? QuackBehavior.cs (Interface)
?   ??? Quack.cs
?   ??? Squeak.cs
?   ??? MuteQuack.cs
??? Program.cs
```

---

## ?? When to Use Strategy Pattern

* When you have **multiple related classes** that differ only in behavior.
* When you need **different variants of an algorithm**.
* When you want to **avoid exposing complex, algorithm-specific data**.
* When a class has **many behaviors expressed via conditionals** (e.g., `if` or `switch`).


