using LVL3.Model.Common.IDomain;
using System;
using System.Collections.Generic;

namespace LVL3.Model.DomainModels
{
    public class VehicleMakeDomain : IVehicleMakeDomain
    {
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<IVehicleModelDomain> VehicleModel { get; set; }
    }
}
