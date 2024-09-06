namespace Boardgames.DataProcessor.ImportDto;

using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Data.DataConstraints;

[XmlType(nameof(Creator))]
public class ImportCreatorDto
{
    [XmlElement(nameof(FirstName))]
    [MinLength(CreatorFirstAndLastNameMinLength)]
    [MaxLength(CreatorFirstAndLastNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [XmlElement(nameof(LastName))]
    [MinLength(CreatorFirstAndLastNameMinLength)]
    [MaxLength(CreatorFirstAndLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
}
