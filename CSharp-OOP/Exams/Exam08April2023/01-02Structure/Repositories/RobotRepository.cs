using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Models()
        {
            return this.models.AsReadOnly();
        }
        public void AddNew(IRobot model)
        {
            this.models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            IRobot robot = null;

            foreach (var model in this.models)
            {
                foreach (var standard in model.InterfaceStandards)
                {
                    if (standard == interfaceStandard)
                    {
                        robot = model;
                        break;
                    }
                }
            }

            return robot;
        }


        public bool RemoveByName(string typeName)
        {
            IRobot robot = this.models.FirstOrDefault(x => x.Model == typeName);

            if (robot == null)
            {
                this.models.Remove(robot);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
