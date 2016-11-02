using LVL3.Model.Common.IDomain;
using LVL3.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Repository.Common
{
    public interface IMakeRepository
    {
        Task<IVehicleMakeDomain> Get(Guid id);
        Task<IEnumerable<IVehicleMakeDomain>> GetAll();
        Task<int> Add(IVehicleMakeDomain entity);
        Task<int> Update(IVehicleMakeDomain entity);
        Task<int> Delete(IVehicleMakeDomain entity);
        Task<int> Delete(Guid id);

    }
}
