using System;
using System.Data.Entity;
using System.Linq;
using Core.Domain;
using Core.Domain.Builders.Author;
using Core.Domain.Builders.Book;
using Core.Infrastructure;
using Data.Entities.EF;
using Data.Mappers.EF;
using Book = Core.Domain.Book;

namespace Data.Repositories.EF
{
    public class BookRepository : IBookRepository, IUnitOfWorkRepository
    {
        private readonly BookMapper _bookMapper;
        private readonly BookStoreDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(IUnitOfWork unitOfWork, BookMapper bookMapper,
            BookStoreDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _dbContext = dbContext;
        }

        public void Add(Book book)
        {
            _unitOfWork.RegisterAdded(book, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            var book = (Book) entity;
            var bookDbEntity = _bookMapper.ToDbEntity(book);
            _dbContext.Books.Add(bookDbEntity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public Book FindById(Guid id)
        {
            var bookEntity = _dbContext.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
            if (bookEntity == null) return null;

            var authorEntity = bookEntity.Author;
            var author = AuthorBuilder.CreateNew()
                .WithId(authorEntity.Id)
                .WithFirstName(authorEntity.FirstName)
                .WithLastName(authorEntity.LastName)
                .Build();

            return BookBuilder.CreateNew()
                .WithId(bookEntity.Id)
                .WithTitle(bookEntity.Title)
                .WithIsbn13(bookEntity.Isbn)
                .WithReleaseDate(bookEntity.ReleaseDate)
                .WithPublisher(bookEntity.Publisher)
                .WithAuthor(author)
                .Build();
        }
    }
}