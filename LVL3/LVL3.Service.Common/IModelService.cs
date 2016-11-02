using LVL3.Model.Common.IDomain;
using LVL3.Model.Common.IView;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service.Common
{
    public interface IModelService
    {
        Task<IEnumerable<IVehicleModelDomain>> ReadAll();
        Task<IVehicleModelDomain> Read(Guid id);
        Task<int> Add(IVehicleModelDomain entry);
        Task<int> Update(IVehicleModelDomain entry);
        Task<int> Delete(IVehicleModelDomain entry);
        Task<int> Delete(Guid id);
    }
}
