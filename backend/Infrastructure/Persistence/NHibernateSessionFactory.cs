using NHibernate;
using NHibernate.Cfg;

namespace Infrastructure.Persistence
{
    public class NHibernateSessionFactory
    {
        private readonly ISessionFactory _factory;

        public NHibernateSessionFactory()
        {
            var cfg = new Configuration();

            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = "Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=postgres";
                db.Driver<NHibernate.Driver.NpgsqlDriver>();
                db.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
            });

            cfg.AddAssembly(typeof(Domain.Entities.User).Assembly);

            _factory = cfg.BuildSessionFactory();
        }

        public NHibernate.ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    }
}