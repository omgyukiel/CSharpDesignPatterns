using State;

Console.Title = "State";

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.Widthdraw(50);
bankAccount.Widthdraw(500);
bankAccount.Widthdraw(50);
bankAccount.Deposit(300);
bankAccount.Widthdraw(50);