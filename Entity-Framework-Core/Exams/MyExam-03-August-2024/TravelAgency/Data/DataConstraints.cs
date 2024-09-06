namespace TravelAgency.Data;

public static class DataConstraints
{
    // Customer
    public const int CustomerFullNameMinLength = 4;
    public const int CustomerFullNameMaxLength = 60;
    public const int CustomerEmailMinLength = 6;
    public const int CustomerEmailMaxLength = 50;
    public const string CustomerPhoneNumberRegex = "^\\+\\d{12}$";

    // Guide
    public const int GuideFullNameMinLength = 4;
    public const int GuideFullNameMaxLength = 60;
    public const int GuideLanguageEnumMinValue = 0;
    public const int GuideLanguageEnumMaxValue = 4;

    // TourPackage
    public const int TourPackageNameMinLength = 2;
    public const int TourPackageNameMaxLength = 40;
    public const int TourPackageDescriptionMaxLength = 200;
    public const decimal TourPackagePriceMinValue = 0.00m;
    public const decimal TourPackagePriceMaxValue = decimal.MaxValue;
}
