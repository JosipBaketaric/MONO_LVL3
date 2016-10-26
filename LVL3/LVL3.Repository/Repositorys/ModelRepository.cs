using LVL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LVL3.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using LVL3.Repository.Common;

namespace LVL3.Repository.Repositorys
{
    public class ModelRepository : Repository, IModelRepository
    {
        public ModelRepository(VehicleContext context)
            :base(context)
        { }

        public void Edit(VehicleModel entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<VehicleModel> Get(Guid id)
        {
            return await this.context.Set<VehicleModel>().FindAsync(id);
        }

        public async Task<IEnumerable<VehicleModel>> GetAll()
        {
            return await this.context.Set<VehicleModel>().ToListAsync();
        }

        public IEnumerable<VehicleModel> Find(Expression<Func<VehicleModel, bool>> predicate)
        {
            return this.context.Set<VehicleModel>().Where(predicate);
        }

        public void Add(VehicleModel entity)
        {
            this.context.Set<VehicleModel>().Add(entity);
        }

        public void Remove(VehicleModel entity)
        {
            this.context.Set<VehicleModel>().Remove(entity);
        }

        public async Task<VehicleModel> SingleOrDefault(Expression<Func<VehicleModel, bool>> predicate)
        {
            return await this.context.Set<VehicleModel>().SingleOrDefaultAsync(predicate);
        }

    }

}
