using Core.Domain;

namespace Core.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void Commit();
        void Rollback();
    }
}