using State;

Console.Title = "State";

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.Widthdraw(500);
bankAccount.Widthdraw(100);
bankAccount.Deposit(2000);
bankAccount.Deposit(100);
bankAccount.Widthdraw(3000);
bankAccount.Deposit(3000);
bankAccount.Deposit(100);

Console.ReadKey();