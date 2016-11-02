using LVL3.Model.Common.IDatabase;
using System;

namespace LVL3.Model.Common.IDomain
{
    public interface IVehicleModelDomain
    {
        Guid VehicleModelId { get; set; }
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
