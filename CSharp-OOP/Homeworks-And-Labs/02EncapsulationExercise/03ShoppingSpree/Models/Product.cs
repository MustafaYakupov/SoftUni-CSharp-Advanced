using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;
        public Product(string productName, decimal price)
        {
            this.Name = productName;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }
        public decimal Price 
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.price = value;
            }
        }

        public override string ToString() => Name;
    }
}
