using System.Diagnostics.CodeAnalysis;
using App.Application;
using Autofac;
using Client.Modules;

namespace Client
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<BookService>();

            builder.RegisterModule<EFModule>();
            // builder.RegisterModule<MongoDbModule>();

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}