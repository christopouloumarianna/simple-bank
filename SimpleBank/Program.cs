using System;

namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(1, "Dimitris", "Athens");
            var account = new AnalyticAccount(person);
            account.LoadJson();

            Console.WriteLine(account);
            
            account.Deposit(1);
           
           //comment
           
            account.Withdraw(2);
            account.PrintTransactions();
            account.SaveToFile("myFile.txt");
            account.SaveToJson();

        }
    }
}
