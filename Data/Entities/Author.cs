using System;
using System.ComponentModel.DataAnnotations;
using App.Infrastructure;

namespace Data.Entities
{
    public class Author : IDbEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
    }
}