using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private bool sonarMode = false;
        private const int InitialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public void ToggleSonarMode()
        {
            sonarMode = !sonarMode;

            if (sonarMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if (sonarMode == false)
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {(sonarMode ? "ON" : "OFF")}";
        }
    }
}
