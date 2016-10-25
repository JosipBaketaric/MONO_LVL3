using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Model;
using System.Collections;
using LVL3.Common.ViewModels;

namespace LVL3.Service.Common
{
    public interface IVehicleService
    {
        void Create(VehicleMakeViewModel vehicleMakeViewModel);
        void Create(VehicleModelViewModel vehicleModelViewModel);
        void DeleteMake(int id);
        void DeleteModel(int id);
        Task<IEnumerable<VehicleMakeViewModel>> ReadAllMakes();
        Task<IEnumerable<VehicleModelViewModel>> ReadAllModels();
        Task<VehicleMakeViewModel> ReadMake(int id);
        Task<VehicleModelViewModel> ReadModel(int id);
        void Update(VehicleModelViewModel vehicleModelViewModel);
        void Update(VehicleMakeViewModel vehicleMakeViewModel);
    }

}
