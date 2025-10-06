namespace Strategy
{

    // strat

    public interface IExportService
    {
        void Export(Order order);
    }


    // concrete start

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} as JSON");
        }
    }
    // concrete start

    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} as XML.");
        }
    }

    // concrete start
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} as CSV.");
        }
    }

    // concrete mine
    public class PNGExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} as PNG.");
        }
    }

    // context
    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }

        public IExportService? ExportService { get; set; }
        public Order(string customer, int amount, string name, IExportService? exportService = null)
        {
            Customer = customer;
            Amount = amount;
            Name = name;
            ExportService = exportService ?? new CSVExportService();
        }

        public void Export()
        {
            ExportService?.Export(this);
        }
    }
}
