using NHibernate;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NHibernate.ISession _session;
        private readonly ITransaction _transaction;

        public UnitOfWork(NHibernate.ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_session);
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _session.Dispose();
        }
    }
}