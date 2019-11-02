using System;

namespace App.Domain.Builders
{
    public class BookBuilder : IWithBookId, IWithTitle, IWithIsbn, IWithPublisher, IWithReleaseDate, IWithAuthor,
        IBuildBook
    {
        private string _author;
        private Guid _id;
        private string _isbn;
        private string _publisher;
        private DateTime _releaseDate;
        private string _title;

        public Book Build()
        {
            return new Book(_id, _title, _releaseDate, _isbn, _publisher, _author);
        }

        public IWithTitle WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public IWithReleaseDate WithIsbn13(string isbn)
        {
            _isbn = isbn;
            return this;
        }

        public IWithAuthor WithPublisher(string publisher)
        {
            _publisher = publisher;
            return this;
        }

        public IWithPublisher WithReleaseDate(DateTime releaseDate)
        {
            _releaseDate = releaseDate;
            return this;
        }

        public IWithPublisher WithReleaseDate(int year, int month, int day = 1)
        {
            _releaseDate = new DateTime(year, month, day);
            return this;
        }

        public IWithIsbn WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IBuildBook WithAuthor(string author)
        {
            _author = author;
            return this;
        }

        public static IWithBookId CreateNew()
        {
            return new BookBuilder();
        }
    }
}