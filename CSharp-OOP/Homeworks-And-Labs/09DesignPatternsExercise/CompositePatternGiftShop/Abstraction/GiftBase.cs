namespace CompositePatternGiftShop.Abstraction
{
    public abstract class GiftBase
    {
        private string name;
        private int price;

        protected GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name 
        { 
            get => name; 
            protected set => name = value; 
        }
        public int Price 
        { 
            get => price;
            protected set => price = value; 
        }

        public abstract int CalculatePrice();
    }
}
