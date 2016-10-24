using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVL3.Model.Common;

namespace LVL3.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
