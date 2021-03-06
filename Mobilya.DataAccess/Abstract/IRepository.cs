using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity:class
    {

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        TEntity Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        ValueTask<TEntity> GetById(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> WithDetails();
    }
}
