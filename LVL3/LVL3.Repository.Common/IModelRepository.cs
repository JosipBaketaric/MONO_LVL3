using LVL3.Model.Common.IDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Repository.Common
{
    public interface IModelRepository
    {
        Task<IVehicleModelDomain> Get(Guid id);
        Task<IEnumerable<IVehicleModelDomain>> GetAll();
        Task<int> Add(IVehicleModelDomain entity);
        Task<int> Update(IVehicleModelDomain entity);
        Task<int> Delete(IVehicleModelDomain entity);
        Task<int> Delete(Guid id);
    }
}
