using Instrument.API.Domain.Interfaces;
using Instrument.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Instrument.API.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InstrumentContext _dbContext;

        public BaseRepository(InstrumentContext context)
        {
            _dbContext = context;
        }

        public async Task Add(T entidade)
        {
            await _dbContext.Set<T>().AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Update(T entidade)
        {
            _dbContext.Set<T>().Update(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entidade)
        {
            _dbContext.Set<T>().Remove(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}
