using System;

namespace LVL3.Model.Common.IView
{
    public interface IVehicleMakeView
    {
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
