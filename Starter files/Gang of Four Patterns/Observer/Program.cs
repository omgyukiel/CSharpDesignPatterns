using Observer;

Console.Title = "Observer";



TicketStockService ticketStockService = new();
TicketResellerService ticketResellerService = new();
OrderService orderService = new();


orderService.AddObserver(ticketStockService);
orderService.CompleteTicketSale(1, 1000);
orderService.AddObserver(ticketResellerService);
orderService.CompleteTicketSale(1, 2000);
orderService.RemoveObserver(ticketStockService);
orderService.CompleteTicketSale(2, 3000);


Console.ReadKey();
