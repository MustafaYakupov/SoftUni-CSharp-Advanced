﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;
        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            Oxygen -= 5;
        }
    }
}
