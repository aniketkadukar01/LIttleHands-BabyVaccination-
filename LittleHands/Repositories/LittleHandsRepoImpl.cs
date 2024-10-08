﻿using LittleHands.CustomHttpExceptions;
using LittleHands.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
                throw new CustomException(HttpStatusCode.NotFound, $"{id} is invalid id.");
            }
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if(entity == null)
            {
                throw new CustomException(HttpStatusCode.NotFound , $"{id} is invalid id.");
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
