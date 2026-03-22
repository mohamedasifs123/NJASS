using NHibernate;
using NHibernate.Linq;
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

        public async Task AddAsync(T entity)
        {
            await _session.SaveAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _session.UpdateAsync(entity);
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _session.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _session.Query<T>().ToListAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}