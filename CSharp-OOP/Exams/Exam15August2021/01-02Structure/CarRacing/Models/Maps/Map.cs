using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return $"Race cannot be completed because both racers are not available!";
            }

            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            double racerOneMultiplier = 0;
            double racerTwoMultiplier = 0;
            double racerOneChanceOfWinning = 0;
            double racerTwoChanceOfWinning = 0;

            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == true)
            {
                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneMultiplier = 1.2;
                }

                if (racerOne.RacingBehavior == "aggressive")
                {
                    racerOneMultiplier = 1.1;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoMultiplier = 1.2;
                }

                if (racerTwo.RacingBehavior == "aggressive")
                {
                    racerTwoMultiplier = 1.1;
                }

                racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;
                racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;
            }

            racerOne.Race();
            racerTwo.Race();

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }
    }
}
