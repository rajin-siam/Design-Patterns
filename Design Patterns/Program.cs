using SimUDuck.Ducks;
using SimUDuck.Behaviors;

Duck mallard = new MallardDuck();
mallard.display();
mallard.performFly();
mallard.performQuack();

Duck model = new ModelDuck();
model.display();
model.performFly();
model.FlyBehavior = new FlyRocketPowered();
model.performFly();
