using Microsoft.AspNetCore.Identity;

namespace Blog.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Articles = new List<Article>();
        }

        public ICollection<Article> Articles { get; set; }
    }
}
