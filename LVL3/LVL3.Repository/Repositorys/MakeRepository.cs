using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.Common.IDomain;
using LVL3.Model.DatabaseModels;

namespace LVL3.Repository.Repositorys
{
    public class MakeRepository : IMakeRepository
    {
        protected IRepository Repository { get; private set; }

        public MakeRepository(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<int> Add(IVehicleMakeDomain entity)
        {
            return await Repository.Add<VehicleMake>( AutoMapper.Mapper.Map<VehicleMake>(entity) );
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await Repository.Get<VehicleMake>(id);

            return await Repository.Delete<VehicleMake>(item);
        }

        public async Task<int> Delete(IVehicleMakeDomain entity)
        {
            return await Repository.Delete<VehicleMake>(AutoMapper.Mapper.Map<VehicleMake>(entity) );
        }

        public async Task<IVehicleMakeDomain> Get(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleMakeDomain>( await Repository.Get<VehicleMake>(id));
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMakeDomain>>( await Repository.GetAll<VehicleMake>());
        }

        public async Task<int> Update(IVehicleMakeDomain entity)
        {
            return await Repository.Update<VehicleMake>(AutoMapper.Mapper.Map<VehicleMake>(entity));
        }
    }

}
