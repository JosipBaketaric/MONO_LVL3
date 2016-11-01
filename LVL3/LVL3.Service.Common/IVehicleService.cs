using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.ViewModels;
using LVL3.Model.Common;

namespace LVL3.Service.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<IVehicleMakeViewModel>> ReadAllMakes();
        Task<IEnumerable<VehicleModelView>> ReadAllModels();
        //Create New
        void Create(VehicleMakeView make);
        void Create(VehicleModelView model);
        //Delete
        void DeleteMake(Guid id);
        void DeleteModel(Guid id);
        //Get One
        Task<VehicleMakeView> ReadMake(Guid id);
        Task<VehicleModelView> ReadModel(Guid id);
        //Update
        void Update(VehicleMakeView make);
        void Update(VehicleModelView model);
    }
}
