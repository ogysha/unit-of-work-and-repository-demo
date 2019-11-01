using System;
using App.Domain;

namespace App.Infrastructure
{
    public interface IAuthorRepository
    {
        Author FindById(Guid id);
        void Add(Author author);
    }
}