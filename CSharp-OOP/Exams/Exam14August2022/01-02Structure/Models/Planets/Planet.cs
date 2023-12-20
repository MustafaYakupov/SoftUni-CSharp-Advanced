using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
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

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

                }
                budget = value;
            }
        }

        public double MilitaryPower => CalculatePower();

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }
        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (Army.Count > 0)
            {
                sb.Append($"--Forces: {string.Join(", ", Army.Select(x => x.GetType().Name))}");

            }
            else
            {
                sb.Append($"--Forces: No units");
            }

            sb.AppendLine();

            if (Weapons.Count > 0)
            {
                sb.Append($"--Combat equipment: {string.Join(", ", Weapons.Select(x => x.GetType().Name))}");

            }
            else
            {
                sb.Append($"--Combat equipment: No weapons");
            }

            sb.AppendLine();

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        private double CalculatePower()
        {
            double result = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return Math.Round(result, 3);
        }
    }
}
