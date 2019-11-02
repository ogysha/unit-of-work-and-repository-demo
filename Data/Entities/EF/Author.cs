using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.EF
{
    public class Author : IDbEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }
        
        [StringLength(128)]
        public string LastName { get; set; }
    }
}