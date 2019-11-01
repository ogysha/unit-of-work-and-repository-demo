using System.Collections.Generic;
using App.Domain;
using App.Infrastructure;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntities;
        private readonly BookStoreDbContext _dbContext;
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