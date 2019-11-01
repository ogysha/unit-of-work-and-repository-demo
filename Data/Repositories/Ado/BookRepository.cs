using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using App.Domain;
using App.Domain.Builders.Book;
using App.Infrastructure;
using Data.Entities;
using Author = Data.Entities.Author;
using Book = App.Domain.Book;

namespace Data.Repositories.Ado
{
    public class BookRepository : IBookRepository, IUnitOfWorkRepository
    {
        private readonly IMapper<Entities.Book, Book> _bookMapper;
        private readonly IMapper<Author, App.Domain.Author> _authorMapper;
        private readonly SqlConnection _sqlConnection;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(IUnitOfWork unitOfWork, IMapper<Entities.Book, Book> bookMapper,
            IMapper<Author, App.Domain.Author> authorMapper, SqlConnection sqlConnection)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
            _authorMapper = authorMapper;
            _sqlConnection = sqlConnection;
        }

        public void Add(Book book)
        {
            _unitOfWork.RegisterAdded(book, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            var book = (Book) entity;

            var insertIntoBookCommand = new SqlCommand(SqlConstants.InsertIntoBookSql, _sqlConnection);
            insertIntoBookCommand.Parameters.AddWithValue("@Title", book.Title);
            insertIntoBookCommand.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
            insertIntoBookCommand.Parameters.AddWithValue("@Isbn", book.Isbn);
            insertIntoBookCommand.Parameters.AddWithValue("@Publisher", book.Publisher);

            insertIntoBookCommand.ExecuteNonQuery();

            foreach (var author in book.Authors)
            {
                var queryAuthor = new SqlCommand(SqlConstants.InsertIntoBookSql, _sqlConnection);

                using (resource)
                {
                    
                }
                if (authorDbEntity != null)
                {
                    _dbContext.BookAuthors.Add(new BookAuthor
                    {
                        Book = bookDbEntity,
                        Author = authorDbEntity
                    });
                }
                else
                {
                    _dbContext.BookAuthors.Add(new BookAuthor
                    {
                        Book = bookDbEntity,
                        Author = _authorMapper.ToDbEntity(author)
                    });
                }
            }
        }

        private void InsertIntoBook(Book book)
        {
            using (var sqlCommand = new SqlCommand(SqlConstants.InsertIntoBookSql, _sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Title", book.Title);
                sqlCommand.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
                sqlCommand.Parameters.AddWithValue("@Isbn", book.Isbn);
                sqlCommand.Parameters.AddWithValue("@Publisher", book.Publisher);

                sqlCommand.ExecuteNonQuery();
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
    }
}