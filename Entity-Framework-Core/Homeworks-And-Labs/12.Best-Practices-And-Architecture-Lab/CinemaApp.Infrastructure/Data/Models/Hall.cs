using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Infrastructure.Data.Models;

public class Hall
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public ICollection<CinemaHall> CinemasHalls { get; set; } = new List<CinemaHall>();

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
