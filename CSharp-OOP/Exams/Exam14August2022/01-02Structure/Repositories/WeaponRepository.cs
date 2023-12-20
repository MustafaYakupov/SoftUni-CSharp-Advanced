using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models;

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string weaponTypeName)
        {
            IWeapon weapon = models.FirstOrDefault(w => w.GetType().Name == weaponTypeName);

            return weapon;
        }

        public bool RemoveItem(string weaponTypeName)
        {
            IWeapon weapon = models.FirstOrDefault(w => w.GetType().Name == weaponTypeName);

            if (weapon != null)
            {
                models.Remove(weapon);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
