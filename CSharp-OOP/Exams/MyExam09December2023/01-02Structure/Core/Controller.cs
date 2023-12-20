using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    partial class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver = null;

            if (divers.GetModel(diverName) != null)
            {
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";
            }

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                return $"{diverType} is not allowed in our competition.";
            }

            divers.AddModel(diver);
            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish newFish = null;

            if (fish.GetModel(fishName) != null)
            {
                return $"{fishName} is already allowed -> {nameof(FishRepository)}.";
            }

            if (fishType == "ReefFish")
            {
                newFish = new ReefFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                newFish = new PredatoryFish(fishName, points);
            }
            else
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            fish.AddModel(newFish);
            return $"{fishName} is allowed for chasing.";
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);

            if (diver == null)
            {
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";
            }

            IFish searchedFish = fish.GetModel(fishName);

            if (searchedFish == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            if (diver.HasHealthIssues == true)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (diver.OxygenLevel < searchedFish.TimeToCatch)
            {
                diver.Miss(searchedFish.TimeToCatch);

                return $"{diverName} missed a good {fishName}.";
            }
            else if (diver.OxygenLevel == searchedFish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    diver.Hit(searchedFish);
                    return $"{diverName} hits a {searchedFish.Points}pt. {fishName}.";
                }
                else
                {
                    diver.Miss(searchedFish.TimeToCatch);
                    return $"{diverName} missed a good {fishName}.";
                }
            }
            else
            {
                diver.Hit(searchedFish);
                return $"{diverName} hits a {searchedFish.Points}pt. {fishName}.";
            }
        }

        public string HealthRecovery()
        {
            int count = 0;

            foreach (var diver in divers.Models.Where(d => d.HasHealthIssues == true))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                count++;
            }

            return $"Divers recovered: {count}";
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Diver [ Name: {diver.Name}, Oxygen left: {diver.OxygenLevel}, Fish caught: {diver.Catch.Count}, Points earned: {diver.CompetitionPoints} ]");
            sb.AppendLine("Catch Report:");

            foreach (var f in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(f).ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in divers.Models.Where(d => d.HasHealthIssues == false).OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
