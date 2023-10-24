namespace _01.GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Box<string> box = new();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            Console.WriteLine(box.ToString());  
        }
    }
}