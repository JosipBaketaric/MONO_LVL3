using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LVL3.Model.ViewModels;

namespace LVL3.Service.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleMakeViewModel>> ReadAllMakes();
        Task<IEnumerable<VehicleModelViewModel>> ReadAllModels();
        //Create New
        void Create(VehicleMakeViewModel make);
        void Create(VehicleModelViewModel model);
        //Delete
        void DeleteMake(Guid id);
        void DeleteModel(Guid id);
        //Get One
        Task<VehicleMakeViewModel> ReadMake(Guid id);
        Task<VehicleModelViewModel> ReadModel(Guid id);
        //Update
        void Update(VehicleMakeViewModel make);
        void Update(VehicleModelViewModel model);
    }
}
