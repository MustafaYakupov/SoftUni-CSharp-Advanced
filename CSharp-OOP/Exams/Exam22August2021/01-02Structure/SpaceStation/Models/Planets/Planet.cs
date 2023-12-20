using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private List<string> items;
        private string name;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();

        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                name = value;
            }
        }

        public ICollection<string> Items => items;
    }
}
