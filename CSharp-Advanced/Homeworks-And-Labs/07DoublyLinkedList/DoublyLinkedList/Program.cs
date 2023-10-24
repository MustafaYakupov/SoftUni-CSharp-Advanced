namespace DoublyLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

            linkedList.Reverse();

            linkedList.ForEach(x => Console.WriteLine($"From Foreach: {x}"));

            //Node currentNode = linkedList.Head;
            //
            //while (currentNode != null)
            //{ 
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}
        }
    }
}