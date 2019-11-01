namespace MongoDb.Client.Helpers.Abstractions
{
    public interface IAllNewPersistable : IClearable, IAddable
    {
        void PersistAllNew();
    }
}