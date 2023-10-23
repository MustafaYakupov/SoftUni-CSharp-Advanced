namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] monsterArmor = Console.ReadLine()  //Queue
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] soldiersImpact = Console.ReadLine()  //Stack
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> armorQueue = new(monsterArmor);
            Stack<int> impactStack = new(soldiersImpact);

            int monstersKilled = 0;

            while (armorQueue.Any() && impactStack.Any())
            {
                int armorValue = armorQueue.Dequeue();
                int strikeValue = impactStack.Pop();

                if (strikeValue >= armorValue)
                {
                    monstersKilled++;
                    strikeValue -= armorValue;

                    
                        if (impactStack.Any())
                        {
                            int topElement = impactStack.Pop();
                            topElement += strikeValue;
                            impactStack.Push(topElement);
                        }
                        else if (!impactStack.Any() && strikeValue > 0)
                        {
                            impactStack.Push(strikeValue);
                        }
                    
                }
                else  // Impact less thank armor
                {
                    armorValue -= strikeValue;
                    armorQueue.Enqueue(armorValue);
                }
            }

            if (!armorQueue.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if(!impactStack.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            
            Console.WriteLine($"Total monsters killed: {monstersKilled}");
        }
    }
}