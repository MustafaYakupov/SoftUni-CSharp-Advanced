using Boardgames.Data.Models.Enums;

namespace Boardgames.Data;

public static class DataConstraints
{
    // byte -> [0, 255] -> 8 bit -> Higher memory efficiency

    // Boardgame
    public const byte BoardgameNameMaxLength = 20;
    public const byte BoardgameNameMinLength = 10;
    public const double BoardgameRatingMinValue = 1.00;
    public const double BoardgameRatingMaxValue = 10.00;
    public const int BoardgameYearPublishedMaxValue = 2023;
    public const int BoardgameYearPublishedMinValue = 2018;
    public const byte BoardgameCategoryTypeMinValue = (int)CategoryType.Abstract;
    public const byte BoardgameCategoryTypeMaxValue = (int)CategoryType.Strategy;

    // Seller
    public const byte SellerNameMinLength = 5;
    public const byte SellerNameMaxLength = 20;
    public const byte SellerAddressMinLength = 2;
    public const byte SellerAddressMaxLength = 30;
    public const string SellerWebsiteRegex = "www\\.[A-Za-z0-9-]*\\.com";

    // Creator
    public const byte CreatorFirstAndLastNameMinLength = 2;
    public const byte CreatorFirstAndLastNameMaxLength = 7;


}
