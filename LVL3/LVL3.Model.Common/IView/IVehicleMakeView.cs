using LVL3.Model.Common.IDatabase;
using System;
using System.Collections.Generic;

namespace LVL3.Model.Common.IView
{
    public interface IVehicleMakeView
    {
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
