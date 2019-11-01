using System;
using App.Application;
using App.Domain.Builders.Author;
using App.Domain.Builders.Book;

namespace EF.Client
{
    internal class Application
    {
        private readonly BookService _bookService;

        public Application(BookService bookService)
        {
            _bookService = bookService;
        }

        public void Run()
        {
            var daveThomas = AuthorBuilder.CreateNew()
                .WithId(Guid.NewGuid())
                .WithFirstName("Dave")
                .WithLastName("Thomas")
                .WithBirthDate(1956, 8, 18)
                .WithBiography("My short bio...")
                .Build();

            var andyHunt = AuthorBuilder.CreateNew()
                .WithId(Guid.NewGuid())
                .WithFirstName("Andy")
                .WithLastName("Hunt")
                .WithBirthDate(1955, 3, 10)
                .WithBiography("My short bio...")
                .Build();

            var pragmaticProgrammerBook = BookBuilder.CreateNew()
                .WithId(Guid.NewGuid())
                .WithTitle("The Pragmatic Programmer: your journey to mastery")
                .WithIsbn13("978-0135957059")
                .WithReleaseDate(2019, 9)
                .WithPublisher("Addison-Wesley Professional")
                .WithAuthors(daveThomas, andyHunt)
                .Build();

            _bookService.AddToBookshelf(pragmaticProgrammerBook);

            Console.WriteLine(@"Added new book: {0}", pragmaticProgrammerBook);
            Console.ReadLine();
        }
    }
}