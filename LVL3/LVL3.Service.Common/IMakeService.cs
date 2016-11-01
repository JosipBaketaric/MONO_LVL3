using LVL3.Model.Common.IView;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service.Common
{
    public interface IMakeService
    {
        Task<IEnumerable<IVehicleMakeView>> ReadAll();
        Task<IVehicleMakeView> Read(Guid id);
        Task<int> Add(IVehicleMakeView entry);
        Task<int> Update(IVehicleMakeView entry);
        Task<int> Delete(IVehicleMakeView entry);
        Task<int> Delete(Guid id);
    }
}
