using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = inputTokens[0];
                int age = int.Parse(inputTokens[1]);

                IBuyer buyer;

                if (inputTokens.Length == 4)  //Citizen
                {
                    string id = inputTokens[2];
                    string birthdate = inputTokens[3];

                    buyer = new Citizen(name, age, id, birthdate);

                    if (!buyers.Contains(buyer))
                    {
                        buyers.Add(buyer);
                    }
                }
                else                         //Rebel
                {
                    string group = inputTokens[2];

                    buyer = new Rebel(name, age, group);

                    if (!buyers.Contains(buyer))
                    {
                        buyers.Add(buyer);
                    }
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name.ToLower() == "end")
                {
                    break;
                }

                IBuyer currentBuyer = buyers.FirstOrDefault(x => x.Name == name);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }

            int totalFoodBought = 0;

            foreach (var buyer in buyers)
            {
                totalFoodBought += buyer.Food;
            }

            Console.WriteLine(totalFoodBought);
        }
    }
}