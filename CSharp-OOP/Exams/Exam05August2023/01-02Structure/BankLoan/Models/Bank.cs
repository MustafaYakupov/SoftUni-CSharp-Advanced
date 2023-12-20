using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public double SumRates()
        {
            double sum = loans.Sum(x => x.InterestRate);
            return sum;
        }

        public void AddClient(IClient Client)
        {
            if (clients.Count == Capacity)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }

            clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");

            if (clients.Count > 0)
            {
                sb.AppendLine($"Clients: {string.Join(", ", Clients.Select(x => x.Name))}");
            }
            else
            {
                sb.AppendLine($"Clients: none");

            }

            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().Trim();
        } 
    }
}
