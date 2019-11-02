using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using App.Domain;
using App.Infrastructure;
using Data.Entities.EF;

namespace Data.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _removedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _updatedEntities;

        public UnitOfWork(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updatedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _removedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void Commit()
        {
            foreach (var entity in _addedEntities.Keys) _addedEntities[entity].PersistCreationOf(entity);
            foreach (var entity in _updatedEntities.Keys) _updatedEntities[entity].PersistUpdateOf(entity);
            foreach (var entity in _removedEntities.Keys) _removedEntities[entity].PersistDeletionOf(entity);

            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _addedEntities.Clear();
            _updatedEntities.Clear();
            _removedEntities.Clear();

            var changedEntries = _dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntries)
            {
                switch(entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_addedEntities.ContainsKey(entity)) _addedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_updatedEntities.ContainsKey(entity)) _updatedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!_removedEntities.ContainsKey(entity)) _removedEntities.Add(entity, unitOfWorkRepository);
        }
    }
}