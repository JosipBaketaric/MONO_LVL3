using LVL3.Model;
using System;
using System.Collections.Generic;

namespace LVL3.Common.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModel;
    }
}
