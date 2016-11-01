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
        void Add(IVehicleModelView entry);
        void Update(IVehicleModelView entry);
        void Delete(IVehicleModelView entry);
        void Delete(Guid id);
    }
}
