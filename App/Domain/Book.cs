using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain
{
    public class Book : IAggregateRoot
    {
        private const string FieldFormat = "{0}: {1}";

        public Book(Guid id, string title, DateTime releaseDate, string isbn, string publisher,
            IList<Author> authors)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Isbn = isbn;
            Publisher = publisher;
            Authors = authors;
        }

        public Guid Id { get; }

        public string Title { get; }

        public DateTime ReleaseDate { get; }

        public string Isbn { get; }

        public string Publisher { get; }

        public IList<Author> Authors { get; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat(FieldFormat, nameof(Id), Id)
                .AppendLine()
                .AppendFormat(FieldFormat, nameof(Title), Title)
                .AppendLine()
                .AppendFormat(FieldFormat, nameof(ReleaseDate), ReleaseDate)
                .AppendLine()
                .AppendFormat(FieldFormat, nameof(Isbn), Isbn)
                .AppendLine()
                .AppendFormat(FieldFormat, nameof(Publisher), Publisher)
                .AppendLine()
                .Append(nameof(Authors))
                .AppendLine(":")
                .Append(Authors.Aggregate(string.Empty, (result, current) => result + " " + current + Environment.NewLine))
                .ToString();
        }
    }
}