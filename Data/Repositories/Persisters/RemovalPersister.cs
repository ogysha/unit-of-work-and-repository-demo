using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal class RemovalPersister : AbstractPersister
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