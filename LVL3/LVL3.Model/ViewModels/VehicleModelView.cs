using LVL3.Model.Common.IDatabase;
using LVL3.Model.Common.IView;
using LVL3.Model.DatabaseModels;
using System;

namespace LVL3.Model.ViewModels
{
    public class VehicleModelView : IVehicleModelView
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
