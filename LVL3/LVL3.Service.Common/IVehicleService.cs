using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Model;
using System.Collections;

namespace LVL3.Service.Common
{
    public interface IVehicleService
    {
        Task Create(VehicleMake vehicleMake);
        Task Create(VehicleModel vehicleModel);
        Task DeleteMake(int? id);
        Task DeleteModel(int? id);
        Task<VehicleMake> FindMakeById(int? id);
        Task<VehicleModel> FindModelById(int? id);
        Task<IEnumerable> ReadAllMakes();
        Task<IEnumerable> ReadAllModels();
        Task<VehicleMake> ReadMake(int? id);
        Task<VehicleModel> ReadModel(int? id);
        Task Update(VehicleModel vehicleModel);
        Task Update(VehicleMake vehicleMake);
    }

}
