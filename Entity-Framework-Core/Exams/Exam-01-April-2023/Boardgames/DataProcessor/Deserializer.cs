namespace Boardgames.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using Boardgames.Data;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Invoices.Utilities;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Creators";

        ICollection<Creator> creatorsToImport = new List<Creator>();

        ImportCreatorDto[] deserializedCreators = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, xmlRoot);

        foreach (var creatorDto in deserializedCreators)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Creator newCreator = new Creator()
            {
                FirstName = creatorDto.FirstName,
                LastName = creatorDto.LastName,
            };

            ICollection<Boardgame> boardgamesToImport = new List<Boardgame>();

            foreach (var boardgameDto in creatorDto.Boardgames)
            {
                if (!IsValid(boardgameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Boardgame newBoardgame = new Boardgame()
                {
                    Name = boardgameDto.Name,
                    Rating = boardgameDto.Rating,
                    YearPublished = boardgameDto.YearPublished,
                    CategoryType = (CategoryType)boardgameDto.CategoryType,
                    Mechanics = boardgameDto.Mechanics,
                };

                boardgamesToImport.Add(newBoardgame);
            }

            newCreator.Boardgames = boardgamesToImport;

            creatorsToImport.Add(newCreator);
            sb.AppendLine(String.Format(SuccessfullyImportedCreator, newCreator.FirstName, newCreator.LastName, newCreator.Boardgames.Count));
        }

        context.Creators.AddRange(creatorsToImport);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ICollection<Seller> sellersToImport = new List<Seller>();

        ImportSellerDto[] deserializedSellers = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString)!;

        foreach (var sellerDto in deserializedSellers)
        {
            if (!IsValid(sellerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Seller newSeller = new Seller()
            {
                Name = sellerDto.Name,
                Address = sellerDto.Address,
                Country = sellerDto.Country,
                Website = sellerDto.Website,
            };

            foreach (var boardgameId in sellerDto.Boardgames.Distinct())
            {
                if (!context.Boardgames.Any(b => b.Id == boardgameId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                BoardgameSeller newBoargameSeller = new BoardgameSeller()
                {
                    BoardgameId = boardgameId,
                    Seller = newSeller,
                };

                newSeller.BoardgamesSellers.Add(newBoargameSeller);
            }

            sellersToImport.Add(newSeller);

            sb.AppendLine(string.Format(SuccessfullyImportedSeller, newSeller.Name, newSeller.BoardgamesSellers.Count));
        }

        context.Sellers.AddRange(sellersToImport);
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
