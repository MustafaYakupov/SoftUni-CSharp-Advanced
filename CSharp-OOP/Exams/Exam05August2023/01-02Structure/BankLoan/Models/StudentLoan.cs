using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Contracts
{
    public class StudentLoan : Loan
    {
        private const int INTERESTRATE = 1;
        private const double AMOUNT = 10000;
        public StudentLoan()
            : base(INTERESTRATE, AMOUNT)
        {
        }
    }
}
