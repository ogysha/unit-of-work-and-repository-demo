using App.Domain;
using App.Infrastructure;

namespace App.Application
{
    public class BookService
    {
        private readonly IBookRepository _booksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork, IBookRepository booksRepository)
        {
            _unitOfWork = unitOfWork;
            _booksRepository = booksRepository;
        }

        public void AddToBookshelf(Book book)
        {
            _booksRepository.Add(book);
            _unitOfWork.Commit();
        }
    }
}