using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal class Addition : Change
    {
        internal Addition(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Apply()
        {
            UnitOfWorkRepository.PersistCreationOf(AggregateRoot);
        }
    }
}