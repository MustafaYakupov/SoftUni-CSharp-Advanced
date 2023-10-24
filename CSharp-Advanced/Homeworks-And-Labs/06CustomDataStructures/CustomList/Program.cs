namespace CustomList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(5);
            list.Add(10);
            list.Add(15);
            list.Add(20);

            list.RemoveAt(0);
            list.Insert(1, 50);

            list.Swap(1,2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}