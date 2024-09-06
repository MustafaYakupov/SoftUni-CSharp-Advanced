using Boardgames.Data.Models.Enums;

namespace Boardgames.DataProcessor.ExportDto;

public class ExportSellersBoardgamesDto
{
    public string Name { get; set; } = null!;

    public double Rating { get; set; }

    public string Mechanics { get; set; } = null!;

    public string Category { get; set; } 
}
