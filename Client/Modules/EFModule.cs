using Autofac;
using Data.Entities.EF;
using Data.Mappers.EF;
using Data.Repositories.EF;

namespace Client.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().AsImplementedInterfaces();
            builder.RegisterType<BookMapper>().AsSelf();
            builder.RegisterType<AuthorMapper>().AsSelf();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.Register(c => new BookStoreDbContext())
                .InstancePerLifetimeScope();
        }
    }
}