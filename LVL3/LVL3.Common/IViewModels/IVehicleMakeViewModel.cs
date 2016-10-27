using System;

namespace LVL3.Common.IViewModels
{
    public interface IVehicleMakeViewModel
    {
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
