using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal class RemovalPersister : ChangePersister
    {
        internal  RemovalPersister(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Persist()
        {
            UnitOfWorkRepository.PersistDeletionOf(AggregateRoot);
        }
    }
}