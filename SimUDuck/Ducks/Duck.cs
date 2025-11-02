using SimUDuck.Behaviors;

public abstract class Duck
{
    public FlyBehavior FlyBehavior { get; set; }
    public QuackBehavior QuackBehavior { get; set; }
    public Duck()
    {
    }

    public abstract void display();
    public void performFly()
    {
        FlyBehavior.fly();
    }
    public void performQuack()
    {
        QuackBehavior.quack();
    }
    public void swim()
    {
        Console.WriteLine("All ducks float, even decoys!");
    }


}