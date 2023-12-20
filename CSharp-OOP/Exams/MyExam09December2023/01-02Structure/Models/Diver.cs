using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catcch;
        private double competitionPoints = 0;
        private bool hasHealthIssues = false;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            catcch = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => catcch.AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(competitionPoints, 1);
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            private set
            {
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;

            if (OxygenLevel <= 0)
            {
                HasHealthIssues = true;
            }

            catcch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
