using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBank
{
   public class Transaction
    {
        public DateTime dateTime { get; set; }
        public double amount { get; set; }
        public string action { get; set; }
        public string actor { get; set; }

        public Transaction(DateTime dateTime, double amount, string action, string actor)
        {
            this.dateTime = dateTime;
            this.amount = amount;
            this.action = action;
            this.actor = actor;
        }

        public override string ToString()
        {
            return $" { dateTime} \t {amount}\t {action}\t {actor}";



        }
    }
}
