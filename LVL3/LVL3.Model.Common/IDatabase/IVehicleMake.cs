using System;
using System.Collections.Generic;

namespace LVL3.Model.Common.IDatabase
{
    public interface IVehicleMake
    {
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
