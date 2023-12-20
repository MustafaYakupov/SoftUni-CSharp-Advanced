using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            IPilot pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);

            return $"Pilot {fullName} is created.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            IFormulaOneCar car = null;

            if (nameof(Ferrari) == type)
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (nameof(Williams) == type)
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            carRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }



        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == null || race.Pilots.Contains(pilot) || pilot.CanRace == false)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }
        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            Dictionary<IPilot, double> resultDictionary = new Dictionary<IPilot, double>();

            foreach (var pilot in race.Pilots)
            {
                double score = pilot.Car.RaceScoreCalculator(race.NumberOfLaps);
                resultDictionary.Add(pilot, score);
            }

            var orderedResultDictionary = resultDictionary.OrderByDescending(x => x.Value);

            int counter = 0;
            IPilot winner = null;
            IPilot second = null;
            IPilot third = null;

            foreach (var kvp in orderedResultDictionary)
            {
                counter++;

                if (counter == 1)
                {
                    winner = kvp.Key;
                }
                if (counter == 2)
                {
                    second = kvp.Key;
                }
                if (counter == 3)
                {
                    third = kvp.Key;
                }
            }

            race.TookPlace = true;
            
            winner.WinRace();

            StringBuilder sb = new();

            sb.AppendLine($"Pilot {winner.FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {second.FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot {third.FullName} is third in the {race.RaceName} race.");


            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder sb = new();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
