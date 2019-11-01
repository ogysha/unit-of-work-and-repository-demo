using System.Data.Entity;
using Data.Entities;

namespace Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext() : base("BookStoreDbContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}