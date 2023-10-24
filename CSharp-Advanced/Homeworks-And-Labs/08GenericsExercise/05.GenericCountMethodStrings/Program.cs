namespace _05.GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            string itemToCompare = Console.ReadLine();

            //box.Count(itemToCompare);
            Console.WriteLine(box.CompareLargerElementCount(itemToCompare));
        }
    }
}