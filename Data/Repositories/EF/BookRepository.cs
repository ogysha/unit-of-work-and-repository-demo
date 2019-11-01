using System;
using System.Data.Entity;
using System.Linq;
using App.Domain;
using App.Domain.Builders.Book;
using App.Infrastructure;
using Data.Entities;
using Data.Mappers.Abstractions;
using Book = App.Domain.Book;

namespace Data.Repositories.EF
{
    public class BookRepository : IBookRepository, IUnitOfWorkRepository
    {
        private readonly IAuthorMapper _authorMapper;
        private readonly IBookMapper _bookMapper;
        private readonly BookStoreDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(IUnitOfWork unitOfWork, IBookMapper bookMapper, IAuthorMapper authorMapper,
            BookStoreDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _authorMapper = authorMapper;
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

            foreach (var author in book.Authors)
            {
                var authorDbEntity = _dbContext.Authors.Local.First(a => a.Id == author.Id);

                _dbContext.BookAuthors.Add(new BookAuthor
                {
                    Book = bookDbEntity,
                    Author = authorDbEntity
                });
            }
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
            var bookEntity = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (bookEntity == null) return null;

            var authors = _dbContext.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .Where(ba => ba.Book.Id == id)
                .Select(ba => _authorMapper.ToDomainEntity(ba.Author))
                .ToArray();

            return BookBuilder.CreateNew()
                .WithId(bookEntity.Id)
                .WithTitle(bookEntity.Title)
                .WithIsbn13(bookEntity.Isbn)
                .WithReleaseDate(bookEntity.ReleaseDate)
                .WithPublisher(bookEntity.Publisher)
                .WithAuthors(authors)
                .Build();
        }
    }
}