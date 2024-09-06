using Cadastre.Data.Enumerations;

namespace Cadastre.Data;

public static class DataConstraints
{
    // byte -> [0, 255] -> 8 bit -> Higher memory efficiency

    // District
    public const byte DistrictNameMinLength = 2;
    public const byte DistrictNameMaxLength = 80;
    public const byte DistrictPostalCodeMinLength = 8;
    public const byte DistrictPostalCodeMaxLength = 8;
    public const string DistrictPostalCodeRegex = @"^[A-Z]{2}-\d{5}$";
    public const byte DistrictRegionEnumMinValue = (int)Region.SouthEast;
    public const byte DistrictRegionEnumMaxValue = (int)Region.NorthWest;

    // Property
    public const byte PropertyIdentifierMinLength = 16;
    public const byte PropertyIdentifierMaxLength = 20;
    public const int PropertyAreaMinValue = 0;
    public const int PropertyAreaMaxValue = int.MaxValue;
    public const int PropertyDetailsMinLength = 5;
    public const int PropertyDetailsMaxLength = 500;
    public const byte PropertyAddressMinLength = 5;
    public const byte PropertyAddressMaxLength = 200;

    // Citizen
    public const byte CitizenFirstAndLastNameMinLength = 2;
    public const byte CitizenFirstAndLastNameMaxLength = 30;
    public const byte CitizenMaritalStatusMinvalue = (int)MaritalStatus.Unmarried;
    public const byte CitizenMaritalStatusMaxvalue = (int)MaritalStatus.Widowed;
}
