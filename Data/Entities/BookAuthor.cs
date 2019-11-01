using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Infrastructure;

namespace Data.Entities
{
    public class BookAuthor : IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}