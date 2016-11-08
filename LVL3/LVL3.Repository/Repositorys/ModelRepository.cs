using LVL3.Model.Common.IDomain;
using LVL3.Model.DatabaseModels;
using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            try
            {
                var response = AutoMapper.Mapper.Map<IVehicleModelDomain>(await Repository.Get<VehicleModel>(id));
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IVehicleModelDomain>> GetAll()
        {
            //Get data
            var response = AutoMapper.Mapper.Map<IEnumerable<IVehicleModelDomain>>(await Repository.GetWhereQuery<VehicleModel>().Include(x => x.VehicleMake).ToListAsync() );
            return response;
        }

        public async Task<int> Update(IVehicleModelDomain entity)
        {
            return await Repository.Update<VehicleModel>(AutoMapper.Mapper.Map<VehicleModel>(entity));
        }

        public async Task<ICollection<IVehicleModelDomain>> getMakersModels(Guid id)
        {
            var response = await Repository.GetWhereQuery<VehicleModel>().Where(x => x.VehicleMakeId == id).ToListAsync();
            var mappedResponse = AutoMapper.Mapper.Map<ICollection<IVehicleModelDomain>>(response);
            return mappedResponse;
        }

    }
}
