
using FactoryMethod.Factory;
using FactoryMethod.Store;

class Program
{
    static void Main()
    {
        SimplePizzaFactory factory = new SimplePizzaFactory();
        PizzaStore store = new PizzaStore(factory);

        store.OrderPizza("cheese");
        Console.WriteLine();

        store.OrderPizza("veggie");
        Console.WriteLine();

        store.OrderPizza("pepperoni");
    }
}
