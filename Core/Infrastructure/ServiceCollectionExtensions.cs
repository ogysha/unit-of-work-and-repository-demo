using Core.Abstractions;
using Core.Domain;
using Core.Entities;
using Core.Infrastructure.Mappers;
using Core.Infrastructure.Repositories;

namespace Core.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MongoFactory>();
            services.AddScoped(sp => sp.GetService<MongoFactory>().MongoClient);
            services.AddScoped(sp => sp.GetService<MongoFactory>().Database);
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IMapper<Entities.Book, Book>, BookMapper>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BookApplicationService>();
            return services;
        }
    }
}