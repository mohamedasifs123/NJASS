
using Infrastructure.Persistence;
using Infrastructure.UnitOfWork;
using NHibernate;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // NHibernate SessionFactory
            services.AddSingleton<NHibernateSessionFactory>();

            // NHibernate Session (per request)
            services.AddScoped<NHibernate.ISession>(provider =>
            {
                var factory = provider.GetRequiredService<NHibernateSessionFactory>();
                return factory.OpenSession();
            });

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}