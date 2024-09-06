namespace Medicines.DataProcessor;

using Invoices.Utilities;
using Medicines.Data;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

public class Deserializer
{
    private const string ErrorMessage = "Invalid Data!";
    private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
    private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

    // Mapping table is being used, many-to-many
    public static string ImportPatients(MedicinesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ICollection<Patient> patientsToImport = new List<Patient>();

        ImportPatientDto[] deserializedPatients = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString)!;

        foreach (var patientDto in deserializedPatients)
        {
            if (!IsValid(patientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Patient newPatient = new Patient()
            {
                FullName = patientDto.FullName,
                AgeGroup = (AgeGroup)patientDto.AgeGroup,
                Gender = (Gender)patientDto.Gender,
            };

            // Patient Medicine connection is many to many
            //ICollection<PatientMedicine> patientMedicinesToImport = new List<PatientMedicine>();

            foreach (var medicineId in patientDto.Medicines)
            {
                if (newPatient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PatientMedicine newPatientMedicine = new PatientMedicine()
                {
                    Patient = newPatient,
                    MedicineId = medicineId,
                };

                newPatient.PatientsMedicines.Add(newPatientMedicine);
            }

            //newPatient.PatientsMedicines = patientMedicinesToImport;
            patientsToImport.Add(newPatient);

            sb.AppendLine(string.Format(SuccessfullyImportedPatient, newPatient.FullName, newPatient.PatientsMedicines.Count));
        }

        context.Patients.AddRange(patientsToImport);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportPharmacies(MedicinesContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Pharmacies";

        ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();

        ImportPharmaciesDto[] deserializedPharmacies = xmlHelper.Deserialize<ImportPharmaciesDto[]>(xmlString, xmlRoot);

        foreach (var pharmacyDto in deserializedPharmacies)
        {
            if (!IsValid(pharmacyDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Medicine> medicinesToImport = new List<Medicine>();

            foreach (var medicineDto in pharmacyDto.Medicines)
            {
                if (!IsValid(medicineDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Validate ProductionDate
                bool isProductionDateValid = DateTime
                    .TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate); // Parsed into issueDate

                // Validate ExpiryDate
                bool isExpiryDateValid = DateTime
                    .TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate); // Parsed into dueDate

                if (isProductionDateValid == false || isExpiryDateValid == false || DateTime.Compare(productionDate, expiryDate) >= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Medicine newMedicine = new Medicine()
                {
                    Name = medicineDto.Name,
                    Price = medicineDto.Price,
                    ProductionDate = productionDate,
                    ExpiryDate = expiryDate,
                    Producer = medicineDto.Producer,
                    Category = (Category)medicineDto.Category,
                };

                if (medicinesToImport.Any(m => m.Name == newMedicine.Name && m.Producer == newMedicine.Producer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                medicinesToImport.Add(newMedicine);
            }

            Pharmacy newPharmacy = new Pharmacy()
            {
                Name = pharmacyDto.Name,
                PhoneNumber = pharmacyDto.PhoneNumber,
                IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
            };

            newPharmacy.Medicines = medicinesToImport;

            pharmaciesToImport.Add(newPharmacy);
            sb.AppendLine(String.Format(SuccessfullyImportedPharmacy, newPharmacy.Name, medicinesToImport.Count));
        }

        context.Pharmacies.AddRange(pharmaciesToImport);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
