using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }

                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            private set
            {
                if (value > 10)
                {
                    value = 10;
                }
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Count > 0)
            {
                foreach (var vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
