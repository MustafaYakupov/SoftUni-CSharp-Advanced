using _01Vehicles.Models;
using _01Vehicles.Models.Interfaces;

namespace _01Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] truckInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] busInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ICollection<IVehicle> vehicles = new List<IVehicle>();
            IVehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            IVehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            IVehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = commandTokens[0];
                    string vehicleType = commandTokens[1];

                    IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                    if (vehicle == null)
                    {
                        throw new ArgumentException("Invalid vehicle type");
                    }

                    if (command == "Drive")
                    {
                        double distance = double.Parse(commandTokens[2]);
                        Console.WriteLine(vehicle.Drive(distance));
                    }
                    else if (command == "Refuel")
                    {
                        double fuelAmount = double.Parse(commandTokens[2]);
                        vehicle.Refuel(fuelAmount);
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(commandTokens[2]);
                        Console.WriteLine(vehicle.Drive(distance, false));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }


    }
}