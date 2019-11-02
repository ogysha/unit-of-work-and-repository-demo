using Core.Domain;

namespace Core.Infrastructure
{
    public interface IBookRepository
    {
        void Add(Book book);

        // void Update(Book book);
        // Book FindById(Guid id);
        // IEnumerable<Book> FindByReleaseDateBetween(DateTime startDate, DateTime endDate);
    }
}