using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] textiles = Console.ReadLine()              // Queue
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] medicaments = Console.ReadLine()         // Stack
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> textileQueue = new Queue<int>(textiles);
            Stack<int> medicamentsStack = new Stack<int>(medicaments);

            int medkits = 0;
            int bandages = 0;
            int patches = 0;


            while (textileQueue.Any() && medicamentsStack.Any())
            {
                int currentTextile = textileQueue.Dequeue();
                int currentMedicament = medicamentsStack.Pop();
                int sum = currentMedicament + currentTextile;

                if (sum > 100)
                {
                    int currentElement = medicamentsStack.Pop(); 
                    medicamentsStack.Push(currentElement + (sum - 100));
                    medkits++;
                }
                else if (sum == 30)
                {
                    patches++;
                }
                else if (sum == 40)
                {
                    bandages++; 
                }
                else if (sum == 100)
                {
                    medkits++;
                }
                else
                {
                    medicamentsStack.Push(currentMedicament + 10);
                }
            }

            if (!textileQueue.Any() && medicamentsStack.Any())
            {
                Console.WriteLine("Textiles are empty.");

                if (medkits > 0)
                {
                    Console.WriteLine($"MedKit - {medkits}");
                }

                if (bandages > 0)
                {
                    Console.WriteLine($"Bandage - {bandages}");
                }
                if (patches > 0)
                {
                    Console.WriteLine($"Patch - {patches}");
                }

                Console.WriteLine($"Medicaments left: {string.Join(" ", medicamentsStack)}");
            }
            else if(textileQueue.Any() && !medicamentsStack.Any())
            {
                Console.WriteLine("Medicaments are empty.");

                if (medkits > 0)
                {
                    Console.WriteLine($"MedKit - {medkits}");
                }

                if (bandages > 0)
                {
                    Console.WriteLine($"Bandage - {bandages}");
                }
                if (patches > 0)
                {
                    Console.WriteLine($"Patch - {patches}");
                }

                Console.WriteLine($"Textiles left: {string.Join(", ", textileQueue)}");
            }
            else
            {
                Console.WriteLine("Textiles and medicaments are both empty.");

                if (medkits > 0)
                {
                    Console.WriteLine($"MedKit - {medkits}");
                }

                if (bandages > 0)
                {
                    Console.WriteLine($"Bandage - {bandages}");
                }
                if (patches > 0)
                {
                    Console.WriteLine($"Patch - {patches}");
                }
            }
        }
    }
}
