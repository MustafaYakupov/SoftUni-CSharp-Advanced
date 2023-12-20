using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }

        public bool CanBreath
        {
            get => canBreath;
            private set
            {
                canBreath = value;
            }
        }

        public IBag Bag
        {
            get => bag;
            private set
            {
                bag = value;
            }
        }

        public virtual void Breath()
        {
            if (Oxygen == 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 10;
            }
        }
    }
}
