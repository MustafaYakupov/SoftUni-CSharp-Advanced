using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsInParking = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (input[0] == "END")
                {
                    break;
                }

                string direction = input[0];
                string carPlate = input[1];

                if (direction == "IN")
                {
                    carsInParking.Add(carPlate);
                }
                else if (direction == "OUT")
                {
                    carsInParking.Remove(carPlate);
                }
            }

            if (carsInParking.Any())
            {
                foreach (var carPlate in carsInParking)
                {
                    Console.WriteLine(carPlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
