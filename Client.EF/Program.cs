using System.Diagnostics.CodeAnalysis;
using Autofac;
using Client.Common;
using Client.EF.Modules;

namespace Client.EF
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppCommonModule>();
            builder.RegisterModule<EFModule>();

            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}