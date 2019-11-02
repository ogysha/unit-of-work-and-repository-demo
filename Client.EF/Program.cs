using System.Diagnostics.CodeAnalysis;
using Autofac;
using Client.EF.Modules;
using Core.Application;

namespace Client.EF
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

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}