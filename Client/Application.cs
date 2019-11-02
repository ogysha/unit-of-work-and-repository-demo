using System;
using App.Application;
using App.Domain.Builders.Author;
using App.Domain.Builders.Book;

namespace Client
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
            var andyHunt = AuthorBuilder.CreateNew()
                .WithId(Guid.NewGuid())
                .WithFirstName("Andy")
                .WithLastName("Hunt")
                .Build();

            var pragmaticProgrammerBook = BookBuilder.CreateNew()
                .WithId(Guid.NewGuid())
                .WithTitle("The Pragmatic Programmer: your journey to mastery")
                .WithIsbn13("9780135957059")
                .WithReleaseDate(2019, 9)
                .WithPublisher("Addison-Wesley Professional")
                .WithAuthor(andyHunt)
                .Build();

            _bookService.AddToBookshelf(pragmaticProgrammerBook);

            Console.WriteLine("Added new book: {0}", pragmaticProgrammerBook);
            Console.ReadLine();
        }
    }
}