namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstraints;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CreatorFirstAndLastNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(CreatorFirstAndLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Boardgame> Boardgames { get; set; }
}
