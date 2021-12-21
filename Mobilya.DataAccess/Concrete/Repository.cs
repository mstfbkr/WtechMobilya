using Microsoft.EntityFrameworkCore;
using Mobilya.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Mobilya.DataAccess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MobilyaDBContext _mobilyaDBContext;
        public Repository(MobilyaDBContext mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _mobilyaDBContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {

            await _mobilyaDBContext.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _mobilyaDBContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _mobilyaDBContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _mobilyaDBContext.Set<TEntity>().FindAsync(id);

        }

        public void RemoveAsync(TEntity entity)
        {
            _mobilyaDBContext.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _mobilyaDBContext.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
