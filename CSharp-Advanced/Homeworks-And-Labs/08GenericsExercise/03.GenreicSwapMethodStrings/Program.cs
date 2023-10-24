namespace _03.GenreicSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<string> list = new();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                list.Add(input);
            }

            int[] swapIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapIndexes[0];
            int secondIndex = swapIndexes[1];

            Swap(firstIndex, secondIndex,list);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static void Swap<T>(int first, int second, List<T> list)
        {
            (list[first], list[second]) = (list[second], list[first]);
        }
    }
}