
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.Entities.EF.BookStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}