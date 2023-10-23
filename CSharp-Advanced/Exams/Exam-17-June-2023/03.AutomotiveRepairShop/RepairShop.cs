using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Capacity > this.Vehicles.Count)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            var vehicleToFind = this.Vehicles.Where(x => x.VIN == vin).FirstOrDefault();

            if (this.Vehicles.Contains(vehicleToFind))
            {
                this.Vehicles.Remove(vehicleToFind);

                return true;
            }
            else return false;
        }

        public int GetCount()
        {
            return this.Vehicles.Count();
        }

        public Vehicle GetLowestMileage()
        {
            return this.Vehicles.OrderBy(x => x.Mileage).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var car in this.Vehicles)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
