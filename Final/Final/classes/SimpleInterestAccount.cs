using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.classes
{
    class SimpleInterestAccount : Account
    {
        private double initialBalance;

        public SimpleInterestAccount(double initialBalance)
        {
            this.initialBalance = initialBalance;
            this.Balance = initialBalance;
        }

        public override void UpdateAccountWithInterest()
        {
            this.Balance += (initialBalance * 0.15);
        }
    }
}
