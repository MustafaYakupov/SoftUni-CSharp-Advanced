using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int exploredPlantesCounter = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            astronauts.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            IPlanet planet = planets.FindByName(planetName);

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            int initialAstroanutsCount = suitableAstronauts.Count;
            IMission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);

            int deadAstronauts = initialAstroanutsCount -  suitableAstronauts.Count;
            exploredPlantesCounter++;

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlantesCounter} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");

                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    foreach (var item in astronaut.Bag.Items.SkipLast(1))
                    {
                        sb.Append($"{item}, ");
                    }

                    sb.AppendLine($"{astronaut.Bag.Items.Last()}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
