using System.Diagnostics.CodeAnalysis;
using Autofac;
using Client.MongoDb.Modules;
using Core.Application;

namespace Client.MongoDb
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<BookService>();
            builder.RegisterModule<MongoDbModule>();

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}