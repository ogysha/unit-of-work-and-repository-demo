using App.Domain;

namespace App.Infrastructure
{
    public interface IBookRepository
    {
        void Add(Book book);

        // void Update(Book book);
        // Book FindById(Guid id);
    }
}