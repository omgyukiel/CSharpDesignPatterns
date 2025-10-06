namespace Decorator
{
    /// comoponent
    /// 
    public interface IMailService
    {
        bool SendMail(string message);
    }

    // concrete component

    public class  CloudMailService: IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(CloudMailService)}");
            return true;
        }
        
    }

    // concrete 2
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(OnPremiseMailService)}");
            return true;
        }

    }
    // deocrator
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }

    }

    // concrete decorator
    public class  StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            // fake collect stats
            Console.WriteLine($"collecting statistic in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }


    // concrete decorator
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        /// <summary>
        ///  a list of sent message - a "fake" database
        /// </summary>

        public List<string> SentMessages { get; private set; } = new List<string>();

        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        { }

        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            };
            return false;
        }

    }

    // my concrete decorator
    public class AttachCatPngDecorator : MailServiceDecoratorBase
    {
        private readonly string _catPngPath;
        public AttachCatPngDecorator(IMailService mailService, string catPngPath) : base(mailService)
        {
                       _catPngPath = catPngPath;
        }

        public override bool SendMail(string message)
        {
           message += $" with cat png from {_catPngPath}";
           return base.SendMail(message);
        }
    }
}
