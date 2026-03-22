using Application.Interfaces;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        void Commit();
        void Rollback();
    }
}