using System.Data.Entity;
using System.Linq;
using Data.Entities.EF;

namespace Data.Repositories.EF
{
    public class UnitOfWork : AbstractUnitOfWork
    {
        private readonly BookStoreDbContext _dbContext;

        public UnitOfWork(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Rollback()
        {
            base.Rollback();

            var changedEntries = _dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntries)
                switch (entry.State)
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

        protected override void OpenTransaction()
        {
        }

        protected override void CommitTransaction()
        {
            _dbContext.SaveChanges();
        }
    }
}