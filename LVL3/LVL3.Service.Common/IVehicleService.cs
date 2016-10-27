using LVL3.Common.IViewModels;
using LVL3.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
