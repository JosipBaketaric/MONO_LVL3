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
        bool Create(VehicleModel vehicleModel);
        bool Create(VehicleMake vehicleMake);
        VehicleMake ReadMake(int? id);
        VehicleModel ReadModel(int? id);
        bool Update(VehicleMake vehicleMake);
        bool Update(VehicleModel vehicleModel);
        bool DeleteMake(int? id);
        bool DeleteModel(int? id);
        IEnumerable ReadAllMakes();
        IEnumerable ReadAllModels();
        VehicleMake FindMakeById(int? id);
        VehicleModel FindModelById(int? id);
    }
}
