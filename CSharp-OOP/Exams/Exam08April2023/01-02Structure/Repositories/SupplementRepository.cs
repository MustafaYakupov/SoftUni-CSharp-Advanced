using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            this.models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement supplement = this.models.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

            if (supplement != null)
            {
                return supplement;
            }
            else
            {
                return null;
            } 
                
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return this.models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement supplementToRemove = this.models.FirstOrDefault(x => x.GetType().Name == typeName);

            if (supplementToRemove != null)
            {
                this.models.Remove(supplementToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
