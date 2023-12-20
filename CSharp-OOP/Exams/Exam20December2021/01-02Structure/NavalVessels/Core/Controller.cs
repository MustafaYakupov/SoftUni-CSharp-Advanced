using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            };

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            IVessel vessel = null;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return $"Invalid vessel type.";
            }

            vessels.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);

            if (captain != null)
            {
                return captain.Report();
            }
            return null;
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel != null)
            {
                return vessel.ToString();
            }
            return null;
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel is Submarine submarine)
            {
                submarine.ToggleSubmergeMode();
                return $"Submarine {submarine.Name} toggled submerge mode.";
            }
            else if (vessel is Battleship battleship)
            {
                battleship.ToggleSonarMode();
                return $"Battleship {battleship.Name} toggled sonar mode.";
            }
            else
            {
                return $"Vessel {vesselName} could not be found.";
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel defender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (defender == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attacker.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (defender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attacker.Attack(defender);

            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return $"Vessel {defender.Name} was attacked by vessel {attacker.Name} - current armor thickness: {defender.ArmorThickness}.";
        } 
    }
}
