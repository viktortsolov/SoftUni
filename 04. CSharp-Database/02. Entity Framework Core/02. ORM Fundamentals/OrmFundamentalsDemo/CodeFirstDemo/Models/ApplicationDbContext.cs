using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-J9T9LVF\MSSQLSERVER01;Integrated Security=true;Database=CodeFirstDemo2021");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
