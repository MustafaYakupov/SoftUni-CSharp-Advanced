using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int INTERESTRATE = 3;
        private const double AMOUNT = 50000;
        public MortgageLoan()
            : base(INTERESTRATE, AMOUNT)
        {
        }
    }
}
