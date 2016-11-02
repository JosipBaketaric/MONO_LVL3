using LVL3.Repository.Common;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LVL3.DAL;
using System.Data.Entity.Infrastructure;
using LVL3.DAL.Common;
using System.Data.Entity.Migrations;

namespace LVL3.Repository.Repositorys
{
    public class Repository : IRepository
    {
        protected IVehicleContext Context { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public Repository(IVehicleContext context, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.Context = context;
            this.UnitOfWorkFactory = unitOfWorkFactory;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this.UnitOfWorkFactory.CreateUnitOfWork();
        }

        public async Task<int> Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            return await Context.SaveChangesAsync();
        }


        public async Task<int> Delete<T>(Guid id) where T : class
        {
            T entity = await Get<T>(id);
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<T> GetWhere<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().FirstAsync(match);
        }

        public async Task<T> Get<T>(Guid id) where T : class
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<int> Update<T>(T entity) where T : class
        {
            Context.Set<T>().AddOrUpdate(entity);

            return await Context.SaveChangesAsync();
        }

    }
}
