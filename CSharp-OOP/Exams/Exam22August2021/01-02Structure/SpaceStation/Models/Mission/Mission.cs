using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<IAstronaut> deadAustronautsToRemove = new List<IAstronaut>();

            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen > 0)
                {
                    List<string> itemsToRemove = new List<string>();

                    foreach (var item in planet.Items)
                    {
                        astronaut.Bag.Items.Add(item);
                        itemsToRemove.Add(item);
                        astronaut.Breath();

                        if (astronaut.Oxygen <= 0)
                        {
                            deadAustronautsToRemove.Add(astronaut);
                            break;
                        }
                    }

                    foreach (var item in itemsToRemove)
                    {
                        planet.Items.Remove(item);
                    }
                }
            }

            foreach (var astronaut in deadAustronautsToRemove)
            {
                astronauts.Remove(astronaut);
            }
        }
    }
}
