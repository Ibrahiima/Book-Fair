using Book_Fair.Models;
using Microsoft.EntityFrameworkCore;


namespace Book_Fair.Context
{
    public class BFDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PIPPO\\IBRAHIM;Initial Catalog=BookFairdb;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
