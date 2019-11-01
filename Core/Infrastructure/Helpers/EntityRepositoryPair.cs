using Core.Abstractions;
using Core.Entities;

namespace Core.Infrastructure.Helpers
{
    public class EntityRepositoryPair
    {
        public EntityRepositoryPair(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            Entity = entity;
            Repository = repository;
        }

        public IAggregateRoot Entity { get; }
        public IUnitOfWorkRepository Repository { get; }

        public void PersistNew()
        {
            Repository.PersistCreationOf(Entity);
        }
        
        public void PersistAmended()
        {
            Repository.PersistUpdateOf(Entity);
        }
        
        public void PersistDeleted()
        {
            Repository.PersistDeletionOf(Entity);
        }
    }
}