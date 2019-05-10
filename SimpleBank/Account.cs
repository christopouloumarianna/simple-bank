using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace SimpleBank
{
     public abstract class Account
    {
        private Person _owner;
        private double _balance;
        public double Balance { get { return _balance; } }
        public string Owner { get { return _owner.ToString(); } }
        public Account(Person owner)
        {
            _owner = owner;
            _balance = 0;
        }
        public virtual bool Withdraw(double amount)
        {
            _balance -= amount;
        return true;
        }
    public virtual bool Deposit(double amount)
    {
            _balance += amount;
            return true;
    }
}
    

    public class SimpleAccount : Account
    {
        public SimpleAccount(Person owner) : base(owner)
        {
        }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount);
        }
    }
    public class AnalyticAccount : Account
    {
        private readonly List<Transaction> transactions;
        private const string fileName = @"C:\mydata\academy\transactions.json";
        public AnalyticAccount(Person owner) : base(owner)
        {
            transactions = new List<Transaction>();
        }

        public override bool Deposit(double amount)
        {
            transactions.Add(new Transaction( DateTime.Now,amount, "deposit",Owner));
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            transactions.Add(new Transaction(DateTime.Now, amount, "withdraw", Owner));
            return base.Withdraw(amount);
        }
        public void PrintTransactions()
        {
            foreach (Transaction t in transactions)
            {
                Console.WriteLine(t);
            }
        }
        public void SaveToFile(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (Transaction t in transactions)
                {
                    file.WriteLine(t);
                }
                
                }
            }
        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(transactions.ToArray());            //write string to file

            File.WriteAllText(fileName, json);
        }
        public void LoadJson()
        {
            
            string data = File.ReadAllText(fileName);

            var tempTransactions = JsonConvert. DeserializeObject<List<Transaction>>(data);
            foreach(Transaction t in tempTransactions)
            {
                transactions.Add(t);
            }
            //transactions.Sort();
        }
        }
    }
    
