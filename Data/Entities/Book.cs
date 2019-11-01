using System;
using System.ComponentModel.DataAnnotations;
using App.Infrastructure;

namespace Data.Entities
{
    public class Book : IDbEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Isbn { get; set; }

        public string Publisher { get; set; }
    }
}