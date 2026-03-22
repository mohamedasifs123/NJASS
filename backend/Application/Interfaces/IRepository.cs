namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}