using App.Domain;
using App.Infrastructure;

namespace App.Application
{
    public class BookService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _booksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork, IBookRepository booksRepository, IAuthorRepository authorRepository)
        {
            _unitOfWork = unitOfWork;
            _booksRepository = booksRepository;
            _authorRepository = authorRepository;
        }

        public void AddToBookshelf(Book book)
        {
            foreach (var bookAuthor in book.Authors)
            {
                var author = _authorRepository.FindById(bookAuthor.Id);

                if (author == null)
                    _authorRepository.Add(bookAuthor);
            }

            _booksRepository.Add(book);
            _unitOfWork.Commit();
        }
    }
}