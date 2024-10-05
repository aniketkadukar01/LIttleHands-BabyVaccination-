using LittleHands.Data;
using Microsoft.EntityFrameworkCore;

namespace LittleHands.Repositories
{
    public class LittleHandsRepoImpl<T> : ILittleHandsRepo<T> where T : class
    {
        private readonly LittleHandsContext _context;
        private DbSet<T> _dbset;

        public LittleHandsRepoImpl(LittleHandsContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if(entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if(entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
