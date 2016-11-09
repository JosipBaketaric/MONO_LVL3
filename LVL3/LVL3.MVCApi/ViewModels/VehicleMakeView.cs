using System;
using System.Collections.Generic;

namespace LVL3.MVCApi.ViewModels
{
    public class VehicleMakeView
    {
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModelView> VehicleModel { get; set; }
    }
}
