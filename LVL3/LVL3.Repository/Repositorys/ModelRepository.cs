using LVL3.Model.Common.IDomain;
using LVL3.Model.DatabaseModels;
using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Repository.Repositorys
{
    public class ModelRepository : IModelRepository
    {
        protected IRepository Repository { get; private set; }

        public ModelRepository(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<int> Add(IVehicleModelDomain entity)
        {
            return await Repository.Add<VehicleModel>(AutoMapper.Mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await Repository.Get<VehicleModel>(id);

            return await Repository.Delete<VehicleModel>(item);
        }

        public async Task<int> Delete(IVehicleModelDomain entity)
        {
            return await Repository.Delete<VehicleModel>(AutoMapper.Mapper.Map<VehicleModel>(entity));
        }

        public async Task<IVehicleModelDomain> Get(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleModelDomain>(await Repository.Get<VehicleModel>(id));
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModelDomain>>(await Repository.GetAll<VehicleModel>());
        }

        public async Task<int> Update(IVehicleModelDomain entity)
        {
            return await Repository.Update<VehicleModel>(AutoMapper.Mapper.Map<VehicleModel>(entity));
        }
    }
}
