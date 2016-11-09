using LVL3.Model.Common.IDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service.Common
{
    public interface IMakeService
    {
        Task<IEnumerable<IVehicleMakeDomain>> ReadAll();
        Task<IVehicleMakeDomain> Read(Guid id);
        Task<int> Add(IVehicleMakeDomain entry);
        Task<int> Update(IVehicleMakeDomain entry);
        Task<int> Delete(IVehicleMakeDomain entry);
        Task<int> Delete(Guid id);
    }
}
