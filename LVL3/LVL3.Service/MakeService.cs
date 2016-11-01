using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.Common.IView;
using LVL3.Repository.Common;
using LVL3.Model.Common.IDomain;

namespace LVL3.Service
{
    public class MakeService : IMakeService
    {
        protected IMakeRepository MakeRepository { get; private set; }

        public MakeService(IMakeRepository makeRepository)
        {
            this.MakeRepository = makeRepository;
        }

        public async void Add(IVehicleMakeView entry)
        {
            await MakeRepository.Add( AutoMapper.Mapper.Map<IVehicleMakeDomain>(entry) );
        }

        public async void Delete(Guid id)
        {
            await MakeRepository.Delete(id);
        }

        public async void Delete(IVehicleMakeView entry)
        {
            await MakeRepository.Delete(AutoMapper.Mapper.Map<IVehicleMakeDomain>(entry));
        }

        public async Task<IVehicleMakeView> Read(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleMakeView>(await MakeRepository.Get(id));
        }

        public async Task<IEnumerable<IVehicleMakeView>> ReadAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMakeView>>( await MakeRepository.GetAll());
        }

        public async void Update(IVehicleMakeView entry)
        {
            await MakeRepository.Update( AutoMapper.Mapper.Map<IVehicleMakeDomain>(entry) );
        }
    }

}
