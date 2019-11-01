using App.Domain;

namespace App.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void Commit();
    }
}