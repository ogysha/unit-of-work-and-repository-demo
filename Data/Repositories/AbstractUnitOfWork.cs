using System.Collections.Generic;
using Core.Domain;
using Core.Infrastructure;
using Data.Repositories.Persisters;

namespace Data.Repositories
{
    public abstract class AbstractUnitOfWork : IUnitOfWork
    {
        private readonly List<ChangePersister> _changes;

        protected AbstractUnitOfWork()
        {
            _changes = new List<ChangePersister>();
        }

        public void Commit()
        {
            OpenTransaction();
            foreach (var change in _changes) change.Persist();
            CommitTransaction();
        }

        public virtual void Rollback()
        {
            _changes.Clear();
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new AdditionPersister(entity, unitOfWorkRepository));
        }

        public void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new UpdatePersister(entity, unitOfWorkRepository));
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new RemovalPersister(entity, unitOfWorkRepository));
        }

        protected abstract void OpenTransaction();

        protected abstract void CommitTransaction();
    }
}