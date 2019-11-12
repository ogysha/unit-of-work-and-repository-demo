using Core.Domain;
using Core.Infrastructure;

namespace Data.Repositories.Persisters
{
    internal  class Update : Change
    {
        internal  Update(IAggregateRoot aggregateRoot, IUnitOfWorkRepository unitOfWorkRepository) : base(
            aggregateRoot, unitOfWorkRepository)
        {
        }

        public override void Apply()
        {
            UnitOfWorkRepository.PersistUpdateOf(AggregateRoot);
        }
    }
}