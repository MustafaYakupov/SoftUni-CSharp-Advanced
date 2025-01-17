﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models;

public class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.AlbumNameMaxLength)]
    public string Name { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    [NotMapped]  // Won't be created in the DB
    public decimal Price => this.Songs.Sum(s => s.Price);

    public int? ProducerId { get; set; }

    [ForeignKey(nameof(ProducerId))]
    public virtual Producer? Producer { get; set; }

    public ICollection<Song> Songs { get; set; }
}
