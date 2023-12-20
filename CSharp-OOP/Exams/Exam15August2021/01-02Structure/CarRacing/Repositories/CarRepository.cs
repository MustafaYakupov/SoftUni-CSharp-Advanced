using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }

            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(c => c.VIN == property);
        }
    }
}
