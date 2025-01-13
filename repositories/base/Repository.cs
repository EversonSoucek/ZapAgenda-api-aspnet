using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;

namespace ZapAgenda_api_aspnet.repositories.generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CoreDBContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(CoreDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}