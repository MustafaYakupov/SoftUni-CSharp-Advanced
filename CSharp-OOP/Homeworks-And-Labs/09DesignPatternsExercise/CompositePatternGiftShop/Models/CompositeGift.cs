using CompositePatternGiftShop.Abstraction;

namespace CompositePatternGiftShop.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
        public override int CalculatePrice()
        {
            int total = 0;

            Console.WriteLine($"{this.Name} contains the following products with prices:");

            foreach (var gift in gifts)
            {
                total += gift.CalculatePrice();
            }

            return total;
        }
    }
}
