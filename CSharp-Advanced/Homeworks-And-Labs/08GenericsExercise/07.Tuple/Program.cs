namespace _07.Tuple
{
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] nameAndBeerAmount = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] intAndDouble = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = nameAndAdress[0] + " " + nameAndAdress[1];
            string address = nameAndAdress[2];

            string secondName = nameAndBeerAmount[0];
            int beerLiters = int.Parse(nameAndBeerAmount[1]);

            int currentInteger = int.Parse(intAndDouble[0]);
            double currentDouble = double.Parse(intAndDouble[1]);

            CustomTuple<string, string> nameAdress = new(name, address);
            CustomTuple<string, int> nameBeer = new(secondName, beerLiters);
            CustomTuple<int, double> intDouble = new(currentInteger, currentDouble);

            Console.WriteLine(nameAdress);
            Console.WriteLine(nameBeer);
            Console.WriteLine(intDouble);
        }
    }
}