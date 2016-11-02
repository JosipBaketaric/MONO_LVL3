using LVL3.Model.Common.IDatabase;
using System;

namespace LVL3.Model.Common.IView
{
    public interface IVehicleModelView
    {
        Guid VehicleModelId { get; set; }
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
