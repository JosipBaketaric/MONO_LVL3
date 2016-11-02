using LVL3.Model.Common.IDatabase;
using LVL3.Model.Common.IDomain;
using LVL3.Model.DatabaseModels;
using System;

namespace LVL3.Model.DomainModels
{
    public class VehicleModelDomain : IVehicleModelDomain
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual IVehicleMake VehicleMake { get; set; }
    }
}
