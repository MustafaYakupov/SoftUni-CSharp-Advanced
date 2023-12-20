using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }

                fullName = value;
            }
        }

        public bool CanRace
        {
            get => canRace;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                canRace = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                car = value;
            }
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set
            {
                numberOfWins = value;
            }
        }


        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
