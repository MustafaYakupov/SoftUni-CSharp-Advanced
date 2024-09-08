
using Microsoft.EntityFrameworkCore;

namespace TODOList.Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskDbContext()
        {
            this.Database.EnsureCreated();
        }

       
    }
}
