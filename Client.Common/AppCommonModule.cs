using Autofac;
using Core.Application;

namespace Client.Common
{
    public class AppCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>();
            builder.RegisterType<BookService>();
        }
    }
}