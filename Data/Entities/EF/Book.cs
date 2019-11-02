using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.EF
{
    public class Book : IDbEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        [StringLength(13)]
        public string Isbn { get; set; }

        [StringLength(255)]
        public string Publisher { get; set; }

        [StringLength(255)]
        public string Author { get; set; }
    }
}