using FacadePattern.Facade;
using FacadePattern.Subsystems;

Console.WriteLine("===================================");
Console.WriteLine("  HOME THEATER FACADE DEMO");
Console.WriteLine("===================================");

// Create subsystem instances
var dvd = new DVDPlayer();
var projector = new Projector();
var sound = new SoundSystem();
var lights = new Lights();
var popcorn = new PopcornMaker();

// Create facade
var homeTheater = new HomeTheaterFacade(
    dvd,
    projector,
    sound,
    lights,
    popcorn
);

// Demonstrate the facade pattern
Console.WriteLine("\n--- DEMO 1: Watch a Movie ---");
homeTheater.WatchMovie("The Matrix");

await Task.Delay(2000);

Console.WriteLine("\n--- DEMO 2: End Movie ---");
homeTheater.EndMovie();

await Task.Delay(1000);

Console.WriteLine("\n--- DEMO 3: Listen to Music ---");
homeTheater.ListenToMusic("Pink Floyd - Dark Side of the Moon");

await Task.Delay(1000);

Console.WriteLine("\n--- DEMO 4: Gaming Mode ---");
homeTheater.PlayGame("Call of Duty");

Console.WriteLine("\n===================================");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();