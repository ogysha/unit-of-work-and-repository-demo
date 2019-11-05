using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal  class UpdatePersister : AbstractPersister
    {
        internal  UpdatePersister(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Persist()
        {
            UnitOfWorkRepository.PersistUpdateOf(AggregateRoot);
        }
    }
}