using System;
using App.Domain;
using App.Infrastructure;

namespace Data.Repositories.Ado
{
    public class AuthorRepository : IAuthorRepository, IUnitOfWorkRepository
    {
        public Author FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
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