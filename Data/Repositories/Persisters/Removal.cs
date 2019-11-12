using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal class Removal : Change
    {
        internal  Removal(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Apply()
        {
            UnitOfWorkRepository.PersistDeletionOf(AggregateRoot);
        }
    }
}