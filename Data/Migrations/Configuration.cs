using System.Data.Entity.Migrations;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}