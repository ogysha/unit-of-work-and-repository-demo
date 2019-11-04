using Autofac;
using Core.Application;

namespace Client.Common.Modules
{
    public class ApplicationCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>();
            builder.RegisterType<BookService>();
        }
    }
}