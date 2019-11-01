namespace MongoDb.Client.Helpers.Abstractions
{
    public interface IAllAmendedPersistable : IClearable, IAddable
    {
        void PersistAllAmended();
    }
}