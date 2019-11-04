using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal class AdditionPersister : ChangePersister
    {
        internal AdditionPersister(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Persist()
        {
            UnitOfWorkRepository.PersistCreationOf(AggregateRoot);
        }
    }
}