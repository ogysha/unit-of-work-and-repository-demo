using Core.Domain;
using Db = Data.Entities.EF;

namespace Data.Mappers.EF
{
    public class AuthorMapper : IDomainToDbMapper<Db.Author, Author>
    {
        public Db.Author ToDbEntity(Author author)
        {
            return new Db.Author
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}