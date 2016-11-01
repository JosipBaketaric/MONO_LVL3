using LVL3.Model.Common.IView;
using LVL3.Model.DatabaseModels;
using System;
using System.Collections.Generic;

namespace LVL3.Model.ViewModels
{
    public class VehicleMakeView : IVehicleMakeView
    {
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModel;
    }
}
