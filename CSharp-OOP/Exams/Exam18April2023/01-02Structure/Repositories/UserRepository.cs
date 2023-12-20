using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> models;

        public UserRepository()
        {
            models = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            this.models.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            var removedUser = this.models.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (removedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IUser FindById(string identifier)
        {
            return this.models.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this.models.AsReadOnly();
        }
    }
}
