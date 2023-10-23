namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] foodPortions = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] staminaQuantities = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string,int> peaksToConquer = new Dictionary<string, int>();
            peaksToConquer["Kamenitza"] = 70;
            peaksToConquer["Polezhan"] = 60;
            peaksToConquer["Banski Suhodol"] = 100;
            peaksToConquer["Kutelo"] = 90;
            peaksToConquer["Vihren"] = 80;

            List<string> conqueredPeaks = new List<string>();

            Stack<int> foodStack = new Stack<int>(foodPortions);
            Queue<int> staminaQueue = new Queue<int>(staminaQuantities);

            while (foodStack.Any() && staminaQueue.Any() && peaksToConquer.Any())
            {
               int sum = foodStack.Pop() + staminaQueue.Dequeue();
               var currentPeak = peaksToConquer.Last();

               if (sum >= currentPeak.Value)
               {
                    conqueredPeaks.Add(currentPeak.Key);
                    peaksToConquer.Remove(currentPeak.Key);
               }
            }

            if (peaksToConquer.Any())
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            else
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }

            if (conqueredPeaks.Any())
            {
                Console.WriteLine("Conquered peaks:");

                foreach (var peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}