namespace Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> stonesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Lake lake = new Lake(stonesInput);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}