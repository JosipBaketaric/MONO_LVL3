using LVL3.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<int> Add(IVehicleModelDomain entry)
        {
            return await ModelRepository.Add(entry);
        }

        public async Task<int> Delete(Guid id)
        {
            return await ModelRepository.Delete(id);
        }

        public async Task<int> Delete(IVehicleModelDomain entry)
        {
            return await ModelRepository.Delete(entry);
        }

        public async Task<IVehicleModelDomain> Read(Guid id)
        {
            return await ModelRepository.Get(id);
        }

        public async Task<IEnumerable<IVehicleModelDomain>> ReadAll()
        {
            var response = await ModelRepository.GetAll();
            return response;
        }

        public async Task<int> Update(IVehicleModelDomain entry)
        {
            return await ModelRepository.Update(entry);
        }
    }

}
