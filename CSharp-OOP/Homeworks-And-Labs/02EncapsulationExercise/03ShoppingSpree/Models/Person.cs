using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
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

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Money cannot be a negative number.");
                }

                this.money = value;
            }
        }

        public string Add(Product product)
        {
            if (this.Money < product.Price)
            {
                return $"{this.Name} can't afford {product}";
            }

            this.products.Add(product);

            this.Money -= product.Price;

            return $"{this.Name} bought {product}";
        }

        public override string ToString()
        {
            string productsString = products.Any()
                 ? string.Join(", ", products)
                 : "Nothing bought";

            return $"{this.Name} - {productsString}";
        }
    }
}
