using Microsoft.EntityFrameworkCore;
using Practical_18.Models.Data;
using Practical_18.Repository.Interface;

namespace Practical_18.Repository.Implement
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            var existing = await _dbSet.FindAsync(entity);
            _dbSet.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing != null)
            {
                return existing;
            }
            throw new Exception("User not found");
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
