using LVL3.Model.Common.IDomain;
using System;

namespace LVL3.Model.DomainModels
{
    public class VehicleModelDomain : IVehicleModelDomain
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
