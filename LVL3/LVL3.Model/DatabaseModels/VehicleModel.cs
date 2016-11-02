using System;
using System.ComponentModel.DataAnnotations.Schema;
using LVL3.Model.Common.IDatabase;

namespace LVL3.Model.DatabaseModels
{
    public class VehicleModel : IVehicleModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleModelId { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[ForeignKey("VehicleMake")]
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual IVehicleMake VehicleMake { get; set; }
    }
}
