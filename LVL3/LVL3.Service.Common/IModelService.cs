using LVL3.Model.Common.IView;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LVL3.Service.Common
{
    public interface IModelService
    {
        Task<IEnumerable<IVehicleModelView>> ReadAll();
        Task<IVehicleModelView> Read(Guid id);
        Task<int> Add(IVehicleModelView entry);
        Task<int> Update(IVehicleModelView entry);
        Task<int> Delete(IVehicleModelView entry);
        Task<int> Delete(Guid id);
    }
}
