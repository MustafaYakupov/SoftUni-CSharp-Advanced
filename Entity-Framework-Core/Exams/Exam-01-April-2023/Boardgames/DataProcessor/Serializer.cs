namespace Boardgames.DataProcessor;

using Boardgames.Data;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ExportDto;
using Invoices.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Creators";

        ExportCreatorsDto[] creatersToExport = context.Creators
            .AsNoTracking()
            .Where(c => c.Boardgames.Any())
            .Select(c => new ExportCreatorsDto()
            {
                CreatorName = c.FirstName + " " + c.LastName,
                BoardgamesCount = c.Boardgames.Count(),
                Boardgames = c.Boardgames
                    .Select(b => new ExportCreatorsBoardgames()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray(),
            })
            .OrderByDescending(c => c.Boardgames.Count())
            .ThenBy(c => c.CreatorName)
            .ToArray();

        return xmlHelper.Serialize(creatersToExport, xmlRoot);
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        ExportSellersWithMostGamesDto[] sellersToExport = context.Sellers
            .AsNoTracking()
            .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            .Select(s => new ExportSellersWithMostGamesDto()
            {
                Name = s.Name,
                Website = s.Website,
                Boardgames = s.BoardgamesSellers
                    .Select(bs => bs.Boardgame)
                    .Where(b => b.YearPublished >= year && b.Rating <= rating)
                    .Select(b => new ExportSellersBoardgamesDto()
                    {
                        Name = b.Name,
                        Rating = b.Rating,
                        Mechanics = b.Mechanics,
                        Category = b.CategoryType.ToString(),
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToArray(),
            })
            .OrderByDescending(s => s.Boardgames.Count())
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(sellersToExport, Formatting.Indented);
    }
}