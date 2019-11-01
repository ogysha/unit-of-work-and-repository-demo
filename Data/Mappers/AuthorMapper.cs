using App.Domain;
using App.Domain.Builders.Author;
using Data.Mappers.Abstractions;

namespace Data.Mappers
{
    public class AuthorMapper : IAuthorMapper
    {
        public Author ToDomainEntity(Entities.Author author)
        {
            return AuthorBuilder.CreateNew()
                .WithId(author.Id)
                .WithFirstName(author.FirstName)
                .WithLastName(author.LastName)
                .WithBirthDate(author.BirthDate)
                .WithBiography(author.Biography)
                .Build();
        }

        public Entities.Author ToDbEntity(Author author)
        {
            return new Entities.Author
            {
                Id = author.Id,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}