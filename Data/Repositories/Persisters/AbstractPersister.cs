using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    public abstract class AbstractPersister
    {
        protected readonly IAggregateRoot AggregateRoot;
        protected readonly IUnitOfWorkRepository UnitOfWorkRepository;

        protected AbstractPersister(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository)
        {
            AggregateRoot = aggregateRoot;
            UnitOfWorkRepository = unitOfWorkRepository;
        }

        public abstract void Persist();
    }
}