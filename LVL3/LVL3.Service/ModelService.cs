using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.Common.IView;
using LVL3.Model.Common.IDomain;
using LVL3.Repository.Common;

namespace LVL3.Service
{
    public class ModelService : IModelService
    {
        protected IModelRepository ModelRepository { get; private set; }
        
        public ModelService(IModelRepository modelRepository)
        {
            this.ModelRepository = modelRepository;
        }

        public async Task<int> Add(IVehicleModelView entry)
        {
            return await ModelRepository.Add( AutoMapper.Mapper.Map<IVehicleModelDomain>(entry) );
        }

        public async Task<int> Delete(Guid id)
        {
            return await ModelRepository.Delete(id);
        }

        public async Task<int> Delete(IVehicleModelView entry)
        {
            return await ModelRepository.Delete( AutoMapper.Mapper.Map<IVehicleModelDomain>(entry) );
        }

        public async Task<IVehicleModelView> Read(Guid id)
        {
            return AutoMapper.Mapper.Map<IVehicleModelView>( await ModelRepository.Get(id));
        }

        public async Task<IEnumerable<IVehicleModelView>> ReadAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModelView>>(await ModelRepository.GetAll());
        }

        public async Task<int> Update(IVehicleModelView entry)
        {
            return await ModelRepository.Update( AutoMapper.Mapper.Map<IVehicleModelDomain>(entry) );
        }
    }

}
