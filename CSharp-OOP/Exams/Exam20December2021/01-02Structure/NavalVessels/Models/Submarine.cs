using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const int InitialArmorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public void ToggleSubmergeMode()
        {
            submergeMode = !submergeMode;

            if (submergeMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (submergeMode == false)
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {(submergeMode ? "ON" : "OFF")}";
        }
    }
}
