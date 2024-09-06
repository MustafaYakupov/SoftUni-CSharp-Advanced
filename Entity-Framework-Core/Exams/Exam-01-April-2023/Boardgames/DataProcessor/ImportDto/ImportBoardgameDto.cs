namespace Boardgames.DataProcessor.ImportDto;

using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Data.DataConstraints;


[XmlType(nameof(Boardgame))]
public class ImportBoardgameDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(BoardgameNameMinLength)]
    [MaxLength(BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Rating))]
    [Range(BoardgameRatingMinValue, BoardgameRatingMaxValue)]
    public double Rating { get; set; }

    [Required]
    [XmlElement(nameof(YearPublished))]
    [Range(BoardgameYearPublishedMinValue, BoardgameYearPublishedMaxValue)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement(nameof(CategoryType))]
    [Range(BoardgameCategoryTypeMinValue, BoardgameCategoryTypeMaxValue)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement(nameof(Mechanics))]
    public string Mechanics { get; set; } = null!;
}
