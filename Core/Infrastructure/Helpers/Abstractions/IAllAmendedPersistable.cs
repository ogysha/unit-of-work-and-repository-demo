namespace Core.Infrastructure.Helpers.Abstractions
{
    public interface IAllAmendedPersistable : IClearable, IAddable
    {
        void PersistAllAmended();
    }
}