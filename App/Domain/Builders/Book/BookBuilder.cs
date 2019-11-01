using System;
using System.Collections.Generic;

namespace App.Domain.Builders.Book
{
    public class BookBuilder : IWithBookId, IWithTitle, IWithIsbn, IWithPublisher, IWithReleaseDate, IWithAuthors,
        IBuildBook
    {
        private IList<Domain.Author> _authors;
        private Guid _id;
        private string _isbn;
        private string _publisher;
        private DateTime _releaseDate;
        private string _title;

        public Domain.Book Build()
        {
            return new Domain.Book(_id, _title, _releaseDate, _isbn, _publisher, _authors);
        }

        public IBuildBook WithAuthors(params Domain.Author[] authors)
        {
            _authors = authors;
            return this;
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

        public IWithAuthors WithPublisher(string publisher)
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

        public static IWithBookId CreateNew()
        {
            return new BookBuilder();
        }
    }
}