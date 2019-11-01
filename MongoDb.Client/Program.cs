using System.Diagnostics.CodeAnalysis;
using Autofac;

namespace MongoDb.Client
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}