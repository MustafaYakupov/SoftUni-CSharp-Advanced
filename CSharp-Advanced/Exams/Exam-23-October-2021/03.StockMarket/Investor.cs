using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            this.Portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Dictionary<string, Stock> Portfolio { get; set; }

        public int Count =>  this.Portfolio.Count;
        
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest > stock.PricePerShare)
            {
                this.Portfolio.Add(stock.CompanyName, stock);

                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            
            if (sellPrice < this.Portfolio[companyName].PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            
            this.Portfolio.Remove(companyName);
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if (this.Portfolio.ContainsKey(companyName))
            {
                return this.Portfolio[companyName];
            }
            else return null;
        }

        public Stock FindBiggestCompany()
        {
            if (!this.Portfolio.Any())
            {
                return null;
            }

            return this.Portfolio.Values.OrderByDescending(x => x.MarketCapitalization).First();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
