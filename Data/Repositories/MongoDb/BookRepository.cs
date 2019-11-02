using App.Domain;
using App.Infrastructure;
using Data.Mappers.MongoDb;
using MongoDB.Driver;
using Book = Data.Entities.MongoDb.Book;

namespace Data.Repositories.MongoDb
{
    public class BookRepository : IBookRepository, IUnitOfWorkRepository
    {
        private const string Name = "Books";
        private readonly BookMapper _bookMapper;
        private readonly IMongoCollection<Book> _books;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(IUnitOfWork unitOfWork, BookMapper bookMapper, MongoClient mongoClient)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _books = mongoClient.GetCollection<Book>(Name);
        }

        public void Add(App.Domain.Book book)
        {
            _unitOfWork.RegisterAdded(book, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            var book = _bookMapper.ToDbEntity((App.Domain.Book) entity);
            _books.InsertOne(book);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            var updatedBook = _bookMapper.ToDbEntity((App.Domain.Book) entity);
            _books.ReplaceOne(book => book.Id == updatedBook.Id, updatedBook);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            var bookToDelete = _bookMapper.ToDbEntity((App.Domain.Book) entity);
            _books.DeleteOne(book => book.Id == bookToDelete.Id);
        }
    }
}