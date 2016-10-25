using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Repository.Common;
using LVL3.DAL;
using LVL3.Model;
using System.Collections;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LVL3.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await this.context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }

}
