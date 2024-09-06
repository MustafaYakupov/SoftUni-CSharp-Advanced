using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Infrastructure.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
