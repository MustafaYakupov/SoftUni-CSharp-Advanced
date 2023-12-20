using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            this.models.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            var removedUser = this.models.FirstOrDefault(u => u.LicensePlateNumber == identifier);

            if (removedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IVehicle FindById(string identifier)
        {
            return this.models.FirstOrDefault(u => u.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.models.AsReadOnly();
        }
    }
}
