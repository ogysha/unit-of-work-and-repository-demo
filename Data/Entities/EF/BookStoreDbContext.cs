using System.Data.Entity;

namespace Data.Entities.EF
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}