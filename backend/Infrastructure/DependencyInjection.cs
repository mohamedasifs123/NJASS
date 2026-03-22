
using Application.Services;
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
var connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
            services.AddScoped<UserService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<CartService>();
            services.AddScoped<CartItemService>();
            services.AddScoped<OrderService>();
            services.AddScoped<OrderItemService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<SessionService>();
            services.AddScoped<ProductCategoryService>();

DatabaseInitializer.CreateDatabaseIfNotExists(connectionString, "ecommerce");
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