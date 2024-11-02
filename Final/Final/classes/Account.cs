using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.classes
{
    public abstract class Account
    {
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public double initialBalance { private get; set; }

        public virtual void Deposit(double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if(Balance > amount)
            {
                Balance -= amount;
            } else
            {
                throw new Exception("Insufficient Funds");
            }
        }
        //Accounts will be differentiated by how they handle interest. CD's will hjave compund interest and simple savings accounts will have normal interest
        public abstract void UpdateAccountWithInterest();

        public override string ToString()
        {
            return AccountName;
        }

    }
}
