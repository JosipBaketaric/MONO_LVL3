using LVL3.Model;
using System;

namespace LVL3.Common.IViewModels
{
    public interface IVehicleModelViewModel
    {
        Guid VehicleModelId { get; set; }
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        VehicleMake VehicleMake { get; set; }
    }
}
