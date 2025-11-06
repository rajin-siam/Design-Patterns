using FactoryMethod.Factory;
using FactoryMethod.Pizzas;


namespace FactoryMethod.Store
{
    public abstract class PizzaStore
    {
        // The Factory Method - subclasses will implement this
        protected abstract Pizza CreatePizza(string type);

        // The template method that uses the factory method
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);  // Factory method call

            Console.WriteLine($"--- Making a {pizza.Name} ---");
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            Console.WriteLine();

            return pizza;
        }
    }
}
