namespace MongoDb.Client.Helpers.Abstractions
{
    public interface IAllRemovedPersistable : IClearable, IAddable
    {
        void PersistAllDeleted();
    }
}