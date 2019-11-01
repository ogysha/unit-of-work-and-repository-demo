using Core.Abstractions;
using Core.Entities;

namespace Core.UseCases
{
    public class AddBookInteractor : IHandler
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddBookInteractor(IRepository<Book> booksRepository, IUnitOfWork unitOfWork)
        {
            _booksRepository = booksRepository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(AddBookRequest request)
        {
            _booksRepository.Add(request.Book);
            _unitOfWork.Commit();   
        }
    }

    public interface IHandler<TRequest, TResponse>
    {
    }

    public class AddBookRequest
    {
        public Book Book { get; set; }
    }
}