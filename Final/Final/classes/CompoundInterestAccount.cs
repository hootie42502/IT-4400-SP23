using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.classes
{
    public class CompoundInterestAccount : Account
    {
        public CompoundInterestAccount(double initialBalance) 
        { 
            this.initialBalance = initialBalance;
            this.Balance= initialBalance;
        }

        //interest rate is 0.15

        public override void UpdateAccountWithInterest()
        {
            Balance = Balance * (1.15);
        }
    }
}
