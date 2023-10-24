namespace _06.GenericCountMethodDoubles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < lines; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            //box.Count(itemToCompare);
            Console.WriteLine(box.CompareLargerElementCount(itemToCompare));
        }
    }
}