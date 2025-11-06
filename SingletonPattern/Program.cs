using SingletonPattern;

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