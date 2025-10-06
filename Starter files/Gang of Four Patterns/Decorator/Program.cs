using Decorator;
Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there.");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hello there.");

// add behavior

var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");



var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
var attachCatPngDecorator = new AttachCatPngDecorator(messageDatabaseDecorator, "cat.png");
attachCatPngDecorator.SendMail($"Hello there via {nameof(MessageDatabaseDecorator)} wrapper, message 1");
attachCatPngDecorator.SendMail($"Hello there via {nameof(MessageDatabaseDecorator)} wrapper, message 2");
messageDatabaseDecorator.SendMail($"hello there via {nameof(messageDatabaseDecorator)} with no cat png");
foreach (var message in messageDatabaseDecorator.SentMessages)
{
       Console.WriteLine($"Logged message: {message}");
}

Console.ReadKey();