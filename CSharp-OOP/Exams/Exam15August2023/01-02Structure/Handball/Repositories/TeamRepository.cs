using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;

        public TeamRepository()
        {
            models = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(models.FirstOrDefault(p => p.Name == name));
        }

        public bool ExistsModel(string name)
        {
            ITeam team = models.FirstOrDefault(p => p.Name == name);

            if (team == null)
            {
                return false;
            }

            return true;
        }

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }
    }
}
