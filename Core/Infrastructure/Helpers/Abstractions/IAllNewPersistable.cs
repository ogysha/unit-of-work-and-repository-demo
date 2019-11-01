namespace Core.Infrastructure.Helpers.Abstractions
{
    public interface IAllNewPersistable : IClearable, IAddable
    {
        void PersistAllNew();
    }
}