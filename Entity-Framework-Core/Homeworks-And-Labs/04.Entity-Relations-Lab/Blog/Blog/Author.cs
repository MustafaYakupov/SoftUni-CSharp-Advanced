using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo;

[Table("Authors", Schema = "blg")]
public class Author
{
    [Key]
    public int AuthorId { get; set; } // Not null by default

    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; } = null!; // Not null

    public int? BlogId { get; set; } // nullable

    [ForeignKey(nameof(BlogId))]
    public Blog? Blog { get; set; } // nullable
}
