using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            this.users = new UserRepository();
            this.vehicles = new VehicleRepository();
            this.routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (this.users.FindById(drivingLicenseNumber) != null)
            {
                return String.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);

            users.AddModel(user);

            return String.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return String.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (this.vehicles.FindById(licensePlateNumber) != null)
            {
                return String.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle = null;

            if (vehicleType == typeof(CargoVan).Name)
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else if (vehicleType == typeof(PassengerCar).Name)
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);

            return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            List<IRoute> allRoutes = this.routes.GetAll().ToList();

            var existingRoute = allRoutes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length);

            if (existingRoute != null)
            {
                return String.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            var shorterRoute = allRoutes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

            if (shorterRoute != null && shorterRoute.Length < length)
            {
                return String.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);

            routes.AddModel(route);

            var longerRoute = allRoutes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

            if (longerRoute != null)
            {
                if (longerRoute.Length > length)
                {
                    longerRoute.LockRoute();
                }
            }

            return String.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.GetAll().First(x => x.DrivingLicenseNumber == drivingLicenseNumber);

            if (user.IsBlocked == true)
            {
                return String.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            IVehicle vehicle = vehicles.GetAll().First(x => x.LicensePlateNumber == licensePlateNumber);

            if (vehicle.IsDamaged == true)
            {
                return String.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            IRoute route = routes.GetAll().First(x => x.RouteId == int.Parse(routeId));

            if (route.IsLocked == true)
            {
                return String.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();

            //if (vehicle.IsDamaged == true)
            //{
            //    return $"{vehicle.Brand} {vehicle.Model} License plate: {vehicle.LicensePlateNumber} Battery: {vehicle.BatteryLevel}% Status: damaged";
            //}
            //else
            //{
            //    return $"{vehicle.Brand} {vehicle.Model} License plate: {vehicle.LicensePlateNumber} Battery: {vehicle.BatteryLevel}% Status: OK";
            //}
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> damagedVehicles = this.vehicles
                .GetAll().ToList()
                .FindAll(x => x.IsDamaged == true)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .ToList();

            int counter = 0;

            if (damagedVehicles.Count > count)
            {
                for (int i = 0; i < count; i++)
                {
                    counter++;
                    damagedVehicles[i].ChangeStatus();
                }

                return String.Format(OutputMessages.RepairedVehicles, counter);
            }
            else
            {
                foreach (var car in damagedVehicles)
                {
                    car.ChangeStatus();
                }

                return String.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
            }
        }

        public string UsersReport()
        {
            List<IUser> allUsers = users.GetAll().ToList()
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.FirstName).ToList();

            StringBuilder sb = new();

            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in allUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
