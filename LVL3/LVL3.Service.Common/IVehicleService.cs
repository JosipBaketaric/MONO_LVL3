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
        void Create(VehicleMake vehicleMake);
        void Create(VehicleModel vehicleModel);
        void DeleteMake(int id);
        void DeleteModel(int id);
        Task<IEnumerable<VehicleMake>> ReadAllMakes();
        Task<IEnumerable<VehicleModel>> ReadAllModels();
        Task<VehicleMake> ReadMake(int id);
        Task<VehicleModel> ReadModel(int id);
        void Update(VehicleModel vehicleModel);
        void Update(VehicleMake vehicleMake);
    }

}
