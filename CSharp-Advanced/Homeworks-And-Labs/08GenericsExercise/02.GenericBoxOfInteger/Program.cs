namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Box<int> box = new();

            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());

                box.Add(input);
            }

            Console.WriteLine(box.ToString());
        }
    }
}