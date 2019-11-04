using System;
using MongoDB.Driver;

namespace Data.Repositories.MongoDb
{
    public class UnitOfWork : AbstractUnitOfWork, IDisposable
    {
        private readonly MongoClient _mongoClient;
        private IClientSessionHandle _session;

        public UnitOfWork(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public void Dispose()
        {
            _session?.Dispose();
        }

        protected override void OpenTransaction()
        {
            _session = _mongoClient.StartSession();
            _session.StartTransaction();
        }

        protected override void CommitTransaction()
        {
            _session.CommitTransaction();
        }
    }
}