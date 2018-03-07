using System;

public class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        account.ID = 1;
        account.Balance = 15;

        Console.WriteLine($"Account {account.ID}, balance {account.Balance}");

    }
}
