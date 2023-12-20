using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly List<IRoute> models;

        public RouteRepository()
        {
            models = new List<IRoute>();
        }

        public void AddModel(IRoute model)
        {
            this.models.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            var removedUser = this.models.FirstOrDefault(r => r.RouteId == int.Parse(identifier));

            if (removedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IRoute FindById(string identifier)
        {
            return this.models.FirstOrDefault(r => r.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return this.models.AsReadOnly();
        }
    }
}
