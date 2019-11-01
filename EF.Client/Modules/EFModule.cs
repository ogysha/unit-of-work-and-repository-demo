using Autofac;
using Data;
using Data.Repositories;
using Data.Repositories.EF;

namespace EF.Client.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().AsImplementedInterfaces();
            builder.RegisterType<AuthorRepository>().AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Register(c => new BookStoreDbContext()).InstancePerLifetimeScope();
        }
    }
}