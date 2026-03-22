using NHibernate;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NHibernate.ISession _session;

        public Repository(NHibernate.ISession session)
        {
            _session = session;
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public T Get(Guid id)
        {
            return _session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }
}