using CompositePatternGiftShop.Abstraction;

namespace CompositePatternGiftShop.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculatePrice()
        {
            Console.WriteLine($"{this.Name} with the price {this.Price}");

            return this.Price;
        }
    }
}
