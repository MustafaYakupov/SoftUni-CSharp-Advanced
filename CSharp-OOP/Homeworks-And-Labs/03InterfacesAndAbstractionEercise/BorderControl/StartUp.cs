using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputTokens[0].ToLower() == "end")
                {
                    break;
                }

                if (inputTokens[0].ToLower() == "citizen")
                {
                    string name = inputTokens[1];
                    int age = int.Parse(inputTokens[2]);
                    string id = inputTokens[3];
                    string birthDate = inputTokens[4];

                    IBirthable citizen = new Citizen(id, name, age, birthDate);

                    birthables.Add(citizen);
                }
                else if (inputTokens[0].ToLower() == "pet")
                {
                    string name = inputTokens[1];
                    string birthDate = inputTokens[2];

                    IBirthable pet = new Pet(name, birthDate);

                    birthables.Add(pet);
                }
                else if (inputTokens[0].ToLower() == "robot")
                {
                    string model = inputTokens[1];
                    string id = inputTokens[2];

                    IIdentifiable robot = new Robot(id, model);
                }
            }

            string specificYear = Console.ReadLine();

            foreach (var item in birthables)
            {
                if (item.Birthdate.EndsWith(specificYear))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}