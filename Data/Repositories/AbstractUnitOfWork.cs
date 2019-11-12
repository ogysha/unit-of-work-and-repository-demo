using System.Collections.Generic;
using Core.Domain;
using Core.Infrastructure;
using Data.Repositories.Persisters;

namespace Data.Repositories
{
    public abstract class AbstractUnitOfWork : IUnitOfWork
    {
        private readonly List<Change> _changes;

        protected AbstractUnitOfWork()
        {
            _changes = new List<Change>();
        }

        public void Commit()
        {
            OpenTransaction();
            foreach (var change in _changes) change.Apply();
            CommitTransaction();
        }

        public virtual void Rollback()
        {
            _changes.Clear();
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new Addition(entity, unitOfWorkRepository));
        }

        public void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new Update(entity, unitOfWorkRepository));
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _changes.Add(new Removal(entity, unitOfWorkRepository));
        }

        protected abstract void OpenTransaction();

        protected abstract void CommitTransaction();
    }
}