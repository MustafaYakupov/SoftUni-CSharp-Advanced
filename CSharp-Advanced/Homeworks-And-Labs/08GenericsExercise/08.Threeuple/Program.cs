namespace _08.Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] nameStreetCity = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] nameBeerDrunk = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] intAndDouble = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = nameStreetCity[0] + " " + nameStreetCity[1];
            string street = nameStreetCity[2];
            string city = string.Join(" ", nameStreetCity[3..]);

            string secondName = nameBeerDrunk[0];
            int beerLiters = int.Parse(nameBeerDrunk[1]);
            bool isDrunk = nameBeerDrunk[2] == "drunk";

            string nameBank = intAndDouble[0];
            double ballance = double.Parse(intAndDouble[1]);
            string bank = intAndDouble[2];


            CustomTuple<string, string, string> nameAdressCity = new(name, street, city);
            CustomTuple<string, int, bool> nameBeer = new(secondName, beerLiters, isDrunk);
            CustomTuple<string, double, string> intDouble = new(nameBank, ballance, bank);

            Console.WriteLine(nameAdressCity);
            Console.WriteLine(nameBeer);
            Console.WriteLine(intDouble);
        }
    }
}