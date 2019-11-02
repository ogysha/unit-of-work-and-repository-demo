using App.Domain;

namespace App.Infrastructure
{
    public interface IAuthorRepository
    {
        void Add(Author author);
    }
}