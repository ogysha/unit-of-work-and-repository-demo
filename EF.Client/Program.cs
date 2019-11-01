using System.Diagnostics.CodeAnalysis;
using App.Application;
using Autofac;
using Data.Mappers;
using EF.Client.Modules;

namespace EF.Client
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<BookService>();
            builder.RegisterType<BookMapper>().AsImplementedInterfaces();
            builder.RegisterType<AuthorMapper>().AsImplementedInterfaces();
            builder.RegisterModule<EFModule>();

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}