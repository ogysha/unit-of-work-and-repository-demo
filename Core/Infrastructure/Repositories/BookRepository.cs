using System.Collections.Generic;
using Core.Abstractions;
using Core.Entities;
using Book = Core.Infrastructure.Entities.Book;

namespace Core.Infrastructure.Repositories
{
    public class BookRepository : IRepository<global::Core.Entities.Book>, IUnitOfWorkRepository
    {
        private const string Name = "Books";
        private readonly IMongoCollection<Book> _books;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Book, global::Core.Entities.Book> _bookMapper;

        public BookRepository(IUnitOfWork unitOfWork, IMongoDatabase database, IMapper<Book, global::Core.Entities.Book> bookMapper)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _books = database.GetCollection<Book>(Name);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            Book book = _bookMapper.ToDocument((global::Core.Entities.Book) entity);
            _books.InsertOne(book);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            Book updatedBook = _bookMapper.ToDocument((global::Core.Entities.Book) entity);
            _books.ReplaceOne(book => book.Id == updatedBook.Id, updatedBook);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            Book bookToDelete = _bookMapper.ToDocument((global::Core.Entities.Book) entity);
            _books.DeleteOne(book => book.Id == bookToDelete.Id);
        }

        public void Add(global::Core.Entities.Book entity)
        {
            _unitOfWork.RegisterNew(entity, this);
        }

        public void Update(global::Core.Entities.Book entity)
        {
            _unitOfWork.RegisterAmended(entity, this);
        }

        public void Remove(global::Core.Entities.Book entity)
        {
            _unitOfWork.RegisterDeleted(entity, this);
        }

        public IEnumerable<global::Core.Entities.Book> FindAll()
        {
            return _books.Find(FilterDefinition<Book>.Empty).ToEnumerable()
                .Select(book => _bookMapper.ToDomain(book));
        }

        public global::Core.Entities.Book FindOne(string id)
        {
            var book =_books.Find(b => b.Id.ToString() == id).ToEnumerable()
                .FirstOrDefault();

            return _bookMapper.ToDomain(book);
        }
    }
}