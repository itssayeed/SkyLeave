namespace SkyLeave.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
    }
}