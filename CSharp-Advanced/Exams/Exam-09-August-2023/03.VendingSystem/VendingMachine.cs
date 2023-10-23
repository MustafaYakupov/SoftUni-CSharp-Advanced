

namespace VendingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            this.Drinks = new List<Drink>();
        }

        public int ButtonCapacity  { get; set; }
        public List<Drink> Drinks { get; set; }

        public int GetCount => this.Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (this.Drinks.Count < this.ButtonCapacity)
            {
                this.Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return this.Drinks.Remove(Drinks.FirstOrDefault(x => x.Name == name));

            //var drinkToRemove = this.Drinks.FirstOrDefault(x => x.Name == name);

            //if (drinkToRemove != null)
            //{
            //    this.Drinks.Remove(drinkToRemove);
            //    return true;
            //}
            //else return false;
        }

        public Drink GetLongest()
        {
            if (this.Drinks.Count > 0)
            {
                var biggestVolumeDrink = this.Drinks.OrderByDescending(x => x.Volume).FirstOrDefault();
                return biggestVolumeDrink;
            }
            else return null;
        }

        public Drink GetCheapest()
        {
            if (this.Drinks.Count > 0)
            {
                var cheapestDrink = this.Drinks.OrderBy(x => x.Price).FirstOrDefault();
                return cheapestDrink;
            }
            else return null;
        }

        public string BuyDrink(string name)  //Remove after bought?
        {
            if (this.Drinks.Count > 0)
            {
                var drinkToBuy = this.Drinks.Where(x => x.Name == name).FirstOrDefault();
                return drinkToBuy.ToString();
            }
            else return null;
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");
            foreach (var drink in this.Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
