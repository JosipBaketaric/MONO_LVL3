﻿using LVL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LVL3.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using LVL3.Repository.Common;
using LVL3.Model.Common;

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

        public async Task<IVehicleModel> Get(Guid id)
        {
            return await this.context.Set<VehicleModel>().FindAsync(id);
        }

        public async Task<IEnumerable<IVehicleModel>> GetAll()
        {
            return await this.context.Set<VehicleModel>().ToListAsync();
        }

        public IEnumerable<IVehicleModel> Find(Expression<Func<VehicleModel, bool>> predicate)
        {
            return this.context.Set<VehicleModel>().Where(predicate);
        }

        public void Add(VehicleModel entity)
        {
            this.context.Set<VehicleModel>().Add(entity);
        }

        public void Remove(IVehicleModel entity)
        {
            this.context.Set<VehicleModel>().Remove( (VehicleModel)entity);            
        }

        public async Task<IVehicleModel> SingleOrDefault(Expression<Func<VehicleModel, bool>> predicate)
        {
            return await this.context.Set<VehicleModel>().SingleOrDefaultAsync(predicate);
        }

    }

}
