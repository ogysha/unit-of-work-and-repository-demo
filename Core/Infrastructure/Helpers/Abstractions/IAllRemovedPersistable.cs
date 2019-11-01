namespace Core.Infrastructure.Helpers.Abstractions
{
    public interface IAllRemovedPersistable : IClearable, IAddable
    {
        void PersistAllDeleted();
    }
}