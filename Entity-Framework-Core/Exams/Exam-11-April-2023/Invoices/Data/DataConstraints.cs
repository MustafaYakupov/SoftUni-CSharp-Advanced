using Invoices.Data.Models.Enums;

namespace Invoices.Data;

public static class DataConstraints
{
    // byte -> [0, 255] -> 8 bit -> Higher memory efficiency
    // Product
    public const byte ProductNameMinLength = 9;
    public const byte ProductNameMaxLength = 30;
    public const string ProductPriceMinvalue = "5.00";
    public const string ProductPriceMaxvalue = "1000.00";
    public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
    public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;

    // Address
    public const byte AddressStreetNameMinLength = 10;
    public const byte AddressStreetNameMaxLength = 20;
    public const byte AddressCityMinLength = 5;
    public const byte AddressCityMaxLength = 15;
    public const byte CountryMinLength = 5;
    public const byte CountryMaxLength = 15;

    // Invoice
    public const int NumberMaxLength = 1_500_000_000;
    public const int NumberMinLength = 1_000_000_000;
    public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
    public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;

    // Client
    public const byte ClientNameMaxLength = 25;
    public const byte ClientNameMinLength = 10;
    public const byte NumberVatMaxLenght = 15;
    public const byte NumberVatMinLenght = 10;

}
