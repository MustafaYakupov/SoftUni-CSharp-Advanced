namespace CustomStack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(5);
            stack.Push(10);
            stack.Push(22);
            stack.Push(36);
            stack.Push(48);

           // Console.WriteLine(stack.Pop());
           // Console.WriteLine(stack.Pop());
           // Console.WriteLine(stack.Peek());

            stack.ForEach(x => Console.WriteLine(x));
        }
    }
}