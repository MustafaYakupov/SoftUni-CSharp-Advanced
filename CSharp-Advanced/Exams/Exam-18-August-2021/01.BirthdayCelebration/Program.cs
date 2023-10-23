using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestCapacityInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] platesInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queueuGuests = new Queue<int>(guestCapacityInput);
            Stack<int> stackPlates = new Stack<int>(platesInput);
            int wastedFood = 0;

            while (queueuGuests.Any() && stackPlates.Any())
            {
                int guest = queueuGuests.Dequeue();
                int plate = stackPlates.Pop();

                if (guest - plate <= 0) 
                {
                    int difference = plate - guest;
                    wastedFood += difference;
                }
                else
                {
                    while (true)
                    {
                        int difference = guest -= plate;

                        if (guest < 0)
                        {
                            wastedFood += Math.Abs(difference);
                            break;
                        }
                        else if (guest == 0)
                        {
                            break;
                        }

                        plate = stackPlates.Pop();
                    }
                }
            }

            if (queueuGuests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", queueuGuests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ", stackPlates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
