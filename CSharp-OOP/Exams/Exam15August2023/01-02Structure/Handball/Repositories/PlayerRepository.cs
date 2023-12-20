using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return models.Remove(models.FirstOrDefault(p => p.Name == name));
        }

        public bool ExistsModel(string name)
        {
            IPlayer player = models.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return false;
            }

            return true;
        }

        public IPlayer GetModel(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }
    }
}
