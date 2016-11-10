using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.Common.IDomain;
using LVL3.DAL.DatabaseModels;
using LVL3.Model.DomainModels;
using LVL3.DAL.Common.IDatabase;

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
            try
            {
                var item = await Repository.Get<VehicleMake>(id);

                if (item == null)
                    return 0;

                return await Repository.Delete<VehicleMake>(item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(IVehicleMakeDomain entity)
        {
            try
            {
                return await Repository.Delete<VehicleMake>(AutoMapper.Mapper.Map<VehicleMake>(entity));
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IVehicleMakeDomain> Get(Guid id)
        {
            try
            {
                var response = AutoMapper.Mapper.Map<VehicleMakeDomain>(await Repository.Get<VehicleMake>(id));           
                return response;
            }            
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAll()
        {
            //Error stack overflow
            try
            {
                //get data
                var getData = AutoMapper.Mapper.Map<IEnumerable<IVehicleMakeDomain>>(await Repository.GetAll<VehicleMake>());
                
                return getData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(IVehicleMakeDomain entity)
        {
            return await Repository.Update<VehicleMake>(AutoMapper.Mapper.Map<VehicleMake>(entity) );
        }
    }

}
