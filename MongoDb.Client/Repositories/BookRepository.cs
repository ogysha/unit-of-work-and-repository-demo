using System.Collections.Generic;
using Book = MongoDb.Client.Entities.Book;

namespace MongoDb.Client.Repositories
{
    public class BookRepository : IRepository<Domain.Book>, IUnitOfWorkRepository
    {
        private const string Name = "Books";
        private readonly IMongoCollection<Book> _books;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Book, Domain.Book> _bookMapper;

        public BookRepository(IUnitOfWork unitOfWork, IMongoDatabase database, IMapper<Book, Domain.Book> bookMapper)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _books = database.GetCollection<Book>(Name);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            Book book = _bookMapper.ToDocument((Domain.Book) entity);
            _books.InsertOne(book);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            Book updatedBook = _bookMapper.ToDocument((Domain.Book) entity);
            _books.ReplaceOne(book => book.Id == updatedBook.Id, updatedBook);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            Book bookToDelete = _bookMapper.ToDocument((Domain.Book) entity);
            _books.DeleteOne(book => book.Id == bookToDelete.Id);
        }

        public void Add(Domain.Book entity)
        {
            _unitOfWork.RegisterNew(entity, this);
        }

        public void Update(Domain.Book entity)
        {
            _unitOfWork.RegisterAmended(entity, this);
        }

        public void Remove(Domain.Book entity)
        {
            _unitOfWork.RegisterDeleted(entity, this);
        }

        public IEnumerable<Domain.Book> FindAll()
        {
            return _books.Find(FilterDefinition<Book>.Empty).ToEnumerable()
                .Select(book => _bookMapper.ToDomain(book));
        }

        public Domain.Book FindOne(string id)
        {
            var book =_books.Find(b => b.Id.ToString() == id).ToEnumerable()
                .FirstOrDefault();

            return _bookMapper.ToDomain(book);
        }
    }
}