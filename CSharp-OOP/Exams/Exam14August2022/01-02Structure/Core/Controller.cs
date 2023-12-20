using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = null;

            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);

            planets.AddItem(planet);

            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format($"{unitTypeName} still not available!"));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            planet.AddUnit(unit);
            planet.Spend(unit.Cost);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format($"{weaponTypeName} still not available!"));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format($"{weaponTypeName} already added to the Weapons of {planetName}!"));
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format($"Planet {planetName} does not exist!"));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format($"No units available for upgrade!"));
            }

            planet.TrainArmy();
            planet.Spend(1.25);

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) 
                    && planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }
                else if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) == false)
                    && planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) == false)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }
                else if(planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    && planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) == false)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet1.Profit(planet2.Budget / 2);
                    double profit = planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price);
                    planet1.Profit(profit);

                    planets.RemoveItem(planet2.Name);

                    return String.Format(OutputMessages.WinnigTheWar, planet1.Name, planet2.Name);

                }
                else  
                {
                    planet2.Spend(planet2.Budget / 2);
                    planet2.Profit(planet1.Budget / 2);
                    double profit = planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price);
                    planet2.Profit(profit);

                    planets.RemoveItem(planet1.Name);

                    return String.Format(OutputMessages.WinnigTheWar, planet2.Name, planet1.Name);
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                double profit = planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price);
                planet1.Profit(profit);

                planets.RemoveItem(planet2.Name);

                return String.Format(OutputMessages.WinnigTheWar, planet1.Name, planet2.Name);
            }
            else
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                double profit = planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price);
                planet2.Profit(profit);

                planets.RemoveItem(planet1.Name);

                return String.Format(OutputMessages.WinnigTheWar, planet2.Name, planet1.Name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (Planet planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        

        
    }
}
