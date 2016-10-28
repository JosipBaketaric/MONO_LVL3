using LVL3.DAL;
using LVL3.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LVL3.Repository.Common;
using LVL3.Model.Common;

namespace LVL3.Repository.Repositorys
{
    public class MakeRepository : Repository, IMakeRepository
    {
        public MakeRepository(VehicleContext context)
            :base(context)
        { }

        public void Edit(VehicleMake entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IVehicleMake> Get(Guid id)
        {
            return await this.context.Set<VehicleMake>().FindAsync(id);
        }

        public async Task<IEnumerable<IVehicleMake>> GetAll()
        {
            return await this.context.Set<VehicleMake>().ToListAsync();
        }

        public IEnumerable<IVehicleMake> Find(Expression<Func<VehicleMake, bool>> predicate)
        {
            return this.context.Set<VehicleMake>().Where(predicate);
        }

        public void Add(VehicleMake entity)
        {
            this.context.Set<VehicleMake>().Add(entity);
        }

        public void Remove(IVehicleMake entity)
        {
            this.context.Set<VehicleMake>().Remove( (VehicleMake)entity );
        }

        public async Task<IVehicleMake> SingleOrDefault(Expression<Func<VehicleMake, bool>> predicate)
        {
            return await this.context.Set<VehicleMake>().SingleOrDefaultAsync(predicate);
        }

    }

}
