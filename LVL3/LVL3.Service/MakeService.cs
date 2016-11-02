using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.Common.IView;
using LVL3.Repository.Common;
using LVL3.Model.Common.IDomain;
using LVL3.Model.DomainModels;

namespace LVL3.Service
{
    public class MakeService : IMakeService
    {
        protected IMakeRepository MakeRepository { get; private set; }

        public MakeService(IMakeRepository makeRepository)
        {
            this.MakeRepository = makeRepository;
        }

        public async Task<int> Add(IVehicleMakeView entry)
        {
            return await MakeRepository.Add( AutoMapper.Mapper.Map<VehicleMakeDomain>(entry) );
        }

        public async Task<int> Delete(Guid id)
        {
            return await MakeRepository.Delete(id);
        }

        public async Task<int> Delete(IVehicleMakeView entry)
        {
            return await MakeRepository.Delete(AutoMapper.Mapper.Map<VehicleMakeDomain>(entry));
        }

        public async Task<IVehicleMakeView> Read(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleMakeView>(await MakeRepository.Get(id));
        }

        public async Task<IEnumerable<IVehicleMakeView>> ReadAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMakeView>>( await MakeRepository.GetAll());
        }

        public async Task<int> Update(IVehicleMakeDomain entry)
        {
            return await MakeRepository.Update(entry);
        }

    }

}
