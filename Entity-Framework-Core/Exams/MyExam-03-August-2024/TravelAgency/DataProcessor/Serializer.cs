using Invoices.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor;

public class Serializer
{
    public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Guides";

        ExportGuideDto[] guidesToExport = context.Guides
            .Where(g => g.Language == Language.Spanish)
            .OrderByDescending(g => g.TourPackagesGuides.Count)
            .ThenBy(g => g.FullName)
            .Select(g => new ExportGuideDto()
            {
                FullName = g.FullName,
                TourPackages = g.TourPackagesGuides
                    .Select(tpg => tpg.TourPackage)
                    .OrderByDescending(tp => tp.Price)
                    .ThenBy(tp => tp.PackageName)
                    .Select(tp => new GuideTourPackagesDto()
                    {
                        Name = tp.PackageName,
                        Description = tp.Description,
                        Price = tp.Price,
                    })
                    .ToArray(),
            })
            .ToArray();

        return xmlHelper.Serialize(guidesToExport, xmlRoot);
    }

    public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
    {
        var customersToExport = context.Customers
            .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
            .Select(c => new
            {
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                Bookings = c.Bookings
                    .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                    .OrderBy(b => b.BookingDate)
                    .Select(b => new
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                    })
            })
            .OrderByDescending(c => c.Bookings.Count())
            .ThenBy(c => c.FullName)
            .ToArray();

        return JsonConvert.SerializeObject(customersToExport, Formatting.Indented);
    }
}
