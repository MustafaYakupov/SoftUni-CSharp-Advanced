using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, booths.Models.Count, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            if (booths.Models.Any(x => x.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (nameof(Gingerbread) == delicacyTypeName)
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (nameof(Stolen) == delicacyTypeName)
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            booths.Models.FirstOrDefault(x => x.BoothId == boothId).DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (size.ToLower() != "small"
                && size.ToLower() != "middle"
                && size.ToLower() != "large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booths.Models.Any(c => c.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size)))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (nameof(Hibernation) == cocktailTypeName)
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (nameof(MulledWine) == cocktailTypeName)
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            IBooth availableBooth = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (availableBooth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int count = int.Parse(tokens[2]);
            string size = null;

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth  = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(x => x.Name == itemName) == false
                && booth.DelicacyMenu.Models.Any(x => x.Name == itemName) == false)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == nameof(MulledWine)
                || itemTypeName == nameof(Hibernation))
            {
                size = tokens[3];

                var cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * count);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }

            if (itemTypeName == nameof(Gingerbread)
                || itemTypeName == nameof(Stolen))
            {
                var delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * count);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }

            return null;
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            booth.Charge();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            StringBuilder sb = new StringBuilder();

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            sb.AppendLine($"Booth: {booth.BoothId}");
            sb.AppendLine($"Capacity: {booth.Capacity}");
            sb.AppendLine($"Turnover: {booth.Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var cocktail in booth.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine($"-Delicacy  menu:");

            foreach (var delicacy in booth.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
