using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = null;

            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException("Invalid bank type.");
            }

            banks.AddModel(bank);
            return $"{bankTypeName} is successfully added.";
        }
        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;

            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException("Invalid loan type.");
            }

            loans.AddModel(loan);

            return $"{loanTypeName} is successfully added.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            IBank bank = banks.FirstModel(bankName);

            bank.AddLoan(loan);

            loans.RemoveModel(loan);

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = null;
            IBank bank = banks.FirstModel(bankName);

            if (clientTypeName == "Student")
            {
                var currentBankType = bank.GetType().Name;

                if (currentBankType != "BranchBank")
                {
                    return $"Unsuitable bank.";
                }

                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == "Adult")
            {
                var currentBankType = bank.GetType().Name;

                if (currentBankType != "CentralBank")
                {
                    return $"Unsuitable bank.";
                }

                client = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException("Invalid client type.");
            }

            bank.AddClient(client);
            return $"{clientTypeName} successfully added to {bankName}.";
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);

            double loansAmountSum = 0;
            double incomeFromClients = 0;

            foreach (var loan in bank.Loans)
            {
                loansAmountSum += loan.Amount;
            }

            foreach (var client in bank.Clients)
            {
                incomeFromClients += client.Income;
            }

            double totalFunds = incomeFromClients + loansAmountSum;

            return $"The funds of bank {bankName} are {totalFunds:F2}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().Trim();
        }
    }
}
