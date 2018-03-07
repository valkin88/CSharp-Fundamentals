using System;

public class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        account.ID = 1;
        account.Deposit(15);
        account.Withdraw(10);

        Console.WriteLine(account);
    }
}
