using CompositePatternGiftShop.Models;

namespace CompositePatternGiftShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculatePrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            SingleGift truckToy = new SingleGift("TruckToy", 289);
            SingleGift plainToy = new SingleGift("PlainToy", 587);
            SingleGift soldierToy = new SingleGift("soldierToy", 200);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            rootBox.Add(soldierToy);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculatePrice()}");
        }
    }
}