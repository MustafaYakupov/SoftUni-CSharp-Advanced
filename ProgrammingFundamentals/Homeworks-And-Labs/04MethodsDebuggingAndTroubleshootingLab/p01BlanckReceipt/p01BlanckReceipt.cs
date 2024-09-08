using System;

namespace p01BlanckReceipt
{
    class p01BlanckReceipt
    {

        static void Main(string[] args)
        {
            PrintReceipt();
           

        }
        
        static void PrintReceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("{0}", new string('-', 30));

        }

        static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to{0}", new string ('_', 20));
            Console.WriteLine("Received by{0}", new string ('_', 19));
        }

        static void PrintReceiptFooter()
        {
            Console.WriteLine("{0}", new string('-', 30));
            Console.WriteLine("\u00A9 SoftUni");
        }

        static void PrintReceipt()
        {
            PrintReceiptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }
    }
}
