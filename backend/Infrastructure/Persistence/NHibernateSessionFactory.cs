using NHibernate;
using NHibernate.Cfg;
    using Npgsql;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
namespace Infrastructure.Persistence
{

public static class DatabaseInitializer
{
    public static void CreateDatabaseIfNotExists(string connectionString, string databaseName)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);

        // Connect to default "postgres" DB first
        builder.Database = "postgres";

        using var connection = new NpgsqlConnection(builder.ConnectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();

        cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{databaseName}'";
        var exists = cmd.ExecuteScalar();

        if (exists == null)
        {
            cmd.CommandText = $"CREATE DATABASE \"{databaseName}\"";
            cmd.ExecuteNonQuery();
        }
    }
}
    public class NHibernateSessionFactory
    {
        private readonly ISessionFactory _factory;
    
        

        public NHibernateSessionFactory()
        {
            var connectionString = "Host=localhost;Port=5432;Database=ecommerce;Username=postgres;Password=postgres";

            _factory = Fluently.Configure()
                .Database(
                    PostgreSQLConfiguration.Standard
                        .ConnectionString(connectionString)        .Dialect<NHibernate.Dialect.PostgreSQL83Dialect>() // ✅ IMPORTANT

                )
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.UserMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.ProductMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.CategoryMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.CartMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.CartItemMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.OrderMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.OrderItemMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.PaymentMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.SessionMap>();
                    m.FluentMappings.AddFromAssemblyOf<Infrastructure.Persistence.Mapping.ProductCategoryMap>();
                }).ExposeConfiguration(cfg =>
{
    cfg.SetProperty("hbm2ddl.auto", "update");
})
                .BuildSessionFactory();
        }

       
    
        public NHibernate.ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    }
}