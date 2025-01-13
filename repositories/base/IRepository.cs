namespace ZapAgenda_api_aspnet.repositories.generic
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
    }
}