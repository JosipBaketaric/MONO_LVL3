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
        void Add(IVehicleMakeView entry);
        void Update(IVehicleMakeView entry);
        void Delete(IVehicleMakeView entry);
        void Delete(Guid id);
    }
}
