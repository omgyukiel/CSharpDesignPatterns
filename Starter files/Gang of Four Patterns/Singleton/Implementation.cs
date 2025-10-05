namespace Singleton
{
    public class Logger
    {
        private static Logger? _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        protected Logger()
        {
            // Protected constructor to prevent instantiation from outside
        }

        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }
    }
}
