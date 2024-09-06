using System.ComponentModel.DataAnnotations;

namespace Blog.WEB.ViewModels
{
    public class ArticleEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title is too short")]
        [MaxLength(128)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(8)]
        [MaxLength(4096)]
        public string Content { get; set; } = null!;
    }
}
