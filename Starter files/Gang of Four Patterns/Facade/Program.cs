using Facade;

Console.Title = "Facade";

var facade = new DiscountFacade();
Console.WriteLine($"Discount for customer 3 is {facade.CalculateDiscountPercentage(3)}");

Console.WriteLine($"Discount for customer 10 is {facade.CalculateDiscountPercentage(10)}");

Console.ReadKey();