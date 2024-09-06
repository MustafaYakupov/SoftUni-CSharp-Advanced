namespace Medicines.DataProcessor;

using Invoices.Utilities;
using Medicines.Data;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

public class Serializer
{
    public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
    {
        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Patients";

        ExportPatientDto[] patientsToExport = context.Patients.AsNoTracking()
            .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= DateTime.Parse(date)))
            .Select(p => new ExportPatientDto()
            {
                Name = p.FullName,
                AgeGroup = p.AgeGroup.ToString(),
                Gender = p.Gender.ToString().ToLower(),
                Medicines = p.PatientsMedicines
                    .Select(pm => pm.Medicine)
                    .Where(m => m.ProductionDate >= DateTime.Parse(date))
                    .OrderByDescending(m => m.ExpiryDate)
                    .ThenBy(m => m.Price)
                    .Select(m => new ExportPatientMedicineDto()
                    {
                        Name = m.Name,
                        Price = m.Price.ToString("F2"),
                        Producer = m.Producer,
                        BestBefore = m.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Category = m.Category.ToString().ToLower(),
                    })
                    .ToArray()
            })
            .OrderByDescending(p => p.Medicines.Length)
            .ThenBy(p => p.Name)
            .ToArray();


        return xmlHelper.Serialize(patientsToExport, xmlRoot);
    }

    public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
    {
        ExportMedicineDto[] medicinesToExport = context.Medicines
            .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop == true)
            .OrderBy(m => m.Price)
            .ThenBy(m => m.Name)
            .Select(m => new ExportMedicineDto()
            {
                Name = m.Name,
                Price = m.Price.ToString("F2"),
                Pharmacy = new ExportMedicinePharmacyDto()
                {
                    Name = m.Pharmacy.Name,
                    PhoneNumber = m.Pharmacy.PhoneNumber,
                }
            })
            .ToArray();

        return JsonConvert.SerializeObject(medicinesToExport, Formatting.Indented);
    }
}
