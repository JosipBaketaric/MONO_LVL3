using System;

namespace LVL3.Model.Common.IDatabase
{
    public interface IVehicleModel
    {
        Guid VehicleModelId { get; set; }
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
