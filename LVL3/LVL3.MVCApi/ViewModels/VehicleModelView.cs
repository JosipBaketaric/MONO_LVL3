using System;

namespace LVL3.MVCApi.ViewModels
{
    public class VehicleModelView
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMakeView VehicleMake { get; set; }

    }
}
