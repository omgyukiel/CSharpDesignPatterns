using BuilderPattern;

Console.Title = "Builder";

var garage = new Garage();

var miniBuilder = new MiniBuilder();
var mustangBuilder = new MustangBuilder();

garage.Construct(miniBuilder);
Console.WriteLine(miniBuilder.Car.ToString());

garage.Show();

garage.Construct(mustangBuilder);
Console.WriteLine(mustangBuilder.Car.ToString());
garage.Show();

Console.ReadKey();