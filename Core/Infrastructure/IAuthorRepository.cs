using Core.Domain;

namespace Core.Infrastructure
{
    public interface IAuthorRepository
    {
        void Add(Author author);
    }
}