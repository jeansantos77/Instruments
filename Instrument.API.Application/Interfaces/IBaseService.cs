using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Instrument.API.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
    }
}
