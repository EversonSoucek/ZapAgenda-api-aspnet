namespace ZapAgenda_api_aspnet.repositories.generic
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T?>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T?> DeleteAsync (int id);
    }
}