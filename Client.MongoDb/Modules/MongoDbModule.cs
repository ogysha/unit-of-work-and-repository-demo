using Autofac;
using Data.Mappers.MongoDb;
using Data.Repositories.MongoDb;
using MongoDB.Driver;

namespace Client.MongoDb.Modules
{
    public class MongoDbModule : Module
    {
        private const string ConnectionString = "mongodb://localhost:27017";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().AsImplementedInterfaces();
            builder.RegisterType<BookMapper>().AsSelf();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.Register(c => new MongoClient(ConnectionString))
                .InstancePerLifetimeScope();
        }
    }
}