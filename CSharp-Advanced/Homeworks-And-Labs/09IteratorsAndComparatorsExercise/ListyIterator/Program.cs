namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            ListyIterator<string> listyIterator = new(inputList);

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }

                if (input == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (input == "PrintAll")
                {
                    listyIterator.PrintAll();
                }
            }
        }
    }
}