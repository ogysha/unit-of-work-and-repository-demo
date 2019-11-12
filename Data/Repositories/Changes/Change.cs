using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Changes
{
    public abstract class Change
    {
        protected readonly IAggregateRoot AggregateRoot;
        protected readonly IUnitOfWorkRepository UnitOfWorkRepository;

        protected Change(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository)
        {
            AggregateRoot = aggregateRoot;
            UnitOfWorkRepository = unitOfWorkRepository;
        }

        public abstract void Apply();
    }
}