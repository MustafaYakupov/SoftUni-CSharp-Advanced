namespace Boardgames.DataProcessor.ExportDto;

public class ExportSellersWithMostGamesDto
{
    public string Name { get; set; } = null!;

    public string Website { get; set; } = null!;

    public ExportSellersBoardgamesDto[] Boardgames { get; set; }
}
