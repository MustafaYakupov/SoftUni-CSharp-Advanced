using Medicines.Data.Models.Enums;

namespace Medicines.Data;

public static class DataConstraints
{
    // byte -> [0, 255] -> 8 bit -> Higher memory efficiency

    // Pharmacy
    public const byte PharmacyNameMaxLength = 50;
    public const byte PharmacyNameMinLength = 2;
    public const string PharmacyPhoneNumberRegex = @"^\(\d{3}\) \d{3}-\d{4}$";
    public const string PharmacyBooleanRegex = @"^(true|false)$";

    // Medicine
    public const byte MedicineNameMaxLength = 150;
    public const byte MedicineNameMinLength = 3;
    public const string MedicinePriceMinValue = "0.01";
    public const string MedicinePriceMaxValue = "1000.00";
    public const byte MedicineProducerNameMaxLenth = 100;
    public const byte MedicineProducerNameMinLenth = 3;
    public const byte MedicineCategoryMinValue = (int)Category.Analgesic;
    public const byte MedicineCategoryMaxValue = (int)Category.Vaccine;

    // Patient
    public const byte PatientNameMaxLength = 100;
    public const byte PatientNameMinLength = 5;
    public const byte PatientAgeGroupMinValue = (int)AgeGroup.Child;
    public const byte PatientAgeGroupMaxValue = (int)AgeGroup.Senior;
    public const byte PatientGenderMinValue = (int)Gender.Male;
    public const byte PatientGenderMaxValue = (int)Gender.Female;



}
