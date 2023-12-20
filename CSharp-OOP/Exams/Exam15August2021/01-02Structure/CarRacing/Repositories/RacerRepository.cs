using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }

            models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(r => r.Username == property);
        }
    }
}
