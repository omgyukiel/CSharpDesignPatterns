namespace Observer
{


    // notification
    public class TicketChange
    {
        public int Amount { get; private set; }
        public int ArtistId { get; private set; }

        public TicketChange(int artistId, int amount)
        {
            ArtistId = artistId;
            Amount = amount;
        }
    }


    // subject
    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        public void AddObserver(ITicketChangeListener observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ITicketChangeListener observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    // observer
    public interface  ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    /// concrete subject
    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            Console.WriteLine($"{nameof(OrderService)}: is changing its state.");
            Console.WriteLine($"{nameof(OrderService)}: Notifying observers...");
            Notify(new TicketChange(artistId, amount));
        }
    }

    /// concrete observer
    /// 
    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)}: Reacted to the event. ArtistId: {ticketChange.ArtistId}, Amount: {ticketChange.Amount}");
        }

    }

    /// concrete observer
    /// 
    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)}: Reacted to the event. ArtistId: {ticketChange.ArtistId}, Amount: {ticketChange.Amount}");
        }

    }
}
