using System.Diagnostics.CodeAnalysis;
using Autofac;
using Client.Common;
using Client.MongoDb.Modules;

namespace Client.MongoDb
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppCommonModule>();
            builder.RegisterModule<MongoDbModule>();

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}