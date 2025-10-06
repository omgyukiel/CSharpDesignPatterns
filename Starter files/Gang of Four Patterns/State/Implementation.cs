namespace State
{
    // state
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void Widthdraw(decimal amount);
    }

    // concrete state
    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, despoiting {amount}");
            Balance += amount;
        }
        public override void Widthdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
            Balance -= amount;
            if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    // concrete state
    public class OverdrawnState : BankAccountState
    {
        public OverdrawnState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, despoiting {amount}");
            Balance += amount;
            if (Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }
        public override void Widthdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, widthdrawing from an overdrawn account is not allowed.");
        }
    }


    // context

    public class BankAccount
    { 
        public BankAccountState BankAccountState { get; set; }

        public decimal Balance => BankAccountState.Balance;

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            BankAccountState.Deposit(amount);
        }

        public void Widthdraw(decimal amount)
        {
            BankAccountState.Widthdraw(amount);
        }
    }
}
