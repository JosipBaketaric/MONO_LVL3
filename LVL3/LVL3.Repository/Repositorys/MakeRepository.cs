using LVL3.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Model.Common.IDomain;
using LVL3.Model.Common.IDatabase;
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
            return await Repository.Add<IVehicleMake>( AutoMapper.Mapper.Map<IVehicleMake>(entity) );
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await Repository.Get<IVehicleMake>(id);

            return await Repository.Delete<IVehicleMake>(item);
        }

        public async Task<int> Delete(IVehicleMakeDomain entity)
        {
            return await Repository.Delete<IVehicleMake>(AutoMapper.Mapper.Map<IVehicleMake>(entity) );
        }

        public async Task<IVehicleMakeDomain> Get(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleMakeDomain>( await Repository.Get<IVehicleMake>(id));
        }

        public async Task<IEnumerable<IVehicleMakeDomain>> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMakeDomain>>( await Repository.GetAll<IVehicleMake>());
        }

        public async Task<int> Update(IVehicleMakeDomain entity)
        {
            return await Repository.Update<IVehicleMake>(AutoMapper.Mapper.Map<IVehicleMake>(entity));
        }
    }

}
