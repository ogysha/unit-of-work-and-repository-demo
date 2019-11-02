using System.Collections.Generic;
using App.Domain;
using App.Infrastructure;
using MongoDB.Driver;

namespace Data.Repositories.MongoDb
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _addedEntities;
        private readonly MongoClient _mongoClient;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _removedEntities;
        private readonly Dictionary<IAggregateRoot, IUnitOfWorkRepository> _updatedEntities;

        public UnitOfWork(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updatedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _removedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void Commit()
        {
            using (var session = _mongoClient.StartSession())
            {
                session.StartTransaction();

                foreach (var entity in _addedEntities.Keys) _addedEntities[entity].PersistCreationOf(entity);
                foreach (var entity in _updatedEntities.Keys) _updatedEntities[entity].PersistUpdateOf(entity);
                foreach (var entity in _removedEntities.Keys) _removedEntities[entity].PersistDeletionOf(entity);

                session.CommitTransaction();
            }
        }

        public void Rollback()
        {
            _addedEntities.Clear();
            _updatedEntities.Clear();
            _removedEntities.Clear();
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