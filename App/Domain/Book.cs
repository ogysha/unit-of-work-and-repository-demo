using System;

namespace App.Domain
{
    public class Book : IAggregateRoot
    {
        public Book(Guid id, string title, DateTime releaseDate, string isbn, string publisher, Author author)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Isbn = isbn;
            Publisher = publisher;
            Author = author;
        }

        public Guid Id { get; }

        public string Title { get; }

        public DateTime ReleaseDate { get; }

        public string Isbn { get; }

        public string Publisher { get; }

        public Author Author { get; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(ReleaseDate)}: {ReleaseDate}, {nameof(Isbn)}: {Isbn}, {nameof(Publisher)}: {Publisher}, {nameof(Author)}: {Author}";
        }
    }
}